using System;
using System.Drawing;

namespace wyk.basic
{
    public class UIBounds
    {
        public float x = 0;
        public float y = 0;
        public float width = 0;
        public float height = 0;

        public UIBounds() { }
        public UIBounds(string content)
        {
            this.content = content;
        }
        public UIBounds(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public string content
        {
            get => x + "," + y + "," + width + "," + height;
            set
            {
                var parts = value.Split(',');
                try
                {
                    x = (float)Convert.ToDouble(parts[0]);
                }
                catch { }
                try
                {
                    y = (float)Convert.ToDouble(parts[1]);
                }
                catch { }
                try
                {
                    width = (float)Convert.ToDouble(parts[2]);
                }
                catch { }
                try
                {
                    height = (float)Convert.ToDouble(parts[3]);
                }
                catch { }
            }
        }

        public int x_px
        {
            get => UIUtil.pxFromMM(x);
            set => x = UIUtil.mmFromPx(value);
        }

        public float x_pt
        {
            get => UIUtil.ptFromMM(x);
            set => x = UIUtil.mmFromPt(value);
        }

        public int y_px
        {
            get => UIUtil.pxFromMM(y);
            set => y = UIUtil.mmFromPx(value);
        }

        public float y_pt
        {
            get => UIUtil.ptFromMM(y);
            set => y = UIUtil.mmFromPt(value);
        }

        public int width_px
        {
            get => UIUtil.pxFromMM(width);
            set => width = UIUtil.mmFromPx(value);
        }

        public float width_pt
        {
            get => UIUtil.ptFromMM(width);
            set => width = UIUtil.mmFromPt(value);
        }

        public int height_px
        {
            get => UIUtil.pxFromMM(height);
            set => height = UIUtil.mmFromPx(value);
        }

        public float height_pt
        {
            get => UIUtil.ptFromMM(height);
            set => height = UIUtil.mmFromPt(value);
        }

        public PointF location
        {
            get => new PointF(x, y);
            set { x = value.X; y = value.Y; }
        }

        public PointF location_pt
        {
            get => new PointF(x_pt, y_pt);
            set { x_pt = value.X; y_pt = value.Y; }
        }

        public Point location_px
        {
            get => new Point(x_px, y_px);
            set { x_px = value.X; y_px = value.Y; }
        }

        public SizeF size
        {
            get => new SizeF(width, height);
            set { width = value.Width; height = value.Height; }
        }
        public SizeF size_pt
        {
            get => new SizeF(width_pt, height_pt);
            set { width_pt = value.Width; height_pt = value.Height; }
        }
        public Size size_px
        {
            get => new Size(width_px, height_px);
            set { width_px = value.Width; height_px = value.Height; }
        }
    }
}
