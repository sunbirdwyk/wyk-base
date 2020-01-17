using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace wyk.basic
{
    /// <summary>
    /// 通用(未分类)功能单元
    /// </summary>
    public class CommonUtil
    {
        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void openFolder(string path)
        {
            try
            {
                Process.Start("explorer.exe", path);
            }
            catch { }
        }

        /// <summary>
        /// 运行cmd命令
        /// </summary>
        /// <param name="command"></param>
        public static void runCmdCommand(string command)
        {
            runCmdCommand(command, null);
        }

        /// <summary>
        /// 运行cmd命令, 带结果回调
        /// </summary>
        /// <param name="command"></param>
        /// <param name="data_receive_handler"></param>
        public static void runCmdCommand(string command, DataReceivedEventHandler data_receive_handler)
        {
            if (command.isNull())
                return;
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                if (data_receive_handler != null)
                    p.OutputDataReceived += data_receive_handler;
                p.Start();
                StreamWriter cmdWriter = p.StandardInput;
                p.BeginOutputReadLine();
                cmdWriter.WriteLine(command);
                cmdWriter.Close();
                p.WaitForExit();
                p.Close();
            }
            catch { }
            /*
             * DataReceiveHandler Example
            private void data_receive_handler(object sender, DataReceivedEventArgs e)
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    this.BeginInvoke(newAction(() => { this.listBox1.Items.Add(e.Data); }));
                }
            }*/
        }

        /// <summary>
        /// 获取本地IP地址
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetLocalIP()
        {
            IPHostEntry ieh = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0; i < ieh.AddressList.Length; i++)
            {
                if (ieh.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                { return ieh.AddressList[i]; }
            }
            return null;
        }

        /// <summary>
        /// 获取本地所有可用IP地址列表
        /// </summary>
        /// <returns></returns>
        public static IPAddress[] GetLocalIPs()
        {
            IPHostEntry ieh = Dns.GetHostEntry(Dns.GetHostName());
            return ieh.AddressList;
        }

        /// <summary>
        /// 深拷贝对象
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static object deepCopy(object source)
        {
            object target;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, source);
                ms.Seek(0, SeekOrigin.Begin);
                target = bf.Deserialize(ms);
                ms.Close();
            }
            return target;
        }

        /// <summary>
        /// 版本号对比, 子版本号之间以.分隔
        /// </summary>
        /// <param name="source_version">当前版本号</param>
        /// <param name="target_version">目标版本号</param>
        /// <returns>0: 相等, 1: 大于, -1:小于</returns>
        public static int versionCompare(string source_version, string target_version)
        {
            return versionCompare(source_version, target_version, '.');
        }

        /// <summary>
        /// 版本号对比, 子版本号之间分隔符自定义
        /// </summary>
        /// <param name="source_version">当前版本号</param>
        /// <param name="target_version">目标版本号</param>
        /// <param name="separator">分隔符</param>
        /// <returns>0: 相等, 1: 大于, -1:小于</returns>
        public static int versionCompare(string source_version, string target_version, char separator)
        {
            string[] parts_s = source_version.Split(separator);
            string[] parts_t = target_version.Split(separator);
            int count = parts_s.Length > parts_t.Length ? parts_s.Length : parts_t.Length;
            for (int i = 0; i < count; i++)
            {
                int ver = 0;
                try
                {
                    ver = Convert.ToInt32(parts_s[i]);
                    if (ver < 0)
                        ver = 0;
                }
                catch { }
                int ver2 = 0;
                try
                {
                    ver2 = Convert.ToInt32(parts_t[i]);
                    if (ver2 < 0)
                        ver = 0;
                }
                catch { }
                if (ver < ver2)
                    return -1;
                else if (ver > ver2)
                    return 1;
            }
            return 0;
        }

        /// <summary>
        /// 检查端口是否被占用
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="isUdp">true:UDP通信,false:TCP通信</param>
        /// <returns></returns>
        public static bool isPortBusy(int port, bool isUdp = true)
        {
            var ip_properties = IPGlobalProperties.GetIPGlobalProperties();
            var ip_end_points = isUdp ? ip_properties.GetActiveUdpListeners() : ip_properties.GetActiveTcpListeners();
            for (int i = 0; i < ip_end_points.Length; i++)
            {
                if (ip_end_points[i].Port == port)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 直接杀掉占用指定端口的进程
        /// </summary>
        public static void killProcessByPort(int port, bool isUdp = true)
        {
            using (var p = new Process())
            {
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;

                p.Start();
                p.StandardInput.WriteLine($"netstat -ano|find \"{port}\"");
                p.StandardInput.WriteLine("exit");
                var pids = new List<int>();
                using (var reader = p.StandardOutput)
                {
                    var str = reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        str = str.Trim();
                        if (str.Length > 0 && ((isUdp && str.Contains("UDP")) || (!isUdp && str.Contains("TCP"))))
                        {
                            var r = new Regex(@"\s+");
                            var strs = r.Split(str);
                            if (strs.Length >= 4)
                            {
                                var pid = strs[3].toInt();
                                if (pid > 0 && !pids.Contains(pid))
                                    pids.Add(pid);
                            }
                        }
                        str = reader.ReadLine();
                    }
                }
                p.Close();

                if (pids.Count > 0)
                {
                    for (int i = 0; i < pids.Count; i++)
                    {
                        p.Start();
                        p.StandardInput.WriteLine($"taskkill /pid {pids[i]} /f");
                        p.StandardInput.WriteLine("exit");
                        p.Close();
                    }
                }
            }
        }
    }
}