using System.Drawing;

namespace wyk.basic
{
    public static class GraphicsReferedExtentionFW
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
        public static void drawTextInRect(this Graphics g, Rectangle rect, string text, Font font, Color color, ContentAlignment alignment)
        {
            GraphicsUtilFW.drawTextInRect(g, text, font, rect, color, alignment);
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
        public static void drawTextInRect(this Graphics g, Rectangle rect, string text, Font font, Color color, ContentAlignment alignment, bool right_to_left)
        {
            GraphicsUtilFW.drawTextInRect(g, text, font, rect, color, alignment, right_to_left);
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
        public static void drawTextInRect(this Graphics g, RectangleF rect, string text, Font font, Color color, ContentAlignment alignment)
        {
            GraphicsUtilFW.drawTextInRect(g, text, font, rect, color, alignment);
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
        public static void drawTextInRect(this Graphics g, RectangleF rect, string text, Font font, Color color, ContentAlignment alignment, bool right_to_left)
        {
            GraphicsUtilFW.drawTextInRect(g, text, font, rect, color, alignment, right_to_left);
        }
    }
}
