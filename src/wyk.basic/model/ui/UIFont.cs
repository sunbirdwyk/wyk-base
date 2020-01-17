using Newtonsoft.Json;
using System;
using System.Drawing;

namespace wyk.basic
{
    public class UIFont
    {
        public Font font = new Font("微软雅黑", 9, FontStyle.Regular);
        public Color color = Color.Black;
        [JsonIgnore]
        public AlignHorizontal align = AlignHorizontal.Left;

        public int align_int
        {
            get
            {
                switch (align)
                {
                    case AlignHorizontal.Left:
                    default:
                        return -1;
                    case AlignHorizontal.Center:
                        return 0;
                    case AlignHorizontal.Right:
                        return 1;
                }
            }
            set
            {
                switch (value)
                {
                    case -1:
                        align = AlignHorizontal.Left;
                        break;
                    case 0:
                        align = AlignHorizontal.Center;
                        break;
                    case 1:
                        align = AlignHorizontal.Right;
                        break;
                    default:
                        if (value < 0)
                            align = AlignHorizontal.Left;
                        else
                            align = AlignHorizontal.Right;
                        break;
                }
            }
        }

        [JsonIgnore]
        public string FontDisplay
        {
            get => font.Name + "," + font.Size + "," + (font.Style == FontStyle.Bold ? "Bold" : "Regular");
            set
            {
                var parts = value.Split(',');
                var name = parts[0];
                if (name.isNull())
                    name = "宋体";
                float size = 9;
                try
                {
                    size = (float)Convert.ToDouble(parts[1]);
                    if (size <= 0)
                        size = 9;
                }
                catch { }
                var bold = false;
                try
                {
                    switch (parts[2].ToLower())
                    {
                        case "1":
                        case "bold":
                        case "on":
                        case "true":
                            bold = true;
                            break;
                        default:
                            bold = false;
                            break;
                    }
                }
                catch { }
                font = new Font(name, size, bold ? FontStyle.Bold : FontStyle.Regular);
            }
        }
        public UIFont() { }
        public UIFont(string font_family, float size,FontStyle style,Color color, AlignHorizontal align)
        {
            font = new Font(font_family, size, style);
            this.color = color;
            this.align = align;
        }

        public UIFont(Font font,Color color,AlignHorizontal align)
        {
            this.font = font;
            this.color = color;
            this.align = align;
        }

        public UIFont(string content)
        {
            this.content = content;
        }

        [JsonIgnore]
        public string content
        {
            get => font.Name + "," + font.Size + "," + (font.Style == FontStyle.Bold ? "1" : "0") + "," + color.hexString() + "," + align_int;
            set
            {
                var parts = value.Split(',');
                float size = 9;
                try
                {
                    size = (float)Convert.ToDouble(parts[1]);
                }
                catch { }
                if (size <= 0)
                    size = 9;
                FontStyle style = FontStyle.Regular;
                try
                {
                    if (parts[2].Trim() == "1" || parts[2].Trim().ToLower() == "true")
                        style = FontStyle.Bold;
                }
                catch { }
                try
                {
                    font = new Font(parts[0], size, style);
                }
                catch { font = new Font("微软雅黑", size, style); }
                try
                {
                    color = parts[3].color();
                }
                catch { color = Color.Black; }
                try
                {
                    align_int = Convert.ToInt32(parts[4]);
                }
                catch { align = AlignHorizontal.Left; }
            }
        }
    }
}
