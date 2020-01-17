using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using wyk.ui.consts;
using wyk.ui.model;

namespace wyk.ui.utility
{
    public class WindowsUtil
    {
        [DllImport("gdi32.dll")]
        public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);
        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, Boolean bRedraw);
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject", CharSet = CharSet.Ansi)]
        public static extern int DeleteObject(int hObject);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern bool GetTextMetrics(IntPtr hdc, out TextMetric lptm);
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern bool DeleteObject(IntPtr hdc);
        [DllImport("User32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("User32.dll ")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
        #region
        struct RECT { public int Left, Top, Right, Bottom; }
        struct NCCALCSIZE_PARAMS
        {
            public RECT rcNewWindow;
            public RECT rcOldWindow;
            public RECT rcClient;
            IntPtr lppos;

            public NCCALCSIZE_PARAMS(RECT rcNewWindow, RECT rcOldWindow,RECT rcClient,IntPtr lppos)
            {
                this.rcNewWindow = rcNewWindow;
                this.rcOldWindow =rcOldWindow;
                this.rcClient = rcClient;
                this.lppos = lppos;
            }
        }

        static void AdjustClientRect(ref RECT rcClient, Padding padding)
        {
            rcClient.Left += padding.Left;
            rcClient.Top += padding.Top;
            rcClient.Right -= padding.Right;
            rcClient.Bottom -= padding.Bottom;
        }

        public static void ChangeClientRectalgle(ref Message message, Padding padding)
        {
            if (message.Msg == WindowMessage.WM_NCCALCSIZE)
            {
                if (message.WParam != IntPtr.Zero)
                {
                    NCCALCSIZE_PARAMS rcsize = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(message.LParam, typeof(NCCALCSIZE_PARAMS));
                    AdjustClientRect(ref rcsize.rcNewWindow, padding);
                    Marshal.StructureToPtr(rcsize, message.LParam, false);
                }
                else
                {
                    RECT rcsize = (RECT)Marshal.PtrToStructure(message.LParam, typeof(RECT));
                    AdjustClientRect(ref rcsize, padding);
                    Marshal.StructureToPtr(rcsize, message.LParam, false);
                }
                message.Result = new IntPtr(1);
            }
        }
        #endregion
    }
}
