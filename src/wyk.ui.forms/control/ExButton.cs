using wyk.basic;
using wyk.ui.enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace wyk.ui
{
    /// <summary>
    /// 扩展的按钮, 可以自定义图片大小/位置和文字的样式, 边框样式等
    /// </summary>
    public class ExButton : Button
    {
        public ExButton()
        {
            setStyles();
            initializeProperties();
        }

        #region private properties
        /// <summary>
        /// 边框样式
        /// </summary>
        private BorderConfig _border = new BorderConfig(BorderStyleEx.None);
        private ColorGroup _border_color = new ColorGroup();
        /// <summary>
        /// 背景颜色
        /// </summary>
        private ColorGroup _back_color = new ColorGroup(Color.Transparent);
        /// <summary>
        /// 文字颜色
        /// </summary>
        private ColorGroup _fore_color = new ColorGroup();
        /// <summary>
        /// 图片
        /// </summary>
        private ImageGroup _image = new ImageGroup();
        /// <summary>
        /// 图片和文字间的距离(如果都存在的话)
        /// </summary>
        private int _text_image_space = 2;
        /// <summary>
        /// 图片大小
        /// </summary>
        private Size _image_size = new Size(20, 20);
        /// <summary>
        /// 图片的悬停方式, 在不为None时, image_size只有部分值管用
        /// </summary>
        private DockStyle _image_dock = DockStyle.None;
        /// <summary>
        /// 当前button的状态
        /// </summary>
        private ControlState _control_state = ControlState.Normal;
        /// <summary>
        /// 当前button的选中状态
        /// </summary>
        private bool _selected = false;
        #endregion

        #region custom properties
        [Description("边框样式")]
        public BorderConfig BorderStyle
        {
            get => _border;
            set => _border = value;
        }

        [Description("边框颜色")]
        public ColorGroup BorderColor
        {
            get => _border_color;
            set => _border_color = value;
        }

        [Description("图片和文字间的距离")]
        public int TextImageSpace
        {
            get => _text_image_space;
            set => _text_image_space = value;
        }

        [Description("图片大小, ImageDock不为None时, 只有部分值有效")]
        public Size ImageSize
        {
            get => _image_size;
            set => _image_size = value;
        }

        [Description("图片悬停方式, 为Fill时, Text不显示")]
        public DockStyle ImageDock
        {
            get => _image_dock;
            set => _image_dock = value;
        }
        [Description("选中状态")]
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                if (_selected)
                    _control_state = ControlState.Focus;
                else
                    _control_state = ControlState.Normal;
                Refresh();
            }
        }
        #endregion

        #region override properties
        [Description("按钮图片")]
        public new ImageGroup Image
        {
            get => _image;
            set => _image = value;
        }

        [Description("背景色")]
        public new ColorGroup BackColor
        {
            get => _back_color;
            set => _back_color = value;
        }

        [Description("前景色")]
        public new ColorGroup ForeColor
        {
            get => _fore_color;
            set => _fore_color = value;
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
            if (_selected)
                _control_state = ControlState.Focus;
            else
                _control_state = ControlState.Highlight;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_selected)
                _control_state = ControlState.Focus;
            else
                _control_state = ControlState.Normal;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (_selected)
                _control_state = ControlState.Focus;
            else
                _control_state = ControlState.Down;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (_selected)
                _control_state = ControlState.Focus;
            else
                _control_state = ControlState.Highlight;
            base.OnMouseUp(mevent);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
            {
                if (_selected)
                    _control_state = ControlState.Focus;
                else
                    _control_state = ControlState.Normal;
            }
            else
                _control_state = ControlState.Disabled;
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
                _control_state = ControlState.Disabled;
            drawContents(g);
        }
        #endregion

        #region public functions
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
            this.FlatAppearance.CheckedBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            base.BackColor = Color.Transparent;
            base.ForeColor = Color.Transparent;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        private void drawContents(Graphics g)
        {
            Rectangle rect = ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            Color back_color = Color.Transparent;
            Color border_color = Color.Transparent;
            Color fore_color = Color.Black;
            Image image = null;

            switch (_control_state)
            {
                case ControlState.Normal:
                default:
                    border_color = _border_color.Normal;
                    back_color = _back_color.Normal;
                    fore_color = _fore_color.Normal;
                    image = _image.Normal;
                    break;
                case ControlState.Disabled:
                    border_color = _border_color.Disabled;
                    back_color = _back_color.DisabledForBackground;
                    fore_color = _fore_color.Disabled;
                    image = _image.Disabled;
                    break;
                case ControlState.Down:
                case ControlState.Focus:
                    border_color = _border_color.Clicked;
                    back_color = _back_color.Clicked;
                    fore_color = _fore_color.Clicked;
                    image = _image.Clicked;
                    break;
                case ControlState.Highlight:
                    border_color = _border_color.Hovered;
                    back_color = _back_color.Hovered;
                    fore_color = _fore_color.Hovered;
                    image = _image.Hovered;
                    break;
            }

            _border.drawBorderAndBackground(g, rect, border_color, back_color);

            RectangleF content_rect = rect;
            content_rect.X += _border.Width + Padding.Left;
            content_rect.Y += _border.Width + Padding.Top;
            content_rect.Width -= _border.Width * 2 + Padding.Left + Padding.Right;
            content_rect.Height -= _border.Width * 2 + Padding.Top + Padding.Bottom;
            calculateContentRects(g, image != null, content_rect, out RectangleF image_rect, out RectangleF text_rect);
            if (image != null && image_rect != Rectangle.Empty)
                g.DrawImage(image, image_rect);
            if (Text != "" && text_rect != Rectangle.Empty)
                g.drawTextInRect(text_rect, Text, Font, fore_color, TextAlign);
        }

        private void calculateContentRects(Graphics g, bool show_image, RectangleF content_rect, out RectangleF image_rect, out RectangleF text_rect)
        {
            image_rect = RectangleF.Empty;
            text_rect = RectangleF.Empty;
            if (!show_image)
            {
                if (Text == null || Text == "")
                    return;
                else
                    text_rect = content_rect;
            }
            else
            {
                if (Text == null || Text == "")
                {
                    switch (_image_dock)
                    {
                        case DockStyle.None:
                            //只有ImageDock为None时,TextAlign属性才管用
                            switch (TextAlign)
                            {
                                case ContentAlignment.TopLeft:
                                    image_rect = new RectangleF(content_rect.X, content_rect.Y, _image_size.Width, _image_size.Height);
                                    break;
                                case ContentAlignment.TopCenter:
                                    image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, content_rect.Y, _image_size.Width, _image_size.Height);
                                    break;
                                case ContentAlignment.TopRight:
                                    image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y, _image_size.Width, _image_size.Height);
                                    break;
                                case ContentAlignment.MiddleLeft:
                                    image_rect = new RectangleF(content_rect.X, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                    break;
                                case ContentAlignment.MiddleCenter:
                                    image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                    break;
                                case ContentAlignment.MiddleRight:
                                    image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                    break;
                                case ContentAlignment.BottomLeft:
                                    image_rect = new RectangleF(content_rect.X, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                    break;
                                case ContentAlignment.BottomCenter:
                                    image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                    break;
                                case ContentAlignment.BottomRight:
                                    image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                    break;
                            }
                            break;
                        case DockStyle.Top:
                            image_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width, _image_size.Height);
                            break;
                        case DockStyle.Right:
                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y, _image_size.Width, content_rect.Height);
                            break;
                        case DockStyle.Bottom:
                            image_rect = new RectangleF(content_rect.X, content_rect.Y + content_rect.Height - _image_size.Height, content_rect.Width, _image_size.Height);
                            break;
                        case DockStyle.Left:
                            image_rect = new RectangleF(content_rect.X, content_rect.Y, _image_size.Width, content_rect.Height);
                            break;
                        case DockStyle.Fill:
                            image_rect = content_rect;
                            break;
                    }
                }
                else
                {
                    switch (_image_dock)
                    {
                        case DockStyle.None:
                            //只有ImageDock为None时,TextAlign属性才管用
                            float start;
                            SizeF size;
                            switch (TextAlign)
                            {
                                case ContentAlignment.TopLeft:
                                    switch (TextImageRelation)
                                    {
                                        case TextImageRelation.Overlay:
                                            image_rect = new RectangleF(content_rect.X, content_rect.Y, _image_size.Width, _image_size.Height);
                                            text_rect = content_rect;
                                            break;
                                        case TextImageRelation.ImageAboveText:
                                            image_rect = new RectangleF(content_rect.X, content_rect.Y, _image_size.Width, _image_size.Height);
                                            start = content_rect.Y + _image_size.Height + _text_image_space;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, content_rect.Height - start);
                                            break;
                                        case TextImageRelation.ImageBeforeText:
                                            image_rect = new RectangleF(content_rect.X, content_rect.Y, _image_size.Width, _image_size.Height);
                                            start = content_rect.X + _image_size.Width + _text_image_space;
                                            text_rect = new RectangleF(start, content_rect.Y, content_rect.Width - start, content_rect.Height);
                                            break;
                                        case TextImageRelation.TextAboveImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width, size.Height);
                                            start = content_rect.Y + size.Height + _text_image_space;
                                            image_rect = new RectangleF(content_rect.X, start, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.TextBeforeImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, size.Width, size.Height);
                                            start = content_rect.X + size.Width + _text_image_space;
                                            image_rect = new RectangleF(start, content_rect.Y, _image_size.Width, _image_size.Height);
                                            break;
                                    }
                                    break;
                                case ContentAlignment.TopCenter:
                                    switch (TextImageRelation)
                                    {
                                        case TextImageRelation.Overlay:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, content_rect.Y, _image_size.Width, _image_size.Height);
                                            text_rect = content_rect;
                                            break;
                                        case TextImageRelation.ImageAboveText:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, content_rect.Y, _image_size.Width, _image_size.Height);
                                            start = content_rect.Y + _image_size.Height + _text_image_space;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, content_rect.Height - start);
                                            break;
                                        case TextImageRelation.ImageBeforeText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            start = content_rect.X + content_rect.Width / 2 - (size.Width + _image_size.Width + _text_image_space) / 2;
                                            image_rect = new RectangleF(start, content_rect.Y, _image_size.Width, _image_size.Height);
                                            start += _image_size.Width + _text_image_space;
                                            text_rect = new RectangleF(start, content_rect.Y, size.Width, content_rect.Height);
                                            break;
                                        case TextImageRelation.TextAboveImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width, size.Height);
                                            start = content_rect.Y + size.Height + _text_image_space;
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, start, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.TextBeforeImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            start = content_rect.X + content_rect.Width / 2 - (size.Width + _image_size.Width + _text_image_space) / 2;
                                            text_rect = new RectangleF(start, content_rect.Y, size.Width, size.Height);
                                            start += size.Width + _text_image_space;
                                            image_rect = new RectangleF(start, content_rect.Y, _image_size.Width, _image_size.Height);
                                            break;
                                    }
                                    break;
                                case ContentAlignment.TopRight:
                                    switch (TextImageRelation)
                                    {
                                        case TextImageRelation.Overlay:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y, _image_size.Width, _image_size.Height);
                                            text_rect = content_rect;
                                            break;
                                        case TextImageRelation.ImageAboveText:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y, _image_size.Width, _image_size.Height);
                                            start = content_rect.Y + _image_size.Height + _text_image_space;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, content_rect.Height - start);
                                            break;
                                        case TextImageRelation.ImageBeforeText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - size.Width - _text_image_space - _image_size.Width, content_rect.Y, _image_size.Width, _image_size.Height);
                                            text_rect = new RectangleF(content_rect.X + content_rect.Width - size.Width, content_rect.Y, size.Width, content_rect.Height);
                                            break;
                                        case TextImageRelation.TextAboveImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width, size.Height);
                                            start = content_rect.Y + size.Height + _text_image_space;
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, start, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.TextBeforeImage:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y, _image_size.Width, _image_size.Height);
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width - _image_size.Width - _text_image_space, content_rect.Height);
                                            break;
                                    }
                                    break;
                                case ContentAlignment.MiddleLeft:
                                    switch (TextImageRelation)
                                    {
                                        case TextImageRelation.Overlay:
                                            image_rect = new RectangleF(content_rect.X, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                            text_rect = content_rect;
                                            break;
                                        case TextImageRelation.ImageAboveText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            start = content_rect.Y + content_rect.Height / 2 - (_image_size.Height + _text_image_space + size.Height) / 2;
                                            image_rect = new RectangleF(content_rect.X, start, _image_size.Width, _image_size.Height);
                                            start += _image_size.Height + _text_image_space;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, size.Height);
                                            break;
                                        case TextImageRelation.ImageBeforeText:
                                            image_rect = new RectangleF(content_rect.X, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                            start = content_rect.X + _image_size.Width + _text_image_space;
                                            text_rect = new RectangleF(start, content_rect.Y, content_rect.Width - start, content_rect.Height);
                                            break;
                                        case TextImageRelation.TextAboveImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            start = content_rect.Y + content_rect.Height / 2 - (_image_size.Height + _text_image_space + size.Height) / 2;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, size.Height);
                                            start += size.Height + _text_image_space;
                                            image_rect = new RectangleF(content_rect.X, start, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.TextBeforeImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, size.Width, size.Height);
                                            start = content_rect.X + size.Width + _text_image_space;
                                            image_rect = new RectangleF(start, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                            break;
                                    }
                                    break;
                                case ContentAlignment.MiddleCenter:
                                    switch (TextImageRelation)
                                    {
                                        case TextImageRelation.Overlay:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                            text_rect = content_rect;
                                            break;
                                        case TextImageRelation.ImageAboveText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            start = content_rect.Y + content_rect.Height / 2 - (size.Height + _text_image_space + _image_size.Height) / 2;
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, start, _image_size.Width, _image_size.Height);
                                            start += _image_size.Height + _text_image_space;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, size.Height);
                                            break;
                                        case TextImageRelation.ImageBeforeText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            start = content_rect.X + content_rect.Width / 2 - (size.Width + _image_size.Width + _text_image_space) / 2;
                                            image_rect = new RectangleF(start, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                            start += _image_size.Width + _text_image_space;
                                            text_rect = new RectangleF(start, content_rect.Y, size.Width, content_rect.Height);
                                            break;
                                        case TextImageRelation.TextAboveImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            start = content_rect.Y + content_rect.Height / 2 - (size.Height + _text_image_space + _image_size.Height) / 2;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, size.Height);
                                            start += size.Height + _text_image_space;
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, start, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.TextBeforeImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            start = content_rect.X + content_rect.Width / 2 - (size.Width + _image_size.Width + _text_image_space) / 2;
                                            text_rect = new RectangleF(start, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, size.Width, size.Height);
                                            start += size.Width + _text_image_space;
                                            image_rect = new RectangleF(start, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                            break;
                                    }
                                    break;
                                case ContentAlignment.MiddleRight:
                                    switch (TextImageRelation)
                                    {
                                        case TextImageRelation.Overlay:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                            text_rect = content_rect;
                                            break;
                                        case TextImageRelation.ImageAboveText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            start = content_rect.Y + content_rect.Height / 2 - (size.Height + _image_size.Height + _text_image_space) / 2;
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, start, _image_size.Width, _image_size.Height);
                                            start += _image_size.Height + _text_image_space;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, size.Height);
                                            break;
                                        case TextImageRelation.ImageBeforeText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            start = content_rect.X + content_rect.Width - size.Width;
                                            text_rect = new RectangleF(start, content_rect.Y, size.Width, content_rect.Height);
                                            start -= _image_size.Width + _text_image_space;
                                            image_rect = new RectangleF(start, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.TextAboveImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            start = content_rect.Y + content_rect.Height / 2 - (size.Height + _image_size.Height + _text_image_space) / 2;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, size.Height);
                                            start += size.Height + _text_image_space;
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, start, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.TextBeforeImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y + content_rect.Height / 2 - _image_size.Height / 2, _image_size.Width, _image_size.Height);
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width - _image_size.Width - _text_image_space, content_rect.Height);
                                            break;
                                    }
                                    break;
                                case ContentAlignment.BottomLeft:
                                    switch (TextImageRelation)
                                    {
                                        case TextImageRelation.Overlay:
                                            image_rect = new RectangleF(content_rect.X, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            text_rect = content_rect;
                                            break;
                                        case TextImageRelation.ImageAboveText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            start = content_rect.Y + content_rect.Height - size.Height;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, size.Height);
                                            start -= _image_size.Height + _text_image_space;
                                            image_rect = new RectangleF(content_rect.X, start, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.ImageBeforeText:
                                            image_rect = new RectangleF(content_rect.X, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            start = content_rect.X + _image_size.Width + _text_image_space;
                                            text_rect = new RectangleF(start, content_rect.Y, content_rect.Width - start, content_rect.Height);
                                            break;
                                        case TextImageRelation.TextAboveImage:
                                            image_rect = new RectangleF(content_rect.X, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width, content_rect.Height - _image_size.Height - _text_image_space);
                                            break;
                                        case TextImageRelation.TextBeforeImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, size.Width, content_rect.Height);
                                            start = content_rect.X + size.Width + _text_image_space;
                                            image_rect = new RectangleF(start, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            break;
                                    }
                                    break;
                                case ContentAlignment.BottomCenter:
                                    switch (TextImageRelation)
                                    {
                                        case TextImageRelation.Overlay:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            text_rect = content_rect;
                                            break;
                                        case TextImageRelation.ImageAboveText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            start = content_rect.Y + content_rect.Height - size.Height;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, size.Height);
                                            start -= _image_size.Height + _text_image_space;
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, start, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.ImageBeforeText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            start = content_rect.X + content_rect.Width / 2 - (size.Width + _image_size.Width + _text_image_space) / 2;
                                            image_rect = new RectangleF(start, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            start += _image_size.Width + _text_image_space;
                                            text_rect = new RectangleF(start, content_rect.Y, size.Width, content_rect.Height);
                                            break;
                                        case TextImageRelation.TextAboveImage:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width / 2 - _image_size.Width / 2, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width, content_rect.Height - _image_size.Height - _text_image_space);
                                            break;
                                        case TextImageRelation.TextBeforeImage:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            start = content_rect.X + content_rect.Width / 2 - (size.Width + _image_size.Width + _text_image_space) / 2;
                                            text_rect = new RectangleF(start, content_rect.Y, size.Width, content_rect.Height);
                                            start += size.Width + _text_image_space;
                                            image_rect = new RectangleF(start, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            break;
                                    }
                                    break;
                                case ContentAlignment.BottomRight:
                                    switch (TextImageRelation)
                                    {
                                        case TextImageRelation.Overlay:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            text_rect = content_rect;
                                            break;
                                        case TextImageRelation.ImageAboveText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Height > content_rect.Height - (_text_image_space + _image_size.Height))
                                                size.Height = content_rect.Height - _text_image_space - _image_size.Height;
                                            start = content_rect.Y + content_rect.Height - size.Height;
                                            text_rect = new RectangleF(content_rect.X, start, content_rect.Width, size.Height);
                                            start -= _image_size.Height + _text_image_space;
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, start, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.ImageBeforeText:
                                            size = Text.measureF(g, Font, content_rect.Width);
                                            if (size.Width > content_rect.Width - (_text_image_space + _image_size.Width))
                                                size.Width = content_rect.Width - _text_image_space - _image_size.Width;
                                            start = content_rect.X + content_rect.Width - size.Width;
                                            text_rect = new RectangleF(start, content_rect.Y, size.Width, content_rect.Height);
                                            start -= _image_size.Width + _text_image_space;
                                            image_rect = new RectangleF(start, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            break;
                                        case TextImageRelation.TextAboveImage:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width, content_rect.Height - _image_size.Height - _text_image_space);
                                            break;
                                        case TextImageRelation.TextBeforeImage:
                                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y + content_rect.Height - _image_size.Height, _image_size.Width, _image_size.Height);
                                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width - _image_size.Width - _text_image_space, content_rect.Height);
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case DockStyle.Top:
                            image_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width, _image_size.Height);
                            text_rect = new RectangleF(content_rect.X, content_rect.Y + _image_size.Height + _text_image_space, content_rect.Width, content_rect.Height - _image_size.Height - _text_image_space);
                            break;
                        case DockStyle.Right:
                            image_rect = new RectangleF(content_rect.X + content_rect.Width - _image_size.Width, content_rect.Y, _image_size.Width, content_rect.Height);
                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width - _image_size.Width - _text_image_space, content_rect.Height);
                            break;
                        case DockStyle.Bottom:
                            image_rect = new RectangleF(content_rect.X, content_rect.Y + content_rect.Height - _image_size.Height, content_rect.Width, _image_size.Height);
                            text_rect = new RectangleF(content_rect.X, content_rect.Y, content_rect.Width, content_rect.Height - _image_size.Height - _text_image_space);
                            break;
                        case DockStyle.Left:
                            image_rect = new RectangleF(content_rect.X, content_rect.Y, _image_size.Width, content_rect.Height);
                            text_rect = new RectangleF(content_rect.X + _image_size.Width + _text_image_space, content_rect.Y, content_rect.Width - _image_size.Width - _text_image_space, content_rect.Height);
                            break;
                        case DockStyle.Fill:
                            image_rect = content_rect;
                            break;
                    }
                }
            }
        }
        #endregion
    }
}