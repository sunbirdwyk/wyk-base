using System.Drawing;

namespace wyk.pdf
{
    public static class ColorReferedExtention
    {
        public static iTextSharp.text.BaseColor baseColor(this Color color)
        {
            if (color == Color.Transparent)
                return null;
            return new iTextSharp.text.BaseColor(color);
        }
    }
}
