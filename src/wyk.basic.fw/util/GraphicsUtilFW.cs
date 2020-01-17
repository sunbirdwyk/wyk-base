using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace wyk.basic
{
    public class GraphicsUtilFW
    {
        /// <summary>
        /// 在指定矩形区域内绘制文本
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        /// <param name="alignment"></param>
        public static void drawTextInRect(Graphics g, string text, Font font, Rectangle rect, Color color, ContentAlignment alignment)
        {
            drawTextInRect(g, text, font, rect, color, alignment, false);
        }

        /// <summary>
        /// 在指定矩形区域内绘制文本
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        /// <param name="alignment"></param>
        /// <param name="right_to_left"></param>
        public static void drawTextInRect(Graphics g, string text, Font font, Rectangle rect, Color color, ContentAlignment alignment, bool right_to_left)
        {
            TextRenderer.DrawText(
                 g,
                 text,
                 font,
                 rect,
                 color,
                 getTextFormatFlags(alignment, right_to_left));
        }

        /// <summary>
        /// 在指定矩形区域内绘制文本
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        /// <param name="alignment"></param>
        public static void drawTextInRect(Graphics g, string text, Font font, RectangleF rect, Color color, ContentAlignment alignment)
        {
            drawTextInRect(g, text, font, rect, color, alignment, false);
        }

        /// <summary>
        /// 在指定矩形区域内绘制文本
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        /// <param name="alignment"></param>
        /// <param name="right_to_left"></param>
        public static void drawTextInRect(Graphics g, string text, Font font, RectangleF rect, Color color, ContentAlignment alignment, bool right_to_left)
        {
            TextRenderer.DrawText(
                 g,
                 text,
                 font,
                new Rectangle(Convert.ToInt32(rect.X), Convert.ToInt32(rect.Y), Convert.ToInt32(rect.Width), Convert.ToInt32(rect.Height)),
                 color,
                 getTextFormatFlags(alignment, right_to_left));
        }

        /// <summary>
        /// 根据Alignment和RightToLeft的设置获取绘制Text的Flags
        /// </summary>
        /// <param name="alignment"></param>
        /// <param name="right_to_left"></param>
        /// <returns></returns>
        public static TextFormatFlags getTextFormatFlags(ContentAlignment alignment, bool right_to_left)
        {
            TextFormatFlags flags = TextFormatFlags.WordBreak |
                TextFormatFlags.SingleLine;
            if (right_to_left)
            {
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            }

            switch (alignment)
            {
                case ContentAlignment.BottomCenter:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleCenter:
                    flags |= TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleLeft:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                case ContentAlignment.MiddleRight:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.TopCenter:
                    flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopLeft:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
            }
            return flags;
        }

        /// <summary>
        /// 获取字体画信息
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public static FontMetrics getFontMetrics(
            Graphics graphics,
            Font font)
        {
            return FontMetricsImpl.GetFontMetrics(graphics, font);
        }
        private class FontMetricsImpl : FontMetrics
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct TEXTMETRIC
            {
                public int tmHeight;
                public int tmAscent;
                public int tmDescent;
                public int tmInternalLeading;
                public int tmExternalLeading;
                public int tmAveCharWidth;
                public int tmMaxCharWidth;
                public int tmWeight;
                public int tmOverhang;
                public int tmDigitizedAspectX;
                public int tmDigitizedAspectY;
                public char tmFirstChar;
                public char tmLastChar;
                public char tmDefaultChar;
                public char tmBreakChar;
                public byte tmItalic;
                public byte tmUnderlined;
                public byte tmStruckOut;
                public byte tmPitchAndFamily;
                public byte tmCharSet;
            }
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern bool GetTextMetrics(IntPtr hdc, out TEXTMETRIC lptm);
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern bool DeleteObject(IntPtr hdc);
            private TEXTMETRIC GenerateTextMetrics(
                Graphics graphics,
                Font font)
            {
                IntPtr hDC = IntPtr.Zero;
                TEXTMETRIC textMetric;
                IntPtr hFont = IntPtr.Zero;
                try
                {
                    hDC = graphics.GetHdc();
                    hFont = font.ToHfont();
                    IntPtr hFontDefault = SelectObject(hDC, hFont);
                    bool result = GetTextMetrics(hDC, out textMetric);
                    SelectObject(hDC, hFontDefault);
                }
                finally
                {
                    if (hFont != IntPtr.Zero) DeleteObject(hFont);
                    if (hDC != IntPtr.Zero) graphics.ReleaseHdc(hDC);
                }
                return textMetric;
            }
            private TEXTMETRIC metrics;
            public override int Height { get { return this.metrics.tmHeight; } }
            public override int Ascent { get { return this.metrics.tmAscent; } }
            public override int Descent { get { return this.metrics.tmDescent; } }
            public override int InternalLeading { get { return this.metrics.tmInternalLeading; } }
            public override int ExternalLeading { get { return this.metrics.tmExternalLeading; } }
            public override int AverageCharacterWidth { get { return this.metrics.tmAveCharWidth; } }
            public override int MaximumCharacterWidth { get { return this.metrics.tmMaxCharWidth; } }
            public override int Weight { get { return this.metrics.tmWeight; } }
            public override int Overhang { get { return this.metrics.tmOverhang; } }
            public override int DigitizedAspectX { get { return this.metrics.tmDigitizedAspectX; } }
            public override int DigitizedAspectY { get { return this.metrics.tmDigitizedAspectY; } }
            private FontMetricsImpl(Graphics graphics, Font font)
            {
                this.metrics = this.GenerateTextMetrics(graphics, font);
            }
            public static FontMetrics GetFontMetrics(
                Graphics graphics,
                Font font)
            {
                return new FontMetricsImpl(graphics, font);
            }
        }
    }
}