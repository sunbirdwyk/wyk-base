using System.ComponentModel;
using System.Drawing;
using wyk.basic;

namespace wyk.ui
{
    /// <summary>
    /// 用于指示不同状态下的颜色
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ColorGroup
    {
        private Color _normal = Color.Black;
        private Color _hovered = Color.Transparent;
        private Color _clicked = Color.Transparent;

        public ColorGroup() { }
        public ColorGroup(Color Normal)
        {
            _normal = Normal;
            _hovered = Color.Transparent;
            _clicked = Color.Transparent;
        }
        public ColorGroup(Color Normal, Color Hovered, Color Clicked)
        {
            _normal = Normal;
            _hovered = Hovered;
            _clicked = Clicked;
        }

        /// <summary>
        /// 不可用状态下的颜色(非背景色)
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Disabled
        {
            get { return _normal.grayColor(); }
        }

        /// <summary>
        /// 不可用状态下的颜色(背景色)
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color DisabledForBackground
        {
            get { return _normal.grayColor().lighterColor(10); }
        }

        [Description("正常状态下的颜色")]
        public Color Normal
        {
            get => _normal;
            set => _normal = value;
        }

        [Description("鼠标悬停状态下的颜色")]
        public Color Hovered
        {
            get => _hovered == Color.Transparent ? _normal : _hovered;
            set => _hovered = value;
        }

        [Description("鼠标按下状态下的颜色")]
        public Color Clicked
        {
            get => _clicked == Color.Transparent ? _normal : _clicked;
            set => _clicked = value;
        }
    }
}
