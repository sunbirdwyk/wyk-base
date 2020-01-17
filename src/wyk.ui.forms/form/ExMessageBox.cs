using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using wyk.basic;

namespace wyk.ui
{
    public partial class ExMessageBox : ExFormBasic
    {
        public ExMessageBox()
        {
            InitializeComponent();
        }

        #region private properties
        Color _color_default = Color.FromArgb(24, 116, 226);
        Color _color_error = Color.FromArgb(215, 0, 0);
        Color _color_information = Color.FromArgb(16, 175, 216);
        Color _color_successed = Color.FromArgb(18, 154, 100);
        Color _color_question = Color.FromArgb(152, 17, 181);
        Color _color_warning = Color.FromArgb(244, 105, 13);
        bool _always_use_default_color = false;

        ExMessageBoxIcon _icon = ExMessageBoxIcon.None;
        ExMessageBoxButton _buttons = ExMessageBoxButton.OK;
        Color _current_color = Color.FromArgb(24, 116, 226);
        Form _superior_form = null;
        #endregion

        #region custom properties
        [Description("默认显示颜色")]
        public Color ColorDefault
        {
            get => _color_default;
            set => _color_default = value;
        }
        [Description("错误信息显示颜色")]
        public Color ColorError
        {
            get => _color_error;
            set => _color_error = value;
        }
        [Description("提示信息显示颜色")]
        public Color ColorInformation
        {
            get => _color_information;
            set => _color_information = value;
        }
        [Description("成功信息显示颜色")]
        public Color ColorSuccessed
        {
            get => _color_successed;
            set => _color_successed = value;
        }
        [Description("提问信息显示颜色")]
        public Color ColorQuestion
        {
            get => _color_question;
            set => _color_question = value;
        }
        [Description("警告信息显示颜色")]
        public Color ColorWarning
        {
            get => _color_warning;
            set => _color_warning = value;
        }
        [Description("是否只使用默认颜色显示")]
        public bool AlwaysUseDefaultColor
        {
            get => _always_use_default_color;
            set => _always_use_default_color = value;
        }
        #endregion

        #region hidden properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExMessageBoxIcon MessageBoxIcon
        {
            get => _icon;
            set => _icon = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExMessageBoxButton MessageBoxButton
        {
            get => _buttons;
            set => _buttons = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MessageText
        {
            get => lblText.Text;
            set => lblText.Text = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MessageCaption
        {
            get => this.Text;
            set => this.Text = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Form SuperiorForm
        {
            get => _superior_form;
            set => _superior_form = value;
        }
        #endregion

        #region overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btn_close.Visible = false;
            btn_maximize.Visible = false;
            btn_minimize.Visible = false;
            setCurrentPositionToCenterParent();
        }
        #endregion

        #region private functions
        private void refreshMessageBoxContents()
        {
            //颜色和图标
            if (_always_use_default_color)
                _current_color = _color_default;
            else
            {
                switch (_icon)
                {
                    case ExMessageBoxIcon.None:
                    default:
                        _current_color = _color_default;
                        break;
                    case ExMessageBoxIcon.Error:
                        _current_color = _color_error;
                        break;
                    case ExMessageBoxIcon.Information:
                        _current_color = _color_information;
                        break;
                    case ExMessageBoxIcon.Question:
                        _current_color = _color_question;
                        break;
                    case ExMessageBoxIcon.Successed:
                        _current_color = _color_successed;
                        break;
                    case ExMessageBoxIcon.Warning:
                        _current_color = _color_warning;
                        break;
                }
            }
            btnAction1.PrimaryColor = _current_color;
            btnAction2.PrimaryColor = _current_color;
            btnCopy.PrimaryColor = _current_color;
            this.BackColor = _current_color.lighterColor(5);
            this.TitleBar.BackColor = _current_color;
            this.EdgeColor = _current_color;
            switch (_icon)
            {
                case ExMessageBoxIcon.None:
                default:
                    pbIcon.BackgroundImage = null;
                    pbIcon.Visible = false;
                    tlpMain.ColumnStyles[0].Width = 0;
                    break;
                case ExMessageBoxIcon.Error:
                    pbIcon.BackgroundImage = global::wyk.ui.forms.Properties.Resources.msgbox_icon_error;
                    pbIcon.Visible = true;
                    tlpMain.ColumnStyles[0].Width = 60;
                    break;
                case ExMessageBoxIcon.Information:
                    pbIcon.BackgroundImage = global::wyk.ui.forms.Properties.Resources.msgbox_icon_info;
                    pbIcon.Visible = true;
                    tlpMain.ColumnStyles[0].Width = 60;
                    break;
                case ExMessageBoxIcon.Question:
                    pbIcon.BackgroundImage = global::wyk.ui.forms.Properties.Resources.msgbox_icon_question;
                    pbIcon.Visible = true;
                    tlpMain.ColumnStyles[0].Width = 60;
                    break;
                case ExMessageBoxIcon.Successed:
                    pbIcon.BackgroundImage = global::wyk.ui.forms.Properties.Resources.msgbox_icon_ok;
                    pbIcon.Visible = true;
                    tlpMain.ColumnStyles[0].Width = 60;
                    break;
                case ExMessageBoxIcon.Warning:
                    pbIcon.BackgroundImage = global::wyk.ui.forms.Properties.Resources.msgbox_icon_warning;
                    pbIcon.Visible = true;
                    tlpMain.ColumnStyles[0].Width = 60;
                    break;
            }

            //动作按钮样式
            switch (_buttons)
            {
                case ExMessageBoxButton.OK:
                default:
                    btnAction1.Visible = false;
                    btnAction2.Visible = true;
                    btnAction2.Text = "确定";
                    DialogResult = DialogResult.OK;
                    break;
                case ExMessageBoxButton.OKCancel:
                    btnAction1.Visible = true;
                    btnAction2.Visible = true;
                    btnAction1.Text = "确定";
                    btnAction2.Text = "取消";
                    DialogResult = DialogResult.Cancel;
                    break;
                case ExMessageBoxButton.RetryCancel:
                    btnAction1.Visible = true;
                    btnAction2.Visible = true;
                    btnAction1.Text = "重试";
                    btnAction2.Text = "取消";
                    DialogResult = DialogResult.Cancel;
                    break;
                case ExMessageBoxButton.YesNo:
                    btnAction1.Visible = true;
                    btnAction2.Visible = true;
                    btnAction1.Text = "是";
                    btnAction2.Text = "否";
                    DialogResult = DialogResult.No;
                    break;
            }

            //大小
            int width_offset = 0;
            width_offset += Convert.ToInt32(tlpMain.ColumnStyles[0].Width);
            width_offset += SystemInformation.VerticalScrollBarWidth + lblText.Location.X;
            width_offset += 3;
            int max_width = MaximumSize.Width - width_offset;
            int min_width = MinimumSize.Width - width_offset;
            int height_offset = TitleBar.Height + tlpAction.Height;
            int min_height = MinimumSize.Height - height_offset - lblText.Location.X * 2;
            Size size = lblText.Text.measure(this.CreateGraphics(), lblText.Font, max_width);
            if (size.Width < min_width)
                size.Width = min_width;
            if (size.Height < min_height)
                size.Height = min_height;
            size.Height += lblText.Location.X * 2;
            lblText.Size = size;
            this.Width = size.Width + width_offset;
            this.Height = size.Height + height_offset;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MessageText);
        }

        private void btnAction1_Click(object sender, EventArgs e)
        {
            switch (_buttons)
            {
                case ExMessageBoxButton.OK:
                    break;
                case ExMessageBoxButton.OKCancel:
                    DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case ExMessageBoxButton.RetryCancel:
                    DialogResult = DialogResult.Retry;
                    this.Close();
                    break;
                case ExMessageBoxButton.YesNo:
                    DialogResult = DialogResult.Yes;
                    this.Close();
                    break;
            }
        }

        private void btnAction2_Click(object sender, EventArgs e)
        {
            switch (_buttons)
            {
                case ExMessageBoxButton.OK:
                    DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case ExMessageBoxButton.OKCancel:
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                case ExMessageBoxButton.RetryCancel:
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                case ExMessageBoxButton.YesNo:
                    DialogResult = DialogResult.No;
                    this.Close();
                    break;
            }
        }
        #endregion

        #region show functions
        /// <summary>
        /// 显示提示框(固定颜色)
        /// </summary>
        /// <param name="parent">父窗体</param>
        /// <param name="primary_color">窗体主色</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <param name="icon">提示图标/类型</param>
        /// <param name="buttons">动作按钮类型</param>
        /// <returns></returns>
        public static DialogResult Show(
           Form parent,
           Color primary_color,
           string message_text,
           string caption,
           ExMessageBoxIcon icon,
           ExMessageBoxButton buttons)
        {
            var mb = new ExMessageBox();
            mb.AlwaysUseDefaultColor = true;
            mb.ColorDefault = primary_color;
            mb.MessageCaption = caption;
            mb.MessageText = message_text;
            mb.MessageBoxIcon = icon;
            mb.MessageBoxButton = buttons;
            mb.SuperiorForm = parent;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }
        /// <summary>
        /// 显示提示框(固定颜色)
        /// </summary>
        /// <param name="parent">父窗体</param>
        /// <param name="primary_color">窗体主色</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="icon">提示图标/类型</param>
        /// <returns></returns>
        public static DialogResult Show(
           Form parent,
           Color primary_color,
           string message_text,
           ExMessageBoxIcon icon)
        {
            var mb = new ExMessageBox();
            mb.AlwaysUseDefaultColor = true;
            mb.ColorDefault = primary_color;
            mb.MessageCaption = "提示";
            mb.MessageText = message_text;
            mb.MessageBoxIcon = icon;
            mb.MessageBoxButton = ExMessageBoxButton.OK;
            mb.SuperiorForm = parent;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }

        /// <summary>
        /// 显示提示框(固定颜色)
        /// </summary>
        /// <param name="parent">父窗体</param>
        /// <param name="primary_color">窗体主色</param>
        /// <param name="message_text">提示文字</param>
        /// <returns></returns>
        public static DialogResult Show(
           Form parent,
           Color primary_color,
           string message_text)
        {
            var mb = new ExMessageBox();
            mb.AlwaysUseDefaultColor = true;
            mb.ColorDefault = primary_color;
            mb.MessageCaption = "提示";
            mb.MessageText = message_text;
            mb.MessageBoxIcon = ExMessageBoxIcon.Information;
            mb.MessageBoxButton = ExMessageBoxButton.OK;
            mb.SuperiorForm = parent;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }

        /// <summary>
        /// 显示提示框(固定颜色)
        /// </summary>
        /// <param name="parent">父窗体</param>
        /// <param name="primary_color">窗体主色</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <returns></returns>
        public static DialogResult Show(
           Form parent,
           Color primary_color,
           string message_text,
           string caption)
        {
            var mb = new ExMessageBox();
            mb.AlwaysUseDefaultColor = true;
            mb.ColorDefault = primary_color;
            mb.MessageCaption = caption;
            mb.MessageText = message_text;
            mb.MessageBoxIcon = ExMessageBoxIcon.Information;
            mb.MessageBoxButton = ExMessageBoxButton.OK;
            mb.SuperiorForm = parent;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }

        /// <summary>
        /// 显示提示框(固定颜色)
        /// </summary>
        /// <param name="parent">父窗体</param>
        /// <param name="primary_color">窗体主色</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <param name="icon">提示图标/类型</param>
        /// <returns></returns>
        public static DialogResult Show(
           Form parent,
           Color primary_color,
           string message_text,
           string caption,
           ExMessageBoxIcon icon)
        {
            var mb = new ExMessageBox();
            mb.AlwaysUseDefaultColor = true;
            mb.ColorDefault = primary_color;
            mb.MessageCaption = caption;
            mb.MessageText = message_text;
            mb.MessageBoxIcon = icon;
            mb.MessageBoxButton = ExMessageBoxButton.OK;
            mb.SuperiorForm = parent;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="parent">父窗体</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <param name="icon">提示图标/类型</param>
        /// <param name="buttons">动作按钮类型</param>
        /// <returns></returns>
        public static DialogResult Show(
            Form parent,
            string message_text,
            string caption,
            ExMessageBoxIcon icon,
            ExMessageBoxButton buttons)
        {
            var mb = new ExMessageBox();
            mb.MessageCaption = caption;
            mb.MessageText = message_text;
            mb.MessageBoxIcon = icon;
            mb.MessageBoxButton = buttons;
            mb.SuperiorForm = parent;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="parent">父窗体</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <param name="icon">提示图标/类型</param>
        /// <returns></returns>
        public static DialogResult Show(
           Form parent,
           string message_text,
           string caption,
           ExMessageBoxIcon icon)
        {
            return Show(parent, message_text, caption, icon, ExMessageBoxButton.OK);
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="parent">父窗体</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <returns></returns>
        public static DialogResult Show(
           Form parent,
           string message_text,
           string caption)
        {
            return Show(parent, message_text, caption, ExMessageBoxIcon.None, ExMessageBoxButton.OK);
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="parent">父窗体</param>
        /// <param name="message_text">提示文字</param>
        /// <returns></returns>
        public static DialogResult Show(
           Form parent,
           string message_text)
        {
            return Show(parent, message_text, "提示", ExMessageBoxIcon.None, ExMessageBoxButton.OK);
        }
        /************************** 以下为使用默认模板Form显示调用 ********************************/
        /// <summary>
        /// 显示提示框(固定颜色)
        /// </summary>
        /// <param name="primary_color">窗体主色</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <param name="icon">提示图标/类型</param>
        /// <param name="buttons">动作按钮类型</param>
        /// <returns></returns>
        public static DialogResult Show(
           Color primary_color,
           string message_text,
           string caption,
           ExMessageBoxIcon icon,
           ExMessageBoxButton buttons)
        {
            var mb = new ExMessageBox();
            mb.AlwaysUseDefaultColor = true;
            mb.ColorDefault = primary_color;
            mb.MessageCaption = caption;
            mb.MessageText = message_text;
            mb.MessageBoxIcon = icon;
            mb.MessageBoxButton = buttons;
            mb.SuperiorForm = FormManager.template_form;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }
        /// <summary>
        /// 显示提示框(固定颜色)
        /// </summary>
        /// <param name="primary_color">窗体主色</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="icon">提示图标/类型</param>
        /// <returns></returns>
        public static DialogResult Show(
           Color primary_color,
           string message_text,
           ExMessageBoxIcon icon)
        {
            var mb = new ExMessageBox();
            mb.AlwaysUseDefaultColor = true;
            mb.ColorDefault = primary_color;
            mb.MessageCaption = "提示";
            mb.MessageText = message_text;
            mb.MessageBoxIcon = icon;
            mb.MessageBoxButton = ExMessageBoxButton.OK;
            mb.SuperiorForm = FormManager.template_form;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }

        /// <summary>
        /// 显示提示框(固定颜色)
        /// </summary>
        /// <param name="primary_color">窗体主色</param>
        /// <param name="message_text">提示文字</param>
        /// <returns></returns>
        public static DialogResult Show(
           Color primary_color,
           string message_text)
        {
            var mb = new ExMessageBox();
            mb.AlwaysUseDefaultColor = true;
            mb.ColorDefault = primary_color;
            mb.MessageCaption = "提示";
            mb.MessageText = message_text;
            mb.MessageBoxIcon = ExMessageBoxIcon.Information;
            mb.MessageBoxButton = ExMessageBoxButton.OK;
            mb.SuperiorForm = FormManager.template_form;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }

        /// <summary>
        /// 显示提示框(固定颜色)
        /// </summary>
        /// <param name="primary_color">窗体主色</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <returns></returns>
        public static DialogResult Show(
           Color primary_color,
           string message_text,
           string caption)
        {
            var mb = new ExMessageBox();
            mb.AlwaysUseDefaultColor = true;
            mb.ColorDefault = primary_color;
            mb.MessageCaption = caption;
            mb.MessageText = message_text;
            mb.MessageBoxIcon = ExMessageBoxIcon.Information;
            mb.MessageBoxButton = ExMessageBoxButton.OK;
            mb.SuperiorForm = FormManager.template_form;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }

        /// <summary>
        /// 显示提示框(固定颜色)
        /// </summary>
        /// <param name="primary_color">窗体主色</param>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <param name="icon">提示图标/类型</param>
        /// <returns></returns>
        public static DialogResult Show(
           Color primary_color,
           string message_text,
           string caption,
           ExMessageBoxIcon icon)
        {
            var mb = new ExMessageBox();
            mb.AlwaysUseDefaultColor = true;
            mb.ColorDefault = primary_color;
            mb.MessageCaption = caption;
            mb.MessageText = message_text;
            mb.MessageBoxIcon = icon;
            mb.MessageBoxButton = ExMessageBoxButton.OK;
            mb.SuperiorForm = FormManager.template_form;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <param name="icon">提示图标/类型</param>
        /// <param name="buttons">动作按钮类型</param>
        /// <returns></returns>
        public static DialogResult Show(
            string message_text,
            string caption,
            ExMessageBoxIcon icon,
            ExMessageBoxButton buttons)
        {
            var mb = new ExMessageBox();
            mb.MessageCaption = caption;
            mb.MessageText = message_text;
            mb.MessageBoxIcon = icon;
            mb.MessageBoxButton = buttons;
            mb.SuperiorForm = FormManager.template_form;
            mb.refreshMessageBoxContents();
            mb.ShowDialog();
            return mb.DialogResult;
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <param name="icon">提示图标/类型</param>
        /// <returns></returns>
        public static DialogResult Show(
           string message_text,
           string caption,
           ExMessageBoxIcon icon)
        {
            return Show(message_text, caption, icon, ExMessageBoxButton.OK);
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="message_text">提示文字</param>
        /// <param name="caption">提示标题</param>
        /// <returns></returns>
        public static DialogResult Show(
           string message_text,
           string caption)
        {
            return Show(message_text, caption, ExMessageBoxIcon.None, ExMessageBoxButton.OK);
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="message_text">提示文字</param>
        /// <returns></returns>
        public static DialogResult Show(
           string message_text)
        {
            return Show(message_text, "提示", ExMessageBoxIcon.None, ExMessageBoxButton.OK);
        }
        #endregion

        #region public functions
        public void setCurrentPositionToCenterParent()
        {
            Invoke(new MainThreadHandler(() =>
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
            }));
        }
        #endregion
    }
}