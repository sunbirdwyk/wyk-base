using System;
using System.Security.Cryptography;
using System.Text;

namespace wyk.basic
{
    /// <summary>
    /// AES 加密/解密
    /// </summary>
    public class AESCryptoBase
    {
        public AESCryptoBase()
        {
            setCryptoKeys();
        }

        public AESCryptoBase(string secret_key)
        {
            this.secret_key = secret_key;
        }

        public AESCryptoBase(byte[] secret_key)
        {
            secret_key_bytes = secret_key;
        }

        public string secret_key
        {
            get => Encoding.UTF8.GetString(secret_key_bytes);
            set
            {
                secret_key_bytes = Encoding.UTF8.GetBytes(value);
            }
        }

        public byte[] secret_key_bytes { get; set; } = new byte[16] { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff };

        /// <summary>
        /// 设置AES密钥, 重写此方法可以使每个AESCrypto的密钥不同
        /// </summary>
        protected virtual void setCryptoKeys()
        {
            secret_key = "sunbird_wyk_key_sunbird_wyk_key_";
        }

        /// <summary>
        /// 按所需位数获取指定长度秘钥
        /// </summary>
        /// <param name="length">所需秘钥长度(字节)</param>
        /// <returns></returns>
        protected byte[] keyBytes(int length)
        {
            if (secret_key_bytes.Length == length)
                return secret_key_bytes;
            var key = new byte[length];
            if (length > secret_key_bytes.Length)
                Array.Copy(secret_key_bytes, key, secret_key_bytes.Length);
            else
                Array.Copy(secret_key_bytes, key, length);
            return key;
        }

        /// <summary>
        /// 按所需位数获取加密实例, 可重写以实现不同类型的加密模式
        /// </summary>
        /// <param name="bit">加密位数</param>
        /// <returns></returns>
        protected virtual RijndaelManaged cryptor(int bit)
        {
            var rm = new RijndaelManaged()
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            foreach (var lks in rm.LegalKeySizes)
            {
                var kl = lks.MinSize;
                do
                {
                    if (kl == bit)
                    {
                        rm.KeySize = bit;
                        rm.Key = keyBytes(bit / 8);
                        //rm.IV = keyBytes(16);
                        return rm;
                    }
                    kl += lks.SkipSize;
                }
                while (kl <= lks.MaxSize);
            }
            return null;
        }

        /// <summary>
        /// 加密(string)
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <param name="bit">位数, 支持128,192,256</param>
        /// <returns></returns>
        public string encrypt(string source, int bit)
        {
            if (string.IsNullOrEmpty(source)) return "";
            var result = encrypt(Encoding.UTF8.GetBytes(source), bit);
            if (result == null)
                return "";
            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// 加密(byte)
        /// </summary>
        /// <param name="source">原字节数组</param>
        /// <param name="bit">位数, 支持128,192,256</param>
        /// <returns></returns>
        public byte[] encrypt(byte[] source, int bit)
        {
            if (source == null || source.Length == 0)
                return null;
            byte[] result = null;
            try
            {
                using (var rm = cryptor(bit))
                {
                    ICryptoTransform cTransform = rm.CreateEncryptor();
                    result = cTransform.TransformFinalBlock(source, 0, source.Length);
                }
            }
            catch { }
            return result;
        }

        /// <summary>
        /// 解密(string)
        /// </summary>
        /// <param name="secreted">加密后的字符串</param>
        /// <param name="bit">位数, 支持128,192,256</param>
        /// <returns></returns>
        public string decrypt(string secreted, int bit)
        {
            if (string.IsNullOrEmpty(secreted)) return "";
            var result = decrypt(Convert.FromBase64String(secreted), bit);
            if (result == null)
                return "";
            return Encoding.UTF8.GetString(result);
        }

        /// <summary>
        /// 解密(byte)
        /// </summary>
        /// <param name="secreted">加密后的字节数组</param>
        /// <param name="bit">位数, 支持128,192,256</param>
        /// <returns></returns>
        public byte[] decrypt(byte[] secreted, int bit)
        {
            if (secreted == null || secreted.Length == 0)
                return null;
            byte[] result = null;
            try
            {
                using (var rm = cryptor(bit))
                {
                    ICryptoTransform cTransform = rm.CreateDecryptor();
                    result = cTransform.TransformFinalBlock(secreted, 0, secreted.Length);
                }
            }
            catch { }
            return result;
        }

        public string encrypt128(string source)
        {
            return encrypt(source, 128);
        }

        public byte[] encrypt128(byte[] source)
        {
            return encrypt(source, 128);
        }

        public string decrypt128(string secreted)
        {
            return decrypt(secreted, 128);
        }

        public byte[] decrypt128(byte[] secreted)
        {
            return decrypt(secreted, 128);
        }

        public string encrypt256(string source)
        {
            return encrypt(source, 256);
        }

        public byte[] encrypt256(byte[] source)
        {
            return encrypt(source, 256);
        }

        public string decrypt256(string secreted)
        {
            return decrypt(secreted, 256);
        }

        public byte[] decrypt256(byte[] secreted)
        {
            return decrypt(secreted, 256);
        }

        #region 与256位加/解密相关的JAVA方法
        /*
        package com.jun.project.utils;

        import javax.crypto.Cipher;
        import javax.crypto.spec.SecretKeySpec;

        import org.apache.tomcat.util.codec.binary.Base64;

        public class AES
        {

            // 加密
            public static String Encrypt(String sSrc, String sKey) throws Exception
            {
        if (sKey == null) {
            System.out.print("Key为空null");
            return null;
        }
        // 判断Key是否为16位
        if (sKey.length() != 16) {
            System.out.print("Key长度不是16位");
            return null;
        }
    byte[] raw = sKey.getBytes("utf-8");
    SecretKeySpec skeySpec = new SecretKeySpec(raw, "AES");
    Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");//"算法/模式/补码方式"
    cipher.init(Cipher.ENCRYPT_MODE, skeySpec);
        byte[] encrypted = cipher.doFinal(sSrc.getBytes("utf-8"));
 
        return new Base64().encodeToString(encrypted);//此处使用BASE64做转码功能，同时能起到2次加密的作用。
}

// 解密
public static String Decrypt(String sSrc, String sKey) throws Exception
{
        try {
        // 判断Key是否正确
        if (sKey == null)
        {
            System.out.print("Key为空null");
            return null;
        }
        // 判断Key是否为16位
        if (sKey.length() != 16)
        {
            System.out.print("Key长度不是16位");
            return null;
        }
        byte[] raw = sKey.getBytes("utf-8");
        SecretKeySpec skeySpec = new SecretKeySpec(raw, "AES");
        Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
        cipher.init(Cipher.DECRYPT_MODE, skeySpec);
        byte[] encrypted1 = new Base64().decode(sSrc);//先用base64解密
        try
        {
            byte[] original = cipher.doFinal(encrypted1);
            String originalString = new String(original, "utf-8");
            return originalString;
        }
        catch (Exception e)
        {
            System.out.println(e.toString());
            return null;
        }
    } catch (Exception ex) {
        System.out.println(ex.toString());
        return null;
    }
}

public static void main(String[] args) throws Exception
{
 
    //此处使用AES-128-ECB加密模式，key需要为16位。
    String cKey = "ae125efkk4454eef";
    // 需要加密的字串
    String cSrc = "数据2343esdofsdfsdfw@wr[1";
    System.out.println(cSrc);
    // 加密
    String enString = AES.Encrypt(cSrc, cKey);
    System.out.println("加密后的字串是：" + enString);

    // 解密
    String DeString = AES.Decrypt(enString, cKey);
    System.out.println("解密后的字串是：" + DeString);
}
}*/
        #endregion
    }
}