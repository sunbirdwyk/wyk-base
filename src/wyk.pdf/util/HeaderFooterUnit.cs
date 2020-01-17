using System.Drawing;
using wyk.basic;

namespace wyk.pdf
{
    /// <summary>
    /// 页眉页脚内容
    /// </summary>
    public class HeaderFooterUnit
    {
        /// <summary>
        /// 为PDF画一行内容
        /// </summary>
        /// <param name="headerfooter">页眉/页脚</param>
        /// <param name="line_number">行号, 起始1, 不能超过10</param>
        /// <param name="unit"></param>
        /// <param name="start_y">起始坐标Y(左上角原点,单位mm)</param>
        /// <param name="page_number">当前页码, 用于兼容之前版本设置</param>
        /// <returns>当前行的字体, 通常用于计算下一行高度</returns>
        public static Font drawContentLine(UIHeaderFooter headerfooter, int line_number, PDFUnit unit, float start_y, int page_number)
        {
            UIFont font;
            try
            {
                font = headerfooter.content_font_list[line_number - 1];
            }
            catch { font = new UIFont("微软雅黑", 9, FontStyle.Regular, Color.LightGray, AlignHorizontal.Left); }
            string text = "";
            try
            {
                text = headerfooter.content_list[line_number - 1];
            }
            catch { return font.font; }
            if (text.isNull())
                return font.font;
            text = text.Replace("{页码}", page_number.ToString());
            PointF start;
            switch (font.align)
            {
                case AlignHorizontal.Left:
                default:
                    start = new PointF(unit.page_padding.left, start_y);
                    break;
                case AlignHorizontal.Center:
                    start = new PointF(unit.Width / 2, start_y);
                    break;
                case AlignHorizontal.Right:
                    start = new PointF(unit.Width - unit.page_padding.right, start_y);
                    break;
            }
            unit.addText(text, font.font, font.color, start, font.align);
            return font.font;
        }

        /// <summary>
        /// 为PDF画全部内容
        /// </summary>
        /// <param name="headerfooter">页眉/页脚</param>
        /// <param name="unit"></param>
        /// <param name="start_y">起始坐标(左上角原点,单位mm), Header为左下角坐标, Footer为左上角坐标</param>
        /// <param name="for_header">是否为Header, 否则为Footer</param>
        /// <param name="page_number">当前页码, 用于兼容之前版本设置</param>
        public static void drawContent(UIHeaderFooter headerfooter, PDFUnit unit, float start_y, bool for_header, int page_number)
        {
            float line_start = start_y;
            if (for_header)
            {
                for (int line = headerfooter.content_list.Count; line > 0; line--)
                {
                    UIFont font;
                    try
                    {
                        font = headerfooter.content_font_list[line - 1];
                    }
                    catch { font = new UIFont("微软雅黑", 9, FontStyle.Regular, Color.LightGray, AlignHorizontal.Left); }
                    line_start -= UIUtil.mmFromPt(font.font.Size);
                    drawContentLine(headerfooter, line, unit, line_start, page_number);
                    line_start -= headerfooter.line_space;
                }
            }
            else
            {
                for (int line = 1; line <= headerfooter.content_list.Count; line++)
                {
                    Font font = drawContentLine(headerfooter, line, unit, line_start, page_number);
                    line_start += UIUtil.mmFromPt(font.Size) + headerfooter.line_space;
                }
            }
        }
    }
}
