using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace wyk.basic
{
    public class UIUtil
    {
        #region Win32 API  
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr ptr);
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(
        IntPtr hdc, // handle to DC  
        int nIndex // index of capability  
        );
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        #endregion
        #region DeviceCaps常量  
        const int HORZRES = 8;
        const int VERTRES = 10;
        const int LOGPIXELSX = 88;
        const int LOGPIXELSY = 90;
        const int DESKTOPVERTRES = 117;
        const int DESKTOPHORZRES = 118;
        #endregion
        public static int _dpi = 0;

        public static int dpi
        {
            get
            {
                if (_dpi == 0)
                {
                    try
                    {
                        IntPtr hdc = GetDC(IntPtr.Zero);
                        _dpi = GetDeviceCaps(hdc, LOGPIXELSX);
                        ReleaseDC(IntPtr.Zero, hdc);
                    }
                    catch { _dpi = 96; }
                }
                return _dpi;
            }
        }

        /// <summary>
        /// 获取某长度(毫米mm)在某个分辨率下对应的像素值
        /// </summary>
        /// <param name="mm">长度(毫米mm)</param>
        /// <param name="dpi">屏幕分辨率</param>
        /// <returns>像素值</returns>
        public static int pxFromMM(float mm, int dpi)
        {
            float px = mm / 25.4f * dpi;
            return Convert.ToInt32(px);
        }

        /// <summary>
        /// 获取某长度(毫米mm)在某个分辨率下对应的像素值, 使用默认dpi
        /// </summary>
        /// <param name="mm">长度(毫米mm)</param>
        /// <returns>像素值</returns>
        public static int pxFromMM(float mm)
        {
            float px = mm / 25.4f * dpi;
            return Convert.ToInt32(px);
        }

        /// <summary>
        /// 获取某像素值在某个分辨率下对应的长度(毫米mm)
        /// </summary>
        /// <param name="px">像素值</param>
        /// <param name="dpi">屏幕分辨率</param>
        /// <returns>长度(毫米mm)</returns>
        public static float mmFromPx(int px, int dpi)
        {
            float mm = px * 25.4f / dpi;
            return (float)Math.Round(mm, 2);
        }

        /// <summary>
        /// 获取某像素值在某个分辨率下对应的长度(毫米mm), 使用默认dpi
        /// </summary>
        /// <param name="px">像素值</param>
        /// <returns>长度(毫米mm)</returns>
        public static float mmFromPx(int px)
        {
            float mm = px * 25.4f / dpi;
            return (float)Math.Round(mm, 2);
        }

        /// <summary>
        /// 获取字体磅数在某个分辨率下对应的像素值
        /// </summary>
        /// <param name="pt">磅数(字体)</param>
        /// <param name="dpi">分辨率</param>
        /// <returns>像素值</returns>
        public static int pxFromPt(float pt, int dpi)
        {
            return Convert.ToInt32(pt * 72 / dpi);
        }

        /// <summary>
        /// 获取字体磅数在某个分辨率下对应的像素值, 使用默认dpi
        /// </summary>
        /// <param name="pt">磅数(字体)</param>
        /// <returns>像素值</returns>
        public static int pxFromPt(float pt)
        {
            return Convert.ToInt32(pt * 72 / dpi);
        }

        /// <summary>
        /// 获取某像素值在某个分辨率下的磅数(字体)
        /// </summary>
        /// <param name="px">像素值</param>
        /// <param name="dpi">分辨率</param>
        /// <returns>磅数(字体)</returns>
        public static float ptFromPx(int px, int dpi)
        {
            return ((float)px) * dpi / 72;
        }

        /// <summary>
        /// 获取某像素值在某个分辨率下的磅数(字体), 使用默认dpi
        /// </summary>
        /// <param name="px">像素值</param>
        /// <returns>磅数(字体)</returns>
        public static float ptFromPx(int px)
        {
            return ((float)px) * dpi / 72;
        }

        /// <summary>
        /// 获取某长度(mm)对应的磅数(字体)
        /// </summary>
        /// <param name="mm">长度(mm)</param>
        /// <returns>磅数(字体)</returns>
        public static float ptFromMM(float mm)
        {
            return mm * 72 / 25.4f;
        }

        /// <summary>
        /// 获取磅数(字体)对应的长度(mm)
        /// </summary>
        /// <param name="pt">磅数(字体)</param>
        /// <returns>长度(mm)</returns>
        public static float mmFromPt(float pt)
        {
            return pt * 25.4f / 72;
        }

        /// <summary>
        /// 将字符串设置转为Font实例
        /// </summary>
        /// <param name="font_string">字体配置字符串,格式为[名称,大小(pt),是否粗体(0/1或false/true)]</param>
        /// <returns>Font实例</returns>
        public static Font fontFromString(string font_string)
        {
            var parts = font_string.Split(',');
            float size = 9;
            try
            {
                size = (float)Convert.ToDouble(parts[1]);
            }
            catch { }
            FontStyle style = FontStyle.Regular;
            try
            {
                if (parts[2].Trim() == "1" || parts[2].Trim().ToLower() == "true")
                    style = FontStyle.Bold;
            }
            catch { }
            try
            {
                return new Font(parts[0], size, style);
            }
            catch { }
            return new Font("微软雅黑", 9, FontStyle.Regular);
        }

        /// <summary>
        /// 将Font实例转为字体配置字符串,格式为[名称,大小(pt),是否粗体(0/1)]
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public static string fontToString(Font font)
        {
            return font.FontFamily + "," + font.Size + "," + (font.Style == FontStyle.Bold ? "1" : "0");
        }
    }
}