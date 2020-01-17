using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace wyk.basic
{
    /// <summary>
    /// 硬件信息
    /// </summary>
    public class HardwareInfo
    {
        static string _cpu_id;
        static string _mac_address;
        static string[] _disk_ids;
        static string[] _ide_drives;
        static string _ip_address;
        static string[] _ip_address_list;
        static string _login_user_name;
        static string _computer_name;
        static string _system_type;
        static string _total_physical_memory;

        /// <summary>
        /// CPU序列号
        /// </summary>
        public static string CpuId
        {
            get
            {
                if (_cpu_id.isNull())
                {
                    try
                    {
                        using (var mc = new ManagementClass("Win32_Processor"))
                        {
                            using (var moc = mc.GetInstances())
                            {
                                foreach (var mo in moc)
                                {
                                    _cpu_id = mo.Properties["ProcessorId"].Value.ToString();
                                    break;
                                }
                            }
                        }
                    }
                    catch { _cpu_id = "unknown"; }
                }
                return _cpu_id;
            }
        }

        /// <summary>
        /// MAC 地址
        /// </summary>
        public static string MacAddress
        {
            get
            {
                if (_mac_address.isNull())
                {
                    try
                    {
                        using (var mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                        {
                            using (var moc = mc.GetInstances())
                            {
                                foreach (var mo in moc)
                                {
                                    if ((bool)mo["IPEnabled"] == true)
                                    {
                                        _mac_address = mo["MacAddress"].ToString();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch { _mac_address = "unknown"; }
                }
                return _mac_address;
            }
        }

        /// <summary>
        /// 硬盘ID
        /// </summary>
        public static string[] DiskIds
        {
            get
            {
                if (_disk_ids == null)
                {
                    try
                    {

                        using (var mc = new ManagementClass("Win32_DiskDrive"))
                        {
                            using (var moc = mc.GetInstances())
                            {
                                var HDids = new ArrayList();
                                foreach (var mo in moc)
                                {
                                    try
                                    {
                                        HDids.Add((string)mo.Properties["Model"].Value);
                                        _disk_ids = (string[])HDids.ToArray(typeof(string));
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch { _disk_ids = new string[0]; }
                }
                return _disk_ids;
            }
        }

        /// <summary>
        /// IDE设备
        /// </summary>
        public static string[] IDEDrives
        {
            get
            {
                if (_ide_drives == null)
                {
                    try
                    {
                        var ideList = new ArrayList();
                        for (byte i = 0; i <= 255; i++)
                        {
                            string res = IDE.Read(i);
                            if (res != "")
                                ideList.Add(res);
                            else
                                break;
                        }
                        _ide_drives = (string[])ideList.ToArray(typeof(string));
                    }
                    catch
                    {
                        _ide_drives = new string[0];
                    }
                }
                return _ide_drives;
            }
        }

        /// <summary>
        /// IP地址(首个)
        /// </summary>
        public static string IPAddress
        {
            get
            {
                if (_ip_address.isNull())
                {
                    try
                    {
                        using (var mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                        {
                            using (var moc = mc.GetInstances())
                            {
                                foreach (var mo in moc)
                                {
                                    if ((bool)mo["IPEnabled"] == true)
                                    {
                                        var ar = (Array)mo.Properties["IpAddress"].Value;
                                        _ip_address = ar.GetValue(0).ToString();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch { _ip_address = "unknown"; }
                }
                return _ip_address;
            }
        }

        /// <summary>
        /// IP地址列表
        /// </summary>
        public static string[] IPAddressList
        {
            get
            {
                if (_ip_address_list == null)
                {
                    try
                    {
                        using (var mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                        {
                            using (var moc = mc.GetInstances())
                            {
                                foreach (var mo in moc)
                                {
                                    if ((bool)mo["IPEnabled"] == true)
                                    {
                                        var ar = (Array)mo.Properties["IpAddress"].Value;
                                        var list = new List<string>();
                                        for (int i = 0; i < ar.Length; i++)
                                        {
                                            list.Add(ar.GetValue(i).ToString());
                                        }
                                        _ip_address_list = list.ToArray();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                }
                return _ip_address_list;
            }
        }

        /// <summary>
        /// 当前登录用户名
        /// </summary>
        public static string LoginUserName
        {
            get
            {
                if (_login_user_name.isNull())
                {
                    try
                    {
                        using (var mc = new ManagementClass("Win32_ComputerSystem"))
                        {
                            using (var moc = mc.GetInstances())
                            {
                                foreach (var mo in moc)
                                {
                                    _login_user_name = mo["UserName"].ToString();
                                }
                            }
                        }
                    }
                    catch { _login_user_name = "unknown"; }
                }
                return _login_user_name;
            }
        }

        /// <summary>
        /// 计算机名
        /// </summary>
        public static string ComputerName
        {
            get
            {
                if (_computer_name.isNull())
                {
                    try
                    {
                        _computer_name = Environment.GetEnvironmentVariable("ComputerName");
                    }
                    catch { _computer_name = "unknown"; }
                }
                return _computer_name;
            }
        }

        /// <summary>
        /// 系统类型
        /// </summary>
        public static string SystemType
        {
            get
            {
                if (_system_type.isNull())
                {
                    try
                    {
                        using (var mc = new ManagementClass("Win32_ComputerSystem"))
                        {
                            using (var moc = mc.GetInstances())
                            {
                                foreach (var mo in moc)
                                {
                                    _system_type = mo["SystemType"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                    catch { _system_type = "unknown"; }
                }
                return _system_type;
            }
        }

        /// <summary>
        /// 物理内存总量
        /// </summary>
        public static string TotalPhysicalMemory
        {
            get
            {
                if (_total_physical_memory.isNull())
                {
                    try
                    {
                        using (var mc = new ManagementClass("Win32_ComputerSystem"))
                        {
                            using (var moc = mc.GetInstances())
                            {
                                foreach (var mo in moc)
                                {
                                    _total_physical_memory = mo["TotalPhysicalMemory"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                    catch { _total_physical_memory = "unknown"; }
                }
                return _total_physical_memory;
            }
        }

        /// <summary>
        /// 获取机器号
        /// </summary>
        /// <returns></returns>
        public static string MachineId()
        {
            return MD5Crypto.encrypt32(CpuId + DiskIds[0] + MacAddress);
        }

        /// <summary>
        /// 获取机器号
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string MachineId(string prefix)
        {
            return MD5Crypto.encrypt32(prefix + Convert.ToChar(29) + CpuId + DiskIds[0] + MacAddress);
        }

        /// <summary>
        /// 获取机器号(可区分同机器不同软件)
        /// </summary>
        /// <param name="prefix">前置字符串</param>
        /// <param name="MachineId">机器号</param>
        /// <returns></returns>
        public static string MachineId(string prefix, string MachineId)
        {
            return MD5Crypto.encrypt32(prefix + Convert.ToChar(29) + MachineId);
        }

        /// <summary>
        /// 列出当前系统中的打印机列表
        /// </summary>
        /// <returns></returns>
        public static string[] printerList()
        {
            string[] list = new string[PrinterSettings.InstalledPrinters.Count];
            int index = 0;
            foreach (string sPrint in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            {
                list[index] = sPrint;
                index++;
            }
            return list;
        }
    }


    public class IDE
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct IDSECTOR
        {
            public ushort wGenConfig;
            public ushort wNumCyls;
            public ushort wReserved;
            public ushort wNumHeads;
            public ushort wBytesPerTrack;
            public ushort wBytesPerSector;
            public ushort wSectorsPerTrack;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public ushort[] wVendorUnique;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string sSerialNumber;
            public ushort wBufferType;
            public ushort wBufferSize;
            public ushort wECCSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
            public string sFirmwareRev;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
            public string sModelNumber;
            public ushort wMoreVendorUnique;
            public ushort wDoubleWordIO;
            public ushort wCapabilities;
            public ushort wReserved1;
            public ushort wPIOTiming;
            public ushort wDMATiming;
            public ushort wBS;
            public ushort wNumCurrentCyls;
            public ushort wNumCurrentHeads;
            public ushort wNumCurrentSectorsPerTrack;
            public uint ulCurrentSectorCapacity;
            public ushort wMultSectorStuff;
            public uint ulTotalAddressableSectors;
            public ushort wSingleWordDMA;
            public ushort wMultiWordDMA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public byte[] bReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct DRIVERSTATUS
        {
            public byte bDriverError;
            public byte bIDEStatus;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] bReserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public uint[] dwReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SENDCMDOUTPARAMS
        {
            public uint cBufferSize;
            public DRIVERSTATUS DriverStatus;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 513)]
            public byte[] bBuffer;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct SRB_IO_CONTROL
        {
            public uint HeaderLength;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
            public string Signature;
            public uint Timeout;
            public uint ControlCode;
            public uint ReturnCode;
            public uint Length;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct IDEREGS
        {
            public byte bFeaturesReg;
            public byte bSectorCountReg;
            public byte bSectorNumberReg;
            public byte bCylLowReg;
            public byte bCylHighReg;
            public byte bDriveHeadReg;
            public byte bCommandReg;
            public byte bReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SENDCMDINPARAMS
        {
            public uint cBufferSize;
            public IDEREGS irDriveRegs;
            public byte bDriveNumber;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] bReserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public uint[] dwReserved;
            public byte bBuffer;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct GETVERSIONOUTPARAMS
        {
            public byte bVersion;
            public byte bRevision;
            public byte bReserved;
            public byte bIDEDeviceMap;
            public uint fCapabilities;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public uint[] dwReserved; // For future use. 
        }

        [DllImport("kernel32.dll")]
        private static extern int CloseHandle(uint hObject);

        [DllImport("kernel32.dll")]
        private static extern int DeviceIoControl(uint hDevice,
                                                  uint dwIoControlCode,
                                                  ref SENDCMDINPARAMS lpInBuffer,
                                                  int nInBufferSize,
                                                  ref SENDCMDOUTPARAMS lpOutBuffer,
                                                  int nOutBufferSize,
                                                  ref uint lpbytesReturned,
                                                  int lpOverlapped);

        [DllImport("kernel32.dll")]
        private static extern int DeviceIoControl(uint hDevice,
                                                  uint dwIoControlCode,
                                                  int lpInBuffer,
                                                  int nInBufferSize,
                                                  ref GETVERSIONOUTPARAMS lpOutBuffer,
                                                  int nOutBufferSize,
                                                  ref uint lpbytesReturned,
                                                  int lpOverlapped);

        [DllImport("kernel32.dll")]
        private static extern uint CreateFile(string lpFileName,
                                              uint dwDesiredAccess,
                                              uint dwShareMode,
                                              int lpSecurityAttributes,
                                              uint dwCreationDisposition,
                                              uint dwFlagsAndAttributes,
                                              int hTemplateFile);

        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint FILE_SHARE_READ = 0x00000001;
        private const uint FILE_SHARE_WRITE = 0x00000002;
        private const uint OPEN_EXISTING = 3;
        private const uint INVALID_HANDLE_VALUE = 0xffffffff;
        private const uint DFP_GET_VERSION = 0x00074080;
        private const int IDE_ATAPI_IDENTIFY = 0xA1; // Returns ID sector for ATAPI. 
        private const int IDE_ATA_IDENTIFY = 0xEC; // Returns ID sector for ATA. 
        private const int IDENTIFY_BUFFER_SIZE = 512;
        private const uint DFP_RECEIVE_DRIVE_DATA = 0x0007c088;

        public static string Read(byte drive)
        {
            OperatingSystem os = Environment.OSVersion;
            if (os.Platform != PlatformID.Win32NT) throw new NotSupportedException("仅支持WindowsNT/2000/XP");

            //if (os.Version.Major < 5) throw new NotSupportedException("仅支持WindowsNT/2000/XP"); 

            string driveName = "\\\\.\\PhysicalDrive" + drive.ToString();
            uint device = CreateFile(driveName,
                                     GENERIC_READ | GENERIC_WRITE,
                                     FILE_SHARE_READ | FILE_SHARE_WRITE,
                                     0, OPEN_EXISTING, 0, 0);
            if (device == INVALID_HANDLE_VALUE) return "";
            GETVERSIONOUTPARAMS verPara = new GETVERSIONOUTPARAMS();
            uint bytRv = 0;

            if (0 != DeviceIoControl(device, DFP_GET_VERSION,
                                     0, 0, ref verPara, Marshal.SizeOf(verPara),
                                     ref bytRv, 0))
            {
                if (verPara.bIDEDeviceMap > 0)
                {
                    byte bIDCmd = (byte)(((verPara.bIDEDeviceMap >> drive & 0x10) != 0) ? IDE_ATAPI_IDENTIFY : IDE_ATA_IDENTIFY);
                    SENDCMDINPARAMS scip = new SENDCMDINPARAMS();
                    SENDCMDOUTPARAMS scop = new SENDCMDOUTPARAMS();

                    scip.cBufferSize = IDENTIFY_BUFFER_SIZE;
                    scip.irDriveRegs.bFeaturesReg = 0;
                    scip.irDriveRegs.bSectorCountReg = 1;
                    scip.irDriveRegs.bCylLowReg = 0;
                    scip.irDriveRegs.bCylHighReg = 0;
                    scip.irDriveRegs.bDriveHeadReg = (byte)(0xA0 | ((drive & 1) << 4));
                    scip.irDriveRegs.bCommandReg = bIDCmd;
                    scip.bDriveNumber = drive;

                    if (0 != DeviceIoControl(device, DFP_RECEIVE_DRIVE_DATA,
                                             ref scip, Marshal.SizeOf(scip), ref scop,
                                             Marshal.SizeOf(scop), ref bytRv, 0))
                    {
                        StringBuilder s = new StringBuilder();
                        for (int i = 20; i < 40; i += 2)
                        {
                            s.Append((char)(scop.bBuffer[i + 1]));
                            s.Append((char)scop.bBuffer[i]);
                        }
                        CloseHandle(device);
                        return s.ToString().Trim();
                    }
                }
            }
            CloseHandle(device);
            return "";
        }
    }
}