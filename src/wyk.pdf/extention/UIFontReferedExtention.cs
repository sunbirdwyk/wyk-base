using iTextSharp.text;
using wyk.basic;

namespace wyk.pdf
{
    public static class UIFontReferedExtention
    {
        public static Font pdfFont(this UIFont font)
        {
            return PDFFontUtil.instance(font);
        }
    }
}
