using System;
using System.Diagnostics;
using System.IO;

namespace wyk.basic
{
    /// <summary>
    /// 文件操作相关单元
    /// </summary>
    public class FileUtil
    {
        /// <summary>
        /// 获取文件版本号
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string version(string path)
        {
            try
            {
                FileVersionInfo version_info = FileVersionInfo.GetVersionInfo(path);
                string version = version_info.FileVersion;
                if (version == null)
                    version = "";
                return version;
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 获取文件MD5验证码
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string md5(string path)
        {
            try
            {
                return MD5Crypto.getFileMd5(path);
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>文件大小字节数</returns>
        public static long length(string path)
        {
            try
            {
                return new FileInfo(path).Length;
            }
            catch { }
            return 0;
        }

        /// <summary>
        /// 获取文件大小, 不同单位返回不同值
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="length_type">单位类型</param>
        /// <returns></returns>
        public static double length(string path, CapacityUnit length_type)
        {
            long llength = length(path);
            double dlength = llength / Convert.ToDouble((int)length_type);
            return dlength;
        }

        /// <summary>
        /// 获取文件大小显示字符串(Byte,无分隔符)
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string lengthString(string path)
        {
            return lengthString(path, "");
        }

        /// <summary>
        /// 获取文件大小显示字符串(2位有效数字, 无分隔符)
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="capacity_unit">单位</param>
        /// <returns></returns>
        public static string lengthString(string path, CapacityUnit capacity_unit)
        {
            return lengthString(path, capacity_unit, "");
        }

        /// <summary>
        /// 获取文件大小显示字符串(无分隔符)
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="capacity_unit">单位</param>
        /// <param name="decimal_place">有效数字(Byte此值无效)</param>
        /// <returns></returns>
        public static string lengthString(string path, CapacityUnit capacity_unit, int decimal_place)
        {
            return lengthString(path, capacity_unit, decimal_place, "");
        }

        /// <summary>
        /// 获取文件大小显示字符串(Byte)
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="seperator">分隔符</param>
        /// <returns></returns>
        public static string lengthString(string path, string seperator)
        {
            return lengthString(path, CapacityUnit.Byte, 2, seperator);
        }

        /// <summary>
        /// 获取文件大小显示字符串(2位有效数字)
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="capacity_unit">单位</param>
        /// <param name="seperator">分隔符</param>
        /// <returns></returns>
        public static string lengthString(string path, CapacityUnit capacity_unit, string seperator)
        {
            return lengthString(path, capacity_unit, 2, seperator);
        }

        /// <summary>
        /// 获取文件大小显示字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="length_type">单位</param>
        /// <param name="decimal_place">有效数字(Byte此值无效)</param>
        /// <param name="seperator">分隔符</param>
        /// <returns></returns>
        public static string lengthString(string path, CapacityUnit capacity_unit, int decimal_place, string seperator)
        {
            if (capacity_unit == CapacityUnit.Byte)
                return length(path) + seperator + "B";
            double dl = length(path, capacity_unit);
            string res = Math.Round(dl, decimal_place) + seperator;
            switch (capacity_unit)
            {
                case CapacityUnit.Byte:
                    res += "B";
                    break;
                case CapacityUnit.KiloByte:
                    res += "KB";
                    break;
                case CapacityUnit.MebiByte:
                    res += "MB";
                    break;
                case CapacityUnit.GigaByte:
                    res += "GB";
                    break;
            }
            return res;
        }
    }
}
