using wyk.basic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace wyk.ui
{
    /// <summary>
    /// 用于定义渐变颜色
    /// </summary>
    public class GradientColorSet
    {
        /// <summary>
        /// 渐变颜色集合, 至少为两个颜色
        /// </summary>
        public Color[] Colors { get; set; } = new Color[] { Color.White, Color.Black };
        /// <summary>
        /// 混色比例(与颜色数相同, 少于颜色数时用1f补齐, 多于时最后一个变为1f)
        /// </summary>
        public float[] BlendPositions { get; set; } = new float[] { 0f, 1f };
        /// <summary>
        /// 渐变方式
        /// 注: 此值为None时只使用 colors中的第一个颜色, 其他颜色无用
        /// </summary>
        public GradientStyle GradientStyle { get; set; } = GradientStyle.None;
        /// <summary>
        /// 旋转角度, 在原有方向上的旋转角度
        /// </summary>
        public float RotateAngle { get; set; } = 0;

        public GradientColorSet() { }

        public GradientColorSet(Color[] colors, float[] blend_positions, GradientStyle gradient_style, float rotate_angle)
        {
            this.Colors = colors;
            this.BlendPositions = blend_positions;
            this.GradientStyle = gradient_style;
            this.RotateAngle = rotate_angle;
        }

        public GradientColorSet(Color[] colors, GradientStyle gradient_style, float rotate_angle)
        {
            this.Colors = colors;
            this.GradientStyle = gradient_style;
            this.RotateAngle = rotate_angle;
            if (colors != null)
            {
                BlendPositions = new float[colors.Length];
            }
            else
                BlendPositions = null;
        }

        public Brush brush(GraphicsPath path)
        {
            return brush(path, -1);
        }

        public Brush brush(GraphicsPath path, int alpha)
        {
            if (Colors == null || Colors.Length == 0)
                return new SolidBrush(Color.Transparent);
            if (alpha < 0)
                alpha = -1;
            if (alpha > 255)
                alpha = 255;
            if (Colors.Length == 1 && GradientStyle != GradientStyle.None)
            {
                var color = Colors[0];
                if (alpha == -1)
                    Colors = new Color[] { color, color.lighterColor(60), color };
                else
                    Colors = new Color[] { color.alpha(alpha), color.lighterColor(60).alpha(alpha), color.alpha(alpha) };
                BlendPositions = new float[] { 0f, 0.5f, 1f };
            }
            switch (GradientStyle)
            {
                case GradientStyle.None:
                default:
                    if (alpha == -1)
                        return new SolidBrush(Colors[0]);
                    else
                        return new SolidBrush(Colors[0].alpha(alpha));
                case GradientStyle.Linear:
                    {
                        float max_x = float.MinValue;
                        float min_x = float.MaxValue;
                        float max_y = float.MinValue;
                        float min_y = float.MaxValue;
                        foreach (var pt in path.PathPoints)
                        {
                            if (pt.X > max_x)
                                max_x = pt.X;
                            if (pt.Y > max_y)
                                max_y = pt.Y;
                            if (pt.X < min_x)
                                min_x = pt.X;
                            if (pt.Y < min_y)
                                min_y = pt.Y;
                        }
                        var rect = new RectangleF(min_x, min_y, max_x - min_x, max_y - min_y);
                        return linearBrush(rect, colorsWithAlpha(Colors, alpha), BlendPositions, RotateAngle);
                    }
                case GradientStyle.Radiant:
                    {
                        return pathBrush(path, colorsWithAlpha(Colors, alpha), BlendPositions);
                    }
            }
        }

        public Brush brush(RectangleF rect)
        {
            return brush(rect, -1);
        }

        public Brush brush(RectangleF rect, int alpha)
        {
            if (Colors == null || Colors.Length == 0)
                return new SolidBrush(Color.Transparent);
            if (alpha < 0)
                alpha = -1;
            if (alpha > 255)
                alpha = 255;
            if (Colors.Length == 1&&GradientStyle!= GradientStyle.None)
            {
                var color = Colors[0];
                if (alpha == -1)
                    Colors = new Color[] { color, color.lighterColor(60), color };
                else
                    Colors = new Color[] { color.alpha(alpha), color.lighterColor(60).alpha(alpha), color.alpha(alpha) };
                BlendPositions = new float[] { 0f, 0.5f, 1f };
            }
            switch (GradientStyle)
            {
                case GradientStyle.None:
                default:
                    if (alpha == -1)
                        return new SolidBrush(Colors[0]);
                    else
                        return new SolidBrush(Colors[0].alpha(alpha));
                case GradientStyle.Linear:
                    {
                        return linearBrush(rect, colorsWithAlpha(Colors, alpha), BlendPositions, RotateAngle);
                    }
                case GradientStyle.Radiant:
                    {
                        var path = new GraphicsPath();
                        path.AddRectangle(rect);
                        return pathBrush(path, colorsWithAlpha(Colors, alpha), BlendPositions);
                    }
            }
        }

        public static LinearGradientBrush linearBrush(RectangleF rect, Color[] colors, float[] blend_positions, float rotate_angle)
        {
            var brush = new LinearGradientBrush(rect, colors[0], colors[colors.Length - 1], rotate_angle);
            var blend = colorBlend(colors, blend_positions);
            if (blend != null)
                brush.InterpolationColors = blend;
            return brush;
        }

        public static PathGradientBrush pathBrush(GraphicsPath path, Color[] colors, float[] blend_positions)
        {
            var brush = new PathGradientBrush(path);
            brush.CenterColor = colors[0];
            brush.SurroundColors = new Color[] { colors[colors.Length - 1] };
            var blend = colorBlend(colors, blend_positions);
            if (blend != null)
                brush.InterpolationColors = blend;
            return brush;
        }

        private static Color[] colorsWithAlpha(Color[] colors, int alpha)
        {
            if (alpha < 0)
                return colors;
            if (alpha > 255)
                alpha = 255;
            if (colors == null || colors.Length == 0)
                return new Color[] { };
            var c_a = new Color[colors.Length];
            for (int i = 0; i < colors.Length; i++)
                c_a[i] = colors[i].alpha(alpha);
            return c_a;
        }

        private static ColorBlend colorBlend(Color[] colors, float[] blend_positions)
        {
            if (colors.Length > 1)
            {
                var blend = new ColorBlend(colors.Length);
                blend.Colors = colors;
                if (blend_positions.Length == colors.Length)
                {

                    blend.Positions = blend_positions;
                    if (blend.Positions[blend.Positions.Length - 1] != 1f)
                        blend.Positions[blend.Positions.Length - 1] = 1f;
                    if (blend.Positions[0] != 0f)
                        blend.Positions[0] = 0f;
                }
                else
                {
                    blend.Positions = new float[colors.Length];
                    blend.Positions[0] = 0f;
                    blend.Positions[blend.Positions.Length - 1] = 1f;
                    for (int i = 1; i < blend.Positions.Length - 1; i++)
                    {
                        try
                        {
                            blend.Positions[i] = blend_positions[i];
                        }
                        catch { blend.Positions[i] = 1f; }
                    }
                }
                return blend;
            }
            return null;
        }
    }
}