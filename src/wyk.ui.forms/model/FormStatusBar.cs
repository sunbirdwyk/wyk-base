using System.ComponentModel;
using System.Drawing;

namespace wyk.ui
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class FormStatusBar
    {
        #region private properties
        bool _should_show = false;
        int _height = 20;
        Color _back_color = Color.FromArgb(138, 185, 242);
        Font _text_font = new Font("微软雅黑", 8, FontStyle.Regular);
        Color _text_color = Color.White;
        string _text = "";
        ContentAlignment _text_alignment = ContentAlignment.MiddleCenter;
        #endregion

        [Description("是否显示")]
        public bool ShouldShow
        {
            get => _should_show;
            set => _should_show = value;
        }

        [Description("高度")]
        public int Height
        {
            get => _height;
            set => _height = value;
        }

        [Description("背景颜色")]
        public Color BackColor
        {
            get => _back_color;
            set => _back_color = value;
        }

        [Description("文字字体")]
        public Font TextFont
        {
            get => _text_font;
            set => _text_font = value;
        }

        [Description("文字颜色")]
        public Color TextColor
        {
            get => _text_color;
            set => _text_color = value;
        }

        [Description("文字内容")]
        public string Text
        {
            get => _text;
            set => _text = value;
        }

        [Description("文字对齐方式")]
        public ContentAlignment TextAlignment
        {
            get => _text_alignment;
            set => _text_alignment = value;
        }
    }
}
