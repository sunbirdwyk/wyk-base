using System;
using System.Collections;
using System.IO.Ports;
using System.Text;

namespace wyk.basic
{
    /// <summary>
    /// 短信发送处理单元
    /// </summary>
    public class SMSUtil
    {
        /// <summary>
        /// 使用GSMModem发送短信
        /// </summary>
        public class GSMModem
        {
            SerialPort ss_port = new SerialPort();
            /// <summary>
            /// 发送短信, 自动分段
            /// </summary>
            /// <param name="service_center">短信中心号码</param>
            /// <param name="text">短信内容</param>
            /// <param name="target_phone">接收手机号码</param>
            public string send(string service_center, string text, string target_phone)
            {
                try
                {
                    string response = "";
                    if (ss_port.IsOpen)
                        ss_port.Close();
                    ss_port.Open();
                    string length = "";
                    if (text.Length <= SMSPDUCoding.MAX_CHAR_COUNT)
                    {
                        #region Short SMS Send
                        string smsTemp = SMSPDUCoding.encodingSMS("00", target_phone, text, out length);
                        ss_port.WriteLine("atz"); //短信猫初始化命令
                        ss_port.WriteLine("at + cmgf=0");  //以PDU编码格式发送短信
                        ss_port.WriteLine(String.Format("at + cmgs={0}", length)); //设置通信内容长度
                        ss_port.Write(smsTemp);  //写入PDU编码的通信内容
                        ss_port.WriteLine("\x01a");  //Ctrl + Z 发送短信
                        while (true)
                        {
                            try
                            {
                                string res = readComm();
                                response += res;
                                if (res == "")
                                    break;
                            }
                            catch { break; }
                        }
                        if (response.IndexOf("ERROR") >= 0)
                        {
                            ss_port.Close();
                            return "短信发送失败,信息:" + response;
                        }
                        #endregion
                    }
                    else
                    {
                        #region Long SMS Send
                        ArrayList list = new ArrayList();
                        int start = 0;
                        while (true)
                        {
                            string msg = "";
                            if (start + SMSPDUCoding.MAX_CHAR_COUNT < text.Length)
                            {
                                msg = text.Substring(start, SMSPDUCoding.MAX_CHAR_COUNT);
                                list.Add(msg);
                                start += SMSPDUCoding.MAX_CHAR_COUNT;
                            }
                            else
                            {
                                msg = text.Substring(start);
                                list.Add(msg);
                                break;
                            }
                        }
                        for (int i = 0; i < list.Count; i++)
                        {
                            string smsTemp = SMSPDUCoding.encodingSMS(service_center, target_phone, list.Count, i + 1, text, out length);
                            ss_port.WriteLine("atz"); //短信猫初始化命令
                            ss_port.WriteLine("at + cmgf=0"); //以PDU编码格式发送短信
                            ss_port.WriteLine(String.Format("at + cmgs={0}", length));  //设置通信内容长度
                            ss_port.Write(smsTemp);  //写入PDU编码的通信内容
                            ss_port.WriteLine("\x01a"); //Ctrl + Z 发送短信
                            while (true)
                            {
                                try
                                {
                                    string res = readComm();
                                    response += res;
                                    if (res == "")
                                        break;
                                }
                                catch { break; }
                            }
                            if (response.IndexOf("ERROR") >= 0)
                            {
                                ss_port.Close();
                                return "短信发送失败,信息:" + response;
                            }
                        }
                        #endregion
                    }
                    if (ss_port.IsOpen)
                        ss_port.Close();
                    return "";
                }
                catch (Exception ex) { if (ss_port.IsOpen) ss_port.Close(); return ex.Message; }
            }

            /// <summary>
            /// 发送短信
            /// </summary>
            /// <param name="service_center">短信中心号码</param>
            /// <param name="text">短信内容</param>
            /// <param name="target_phone">接收手机号码</param>
            /// <param name="count">短信分条总量</param>
            /// <param name="index">当前第几条</param>
            /// <returns>成功返回空字符串,失败返回失败信息</returns>
            public string send(string service_center, string text, string target_phone, int count, int index)
            {
                try
                {
                    string response = "";
                    if (ss_port.IsOpen)
                        ss_port.Close();
                    ss_port.Open();
                    string length = "";
                    if (count == 1)
                    {
                        #region Short SMS Send
                        string smsTemp = SMSPDUCoding.encodingSMS("00", target_phone, text, out length);
                        ss_port.WriteLine("atz"); //短信猫初始化命令
                        ss_port.WriteLine("at + cmgf=0");  //以PDU编码格式发送短信
                        ss_port.WriteLine(String.Format("at + cmgs={0}", length)); //设置通信内容长度
                        ss_port.Write(smsTemp);  //写入PDU编码的通信内容
                        ss_port.WriteLine("\x01a");  //Ctrl + Z 发送短信
                        while (true)
                        {
                            try
                            {
                                string res = readComm();
                                response += res;
                                if (res == "")
                                    break;
                            }
                            catch { break; }
                        }
                        if (response.IndexOf("ERROR") >= 0)
                        {
                            ss_port.Close();
                            return "短信发送失败,信息:" + response;
                        }
                        #endregion
                    }
                    else
                    {
                        #region Long SMS Send
                        string smsTemp = SMSPDUCoding.encodingSMS(service_center, target_phone, count, index, text, out length);
                        ss_port.WriteLine("atz"); //短信猫初始化命令
                        ss_port.WriteLine("at + cmgf=0"); //以PDU编码格式发送短信
                        ss_port.WriteLine(String.Format("at + cmgs={0}", length));  //设置通信内容长度
                        ss_port.Write(smsTemp);  //写入PDU编码的通信内容
                        ss_port.WriteLine("\x01a"); //Ctrl + Z 发送短信
                        while (true)
                        {
                            try
                            {
                                string res = readComm();
                                response += res;
                                if (res == "")
                                    break;
                            }
                            catch { break; }
                        }
                        if (response.IndexOf("ERROR") >= 0)
                        {
                            ss_port.Close();
                            return "短信发送失败,信息:" + response;
                        }
                        #endregion
                    }
                    if (ss_port.IsOpen)
                        ss_port.Close();
                    return "";
                }
                catch (Exception ex) { if (ss_port.IsOpen) ss_port.Close(); return ex.Message; }
            }

            /// <summary>
            /// 获取串口应答
            /// </summary>
            /// <returns></returns>
            public string readComm()
            {
                byte[] buffer = new byte[ss_port.ReadBufferSize];
                ss_port.Read(buffer, 0, buffer.Length);
                return Encoding.ASCII.GetString(buffer).Trim('\0');
            }

            /// <summary>
            /// 初始化串口
            /// </summary>
            /// <param name="m_port">串口号</param>
            /// <param name="m_baudrate">波特率</param>
            /// <returns>成功返回空字符串,失败返回失败信息</returns>
            public string initCom(string m_port, int m_baudrate)
            {
                ss_port = new SerialPort();
                ss_port.PortName = m_port;
                ss_port.BaudRate = m_baudrate;
                ss_port.DataBits = 8;
                ss_port.Parity = 0;
                ss_port.StopBits = StopBits.One;
                ss_port.ReadTimeout = 1000;
                try
                {
                    if (ss_port.IsOpen)
                        ss_port.Close();
                    ss_port.Open();
                    ss_port.Close();
                    return "";
                }
                catch (Exception ex) { return ex.Message; }
            }
        }
    }
}