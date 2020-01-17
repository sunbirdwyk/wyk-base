using System;
using System.IO;

namespace wyk.basic
{
    public class LogUtil
    {
        static string log_folder = "";
        static TextWriter tw = null;
        public static void v(string content)
        {
            log(LogLevel.Verbose, content);
        }

        public static void i(string content)
        {
            log(LogLevel.Info, content);
        }

        public static void w(string content)
        {
            log(LogLevel.Warning, content);
        }

        public static void d(string content)
        {
            log(LogLevel.Debug, content);
        }

        public static void e(string content)
        {
            log(LogLevel.Error, content);
        }

        public static void f(string content)
        {
            log(LogLevel.Fetal, content);
        }

        public static void v(string content, string folder)
        {
            log(LogLevel.Verbose, content, folder);
        }

        public static void i(string content, string folder)
        {
            log(LogLevel.Info, content, folder);
        }

        public static void w(string content, string folder)
        {
            log(LogLevel.Warning, content, folder);
        }

        public static void d(string content, string folder)
        {
            log(LogLevel.Debug, content, folder);
        }

        public static void e(string content, string folder)
        {
            log(LogLevel.Error, content, folder);
        }

        public static void f(string content, string folder)
        {
            log(LogLevel.Fetal, content, folder);
        }

        public static void log(LogLevel level, string content)
        {
            log(level, content, "");
        }

        public static void log(LogLevel level, string content, string folder)
        {
            string path = "";
            if (folder.isNull())
            {
                if (log_folder == "")
                {
                    log_folder = AppDomain.CurrentDomain.BaseDirectory + "logs/";
                    try
                    {
                        IOUtil.createDirectoryIfNotExist(log_folder);
                    }
                    catch { }
                }
                path = log_folder + DateTime.Today.ToString("yyyyMMdd") + ".log";
            }
            else
            {
                IOUtil.createDirectoryIfNotExist(folder);
                path = folder + DateTime.Today.ToString("yyyyMMdd") + ".log";
            }
            tw = new StreamWriter(path, true);
            tw.WriteLine("[{0}]({1}){2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"), getTagByLevel(level), content);
            tw.Flush();
            tw.Close();
        }

        private static string getTagByLevel(LogLevel level)
        {
            try
            {
                return level.ToString();
            }
            catch { }
            return "Unknown";
        }
    }
}
