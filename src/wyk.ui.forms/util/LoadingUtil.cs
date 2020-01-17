using System;
using System.Drawing;
using System.Windows.Forms;

namespace wyk.ui.utility
{
    public class LoadingUtil
    {
        #region private properties
        private const string LOADING_NAME = "_loading_bg_panel_";

        public static int dot_count = 10;
        public static int start_angle = 0;
        public static int dot_size = 10;
        public static int circle_size = 50;
        public static Color dot_color = Color.White;
        public static Color bg_color = Color.Black;
        public static int bg_opacity = 60;
        public static int animation_interval = 150;
        public static int dot_opacity_min = 20;
        public static int dot_opacity_max = 100;

        #endregion

        #region public properties

        #endregion

        #region private functions 
      
        #endregion

        #region public functions 
        public static Color coverBGColor()
        {
            return Color.FromArgb(Convert.ToInt32(Convert.ToDouble(bg_opacity) / 100 * 255), bg_color);
        }

        public static void showLoading(Control control, bool with_cover)
        {
            hideLoading(control);
            var loading = new ExLoading();
            loading.Name = LOADING_NAME;
            loading.Dock = DockStyle.Fill;
            loading.show_cover_color = with_cover;
            control.Controls.Add(loading);
            loading.BringToFront();
            loading.start();
        }

        public static void hideLoading(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Name == LOADING_NAME)
                {
                    try
                    {
                        var loading = c as ExLoading;
                        loading.stop();
                    }
                    catch { }
                    control.Controls.Remove(c);
                }
            }
        }
        #endregion
    }
}
