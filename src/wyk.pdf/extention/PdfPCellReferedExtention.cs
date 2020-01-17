using iTextSharp.text;
using iTextSharp.text.pdf;
using wyk.basic;

namespace wyk.pdf
{
    public static class PdfPCellReferedExtention
    {
        /// <summary>
        /// 设置无边框
        /// </summary>
        /// <param name="cell"></param>
        public static void setNoBorder(this PdfPCell cell)
        {
            cell.Border = Rectangle.NO_BORDER;
            cell.BorderWidth = 0;
        }

        /// <summary>
        /// 设置边框
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="color"></param>
        /// <param name="width"></param>
        public static void setBorder(this PdfPCell cell, System.Drawing.Color color, float width)
        {
            cell.setBorder(color.baseColor(), width);
        }

        /// <summary>
        /// 设置边框
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="color"></param>
        /// <param name="width"></param>
        public static void setBorder(this PdfPCell cell, BaseColor color, float width)
        {
            if (width == 0 || color == null)
            {
                cell.setNoBorder();
                return;
            }
            cell.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
            cell.BorderWidth = width;
            cell.BorderColor = color;
        }

        /// <summary>
        /// 设置边框
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="color"></param>
        public static void setBorder(this PdfPCell cell, System.Drawing.Color color)
        {
            cell.setBorder(color, PdfPCellUnit.DEFAULT_BORDER_WIDTH);
        }

        /// <summary>
        /// 设置边框
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="color"></param>
        public static void setBorder(this PdfPCell cell, BaseColor color)
        {
            cell.setBorder(color, PdfPCellUnit.DEFAULT_BORDER_WIDTH);
        }
        /// <summary>
        /// 设置padding
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="padding"></param>
        public static void setPadding(this PdfPCell cell, UIPadding padding)
        {
            cell.PaddingLeft = padding.left_pt;
            cell.PaddingRight = padding.right_pt;
            cell.PaddingBottom = padding.bottom_pt;
            cell.PaddingTop = padding.top_pt;
        }

        /// <summary>
        /// 设置padding(全部)
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="all_padding"></param>
        public static void setPadding(this PdfPCell cell, float all_padding)
        {
            cell.PaddingLeft = all_padding;
            cell.PaddingRight = all_padding;
            cell.PaddingBottom = all_padding;
            cell.PaddingTop = all_padding;
        }

        /// <summary>
        /// 设置垂直对齐方式
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="align"></param>
        public static void setVerticalAlign(this PdfPCell cell, AlignVertical align)
        {
            switch (align)
            {
                case AlignVertical.Middle:
                default:
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    break;
                case AlignVertical.Top:
                    cell.VerticalAlignment = Element.ALIGN_TOP;
                    break;
                case AlignVertical.Bottom:
                    cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                    break;
            }
        }

        /// <summary>
        /// 设置水平对齐方式
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="align"></param>
        public static void setHorizontalAlign(this PdfPCell cell, AlignHorizontal align)
        {
            switch (align)
            {
                case AlignHorizontal.Left:
                default:
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
                case AlignHorizontal.Center:
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case AlignHorizontal.Right:
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
            }
        }
    }
}