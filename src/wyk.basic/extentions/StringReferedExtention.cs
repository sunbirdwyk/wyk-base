using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace wyk.basic
{
    public static class StringReferedExtention
    {
        /// <summary>
        /// 将显示名称转换为相应的枚举
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TEnum enumFromDisplay<TEnum>(this string source)
        {
            return EnumUtil.fromDisplay<TEnum>(source);
        }

        /// <summary>
        /// 将枚举值名称转换为相应的枚举
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TEnum enumFromName<TEnum>(this string source)
        {
            return EnumUtil.fromName<TEnum>(source);
        }

        /// <summary>
        /// 获取DateTime
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime datetime(this string source)
        {
            try
            {
                return Convert.ToDateTime(source);
            }
            catch { }
            return DateTimeUtil.defaultTime();
        }

        /// <summary>
        /// 获取字符串的拼音字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string pinyin(this string source)
        {
            return CharacterUtil.getPinyin(source, " ");
        }

        /// <summary>
        /// 获取字符串的拼音缩写
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string pinyinShort(this string source)
        {
            return CharacterUtil.getPinyinShort(source);
        }

        /// <summary>
        /// 获取字符串的拼音缩写(最大字符限制)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static string pinyinShort(this string source, int max)
        {
            return CharacterUtil.getPinyinShort(source, max);
        }

        /// <summary>
        /// 判断字符串是否为纯数字组成
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool isOnlyNumber(this string source)
        {
            return StringUtil.isOnlyNumber(source);
        }

        /// <summary>
        /// 字符串中提取数字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string getOnlyNumber(this string source)
        {
            return StringUtil.numberFromString(source);
        }

        /// <summary>
        /// 判断字符串是否为身份证号
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool isIDCardNumber(this string source)
        {
            return StringUtil.isIDCardNumber(source);
        }

        /// <summary>
        /// 判断字符串是否为电话号码
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool isPhoneNumber(this string source)
        {
            return StringUtil.isPhoneNumber(source);
        }

        /// <summary>
        /// 判断字符串是否为空或空字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool isNull(this string source)
        {
            bool is_null = string.IsNullOrEmpty(source);
            if (is_null)
                return true;
            if (source.Trim() == "")
                return true;
            return false;
        }

        /// <summary>
        /// 判断字符串是否有内容(非空或空字符串)
        /// 此函数为isNull()的反结果函数, 为了方便判断空和非空两种结果
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool hasContents(this string source)
        {
            return !source.isNull();
        }

        /// <summary>
        /// 判断字符串是否为IP地址
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool isIPAddress(this string source)
        {
            return StringUtil.isIPAddress(source);
        }

        /// <summary>
        /// 字符串转16进制字节数组 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] toBytesForHex(this string hex)
        {
            return StringUtil.toBytesFromHexString(hex);
        }

        /// <summary>
        /// 转化为填入xml的内容
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string xmlEncode(this string source)
        {
            return StringUtil.toXMLContent(source);
        }

        /// <summary>
        /// 从xml内容转回正常字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string xmlDecode(this string source)
        {
            return StringUtil.fromXMLContent(source);
        }

        /// <summary>
        /// 转化为填入html的内容
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string htmlEncode(this string source)
        {
            return StringUtil.toHTMLString(source);
        }

        /// <summary>
        /// 从html内容转回正常字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string htmlDecode(this string source)
        {
            return StringUtil.fromHTMLString(source);
        }

        /// <summary>
        /// url encode
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string urlEncode(this string source)
        {
            return HttpUtility.UrlEncode(source);
        }

        /// <summary>
        /// url decode
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string urlDecode(this string source)
        {
            return HttpUtility.UrlDecode(source);
        }


        /// <summary>
        /// 获取全角字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string toSBCString(this string source)
        {
            return StringUtil.getSBCString(source);
        }

        /// <summary>
        /// 获取半角字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string toDBCString(this string source)
        {
            return StringUtil.getDBCString(source);
        }

        /// <summary>
        /// 过滤掉特殊字符,只保留字母,数字和_
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string filterSpecialChars(this string source)
        {
            return StringUtil.getClassicString(source);
        }

        /// <summary>
        /// 判断字符串是否含有特殊字符
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool hasSpecialChars(this string source)
        {
            return StringUtil.isClassicString(source);
        }

        /// <summary>
        /// 竖着排列的字符串(每个字符用回车换行分隔)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string verticalString(this string source)
        {
            return StringUtil.verticalString(source);
        }

        /// <summary>
        /// 下划线'_'分隔string转化为驼峰
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="big_camel">是否大驼峰</param>
        /// <param name="skip_first">是否跳过第一个(数据表名获取时通常第一部分为通用类型, 需要过滤掉)</param>
        /// <returns></returns>
        public static string camelStringFromDash(this string source, bool big_camel, bool skip_first)
        {
            return StringUtil.camelStringFromDash(source, big_camel, skip_first);
        }

        /// <summary>
        /// 测量字符串所占的空间
        /// </summary>
        /// <param name="content"></param>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <param name="max_width"></param>
        /// <returns></returns>
        public static SizeF measureF(this string content, Graphics g, Font font, int max_width)
        {
            return StringUtil.measureStringSizeF(g, font, content, max_width);
        }

        /// <summary>
        /// 测量字符串所占的空间
        /// </summary>
        /// <param name="content"></param>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <param name="max_width"></param>
        /// <returns></returns>
        public static SizeF measureF(this string content, Graphics g, Font font, float max_width)
        {
            return StringUtil.measureStringSizeF(g, font, content, max_width);
        }

        /// <summary>
        /// 测量字符串所占的空间
        /// </summary>
        /// <param name="content"></param>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public static SizeF measureF(this string content, Graphics g, Font font)
        {
            return StringUtil.measureStringSizeF(g, font, content);
        }

        /// <summary>
        /// 测量字符串所占的空间
        /// </summary>
        /// <param name="content"></param>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <param name="max_width"></param>
        /// <returns></returns>
        public static Size measure(this string content, Graphics g, Font font, int max_width)
        {
            return StringUtil.measureStringSize(g, font, content, max_width);
        }

        /// <summary>
        /// 测量字符串所占的空间
        /// </summary>
        /// <param name="content"></param>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public static Size measure(this string content, Graphics g, Font font)
        {
            return StringUtil.measureStringSize(g, font, content);
        }

        /// <summary>
        /// 过滤特殊字符, 只保留字母数字,-和中文
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string filterSpecialCharacters(this string content)
        {
            //if (Regex.IsMatch(content, "[A-Za-z0-9\u4e00-\u9fa5-]+"))
            try
            {
                return Regex.Match(content, "[A-Za-z0-9\u4e00-\u9fa5_-]+").Value;
            }
            catch { }
            return "";
        }

        /// <summary>
        ///  将原始字符串按指定长度输出，超出部分舍弃，不足部分在前面补0
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string interpolateZeroAhead(this string str, int length)
        {
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
        ///  将原始字符串按指定长度输出，超出部分舍弃，不足部分在后面补0
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string interpolateZeroBehind(this string str, int length)
        {
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

        #region 字符串转数字，失败的时候使用默认值返回
        public static byte toByte(this string str, byte default_num = 0)
        {
            byte.TryParse(str, out default_num);
            return default_num;
        }

        public static short toShort(this string str, short default_num = 0)
        {
            short.TryParse(str, out default_num);
            return default_num;
        }

        public static ushort toUShort(this string str, ushort default_num = 0)
        {
            ushort.TryParse(str, out default_num);
            return default_num;
        }

        public static int toInt(this string str, int default_num = 0)
        {
            int.TryParse(str, out default_num);
            return default_num;
        }

        public static uint toUInt(this string str, uint default_num = 0)
        {
            uint.TryParse(str, out default_num);
            return default_num;
        }

        public static float toFloat(this string str, float default_num = 0)
        {
            float.TryParse(str, out default_num);
            return default_num;
        }

        public static double toDouble(this string str, double default_num = 0)
        {
            double.TryParse(str, out default_num);
            return default_num;
        }

        public static long toLong(this string str, long default_num = 0)
        {
            long.TryParse(str, out default_num);
            return default_num;
        }

        public static byte toByte(this string str, int fromBase, byte default_num)
        {
            try
            {
                default_num = Convert.ToByte(str, fromBase);
            }
            catch { }
            return default_num;
        }

        public static short toShort(this string str, int fromBase, short default_num)
        {
            try
            {
                default_num = Convert.ToInt16(str, fromBase);
            }
            catch { }
            return default_num;
        }

        public static ushort toUShort(this string str, int fromBase, ushort default_num)
        {
            try
            {
                default_num = Convert.ToUInt16(str, fromBase);
            }
            catch { }
            return default_num;
        }

        public static int toInt(this string str, int fromBase, int default_num)
        {
            try
            {
                default_num = Convert.ToInt32(str, fromBase);
            }
            catch { }
            return default_num;
        }

        public static uint toUInt(this string str, int fromBase, uint default_num)
        {
            try
            {
                default_num = Convert.ToUInt32(str, fromBase);
            }
            catch { }
            return default_num;
        }

        public static long toLong(this string str, int fromBase, long default_num)
        {
            try
            {
                default_num = Convert.ToInt64(str, fromBase);
            }
            catch { }
            return default_num;
        }
        #endregion
    }
}