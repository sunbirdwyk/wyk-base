using System;
using System.Drawing;

namespace wyk.basic
{
    /// <summary>
    /// 颜色处理单元
    /// </summary>
    public class ColorUtil
    {
        /// <summary>
        /// 获取随机颜色,为避免颜色太浅或太深,指定颜色区间(50~200)
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static Color randomColor(int alpha, int seed)
        {
            return randomColor(50, 200, alpha, seed);
        }

        /// <summary>
        /// 获取随机颜色,为避免颜色太浅或太深,指定颜色区间(0~255)
        /// </summary>
        /// <param name="min">颜色区间最小值</param>
        /// <param name="max">颜色区间最大值</param>
        /// <param name="alpha"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static Color randomColor(int min, int max, int alpha, int seed)
        {
            Random ran = new Random(seed);
            return Color.FromArgb(alpha, ran.Next(max - min) + min, ran.Next(max - min) + min, ran.Next(max - min) + min);
        }

        /// <summary>
        /// 获取给定的颜色的ARGB的分量差值的颜色
        /// </summary>
        /// <param name="colorBase"></param>
        /// <param name="a">A</param>
        /// <param name="r">R</param>
        /// <param name="g">G</param>
        /// <param name="b">B</param>
        /// <returns></returns>
        public static Color colorWithOffset(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }

            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// 获取颜色名字,有名字则获取名字,无则获取#XXXXXX
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string stringForColor(Color color)
        {
            if (color.IsNamedColor)
            {
                return color.Name;
            }
            else
            {
                string r = color.R.ToString("X");
                string g = color.G.ToString("X");
                string b = color.B.ToString("X");
                while (r.Length < 2)
                    r = "0" + r;
                while (g.Length < 2)
                    g = "0" + g;
                while (b.Length < 2)
                    b = "0" + b;
                return "#" + r + g + b;
            }
        }

        /// <summary>
        /// 获取颜色名字
        /// </summary>
        /// <param name="inputColor">颜色</param>
        /// <param name="AllowName">是否允许名字,否则只返回#XXXXXX类型结果</param>
        /// <returns></returns>
        public static string stringForColor(Color inputColor, bool AllowName)
        {
            if (AllowName && inputColor.IsNamedColor)
            {
                return inputColor.Name;
            }
            else
            {
                string r = inputColor.R.ToString("X");
                string g = inputColor.G.ToString("X");
                string b = inputColor.B.ToString("X");
                while (r.Length < 2)
                    r = "0" + r;
                while (g.Length < 2)
                    g = "0" + g;
                while (b.Length < 2)
                    b = "0" + b;
                return "#" + r + g + b;
            }
        }

        /// <summary>
        /// 根据名字获取颜色
        /// </summary>
        /// <param name="colorString"></param>
        /// <returns></returns>
        public static Color colorByString(string colorString)
        {
            if (colorString.StartsWith("#"))
            {
                try
                {
                    string r = colorString.Substring(1, 2);
                    string g = colorString.Substring(3, 2);
                    string b = colorString.Substring(5, 2);
                    return Color.FromArgb(Convert.ToInt32(r, 16), Convert.ToInt32(g, 16), Convert.ToInt32(b, 16));
                }
                catch { }
            }
            else
            {
                try
                {
                    return Color.FromName(colorString);
                }
                catch { }
            }
            return Color.Transparent;
        }

        /// <summary>
        /// 获取比当前颜色浅一些的颜色
        /// </summary>
        /// <param name="opacity">变浅为原来的百分比,1~100(%)</param>
        /// <param name="color">原来的颜色</param>
        /// <returns></returns>
        public static Color lighterColor(int opacity, Color color)
        {
            int r = color.R;
            int g = color.G;
            int b = color.B;
            r = r + (255 - r) * (100 - opacity) / 100;
            g = g + (255 - g) * (100 - opacity) / 100;
            b = b + (255 - b) * (100 - opacity) / 100;
            return Color.FromArgb(color.A, r, g, b);
        }

        /// <summary>
        /// 将当前颜色转换为灰色
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static Color transToGrayColor(Color original)
        {
            if (original.Equals(Color.Transparent))
                return original;
            int grayScale = (int)((original.R * 0.299) + (original.G * 0.587) + (original.B * 0.114));
            return Color.FromArgb(grayScale, grayScale, grayScale);
        }

        /*
         * 说明:
         * RGB：这种表示颜色由三原色构成，通过红，绿，蓝三种颜色分量的不同，组合成不同的颜色，例如，100%红+100%绿混合可以得到黄色，红绿蓝三种颜色叠加可以得到白色，基本上屏幕显示色彩都采用这种方式。
         * CMYK：也称作印刷色彩模式，是一种依靠反光的色彩模式，主要用于印刷，和RGB类似，CMY是3种印刷油墨名称的首字母：青色Cyan、品红色Magenta、黄色Yellow。而K取的是black最后一个字母，之所以不取首字母，是为了避免与蓝色(Blue)混淆。从理论上来说，只需要CMY三种油墨就足够了，它们三个加在一起就应该得到黑色。但是由于目前制造工艺还不能造出高纯度的油墨，CMY相加的结果实际是一种暗红色。
         * HSB：通过色相（hues），饱和度（saturation），亮度（brightness）来表示颜色
         */
        /// <summary>
        /// RGB转化为CMYK
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="cyan"></param>
        /// <param name="magenta"></param>
        /// <param name="yellow"></param>
        /// <param name="black"></param>
        public static void transRGBtoCMYK(int red, int green, int blue, out double cyan, out double magenta, out double yellow, out double black)
        {
            cyan = (double)(255 - red) / 255;
            magenta = (double)(255 - green) / 255;
            yellow = (double)(255 - blue) / 255;

            black = (double)Math.Min(cyan, Math.Min(magenta, yellow));
            if (black == 1.0)
            {
                cyan = magenta = yellow = 0;
            }
            else
            {
                cyan = (cyan - black) / (1 - black);
                magenta = (magenta - black) / (1 - black);
                yellow = (yellow - black) / (1 - black);
            }
        }

        /// <summary>
        /// CMYK 转化为 RGB
        /// </summary>
        /// <param name="cyan"></param>
        /// <param name="magenta"></param>
        /// <param name="yellow"></param>
        /// <param name="black"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public static void transCMYKtoRGB(double cyan, double magenta, double yellow, double black, out int red, out int green, out int blue)
        {
            red = Convert.ToInt32((1.0 - cyan) * (1.0 - black) * 255.0);
            green = Convert.ToInt32((1.0 - magenta) * (1.0 - black) * 255.0);
            blue = Convert.ToInt32((1.0 - yellow) * (1.0 - black) * 255.0);
        }

        /// <summary>
        /// RGB 转化为 HSB
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="brightness"></param>
        public static void transRGBtoHSB(int red, int green, int blue, out double hue, out double saturation, out double brightness)
        {
            double r = ((double)red / 255.0);
            double g = ((double)green / 255.0);
            double b = ((double)blue / 255.0);

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));

            hue = 0.0;
            if (max == r && g >= b)
            {
                if (max - min == 0) hue = 0.0;
                else hue = 60 * (g - b) / (max - min);
            }
            else if (max == r && g < b)
            {
                hue = 60 * (g - b) / (max - min) + 360;
            }
            else if (max == g)
            {
                hue = 60 * (b - r) / (max - min) + 120;
            }
            else if (max == b)
            {
                hue = 60 * (r - g) / (max - min) + 240;
            }

            saturation = (max == 0) ? 0.0 : (1.0 - ((double)min / (double)max));
            brightness = max;
        }

        /// <summary>
        /// HSB 转化为 RGB
        /// </summary>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="brightness"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public static void transHSBtoRGB(double hue, double saturation, double brightness, out int red, out int green, out int blue)
        {
            double r = 0;
            double g = 0;
            double b = 0;

            if (saturation == 0)
            {
                r = g = b = brightness;
            }
            else
            {
                // the color wheel consists of 6 sectors. Figure out which sector you're in.
                double sectorPos = hue / 60.0;
                int sectorNumber = (int)(Math.Floor(sectorPos));
                // get the fractional part of the sector
                double fractionalSector = sectorPos - sectorNumber;

                // calculate values for the three axes of the color. 
                double p = brightness * (1.0 - saturation);
                double q = brightness * (1.0 - (saturation * fractionalSector));
                double t = brightness * (1.0 - (saturation * (1 - fractionalSector)));

                // assign the fractional colors to r, g, and b based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        r = brightness;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = brightness;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = brightness;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = brightness;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = brightness;
                        break;
                    case 5:
                        r = brightness;
                        g = p;
                        b = q;
                        break;
                }
            }
            red = Convert.ToInt32(r * 255);
            green = Convert.ToInt32(g * 255);
            blue = Convert.ToInt32(b * 255);
        }
    }
}