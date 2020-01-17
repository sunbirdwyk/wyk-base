using System.Drawing;

namespace wyk.basic
{
    /// <summary>
    /// 与颜色相关的函数扩展
    /// 注:使用时直接引用imc.basic后即可生效, 比如:
    /// Color color = Color.Red; Color linghter = color.lighterColor(60);
    /// 注:当前Extention下的类只是为了调用方便, 并没有删掉原Utility中的内容, 只是直接调用
    /// </summary>
    public static class ColorReferedExtention
    {
        /// <summary>
        /// 获取给定的颜色的ARGB的分量差值的颜色
        /// </summary>
        /// <param name="color"></param>
        /// <param name="a">A</param>
        /// <param name="r">R</param>
        /// <param name="g">G</param>
        /// <param name="b">B</param>
        /// <returns></returns>
        public static Color withOffset(this Color color, int a, int r, int g, int b)
        {
            return ColorUtil.colorWithOffset(color, a, r, g, b);
        }

        /// <summary>
        /// 获取颜色名字,有名字则获取名字,无则获取#XXXXXX
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string hexString(this Color color)
        {
            return ColorUtil.stringForColor(color);
        }

        /// <summary>
        /// 获取颜色名字
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="allow_name">是否允许名字,否则只返回#XXXXXX类型结果</param>
        /// <returns></returns>
        public static string hexString(this Color color, bool allow_name)
        {
            return ColorUtil.stringForColor(color, allow_name);
        }

        /// <summary>
        /// 根据名字获取颜色
        /// </summary>
        /// <param name="color_string"></param>
        /// <returns></returns>
        public static Color color(this string color_string)
        {
            return ColorUtil.colorByString(color_string);
        }

        /// <summary>
        /// 获取比当前颜色浅一些的颜色
        /// </summary>
        /// <param name="color">原来的颜色</param>
        /// <param name="opacity">变浅为原来的百分比,1~100(%)</param>
        /// <returns></returns>
        public static Color lighterColor(this Color color, int opacity)
        {
            return ColorUtil.lighterColor(opacity, color);
        }

        /// <summary>
        /// 将当前颜色转换为灰色
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color grayColor(this Color color)
        {
            return ColorUtil.transToGrayColor(color);
        }

        /// <summary>
        /// 获取一定透明度的Color
        /// </summary>
        /// <param name="color">原颜色</param>
        /// <param name="alpha">透明度(0~255)</param>
        /// <returns></returns>
        public static Color alpha(this Color color, int alpha)
        {
            return Color.FromArgb(alpha, color);
        }

        /// <summary>
        /// 获取纯色图片
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Image image(this Color color)
        {
            return ImageUtil.imageWithColor(color);
        }

        /// <summary>
        /// 获取纯色图片
        /// </summary>
        /// <param name="color"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Image image(this Color color, Size size)
        {
            return ImageUtil.imageWithColor(color, size);
        }
    }
}
