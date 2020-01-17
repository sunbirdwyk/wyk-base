using System;
using System.IO;
using System.Text;

namespace wyk.basic
{
    public class IOUtil
    {
        public static bool isDirectory(string path)
        {
            if (Directory.Exists(path))
                return true;
            path = path.Trim();
            if (path.EndsWith("/") || path.EndsWith("\\"))
                return true;
            return false;
        }

        /// <summary>
        /// 检查当前文件夹是否存在, 不存在则新建
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public static void createDirectoryIfNotExist(string path)
        {
            if (path.isNull())
                return;
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch { }
        }

        /// <summary>
        /// 删除当前路径下的文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void deleteFileIfExists(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch { }
            }
        }

        /// <summary>
        /// 获取一个文件的文件夹路径
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns></returns>
        public static string directoryPath(string file_path)
        {
            if (isDirectory(file_path))
                return file_path;
            char sep = '\\';
            if (file_path.IndexOf('/') >= 0)
            {//以 '/' 分隔
                file_path = file_path.Replace("\\", "/");
                sep = '/';
            }
            else
            {
                file_path = file_path.Replace("/", "\\");
            }
            string[] sub = file_path.Split(sep);
            var path = new StringBuilder();
            for (int i = 0; i < sub.Length - 1; i++)
            {
                if (sub[i].isNull())
                    continue;
                path.Append(sub[i]);
                path.Append(sep);
            }
            return path.ToString();
        }

        /// <summary>
        /// 将stream中的内容保存到文件
        /// </summary>
        /// <param name="stream">要保存的数据流</param>
        /// <param name="path">文件路径</param>
        /// <param name="overwrite">是否覆盖</param>
        /// <returns></returns>
        public static string saveFile(Stream stream, string path, bool overwrite)
        {
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            stream.Close();
            return saveFile(buffer, path, overwrite);
        }

        /// <summary>
        /// 将字节流写入到文件
        /// </summary>
        /// <param name="buffer">要保存的字节流</param>
        /// <param name="path">文件路径</param>
        /// <param name="overwrite">是否覆盖</param>
        /// <returns></returns>
        public static string saveFile(byte[] buffer, string path, bool overwrite)
        {
            if (isDirectory(path))
                return "当前路径为文件夹路径, 不能保存";
            createDirectoryIfNotExist(directoryPath(path));
            if (File.Exists(path))
            {
                if (overwrite)
                    deleteFileIfExists(path);
                else
                    return "文件已存在!";
            }
            try
            {
                var fs = new FileStream(path, FileMode.CreateNew);
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
                fs.Close();
                return "";
            }
            catch (Exception ex) { return "保存文件失败,错误信息:" + ex.Message; }
        }
    }
}
