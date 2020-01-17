using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace wyk.basic
{
    public class SerializeUtil
    {
        /// <summary>
        /// 序列化实例(String)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string serialize(object obj)
        {
            BinaryFormatter loBinFormatter = new BinaryFormatter();
            MemoryStream loMs = new MemoryStream();
            loBinFormatter.Serialize(loMs, obj);
            byte[] buffer = loMs.ToArray();
            string lcRetVal = Convert.ToBase64String(buffer, 0, buffer.Length);
            loMs.Close();
            return lcRetVal;
        }

        /// <summary>
        /// 反序列化实例(String)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static object deserialize(string source)
        {
            object loRetVal = null;
            if (source != null)
            {
                byte[] buffer = Convert.FromBase64String(source);
                BinaryFormatter loFormatter = new BinaryFormatter();
                MemoryStream loStream = new MemoryStream(buffer, 0, buffer.Length);
                loStream.Seek(0, SeekOrigin.Begin);
                loRetVal = loFormatter.Deserialize(loStream);
                loStream.Close();
            }
            return loRetVal;
        }

        /// <summary>
        /// 序列化实例(byte[])
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] serializeToArray(object obj)
        {
            BinaryFormatter loBinFormatter = new BinaryFormatter();
            MemoryStream loMs = new MemoryStream();
            loBinFormatter.Serialize(loMs, obj);
            byte[] buffer = loMs.ToArray();
            loMs.Close();
            return buffer;

        }

        /// <summary>
        /// 反序列化实例(byte[])
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static object deserializeFromArray(byte[] bytes)
        {
            object loRetVal = null;
            if (bytes != null && bytes.Length > 0)
            {
                BinaryFormatter loFormatter = new BinaryFormatter();
                MemoryStream loStream = new MemoryStream(bytes, 0, bytes.Length);
                loStream.Seek(0, SeekOrigin.Begin);
                loRetVal = loFormatter.Deserialize(loStream);
                loStream.Close();
            }
            return loRetVal;
        }
    }
}