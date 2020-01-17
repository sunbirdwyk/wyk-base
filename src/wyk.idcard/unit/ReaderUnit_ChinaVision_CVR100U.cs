using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using wyk.basic;

namespace wyk.idcard.unit
{
    [IDCardReader("ChinaVision", "CVR")]
    public class ReaderUnit_ChinaVision_CVR100U : ReaderUnit
    {
        #region Imports
        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "CVR_InitComm", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_InitComm(int Port);//声明外部的标准动态库, 跟Win32API是一样的


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "CVR_Authenticate", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_Authenticate();


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "CVR_Read_Content", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_Read_Content(int Active);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "CVR_Read_FPContent", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_Read_FPContent();

        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "CVR_FindCard", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_FindCard();

        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "CVR_SelectCard", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_SelectCard();


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "CVR_CloseComm", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_CloseComm();

        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetCertType", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern unsafe int GetCertType(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetPeopleName", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern unsafe int GetPeopleName(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetPeopleChineseName", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern unsafe int GetPeopleChineseName(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetPeopleNation", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int GetPeopleNation(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetNationCode", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int GetNationCode(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetPeopleBirthday", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleBirthday(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetPeopleAddress", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleAddress(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetPeopleIDCode", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleIDCode(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetDepartment", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDepartment(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetStartDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetStartDate(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetEndDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetEndDate(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetPeopleSex", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleSex(ref byte strTmp, ref int strLen);


        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "CVR_GetSAMID", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int CVR_GetSAMID(ref byte strTmp);

        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetBMPData", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetBMPData(ref byte btBmp, ref int nLen);

        [DllImport(@"libs\ChinaVision\CVR\Termb.dll", EntryPoint = "GetJpgData", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetJpgData(ref byte btBmp, ref int nLen);
        #endregion

        public override IDCardInfo readIDCard(bool get_photo,out string msg)
        {
            msg = "";
            //如果端口号为空,则以1001为默认
            if (port_number == "")
                port_number = "1001";
            IDCardInfo info = new IDCardInfo();
            try
            {
                int i = CVR_InitComm(Convert.ToInt32(port_number));
                if (i == 1)
                {
                    i = CVR_Authenticate();
                    if (i == 1)
                    {
                        i = CVR_Read_Content(2);
                        if (i == 1)
                        {
                            info.name = getName();
                            info.address = getAddress();
                            info.birthday = getBirthday();
                            info.department = getDepartment();
                            info.end_date = getEndDate();
                            info.gender = getSex();
                            info.id_card_number = getIdCode();
                            info.nation = getNation();
                            info.reserve_contents = getReserve();
                            info.start_date = getStartDate();
                            if (get_photo)
                                info.photo = getPhoto();
                            info.read_from_machine = true;
                            i = CVR_CloseComm();
                        }
                        else
                            msg = "读取卡信息失败.";
                    }
                    else
                        msg = "卡认证失败, 请确认您已正确放置好身份证, 读取一次身份证之后如果需要再次读取需要将身份证拿起后再放置一次.";
                }
                else
                    msg = "设备初始化失败, 请确认您已正确连接好设备并正确配置.";
            }
            catch (Exception ex) { msg = ex.Message; }
            return info;
        }

        #region Private Methods
        private static string getName()
        {
            try
            {
                byte[] data = null;
                data = new byte[30];
                int length = 30;
                int dwRet = GetPeopleName(ref data[0], ref length);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(data, 0, length)];
                gb2312.GetChars(data, 0, length, asciiChars, 0);
                return new string(asciiChars).TrimEnd('\0');
            }
            catch { return ""; }
        }

        private static string getSex()
        {
            try
            {
                byte[] data = null;
                data = new byte[30];
                int length = 3;
                int dwRet = GetPeopleSex(ref data[0], ref length);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(data, 0, length)];
                gb2312.GetChars(data, 0, length, asciiChars, 0);
                return new string(asciiChars).TrimEnd('\0');
            }
            catch { return ""; }
        }

        private static DateTime getBirthday()
        {
            try
            {
                byte[] data = null;
                data = new byte[30];
                int length = 16;
                int dwRet = GetPeopleBirthday(ref data[0], ref length);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(data, 0, length)];
                gb2312.GetChars(data, 0, length, asciiChars, 0);
                string birth = new string(asciiChars).Trim('\0');
                if (birth.Length == 10)
                    return Convert.ToDateTime(birth);
                return new DateTime(Convert.ToInt32(birth.Substring(0, 4)), Convert.ToInt32(birth.Substring(4, 2)), Convert.ToInt32(birth.Substring(6, 2)));
            }
            catch { }
            return new DateTime(1900, 1, 1);
        }

        private static string getAddress()
        {
            try
            {
                byte[] data = null;
                data = new byte[70];
                int length = 70;
                int dwRet = GetPeopleAddress(ref data[0], ref length);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(data, 0, length)];
                gb2312.GetChars(data, 0, length, asciiChars, 0);
                return new string(asciiChars).TrimEnd('\0');
            }
            catch { return ""; }
        }

        private static string getNation()
        {
            try
            {
                byte[] data = null;
                data = new byte[30];
                int length = 3;
                int dwRet = GetPeopleNation(ref data[0], ref length);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(data, 0, length)];
                gb2312.GetChars(data, 0, length, asciiChars, 0);
                return new string(asciiChars).TrimEnd('\0');
            }
            catch { return ""; }
        }

        private static string getIdCode()
        {
            try
            {
                byte[] data = null;
                data = new byte[36];
                int length = 36;
                int dwRet = GetPeopleIDCode(ref data[0], ref length);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(data, 0, length)];
                gb2312.GetChars(data, 0, length, asciiChars, 0);
                return new string(asciiChars).TrimEnd('\0');
            }
            catch { return ""; }
        }

        private static string getDepartment()
        {
            try
            {
                byte[] data = null;
                data = new byte[30];
                int length = 30;
                int dwRet = GetDepartment(ref data[0], ref length);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(data, 0, length)];
                gb2312.GetChars(data, 0, length, asciiChars, 0);
                return new string(asciiChars).TrimEnd('\0');
            }
            catch { return ""; }
        }

        private static DateTime getStartDate()
        {
            try
            {
                byte[] data = null;
                data = new byte[30];
                int length = 16;
                int dwRet = GetStartDate(ref data[0], ref length);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(data, 0, length)];
                gb2312.GetChars(data, 0, length, asciiChars, 0);
                string birth = new string(asciiChars).Trim('\0');
                if (birth.Length == 10)
                    return Convert.ToDateTime(birth);
                return new DateTime(Convert.ToInt32(birth.Substring(0, 4)), Convert.ToInt32(birth.Substring(4, 2)), Convert.ToInt32(birth.Substring(6, 2)));
            }
            catch { }
            return new DateTime(1900, 1, 1);
        }

        private static DateTime getEndDate()
        {
            try
            {
                byte[] data = null;
                data = new byte[30];
                int length = 16;
                int dwRet = GetEndDate(ref data[0], ref length);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(data, 0, length)];
                gb2312.GetChars(data, 0, length, asciiChars, 0);
                string birth = new string(asciiChars).Trim('\0');
                if (birth.Length == 10)
                    return Convert.ToDateTime(birth);
                return new DateTime(Convert.ToInt32(birth.Substring(0, 4)), Convert.ToInt32(birth.Substring(4, 2)), Convert.ToInt32(birth.Substring(6, 2)));
            }
            catch { }
            return new DateTime(1900, 1, 1);
        }

        private static Image getPhoto()
        {
            try
            {
                byte[] data = null;
                data = new byte[999999];
                int length = 16;
                int dwRet = GetJpgData(ref data[0], ref length);
                var bytes = new byte[length];
                Array.Copy(data, bytes, length);
                return ImageUtil.fromBytes(bytes);
            }
            catch { }
            return null;
        }

        private static string getReserve()
        {
            return "";
        }
        #endregion
    }
}
