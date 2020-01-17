using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using wyk.basic;
using wyk.ui.consts;
using wyk.ui.enums;

namespace wyk.ui
{
    /// <summary>
    /// ExForm的基类
    /// </summary>
    public partial class ExFormBasic : ExFormBase
    {
        public ExFormBasic()
        {
            InitializeComponent();
            refreshWindowPadding();
            setStyles();
            initializeActionButtons();
        }

        #region private properties
        FormTitleBar _titlebar_style = new FormTitleBar();
        FormStatusBar _statusbar_style = new FormStatusBar();
        private int _edge_width = 0;
        protected ExButton btn_close = null;
        protected ExButton btn_minimize = null;
        protected ExButton btn_maximize = null;
        protected Image _header_image = null;
        protected int _header_height = 100;
        #endregion

        #region custom properties
        [Description("是否在TaskBar中显示程序图标(原ShowIcon)")]
        public bool ShowIconInTaskBar
        {
            get => base.ShowIcon;
            set => base.ShowIcon = value;
        }

        [Description("标题栏样式")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FormTitleBar TitleBar
        {
            get => _titlebar_style;
            set
            {
                _titlebar_style = value;
                refreshWindowPadding();
            }
        }

        [Description("状态栏样式")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FormStatusBar StatusBar
        {
            get => _statusbar_style;
            set
            {
                _statusbar_style = value;
                refreshWindowPadding();
            }
        }

        [Description("边框颜色")]
        public Color EdgeColor { get; set; } = Color.Transparent;

        [Description("边框宽度")]
        public int EdgeWidth
        {
            get => _edge_width;
            set
            {
                _edge_width = value;
                refreshWindowPadding();
            }
        }

        [Description("是否显示程序图标")]
        public bool ShowIconOnUI { get; set; } = true;

        [Description("标题头图片")]
        public Image HeaderImage { get; set; } = null;

        [Description("标题头高度")]
        public int HeaderHeight { get; set; } = 100;
        #endregion

        #region override properties
        #endregion

        #region hided properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool ShowIcon
        {
            get => base.ShowIcon;
            set => base.ShowIcon = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding
        {
            get => base.Padding;
            set => base.Padding = value;
        }
        #endregion

        #region overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btn_close.BringToFront();
            btn_maximize.BringToFront();
            btn_minimize.BringToFront();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            drawHeader(e.Graphics);
            drawTitleBar(e.Graphics);
            drawStatusBar(e.Graphics);
            if (EdgeWidth > 0)
                this.setEdge(EdgeColor, EdgeWidth);
            refreshActionButtons();
        }
        protected override void refreshWindowPadding()
        {
            Padding = new Padding(EdgeWidth, EdgeWidth + (_titlebar_style.ShouldShow ? _titlebar_style.Height : 0), EdgeWidth, EdgeWidth + (_statusbar_style.ShouldShow ? _statusbar_style.Height : 0));
        }
        protected override void processNCMouseAction(ref Message m)  //调整窗体大小
        {
            var point = PointToClient(m.formPosition());
            if (WindowState == FormWindowState.Maximized || !FormResizeable)
            {
                if (point.Y < _titlebar_style.Height + EdgeWidth)
                    m.Result = new IntPtr(WindowHitTest.HTCAPTION);
                else
                    m.Result = new IntPtr(WindowHitTest.HTCLIENT);
                return;
            }
            if (point.X < 3)
            {
                if (point.Y < 3)
                    m.Result = new IntPtr(WindowHitTest.HTTOPLEFT);
                else if (point.Y < Height - 3)
                    m.Result = new IntPtr(WindowHitTest.HTLEFT);
                else
                    m.Result = new IntPtr(WindowHitTest.HTBOTTOMLEFT);
            }
            else if (point.X < Width - 3)
            {
                if (point.Y < 3)
                    m.Result = new IntPtr(WindowHitTest.HTTOP);
                else if (point.Y < _titlebar_style.Height + EdgeWidth)
                    m.Result = new IntPtr(WindowHitTest.HTCAPTION);
                else if (point.Y < Height - 3)
                    m.Result = new IntPtr(WindowHitTest.HTCLIENT);
                else
                    m.Result = new IntPtr(WindowHitTest.HTBOTTOM);
            }
            else
            {
                if (point.Y < 3)
                    m.Result = new IntPtr(WindowHitTest.HTTOPRIGHT);
                else if (point.Y < Height - 3)
                    m.Result = new IntPtr(WindowHitTest.HTRIGHT);
                else
                    m.Result = new IntPtr(WindowHitTest.HTBOTTOMRIGHT);
            }
        }
        #endregion

        #region protected functions
        protected void drawHeader(Graphics g)
        {
            if (HeaderImage == null || HeaderHeight <= 0)
                return;
            Rectangle rect;
            if (_titlebar_style.ShouldShow && _titlebar_style.UIMode == FormTitleBarUIMode.Separated && _titlebar_style.BackColor != Color.Transparent)
                rect = new Rectangle(0, _titlebar_style.Height, Width, HeaderHeight);
            else
                rect = new Rectangle(0, 0, Width, HeaderHeight);
            g.DrawImage(HeaderImage, rect);
        }
        protected void drawTitleBar(Graphics g)
        {
            if (!_titlebar_style.ShouldShow)
                return;
            if (_titlebar_style.UIMode == FormTitleBarUIMode.Separated && _titlebar_style.BackColor != Color.Transparent)
                g.FillRectangle(new SolidBrush(_titlebar_style.BackColor), new Rectangle(0, 0, Width, _titlebar_style.Height + EdgeWidth));
            var start_x = 8;
            var y = 0;
            if (ShowIconOnUI && Icon != null)
            {
                y = EdgeWidth + (_titlebar_style.Height - SystemInformation.SmallIconSize.Height) / 2;
                g.DrawIcon(Icon, new Rectangle(start_x, y, SystemInformation.SmallIconSize.Width, SystemInformation.SmallIconSize.Height));
                start_x += SystemInformation.SmallIconSize.Width + 3;
            }
            if (Text.Trim() != "" && _titlebar_style.TextColor != Color.Transparent)
                g.drawTextInRect(new Rectangle(start_x, EdgeWidth, Width * 2 / 3, _titlebar_style.Height), Text, _titlebar_style.TextFont, _titlebar_style.TextColor, ContentAlignment.MiddleLeft);
        }

        protected void drawStatusBar(Graphics g)
        {
            if (!_statusbar_style.ShouldShow)
                return;
            if (_statusbar_style.BackColor != Color.Transparent)
                g.FillRectangle(new SolidBrush(_statusbar_style.BackColor), new Rectangle(0, Height - _statusbar_style.Height - EdgeWidth, Width, _statusbar_style.Height + EdgeWidth));
            if (_statusbar_style.Text.Trim() != "" && _statusbar_style.TextColor != Color.Transparent)
                g.drawTextInRect(new Rectangle(8, Height - EdgeWidth - _statusbar_style.Height, Width - EdgeWidth * 2 - 16, _statusbar_style.Height), _statusbar_style.Text, _statusbar_style.TextFont, _statusbar_style.TextColor, _statusbar_style.TextAlignment);
        }

        protected void initializeActionButtons()
        {
            btn_close = new ExButton();
            btn_close.Visible = false;
            btn_close.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btn_maximize = new ExButton();
            btn_maximize.Visible = false;
            btn_maximize.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btn_minimize = new ExButton();
            btn_minimize.Visible = false;
            btn_minimize.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            btn_close.Click += performClose;
            Controls.Add(btn_close);
            btn_maximize.Click += performMaximize;
            Controls.Add(btn_maximize);
            btn_minimize.Click += performMinimize;
            Controls.Add(btn_minimize);
        }

        private void performMinimize(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void performMaximize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                switch (_titlebar_style.ActionButtonStyle)
                {
                    case FormActionButtonStyle.Flat:
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.maximize_white;
                        break;
                    case FormActionButtonStyle.FlatDark:
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.maximize;
                        break;
                    case FormActionButtonStyle.Glass:
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.glass_form_max_normal;
                        btn_maximize.Image.Hovered = global::wyk.ui.forms.Properties.Resources.glass_form_max_highlight;
                        btn_maximize.Image.Clicked = global::wyk.ui.forms.Properties.Resources.glass_form_max_down;
                        break;
                }
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                switch (_titlebar_style.ActionButtonStyle)
                {
                    case FormActionButtonStyle.Flat:
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.restore_white;
                        break;
                    case FormActionButtonStyle.FlatDark:
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.restore;
                        break;
                    case FormActionButtonStyle.Glass:
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.glass_form_restore_normal;
                        btn_maximize.Image.Hovered = global::wyk.ui.forms.Properties.Resources.glass_form_restore_highlight;
                        btn_maximize.Image.Clicked = global::wyk.ui.forms.Properties.Resources.glass_form_restore_down;
                        break;
                }
            }
        }

        private void performClose(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void refreshActionButtons()
        {
            refreshWindowPadding();
            if (!_titlebar_style.ShouldShow)
                return;
            var btn_size = new Size(40, 20);
            var icon_size = new Size(12, 12);
            switch (_titlebar_style.ActionButtonStyle)
            {
                case FormActionButtonStyle.Glass:
                    //close
                    btn_close.Image.Normal = global::wyk.ui.forms.Properties.Resources.glass_form_close_normal;
                    btn_close.Image.Hovered = global::wyk.ui.forms.Properties.Resources.glass_form_close_highlight;
                    btn_close.Image.Clicked = global::wyk.ui.forms.Properties.Resources.glass_form_close_down;
                    btn_close.ImageDock = DockStyle.Fill;
                    //max
                    if (WindowState == FormWindowState.Maximized)
                    {
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.glass_form_restore_normal;
                        btn_maximize.Image.Hovered = global::wyk.ui.forms.Properties.Resources.glass_form_restore_highlight;
                        btn_maximize.Image.Clicked = global::wyk.ui.forms.Properties.Resources.glass_form_restore_down;
                    }
                    else
                    {
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.glass_form_max_normal;
                        btn_maximize.Image.Hovered = global::wyk.ui.forms.Properties.Resources.glass_form_max_highlight;
                        btn_maximize.Image.Clicked = global::wyk.ui.forms.Properties.Resources.glass_form_max_down;
                    }
                    btn_maximize.ImageDock = DockStyle.Fill;
                    //min
                    btn_minimize.Image.Normal = global::wyk.ui.forms.Properties.Resources.glass_form_min_normal;
                    btn_minimize.Image.Hovered = global::wyk.ui.forms.Properties.Resources.glass_form_min_highlight;
                    btn_minimize.Image.Clicked = global::wyk.ui.forms.Properties.Resources.glass_form_min_down;
                    btn_minimize.ImageDock = DockStyle.Fill;
                    break;
                case FormActionButtonStyle.Flat:
                    //close
                    btn_close.Image.Normal = global::wyk.ui.forms.Properties.Resources.close_white;
                    btn_close.ImageSize = icon_size;
                    btn_close.ImageDock = DockStyle.None;
                    btn_close.TextAlign = ContentAlignment.MiddleCenter;
                    btn_close.BackColor.Normal = Color.Transparent;
                    btn_close.BackColor.Hovered = Color.FromArgb(255, 255, 0, 0);
                    btn_close.BackColor.Clicked = Color.FromArgb(200, 255, 0, 0);
                    //max
                    if (WindowState == FormWindowState.Maximized)
                    {
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.restore_white;
                    }
                    else
                    {
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.maximize_white;
                    }
                    btn_maximize.ImageSize = icon_size;
                    btn_maximize.TextAlign = ContentAlignment.MiddleCenter;
                    btn_maximize.ImageDock = DockStyle.None;
                    btn_maximize.BackColor.Normal = Color.Transparent;
                    btn_maximize.BackColor.Hovered = Color.FromArgb(80, 255, 255, 255);
                    btn_maximize.BackColor.Clicked = Color.FromArgb(160, 255, 255, 255);
                    //min
                    btn_minimize.Image.Normal = global::wyk.ui.forms.Properties.Resources.minimize_white;
                    btn_minimize.ImageSize = icon_size;
                    btn_minimize.ImageDock = DockStyle.None;
                    btn_minimize.TextAlign = ContentAlignment.MiddleCenter;
                    btn_minimize.BackColor.Normal = Color.Transparent;
                    btn_minimize.BackColor.Hovered = Color.FromArgb(80, 255, 255, 255);
                    btn_minimize.BackColor.Clicked = Color.FromArgb(160, 255, 255, 255);
                    break;
                case FormActionButtonStyle.FlatDark:
                    //close
                    btn_close.Image.Normal = global::wyk.ui.forms.Properties.Resources.close;
                    btn_close.Image.Hovered = global::wyk.ui.forms.Properties.Resources.close_white;
                    btn_close.Image.Clicked = global::wyk.ui.forms.Properties.Resources.close_white;
                    btn_close.ImageSize = icon_size;
                    btn_close.ImageDock = DockStyle.None;
                    btn_close.TextAlign = ContentAlignment.MiddleCenter;
                    btn_close.BackColor.Normal = Color.Transparent;
                    btn_close.BackColor.Hovered = Color.FromArgb(255, 255, 0, 0);
                    btn_close.BackColor.Clicked = Color.FromArgb(200, 255, 0, 0);
                    //max
                    if (WindowState == FormWindowState.Maximized)
                    {
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.restore;
                    }
                    else
                    {
                        btn_maximize.Image.Normal = global::wyk.ui.forms.Properties.Resources.maximize;
                    }
                    btn_maximize.ImageSize = icon_size;
                    btn_maximize.ImageDock = DockStyle.None;
                    btn_maximize.TextAlign = ContentAlignment.MiddleCenter;
                    btn_maximize.BackColor.Normal = Color.Transparent;
                    btn_maximize.BackColor.Hovered = Color.FromArgb(80, 180, 180, 180);
                    btn_maximize.BackColor.Clicked = Color.FromArgb(120, 180, 180, 180);
                    //min
                    btn_minimize.Image.Normal = global::wyk.ui.forms.Properties.Resources.minimize;
                    btn_minimize.ImageSize = icon_size;
                    btn_minimize.ImageDock = DockStyle.None;
                    btn_minimize.TextAlign = ContentAlignment.MiddleCenter;
                    btn_minimize.BackColor.Normal = Color.Transparent;
                    btn_minimize.BackColor.Hovered = Color.FromArgb(160, 100, 100, 100);
                    btn_minimize.BackColor.Clicked = Color.FromArgb(100, 100, 100, 100);
                    break;
                default:
                    break;
            }
            int current_x = Width;
            current_x -= btn_size.Width + EdgeWidth;
            switch (_titlebar_style.ActionButtonPosition)
            {
                case FormActionButtonPosition.Top:
                    btn_close.Left = current_x;
                    btn_close.Top = EdgeWidth;
                    btn_close.Size = btn_size;
                    if (MaximizeBox && FormResizeable)
                    {
                        current_x -= btn_size.Width + EdgeWidth;
                        btn_maximize.Left = current_x;
                        btn_maximize.Top = EdgeWidth;
                        btn_maximize.Size = btn_size;
                    }
                    if (MinimizeBox)
                    {
                        current_x -= btn_size.Width + EdgeWidth;
                        btn_minimize.Left = current_x;
                        btn_minimize.Top = EdgeWidth;
                        btn_minimize.Size = btn_size;
                    }
                    break;
                case FormActionButtonPosition.FullFill:
                    btn_close.Left = current_x;
                    btn_close.Top = EdgeWidth;
                    btn_close.Size = new Size(btn_size.Width, _titlebar_style.Height);
                    if (MaximizeBox && FormResizeable)
                    {
                        current_x -= btn_size.Width + EdgeWidth;
                        btn_maximize.Left = current_x;
                        btn_maximize.Top = EdgeWidth;
                        btn_maximize.Size = new Size(btn_size.Width, _titlebar_style.Height);
                    }
                    if (MinimizeBox)
                    {
                        current_x -= btn_size.Width + EdgeWidth;
                        btn_minimize.Left = current_x;
                        btn_minimize.Top = EdgeWidth;
                        btn_minimize.Size = new Size(btn_size.Width, _titlebar_style.Height);
                    }
                    break;
                case FormActionButtonPosition.Center:
                default:
                    btn_close.Left = current_x;
                    btn_close.Top = EdgeWidth + (_titlebar_style.Height - btn_size.Height) / 2;
                    btn_close.Size = btn_size;
                    if (MaximizeBox && FormResizeable)
                    {
                        current_x -= btn_size.Width + EdgeWidth;
                        btn_maximize.Left = current_x;
                        btn_maximize.Top = EdgeWidth + (_titlebar_style.Height - btn_size.Height) / 2;
                        btn_maximize.Size = btn_size;
                    }
                    if (MinimizeBox)
                    {
                        current_x -= btn_size.Width + EdgeWidth;
                        btn_minimize.Left = current_x;
                        btn_minimize.Top = EdgeWidth + (_titlebar_style.Height - btn_size.Height) / 2;
                        btn_minimize.Size = btn_size;
                    }
                    break;
            }
            btn_close.Visible = true;
            if (MaximizeBox && FormResizeable)
                btn_maximize.Visible = true;
            if (MinimizeBox)
                btn_minimize.Visible = true;
        }
        #endregion
    }
}