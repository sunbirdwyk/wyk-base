using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using wyk.basic;

namespace wyk.ui
{
    public class ExFontConfig : Panel
    {
        public ExFontConfig()
        {
            setStyles();
            initializeProperties();
            initializeUI();
        }

        #region private properties
        private int _item_space = 5;
        private int _font_family_width = 120;
        private int _font_size_width = 40;
        #endregion

        #region private controls
        private ExFontSelector _fs_font_family = new ExFontSelector();
        private TextBox _txt_size = new TextBox();
        private CheckBox _chb_bold = new CheckBox();
        private Label _lbl_font_size_unit = new Label();
        #endregion

        #region custom properties
        [Description("各个子元素之间的距离")]
        public int ItenSpace
        {
            get => _item_space;
            set { _item_space = value; initializeUI(); }
        }

        [Description("内部元素的字体(注:此字体非当前管理的字体)")]
        public new Font Font
        {
            get => base.Font;
            set { base.Font = value; initializeUI(); }
        }

        [Description("内部元素的前景色颜色")]
        public new Color ForeColor
        {
            get => base.ForeColor;
            set { base.ForeColor = value; initializeUI(); }
        }
        [Description("当前设置的字体")]
        public Font CurrentFont
        {
            get
            {
                var name = _fs_font_family.Text;
                if (name.isNull())
                    name = "微软雅黑";
                var size = 9f;
                try
                {
                    size = (float)Convert.ToDouble(_txt_size.Text);
                    if (size <= 0)
                        size = 9;
                }
                catch { }
                return new Font(name, size, _chb_bold.Checked ? FontStyle.Bold : FontStyle.Regular);
            }
            set
            {
                _fs_font_family.Text = value.Name;
                _txt_size.Text = value.Size.ToString();
                _chb_bold.Checked = value.Bold;
            }
        }

        [Description("设置字体名称的输入框宽度")]
        public int FontFamilyWidth
        {
            get => _font_family_width;
            set { _font_family_width = value;initializeUI(); }
        }
        #endregion

        #region hided properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string AccessibleDescription
        {
            get => base.AccessibleDescription;
            set => base.AccessibleDescription = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string AccessibleName
        {
            get => base.AccessibleName;
            set => base.AccessibleName = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AccessibleRole AccessibleRole
        {
            get => base.AccessibleRole;
            set => base.AccessibleRole = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoScroll
        {
            get => base.AutoScroll;
            set => base.AutoScroll = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size AutoScrollMargin
        {
            get => base.AutoScrollMargin;
            set => base.AutoScrollMargin = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size AutoScrollMinSize
        {
            get => base.AutoScrollMinSize;
            set => base.AutoScrollMinSize = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoSize
        {
            get => base.AutoSize;
            set => base.AutoSize = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AutoSizeMode AutoSizeMode
        {
            get => base.AutoSizeMode;
            set => base.AutoSizeMode = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image BackgroundImage
        {
            get => base.BackgroundImage;
            set => base.BackgroundImage = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageLayout BackgroundImageLayout
        {
            get => base.BackgroundImageLayout;
            set => base.BackgroundImageLayout = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool CausesValidation
        {
            get => base.CausesValidation;
            set => base.CausesValidation = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get => base.Size;
            set => base.Size = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size MaximumSize
        {
            get => base.MaximumSize;
            set => base.MaximumSize = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size MinimumSize
        {
            get => base.MinimumSize;
            set => base.MinimumSize = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new RightToLeft RightToLeft
        {
            get => base.RightToLeft;
            set => base.RightToLeft = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding
        {
            get => base.Padding;
            set => base.Padding = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new object Tag
        {
            get => base.Tag;
            set => base.Tag = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseWaitCursor
        {
            get => base.UseWaitCursor;
            set => base.UseWaitCursor = value;
        }
        #endregion

        #region private functions
        private void setStyles()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        private void initializeProperties()
        {
            this.Font = new Font("微软雅黑", 9, FontStyle.Regular);
            this.BackColor = Color.Transparent;
            this.Controls.Add(_fs_font_family);
            _txt_size.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(_txt_size);
            _lbl_font_size_unit.Text = "pt";
            _lbl_font_size_unit.AutoSize = true;
            this.Controls.Add(_lbl_font_size_unit);
            _chb_bold.Text = "粗体";
            _chb_bold.AutoSize = true;
            this.Controls.Add(_chb_bold);
            this.SizeChanged += ExFontConfig_SizeChanged;
            initializeUI();
        }

        private void ExFontConfig_SizeChanged(object sender, System.EventArgs e)
        {
            var size = new Size();
            size.Height = _fs_font_family.Height;
            if (_txt_size.Height > size.Height)
                size.Height = _txt_size.Height;
            if (_chb_bold.Height > size.Height)
                size.Height = _chb_bold.Height;
            size.Width = _fs_font_family.Width + _txt_size.Width + _lbl_font_size_unit.Width + _chb_bold.Width + _item_space * 3;
            this.Size = size;
        }

        private void initializeUI()
        {
            _fs_font_family.Font = Font;
            _fs_font_family.Width = _font_family_width;
            _txt_size.Width = _font_size_width;
            _txt_size.Font = Font;
            _lbl_font_size_unit.Font = Font;
            _lbl_font_size_unit.ForeColor = ForeColor;
            _chb_bold.Font = Font;
            _chb_bold.ForeColor = ForeColor;
            var size = new Size();
            size.Height = _fs_font_family.Height;
            if (_txt_size.Height > size.Height)
                size.Height = _txt_size.Height;
            if (_chb_bold.Height > size.Height)
                size.Height = _chb_bold.Height;
            var x = 0;
            _fs_font_family.Location = new Point(x, (size.Height - _fs_font_family.Height) / 2);
            x += _fs_font_family.Width + _item_space;
            _txt_size.Location = new Point(x, (size.Height - _txt_size.Height) / 2);
            x += _txt_size.Width;
            _lbl_font_size_unit.Location = new Point(x, (size.Height - _lbl_font_size_unit.Height) / 2);
            x += _lbl_font_size_unit.Width + _item_space;
            _chb_bold.Location = new Point(x, (size.Height - _chb_bold.Height) / 2);
            size.Width = x + _chb_bold.Width;
            this.Size = size;
        }
        #endregion
    }
}