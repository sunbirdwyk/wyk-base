using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace wyk.ui
{
    public partial class ExForm : ExFormBasic
    {
        public ExForm()
        {
            InitializeComponent();
        }

        #region private properties
        /// <summary>
        /// 父窗体, 用于继承UI设置
        /// </summary>
        private ExFormBasic _superior_form = null;
        private bool _inherit_ui = true;
        #endregion

        #region custom properties
        [Browsable(false)]
        [Description("父窗体")]
        public ExFormBasic SuperiorForm
        {
            get => _superior_form;
            set => _superior_form = value;
        }

        [Description("是否继承父窗体UI设置, 注:状态栏设置不会继承")]
        public bool InheritUI
        {
            get => _inherit_ui;
            set => _inherit_ui = value;
        }
        #endregion

        #region overrides
        protected override void OnLoad(EventArgs e)
        {
            if (_inherit_ui)
            {
                loadSuperiorUISettings();
            }
            base.OnLoad(e);
        }
        #endregion

        #region private functions
        private void loadSuperiorUISettings()
        {
            if (_superior_form == null)
                _superior_form = FormManager.template_form;
            if (_superior_form == null)
                return;
            TitleBar = _superior_form.TitleBar;
            EdgeColor = _superior_form.EdgeColor;
            EdgeWidth = _superior_form.EdgeWidth;
            Font = _superior_form.Font;
            BackColor = _superior_form.BackColor;
            ForeColor = _superior_form.ForeColor;
            BackgroundImage = _superior_form.BackgroundImage;
            BackgroundImageLayout = _superior_form.BackgroundImageLayout;
        }
        #endregion

        #region public functions
        public void setCurrentPositionToCenterParent()
        {
            if (_superior_form == null)
            {
                setCurrentPositionToCenter();
                return;
            }
            if (WindowState != FormWindowState.Normal)
                WindowState = FormWindowState.Normal;
            int offset_x = (_superior_form.Width - Width) / 2;
            int offset_y = (_superior_form.Height - Height) / 2;
            Left = _superior_form.Left + offset_x;
            Top = _superior_form.Top + offset_y;
        }
        #endregion
    }
}