using System.ComponentModel;
using System.Drawing;

namespace wyk.ui
{
    /// <summary>
    /// 用于自定义属性中的文字块
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TextBlock
    {
        #region private properties
        Color _back_color = Color.Transparent;
        Color _fore_color = Color.Black;
        Font _font = new Font("微软雅黑", 9, FontStyle.Regular);
        string _text = "";
        ContentAlignment _text_align = ContentAlignment.MiddleCenter;
        #endregion

        public TextBlock() { }
        public TextBlock(Color BackColor, Color ForeColor)
        {
            _back_color = BackColor;
            _fore_color = ForeColor;
        }
        public TextBlock(Color BackColor, Color ForeColor, Font Font)
        {
            _back_color = BackColor;
            _fore_color = ForeColor;
            _font = Font;
        }
        public TextBlock(Color BackColor, Color ForeColor, Font Font, ContentAlignment TextAlign)
        {
            _back_color = BackColor;
            _fore_color = ForeColor;
            _font = Font;
            _text_align = TextAlign;
        }

        [Description("背景色")]
        public Color BackColor
        {
            get => _back_color;
            set => _back_color = value;
        }

        [Description("文字颜色")]
        public Color ForeColor
        {
            get => _fore_color;
            set => _fore_color = value;
        }

        [Description("字体")]
        public Font Font
        {
            get => _font;
            set => _font = value;
        }

        [Description("文字内容")]
        public string Text
        {
            get => _text;
            set => _text = value;
        }

        [Description("文字对齐方式")]
        public ContentAlignment TextAlign
        {
            get => _text_align;
            set => _text_align = value;
        }
    }
}
