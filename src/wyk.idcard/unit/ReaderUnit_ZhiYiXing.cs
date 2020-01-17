using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using wyk.basic;

namespace wyk.idcard.unit
{
    //智羿星
    [IDCardReader("ZhiYiXing", "")]
    public class ReaderUnit_ZhiYiXing : ReaderUnit
    {
        #region Imports
        const int MSG_CARD_READY = 0x0400 + 6;

        [DllImport(@"libs\ZhiYiXing\termb.dll")]
        public extern static int InitComm(int Port);
        [DllImport(@"libs\ZhiYiXing\termb.dll")]
        public extern static int InitCommExt();
        [DllImport(@"libs\ZhiYiXing\termb.dll")]
        public extern static int Authenticate();
        [DllImport(@"libs\ZhiYiXing\termb.dll")]
        public extern static int Read_Content(int Active);
        [DllImport(@"libs\ZhiYiXing\termb.dll")]
        unsafe public extern static int Read_Content_Path(string strPath, int Active);
        [DllImport(@"libs\ZhiYiXing\termb.dll")]
        unsafe public extern static int CloseComm();
        [DllImport(@"libs\ZhiYiXing\termb.dll")]
        unsafe public extern static int GetBmpPhoto(string Wlt_File);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
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
                int i = InitCommExt();
                if (i != 0)
                {
                    i = Authenticate();
                    if (i == 1)
                    {
                        i = Read_Content(1);
                        if (i == 1)
                        {
                            getCardInfo(ref info);
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
            catch (Exception ex) { msg = ex.Message; }
            return info;
        }

        #region Private Methods
        private static void getCardInfo(ref IDCardInfo info)
        {
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}\\libs\\ZhiYiXing\\wz.txt";
            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(fs, System.Text.Encoding.Unicode))
                {
                    string filecontent = sr.ReadToEnd();
                    sr.Close();
                    fs.Close();

                    //解析身份证指纹
                    //name
                    try
                    {
                        info.name = filecontent.Substring(0, 15).Trim();
                    }
                    catch { }
                    //gender
                    try
                    {
                        var gender = filecontent.Substring(15, 1);
                        if (gender == "1")
                            info.gender = "男";
                        else
                            info.gender = "女";
                    }
                    catch { }
                    //nation
                    try
                    {
                        int nation_id = Convert.ToInt32(filecontent.Substring(16, 2));
                        info.nation = getNation(nation_id);
                    }
                    catch { }
                    //birthday
                    try
                    {
                        var date_str = filecontent.Substring(18, 8);
                        info.Birthday = date_str.Insert(4, "-").Insert(7, "-");
                    }
                    catch { }
                    //address
                    try
                    {
                        info.address = filecontent.Substring(26, 35);
                    }
                    catch { }
                    //id_card_number
                    try
                    {
                        info.id_card_number = filecontent.Substring(61, 18);
                    }
                    catch { }
                    //department
                    try
                    {
                        info.department = filecontent.Substring(79, 15);
                    }
                    catch { }
                    //start date
                    try
                    {
                        var date_str = filecontent.Substring(94, 8);
                        info.StartDate = date_str.Insert(4, "-").Insert(7, "-");
                    }
                    catch { }
                    //end date 
                    try
                    {
                        var date_str = filecontent.Substring(102, 8);
                        info.EndDate = date_str.Insert(4, "-").Insert(7, "-");
                    }
                    catch { }
                }
            }

        }

        private static Image getPhotoBMP()
        {
            try
            {
                var path = $"{AppDomain.CurrentDomain.BaseDirectory}\\libs\\ZhiYiXing\\zp.bmp";
                return ImageUtil.fromUrl(path);
            }
            catch { }
            return null;
        }

        private static string getNation(int nNation)
        {
            switch (nNation)
            {
                default:
                    return "";
                case 01:
                    return "汉";
                case 02:
                    return "蒙古";
                case 03:
                    return "回";
                case 04:
                    return "藏";
                case 05:
                    return "维吾尔";
                case 06:
                    return "苗";
                case 07:
                    return "彝";
                case 08:
                    return "壮";
                case 09:
                    return "布依";
                case 10:
                    return "朝鲜";
                case 11:
                    return "满";
                case 12:
                    return "侗";
                case 13:
                    return "瑶";
                case 14:
                    return "白";
                case 15:
                    return "土家";
                case 16:
                    return "哈尼";
                case 17:
                    return "哈萨克";
                case 18:
                    return "傣";
                case 19:
                    return "黎";
                case 20:
                    return "傈僳";
                case 21:
                    return "佤";
                case 22:
                    return "畲";
                case 23:
                    return "高山";
                case 24:
                    return "拉祜";
                case 25:
                    return "水";
                case 26:
                    return "东乡";
                case 27:
                    return "纳西";
                case 28:
                    return "景颇";
                case 29:
                    return "柯尔克孜";
                case 30:
                    return "土";
                case 31:
                    return "达斡尔";
                case 32:
                    return "仫佬";
                case 33:
                    return "羌";
                case 34:
                    return "布朗";
                case 35:
                    return "撒拉";
                case 36:
                    return "毛南";
                case 37:
                    return "仡佬";
                case 38:
                    return "锡伯";
                case 39:
                    return "阿昌";
                case 40:
                    return "普米";
                case 41:
                    return "塔吉克";
                case 42:
                    return "怒";
                case 43:
                    return "乌孜别克";
                case 44:
                    return "俄罗斯";
                case 45:
                    return "鄂温克";
                case 46:
                    return "德昂";
                case 47:
                    return "保安";
                case 48:
                    return "裕固";
                case 49:
                    return "京";
                case 50:
                    return "塔塔尔";
                case 51:
                    return "独龙";
                case 52:
                    return "鄂伦春";
                case 53:
                    return "赫哲";
                case 54:
                    return "门巴";
                case 55:
                    return "珞巴";
                case 56:
                    return "基诺";
            }
        }
        #endregion
    }
}