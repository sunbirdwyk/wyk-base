using System;
using System.Drawing;

namespace wyk.basic
{
    /// <summary>
    /// 指示与当前标签主体相关的颜色
    /// </summary>
    public class ReferedColorAttribute : Attribute
    {
        public Color color = Color.White;

        public ReferedColorAttribute(Color color)
        {
            this.color = color;
        }

        public ReferedColorAttribute(string color_string)
        {
            this.color = color_string.color();
        }

        public ReferedColorAttribute(int r, int g, int b)
        {
            this.color = Color.FromArgb(r, g, b);
        }

        public ReferedColorAttribute(int a, int r, int g, int b)
        {
            this.color = Color.FromArgb(a, r, g, b);
        }
    }
}
