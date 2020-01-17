using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using wyk.basic;
using wyk.ui.enums;

namespace wyk.ui
{
    /// <summary>
    /// 普通的文本按钮, 可以定义背景色和边框颜色和边框样式, 不能添加图片
    /// </summary>
    public class ExTextButton : Button
    {
        public ExTextButton()
        {
            setStyles();
            initializeProperties();
        }

        #region private properties
        /// <summary>
        /// 边框设置
        /// </summary>
        private BorderConfig _border = new BorderConfig();
        /// <summary>
        /// button的主色
        /// </summary>
        private Color _primary_color = Color.RoyalBlue;
        /// <summary>
        /// button的辅色
        /// </summary>
        private Color _secondary_color = Color.White;
        /// <summary>
        /// 是否反转颜色
        /// 注:根据_is_reverse的状态来确定各个颜色
        /// --IsReverse为true时, 主色为按钮字体颜色和边框颜色, 辅色为背景色
        /// --IsReverse为false时, 主色为背景色, 辅色为字体颜色(边框颜色与背景色相同)
        /// </summary>
        private bool _is_reverse = false;
        private ButtonFuctionType _function_type = ButtonFuctionType.Normal;
        #endregion

        #region public properties
        /// <summary>
        /// 当前button的状态
        /// </summary>
        public ControlState control_state = ControlState.Normal;
        #endregion

        #region custom properties
        [Description("边框样式")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BorderConfig Border
        {
            get => _border;
            set => _border = value;
        }

        [Description("按钮主色")]
        public Color PrimaryColor
        {
            get => _primary_color;
            set => _primary_color = value;
        }

        [Description("按钮辅色")]
        public Color SecondaryColor
        {
            get => _secondary_color;
            set => _secondary_color = value;
        }

        [Description("是否反转颜色\r\n注:根据_is_reverse的状态来确定各个颜色\r\n--IsReverse为true时, 主色为按钮字体颜色和边框颜色, 辅色为背景色\r\n--IsReverse为false时, 主色为背景色, 辅色为字体颜色(边框颜色与背景色相同)")]
        public bool IsReverse
        {
            get => _is_reverse;
            set => _is_reverse = value;
        }
        [Description("是否使用父窗体的主色作为按钮的主色")]
        public ButtonFuctionType FunctionType
        {
            get => _function_type;
            set
            {
                _function_type = value;
                setColorForFunctionType();
            }
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
        public new Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
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
        public new Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FlatStyle FlatStyle
        {
            get => base.FlatStyle;
            set => base.FlatStyle = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FlatButtonAppearance FlatAppearance
        {
            get => base.FlatAppearance;
            set
            {
                base.FlatAppearance.BorderColor = value.BorderColor;
                base.FlatAppearance.BorderSize = value.BorderSize;
                base.FlatAppearance.CheckedBackColor = value.CheckedBackColor;
                base.FlatAppearance.MouseDownBackColor = value.MouseDownBackColor;
                base.FlatAppearance.MouseOverBackColor = value.MouseOverBackColor;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image Image
        {
            get => base.Image;
            set => base.Image = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ContentAlignment ImageAlign
        {
            get => base.ImageAlign;
            set => base.ImageAlign = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int ImageIndex
        {
            get => base.ImageIndex;
            set => base.ImageIndex = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string ImageKey
        {
            get => base.ImageKey;
            set => base.ImageKey = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageList ImageList
        {
            get => base.ImageList;
            set => base.ImageList = value;
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
        public new object Tag
        {
            get => base.Tag;
            set => base.Tag = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TextImageRelation TextImageRelation
        {
            get => base.TextImageRelation;
            set => base.TextImageRelation = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseCompatibleTextRendering
        {
            get => base.UseCompatibleTextRendering;
            set => base.UseCompatibleTextRendering = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseVisualStyleBackColor
        {
            get => base.UseVisualStyleBackColor;
            set => base.UseVisualStyleBackColor = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseWaitCursor
        {
            get => base.UseWaitCursor;
            set => base.UseWaitCursor = value;
        }
        #endregion

        #region override functions
        protected override void OnMouseEnter(EventArgs e)
        {
            control_state = ControlState.Highlight;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            control_state = ControlState.Normal;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            control_state = ControlState.Down;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            control_state = ControlState.Highlight;
            base.OnMouseUp(mevent);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
                control_state = ControlState.Normal;
            else
                control_state = ControlState.Disabled;
            base.OnEnabledChanged(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            if (!Enabled)
                control_state = ControlState.Disabled;
            drawButtonContents(g);
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
            this.Size = new Size(60, 25);
            this.UseVisualStyleBackColor = true;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.BackColor = Color.Transparent;
        }

        private void setColorForFunctionType()
        {
            try
            {
                switch (_function_type)
                {
                    case ButtonFuctionType.Normal:
                        break;
                    case ButtonFuctionType.Primary:
                        _primary_color = this.parentExForm().TitleBar.BackColor;
                        break;
                    case ButtonFuctionType.Secondary:
                        _primary_color = this.parentExForm().StatusBar.BackColor;
                        break;
                    default:
                        var ref_color = _function_type.getAttribute<ReferedColorAttribute>();
                        if (ref_color != null)
                            _primary_color = ref_color.color;
                        break;
                }
                
            }
            catch { }
        }

        private void drawButtonContents(Graphics g)
        {
            Rectangle rect = ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            Color bg_color = Color.Transparent;
            Color border_color = Color.Transparent;
            Color text_color = Color.Black;

            setColorForFunctionType();

            switch (control_state)
            {
                case ControlState.Normal:
                case ControlState.Focus:
                default:
                    if (_is_reverse)
                    {
                        bg_color = _secondary_color;
                        border_color = _primary_color;
                        text_color = border_color;
                    }
                    else
                    {
                        bg_color = _primary_color;
                        text_color = _secondary_color;
                    }
                    break;
                case ControlState.Disabled:
                    if (_is_reverse)
                    {
                        bg_color = _secondary_color.grayColor().lighterColor(10);
                        border_color = _primary_color.grayColor();
                        text_color = border_color;
                    }
                    else
                    {
                        bg_color = _primary_color.grayColor();
                        text_color = _secondary_color;
                    }
                    break;
                case ControlState.Down:
                    if (_is_reverse)
                    {
                        bg_color = _secondary_color.lighterColor(60);
                        border_color = _primary_color.lighterColor(60);
                        text_color = border_color;
                    }
                    else
                    {
                        bg_color = _primary_color.lighterColor(60);
                        text_color = _secondary_color.lighterColor(60);
                    }
                    break;
                case ControlState.Highlight:
                    if (_is_reverse)
                    {
                        bg_color = _secondary_color.lighterColor(80);
                        border_color = _primary_color.lighterColor(80);
                        text_color = border_color;
                    }
                    else
                    {
                        bg_color = _primary_color.lighterColor(80);
                        text_color = _secondary_color.lighterColor(80);
                    }
                    break;
            }

            _border.drawBorderAndBackground(g, rect, border_color, bg_color);

            Rectangle text_rect = rect;
            text_rect.X +=  Padding.Left;
            text_rect.Y +=  Padding.Top;
            text_rect.Width -=  Padding.Left + Padding.Right - 4;
            text_rect.Height -= Padding.Top + Padding.Bottom - 2;
            /*
            text_rect.X += _border.Width + Padding.Left;
            text_rect.Y += _border.Width + Padding.Top;
            text_rect.Width -= _border.Width * 2 + Padding.Left + Padding.Right;
            text_rect.Height -= _border.Width * 2 + Padding.Top + Padding.Bottom;
            */
            g.drawTextInRect(text_rect, Text, Font, text_color, TextAlign);
        }
        #endregion
    }
}