using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using wyk.basic;

namespace wyk.ui
{
    [ToolboxItem(false)]
    public partial class ExNotification : ExUserControl
    {
        public ExNotification()
        {
            InitializeComponent();
        }

        #region private properties
        static ExNotification _instance = null;
        long _close_time_tick = 0;

        Form _superior_form = null;
        int _max_width = 500;
        Color _edge_color = Color.Transparent;
        int _edge_width = 1;
        ExLabel _label = new ExLabel();
        Timer _close_timer = null;
        Timer _ui_timer = null;
        float _alpha = 0;
        float _opacity = 0.8f;
        bool _click_to_close = true;

        //用于标识是否正在显示通知界面, false为正在隐藏通知界面, 用于_ui_timer判断alpha的增减
        bool _is_ui_showing = false;
        //用于记录每次_ui_timer改变界面时alpha增/减的幅度
        float _alpha_step = 0;
        //显示/隐藏时进行变化的次数
        int _ui_animation_count = 5;
        //显示/隐藏时每次变化的间隔时长(毫秒)
        int _ui_animation_interval = 20;
        #endregion

        #region custom properties
         /// <summary>
        /// 父窗体, 仅用于定位
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Form SuperiorForm
        {
            get => _superior_form;
            set
            {
                _superior_form = value;
                if (_max_width > _superior_form.Width * 2 / 3)
                    _max_width = _superior_form.Width * 2 / 3;
            }
        }
        /// <summary>
        /// 静态实例
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ExNotification Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ExNotification();
                return _instance;
            }
            set => _instance = value;
        }

        /// <summary>
        /// 关闭当前实例时间(DateTime)
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime CloseTime
        {
            get => new DateTime(_close_time_tick);
            set { _close_time_tick = value.Ticks; resetCloseTimer(); }
        }

        /// <summary>
        /// 关闭当前实例时间(Tick)
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long CloseTimeTick
        {
            get => _close_time_tick;
            set { _close_time_tick = value; resetCloseTimer(); }
        }

        [Description("通知显示时框体的透明度")]
        public float Opacity
        {
            get => _opacity;
            set => _opacity = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float Alpha
        {
            get => _alpha;
            set
            {
                _alpha = value;
                int alpha_value = Convert.ToInt32(_alpha * 255);
                BackColor = Color.FromArgb(alpha_value, BackColor.R, BackColor.G, BackColor.B);
                ForeColor = Color.FromArgb(alpha_value, ForeColor.R, ForeColor.G, ForeColor.B);
                Invalidate();
            }
        }

        [Description("通知框最大宽度")]
        public int MaxWidth
        {
            get => _max_width;
            set => _max_width = value;
        }

        [Description("边框颜色")]
        public Color EdgeColor
        {
            get => _edge_color;
            set => _edge_color = value;
        }

        [Description("边框宽度")]
        public int EdgeWith
        {
            get => _edge_width;
            set => _edge_width = value;
        }

        [Description("是否开启点击通知文字就关闭通知的功能")]
        public bool ClickToClose
        {
            get => _click_to_close;
            set => _click_to_close = value;
        }
        #endregion

        #region override properties
        [Description("当前通知文本")]
        public new string Text
        {
            get => _label.Text;
            set => _label.Text = value;
        }

        [Description("通知文本颜色")]
        public new Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                _label.ForeColor = value;
            }
        }

        public new Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                _label.Font = value;
            }
        }
        #endregion

        #region overrides
        protected override void OnLoad(EventArgs e)
        {
            Padding = new Padding(5);
            _label.Font = Font;
            _label.ForeColor = ForeColor;
            _label.Dock = DockStyle.Fill;
            _label.TextAlign = ContentAlignment.MiddleCenter;
            _label.BackColor = Color.Transparent;
            this.Controls.Add(_label);
            _label.Click += onTextClicked;
            _label.DoubleClick += onTextDoubleClicked;
            Visible = false;
            base.OnLoad(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                resetSizeAndPosition();
                resetCloseTimer();
            }
            else
            {
                if (_close_timer != null && _close_timer.Enabled)
                {
                    try
                    {
                        _close_timer.Stop();
                    }
                    catch { }
                }
                _close_timer = null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_edge_color != Color.Transparent)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.DrawRectangle(new Pen(_edge_color, _edge_width), new Rectangle(_edge_width / 2, _edge_width / 2, Width - _edge_width - 1, Height - _edge_width - 1));
            }
            base.OnPaint(e);
        }
        #endregion

        #region private functions
        /// <summary>
        /// 通知文字双击, 复制当前文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onTextDoubleClicked(object sender, EventArgs e)
        {
            Clipboard.SetText(_label.Text);
        }

        /// <summary>
        /// 通知文字点击, 关闭通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onTextClicked(object sender, EventArgs e)
        {
            if (_click_to_close)
                HideNotification();
        }

        private void resetSizeAndPosition()
        {
            if (_superior_form == null)
                return;
            Graphics g = this.CreateGraphics();
            Size size = _label.Text.measure(g, _label.Font, _max_width - _edge_width * 2 - Padding.Left - Padding.Right);
            size.Width += _edge_width * 2 + Padding.Left + Padding.Right;
            size.Height += _edge_width * 2 + Padding.Top + Padding.Bottom;
            if (size.Width < 100)
                size.Width = 100;
            if (size.Height < 40)
                size.Height = 40;
            Size = size;
                Left = (_superior_form.Width - Width) / 2;
                Top = (_superior_form.Height - Height) / 2;
                if (Width > _superior_form.Width * 2 / 3)
                    Width = _superior_form.Width * 2 / 3;
        }

        private void onColseTimeHitted(object sender, EventArgs e)
        {
            HideNotification();
        }

        private void resetCloseTimer()
        {
            if (_close_timer != null && _close_timer.Enabled)
            {
                try
                {
                    _close_timer.Stop();
                    _close_timer.Enabled = false;
                }
                catch { }
            }
            long ticks_now = DateTime.Now.Ticks;
            if (_close_time_tick > ticks_now)
            {
                if (_close_timer == null)
                {
                    _close_timer = new Timer();
                    _close_timer.Tick += onColseTimeHitted;
                }
                _close_timer.Interval = (int)(_close_time_tick - ticks_now) / 10000;
                _close_timer.Enabled = true;
                _close_timer.Start();
            }
        }

        private void startUITimer()
        {
            if(_ui_timer!=null && _ui_timer.Enabled)
            {
                try
                {
                    _ui_timer.Stop();
                    _ui_timer.Enabled = false;
                }
                catch { }
            }
            if(_ui_timer==null)
            {
                _ui_timer = new Timer();
                _ui_timer.Tick += onUITimerTicked;
            }
            _alpha_step = _opacity / _ui_animation_count;
            _ui_timer.Interval = _ui_animation_interval;
            _ui_timer.Enabled = true;
            _ui_timer.Start();
        }

        private void onUITimerTicked(object sender, EventArgs e)
        {
            float new_alpha;
            bool finished = false;
            if (_is_ui_showing)
            {
                new_alpha = Alpha + _alpha_step;
                if (new_alpha >= _opacity)
                {
                    new_alpha = _opacity;
                    finished = true;
                }
            }
            else
            {
                new_alpha = Alpha - _alpha_step;
                if (new_alpha <= 0)
                {
                    new_alpha = 0;
                    finished = true;
                }
            }
            Alpha = new_alpha;
            if (finished)
            {
                _ui_timer.Stop();
                _ui_timer.Enabled = false;
                if (Alpha <= 0)
                    Hide();
            }
        }
        #endregion

        #region static functions
        /// <summary>
        /// 显示通知
        /// </summary>
        /// <param name="close_delay">关闭时间延时(秒)</param>
        public static void Show(double close_delay)
        {
            HideNotification(true);
            if (Instance.SuperiorForm == null)
                return;
            Instance.CloseTime = DateTime.Now.AddSeconds(close_delay);
            Instance.SuperiorForm.Controls.Add(Instance);
            Instance.BringToFront();
            Instance.Alpha = 0;
            Instance.Show();
            Instance._is_ui_showing = true;
            Instance.startUITimer();
        }

        public static void HideNotification()
        {
            HideNotification(false);
        }

        public static void HideNotification(bool directly)
        {
            if(directly)
                Instance.Hide();
            else
            {
                Instance._is_ui_showing = false;
                Instance.startUITimer();
            }
        }
        #endregion
    }
}
