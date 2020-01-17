using System.Collections.Generic;
using System.ComponentModel;

namespace wyk.basic
{
    /// <summary>
    /// 网络相关操作单元
    /// </summary>
    public class WebUtil
    {
        public static Dictionary<string, string> getPostParamList(string post_content)
        {
            var result = new Dictionary<string, string>();
            string[] parts = post_content.Split('&');
            foreach(string sub in parts)
            {
                if (sub.isNull())
                    continue;
                string[] subs = sub.Split('=');
                if (subs.Length != 2)
                    continue;
                string key = subs[0].Trim();
                if (key.isNull())
                    continue;
                try
                {
                    result[key] = subs[1];
                }
                catch { }
            }
            return result;
        }

        /// <summary>
        /// 下载文件(分段,显示进度)(form)
        /// </summary>
        /// <param name="URL">下载地址</param>
        /// <param name="filename">保存地址</param>
        /// <param name="bgw">BackgroundWorker,用于报告进度</param>
        public static void downloadFile(string URL, string filename, BackgroundWorker bgw)
        {
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                long totalBytes = response.ContentLength;
                System.IO.Stream st = response.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = 0;
                do
                {
                    osize = st.Read(by, 0, (int)by.Length);
                    totalDownloadedByte = osize + totalDownloadedByte;
                    so.Write(by, 0, osize);
                    if (bgw != null)
                        bgw.ReportProgress(1, totalDownloadedByte * 100 / totalBytes);
                } while (osize > 0);
                so.Close();
                st.Close();
                bgw.ReportProgress(-2);
            }
            catch { }
        }

        /// <summary>
        /// 获取可以在alert中显示的字符串(替换掉无法正常显示的字符)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string stringShowingForAlert(string source)
        {
            return source.Replace('\'', '\"').Replace("\r\n", "    ");
        }
    }
}