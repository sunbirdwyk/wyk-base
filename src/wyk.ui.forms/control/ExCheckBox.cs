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
    /// <summary>
    /// 扩展的勾选框, 可自定义勾选框的样式
    /// </summary>
    public class ExCheckBox : CheckBox
    {
        public ExCheckBox()
        {
            setStyles();
            this.BackColor = Color.Transparent;
            this.Font = new Font("微软雅黑", 9, FontStyle.Regular);
            this.UseVisualStyleBackColor = true;
        }

        #region private properties
        public ControlState control_state = ControlState.Normal;
        bool _use_same_color = true;
        float _check_rect_size = 13;
        float _check_text_space = 2;
        float _check_box_line_width = 1;
        Image _image_for_checked = null;
        Image _image_for_indeterminate = null;
        BorderConfig _border = new BorderConfig(BorderStyleEx.None);
        #endregion

        #region custom properties
        [Description("勾选框和文字使用相同颜色(否时勾选框一直使用系统色ControlText)")]
        public bool UseSameColor
        {
            get => _use_same_color;
            set => _use_same_color = value;
        }

        [Description("勾选框大小")]
        public float CheckRectSize
        {
            get => _check_rect_size;
            set => _check_rect_size = value;
        }

        [Description("勾选框方框的线宽")]
        public float CheckBoxLineWidth
        {
            get => _check_box_line_width;
            set => _check_box_line_width = value;
        }

        [Description("勾选框和文字之间的距离")]
        public float CheckTextSpace
        {
            get => _check_text_space;
            set => _check_text_space = value;
        }

        [Description("勾选框选中时的图片, 图片会占据方框内所有空间, 所以图片内应包括空白间距")]
        public Image ImageForChecked
        {
            get => _image_for_checked;
            set => _image_for_checked = value;
        }

        [Description("勾选框选择'未定'状态时的图片, 图片会占据方框内所有空间, 所以图片内应包括空白间距")]
        public Image ImageForIndeterminate
        {
            get => _image_for_indeterminate;
            set => _image_for_indeterminate = value;
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
            SizeF check_size = new SizeF(_check_rect_size, _check_rect_size);
            PointF check_point = new PointF(0, 0);
            RectangleF check_rect;
            switch (CheckAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    check_point.X = Padding.Left;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    check_point.X = Width / 2 - _check_rect_size / 2;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    check_point.X = Width - Padding.Right - _check_rect_size;
                    break;
            }
            switch (CheckAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    check_point.Y = Padding.Top;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    check_point.Y = Height / 2 - _check_rect_size / 2;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    check_point.Y = Height - Padding.Bottom - _check_rect_size;
                    break;
            }
            check_rect = new RectangleF(check_point.X + _check_box_line_width / 2, check_point.Y + _check_box_line_width / 2, check_size.Width - _check_box_line_width, check_size.Height - _check_box_line_width);
            RectangleF text_rect;
            switch (CheckAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                default:
                    text_rect = new RectangleF(Padding.Left + _check_rect_size + _check_text_space, Padding.Top, Width - Padding.Left - Padding.Right - _check_text_space + _check_rect_size, Height - Padding.Top - Padding.Bottom);
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    text_rect = new RectangleF(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right - _check_text_space + _check_rect_size, Height - Padding.Top - Padding.Bottom);
                    break;
                case ContentAlignment.TopCenter:
                    text_rect = new RectangleF(Padding.Left, Padding.Top + _check_rect_size + _check_text_space, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom - _check_rect_size + _check_text_space);
                    break;
                case ContentAlignment.MiddleCenter:
                    text_rect = new RectangleF(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom);
                    break;
                case ContentAlignment.BottomCenter:
                    text_rect = new RectangleF(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom - _check_rect_size - _check_text_space);
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
            g.DrawRectangle(new Pen(check_color, _check_box_line_width), check_rect.X, check_rect.Y, check_rect.Width, check_rect.Height);

            //画选择状态
            if (CheckState == CheckState.Indeterminate)
            {//不完全选择状态, 画方块
                if (_image_for_indeterminate == null)
                {
                    float bare_width = _check_rect_size / 10;
                    if (bare_width == 0)
                        bare_width = 1;
                    check_rect.Inflate(-bare_width - _check_box_line_width, -bare_width - _check_box_line_width);
                    g.FillRectangle(new SolidBrush(check_color), check_rect);
                }
                else
                {
                    check_rect.Inflate(-_check_box_line_width, -_check_box_line_width);
                    g.DrawImage(_image_for_indeterminate, check_rect);
                }
            }
            else if (CheckState == CheckState.Checked)
            {//完全选择状态, 画对勾
                check_rect.Inflate(-_check_box_line_width, _check_box_line_width);
                if (_image_for_checked == null)
                {
                    string symbol = "√";
                    Font font = new Font("华文琥珀", check_rect.Width, FontStyle.Bold);
                    SizeF size = symbol.measureF(g, font);
                    PointF p = check_rect.Location;
                    p.X -= (size.Width - check_rect.Width) / 2;
                    p.Y -= (size.Height - check_rect.Height) / 2 - 1;
                    g.DrawString(symbol, font, new SolidBrush(check_color), p);
                }
                else
                {
                    g.DrawImage(_image_for_checked, check_rect);
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