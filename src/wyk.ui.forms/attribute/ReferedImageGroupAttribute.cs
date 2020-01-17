using System;
using System.Drawing;

namespace wyk.ui
{
    public class ReferedImageGroupAttribute : Attribute
    {
        public ImageGroup image_group = null;
        public string resource_base_name = "";

        public ReferedImageGroupAttribute(ImageGroup group)
        {
            this.image_group = group;
        }
        public ReferedImageGroupAttribute(string resource_base_name)
        {
            this.resource_base_name = resource_base_name;
        }
        public ReferedImageGroupAttribute(Image normal, Image hovered, Image clicked)
        {
            this.image_group = new ImageGroup(normal, hovered, clicked);
        }
        public ReferedImageGroupAttribute(Bitmap normal, Bitmap hovered, Bitmap clicked)
        {
            this.image_group = new ImageGroup(normal, hovered, clicked);
        }
    }
}
