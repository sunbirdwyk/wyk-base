using System.ComponentModel;
using System.Drawing;
using wyk.ui.enums;

namespace wyk.ui
{
    /// <summary>
    /// 窗体标题条样式
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class FormTitleBar
    {
        #region private properties
        bool _should_show = true;
        int _height = 25;
        FormTitleBarUIMode _ui_mode = FormTitleBarUIMode.Separated;
        FormActionButtonStyle _action_button_style = FormActionButtonStyle.Flat;
        FormActionButtonPosition _action_button_position = FormActionButtonPosition.Center;
        Color _back_color = Color.FromArgb(24, 116, 226);
        Font _text_font = new Font("微软雅黑", 9, FontStyle.Regular);
        Color _text_color = Color.White;
        #endregion

        [Description("是否显示")]
        public bool ShouldShow
        {
            get => _should_show;
            set => _should_show = value;
        }

        [Description("高度, 不得小于25")]
        public int Height
        {
            get => _height;
            set => _height = value;
        }

        [Description("显示形式(独立显示/融合显示)")]
        public FormTitleBarUIMode UIMode
        {
            get => _ui_mode;
            set => _ui_mode = value;
        }

        [Description("动作按钮样式")]
        public FormActionButtonStyle ActionButtonStyle
        {
            get => _action_button_style;
            set => _action_button_style = value;
        }

        [Description("动作按钮位置")]
        public FormActionButtonPosition ActionButtonPosition
        {
            get => _action_button_position;
            set => _action_button_position = value;
        }

        [Description("背景色")]
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
    }
}
