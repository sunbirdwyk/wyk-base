using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using wyk.ui.utility;

namespace wyk.ui
{
    [ToolboxItem(false)]
    public partial class ExUserControl : UserControl
    {
        protected int main_thread_id = Thread.CurrentThread.ManagedThreadId;
        protected delegate void MainThreadHandler();
        public ExUserControl()
        {
            setStyles();
            InitializeComponent();
        }

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
        public new ImeMode ImeMode
        {
            get => base.ImeMode;
            set => base.ImeMode = value;
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
        protected void setStyles()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }
        #endregion

        #region public functions
        /// <summary>
        /// 显示Loading动画
        /// </summary>
        public void showLoading()
        {
            LoadingUtil.showLoading(this, true);
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
            ExMessageBox.Show(this.ParentForm, message);
        }
        #endregion
    }
}
