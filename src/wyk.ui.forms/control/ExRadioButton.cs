using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using wyk.basic;
using wyk.ui.enums;

namespace wyk.ui
{
    public class ExRadioButton : RadioButton
    {
        public ExRadioButton()
        {
            setStyles();
            this.BackColor = Color.Transparent;
            this.Font = new Font("微软雅黑", 9, FontStyle.Regular);
            this.UseVisualStyleBackColor = true;
        }

        #region private properties
        public ControlState control_state = ControlState.Normal;
        bool _use_same_color = true;
        float _radio_rect_size = 13;
        float _radio_text_space = 2;
        float _radio_circle_line_width = 1;
        Image _image_for_checked = null;
        BorderConfig _border = new BorderConfig(BorderStyleEx.None);
        #endregion

        #region custom properties
        [Description("单选框和文字使用相同颜色(否时勾选框一直使用系统色ControlText)")]
        public bool UseSameColor
        {
            get => _use_same_color;
            set => _use_same_color = value;
        }

        [Description("单选框大小")]
        public float RadioRectSize
        {
            get => _radio_rect_size;
            set => _radio_rect_size = value;
        }

        [Description("单选框方框的线宽")]
        public float RadioCircleLineWidth
        {
            get => _radio_circle_line_width;
            set => _radio_circle_line_width = value;
        }

        [Description("单选框和文字之间的距离")]
        public float RadioTextSpace
        {
            get => _radio_text_space;
            set => _radio_text_space = value;
        }

        [Description("单选框选中时的图片, 图片会占据方框内所有空间, 所以图片内应包括空白间距")]
        public Image ImageForChecked
        {
            get => _image_for_checked;
            set => _image_for_checked = value;
        }

        [Description("边框设置")]
        public BorderConfig Border
        {
            get => _border;
            set => _border = value;
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
        public new Appearance Appearance
        {
            get => base.Appearance;
            set => base.Appearance = value;
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
        public new FlatButtonAppearance FlatAppearance
        {
            get { return base.FlatAppearance; }
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
        public new bool UseCompatibleTextRendering
        {
            get => base.UseCompatibleTextRendering;
            set => base.UseCompatibleTextRendering = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseMnemonic
        {
            get => base.UseMnemonic;
            set => base.UseMnemonic = value;
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

        #region overrides
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
            //base.OnPaint(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
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

        private void drawContents(Graphics g)
        {
            Color primary_color = ForeColor;
            if (control_state == ControlState.Disabled)
                primary_color = Color.FromArgb(200, 200, 200);
            SizeF radio_size = new SizeF(_radio_rect_size, _radio_rect_size);
            PointF radio_point = new PointF(0, 0);
            RectangleF radio_rect;
            switch (CheckAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    radio_point.X = Padding.Left;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    radio_point.X = Width / 2 - _radio_rect_size / 2;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    radio_point.X = Width - Padding.Right - _radio_rect_size;
                    break;
            }
            switch (CheckAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    radio_point.Y = Padding.Top;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    radio_point.Y = Height / 2 - _radio_rect_size / 2;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    radio_point.Y = Height - Padding.Bottom - _radio_rect_size;
                    break;
            }
            radio_rect = new RectangleF(radio_point.X + _radio_circle_line_width / 2, radio_point.Y + _radio_circle_line_width / 2, radio_size.Width - _radio_circle_line_width, radio_size.Height - _radio_circle_line_width);
            RectangleF text_rect;
            switch (CheckAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                default:
                    text_rect = new RectangleF(Padding.Left + _radio_rect_size + _radio_text_space, Padding.Top, Width - Padding.Left - Padding.Right - _radio_text_space - _radio_rect_size, Height - Padding.Top - Padding.Bottom);
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    text_rect = new RectangleF(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right - _radio_text_space - _radio_rect_size, Height - Padding.Top - Padding.Bottom);
                    break;
                case ContentAlignment.TopCenter:
                    text_rect = new RectangleF(Padding.Left, Padding.Top + _radio_rect_size + _radio_text_space, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom - _radio_rect_size - _radio_text_space);
                    break;
                case ContentAlignment.MiddleCenter:
                    text_rect = new RectangleF(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom);
                    break;
                case ContentAlignment.BottomCenter:
                    text_rect = new RectangleF(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom - _radio_rect_size - _radio_text_space);
                    break;
            }
            Color check_color;
            Color text_color;
            switch (control_state)
            {
                case ControlState.Normal:
                case ControlState.Focus:
                default:
                    if (_use_same_color)
                        check_color = primary_color;
                    else
                        check_color = SystemColors.ControlText;
                    text_color = primary_color;
                    break;
                case ControlState.Highlight:
                    if (_use_same_color)
                        check_color = primary_color.lighterColor(80);
                    else
                        check_color = SystemColors.ControlText.lighterColor(80);
                    text_color = primary_color.lighterColor(80);
                    break;
                case ControlState.Down:
                    if (_use_same_color)
                        check_color = primary_color.lighterColor(60);
                    else
                        check_color = SystemColors.ControlText.lighterColor(60);
                    text_color = primary_color.lighterColor(60);
                    break;
                case ControlState.Disabled:
                    check_color = primary_color;
                    text_color = primary_color;
                    break;
            }
            g.DrawEllipse(new Pen(check_color, _radio_circle_line_width), radio_rect);

            //画选择状态
            if (Checked)
            {//不完全选择状态, 画方块
                if (_image_for_checked == null)
                {
                    float bare_width = _radio_rect_size / 10;
                    if (bare_width == 0)
                        bare_width = 1;
                    radio_rect.Inflate(-bare_width - _radio_circle_line_width, -bare_width - _radio_circle_line_width);
                    g.FillEllipse(new SolidBrush(check_color), radio_rect);
                }
                else
                {
                    radio_rect.Inflate(-_radio_circle_line_width, -_radio_circle_line_width);
                    g.DrawImage(_image_for_checked, radio_rect);
                }
            }
            //画文字
            g.drawTextInRect(text_rect, Text, Font, text_color, TextAlign);
            //画边框
            _border.drawBorder(g, new Rectangle(0, 0, Width - 1, Height - 1), text_color);
        }
        #endregion
    }
}