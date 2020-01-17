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
    /// 勾选按钮, 选中和非选中两种状态
    /// </summary>
    public class ExCheckButton : Button
    {
        public ExCheckButton()
        {
            setStyles();
            initializeProperties();
        }

        #region public properties
        /// <summary>
        /// 当前button的状态
        /// </summary>
        private ControlState control_state = ControlState.Normal;
        #endregion

        #region custom properties
        [Description("边框样式")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BorderConfig Border { get; set; } = new BorderConfig(BorderStyleEx.RoundedRectangle, 3, 2);

        [Description("按钮主色")]
        public Color PrimaryColor { get; set; } = Color.RoyalBlue;

        [Description("按钮辅色")]
        public Color SecondaryColor { get; set; } = Color.White;

        /// <summary>
        /// 是否反转颜色
        /// 注:根据_is_reverse的状态来确定各个颜色
        /// --IsReverse为true时, 主色为按钮字体颜色和边框颜色, 辅色为背景色
        /// --IsReverse为false时, 主色为背景色, 辅色为字体颜色(边框颜色与背景色相同)
        /// </summary>
        [Description("是否反转颜色\r\n注:根据_is_reverse的状态来确定各个颜色\r\n--IsReverse为true时, 主色为按钮字体颜色和边框颜色, 辅色为背景色\r\n--IsReverse为false时, 主色为背景色, 辅色为字体颜色(边框颜色与背景色相同)")]
        public bool IsReverse { get; set; } = true;

        [Description("按钮是否已选中")]
        public bool IsSelected { get; set; } = false;
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
            drawContents(g);
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
            this.Click += ExCheckButton_Click;
            base.Text = "";
        }

        private void ExCheckButton_Click(object sender, EventArgs e)
        {
            IsSelected = !IsSelected;
            Invalidate();
        }

        private void drawContents(Graphics g)
        {
            Rectangle rect = ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            Color bg_color = Color.Transparent;
            Color border_color = Color.Transparent;
            Color text_color = Color.Black;
            if (IsSelected)
            {
                switch (control_state)
                {
                    case ControlState.Normal:
                    case ControlState.Focus:
                    default:
                        if (IsReverse)
                        {
                            bg_color = PrimaryColor;
                            border_color = bg_color;
                            text_color = SecondaryColor;
                        }
                        else
                        {
                            bg_color = SecondaryColor;
                            border_color = PrimaryColor;
                            text_color = border_color;
                        }
                        break;
                    case ControlState.Disabled:
                        if (IsReverse)
                        {
                            bg_color = PrimaryColor.grayColor();
                            border_color = bg_color;
                            text_color = SecondaryColor;
                        }
                        else
                        {
                            bg_color = SecondaryColor.grayColor();
                            border_color = PrimaryColor.grayColor();
                            text_color = border_color;
                        }
                        break;
                    case ControlState.Down:
                        if (IsReverse)
                        {
                            bg_color = PrimaryColor.lighterColor(60);
                            border_color = bg_color;
                            text_color = SecondaryColor;
                        }
                        else
                        {
                            bg_color = SecondaryColor.lighterColor(60);
                            border_color = PrimaryColor.lighterColor(60);
                            text_color = border_color;
                        }
                        break;
                    case ControlState.Highlight:
                        if (IsReverse)
                        {
                            bg_color = PrimaryColor.lighterColor(80);
                            border_color = bg_color;
                            text_color = SecondaryColor;
                        }
                        else
                        {
                            bg_color = SecondaryColor.lighterColor(80);
                            border_color = PrimaryColor.lighterColor(80);
                            text_color = border_color;
                        }
                        break;
                }
            }
            else
            {
                switch (control_state)
                {
                    case ControlState.Normal:
                    case ControlState.Focus:
                    default:
                        if (IsReverse)
                        {
                            bg_color = SecondaryColor;
                            border_color = PrimaryColor;
                            text_color = border_color;
                        }
                        else
                        {
                            bg_color = PrimaryColor;
                            border_color = bg_color;
                            text_color = SecondaryColor;
                        }
                        break;
                    case ControlState.Disabled:
                        if (IsReverse)
                        {
                            bg_color = SecondaryColor.grayColor();
                            border_color = PrimaryColor.grayColor();
                            text_color = border_color;
                        }
                        else
                        {
                            bg_color = PrimaryColor.grayColor();
                            border_color = bg_color;
                            text_color = SecondaryColor.grayColor();
                        }
                        break;
                    case ControlState.Down:
                        if (IsReverse)
                        {
                            bg_color = SecondaryColor.lighterColor(60);
                            border_color = PrimaryColor.lighterColor(60);
                            text_color = border_color;
                        }
                        else
                        {
                            bg_color = PrimaryColor.lighterColor(60);
                            border_color = bg_color;
                            text_color = SecondaryColor.lighterColor(60);
                        }
                        break;
                    case ControlState.Highlight:
                        if (IsReverse)
                        {
                            bg_color = SecondaryColor.lighterColor(80);
                            border_color = PrimaryColor.lighterColor(80);
                            text_color = border_color;
                        }
                        else
                        {
                            bg_color = PrimaryColor.lighterColor(80);
                            border_color = bg_color;
                            text_color = SecondaryColor.lighterColor(80);
                        }
                        break;
                }
            }

            Border.drawBorderAndBackground(g, rect, border_color, bg_color);

            Rectangle text_rect = rect;
            text_rect.X += Padding.Left;
            text_rect.Y += Padding.Top;
            text_rect.Width -= Padding.Left + Padding.Right - 4;
            text_rect.Height -= Padding.Top + Padding.Bottom - 2;

            g.drawTextInRect(text_rect, Text, Font, text_color, TextAlign);
        }
        #endregion
    }
}