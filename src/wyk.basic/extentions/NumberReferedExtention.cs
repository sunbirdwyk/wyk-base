using System;
using System.Text;

namespace wyk.basic
{
    public static class NumberReferedExtention
    {
        /// <summary>
        /// 将数字按指定长度转为字符串，超出部分舍弃，不足部分在前面补0
        /// </summary>
        /// <param name="num"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string interpolateZeroAhead(this int num, int length)
        {
            var str = num.ToString();
            if (str.Length == length)
                return str;

            if (str.Length > length)
                return str.Substring(0, str.Length - length);

            var sb = new StringBuilder(str);
            while (sb.Length < length)
            {
                sb.Insert(0, "0");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将数字按指定长度转为字符串，超出部分舍弃，不足部分在后面补0
        /// </summary>
        /// <param name="num"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string interpolateZeroBehind(this int num, int length)
        {
            var str = num.ToString();
            if (str.Length == length)
                return str;

            if (str.Length > length)
                return str.Substring(str.Length - length, length);

            var sb = new StringBuilder(str);
            while (sb.Length < length)
            {
                sb.Append("0");
            }
            return sb.ToString();
        }

        #region 数字转字节数组

        #region 小端(低位在前)
        public static byte[] toBytes(this short num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes;
            else
                return bytes.reverse();
        }

        public static byte[] toBytes(this ushort num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes;
            else
                return bytes.reverse();
        }

        public static byte[] toBytes(this int num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes;
            else
                return bytes.reverse();
        }

        public static byte[] toBytes(this uint num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes;
            else
                return bytes.reverse();
        }

        public static byte[] toBytes(this float num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes;
            else
                return bytes.reverse();
        }

        public static byte[] toBytes(this double num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes;
            else
                return bytes.reverse();
        }

        public static byte[] toBytes(this long num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes;
            else
                return bytes.reverse();
        }
        #endregion

        #region 大端(高位在前)
        public static byte[] toBytesMSB(this short num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes.reverse();
            else
                return bytes;
        }

        public static byte[] toBytesMSB(this ushort num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes.reverse();
            else
                return bytes;
        }

        public static byte[] toBytesMSB(this int num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes.reverse();
            else
                return bytes;
        }

        public static byte[] toBytesMSB(this uint num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes.reverse();
            else
                return bytes;
        }

        public static byte[] toBytesMSB(this float num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes.reverse();
            else
                return bytes;
        }

        public static byte[] toBytesMSB(this double num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes.reverse();
            else
                return bytes;
        }

        public static byte[] toBytesMSB(this long num)
        {
            var bytes = BitConverter.GetBytes(num);
            if (BitConverter.IsLittleEndian)
                return bytes.reverse();
            else
                return bytes;
        }
        #endregion

        #endregion

        #region 字节数组转数字

        #region 小端(低位在前)
        public static short toShort(this byte[] bytes, int startIndex = 0, int length = 2)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 2 ? 2 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[2];
            Array.Copy(bytes, startIndex, data, 0, length);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToInt16(data, 0);
        }

        public static ushort toUShort(this byte[] bytes, int startIndex = 0, int length = 2)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 2 ? 2 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[2];
            Array.Copy(bytes, startIndex, data, 0, length);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToUInt16(data, 0);
        }

        public static int toInt(this byte[] bytes, int startIndex = 0, int length = 4)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 4 ? 4 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[4];
            Array.Copy(bytes, startIndex, data, 0, length);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);
        }

        public static uint toUInt(this byte[] bytes, int startIndex = 0, int length = 4)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 4 ? 4 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[4];
            Array.Copy(bytes, startIndex, data, 0, length);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToUInt32(data, 0);
        }

        public static float toFloat(this byte[] bytes, int startIndex = 0, int length = 4)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 4 ? 4 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[4];
            Array.Copy(bytes, startIndex, data, 0, length);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

        public static double toDouble(this byte[] bytes, int startIndex = 0, int length = 8)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 8 ? 8 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[8];
            Array.Copy(bytes, startIndex, data, 0, length);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToDouble(data, 0);
        }

        public static long toLong(this byte[] bytes, int startIndex = 0, int length = 8)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 8 ? 8 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[8];
            Array.Copy(bytes, startIndex, data, 0, length);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToInt64(data, 0);
        }

        public static ulong toULong(this byte[] bytes, int startIndex = 0, int length = 8)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 8 ? 8 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[8];
            Array.Copy(bytes, startIndex, data, 0, length);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToUInt64(data, 0);
        }
        #endregion

        #region 大端(高位在前)
        public static short toShortMSB(this byte[] bytes, int startIndex = 0, int length = 2)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 2 ? 2 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[2];
            Array.Copy(bytes, startIndex, data, 2 - length, length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToInt16(data, 0);
        }

        public static ushort toUShortMSB(this byte[] bytes, int startIndex = 0, int length = 2)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 2 ? 2 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[2];
            Array.Copy(bytes, startIndex, data, 2 - length, length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToUInt16(data, 0);
        }

        public static int toIntMSB(this byte[] bytes, int startIndex = 0, int length = 4)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 4 ? 4 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[4];
            Array.Copy(bytes, startIndex, data, 4 - length, length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);
        }

        public static uint toUIntMSB(this byte[] bytes, int startIndex = 0, int length = 4)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 4 ? 4 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[4];
            Array.Copy(bytes, startIndex, data, 4 - length, length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToUInt32(data, 0);
        }

        public static float toFloatMSB(this byte[] bytes, int startIndex = 0, int length = 4)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 4 ? 4 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[4];
            Array.Copy(bytes, startIndex, data, 4 - length, length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

        public static double toDoubleMSB(this byte[] bytes, int startIndex = 0, int length = 8)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 8 ? 8 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[8];
            Array.Copy(bytes, startIndex, data, 8 - length, length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToDouble(data, 0);
        }

        public static long toLongMSB(this byte[] bytes, int startIndex = 0, int length = 8)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 8 ? 8 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[8];
            Array.Copy(bytes, startIndex, data, 8 - length, length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToInt64(data, 0);
        }

        public static ulong toULongMSB(this byte[] bytes, int startIndex = 0, int length = 8)
        {
            if (bytes == null || length <= 0 || startIndex >= bytes.Length)
                return 0;

            length = length > 8 ? 8 : length;
            length = length > bytes.Length - startIndex ? bytes.Length - startIndex : length;

            var data = new byte[8];
            Array.Copy(bytes, startIndex, data, 8 - length, length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToUInt64(data, 0);
        }
        #endregion

        #endregion

        public static byte[] reverse(this byte[] bytes)
        {
            if (bytes == null)
                return null;

            var data = new byte[bytes.Length];
            bytes.CopyTo(data, 0);
            Array.Reverse(data);
            return data;
        }
    }
}