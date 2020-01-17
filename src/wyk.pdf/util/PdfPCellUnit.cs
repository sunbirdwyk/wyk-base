using iTextSharp.text;
using iTextSharp.text.pdf;
using wyk.basic;

namespace wyk.pdf
{
    public class PdfPCellUnit
    {
        public const float DEFAULT_BORDER_WIDTH = 0.3f;
        public const float DEFAULT_CELL_PADDING = 5f;

        public static PdfPCell instance()
        {
            var cell = new PdfPCell(new Paragraph(" "));
            cell.setNoBorder();
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.BackgroundColor = BaseColor.White;
            cell.setPadding(DEFAULT_CELL_PADDING);
            return cell;
        }

        public static PdfPCell instance(string content, UIFont font, System.Drawing.Color bg_color, System.Drawing.Color border_color, UIPadding padding)
        {
            if (content.isNull())
                content = " ";
            var cell = new PdfPCell(new Paragraph(content, font.pdfFont()));
            cell.setBorder(border_color);
            cell.setPadding(padding);
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = border_color.baseColor();
            cell.setHorizontalAlign(font.align);
            return cell;
        }

        public static PdfPCell instance(string content, PDFCellUIConfig config)
        {
            if (content.isNull())
                content = " ";
            var cell = new PdfPCell(new Paragraph(content, config.font));
            cell.setBorder(config.border_color, config.border_width);
            cell.setPadding(config.padding);
            cell.VerticalAlignment = config.vertical_align;
            cell.HorizontalAlignment = config.horizontal_align;
            cell.BackgroundColor = config.bg_color;
            if (config.leading != 1)
                cell.SetLeading(config.leading, config.leading);
            return cell;
        }

        public static PdfPCell instance(string content, float font_size, bool font_bold, UIPadding padding)
        {
            if (content.isNull())
                content = " ";
            var cell = new PdfPCell(new Paragraph(content, PDFFontUtil.instance(font_size, font_bold)));
            cell.setNoBorder();
            cell.setPadding(padding);
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.White;
            return cell;
        }

        public static PdfPCell instance(string content, float font_size, bool font_bold)
        {
            return instance(content, font_size, font_bold, UIPadding.instanceByPt(DEFAULT_CELL_PADDING));
        }

        public static PdfPCell instance(string content, float font_size)
        {
            return instance(content, font_size, false, UIPadding.instanceByPt(DEFAULT_CELL_PADDING));
        }

        public static PdfPCell instance(string content, Font font, UIPadding padding)
        {
            if (content.isNull())
                content = " ";
            var cell = new PdfPCell(new Paragraph(content, font));
            cell.setNoBorder();
            cell.setPadding(padding);
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.White;
            return cell;
        }

        public static PdfPCell instance(string content, Font font)
        {
            return instance(content, font, UIPadding.instanceByPt(DEFAULT_CELL_PADDING));
        }

        public static PdfPCell instance(Image image, AlignHorizontal align, UIPadding padding)
        {
            var cell = new PdfPCell(image);
            cell.setNoBorder();
            cell.setPadding(padding);
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.setHorizontalAlign(align);
            cell.BackgroundColor = BaseColor.White;
            return cell;
        }

        public static PdfPCell instance(Image image, UIPadding padding)
        {
            var cell = new PdfPCell(image);
            cell.setNoBorder();
            cell.setPadding(padding);
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = BaseColor.White;
            return cell;
        }

        public static PdfPCell instance(Image image)
        {
            var cell = new PdfPCell(image);
            cell.setNoBorder();
            cell.setPadding(UIPadding.instanceByPt(DEFAULT_CELL_PADDING));
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = BaseColor.White;
            return cell;
        }
    }
}