using iTextSharp.text.pdf;
using System;
using System.Drawing;
using wyk.basic;

namespace wyk.pdf
{
    public class BarcodeUtil
    {
        /// <summary>
        /// 获取条码图片
        /// </summary>
        /// <param name="content">条码配置和内容</param>
        /// <returns></returns>
        public static Image getBarcode(BarcodeContent content)
        {
            return getBarcode(content.content, content.Type, content.height, content.unit, content.BarColor, content.BackColor);
        }

        /// <summary>
        /// 获取条码图片(黑白)
        /// </summary>
        /// <param name="content">条码内容</param>
        /// <param name="type">编码类型</param>
        /// <param name="height">高度(磅)</param>
        /// <param name="unit">单位宽度(磅)</param>
        /// <returns></returns>
        public static Image getBarcode(string content, string type, float height, float unit)
        {
            return getBarcode(content, type.enumFromName<BarcodeType>(), height, unit, Color.Black, Color.White);
        }

        /// <summary>
        /// 获取条码图片
        /// </summary>
        /// <param name="content">条码内容</param>
        /// <param name="type">编码类型</param>
        /// <param name="height">高度(磅)</param>
        /// <param name="unit">单位宽度(磅)</param>
        /// <param name="fore">前景色/条码颜色</param>
        /// <param name="back">背景色</param>
        /// <returns>条码Image</returns>
        public static Image getBarcode(string content, BarcodeType type, float height, float unit, Color fore, Color back)
        {
            if (content.isNull())
                content = "1234567";
            try
            {
                var test = Convert.ToInt64(content);
                if (test < 0)
                    content = "1234567";
            }
            catch { content = "1234567"; }
            Image img = null;
            if (fore.A == 0)
                fore = Color.Black;
            if (back.A == 0)
                back = Color.White;
            try
            {
                switch (type)
                {
                    case BarcodeType.Code39:
                    default:
                        Barcode39 code39 = new Barcode39();
                        code39.BarHeight = height;
                        code39.Code = content;
                        if (unit > 0)
                            code39.N = unit;
                        img = code39.CreateDrawingImage(fore, back);
                        break;
                    case BarcodeType.Code128:
                        Barcode128 code128 = new Barcode128();
                        code128.BarHeight = height;
                        code128.Code = content;
                        if (unit > 0)
                            code128.N = unit;
                        code128.CodeType = Barcode.CODE128;
                        img = code128.CreateDrawingImage(fore, back);
                        break;
                    case BarcodeType.Inter25:
                        BarcodeInter25 codeInter25 = new BarcodeInter25();
                        codeInter25.BarHeight = height;
                        codeInter25.Code = content;
                        if (unit > 0)
                            codeInter25.N = unit;
                        img = codeInter25.CreateDrawingImage(fore, back);
                        break;
                    case BarcodeType.Postnet:
                        BarcodePostnet codePostnet = new BarcodePostnet();
                        codePostnet.BarHeight = height;
                        codePostnet.Code = content;
                        if (unit > 0)
                            codePostnet.N = unit;
                        img = codePostnet.CreateDrawingImage(fore, back);
                        break;
                    case BarcodeType.CodeBar:
                        BarcodeCodabar codeCodeBar = new BarcodeCodabar();
                        codeCodeBar.BarHeight = height;
                        codeCodeBar.Code = "A" + content + "A";
                        if (unit > 0)
                            codeCodeBar.N = unit;
                        img = codeCodeBar.CreateDrawingImage(fore, back);
                        break;
                }
            }
            catch { }
            return img;
        }
    }
}
