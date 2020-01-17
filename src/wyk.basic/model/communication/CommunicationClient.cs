using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace wyk.basic
{
    public class CommunicationClient
    {
        public static OnCommunicationDataEndPointReached OnDataEndPointReached = null;
        public static OnCommunicationDataBlockReceived OnDataBlockReceived = null;
        public static OnCommunicationDataContentReceived OnDataContentReceived = null;
        const int MAX_DATA_BUFFER = 10000000; //队列中最多存10M的数据

        static IPEndPoint server = null;
        static bool current_ack_mode = false;
        static int current_server_port = 9008;
        static int current_client_port = 9009;

        static UdpClient udp_send = new UdpClient();
        static UdpClient udp_receive = null;

        static List<CommDataBlock> received_blocks = new List<CommDataBlock>();
        static List<CommDataBlock> sending_data = new List<CommDataBlock>();
        static List<CommDataBlock> sending_acks = new List<CommDataBlock>();
        static Dictionary<uint, bool> ack_status = new Dictionary<uint, bool>();
        static List<uint> recent_raised_tasks = new List<uint>();

        static List<byte> received_data_unsolved = new List<byte>();

        static Thread th_client = null;
        static Thread th_client_data_send = null;
        static Thread th_client_ack_send = null;
        static Thread th_client_data_process = null;

        public static void init()
        {
            try
            {
                udp_send = new UdpClient();
                received_blocks = new List<CommDataBlock>();
                sending_data = new List<CommDataBlock>();
                sending_acks = new List<CommDataBlock>();
                ack_status = new Dictionary<uint, bool>();
                recent_raised_tasks = new List<uint>();

                received_data_unsolved = new List<byte>();

                if (th_client_data_send == null)
                {
                    th_client_data_send = new Thread(udpClientDataSend);
                    th_client_data_send.IsBackground = true;
                }
                if (!th_client_data_send.IsAlive)
                    th_client_data_send.Start();

                if (th_client_ack_send == null)
                {
                    th_client_ack_send = new Thread(udpClientAckSend);
                    th_client_ack_send.IsBackground = true;
                }
                if (!th_client_ack_send.IsAlive)
                    th_client_ack_send.Start();

                if (th_client_data_process == null)
                {
                    th_client_data_process = new Thread(udpClientDataProcess);
                    th_client_data_process.IsBackground = true;
                }
                if (!th_client_data_process.IsAlive)
                    th_client_data_process.Start();

                if (th_client == null)
                {
                    th_client = new Thread(udpClientListening);
                    th_client.IsBackground = true;
                }
                if (!th_client.IsAlive)
                    th_client.Start();
            }
            catch { }
        }

        public static void deinit()
        {
            try
            {
                OnDataBlockReceived = null;
                OnDataContentReceived = null;
                OnDataEndPointReached = null;

                if (udp_receive != null)
                {
                    try
                    {
                        udp_receive.Close();
                    }
                    catch { }
                    udp_receive = null;
                }
                if (udp_send != null)
                {
                    try
                    {
                        udp_send.Close();
                    }
                    catch { }
                    udp_send = null;
                }
                if (th_client != null)
                {
                    try
                    {
                        th_client.Abort();
                    }
                    catch { }
                    th_client = null;
                }
                received_blocks = new List<CommDataBlock>();
                sending_data = new List<CommDataBlock>();
                sending_acks = new List<CommDataBlock>();
                ack_status = new Dictionary<uint, bool>();
                received_data_unsolved = new List<byte>();
                recent_raised_tasks = new List<uint>();

                if (th_client_data_send != null)
                {
                    try
                    {
                        th_client_data_send.Abort();
                    }
                    catch { }
                    th_client_data_send = null;
                }

                if (th_client_ack_send != null)
                {
                    try
                    {
                        th_client_ack_send.Abort();
                    }
                    catch { }
                    th_client_ack_send = null;
                }

                if (th_client_data_process != null)
                {
                    try
                    {
                        th_client_data_process.Abort();
                    }
                    catch { }
                    th_client_data_process = null;
                }
            }
            catch { }
        }

        /// <summary>
        /// 开始连接服务器, UDP模式, 客户端端口号为服务器端口号+1
        /// </summary>
        /// <param name="ip_address">服务器IP地址</param>
        /// <param name="server_port">服务端端口号</param>
        /// <param name="ack_mode">是否应答模式</param>
        /// <returns></returns>
        public static void setServer(string ip_address, int server_port, bool ack_mode)
        {
            setServer(ip_address, server_port, server_port + 1, ack_mode);
        }

        /// <summary>
        /// 开始连接服务器, UDP模式, 指定客户端端口号
        /// </summary>
        /// <param name="ip_address">服务器IP地址</param>
        /// <param name="server_port">服务端端口号</param>
        /// <param name="client_port">客户端端口号</param>
        /// <param name="ack_mode">是否应答模式</param>
        /// <returns></returns>
        public static void setServer(string ip_address, int server_port, int client_port, bool ack_mode)
        {
            try
            {
                if (ip_address.isNull())
                    ip_address = "127.0.0.1";
                current_ack_mode = ack_mode;
                current_server_port = server_port;
                current_client_port = client_port;
                if (udp_receive != null)
                {
                    try
                    {
                        udp_receive.Close();
                    }
                    catch { }
                    udp_receive = null;
                }

                server = new IPEndPoint(IPAddress.Parse(ip_address), current_server_port);
            }
            catch { }
        }

        public static bool checkConnection()
        {
            try
            {
                if (sending_data == null)
                    sending_data = new List<CommDataBlock>();
                sending_data.Add(CommDataBlock.createHelloBlock());
                var check = 0;
                ack_status[0] = false;
                while (check < 60)
                {
                    Thread.Sleep(50);
                    check++;
                    if (ack_status.ContainsKey(0) && ack_status[0])
                        return true;
                }
            }
            catch { }
            return false;
        }

        public static void sendData(string data_content)
        {
            try
            {
                if (data_content.isNull())
                    return;
                if (sending_data == null)
                    sending_data = new List<CommDataBlock>();
                var dc = new CommDataContent(data_content);
                foreach (var db in dc.data_blocks)
                {
                    sending_data.Add(db.Value);
                }
                sending_data.Add(CommDataBlock.createEndBlock(dc.task_id));
            }
            catch { }
        }

        #region udp
        private static void udpClientDataSend()
        {
            while (true)
            {
                Thread.Sleep(50);
                try
                {
                    if (sending_data == null || sending_data.Count <= 0)
                        continue;
                    while (sending_data.Count > 0)
                    {
                        try
                        {
                            if (current_ack_mode)
                            {
                                var task_id = sending_data[0].getTaskId();
                                ack_status[task_id] = false;
                                int check = 0;
                                while (!ack_status[task_id])
                                {
                                    if (check % 20 == 0)
                                        udp_send.Send(sending_data[0].content_bytes, sending_data[0].content_bytes.Length, server);
                                    Thread.Sleep(50);
                                    check++;
                                    if (check >= 60)
                                        break;
                                }
                            }
                            else
                            {
                                udp_send.Send(sending_data[0].content_bytes, sending_data[0].content_bytes.Length, server);
                                Thread.Sleep(50);
                            }
                            sending_data.RemoveAt(0);
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }

        private static void udpClientAckSend()
        {
            while (true)
            {
                Thread.Sleep(50);
                try
                {
                    while (sending_acks.Count > 0)
                    {
                        try
                        {
                            udp_send.Send(sending_acks[0].content_bytes, sending_acks[0].content_bytes.Length, server);
                        }
                        catch { }
                        sending_acks.RemoveAt(0);
                        Thread.Sleep(10);
                    }
                }
                catch { }
            }
        }

        private static void udpClientListening()
        {
            while (true)
            {
                try
                {
                    if (udp_receive == null)
                        udp_receive = new UdpClient(current_client_port);
                    if (udp_receive != null)
                    {
                        var remote_point = new IPEndPoint(IPAddress.Any, current_client_port);
                        var data = udp_receive.Receive(ref remote_point);
                        if (data != null && data.Length > 0)
                            received_data_unsolved.AddRange(data);
                        if (received_data_unsolved.Count > MAX_DATA_BUFFER)
                            received_data_unsolved.RemoveRange(0, received_data_unsolved.Count - MAX_DATA_BUFFER);
                    }
                }
                catch { Thread.Sleep(50); }
            }
        }

        private static void udpClientDataProcess()
        {
            while (true)
            {
                Thread.Sleep(50);
                if (received_data_unsolved == null || received_data_unsolved.Count <= 0)
                    continue;
                try
                {
                    while (true)
                    {
                        bool found_end = false;
                        for (int i = 0; i < received_data_unsolved.Count; i++)
                        {
                            if (received_data_unsolved[i] == 0x04)
                            {//遇到结束符时, 截取前面所有数据进行处理
                                var buffer = new byte[i + 1];
                                received_data_unsolved.CopyTo(0, buffer, 0, buffer.Length);
                                processReceivedData(buffer);
                                received_data_unsolved.RemoveRange(0, buffer.Length);
                                found_end = true;
                            }
                        }
                        if (!found_end)
                            break;
                    }
                }
                catch { }
            }
        }
        #endregion

        private static void processReceivedData(byte[] data)
        {
            try
            {
                OnDataEndPointReached?.Invoke("", data);
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
                    OnDataBlockReceived?.Invoke("", db);
                    sending_acks.Add(CommDataBlock.createAckBlock(0, 0));
                }
                else if (db.isAvailableEnd()) //传输结束, 上报全部收取内容
                {
                    OnDataBlockReceived?.Invoke("", db);
                    var task_id = db.getTaskId();
                    if (current_ack_mode)
                        sending_acks.Add(CommDataBlock.createAckBlock(task_id, 0));
                    raiseTask(task_id);
                }
                else if (db.isAvailableAck()) //收到确认包
                {
                    OnDataBlockReceived?.Invoke("", db);
                    ack_status[db.getTaskId()] = true;
                }
                else if (db.isAvailableData()) //收到数据包
                {
                    OnDataBlockReceived?.Invoke("", db);
                    received_blocks.Add(db);
                    if (db.content_bytes.Length < CommDataContent.DATA_BLOCK_SIZE)
                    {//在收到的数据包长度小于最大长度值时, 已可以确认收到了全部的内容, 直接调起当前任务
                        raiseTask(db.getTaskId());
                    }
                    if (current_ack_mode)
                        sending_acks.Add(CommDataBlock.createAckBlock(db.getTaskId(), db.getBlockId()));
                }
            }
            catch { }
        }

        private static void raiseTask(uint task_id)
        {
            try
            {
                var dbl = new SortedList<uint, CommDataBlock>();
                for (int i = 0; i < received_blocks.Count; i++)
                {
                    var rdb = received_blocks[i];
                    if (rdb.getTaskId() == task_id)
                    {
                        var block_id = rdb.getBlockId();
                        //判断是否有重复的block_id, 有的话忽略, 重复的block有可能是在传输过程中ACK确认未收到导致多次发送
                        if (!dbl.ContainsKey(block_id))
                            dbl.Add(block_id, rdb);
                        received_blocks.RemoveAt(i);
                        i--;
                    }
                }
                if (dbl.Count <= 0)
                    return;
                //判断是否重复触发
                if (recent_raised_tasks.Contains(task_id))
                    return;
                recent_raised_tasks.Add(task_id);
                if (recent_raised_tasks.Count > 100)
                    recent_raised_tasks.RemoveRange(0, recent_raised_tasks.Count - 100);
                var content = new CommDataContent()
                {
                    data_blocks = dbl
                };
                OnDataContentReceived?.Invoke("", content);
            }
            catch { }
        }
    }
}