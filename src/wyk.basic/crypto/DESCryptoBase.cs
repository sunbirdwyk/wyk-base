using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace wyk.basic
{
    /// <summary>
    /// DES 加密/解密 (公共密钥)
    /// </summary>
    public class DESCryptoBase
    {
        /// <summary>
        /// 密钥(8位字符串)
        /// </summary>
        protected string _secret_key = "12345678";
        /// <summary>
        /// 初始化向量(8 bytes)
        /// </summary>
        protected byte[] _initailize_vector = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        public DESCryptoBase()
        {
            setCryptoKeys();
        }

        public DESCryptoBase(string SecretKey, byte[] IV)
        {
            this.secret_key = SecretKey;
            this.initialize_vector = IV;
        }

        public string secret_key
        {
            get => _secret_key;
            set
            {
                _secret_key = value;
                while (_secret_key.Length < 8)
                {
                    _secret_key += " ";
                }
                if (_secret_key.Length > 8)
                    _secret_key = _secret_key.Substring(0, 8);
            }
        }

        public byte[] initialize_vector
        {
            get => _initailize_vector;
            set
            {
                if (value.Length != 8)
                {
                    byte[] bytes = new byte[8];
                    for (int i = 0; i < 8; i++)
                    {
                        try
                        {
                            bytes[i] = value[i];
                        }
                        catch { bytes[i] = 0; }
                    }
                    _initailize_vector = bytes;
                }
                else
                {
                    _initailize_vector = value;
                }
            }
        }

        /// <summary>
        /// 设置DES密钥, 重写此方法可以使每个DESCrypto的密钥不同
        /// 示例:
        /// key_string = "your_key";  //8位字符串
        /// key_bytes = new byte[] { 0x11, 0x22, 0x33, 0x44, 0xaa, 0xbb, 0xcc, 0xdd }; //8 byte
        /// </summary>
        protected virtual void setCryptoKeys()
        {
            secret_key = "wyk__pub";
            initialize_vector = new byte[] { 0x11, 0x22, 0x33, 0x44, 0xaa, 0xbb, 0xcc, 0xdd };
        }

        /// <summary>
        /// 设置初始化向量
        /// </summary>
        /// <param name="iv"></param>
        /// <param name="is_hex">是否为16进制数字</param>
        public void setIV(string[] iv, bool is_hex)
        {
            byte[] _iv = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    if (is_hex)
                        _iv[i] = byte.Parse(iv[i], System.Globalization.NumberStyles.HexNumber);
                    else
                        _iv[i] = Convert.ToByte(iv[i]);
                }
                catch { _iv[i] = 0; }
            }
            initialize_vector = _iv;
        }

        /// <summary>
        /// 设置初始化向量
        /// </summary>
        /// <param name="iv_1"></param>
        /// <param name="iv_2"></param>
        /// <param name="iv_3"></param>
        /// <param name="iv_4"></param>
        /// <param name="iv_5"></param>
        /// <param name="iv_6"></param>
        /// <param name="iv_7"></param>
        /// <param name="iv_8"></param>
        /// <param name="is_hex">是否为16进制数字</param>
        public void setIV(string iv_1, string iv_2, string iv_3, string iv_4, string iv_5, string iv_6, string iv_7, string iv_8, bool is_hex)
        {
            setIV(new string[] { iv_1, iv_2, iv_3, iv_4, iv_5, iv_6, iv_7, iv_8 }, is_hex);
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        public string encrypt(string source)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(_secret_key.Substring(0, 8));
                byte[] rgbIV = _initailize_vector;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(source);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return source;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        public string decryptNoNull(string secreted)
        {
            if (secreted == "")
                return "";
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(_secret_key);
                byte[] rgbIV = _initailize_vector;
                byte[] inputByteArray = Convert.FromBase64String(secreted);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch { return secreted; }
        }

        /// <summary>
        /// DES解密字符串  如解密的字符串和原字符串相同,返回空值
        /// </summary>
        public string decrypt(string secreted)
        {
            var res = decryptNoNull(secreted);
            if (res == secreted)
                res = "";
            return res;
        }
    }
}