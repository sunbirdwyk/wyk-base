using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using wyk.ui.consts;
using wyk.ui.utility;

namespace wyk.ui
{
    /// <summary>
    /// 最基础的ExForm类
    /// </summary>
    public partial class ExFormBase : Form
    {
        protected int main_thread_id = Thread.CurrentThread.ManagedThreadId;
        protected delegate void MainThreadHandler();
        public ExFormBase()
        {
            InitializeComponent();
        }

        #region private properties
        #endregion

        #region public properties
        [Description("最大化时是否占满整个屏幕")]
        public bool MaximizeToFullscreen { get; set; } = false;

        [Description("Form是否可以改变大小")]
        public bool FormResizeable { get; set; } = true;

        [Description("是否显示窗体阴影")]
        public bool ShowShadow { get; set; } = true;

        [Description("是否剪裁子控件背景(如果窗口经常出现空洞, 禁用此项, 窗体控件较多时启用此项)")]
        public bool ClipChildren { get; set; } = true;
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
        public new AutoValidate AutoValidate
        {
            get => base.AutoValidate;
            set => base.AutoValidate = value;
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
        public new bool ControlBox
        {
            get => base.ControlBox;
            set => base.ControlBox = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle
        {
            get => base.FormBorderStyle;
            set => base.FormBorderStyle = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool HelpButton
        {
            get => base.HelpButton;
            set => base.HelpButton = value;
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
        public new bool IsMdiContainer
        {
            get => base.IsMdiContainer;
            set => base.IsMdiContainer = value;
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
        public new bool RightToLeftLayout
        {
            get => base.RightToLeftLayout;
            set => base.RightToLeftLayout = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new SizeGripStyle SizeGripStyle
        {
            get => base.SizeGripStyle;
            set => base.SizeGripStyle = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormStartPosition StartPosition
        {
            get => base.StartPosition;
            set => base.StartPosition = value;
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!DesignMode)
                {
                    if (MaximizeBox) { cp.Style |= (int)WindowStyle.WS_MAXIMIZEBOX; }
                    if (MinimizeBox) { cp.Style |= (int)WindowStyle.WS_MINIMIZEBOX; }
                    if (ClipChildren)
                        cp.ExStyle |= (int)WindowStyle.WS_CLIPCHILDREN;  //防止因窗体控件太多出现闪烁
                    if (ShowShadow)
                        cp.ClassStyle |= (int)ClassStyle.CS_DropSHADOW;  //实现窗体边框阴影效果
                }
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WindowMessage.WM_ERASEBKGND:
                    m.Result = IntPtr.Zero;
                    break;
                case WindowMessage.WM_NCHITTEST:
                    processNCMouseAction(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            refreshWindowPadding();
            base.OnPaint(e);
        }
        #endregion

        #region protected functions
        protected virtual void setStyles()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        protected virtual void refreshWindowPadding()
        {
            Padding = new Padding(0);
        }

        protected virtual void processNCMouseAction(ref Message m)  //调整窗体大小
        {
            var point = PointToClient(m.formPosition());
            if (WindowState == FormWindowState.Maximized || !FormResizeable)
            {
                if (point.Y < 3)
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
                else if (point.Y < 3)
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

        #region public functions
        /// <summary>
        /// 显示Loading动画
        /// </summary>
        public void showLoading()
        {
            LoadingUtil.showLoading(this,true);
        }

        /// <summary>
        /// 显示Loading动画
        /// </summary>
        /// <param name="with_cover">是否显示遮罩颜色</param>
        public void showLoading(bool with_cover)
        {
            LoadingUtil.showLoading(this, with_cover);
        }

        /// <summary>
        /// 隐藏Loading动画
        /// </summary>
        public void hideLoading()
        {
            if (isInMainThread())
                LoadingUtil.hideLoading(this);
            else
                this.Invoke(new MainThreadHandler(hideLoading));
        }

        /// <summary>
        /// 判断当前线程是否在主线程
        /// </summary>
        /// <returns></returns>
        protected bool isInMainThread()
        {
            return Thread.CurrentThread.ManagedThreadId == main_thread_id;
        }

        /// <summary>
        /// API返回结果正常时的默认操作, 此处只隐藏了Loading动画
        /// </summary>
        /// <param name="data"></param>
        protected virtual void onApiSuccess(object data)
        {
            hideLoading();
        }

        /// <summary>
        /// API返回结果异常时的默认操作, 弹出错误对话框并隐藏Loading, 如需其他操作, 请自行重写或者使用新的函数
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="code">错误代码</param>
        protected virtual void onApiFailed(string message, int code)
        {
            hideLoading();
            ExMessageBox.Show(this, message);
        }
        public void setCurrentPositionToCenter()
        {
            setCurrentPositionTo(ContentAlignment.MiddleCenter);
        }

        public void setCurrentPositionToCenterParent(Form parent)
        {
            if (parent == null)
            {
                setCurrentPositionToCenter();
                return;
            }
            if (WindowState != FormWindowState.Normal)
                WindowState = FormWindowState.Normal;
            var offset_x = (parent.Width - Width) / 2;
            var offset_y = (parent.Height - Height) / 2;
            Left = parent.Left + offset_x;
            Top = parent.Top + offset_y;
        }

        public void setCurrentPositionTo(ContentAlignment area_place)
        {
            setCurrentPositionTo(area_place, Width, Height);
        }

        public void setCurrentPositionTo(ContentAlignment area_place, int width, int height)
        {
            var current_screen = Screen.FromControl(this);
            if (WindowState != FormWindowState.Normal)
                WindowState = FormWindowState.Normal;
            var rect = current_screen.WorkingArea;
            if (MaximizeToFullscreen)
                rect = current_screen.Bounds;

            if (width > rect.Width)
                width = rect.Width;
            if (height > rect.Height)
                height = rect.Height;
            if (Width != width)
                Width = width;
            if (Height != height)
                Height = height;
            switch (area_place)
            {
                case ContentAlignment.TopLeft:
                    Left = 0;
                    Top = 0;
                    break;
                case ContentAlignment.TopCenter:
                    Left = (rect.Width - Width) / 2;
                    Top = 0;
                    break;
                case ContentAlignment.TopRight:
                    Left = rect.Width - Width;
                    Top = 0;
                    break;
                case ContentAlignment.MiddleLeft:
                    Left = 0;
                    Top = (rect.Height - Height) / 2;
                    break;
                case ContentAlignment.MiddleCenter:
                default:
                    Left = (rect.Width - Width) / 2;
                    Top = (rect.Height - Height) / 2;
                    break;
                case ContentAlignment.MiddleRight:
                    Left = rect.Width - Width;
                    Top = (rect.Height - Height) / 2;
                    break;
                case ContentAlignment.BottomLeft:
                    Left = 0;
                    Top = rect.Height - height;
                    break;
                case ContentAlignment.BottomCenter:
                    Left = (rect.Width - Width) / 2;
                    Top = rect.Height - height;
                    break;
                case ContentAlignment.BottomRight:
                    Left = rect.Width - Width;
                    Top = rect.Height - height;
                    break;
            }
        }

        public void setCurrentStatusToMaxmizedFullScreen()
        {
            MaximizeToFullscreen = true;
            WindowState = FormWindowState.Maximized;
        }
        #endregion
    }
}
