using wyk.basic;
using System.Drawing;

namespace wyk.ui
{
    /// <summary>
    /// 用于定义渐变颜色(单色渐变设置)
    /// 注: 此设置不包括颜色
    /// </summary>
    public class GradientColorSetSimple
    {
        /// <summary>
        /// 渐变方式
        /// 注: 此值为None时只使用 colors中的第一个颜色, 其他颜色无用
        /// </summary>
        public GradientStyle gradient_style = GradientStyle.None;
        /// <summary>
        /// 旋转角度, 在原有方向上的旋转角度
        /// </summary>
        public float rotate_angle = 0;
        /// <summary>
        /// 第二颜色的浅度
        /// </summary>
        public int secondary_opacity = 60;
        /// <summary>
        /// 第二颜色的透明度(-1表示使用原颜色的透明度)
        /// </summary>
        public int secondary_alpha = -1;
        /// <summary>
        /// 是否翻转颜色渐变方向
        /// </summary>
        public bool is_reverse = false;
        /// <summary>
        /// 是否边缘颜色相同, 如果相同则为 深->浅->深 或者 浅->深->浅 三相渐变
        /// </summary>
        public bool same_edge_color = false;

        public GradientColorSetSimple() { }

        public GradientColorSetSimple(GradientStyle gradient_style, float rotate_angle, int secondary_opacity, int secondary_alpha, bool is_reverse, bool same_edge_color)
        {
            this.gradient_style = gradient_style;
            this.rotate_angle = rotate_angle;
            this.secondary_opacity = secondary_opacity;
            this.secondary_alpha = secondary_alpha;
            this.is_reverse = is_reverse;
            this.same_edge_color = same_edge_color;
        }

        public GradientColorSetSimple(GradientStyle gradient_style, float rotate_angle, bool is_reverse, bool same_edge_color)
        {
            this.gradient_style = gradient_style;
            this.rotate_angle = rotate_angle;
            this.is_reverse = is_reverse;
            this.same_edge_color = same_edge_color;
        }

        public GradientColorSetSimple(GradientStyle gradient_style, float rotate_angle)
        {
            this.gradient_style = gradient_style;
            this.rotate_angle = rotate_angle;
        }

        public GradientColorSet colorSet(Color color)
        {
            var cs = new GradientColorSet();
            Color sec = color.lighterColor(secondary_opacity);
            if (secondary_alpha > 255)
                sec = sec.alpha(255);
            else if (secondary_alpha >= 0)
                sec = sec.alpha(secondary_alpha);
            if (same_edge_color)
            {
                if (is_reverse)
                    cs.Colors = new Color[] { sec, color, sec };
                else
                    cs.Colors = new Color[] { color, sec, color };
                cs.BlendPositions = new float[] { 0f, 0.5f, 1f };
            }
            else
            {
                if (is_reverse)
                    cs.Colors = new Color[] { sec, color };
                else
                    cs.Colors = new Color[] { color, sec };
                cs.BlendPositions = new float[] { 0f, 1f };
            }
            cs.GradientStyle = gradient_style;
            cs.RotateAngle = rotate_angle;
            return cs;
        }
    }
}