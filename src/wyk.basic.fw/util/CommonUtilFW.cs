using System;
using System.Runtime.InteropServices;

namespace wyk.basic
{
    public class CommonUtilFW
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        /// <summary>
        /// 设置Window的位置
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="center_x"></param>
        /// <param name="center_y"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static IntPtr setWindowPosition(IntPtr hWnd, int hWndInsertAfter, int x, int y, int center_x, int center_y, int flags)
        {
            return SetWindowPos(hWnd, hWndInsertAfter, x, y, center_x, center_y, flags);
        }
    }
}