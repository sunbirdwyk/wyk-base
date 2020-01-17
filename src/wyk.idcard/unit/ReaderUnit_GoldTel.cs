using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace wyk.idcard.unit
{
    [IDCardReader("GoldTel", "")]
    public class ReaderUnit_GoldTel : ReaderUnit
    {
        #region Imports
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int InitComm(int iPort);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int CloseComm();

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int Authenticate();

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int Read_Content(int iActive);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPeopleName(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPeopleSex(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPeopleNation(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPeopleBirthday(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPeopleAddress(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPeopleIDCode(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetStartDate(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetEndDate(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetDepartment(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetReserve(Byte[] buf, int iLen);

        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPhotoBMP(Byte[] buf, int iLen);
        #endregion

        public override IDCardInfo readIDCard(bool get_photo, out string msg)
        {
            msg = "";
            //如果端口号为空,则以1001为默认
            if (port_number == "")
                port_number = "1001";
            IDCardInfo info = new IDCardInfo();
            try
            {
                int i = InitComm(Convert.ToInt32(port_number));
                if (i == 1)
                {
                    i = Authenticate();
                    if (i == 1)
                    {
                        i = Read_Content(2);
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
                                info.photo = getPhotoBMP();
                            info.read_from_machine = true;
                            i = CloseComm();
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
            catch(Exception ex) { msg = ex.Message; }
            return info;
        }

        #region Private Methods
        private static string getName()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[30];
                int dwRet = GetPeopleName(asciiBytes, 30);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
                gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
                return new string(asciiChars);
            }
            catch { return ""; }
        }

        private static string getSex()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[2];
                int dwRet = GetPeopleSex(asciiBytes, 2);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
                gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
                return new string(asciiChars);
            }
            catch { return ""; }
        }

        private static DateTime getBirthday()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[16];
                int dwRet = GetPeopleBirthday(asciiBytes, 16);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
                gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
                string birth = new string(asciiChars);
                return new DateTime(Convert.ToInt32(birth.Substring(0, 4)), Convert.ToInt32(birth.Substring(4, 2)), Convert.ToInt32(birth.Substring(6, 2)));
            }
            catch { }
            return new DateTime(1900, 1, 1);
        }

        private static string getAddress()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[70];
                int dwRet = GetPeopleAddress(asciiBytes, 70);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
                gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
                return new string(asciiChars);
            }
            catch { return ""; }
        }

        private static string getNation()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[4];
                int dwRet = GetPeopleNation(asciiBytes, 4);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
                gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
                return new string(asciiChars);
            }
            catch { return ""; }
        }

        private static string getIdCode()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[36];
                int dwRet = GetPeopleIDCode(asciiBytes, 36);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
                gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
                return new string(asciiChars);
            }
            catch { return ""; }
        }

        private static string getDepartment()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[30];
                int dwRet = GetDepartment(asciiBytes, 30);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
                gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
                return new string(asciiChars);
            }
            catch { return ""; }
        }

        private static DateTime getStartDate()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[16];
                int dwRet = GetStartDate(asciiBytes, 16);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
                gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
                string birth = new string(asciiChars);
                return new DateTime(Convert.ToInt32(birth.Substring(0, 4)), Convert.ToInt32(birth.Substring(4, 2)), Convert.ToInt32(birth.Substring(6, 2)));
            }
            catch { }
            return new DateTime(1900, 1, 1);
        }

        private static DateTime getEndDate()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[16];
                int dwRet = GetEndDate(asciiBytes, 16);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
                gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
                string birth = new string(asciiChars);
                return new DateTime(Convert.ToInt32(birth.Substring(0, 4)), Convert.ToInt32(birth.Substring(4, 2)), Convert.ToInt32(birth.Substring(6, 2)));
            }
            catch { }
            return new DateTime(1900, 1, 1);
        }

        private static Image getPhotoBMP()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[100 * 1024];
                int dwRet = GetPhotoBMP(asciiBytes, 100 * 1024);
                string tmp_path = AppDomain.CurrentDomain.BaseDirectory + "tmp.bmp";
                FileStream fs = new FileStream(tmp_path, FileMode.Create, FileAccess.ReadWrite);
                fs.Write(asciiBytes, 0, dwRet);
                Image img = Image.FromStream(fs);
                fs.Close();
                try
                {
                    File.Delete(tmp_path);
                }
                catch { }
                return img;
            }
            catch { }
            return null;
        }

        private static string getReserve()
        {
            try
            {
                Byte[] asciiBytes = null;
                asciiBytes = new Byte[36];
                int dwRet = GetReserve(asciiBytes, 36);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
                gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
                return new string(asciiChars);
            }
            catch { return ""; }
        }
        #endregion
    }
}
