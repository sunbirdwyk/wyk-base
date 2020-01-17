using wyk.basic;
using System;
using System.Drawing;

namespace wyk.ui
{
    public class ReferedColorGroupAttribute : Attribute
    {
        public ColorGroup color_group = new ColorGroup();

        public ReferedColorGroupAttribute(ColorGroup color_group)
        {
            this.color_group = color_group;
        }

        public ReferedColorGroupAttribute(Color normal, Color hovered, Color clicked)
        {
            this.color_group = new ColorGroup(normal, hovered, clicked);
        }

        public ReferedColorGroupAttribute(string normal, string hovered, string clicked)
        {
            this.color_group = new ColorGroup(normal.color(), hovered.color(), clicked.color());
        }
    }
}
