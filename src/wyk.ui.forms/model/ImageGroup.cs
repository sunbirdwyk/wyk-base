using System.ComponentModel;
using System.Drawing;
using wyk.basic;

namespace wyk.ui
{
    /// <summary>
    /// 用于显示不同状态下的图片
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ImageGroup
    {
        private Image _normal = null;
        private Image _hovered = null;
        private Image _clicked = null;

        public ImageGroup() { }
        public ImageGroup(Image Normal)
        {
            _normal = Normal;
            _hovered = null;
            _clicked = null;
        }
        public ImageGroup(Image Normal,Image Hovered,Image Clicked)
        {
            _normal = Normal;
            _hovered = Hovered;
            _clicked = Clicked;
        }

        /// <summary>
        /// 不可用状态下的图片
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image Disabled
        {
            get
            {
                if (_normal == null)
                    return null;
                return _normal.grayImage();
            }
        }

        [Description("正常状态下的图片")]
        public Image Normal
        {
            get => _normal;
            set => _normal = value;
        }

        [Description("鼠标悬停状态下的图片")]
        public Image Hovered
        {
            get
            {
                if (_hovered == null)
                    return _normal;
                return _hovered;
            }
            set => _hovered = value;
        }

        [Description("鼠标点击状态下的图片")]
        public Image Clicked
        {
            get
            {
                if (_clicked == null)
                    return _normal;
                return _clicked;
            }
            set => _clicked = value;
        }
    }
}
