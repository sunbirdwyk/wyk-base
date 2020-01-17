using System.Drawing;
using System.Windows.Forms;
using wyk.ui.consts;
using wyk.ui.utility;

namespace wyk.ui
{
    public static class FormReferedExtention
    {
        /// <summary>
        /// 设置窗体的圆角矩形
        /// </summary>
        /// <param name="form">需要设置的窗体</param>
        /// <param name="rgn_radius">圆角矩形的半径</param>
        public static void setRoundRectRgn(this Form form, int rgn_radius)
        {
            int hRgn = 0;
            hRgn = WindowsUtil.CreateRoundRectRgn(0, 0, form.Width, form.Height, rgn_radius, rgn_radius);
            WindowsUtil.SetWindowRgn(form.Handle, hRgn, true);
            WindowsUtil.DeleteObject(hRgn);
        }

        /// <summary>
        /// 移动窗体
        /// </summary>
        /// <param name="form"></param>
        public static void moveWindow(this Form form)
        {
            WindowsUtil.ReleaseCapture();
            WindowsUtil.SendMessage(form.Handle, WindowMessage.WM_NCLBUTTONDOWN, WindowHitTest.HTCAPTION, 0);
        }

        /// <summary>
        /// 给form描边
        /// </summary>
        /// <param name="form"></param>
        /// <param name="edge_color"></param>
        /// <param name="edge_width"></param>
        public static void setEdge(this Form form, Color edge_color, int edge_width)
        {
            setEdge(form, form.CreateGraphics(), edge_color, edge_width);
        }

        /// <summary>
        /// 给form描边
        /// </summary>
        /// <param name="form"></param>
        /// <param name="g"></param>
        /// <param name="edge_color"></param>
        /// <param name="edge_width"></param>
        public static void setEdge(this Form form, Graphics g, Color edge_color, int edge_width)
        {
            g.DrawRectangle(new Pen(edge_color, edge_width), new Rectangle(edge_width / 2, edge_width / 2, form.Width - edge_width, form.Height - edge_width));
        }

        #region Notification Extention
        public static void hideNotification(this Form form)
        {
            ExNotification.HideNotification();
        }

        public static void showNotification(this Form form, string text, double close_delay)
        {
            form.showNotification(text, ExNotification.Instance.ForeColor, ExNotification.Instance.Font, ExNotification.Instance.BackColor, ExNotification.Instance.EdgeColor, ExNotification.Instance.MaxWidth, close_delay);
        }

        public static void showNotification(this ExFormBasic form, string text, double close_delay)
        {
            form.showNotification(text, ExNotification.Instance.ForeColor, ExNotification.Instance.Font, ExNotification.Instance.BackColor, ExNotification.Instance.EdgeColor, ExNotification.Instance.MaxWidth, close_delay);
        }

        public static void showNotification(this Form form, string text, NotificationUIStyle style, double close_delay)
        {
            ExNotification.Instance.Opacity = 0.8f;
            switch (style)
            {
                case NotificationUIStyle.Dark:
                    form.showNotification(text, Color.FromArgb(255, 255, 255), ExNotification.Instance.Font, Color.FromArgb(30, 30, 30), Color.Transparent, ExNotification.Instance.MaxWidth, close_delay);
                    break;
                case NotificationUIStyle.Light:
                    form.showNotification(text, Color.FromArgb(80, 80, 80), ExNotification.Instance.Font, Color.FromArgb(255, 255, 255), Color.FromArgb(150, 150, 150), ExNotification.Instance.MaxWidth, close_delay);
                    break;
                case NotificationUIStyle.Blue:
                    form.showNotification(text, Color.FromArgb(255, 255, 255), ExNotification.Instance.Font, Color.FromArgb(4, 116, 198), Color.Transparent, ExNotification.Instance.MaxWidth, close_delay);
                    break;
                case NotificationUIStyle.BlueLight:
                    form.showNotification(text, Color.FromArgb(4, 116, 198), ExNotification.Instance.Font, Color.FromArgb(255, 255, 255), Color.FromArgb(4, 116, 198), ExNotification.Instance.MaxWidth, close_delay);
                    break;
                case NotificationUIStyle.Green:
                    form.showNotification(text, Color.FromArgb(255, 255, 255), ExNotification.Instance.Font, Color.FromArgb(34, 139, 34), Color.Transparent, ExNotification.Instance.MaxWidth, close_delay);
                    break;
                case NotificationUIStyle.GreenLight:
                    form.showNotification(text, Color.FromArgb(34, 139, 34), ExNotification.Instance.Font, Color.FromArgb(255, 255, 255), Color.FromArgb(34, 139, 34), ExNotification.Instance.MaxWidth, close_delay);
                    break;
                case NotificationUIStyle.Red:
                    form.showNotification(text, Color.FromArgb(255, 255, 255), ExNotification.Instance.Font, Color.FromArgb(220, 20, 20), Color.Transparent, ExNotification.Instance.MaxWidth, close_delay);
                    break;
                case NotificationUIStyle.RedLight:
                    form.showNotification(text, Color.FromArgb(220, 20, 20), ExNotification.Instance.Font, Color.FromArgb(255, 255, 255), Color.FromArgb(220, 20, 20), ExNotification.Instance.MaxWidth, close_delay);
                    break;
                case NotificationUIStyle.Orange:
                    form.showNotification(text, Color.FromArgb(255, 255, 255), ExNotification.Instance.Font, Color.FromArgb(255, 165, 0), Color.Transparent, ExNotification.Instance.MaxWidth, close_delay);
                    break;
                case NotificationUIStyle.OrangeLight:
                    form.showNotification(text, Color.FromArgb(255, 165, 0), ExNotification.Instance.Font, Color.FromArgb(255, 255, 255), Color.FromArgb(255, 165, 0), ExNotification.Instance.MaxWidth, close_delay);
                    break;
            }
        }

        public static void showNotification(this Form form, string text, Color primary_color, bool is_light, double close_delay)
        {
            if (is_light)
                form.showNotification(text, primary_color, ExNotification.Instance.Font, Color.White, primary_color, ExNotification.Instance.MaxWidth, close_delay);
            else
                form.showNotification(text, Color.White, ExNotification.Instance.Font, primary_color, Color.Transparent, ExNotification.Instance.MaxWidth, close_delay);
        }

        public static void showNotification(this Form form, string text,Color text_color,Font text_font, Color back_color,Color edge_color,int max_width,double close_delay)
        {
            form.hideNotification();
            ExNotification.Instance.ForeColor = text_color;
            ExNotification.Instance.Text = text;
            ExNotification.Instance.Font = text_font;
            ExNotification.Instance.BackColor = back_color;
            ExNotification.Instance.EdgeColor = edge_color;
            ExNotification.Instance.MaxWidth = max_width;
            ExNotification.Instance.SuperiorForm = form;
            ExNotification.Show(close_delay);
        }
        #endregion


        #region Message Extention
        /// <summary>
        /// 获取窗体的左上角坐标(对屏幕), 使用时需要调用PointToClient转换为工作区坐标
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Point formPosition(this Message m)
        {
            int wparam = m.LParam.ToInt32();
            //低位X坐标 & 高位Y坐标
            return new Point(wparam & 0xFFFF, wparam >> 16);
        }
        #endregion
    }
}
