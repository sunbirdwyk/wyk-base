using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using wyk.basic;

namespace wyk.svg
{
    public class SvgUtil
    {
        private static Dictionary<string, Image> images = new Dictionary<string, Image>();
        private static Image null_image = null;
        public static string base_dictionary = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "SVG\\");

        public static Image svg(string name, Size size, Color color)
        {
            return svg(base_dictionary, name, size, color);
        }

        public static Image svg(string folder, string name, Size size, Color color)
        {
            var key = getKey(name,size,color);
            if (images.ContainsKey(key))
                return images[key];
            if (!folder.EndsWith("\\"))
                folder = string.Concat(folder, "\\");
            var svg_path = string.Concat(folder, name, ".svg");
            try
            {
                var svgDoc = SvgDocument.Open(svg_path);
                var c = new SvgColourServer(color);
                setColor(svgDoc, c);
                svgDoc.Width = size.Width;
                svgDoc.Height = size.Height;
                var image = svgDoc.Draw();
                images[key] = image;
                return image;
            }
            catch { }
            if (null_image == null)
                null_image = ImageUtil.imageWithColor(Color.Transparent, new Size(10, 10));
            return null_image;
        }

        public static Image svgByXml(string xml, string name, Size size, Color color)
        {
            var key = getKey(name, size, color);
            if (images.ContainsKey(key))
                return images[key];
            try
            {
                var xDoc = new XmlDocument();
                xDoc.LoadXml(xml);
                var svgDoc = SvgDocument.Open(xDoc);
                var c = new SvgColourServer(color);
                setColor(svgDoc, c);
                svgDoc.Width = size.Width;
                svgDoc.Height = size.Height;
                var image = svgDoc.Draw();
                images[key] = image;
                return image;
            }
            catch { }
            if (null_image == null)
                null_image = ImageUtil.imageWithColor(Color.Transparent, new Size(10, 10));
            return null_image;
        }


        private static void setColor(SvgElement svgEle, SvgColourServer color)
        {
            svgEle.Fill = color;
            foreach (SvgElement sub in svgEle.Children)
                setColor(sub, color);
        }

        private static string getKey(string name, Size size, Color color)
        {
            return string.Format("{0}|{1},{2}|{3}", name, size.Width, size.Height, color.hexString(false));
        }
    }
}