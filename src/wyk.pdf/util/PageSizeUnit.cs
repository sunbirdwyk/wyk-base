using iTextSharp.text;
using wyk.basic;

namespace wyk.pdf
{
    public class PageSizeUnit
    {
        public static Rectangle rectangleByPageSize(UIPageSize page_size)
        {
            switch (page_size.name.ToUpper())
            {
                case "A0":
                    return PageSize.A0;
                case "A1":
                    return PageSize.A1;
                case "A2":
                    return PageSize.A2;
                case "A3":
                    return PageSize.A3;
                case "A4":
                    return PageSize.A4;
                case "A5":
                    return PageSize.A5;
                case "A6":
                    return PageSize.A6;
                case "A7":
                    return PageSize.A7;
                case "A8":
                    return PageSize.A8;
                case "B0":
                    return PageSize.B0;
                case "B1":
                    return PageSize.B1;
                case "B2":
                    return PageSize.B2;
                case "B3":
                    return PageSize.B3;
                case "B4":
                    return PageSize.B4;
                case "B5":
                    return PageSize.B5;
                case "B6":
                    return PageSize.B6;
                case "B7":
                    return PageSize.B7;
                case "B8":
                    return PageSize.B8;
                default:
                    return new Rectangle(UIUtil.ptFromMM(page_size.size.Width), UIUtil.ptFromMM(page_size.size.Height));
            }
        }
       
        public static UIPageSize pageSizeByRectangle(Rectangle rectangle)
        {
            return new UIPageSize(UIUtil.mmFromPt(rectangle.Width), UIUtil.mmFromPt(rectangle.Height));
        }
    }
}
