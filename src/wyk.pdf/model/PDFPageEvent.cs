using iTextSharp.text;
using iTextSharp.text.pdf;
using wyk.basic;

namespace wyk.pdf
{
    /// <summary>
    /// 通用页面事件
    /// </summary>
    public class PDFPageEvent : IPdfPageEvent
    {
        public PDFUnit unit;

        public PDFPageEvent(PDFUnit Unit)
        {
            unit = Unit;
        }

        /// <summary>
        /// 每页开始时调用
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="document"></param>
        public virtual void OnStartPage(PdfWriter writer, Document document)
        {
            unit.contentUnder.BeginText();
            unit.contentUnder.SetFontAndSize(BaseFont.CreateFont(), 11);
            unit.contentUnder.ShowText(" ");
            unit.contentUnder.EndText();
        }

        /// <summary>
        /// 每页结束时调用
        /// 注: 页面元素添加时尽量写在此方法内, 因为在Document创建时已经走过第一页的OnStartPage, 
        ///     如果写在OnStartPage的话, 第一页只会走默认设置的内容, 不会走后面代码修改过的内容, 例
        ///     如设置背景图片, 如果写在OnStartPage里面, 第一页只会走默认设置的background_image = null,
        ///     不会走后设置的任何image
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="document"></param>
        public virtual void OnEndPage(PdfWriter writer, Document document)
        {
            if (unit.hide_all_ui_on_page)
                return;
            int page_number = writer.PageNumber;
            //页码
            if (unit.page_number != null && unit.page_number.show_page_number && page_number > unit.page_number.skip_page_count)
            {
                if (unit.page_number.show_on_extra_page || !unit.on_extra_page)
                {
                    float page_number_y = unit.Height - unit.page_padding.bottom + unit.footer.pre_space + unit.page_number.start_space;
                    string text = unit.page_number.format.Replace("{P}", writer.PageNumber.ToString());
                    System.Drawing.PointF start = new System.Drawing.PointF(unit.page_size.size.Width / 2, page_number_y);
                    unit.addText(text, unit.page_number.Font.font, unit.page_number.Font.color, start);
                }
            }
            //页眉
            if (unit.header != null && page_number > unit.header.skip_page_count)
            {
                if (unit.header.show_on_extra_page || !unit.on_extra_page)
                {
                    System.Drawing.PointF start = new System.Drawing.PointF(unit.page_padding.left, unit.page_padding.top - unit.header.pre_space);
                    if (unit.header.show_seperator)
                    {
                        unit.addLine(unit.header.SeperatorColor, Align4Direction.Right, start, unit.ContentWidth, unit.header.seperator_width);
                        start.Y -= unit.header.seperator_width;
                    }
                    start.Y -= unit.header.post_space;
                    HeaderFooterUnit.drawContent(unit.header, unit, start.Y, true, page_number);
                }
            }
            //页脚
            if (unit.footer != null && page_number > unit.footer.skip_page_count)
            {
                if (unit.footer.show_on_extra_page || !unit.on_extra_page)
                {
                    System.Drawing.PointF start = new System.Drawing.PointF(unit.page_padding.left, unit.Height - unit.page_padding.bottom + unit.footer.pre_space);
                    if (unit.footer.show_seperator)
                    {
                        unit.addLine(unit.footer.SeperatorColor, Align4Direction.Right, start, unit.ContentWidth, unit.footer.seperator_width);
                        start.Y += unit.footer.seperator_width;
                    }
                    start.Y += unit.footer.post_space;
                    HeaderFooterUnit.drawContent(unit.footer, unit, start.Y, false, page_number);
                }
            }
            //背景
            if (unit.background_image != null)
                unit.addBackgroundImage(unit.background_image);
            //内容页页面元素
            if (!unit.on_extra_page && unit.content_page_items != null && unit.content_page_items.Count > 0)
            {
                foreach (var item in unit.content_page_items)
                {
                    unit.drawPageItem(item, page_number);
                }
            }
        }

        /// <summary>
        /// 文档打开时调用
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="document"></param>
        public virtual void OnOpenDocument(PdfWriter writer, Document document)
        {

        }

        /// <summary>
        /// 文档关闭时调用
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="document"></param>
        public virtual void OnCloseDocument(PdfWriter writer, Document document)
        {

        }

        public virtual void OnParagraph(PdfWriter writer, Document document, float paragraphPosition)
        {

        }

        public virtual void OnParagraphEnd(PdfWriter writer, Document document, float paragraphPosition)
        {

        }

        public virtual void OnSection(PdfWriter writer, Document document, float paragraphPosition, int depth, Paragraph title)
        {

        }
        public virtual void OnSectionEnd(PdfWriter writer, Document document, float paragraphPosition)
        {

        }

        public virtual void OnGenericTag(PdfWriter writer, Document document, Rectangle rect, string text)
        {

        }

        public virtual void OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title)
        {

        }

        public virtual void OnChapterEnd(PdfWriter writer, Document document, float paragraphPosition)
        {

        }
    }
}
