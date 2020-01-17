using System.Windows.Forms;

namespace wyk.basic
{
    public static class PanelReferedExtention
    {
        /// <summary>
        /// 为Panel设置双倍缓冲状态
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="double_buffered"></param>
        public static void setDoubleBuffered(this Panel panel, bool double_buffered)
        {
            panel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(panel, double_buffered, null);
        }

        /// <summary>
        /// 为Panel设置双倍缓冲(true)
        /// </summary>
        /// <param name="panel"></param>
        public static void setDoubleBuffered(this Panel panel)
        {
            panel.setDoubleBuffered(true);
        }

        public static void setAutoScrollNoHorizontal(this FlowLayoutPanel panel)
        {
            panel.WrapContents = false;
            panel.HorizontalScroll.Maximum = 0;
            panel.AutoScroll = true;
            panel.FlowDirection = FlowDirection.TopDown;
        }
    }
}
