using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using wyk.basic;

namespace wyk.ui
{
    /// <summary>
    /// 边框样式设置
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BorderConfig
    {

        public BorderConfig() { }
        public BorderConfig(BorderStyleEx Style)
        {
            this.Style = Style;
            CornerRadius = 0;
            Width = 1;
        }
        public BorderConfig(BorderStyleEx Style, float CornerRadius, float Width)
        {
            this.Style = Style;
            this.CornerRadius = CornerRadius;
            this.Width = Width;
        }

        public BorderConfig copy()
        {
            return new BorderConfig(Style, CornerRadius, Width);
        }

        [Description("边框样式")]
        public BorderStyleEx Style { get; set; } = BorderStyleEx.RoundedRectangle;

        [Description("边框圆角半径(仅RoundedRectangle可用)")]
        public float CornerRadius { get; set; } = 3;

        [Description("边框宽度")]
        public float Width { get; set; } = 1;

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="color">边框颜色</param>
        public void drawBorder(Graphics g, RectangleF rect, Color color)
        {
            if (color == Color.Transparent)
                return;
            if (Width <= 0)
                return;
            switch (Style)
            {
                case BorderStyleEx.None:
                default:
                    break;
                case BorderStyleEx.BottomLine:
                    using (var pen = new Pen(color, Width))
                        g.DrawLine(pen, rect.X, rect.Y + rect.Height - Width / 2, rect.X + rect.Width, rect.Y + rect.Height - Width / 2);
                    break;
                case BorderStyleEx.Capsule:
                    rect = new RectangleF(rect.X + Width / 2, rect.Y + Width / 2, rect.Width - Width, rect.Height - Width);
                    GraphicsPath path = g.generateCapsule(rect);
                    using (var pen = new Pen(color, Width))
                        g.DrawPath(pen, path);
                    break;
                case BorderStyleEx.Rectangle:
                    rect = new RectangleF(rect.X + Width / 2, rect.Y + Width / 2, rect.Width - Width, rect.Height - Width);
                    using (var pen = new Pen(color, Width))
                        g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                    break;
                case BorderStyleEx.RoundedRectangle:
                    rect = new RectangleF(rect.X + Width / 2, rect.Y + Width / 2, rect.Width - Width, rect.Height - Width);
                    using (var pen = new Pen(color, Width))
                        g.drawRoundedRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height, CornerRadius);
                    break;
            }
        }

        /// <summary>
        /// 绘制背景
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="color">背景颜色</param>
        public void drawBackground(Graphics g, RectangleF rect, Color color)
        {
            if (color == Color.Transparent)
                return;
            if (Width > 0 && Style != BorderStyleEx.None)
                rect = new RectangleF(rect.X + Width / 2, rect.Y + Width / 2, rect.Width - Width, rect.Height - Width);
            using (var brush = new SolidBrush(color))
            {
                switch (Style)
                {
                    case BorderStyleEx.None:
                    default:
                        g.FillRectangle(brush, rect);
                        break;
                    case BorderStyleEx.BottomLine:
                        g.FillRectangle(brush, rect);
                        break;
                    case BorderStyleEx.Capsule:
                        GraphicsPath path = g.generateCapsule(rect);
                        g.FillPath(brush, path);
                        break;
                    case BorderStyleEx.Rectangle:
                        g.FillRectangle(brush, rect);
                        break;
                    case BorderStyleEx.RoundedRectangle:
                        g.fillRoundedRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height, CornerRadius);
                        break;
                }
            }
        }

        /// <summary>
        /// 绘制边框和背景
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="border_color">边框颜色</param>
        /// <param name="background_color">背景颜色</param>
        public void drawBorderAndBackground(Graphics g, RectangleF rect, Color border_color, Color background_color)
        {
            if (background_color != Color.Transparent)
                drawBackground(g, rect, background_color);
            if (border_color != Color.Transparent && border_color != background_color)
                drawBorder(g, rect, border_color);
        }
    }
}