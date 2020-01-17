using System;
using System.Security.Cryptography;

namespace wyk.basic
{
    public class ShaCrypto
    {
        /// <summary>
        /// Sha1
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string encrypt1(string source)
        {
            return encrypt1(source, "UTF-8");
        }

        /// <summary>
        /// Sha1
        /// </summary>
        /// <param name="source"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string encrypt1(string source, string encode = "UTF-8")
        {
            var sha1 = new SHA1Managed();
            var source_bytes = System.Text.Encoding.GetEncoding(encode).GetBytes(source);
            byte[] result_bytes = sha1.ComputeHash(source_bytes);
            string result = BitConverter.ToString(result_bytes).ToLower().Replace("-", "");
            sha1.Clear();
            return result;
        }

        /// <summary>
        /// Sha256
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string encrypt256(string source)
        {
            return encrypt256(source, "UTF-8");
        }

        /// <summary>
        /// Sha256
        /// </summary>
        /// <param name="source"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string encrypt256(string source, string encode = "UTF-8")
        {
            var sha256 = new SHA256Managed();
            var source_bytes = System.Text.Encoding.GetEncoding(encode).GetBytes(source);
            byte[] result_bytes = sha256.ComputeHash(source_bytes);
            string result = BitConverter.ToString(result_bytes).ToLower().Replace("-", "");
            sha256.Clear();
            return result;
        }
    }
}
