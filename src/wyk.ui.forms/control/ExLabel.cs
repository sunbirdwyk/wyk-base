using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using wyk.basic;

namespace wyk.ui
{
    public class ExLabel : Label
    {
        public ExLabel()
        {
            setStyles();
            this.BackColor = Color.Transparent;
            this.Font = new Font("微软雅黑", 9, FontStyle.Regular);
        }

        #region private properties
        Color _text_border_color = Color.Transparent;
        float _text_border_width = 0;
        BorderConfig _box_border = new BorderConfig(BorderStyleEx.None);
        Color _box_border_color = Color.Transparent;
        float _text_rotation = 0;
        Color _back_color = Color.Transparent;
        #endregion

        #region custom properties
        [Description("文字描边颜色")]
        public Color TextBorderColor
        {
            get => _text_border_color;
            set => _text_border_color = value;
        }

        [Description("文字描边宽度")]
        public float TextBorderWidth
        {
            get => _text_border_width;
            set => _text_border_width = value;
        }

        [Description("控件边框颜色")]
        public Color BoxBorderColor
        {
            get => _box_border_color;
            set => _box_border_color = value;
        }

        [Description("控件边框设置")]
        public BorderConfig BoxBorder
        {
            get => _box_border;
            set => _box_border = value;
        }

        [Description("文字旋转角度")]
        public float TextRotation
        {
            get => _text_rotation;
            set => _text_rotation = value;
        }

        [Description("背景色")]
        public new Color BackColor
        {
            get => _back_color;
            set => _back_color = value;
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
        public new bool UseWaitCursor
        {
            get => base.UseWaitCursor;
            set => base.UseWaitCursor = value;
        }
        #endregion

        #region overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            drawBox(e.Graphics);
            drawText(e.Graphics);
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

        private void drawText(Graphics g)
        {
            if (Text.isNull())
                return;
            SizeF size = this.Text.measure(g, this.Font);
            PointF center = new PointF((float)(Width-1) / 2, (float)(Height-1) / 2);
            PointF text_start = new PointF(center.X - size.Width / 2, center.Y - size.Height / 2);
            Matrix o_matrix = g.Transform;
            Matrix matrix = g.Transform;
            SizeF new_size = size;
            if (_text_rotation != 0)
            {
                //以中心为原点旋转
                matrix.RotateAt(_text_rotation, center);
                g.Transform = matrix;
                new_size = getRotatedTextSize(size, _text_rotation);
            }
            if (_text_border_color == Color.Transparent || _text_border_width <= 0)
            {
                //只有旋转没有描边时, 使用DrawString, 因为使用DrawPath方法如果文字字号较小时会不太清晰
                g.DrawString(Text, Font, new SolidBrush(ForeColor), text_start);
            }
            else
            {
                //有描边时, 使用DrawPath
                float font_size = g.DpiY * this.Font.SizeInPoints / 72;
                GraphicsPath draw_path = new GraphicsPath();
                draw_path.AddString(this.Text, this.Font.FontFamily, (int)this.Font.Style, font_size, text_start, StringFormat.GenericTypographic);
                g.FillPath(new SolidBrush(ForeColor), draw_path);
                g.DrawPath(new Pen(_text_border_color, _text_border_width), draw_path);
            }
            if (_text_rotation != 0)
            {
                g.Transform = o_matrix;
            }
            if (AutoSize && _text_rotation != 0)
                AutoSize = false;
            //由于绘图完之后无法位移, 所以只能定义大小为它的最小大小
            if (AutoSize)
            {
                Width = Convert.ToInt32(Math.Ceiling(new_size.Width)) + Padding.Left + Padding.Right;
                Height = Convert.ToInt32(Math.Ceiling(new_size.Height)) + Padding.Top + Padding.Bottom;
            }
        }

        private SizeF getRotatedTextSize(SizeF size, float angle)
        {
            Matrix matrix = new Matrix();
            matrix.Rotate(angle);
            // 旋转矩形四个顶点, 原点为矩形中心
            PointF[] pts = new PointF[4];
            pts[0].X = -size.Width / 2f;
            pts[0].Y = -size.Height / 2f;
            pts[1].X = -size.Width / 2f;
            pts[1].Y = size.Height / 2f;
            pts[2].X = size.Width / 2f;
            pts[2].Y = size.Height / 2f;
            pts[3].X = size.Width / 2f;
            pts[3].Y = -size.Height / 2f;
            matrix.TransformPoints(pts);
            //获取4个顶点边界的X,Y值
            float left = float.MaxValue;
            float right = float.MinValue;
            float top = float.MaxValue;
            float bottom = float.MinValue;
            foreach (PointF pt in pts)
            {
                if (pt.X < left)
                    left = pt.X;
                if (pt.X > right)
                    right = pt.X;
                if (pt.Y < top)
                    top = pt.Y;
                if (pt.Y > bottom)
                    bottom = pt.Y;
            }
            SizeF result = new SizeF(right - left, bottom - top);
            return result;
        }

        private void drawBox(Graphics g)
        {
            _box_border.drawBorderAndBackground(g, new Rectangle(0, 0, Width - 1, Height - 1), _box_border_color, BackColor);
        }
        #endregion
    }
}