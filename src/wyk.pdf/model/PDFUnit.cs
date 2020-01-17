using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using wyk.basic;

namespace wyk.pdf
{
    /// <summary>
    /// 用于操作PDF读写的类
    /// </summary>
    public class PDFUnit : IDisposable
    {
        /***************************************
         * 注:PDF文件坐标原点为左下角, 而我们传入的坐标和方向的参考坐标原点为左上角, 请注意在绘图时的坐标转换
         ***************************************/
        public Document document = null;
        public PdfWriter writer = null;
        public string file_path = "";
        public PdfContentByte content = null;
        public PdfContentByte contentUnder = null;
        private PdfPTable _main_table = null;
        /// <summary>
        /// 当前unit状态, 可用于标记不同页面的内容状态, 通常用于决定在PageEvent的时候绘制什么样的内容
        /// </summary>
        public string current_status = "";
        /// <summary>
        /// 当前是否在附加页上, 此状态需要自行设置, 默认为否
        /// </summary>
        public bool on_extra_page = false;
        /// <summary>
        /// 当前是否隐藏(不绘制)此页面的所有元素(在PageEvent中)
        /// 开启此选项时, PageEvent中不会再绘制任何内容
        /// </summary>
        public bool hide_all_ui_on_page = false;
        /// <summary>
        /// 页面尺寸
        /// </summary>
        public UIPageSize page_size;

        /// <summary>
        /// 页面边距
        /// </summary>
        public UIPadding page_padding;

        /// <summary>
        /// 页码样式
        /// </summary>
        public UIPageNumber page_number = new UIPageNumber();

        /// <summary>
        /// 页眉内容和样式
        /// </summary>
        public UIHeaderFooter header = new UIHeaderFooter();
        /// <summary>
        /// 页脚内容和样式
        /// </summary>
        public UIHeaderFooter footer = new UIHeaderFooter();
        public List<UIPageItem> content_page_items = null;

        public System.Drawing.Image background_image = null;

        public System.Drawing.Color background_color
        {
            set => background_image = ImageUtil.imageWithColor(value);
        }

        public PdfPTable main_table
        {
            get
            {
                if (_main_table == null)
                {
                    _main_table = new PdfPTable(1);
                    _main_table.DefaultCell.Border = Rectangle.NO_BORDER;
                    _main_table.DefaultCell.BorderWidth = 0;
                }
                return _main_table;
            }
            set
            {
                if (_main_table != null)
                {
                    addTable(_main_table);
                }
                _main_table = value;
            }
        }

        /// <summary>
        /// 打开文档时的构造函数
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        PDFUnit(string FilePath)
        {
            file_path = FilePath;
            document = new Document();
            writer = PdfWriter.GetInstance(document, new FileStream(file_path, FileMode.Open));
            document.Open();
            page_size = PageSizeUnit.pageSizeByRectangle(document.PageSize);
            page_padding = UIPadding.instanceByPt(document.TopMargin, document.RightMargin, document.BottomMargin, document.LeftMargin);
            content = writer.DirectContent;
            contentUnder = writer.DirectContentUnder;
        }

        /// <summary>
        /// 新建文档时的构造函数
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="PageSize">页面尺寸</param>
        /// <param name="Padding">页面边距</param>
        PDFUnit(string FilePath, UIPageSize PageSize, UIPadding Padding)
        {
            file_path = FilePath;
            page_size = PageSize;
            page_padding = Padding;
            document = new Document(PageSizeUnit.rectangleByPageSize(PageSize), Padding.left_pt, Padding.right_pt, Padding.top_pt, Padding.bottom_pt);
            writer = PdfWriter.GetInstance(document, new FileStream(file_path, FileMode.Create));
            document.Open();
            content = writer.DirectContent;
            contentUnder = writer.DirectContentUnder;
            page_event = new PDFPageEvent(this);
        }

        /// <summary>
        /// 创建PDF文件, 文件存在时将会删除
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="PageSize">页面尺寸</param>
        /// <param name="Padding">页面边距</param>
        public static PDFUnit create(string FilePath, UIPageSize PageSize, UIPadding Padding)
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    File.Delete(FilePath);
                }
                catch { throw new Exception("文件已存在且正在被占用, 无法删除当前已存在的文件!"); }
            }
            PDFUnit unit = new PDFUnit(FilePath, PageSize, Padding);
            //unit.addText(" ", new System.Drawing.Font("宋体",9, System.Drawing.FontStyle.Regular), System.Drawing.Color.White, new System.Drawing.PointF(0, 0));
            return unit;
        }

        /// <summary>
        /// 创建PDF文件, A4, 边距 [60,40,60,40]pt
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        public static PDFUnit create(string FilePath)
        {
            return create(FilePath, PageSizeUnit.pageSizeByRectangle(PageSize.A4), UIPadding.instanceByPt(60, 40, 60, 40));
        }

        /// <summary>
        /// 创建PDF文件
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="PageSize">页面尺寸(Rectangle)</param>
        /// <param name="PaddingInPt">页面边距(Pt)</param>
        /// <returns></returns>
        public static PDFUnit create(string FilePath, Rectangle PageSize, float PaddingInPt)
        {
            return create(FilePath, PageSizeUnit.pageSizeByRectangle(PageSize), UIPadding.instanceByPt(PaddingInPt));
        }

        /// <summary>
        /// 创建PDF文件
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="PageSize">页面尺寸(Rectangle)</param>
        /// <param name="PaddingTopInPt">页面上边距(Pt)</param>
        /// <param name="PaddingRightInPt">页面右边距(Pt)</param>
        /// <param name="PaddingBottomInPt">页面下边距(Pt)</param>
        /// <param name="PaddingLeftInPt">页面左边距(Pt)</param>
        /// <returns></returns>
        public static PDFUnit create(string FilePath, Rectangle PageSize, float PaddingTopInPt, float PaddingRightInPt, float PaddingBottomInPt, float PaddingLeftInPt)
        {
            return create(FilePath, PageSizeUnit.pageSizeByRectangle(PageSize), UIPadding.instanceByPt(PaddingTopInPt, PaddingRightInPt, PaddingBottomInPt, PaddingLeftInPt));
        }

        /// <summary>
        /// 打开PDF文件
        /// </summary>
        /// <param name="FilePath"></param>
        public static PDFUnit open(string FilePath)
        {
            if (!File.Exists(FilePath))
                throw new Exception("文件不存在!");
            PDFUnit unit = new PDFUnit(FilePath);
            return unit;
        }

        /// <summary>
        /// 页面事件
        /// </summary>
        public PDFPageEvent page_event
        {
            get => writer.PageEvent as PDFPageEvent;
            set => writer.PageEvent = value;
        }

        #region 页面的部分快捷属性
        /// <summary>
        /// 页面左上角的点(mm,mm)
        /// </summary>
        public System.Drawing.PointF TopLeftPoint
        {
            get { return new System.Drawing.PointF(page_padding.left, page_padding.top); }
        }

        /// <summary>
        /// 页面右上角的点(mm,mm)
        /// </summary>
        public System.Drawing.PointF TopRightPoint
        {
            get { return new System.Drawing.PointF(Width - page_padding.right, page_padding.top); }
        }

        /// <summary>
        /// 页面左下角的点(mm,mm)
        /// </summary>
        public System.Drawing.PointF BottomLeftPoint
        {
            get { return new System.Drawing.PointF(page_padding.left, Height - page_padding.bottom); }
        }

        /// <summary>
        /// 页面右下角的点(mm,mm)
        /// </summary>
        public System.Drawing.PointF BottomRightPoint
        {
            get { return new System.Drawing.PointF(Width - page_padding.right, Height - page_padding.bottom); }
        }

        /// <summary>
        /// 页面宽度(mm)
        /// </summary>
        public float Width
        {
            get { return page_size.size.Width; }
        }

        /// <summary>
        /// 页面高度(mm)
        /// </summary>
        public float Height
        {
            get { return page_size.size.Height; }
        }

        /// <summary>
        /// 内容区域宽度(mm)
        /// </summary>
        public float ContentWidth
        {
            get { return Width - page_padding.left - page_padding.right; }
        }

        /// <summary>
        /// 内容区域高度(mm)
        /// </summary>
        public float ContentHeight
        {
            get { return Height - page_padding.top - page_padding.bottom; }
        }

        /// <summary>
        /// 页面宽度(pt)
        /// </summary>
        public float WidthInPt
        {
            get { return page_size.size_pt.Width; }
        }

        /// <summary>
        /// 页面高度(pt)
        /// </summary>
        public float HeightInPt
        {
            get { return page_size.size_pt.Height; }
        }
        #endregion

        /// <summary>
        /// 新起一页
        /// </summary>
        public void newPage()
        {
            try
            {
                document.NewPage();
            }
            catch { }
        }

        public void addMainTable()
        {
            if (_main_table != null)
            {
                try
                {
                    addTable(_main_table);
                    _main_table = null;
                }
                catch { }
            }
        }

        /// <summary>
        /// 关闭文档
        /// </summary>
        public void close()
        {
            addMainTable();
            try
            {
                document.Close();
            }
            catch { }
            document = null;
            writer = null;
            content = null;
            contentUnder = null;
        }

        /// <summary>
        /// 将table加入主页面
        /// </summary>
        /// <param name="table"></param>
        public void addTable(PdfPTable table)
        {
            if (table == null)
                return;
            table.WidthPercentage = 100;
            document.Add(table);
        }

        /// <summary>
        /// 为当前页添加背景图片
        /// </summary>
        /// <param name="image"></param>
        public void addBackgroundImage(System.Drawing.Image image)
        {
            if (image == null)
                return;
            Image img = Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Bmp);
            contentUnder.MoveTo(0, 0);
            img.SetAbsolutePosition(0, 0);
            System.Drawing.SizeF size_in_pt = page_size.size_pt;
            img.ScaleAbsoluteHeight(size_in_pt.Height);
            img.ScaleAbsoluteWidth(size_in_pt.Width);
            contentUnder.AddImage(img);
        }

        /// <summary>
        /// 为当前页添加图片, 大小为图片原始大小
        /// </summary>
        /// <param name="image"></param>
        /// <param name="location">图片起始点(mm), 注意:起始点的x,y不包含margin-left和top</param>
        public void addImage(System.Drawing.Image image, System.Drawing.PointF location)
        {
            if (image == null)
                return;
            System.Drawing.SizeF size = new System.Drawing.SizeF(UIUtil.mmFromPx(image.Width), UIUtil.mmFromPx(image.Height));
            addImage(image, location, size);
        }

        /// <summary>
        /// 为当前页添加图片
        /// </summary>
        /// <param name="image"></param>
        /// <param name="location">图片起始点(mm), 注意:起始点的x,y不包含margin-left和top</param>
        /// <param name="size">图片大小</param>
        public void addImage(System.Drawing.Image image, System.Drawing.PointF location, System.Drawing.SizeF size)
        {
            if (image == null)
                return;
            try
            {
                Image img = Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Bmp);
                //先以左上角为原点计算坐标
                float x = UIUtil.ptFromMM(location.X);
                float y = UIUtil.ptFromMM(location.Y);
                float width = UIUtil.ptFromMM(size.Width);
                float height = UIUtil.ptFromMM(size.Height);
                //转换为左下角原点的y值
                y = HeightInPt - y - height;
                content.MoveTo(x, y);
                img.SetAbsolutePosition(x, y);
                img.ScaleAbsoluteWidth(width);
                img.ScaleAbsoluteHeight(height);
                content.AddImage(img);
            }
            catch { }
        }

        /// <summary>
        /// 添加线条, 默认宽度(0.1)
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="direction">方向</param>
        /// <param name="start">起点(mm,mm)</param>
        /// <param name="length">长度(mm)</param>
        public void addLine(System.Drawing.Color color, Align4Direction direction, System.Drawing.PointF start, float length)
        {
            addLine(color, direction, start, length, 0.1f);
        }

        /// <summary>
        /// 添加线条
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="direction">方向</param>
        /// <param name="start">起点(mm,mm)</param>
        /// <param name="length">长度(mm)</param>
        /// <param name="width">线宽(mm)</param>
        public void addLine(System.Drawing.Color color, Align4Direction direction, System.Drawing.PointF start, float length, float width)
        {
            if (length <= 0 || width <= 0)
                return;
            try
            {
                //根据不同的Direction设置rectangle的属性(初始以mm为单位计算)
                float x = 0;
                float y = 0;
                float w = 0;
                float h = 0;
                //先以左上角为原点计算坐标
                switch (direction)
                {
                    case Align4Direction.Top:
                        x = start.X - width / 2;
                        y = start.Y - length;
                        w = width;
                        h = length;
                        break;
                    case Align4Direction.Right:
                        x = start.X;
                        y = start.Y - width / 2;
                        w = length;
                        h = width;
                        break;
                    case Align4Direction.Left:
                        x = start.X - length;
                        y = start.Y - width / 2;
                        w = length;
                        h = width;
                        break;
                    case Align4Direction.Bottom:
                        x = start.X - width / 2;
                        y = start.Y;
                        w = width;
                        h = length;
                        break;
                }
                //mm转为pt
                x = UIUtil.ptFromMM(x);
                y = UIUtil.ptFromMM(y);
                w = UIUtil.ptFromMM(w);
                h = UIUtil.ptFromMM(h);
                //转换为左下角原点的y值
                y = HeightInPt - y - h;
                //画Rectangle
                content.Rectangle(x, y, w, h);
                content.SetColorFill(new BaseColor(color));
                content.Fill();
                content.Stroke();
            }
            catch { }
        }

        /// <summary>
        /// 绘制矩形, 只有边框, 不填充内部
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="start">起点(mm,mm)</param>
        /// <param name="width">宽度(mm)</param>
        /// <param name="height">高度(mm)</param>
        /// <param name="line_width">线宽(mm)</param>
        public void drawRectangle(System.Drawing.Color color, System.Drawing.PointF start, float width, float height, float line_width)
        {
            if (width <= 0 || height <= 0 || line_width <= 0)
                return;
            addLine(color, Align4Direction.Right, start, width, line_width);
            addLine(color, Align4Direction.Bottom, start, height, line_width);
            start.X += width;
            start.Y += height;
            addLine(color, Align4Direction.Top, start, height, line_width);
            addLine(color, Align4Direction.Left, start, width, line_width);
        }

        /// <summary>
        /// 填充矩形
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="start">起点(mm,mm)</param>
        /// <param name="width">宽度(mm)</param>
        /// <param name="height">高度(mm)</param>
        public void fillRectangle(System.Drawing.Color color, System.Drawing.PointF start, float width, float height)
        {
            if (width <= 0 || height <= 0)
                return;
            try
            {
                float x = start.X;
                float y = start.Y - height / 2;
                float w = width;
                float h = height;
                //mm转为pt
                x = UIUtil.ptFromMM(x);
                y = UIUtil.ptFromMM(y);
                w = UIUtil.ptFromMM(w);
                h = UIUtil.ptFromMM(h);
                //转换为左下角原点的y值
                y = HeightInPt - y - h;
                //画Rectangle
                content.Rectangle(x, y, w, h);
                content.SetColorFill(new BaseColor(color));
                content.Fill();
                content.Stroke();
            }
            catch { }
        }

        /// <summary>
        /// 添加文本, 默认左对齐
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <param name="font">字体</param>
        /// <param name="color">颜色</param>
        /// <param name="start">起始点(mm,mm)</param>
        public void addText(string text, System.Drawing.Font font, System.Drawing.Color color, System.Drawing.PointF start)
        {
            addText(text, font, color, start, AlignHorizontal.Left);
        }

        /// <summary>
        /// 添加文本
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <param name="font">字体</param>
        /// <param name="color">颜色</param>
        /// <param name="start">起始点(mm,mm)</param>
        /// <param name="alignment">对齐方式(如左对齐, 起始点为左上角, 如右对齐, 起始点为右上角, 如居中,起始点为文字中心线最上点)</param>
        public void addText(string text, System.Drawing.Font font, System.Drawing.Color color, System.Drawing.PointF start, AlignHorizontal alignment)
        {
            if (text.isNull())
                return;
            try
            {
                BaseFont txt_font = PDFFontUtil.baseFontByName(font.Name);
                BaseColor txt_color = new BaseColor(color);
                content.BeginText();
                content.SetFontAndSize(txt_font, font.Size);
                content.SetColorFill(txt_color);
                content.SetColorStroke(txt_color);
                if (font.Bold)
                    content.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);
                else
                    content.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                //先以左上角为原点计算坐标
                float x = UIUtil.ptFromMM(start.X);
                float y = UIUtil.ptFromMM(start.Y);
                int pdf_align = PdfContentByte.ALIGN_LEFT;
                switch (alignment)
                {
                    case AlignHorizontal.Left:
                    default:
                        pdf_align = PdfContentByte.ALIGN_LEFT;
                        break;
                    case AlignHorizontal.Center:
                        pdf_align = PdfContentByte.ALIGN_CENTER;
                        break;
                    case AlignHorizontal.Right:
                        pdf_align = PdfContentByte.ALIGN_RIGHT;
                        break;
                }

                if (text.IndexOf("\n") < 0)//单行文字
                {
                    //转换为左下角原点的y值
                    //注:实测画出的字体大小比实际font.size会大一点, 此处减字体高度时乘了一个0.95的系数用来调整高度使其看起来比较对齐
                    //TODO:当前未找到可以精确测量字体高度的方法, 待以后解决
                    float pdf_y = HeightInPt - y - font.Size * 0.95f;
                    content.ShowTextAligned(pdf_align, text, x, pdf_y, 0);
                }
                else //多行文字
                {
                    float line_space = 2;
                    string[] texts = text.Replace("\r\n", "\n").Split('\n');
                    foreach (string t in texts)
                    {
                        //转换为左下角原点的y值
                        //注:实测画出的字体大小比实际font.size会大一点, 此处减字体高度时乘了一个0.95的系数用来调整高度使其看起来比较对齐
                        float pdf_y = HeightInPt - y - font.Size * 0.95f;
                        content.ShowTextAligned(pdf_align, t, x, pdf_y, 0);
                        y += font.Size + line_space;
                    }
                }
                content.EndText();
            }
            catch { }
        }

        /// <summary>
        /// 绘制页面元素
        /// </summary>
        /// <param name="item">页面元素</param>
        public void drawPageItem(UIPageItem item)
        {
            drawPageItem(item, 0);
        }

        /// <summary>
        /// 处理页码
        /// </summary>
        /// <param name="item"></param>
        /// <param name="page_number"></param>
        public void drawPageItem(UIPageItem item, int page_number)
        {
            switch (item.ItemType)
            {
                case UIPageItemType.Text:
                    var content = item.content;
                    if (page_number > 0)
                        content = item.content.Replace("{页码}", page_number.ToString());
                    addText(content, item.Font.font, item.Font.color, item.Bounds.location, item.Font.align);
                    break;
                case UIPageItemType.Rectangle:
                    if (item.is_solid)
                        fillRectangle(item.Font.color, item.Bounds.location, item.Bounds.width, item.Bounds.height);
                    else
                    {
                        var line_width = item.line_width;
                        if (line_width < 0.1)
                            line_width = 0.1f;
                        drawRectangle(item.Font.color, item.Bounds.location, item.Bounds.width, item.Bounds.height, line_width);
                    }
                    break;
                case UIPageItemType.Picture:
                    var pic = item.picture;
                    if (pic == null)
                        break;
                    var bg = item.is_bg_image;
                    if (bg)
                        addBackgroundImage(pic);
                    else
                        addImage(pic, item.Bounds.location, item.Bounds.size);
                    break;
                case UIPageItemType.BarCode:
                    if (item.content_image == null)
                        item.content_image = BarcodeUtil.getBarcode(item.barcode_content);
                    if (item.content_image != null)
                        addImage(item.content_image, item.Bounds.location);
                    break;
                case UIPageItemType.QRCode:
                    //由于QRCode的调用在另一个库中, 为了避免交叉引用, 这里只能判断是否已生成二维码图片, 如果已生成, 则添加到文档中
                    if (item.content_image != null)
                        addImage(item.content_image, item.Bounds.location);
                    break;
            }
        }

        /// <summary>
        /// 获取字符串所占宽度(pt)
        /// </summary>
        /// <param name="content"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public float measureWidth(string content, Font font)
        {
            var cb = writer.DirectContent;
            cb.SetFontAndSize(font.BaseFont, font.Size);
            return cb.GetEffectiveStringWidth(content, false);
        }

        public void Dispose()
        {
            close();
        }
    }
}