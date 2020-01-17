using System.Drawing;
using System.Drawing.Drawing2D;

namespace wyk.basic
{
    /// <summary>
    /// 用于在饼图上显示的值
    /// </summary>
    public class PieValue
    {
        public string Text { get; set; } = "";
        public double Value { get; set; } = 0;
        /// <summary>
        /// 留空则显示默认的样式: {名称}:{百分比}%
        /// 可使用样式替换符: {名称}, {值}, {百分比}
        /// </summary>
        public string Tooltip { get; set; } = "";


        public PieValue() { }
        public PieValue(string text, double value, string tooltip)
        {
            Text = text;
            Value = value;
            Tooltip = tooltip;
        }

        /// <summary>
        /// 饼图中所占的角度值, 绘图时计算
        /// </summary>
        public float sweep_angle = 0;
        public GraphicsPath path = null;
        public PointF center = new PointF();
        public RectangleF gradient_rect = new RectangleF();
        public float center_angle = 0;
    }
}
