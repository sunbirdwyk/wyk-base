using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using wyk.basic;

namespace wyk.ui
{
    public class ExGroupBox : Panel
    {
        public ExGroupBox()
        {
            setStyles();
            this.SizeChanged += ExFontConfig_SizeChanged;
        }

        #region private properties
        private float _corner_radius = 3;
        private float _title_space = 10;
        private Font _title_font = new Font("微软雅黑", 9, FontStyle.Regular);
        private Color _title_fore_color = Color.Black;
        private Color _bounds_color = Color.FromArgb(180, 180, 180);
        private float _bounds_width = 1;
        private float _title_offset = 15;
        private string _title_text = "";
        #endregion

        #region custom properties
        [Description("边框圆角半径")]
        public float CornerRadius
        {
            get => _corner_radius;
            set
            {
                if (_corner_radius == value)
                    return;
                _corner_radius = value;
                if (_title_offset < _corner_radius)
                    _title_offset = _corner_radius;
                refreshUI();
            }
        }

        [Description("标题文字距离边框的距离(文字与边框的空隙距离)")]
        public float TitleSpace
        {
            get => _title_space;
            set
            {
                if (_title_space == value)
                    return;
                _title_space = value;
                refreshUI();
            }
        }

        [Description("标题文字字体")]
        public Font TitleFont
        {
            get => _title_font;
            set
            {
                if (_title_font == value)
                    return;
                _title_font = value;
                refreshUI();
            }
        }

        [Description("标题文字颜色")]
        public Color TitleForeColor
        {
            get => _title_fore_color;
            set
            {
                if (_title_fore_color == value)
                    return;
                _title_fore_color = value;
                refreshUI();
            }
        }

        [Description("边框颜色")]
        public Color BoundsColor
        {
            get => _bounds_color;
            set
            {
                if (_bounds_color == value)
                    return;
                _bounds_color = value;
                refreshUI();
            }
        }

        [Description("边框线宽")]
        public float BoundsWidth
        {
            get => _bounds_width;
            set
            {
                if (_bounds_width == value)
                    return;
                _bounds_width = value;
                refreshUI();
            }
        }

        [Description("标题偏移量(标题距左上角的距离,不含空隙)")]
        public float TitleOffset
        {
            get => _title_offset;
            set
            {
                if (_title_offset == value)
                    return;
                _title_offset = value;
                if (_title_offset < _corner_radius)
                    _title_offset = _corner_radius;
                refreshUI();
            }
        }

        [Description("标题文字")]
        public string TitleText
        {
            get => _title_text;
            set
            {
                if (_title_text == value)
                    return;
                _title_text = value;
                refreshUI();
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
        public new bool CausesValidation
        {
            get => base.CausesValidation;
            set => base.CausesValidation = value;
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

        private void ExFontConfig_SizeChanged(object sender, System.EventArgs e)
        {
            refreshUI();
        }

        private void refreshUI()
        {
            var image = new Bitmap(Width, Height);
            using (var g = Graphics.FromImage(image))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                var size = _title_text.measureF(g, TitleFont);
                this.MinimumSize = new Size(Convert.ToInt32(size.Width + 2 * _title_offset + 2 * _title_space), Convert.ToInt32(size.Height + 20));
                var rect = new RectangleF(_bounds_width / 2, size.Height / 2, Width - _bounds_width - 1, Height - _bounds_width - size.Height / 2 - 1);

                using (var pen = new Pen(_bounds_color, _bounds_width))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    if (_corner_radius == 0)
                    {
                        g.DrawLines(pen, new PointF[] {
                            new PointF(rect.X + _title_offset, rect.Y),
                            new PointF(rect.X, rect.Y),
                            new PointF(rect.X, rect.Y + rect.Height),
                            new PointF(rect.X + rect.Width, rect.Y + rect.Height),
                            new PointF(rect.X + rect.Width, rect.Y),
                            new PointF(rect.X + _title_offset + _title_space * 2 + size.Width, rect.Y) });
                    }
                    else
                    {
                        GraphicsPath path = new GraphicsPath();
                        if (_title_offset > _corner_radius)
                            path.AddLine(rect.X + _title_offset, rect.Y, rect.X + _title_offset - _corner_radius, rect.Y);
                        path.AddArc(rect.X, rect.Y, _corner_radius * 2, _corner_radius * 2, -90, -90);
                        path.AddLine(rect.X, rect.Y + _corner_radius, rect.X, rect.Y + rect.Height - _corner_radius);
                        path.AddArc(rect.X, rect.Y + rect.Height - _corner_radius * 2, _corner_radius * 2, _corner_radius * 2, -180, -90);
                        path.AddLine(rect.X + _corner_radius, rect.Y + rect.Height, rect.X + rect.Width - _corner_radius, rect.Y + rect.Height);
                        path.AddArc(rect.X + rect.Width - _corner_radius * 2, rect.Y + rect.Height - _corner_radius * 2, _corner_radius * 2, _corner_radius * 2, 90, -90);
                        path.AddLine(rect.X + rect.Width, rect.Y + rect.Height - _corner_radius, rect.X + rect.Width, rect.Y + _corner_radius);
                        path.AddArc(rect.X + rect.Width - _corner_radius * 2, rect.Y, _corner_radius * 2, _corner_radius * 2, 0, -90);
                        if (Width - size.Width - _title_space * 2 - _title_offset > _corner_radius)
                            path.AddLine(rect.X + rect.Width - _corner_radius, rect.Y, rect.X + _title_offset + _title_space * 2 + size.Width, rect.Y);
                        g.DrawPath(pen, path);
                    }
                }
                using (var brush = new SolidBrush(_title_fore_color))
                    g.DrawString(_title_text, _title_font, brush, new PointF(_title_offset + _title_space, 0));
                int line_edge = Convert.ToInt32(Math.Ceiling(_bounds_width / 2));
                Padding padding;
                if (TitleText.isNull())
                    padding = new Padding(line_edge);
                else
                    padding = new Padding(line_edge, Convert.ToInt32(size.Height + line_edge), line_edge, line_edge);
                Padding = new Padding(Math.Max(Padding.Left, padding.Left), Math.Max(Padding.Top, padding.Top), Math.Max(Padding.Right, padding.Right), Math.Max(Padding.Bottom, padding.Bottom));
            }
            BackgroundImage = image;
        }
        #endregion
    }
}