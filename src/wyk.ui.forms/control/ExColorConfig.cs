using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using wyk.basic;

namespace wyk.ui
{
    public delegate void SelectedColorChangedNotice(ExColorConfig self, Color old_color, Color new_color);
    public class ExColorConfig : Panel
    {
        public SelectedColorChangedNotice SelectedColorChanged = null;
        public ExColorConfig()
        {
            setStyles();
            initializeProperties();
            initializeUI();
        }

        private void ShowColorSelector(object sender, System.EventArgs e)
        {
            var dialog = new ColorDialog();
            dialog.Color = _color;
            if(dialog.ShowDialog()== DialogResult.OK)
            {
                var old = _color;
                _color = dialog.Color;
                initializeUI();
                SelectedColorChanged?.Invoke(this, old, _color);
            }
        }

        private void HexChanged(object sender, System.EventArgs e)
        {
            var old = _color;
            _color = _hex_box.Text.color();
            initializeUI();
            SelectedColorChanged?.Invoke(this, old, _color);
        }

        #region private properties
        private ColorConfigUIType _ui_type = ColorConfigUIType.ColorBox;
        private bool _allow_hex_show_name = false;
        private Size _color_box_size = new Size(40, 20);
        private bool _color_box_show_first = false;
        private int _color_box_hex_space = 5;
        private Color _color = Color.Black;
        private bool self_added_click_event = false;
        #endregion

        #region private controls
        private TextBox _hex_box = new TextBox();
        private Panel _color_box = new Panel();
        #endregion

        #region custom properties
        [Description("显示样式")]
        public ColorConfigUIType UIType
        {
            get => _ui_type;
            set { _ui_type = value; initializeUI(); }
        }

        [Description("允许16进制显示颜色名称")]
        public bool AllowHexShowName
        {
            get => _allow_hex_show_name;
            set => _allow_hex_show_name = value;
        }

        [Description("颜色盒是否显示在16进制之前")]
        public bool ColorBoxShowFirst
        {
            get => _color_box_show_first;
            set { _color_box_show_first = value; initializeUI(); }
        }

        [Description("颜色盒大小")]
        public Size ColorBoxSize
        {
            get => _color_box_size;
            set { _color_box_size = value; initializeUI(); }
        }

        [Description("颜色盒与16进制之间的距离")]
        public int ColorBoxHexSpace
        {
            get => _color_box_hex_space;
            set { _color_box_hex_space = value; initializeUI(); }
        }

        [Description("16进制字体")]
        public new Font Font
        {
            get => base.Font;
            set { base.Font = value; initializeUI(); }
        }

        [Description("16进制字体颜色")]
        public new Color ForeColor
        {
            get => base.ForeColor;
            set { base.ForeColor = value; initializeUI(); }
        }
        /*
        [Description("16进制输入框Padding")]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; initializeUI(); }
        }
        */
        [Description("当前设置的颜色")]
        public Color CurrentColor
        {
            get => _color;
            set { _color = value; initializeUI(); }
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
            _color_box.BorderStyle = BorderStyle.FixedSingle;
            _hex_box.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(_hex_box);
            this.Controls.Add(_color_box);
            _color_box.Click += ShowColorSelector;
            _hex_box.DoubleClick += ShowColorSelector;
            _hex_box.Leave += HexChanged;
            this.SizeChanged += ExColorConfig_SizeChanged;
        }

        private void ExColorConfig_SizeChanged(object sender, System.EventArgs e)
        {
            var size = new Size();
            switch (_ui_type)
            {
                case ColorConfigUIType.ColorBox:
                default://只显示颜色盒时, 自身作为颜色盒显示
                    Size = _color_box_size;
                    break;
                case ColorConfigUIType.HexBox:
                    this.Size = _hex_box.Size;
                    break;
                case ColorConfigUIType.Both:
                    size = _color_box_size;
                    if (_hex_box.Height > size.Height)
                        size.Height = _hex_box.Height;
                    size.Width += _color_box_hex_space + _hex_box.Width;
                    break;
            }
            this.Size = size;
        }

        private void initializeUI()
        {
            switch (_ui_type)
            {
                case ColorConfigUIType.ColorBox:
                default://只显示颜色盒时, 自身作为颜色盒显示
                    this.BorderStyle = BorderStyle.FixedSingle;
                    if (!self_added_click_event)
                    {
                        this.Click += ShowColorSelector;
                        self_added_click_event = true;
                    }

                    _hex_box.Visible = false;
                    _color_box.Visible = false;

                    this.Size = _color_box_size;
                    this.BackColor = _color;
                    break;
                case ColorConfigUIType.HexBox:
                    this.BackColor = Color.Transparent;
                    if (self_added_click_event)
                    {
                        this.Click -= ShowColorSelector;
                        self_added_click_event = false;
                    }
                    this.BorderStyle = BorderStyle.None;

                    _hex_box.Visible = true;
                    _color_box.Visible = false;
                    
                    _hex_box.ForeColor = ForeColor;
                    _hex_box.Font = Font;
                    _hex_box.Location = new Point(0, 0);
                    _hex_box.Text = _color.hexString(_allow_hex_show_name);
                    _hex_box.Width = "#888888".measure(this.CreateGraphics(), Font).Width + 8;
                    this.Size = _hex_box.Size;
                    break;
                case ColorConfigUIType.Both:
                    this.BackColor = Color.Transparent;
                    if (self_added_click_event)
                    {
                        this.Click -= ShowColorSelector;
                        self_added_click_event = false;
                    }
                    this.BorderStyle = BorderStyle.None;

                    _hex_box.Visible = true;
                    _color_box.Visible = true;

                    _color_box.Size = _color_box_size;
                    _hex_box.ForeColor = ForeColor;
                    _hex_box.Font = Font;
                    _hex_box.Width = "#888888".measure(this.CreateGraphics(), Font).Width + 8;
                    var size = _color_box_size;
                    if (_hex_box.Height > size.Height)
                        size.Height = _hex_box.Height;
                    size.Width += _color_box_hex_space + _hex_box.Width;
                    if (_color_box_show_first)
                    {
                        _color_box.Location = new Point(0, (size.Height - _color_box_size.Height) / 2);
                        _hex_box.Location = new Point(_color_box_size.Width + _color_box_hex_space, 0);
                    }
                    else
                    {
                        _hex_box.Location = new Point(0, 0);
                        _color_box.Location = new Point(_hex_box.Width + _color_box_hex_space, (size.Height - _color_box_size.Height) / 2);
                    }
                    _hex_box.Text = _color.hexString(_allow_hex_show_name);
                    _color_box.BackColor = _color;
                    this.Size = size;
                    break;
            }
        }
        #endregion
    }
}
