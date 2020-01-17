using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using wyk.basic;
using wyk.ui.model;

namespace wyk.ui
{
    public class ExProgressBar : Panel
    {
        public ExProgressBar()
        {
            setStyles();
            base.BackColor = Color.Transparent;
            this.Font = new Font("微软雅黑", 9, FontStyle.Regular);
            this.Size = new Size(200, 30);
        }

        #region private properties
        Color _edge_color = Color.Transparent;
        int _edge_width = 1;
        int _corner_radius = 0;
        int _current_value = 0;
        Color[] _progress_step_color = new Color[] { Color.ForestGreen };
        int[] _progress_step_value = new int[] { 100 };
        Color _back_color = Color.FromArgb(150, 0, 0, 0);
        string _current_text = "";
        ContentAlignment _text_align = ContentAlignment.MiddleCenter;
        GradientColorSetSimple _primary_gradient = new GradientColorSetSimple(GradientStyle.None, 90);
        int _left_bar_width = 0;
        TextBlock _left_bar = new TextBlock(Color.Black, Color.White);
        GradientColorSetSimple _left_bar_gradient = new GradientColorSetSimple(GradientStyle.None, 90);
        int _right_bar_width = 0;
        TextBlock _right_bar = new TextBlock(Color.Black, Color.White);
        GradientColorSetSimple _right_bar_gradient = new GradientColorSetSimple(GradientStyle.None, 90);
        int _top_bar_height = 0;
        TextBlock _top_bar = new TextBlock(Color.Purple, Color.White);
        GradientColorSetSimple _top_bar_gradient = new GradientColorSetSimple(GradientStyle.None, 90);
        int _bottom_bar_height = 0;
        TextBlock _bottom_bar = new TextBlock(Color.Purple, Color.White);
        GradientColorSetSimple _bottom_bar_gradient = new GradientColorSetSimple(GradientStyle.None, 90);
        #endregion

        #region custom properties
        [Description("边框颜色")]
        public Color EdgeColor
        {
            get => _edge_color;
            set { _edge_color = value; Refresh(); }
        }
        [Description("边框宽度")]
        public int EdgeWidth
        {
            get => _edge_width;
            set { _edge_width = value; Refresh(); }
        }
        [Description("边角圆角半径")]
        public int CornerRadius
        {
            get => _corner_radius;
            set { _corner_radius = value; Refresh(); }
        }
        [Description("当前值(0~100")]
        public int CurrentValue
        {
            get => _current_value;
            set
            {
                if (value <= 0)
                    _current_value = 0;
                else if (value >= 100)
                    _current_value = 100;
                else
                    _current_value = value;
                Refresh();
            }
        }
        [Description("分段进度颜色, 跟ProgressStepValue对应")]
        public Color[] ProgressStepColor
        {
            get => _progress_step_color;
            set { _progress_step_color = value; Refresh(); }
        }
        [Description("分段进度值, 多个值相加为100, 超过100的部分不会起作用")]
        public int[] ProgressStepValue
        {
            get => _progress_step_value;
            set { _progress_step_value = value; Refresh(); }
        }
        [Description("进度条主体提示文字(通常为当前百分比)")]
        public string CurrentText
        {
            get => _current_text;
            set { _current_text = value; Refresh(); }
        }
        [Description("进度条主体提示文字的对齐方式")]
        public ContentAlignment TextAlign
        {
            get => _text_align;
            set { _text_align = value; Refresh(); }
        }

        [Description("左方文字宽度")]
        public int LeftBarWidth
        {
            get => _left_bar_width;
            set { _left_bar_width = value; Refresh(); }
        }
        [Description("左方文字设置")]
        public TextBlock LeftBar
        {
            get => _left_bar;
            set { _left_bar = value; Refresh(); }
        }
        [Description("右方文字宽度")]
        public int RightBarWidth
        {
            get => _right_bar_width;
            set { _right_bar_width = value; Refresh(); }
        }
        [Description("右方文字设置")]
        public TextBlock RightBar
        {
            get => _right_bar;
            set { _right_bar = value; Refresh(); }
        }
        [Description("上方文字高度")]
        public int TopBarHeight
        {
            get => _top_bar_height;
            set { _top_bar_height = value; Refresh(); }
        }
        [Description("上方文字设置")]
        public TextBlock TopBar
        {
            get => _top_bar;
            set { _top_bar = value; Refresh(); }
        }
        [Description("下方文字宽度")]
        public int BottomBarHeight
        {
            get => _bottom_bar_height;
            set { _bottom_bar_height = value; Refresh(); }
        }
        [Description("下方文字设置")]
        public TextBlock BottomBar
        {
            get => _bottom_bar;
            set { _bottom_bar = value; Refresh(); }
        }
        [Description("主渐变方式")]
        public GradientColorSetSimple PrimaryGradient
        {
            get => _primary_gradient;
            set
            {
                _primary_gradient = value;
                Refresh();
            }
        }
        [Description("左方文字条渐变方式")]
        public GradientColorSetSimple LeftBarGradient
        {
            get => _left_bar_gradient;
            set
            {
                _left_bar_gradient = value;
                Refresh();
            }
        }
        [Description("右方文字条渐变方式")]
        public GradientColorSetSimple RightBarGradient
        {
            get => _right_bar_gradient;
            set
            {
                _right_bar_gradient = value;
                Refresh();
            }
        }
        [Description("上方文字条渐变方式")]
        public GradientColorSetSimple TopBarGradient
        {
            get => _top_bar_gradient;
            set
            {
                _top_bar_gradient = value;
                Refresh();
            }
        }
        [Description("下方文字条渐变方式")]
        public GradientColorSetSimple BottomBarGradient
        {
            get => _bottom_bar_gradient;
            set
            {
                _bottom_bar_gradient = value;
                Refresh();
            }
        }
        #endregion

        #region override properties
        [Description("进度条背景色")]
        public new Color BackColor
        {
            get => _back_color;
            set { _back_color = value; Refresh(); }
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
        public new BorderStyle BorderStyle
        {
            get => base.BorderStyle;
            set => base.BorderStyle = value;
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
        public new ImeMode ImeMode
        {
            get => base.ImeMode;
            set => base.ImeMode = value;
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

        #region overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
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
            Rectangle rect;
            if (_left_bar_width > 0)
            {//左边条
                rect = new Rectangle(0, 0, _left_bar_width, Height);
                drawGradientBar(g, rect, _left_bar_gradient.colorSet(_left_bar.BackColor));
                if (_left_bar.Text.Trim() != "")
                    g.drawTextInRect(rect, _left_bar.Text, _left_bar.Font, _left_bar.ForeColor, _left_bar.TextAlign);
            }
            if (_right_bar_width > 0)
            {//右边条
                rect = new Rectangle(Width - _right_bar_width, 0, _right_bar_width, Height);
                drawGradientBar(g, rect, _right_bar_gradient.colorSet(_right_bar.BackColor));
                if (_right_bar.Text.Trim() != "")
                    g.drawTextInRect(rect, _right_bar.Text, _right_bar.Font, _right_bar.ForeColor, _right_bar.TextAlign);
            }
            if (_top_bar_height > 0)
            {//上边条
                rect = new Rectangle(_left_bar_width, 0, Width - _left_bar_width - _right_bar_width, _top_bar_height);
                drawGradientBar(g, rect, _top_bar_gradient.colorSet(_top_bar.BackColor));
                if (_top_bar.Text.Trim() != "")
                    g.drawTextInRect(rect, _top_bar.Text, _top_bar.Font, _top_bar.ForeColor, _top_bar.TextAlign);
            }
            if (_bottom_bar_height > 0)
            {//下边条
                rect = new Rectangle(_left_bar_width, Height - _bottom_bar_height, Width - _left_bar_width - _right_bar_width, _bottom_bar_height);
                drawGradientBar(g, rect, _bottom_bar_gradient.colorSet(_bottom_bar.BackColor));
                if (_bottom_bar.Text.Trim() != "")
                    g.drawTextInRect(rect, _bottom_bar.Text, _bottom_bar.Font, _bottom_bar.ForeColor, _bottom_bar.TextAlign);
            }
            //进度条背景
            rect = new Rectangle(_left_bar_width, _top_bar_height, Width - _left_bar_width - _right_bar_width, Height - _top_bar_height - _bottom_bar_height);
            drawGradientBar(g, rect, _primary_gradient.colorSet(BackColor));
            //进度条值
            Color value_color = Color.ForestGreen;
            int current_max = 0;
            int step_index = -1;
            for (int i = 0; i < _progress_step_value.Length; i++)
            {
                current_max += _progress_step_value[i];
                if (current_max > 100)
                    current_max = 100;
                if (_current_value < current_max)
                {
                    step_index = i;
                    break;
                }
                if (current_max == 100)
                    break;
            }
            if (step_index < 0)
                step_index = _progress_step_value.Length + 1;
            if (step_index < _progress_step_color.Length)
                value_color = _progress_step_color[step_index];
            else if (_progress_step_color.Length > 0)
                value_color = _progress_step_color[_progress_step_color.Length - 1];
            Rectangle value_rect = new Rectangle(rect.Location, new Size(rect.Width * _current_value / 100, rect.Height));
            drawGradientBar(g, value_rect, _primary_gradient.colorSet(value_color));
            //进度提示文字
            if (_current_text.Trim() != "")
                g.drawTextInRect(rect, _current_text, Font, ForeColor, TextAlign);
            //边框
            if (_edge_color != Color.Transparent && _edge_width > 0)
                g.drawRoundedRectangle(new Pen(_edge_color, _edge_width), new Rectangle(0, 0, Width - 1, Height - 1), _corner_radius);
        }

        /// <summary>
        /// 根据矩形获取圆角位置Filter
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        private RectangleCorner getCornerFilter(Rectangle rect)
        {
            RectangleCorner filter = RectangleCorner.None;
            if (rect.X == 0 && rect.Y == 0)
                filter |= RectangleCorner.TopLeft;
            if (rect.X == 0 && rect.Y + rect.Height == this.Height)
                filter |= RectangleCorner.BottomLeft;
            if (rect.X + rect.Width == this.Width && rect.Y == 0)
                filter |= RectangleCorner.TopRight;
            if (rect.X + rect.Width == this.Width && rect.Y + rect.Height == this.Height)
                filter |= RectangleCorner.BottomRight;
            return filter;
        }

        /// <summary>
        /// 绘制渐变条
        /// </summary>
        /// <param name="g"></param>
        /// <param name="color"></param>
        /// <param name="rect"></param>
        private void drawGradientBar(Graphics g, Rectangle rect, GradientColorSet color_set)
        {
            if (rect == Rectangle.Empty)
                return;
            RectangleCorner corner_filter = getCornerFilter(rect);
            GraphicsPath path = g.generateRoundedRectangle(rect, _corner_radius, corner_filter);
            try
            {
                Brush brush = color_set.brush(path);
                g.FillPath(brush, path);
            }
            catch { }
        }
        #endregion
    }
}
