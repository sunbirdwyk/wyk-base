using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using wyk.basic;
using wyk.ui.utility;

namespace wyk.ui
{
    public class ExLoading : Control
    {
        #region private properties
        List<ExLoadingDot> dots = new List<ExLoadingDot>();
        bool _show_cover_color = true;
        int _showing_index = 0;
        int _opacity_step = 0;
        Timer timer;
        #endregion

        #region initialize
        public ExLoading()
        {
            initialize();
        }

        public ExLoading(bool show_cover_color)
        {
            this.show_cover_color = show_cover_color;
            initialize();
        }

        public void initialize()
        {
            SetStyle(ControlStyles.Opaque, true);
            base.CreateControl();
            dots = new List<ExLoadingDot>();
            for (int i = 0; i < LoadingUtil.dot_count; i++)
            {
                var dot = new ExLoadingDot();
                dot.Size = new Size(LoadingUtil.dot_size, LoadingUtil.dot_size);
                dot.BackColor = LoadingUtil.dot_color;
                dots.Add(dot);
                dot.Parent = this;
            }
            _opacity_step = Convert.ToInt32(Convert.ToDouble(LoadingUtil.dot_opacity_max - LoadingUtil.dot_opacity_min) / LoadingUtil.dot_count);
            showing_index = 0;
        }
        #endregion

        #region properties
        public int showing_index
        {
            get => _showing_index;
            set
            {
                _showing_index = value;
                var opacity = LoadingUtil.dot_opacity_max;
                for (int i = 0; i < dots.Count; i++)
                {
                    dots[i].Alpha = (opacity - _opacity_step * ((_showing_index + i) % LoadingUtil.dot_count)) * 255 / 100;
                }
            }
        }

        public bool show_cover_color
        {
            get => _show_cover_color;
            set { _show_cover_color = value; this.Invalidate(); }
        }
        #endregion

        #region public functions
        public void start()
        {
            stop();
            timer = new Timer();
            timer.Interval = LoadingUtil.animation_interval;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            showing_index++;
        }

        public void stop()
        {
            if (timer != null && timer.Enabled)
            {
                try
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }
                catch { }
            }
        }
        #endregion

        #region private functions
        private void refreshDotLocations()
        {
            //原点
            var original = new PointF((float)Width / 2, (float)Height / 2);
            var point = new PointF(original.X, original.Y-((float)LoadingUtil.circle_size / 2));
            point = GraphicsUtil.pointRotate(original, point, LoadingUtil.start_angle);
            var angle_step = 360 / LoadingUtil.dot_count;
            for (int i = 0; i < dots.Count; i++)
            {
                dots[i].Location = new Point(Convert.ToInt32(point.X)-LoadingUtil.dot_size/2,Convert.ToInt32(point.Y) - LoadingUtil.dot_size / 2);
                point = GraphicsUtil.pointRotate(original, point, angle_step);
            }
        }
        #endregion

        #region overrides
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_show_cover_color)
            {
                var back_color = LoadingUtil.coverBGColor();
                using (var brush = new SolidBrush(back_color))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, Width, Height);
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            refreshDotLocations();
        }

        protected override void Dispose(bool disposing)
        {
            stop();
            base.Dispose(disposing);
        }
        #endregion

        #region ExLoading Dot (Private Class)
        class ExLoadingDot : Control
        {
            int _alpha = 255;
            public ExLoadingDot()
            {
                SetStyle(ControlStyles.Opaque, true);
                base.CreateControl();
            }

            public int Alpha
            {
                get => _alpha;
                set { _alpha = value; this.Invalidate(); }
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                    return cp;
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                using (var brush = new SolidBrush(Color.FromArgb(Alpha, BackColor)))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, Width-1, Height-1);
                }
            }
        }
        #endregion
    }
}
