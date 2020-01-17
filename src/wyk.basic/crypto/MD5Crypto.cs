using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace wyk.basic
{
    /// <summary>
    /// MD5 加密
    /// </summary>
    public class MD5Crypto
    {
        /// <summary>
        /// 16位MD5加密方法
        /// </summary>
        /// <param name="source">待加密字串</param>
        /// <returns>加密后的字串</returns>
        public static string encrypt16(string source)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(source)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2.ToLower();
        }

        /// <summary>
        /// 32位MD5加密方法
        /// </summary>
        /// <param name="source">待加密字串</param>
        /// <returns>加密后的字串</returns>
        public static string encrypt32(string source)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(source));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取文件的MD5校验码
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string getFileMd5(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                md5.Initialize();
                byte[] bytes = md5.ComputeHash(fs);
                md5.Clear();
                fs.Close();
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
            catch { }
            return "";
        }
    }
}