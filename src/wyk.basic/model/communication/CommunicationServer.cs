using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace wyk.basic
{
    //当检测到结束符时, 将结束符之前的所有数据拿出来上报(仅用于调试)
    public delegate void OnCommunicationDataEndPointReached(string ip, byte[] data);
    //当检测到数据包时, 将数据包上报(仅用于调试)
    public delegate void OnCommunicationDataBlockReceived(string ip, CommDataBlock block);
    //当检测到数据内容段(完整数据)时, 将完整数据解包后上报
    public delegate void OnCommunicationDataContentReceived(string ip, CommDataContent content);
    //新客户端连接时的通知
    public delegate void OnCommunicationNewClientConnected(string ip);

    public class CommunicationServer
    {
        public static OnCommunicationDataEndPointReached OnDataEndPointReached = null;
        public static OnCommunicationDataBlockReceived OnDataBlockReceived = null;
        public static OnCommunicationDataContentReceived OnDataContentReceived = null;
        public static OnCommunicationNewClientConnected OnNewClientConnected = null;
        //在没有传入端口号或者端口号传入有问题时, 使用默认端口号
        const int MAX_DATA_BUFFER = 10000000; //队列中最多存10M的数据

        static bool current_ack_mode = false;
        static int current_server_port = 9008;
        static int current_client_port = 9009;

        //注: 由于此通信为自建通信, 严格走本通信定义的数据包格式, 结束符为 0x04(EOT)

        //UDP
        static UdpClient udp_receive = null;
        static UdpClient udp_send = new UdpClient();
        //
        static Thread th_server = null;
        static Thread th_server_data_process = null;
        static Dictionary<string, Thread> th_server_data_sends = new Dictionary<string, Thread>();
        static Thread th_server_ack_send = null;

        static Dictionary<string, List<byte>> received_data = new Dictionary<string, List<byte>>();
        static Dictionary<string, List<CommDataBlock>> sending_data = new Dictionary<string, List<CommDataBlock>>();
        static Dictionary<string, List<CommDataBlock>> sending_acks = new Dictionary<string, List<CommDataBlock>>();
        static Dictionary<string, List<CommDataBlock>> received_blocks = new Dictionary<string, List<CommDataBlock>>();
        static Dictionary<string, Dictionary<uint, bool>> ack_status = new Dictionary<string, Dictionary<uint, bool>>();

        static Dictionary<string, List<uint>> recent_raised_tasks = new Dictionary<string, List<uint>>();

        static bool _server_started = false;

        public static bool server_started
        {
            get => _server_started;
        }

        public static string[] clients
        {
            get
            {
                if (th_server_data_sends.Count <= 0)
                    return new string[0];
                var list = new string[th_server_data_sends.Count];
                th_server_data_sends.Keys.CopyTo(list, 0);
                return list;
            }
        }

        /// <summary>
        /// 服务器开始监听
        /// </summary>
        /// <param name="port">监听端口(注:UDP模式客户端自动使用此端口+1, 请注意分配端口)</param>
        /// <param name="ack_mode">是否应答模式</param>
        /// <returns></returns>
        public static string startServer(int port, bool ack_mode)
        {
            try
            {
                if (_server_started)
                {
                    stopServer();
                    Thread.Sleep(1000);
                }
                current_ack_mode = ack_mode;
                current_server_port = port;
                current_client_port = port + 1;

                //UDP时, 如果没有指定客户端端口, 则使用服务端端口+1

                th_server = new Thread(udpServerListening);
                th_server.IsBackground = true;
                th_server.Start();
                th_server_data_process = new Thread(udpServerDataProcess);
                th_server_data_process.IsBackground = true;
                th_server_data_process.Start();
                th_server_data_sends = new Dictionary<string, Thread>();
                th_server_ack_send = new Thread(udpServerAckSend);
                th_server_ack_send.IsBackground = true;
                th_server_ack_send.Start();
                _server_started = true;
                return "";
            }
            catch { return "服务器开启失败"; }
        }

        /// <summary>
        /// 服务器开始监听UDP模式, 指定客户端端口号
        /// </summary>
        /// <param name="server_port">服务器端口号</param>
        /// <param name="client_port">客户端端口号</param>
        /// <param name="ack_mode">是否应答模式</param>
        /// <returns></returns>
        public static string startServer(int server_port, int client_port, bool ack_mode)
        {
            try
            {
                if (_server_started)
                {
                    stopServer();
                    Thread.Sleep(1000);
                }
                current_ack_mode = ack_mode;
                current_server_port = server_port;
                current_client_port = client_port;

                th_server = new Thread(udpServerListening);
                th_server.IsBackground = true;
                th_server.Start();
                th_server_data_process = new Thread(udpServerDataProcess);
                th_server_data_process.IsBackground = true;
                th_server_data_process.Start();
                th_server_data_sends = new Dictionary<string, Thread>();
                th_server_ack_send = new Thread(udpServerAckSend);
                th_server_ack_send.IsBackground = true;
                th_server_ack_send.Start();
                _server_started = true;
                return "";
            }
            catch { return "服务器开启失败"; }
        }

        public static void stopServer()
        {
            if (udp_receive != null)
            {
                try
                {
                    udp_receive.Close();
                }
                catch { }
                udp_receive = null;
            }
            received_data.Clear();
            sending_data.Clear();
            sending_acks.Clear();
            received_blocks.Clear();
            ack_status.Clear();
            recent_raised_tasks.Clear();

            try
            {
                th_server_data_process.Abort();
            }
            catch { }
            th_server_data_process = null;

            foreach (var th in th_server_data_sends.Values)
            {
                try
                {
                    th.Abort();
                }
                catch { }
                th_server_data_sends = new Dictionary<string, Thread>();
            }

            try
            {
                th_server_ack_send.Abort();
            }
            catch { }
            th_server_ack_send = null;

            try
            {
                th_server.Abort();
            }
            catch { }
            th_server = null;
            _server_started = false;
        }

        public static void sendData(string ip, string data_content)
        {
            try
            {
                if (data_content.isNull())
                    return;
                if (!sending_data.ContainsKey(ip) || sending_data[ip] == null)
                    sending_data[ip] = new List<CommDataBlock>();
                var dc = new CommDataContent(data_content);
                foreach (var db in dc.data_blocks)
                {
                    sending_data[ip].Add(db.Value);
                }
                sending_data[ip].Add(CommDataBlock.createEndBlock(dc.task_id));
            }
            catch { }
        }

        #region udp
        private static void udpServerListening()
        {
            udp_receive = new UdpClient(current_server_port);
            while (true)
            {
                try
                {
                    var remote_point = new IPEndPoint(IPAddress.Any, current_server_port);
                    var data = udp_receive.Receive(ref remote_point);
                    var ip = remote_point.Address.ToString();
                    if (!th_server_data_sends.ContainsKey(ip))
                    {
                        var th = new Thread(new ParameterizedThreadStart(udpServerDataSend));
                        th.IsBackground = true;
                        th.Start(ip);
                        th_server_data_sends[ip] = th;
                        OnNewClientConnected?.Invoke(ip);
                    }
                    if (!received_data.ContainsKey(ip) || received_data[ip] == null)
                        received_data[ip] = new List<byte>();
                    if (data != null && data.Length > 0)
                        received_data[ip].AddRange(data);
                    if (received_data[ip].Count > MAX_DATA_BUFFER)
                        received_data[ip].RemoveRange(0, received_data[ip].Count - MAX_DATA_BUFFER);
                }
                catch { Thread.Sleep(50); }
            }
        }

        private static void udpServerDataProcess()
        {
            while (true)
            {
                Thread.Sleep(50);
                try
                {
                    foreach (var data in received_data)
                    {
                        if (data.Value == null || data.Value.Count <= 0)
                            continue;
                        var ip = data.Key;
                        var data_content = data.Value;
                        while (true)
                        {
                            bool found_end = false;
                            for (int i = 0; i < data_content.Count; i++)
                            {
                                if (data_content[i] == 0x04)
                                {//遇到结束符时, 截取前面所有数据进行处理
                                    var buffer = new byte[i + 1];
                                    data_content.CopyTo(0, buffer, 0, buffer.Length);
                                    processReceivedData(ip, buffer);
                                    data_content.RemoveRange(0, buffer.Length);
                                    found_end = true;
                                }
                            }
                            if (!found_end)
                                break;
                        }
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 在ACK Mode时, 发送数据包需要等ACK, 如果没有, 尝试发送3次
        /// 注: 为了防止在ACK Mode时等待卡住, 每个与客户端的连接都启动一个数据发送线程
        /// </summary>
        private static void udpServerDataSend(object param)
        {
            var ip = param.ToString();
            if (!sending_data.ContainsKey(ip) || sending_data[ip] == null)
                sending_data[ip] = new List<CommDataBlock>();
            var end_point = new IPEndPoint(IPAddress.Parse(ip), current_client_port);
            var data = sending_data[ip];
            while (true)
            {
                Thread.Sleep(50);
                try
                {
                    if (data.Count <= 0)
                        continue;
                    while (data.Count > 0)
                    {
                        try
                        {
                            if (current_ack_mode)
                            {
                                var task_id = data[0].getTaskId();
                                if (!ack_status.ContainsKey(ip))
                                    ack_status[ip] = new Dictionary<uint, bool>();
                                ack_status[ip][task_id] = false;
                                int check = 0;
                                while (!ack_status[ip][task_id])
                                {
                                    if (check % 20 == 0)
                                        udp_send.Send(data[0].content_bytes, data[0].content_bytes.Length, end_point);
                                    Thread.Sleep(50);
                                    check++;
                                    if (check >= 60)
                                        break;
                                }
                            }
                            else
                            {
                                udp_send.Send(data[0].content_bytes, data[0].content_bytes.Length, end_point);
                                Thread.Sleep(50);
                            }
                            data.RemoveAt(0);
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// ACK回应不需要收确认包之后走下一个, 只需要一直走就行
        /// </summary>
        private static void udpServerAckSend()
        {
            while (true)
            {
                Thread.Sleep(30);
                if (sending_acks == null || sending_acks.Count <= 0)
                    continue;
                try
                {
                    foreach (var data in sending_acks)
                    {
                        if (data.Value.Count <= 0)
                            continue;
                        while (data.Value.Count > 0)
                        {
                            try
                            {
                                var end_point = new IPEndPoint(IPAddress.Parse(data.Key), current_client_port);
                                udp_send.Send(data.Value[0].content_bytes, data.Value[0].content_bytes.Length, end_point);
                            }
                            catch { }
                            data.Value.RemoveAt(0);
                            Thread.Sleep(10);
                        }
                    }
                }
                catch { }
            }
        }
        #endregion

        private static void processReceivedData(string ip, byte[] data)
        {
            try
            {
                OnDataEndPointReached?.Invoke(ip, data);
                var start_index = -1;
                for (int i = data.Length - 2; i >= 0; i--)
                {
                    if (data[i] == 0x01)
                    {
                        start_index = i;
                        break;
                    }
                }
                byte[] buffer;
                if (start_index >= 0)
                {
                    buffer = new byte[data.Length - start_index];
                    Array.Copy(data, start_index, buffer, 0, buffer.Length);
                }
                else
                {
                    buffer = new byte[data.Length + 1];
                    buffer[0] = 0x01;
                    Array.Copy(data, 0, buffer, 1, data.Length);
                }
                var db = new CommDataBlock()
                {
                    content_bytes = buffer
                };
                if (db.isAvailableHello())
                {
                    OnDataBlockReceived?.Invoke(ip, db);
                    if (!sending_acks.ContainsKey(ip))
                        sending_acks[ip] = new List<CommDataBlock>();
                    sending_acks[ip].Add(CommDataBlock.createAckBlock(0, 0));
                }
                else if (db.isAvailableEnd()) //传输结束, 上报全部收取内容
                {
                    OnDataBlockReceived?.Invoke(ip, db);
                    var task_id = db.getTaskId();
                    if (current_ack_mode)
                    {
                        if (!sending_acks.ContainsKey(ip))
                            sending_acks[ip] = new List<CommDataBlock>();
                        sending_acks[ip].Add(CommDataBlock.createAckBlock(task_id, 0));
                    }
                    raiseTask(ip, task_id);
                }
                else if (db.isAvailableAck()) //收到确认包
                {
                    OnDataBlockReceived?.Invoke(ip, db);
                    ack_status[ip][db.getTaskId()] = true;
                }
                else if (db.isAvailableData()) //收到数据包
                {
                    OnDataBlockReceived?.Invoke(ip, db);
                    if (!received_blocks.ContainsKey(ip))
                        received_blocks[ip] = new List<CommDataBlock>();
                    received_blocks[ip].Add(db);
                    if (db.content_bytes.Length < CommDataContent.DATA_BLOCK_SIZE)
                    {//在收到的数据包长度小于最大长度值时, 已可以确认收到了全部的内容, 直接调起当前任务
                        raiseTask(ip, db.getTaskId());
                    }
                    if (current_ack_mode)
                    {
                        if (!sending_acks.ContainsKey(ip))
                            sending_acks[ip] = new List<CommDataBlock>();
                        sending_acks[ip].Add(CommDataBlock.createAckBlock(db.getTaskId(), db.getBlockId()));
                    }
                }
            }
            catch { }
        }

        private static void raiseTask(string ip, uint task_id)
        {
            var dbl = new SortedList<uint, CommDataBlock>();
            for (int i = 0; i < received_blocks[ip].Count; i++)
            {
                var rdb = received_blocks[ip][i];
                if (rdb.getTaskId() == task_id)
                {
                    var block_id = rdb.getBlockId();
                    //判断是否有重复的block_id, 有的话忽略, 重复的block有可能是在传输过程中ACK确认未收到导致多次发送
                    if (!dbl.ContainsKey(block_id))
                        dbl.Add(block_id, rdb);
                    received_blocks[ip].RemoveAt(i);
                    i--;
                }
            }
            if (dbl.Count <= 0)
                return;
            if (!recent_raised_tasks.ContainsKey(ip))
                recent_raised_tasks[ip] = new List<uint>();
            //判断是否重复触发
            if (recent_raised_tasks[ip].Contains(task_id))
                return;
            recent_raised_tasks[ip].Add(task_id);
            if (recent_raised_tasks[ip].Count > 100)
                recent_raised_tasks[ip].RemoveRange(0, recent_raised_tasks[ip].Count - 100);

            var content = new CommDataContent()
            {
                data_blocks = dbl
            };
            OnDataContentReceived?.Invoke(ip, content);
        }
    }
}