using iTextSharp.text;
using wyk.basic;

namespace wyk.pdf
{
    public class PDFCellUIConfig
    {
        public Font font = PDFFontUtil.instance(9);
        public BaseColor bg_color = BaseColor.White;
        public BaseColor border_color = null;
        public float border_width = PdfPCellUnit.DEFAULT_BORDER_WIDTH;
        public int vertical_align = Element.ALIGN_MIDDLE;
        public int horizontal_align = Element.ALIGN_LEFT;
        public UIPadding padding = UIPadding.instanceByPt(5);
        public float leading = 1f;

        public void setHorizontalAlign(AlignHorizontal align)
        {
            switch (align)
            {
                case AlignHorizontal.Left:
                default:
                    horizontal_align = Element.ALIGN_LEFT;
                    break;
                case AlignHorizontal.Center:
                    horizontal_align = Element.ALIGN_CENTER;
                    break;
                case AlignHorizontal.Right:
                    horizontal_align = Element.ALIGN_RIGHT;
                    break;
            }
        }

        public void setVerticalAlign(AlignVertical align)
        {
            switch (align)
            {
                case AlignVertical.Middle:
                default:
                    vertical_align = Element.ALIGN_MIDDLE;
                    break;
                case AlignVertical.Top:
                    vertical_align = Element.ALIGN_TOP;
                    break;
                case AlignVertical.Bottom:
                    vertical_align = Element.ALIGN_BOTTOM;
                    break;
            }
        }
    }
}
