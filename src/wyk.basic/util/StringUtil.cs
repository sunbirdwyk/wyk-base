using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace wyk.basic
{
    /// <summary>
    /// 字符串处理单元
    /// </summary>
    public class StringUtil
    {
        /// <summary>
        /// 格式化数字
        /// </summary>
        /// <param name="value">原数字值</param>
        /// <param name="step">整数位分隔步长(小于等于0表示不处理)</param>
        /// <param name="seperator">整数位分隔字符(为空则默认使用逗号)</param>
        /// <param name="decimal_places">保留小数位数(小于0表示不处理)</param>
        /// <param name="force_show_zero">强制显示设定的小数位数, 不够以0填充</param>
        /// <returns></returns>
        public static string formatNumber(double value, int step, string seperator, int decimal_places, bool force_show_zero)
        {
            string str;
            if (decimal_places >= 0)
                str = Math.Round(value, decimal_places).ToString();
            else
                str = value.ToString();
            var sb = new StringBuilder();
            if (seperator.isNull())
                seperator = ",";
            var idx = str.IndexOf('.');
            if (idx < 0)
                idx = str.Length;
            if (step > 0)
            {
                for (var i = idx; i > 0; i -= step)
                {
                    var part = "";
                    if (i - step>= 0)
                        part = str.Substring(i - step, step);
                    else
                        part = str.Substring(0, i);
                    if (!part.isNull())
                    {
                        if (sb.Length <= 0)
                            sb.Append(part);
                        else
                            sb.Insert(0, part + seperator);
                    }                        
                }
            }
            else
            {
                sb.Append(str.Substring(0, idx));
            }
            var postfix = "";
            if (idx < str.Length - 1)
                postfix = str.Substring(idx + 1);
            if((postfix.isNull()||postfix.Length<decimal_places)&&force_show_zero)
            {
                if (postfix.isNull())
                    postfix = "";
                while (postfix.Length < decimal_places)
                    postfix += "0";
            }
            if (!postfix.isNull())
                sb.Append("."+postfix);
            return sb.ToString();
        }

        static int[] IDCARD_BITS_FACTOR = new int[17] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        static int[] IDCARD_VERIFY_FACTOR = new int[11] { 1, 0, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        /// <summary>
        /// 判定是否为有效身份证号码
        /// </summary>
        /// <param name="source">身份证号</param>
        /// <returns>是否为有效身份证号</returns>
        public static bool isIDCardNumber(string source)
        {
            if (source.Trim().Length == 18)
            {
                char[] chars = source.Trim().ToCharArray();
                int[] bits = new int[17];
                try
                {
                    for (int i = 0; i < 17; i++)
                    {
                        bits[i] = Convert.ToInt32(chars[i].ToString());
                    }
                }
                catch { return false; }
                int total = 0;
                for (int i = 0; i < 17; i++)
                {
                    total += bits[i] * IDCARD_BITS_FACTOR[i];
                }
                int rear = total % 11;
                string rearstring = IDCARD_VERIFY_FACTOR[rear].ToString();
                if (rearstring == "10")
                    rearstring = "X";
                try
                {
                    if (chars[17].ToString().ToUpper() == rearstring)
                    {
                        return true;
                    }
                }
                catch { return false; }
            }
            if (source.Trim().Length == 15)
            {
                char[] chars = source.Trim().ToCharArray();
                int[] bits = new int[15];
                try
                {
                    for (int i = 0; i < 15; i++)
                    {
                        bits[i] = Convert.ToInt32(chars[i].ToString());
                    }
                }
                catch { return false; }
                string date = "19" + chars[6] + chars[7] + "-" + chars[8] + chars[9] + "-" + chars[10] + chars[11];
                try
                {
                    DateTime birth = Convert.ToDateTime(date);
                }
                catch { return false; }
                string code = bits[0].ToString() + bits[1] + bits[2] + bits[3] + bits[4] + bits[5];
                return AreaUtil.isValidAreaCode(code);
            }
            return false;
        }

        /// <summary>
        /// 格式化数字(整数位4位逗号分隔,保留两位小数)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string formatNumber(double value)
        {
            return formatNumber(value, 4, ",", 2,false);
        }

        /// <summary>
        /// 判断是否为手机号
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool isPhoneNumber(string source)
        {
            if (source.isNull())
                return false;
            if (Regex.IsMatch(source, @"1\d{10}"))
                return true;
            return false;
        }

        /// <summary>
        /// 判断字符串是否为 IP 地址
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool isIPAddress(string source)
        {
            if (source.isNull())
                return false;
            return Regex.IsMatch(source, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 判断字符串是否由纯数字组成
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool isOnlyNumber(string source)
        {
            return Regex.IsMatch(source, @"\d+");
        }

        /// <summary>
        /// 字符串中提取数字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string numberFromString(string source)
        {
            return Regex.Replace(source, @"[^0-9]+", "");
        }

        /// <summary> 
        /// 字符串转16进制字节数组 
        /// </summary> 
        /// <param name="hexString"></param> 
        /// <returns></returns> 
        public static byte[] toBytesFromHexString(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary> 
        /// 字节数组转16进制字符串 
        /// </summary> 
        /// <param name="bytes"></param> 
        /// <returns></returns> 
        public static string fromBytesToHexString(byte[] bytes)
        {
            var sb = new StringBuilder();
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("X2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 字节数组转16进制字符串,定长
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string fromBytesToHexString(byte[] bytes, int length)
        {
            var sb = new StringBuilder();
            if (bytes != null)
            {
                for (int i = 0; i < length; i++)
                {
                    sb.Append(bytes[i].ToString("X2"));
                }
            }
            return sb.ToString();
        }

        public static string fromBytesCNEncoded(Byte[] content, int length)
        {
            return fromBytes(content, length, Encoding.GetEncoding("GB18030"));
        }

        public static string fromBytesUTF8Encoded(Byte[] content, int length)
        {
            return fromBytes(content, length, Encoding.UTF8);
        }

        public static string fromBytes(Byte[] content, int length, Encoding encoding)
        {
            char[] chars = new char[encoding.GetCharCount(content, 0, length)];
            encoding.GetChars(content, 0, length, chars, 0);
            return new string(chars);
        }

        /// <summary>
        /// 获取用于填入XML文件内容中的字符串内容.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string toXMLContent(string source)
        {
            try
            {
                string res = source.Replace("<", "$lt;");
                res = res.Replace(">", "$gt;");
                res = res.Replace("\"", "$quot;");
                res = res.Replace("'", "$apos;");
                res = res.Replace("&", "$amp;");
                res = res.Replace(Convert.ToChar(29).ToString(), "$29;");
                res = res.Replace(Convert.ToChar(30).ToString(), "$30;");
                res = res.Replace(Convert.ToChar(31).ToString(), "$31;");
                return res;
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 将XML文件内容转回正常内容
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string fromXMLContent(string source)
        {
            try
            {
                string res = source.Replace("$lt;", "<");
                res = res.Replace("$gt;", ">");
                res = res.Replace("$quot;", "\"");
                res = res.Replace("$apos;", "'");
                res = res.Replace("$amp;", "&");
                res = res.Replace("$29;", Convert.ToChar(29).ToString());
                res = res.Replace("$30;", Convert.ToChar(30).ToString());
                res = res.Replace("$31;", Convert.ToChar(31).ToString());
                return res;
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 获取网页显示的字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string toHTMLString(string source)
        {
            if (source == null || source == "")
                return "&nbsp;";
            return HttpUtility.HtmlEncode(source).Replace("\r\n","<br>");
        }

        /// <summary>
        /// 从网页显示的字符串还原为原字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string fromHTMLString(string source)
        {
            try
            {
                if (source == "&nbsp;")
                    return "";
                return HttpUtility.HtmlDecode(source).Replace("<br>", "\r\n"); ;
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 半角转全角
        /// 全角空格为12288，半角空格为32
        /// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        /// </summary>
        /// <param name="source">任意字符串</param>
        /// <returns>全角字符串</returns>
        public static string getSBCString(string source)
        {
            char[] c = source.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new String(c);
        }

        /// <summary>
        /// 全角转半角
        /// 全角空格为12288，半角空格为32
        /// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        /// </summary>
        /// <param name="source">任意字符串</param>
        /// <returns>半角字符串</returns>
        public static string getDBCString(string source)
        {
            char[] c = source.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

        /// <summary>
        /// 获取输入字符串的常规字符串(清除特殊字符,只保留字母,数字和_)
        /// </summary>
        /// <param name="source">输入字符串</param>
        /// <returns>返回清除特殊字符后的常规字符串</returns>
        public static string getClassicString(string source)
        {
            char[] parts = source.ToCharArray();
            string res = "";
            foreach (char c in parts)
            {
                if (isClassicCharacter(c))
                    res += c.ToString();
            }
            return res;
        }

        /// <summary>
        /// 判断输入字符串是否为常规字符串
        /// </summary>
        /// <param name="source">输入字符串</param>
        /// <returns>包含特殊字符返回否,否则返回是</returns>
        public static bool isClassicString(string source)
        {
            char[] parts = source.ToCharArray();
            foreach (char c in parts)
            {
                if (!isClassicCharacter(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 判断输入字符是否为常规字符
        /// </summary>
        /// <param name="character">输入字符</param>
        /// <returns>是常规字符返回是,否则返回否</returns>
        public static bool isClassicCharacter(char character)
        {
            for (int i = 0; i < StaticItems.CLASSIC_CHARACTERS.Length; i++)
            {
                if (character == StaticItems.CLASSIC_CHARACTERS[i])
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <param name="only_numbers">是否只要数字</param>
        /// <returns></returns>
        public static string getRandomString(int length, bool only_numbers)
        {
            string res = "";
            Random ran = new Random();
            if (only_numbers)
            {
                for (int i = 0; i < length; i++)
                {
                    int id = ran.Next(0, 9);
                    res += id.ToString();
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    int id = ran.Next(1, 62);
                    if (id <= 10)
                        id = id + 47;
                    else if (id <= 36)
                        id = id + 64 - 10;
                    else
                        id = id + 96 - 36;
                    res += ((char)id).ToString();
                }
            }
            return res;
        }

        /// <summary>
        /// 格式化数字字符串(长度不够的前方补0)
        /// </summary>
        /// <param name="number">数字</param>
        /// <param name="digit">长度</param>
        /// <returns></returns>
        public static string formatNumberString(int number, int digit)
        {
            string res = "";
            res = number.ToString();
            if (res.Length < digit)
            {
                int end = res.Length;
                for (int i = digit; i > end; i--)
                {
                    res = "0" + res;
                }
            }
            return res;
        }

        /// <summary>
        /// 格式化数字字符串(长度不够的前方补0)
        /// </summary>
        /// <param name="number">数字</param>
        /// <param name="digit">长度</param>
        /// <returns></returns>
        public static string formatNumberString(long number, int digit)
        {
            string res = "";
            res = number.ToString();
            if (res.Length < digit)
            {
                int end = res.Length;
                for (int i = digit; i > end; i--)
                {
                    res = "0" + res;
                }
            }
            return res;
        }

        /// <summary>
        /// 获取重复字符的字符串,如'aaaaa'
        /// </summary>
        /// <param name="count">长度</param>
        /// <param name="ch">字符</param>
        /// <returns></returns>
        public static string duplicateCharString(int count, char ch)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s += ch.ToString();
            }
            return s;
        }

        /// <summary>
        /// 获取竖排字符串,每行一个字符
        /// </summary>
        /// <param name="input_string"></param>
        /// <returns></returns>
        public static string verticalString(string input_string)
        {
            string tmp = input_string.Replace("\r\n", "");
            char[] tmplist = tmp.ToCharArray();
            string res = "";
            foreach (char c in tmplist)
            {
                res += c.ToString() + "\r\n";
            }
            res = res.TrimEnd('\n');
            res = res.TrimEnd('\r');
            return res;
        }

        /// <summary>
        /// 下划线'_'分隔string转化为驼峰
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="big_camel">是否大驼峰</param>
        /// <param name="skip_first">是否跳过第一个(数据表名获取时通常第一部分为通用类型, 需要过滤掉)</param>
        /// <returns></returns>
        public static string camelStringFromDash(string source, bool big_camel, bool skip_first)
        {
            string target = "";
            string[] parts = source.Split('_');
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "")
                    continue;
                if (i == 0)
                {
                    if (skip_first && parts.Length > 1)
                        continue;
                }
                if (big_camel || target != "")
                    target += parts[i].Substring(0, 1).ToUpper() + parts[i].Substring(1);
                else
                    target += parts[i];
            }
            return target;
        }

        /// <summary>
        /// 测量字符串所占的空间(float返回值)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <param name="content"></param>
        /// <param name="max_width"></param>
        /// <returns></returns>
        public static SizeF measureStringSizeF(Graphics g, Font font, string content, int max_width)
        {
            g.PageUnit = GraphicsUnit.Pixel;
            g.SmoothingMode = SmoothingMode.HighQuality;
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            return g.MeasureString(content, font, max_width, sf);
        }

        /// <summary>
        /// 测量字符串所占的空间(float返回值)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <param name="content"></param>
        /// <param name="max_width"></param>
        /// <returns></returns>
        public static SizeF measureStringSizeF(Graphics g, Font font, string content, float max_width)
        {
            return measureStringSizeF(g, font, content, Convert.ToInt32(max_width));
        }

        /// <summary>
        /// 测量字符串所占的空间(float返回值)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static SizeF measureStringSizeF(Graphics g, Font font, string content)
        {
            return measureStringSizeF(g, font, content, int.MaxValue);
        }

        /// <summary>
        /// 测量字符串所占的空间(int返回值)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <param name="content"></param>
        /// <param name="max_width"></param>
        /// <returns></returns>
        public static Size measureStringSize(Graphics g, Font font, string content, int max_width)
        {
            SizeF sizef = measureStringSizeF(g, font, content, max_width);
            return new Size((int)Math.Ceiling(sizef.Width), (int)Math.Ceiling(sizef.Height));
        }

        /// <summary>
        /// 测量字符串所占的空间(int返回值)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Size measureStringSize(Graphics g, Font font, string content)
        {
            return measureStringSize(g, font, content, int.MaxValue);
        }
    }
}