using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Globalization;
using System.IO;
using System.Xml;
using wyk.basic;

namespace wyk.pdf
{
    public class PDFFontUtil
    {
        /// <summary>
        /// 根据System.Drawing.Font 和 System.Drawing.Color 获取 Font
        /// </summary>
        /// <param name="font"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Font instance(System.Drawing.Font font, System.Drawing.Color color)
        {
            return new Font(baseFontByName(font.Name), font.Size, font.Bold ? Font.BOLD : Font.NORMAL, new BaseColor(color));
        }

        public static Font instance(string font_family, float size, bool bold, System.Drawing.Color color)
        {
            return new Font(baseFontByName(font_family), size, bold ? Font.BOLD : Font.NORMAL, new BaseColor(color));
        }

        public static Font instance(string font_family, float size, bool bold)
        {
            return instance(font_family, size, bold, System.Drawing.Color.Black);
        }

        public static Font instance(float size, bool bold)
        {
            return instance("宋体", size, bold);
        }

        public static Font instance(float size)
        {
            return instance(size, false);
        }

        public static Font instance(UIFont uifont)
        {
            return instance(uifont.font, uifont.color);
        }

        /// <summary>
        /// 根据名称获取BaseFont
        /// </summary>
        /// <param name="font_name"></param>
        /// <returns></returns>
        public static BaseFont baseFontByName(string font_name)
        {
            BaseFont bf = null;
            try
            {
                string fontName = specialFontFileName(font_name);
                if (fontName == "")
                    fontName = new System.Drawing.FontFamily(font_name).GetName(CultureInfo.GetCultureInfo("en-us").LCID);
                string fontFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.System).Replace("system32", "Fonts");
                string fontPath = fontFolderPath + "\\" + fontName + ".TTF";
                if (!File.Exists(fontPath))
                    fontPath = fontFolderPath + "\\" + fontName + ".TTC,1";
                bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            }
            catch
            {
                try
                {
                    bf = BaseFont.CreateFont(Environment.GetFolderPath(Environment.SpecialFolder.System).Replace("system32", "Fonts") + "\\msyh.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                }
                catch { bf = BaseFont.CreateFont(); }
            }
            return bf;
        }

        /// <summary>
        /// 特定的字体库文件名
        /// </summary>
        /// <param name="font_name"></param>
        /// <returns></returns>
        public static string specialFontFileName(string font_name)
        {
            font_name = font_name.ToLower();
            string[,] FontNames = new string[,]{
                {"微软雅黑","MSYH"},
                {"雅黑","MSYH"},
                {"方正舒体","FZSTK"},
                {"方正姚体","FZYTK"},
                {"仿宋","simfang"},
                {"黑体","simhei"},
                {"华文彩云","STCAIYUN"},
                {"华文仿宋","STFANGSO"},
                {"华文行楷","STXINGKA"},
                {"华文细黑","STXIHEI"},
                {"华文新魏","STXINWEI"},
                {"华文中宋","STZHONGS"},
                {"华文琥珀","STHUPO"},
                {"华文楷体","STKAITI"},
                {"华文隶书","STLITI"},
                {"华文宋体","STSONG"},
                {"楷体","simkai"},
                {"隶书","SIMLI"},
                {"lisu","SIMLI"},
                {"宋体","simsun"},
                {"雅黑","SURSONG"},
                {"新宋体","simsun"},
                {"幼圆","SIMYOU"}
            };
            string res = "";
            for (int i = 0; i < FontNames.Length / 2; i++)
            {
                if (FontNames[i, 0] == font_name)
                    return FontNames[i, 1];
            }
            if (res == "")
            {
                try
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "PDFFontMap.xml");
                    XmlNodeList xnl = xDoc.SelectSingleNode("fonts").SelectNodes("font");
                    foreach (XmlNode xn in xnl)
                    {
                        if (xn.Attributes["name"].Value.ToLower() == font_name)
                        {
                            return xn.InnerText;
                        }
                    }
                }
                catch { }
            }
            if (res == "")
                res = "simsun";
            return res;
        }
    }
}
