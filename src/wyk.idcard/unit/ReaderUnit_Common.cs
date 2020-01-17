using System;
using System.Runtime.InteropServices;
using wyk.basic;

namespace wyk.idcard.unit
{
    [IDCardReader("Common", "")]
    public class ReaderUnit_Common : ReaderUnit
    {
        #region Imports
        /************************端口类API *************************/
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SetMaxRFByte", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_GetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetCOMBaud(int iPort, ref uint puiBaudRate);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetCOMBaud(int iPort, uint uiCurrBaud, uint uiSetBaud);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int iPort);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_ClosePort", CharSet = CharSet.Ansi)]
        public static extern int Syn_ClosePort(int iPort);
        /**************************SAM类函数 **************************/
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_ResetSAM", CharSet = CharSet.Ansi)]
        public static extern int Syn_ResetSAM(int iPort, int iIfOpen);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMStatus", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMStatus(int iPort, int iIfOpen);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMID", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMID(int iPort, ref byte pucSAMID, int iIfOpen);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMIDToStr", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMIDToStr(int iPort, ref byte pcSAMID, int iIfOpen);
        /*************************身份证卡类函数 ***************************/
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int iPort, ref byte pucIIN, int iIfOpen);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int iPort, ref byte pucSN, int iIfOpen);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, int iIfOpen);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_ReadIINSNDN", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadIINSNDN(int iPort, ref byte pucIINSNDN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, int iIfOpen);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_ReadIINSNDNToASCII", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadIINSNDNToASCII(int iPort, ref byte pucIINSNDN, int iIfOpen);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_ReadNewAppMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadNewAppMsg(int iPort, ref byte pucAppMsg, ref uint puiAppMsgLen, int iIfOpen);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_GetBmp", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetBmp(int iPort, ref byte Wlt_File);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_FindReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindReader();
        /***********************设置附加功能函数 ************************/
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoPath", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoPath(int iOption, ref byte cPhotoPath);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoType(int iType);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoName", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoName(int iType);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SetSexType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetSexType(int iType);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SetNationType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetNationType(int iType);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SetBornType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetBornType(int iType);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeBType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeBType(int iType);
        [DllImport(@"libs\Common\SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeEType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeEType(int iType, int iOption);
        #endregion

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct IDCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] //结构中使用的字串，[]类似限定说明 说明此公共结构传输到非托管代码时封装定义
            public string Name; //姓名   
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            public string Sex;   //性别
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Nation; //民族
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string Born; //出生日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)]
            public string Address; //住址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string IDCardNo; //身份证号
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string GrantDept; //发证机关
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeBegin; // 有效开始日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeEnd;  // 有效截止日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string reserved; // 保留
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string PhotoFileName; // 照片路径
        }

        public override IDCardInfo readIDCard(bool get_photo, out string msg)
        {
            msg = "";
            //如果端口号为空,则以1001为默认
            if (port_number == "")
                port_number = "1001";
            IDCardInfo info = new IDCardInfo();
            try
            {
                var port = Syn_FindReader();
                if (port <= 0)
                {
                    msg = "无法获取有效的读卡器";
                    return info;
                }
                if (Syn_OpenPort(port) != 0)
                {
                    msg = "打开端口失败";
                    return info;
                }
                if (Syn_SetMaxRFByte(port, 80, 0) != 0)
                {
                    msg = "尝试连接读卡器失败";
                    return info;
                }
                var pucIIN = new byte[4];
                if (Syn_StartFindIDCard(port, ref pucIIN[0], 0) != 0)
                {
                    msg = "查询身份证失败, 请确认身份证已放置";
                    return info;
                }
                var pucSN = new byte[8];
                if (Syn_SelectIDCard(port, ref pucSN[0], 0) != 0)
                {
                    msg = "选择卡片失败, 请重试";
                    return info;
                }
                var card_msg = new IDCardData();
                if (Syn_ReadMsg(port, 0, ref card_msg) != 0)
                {
                    msg = "读取卡片信息失败, 请重试";
                    return info;
                }
                info.name = card_msg.Name;
                info.gender = card_msg.Sex;
                info.nation = card_msg.Name;
                info.Birthday = card_msg.Born;
                info.address = card_msg.Address;
                info.id_card_number = card_msg.IDCardNo;
                info.department = card_msg.GrantDept;
                info.StartDate = card_msg.UserLifeBegin;
                info.EndDate = card_msg.UserLifeEnd;
                if (get_photo)
                    info.photo = ImageUtil.fromUrl(AppDomain.CurrentDomain.BaseDirectory + card_msg.PhotoFileName);
            }
            catch (Exception ex) { msg = ex.Message; }
            return info;
        }
    }
}