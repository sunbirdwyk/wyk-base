using System.Drawing;
using System.Drawing.Drawing2D;

namespace wyk.basic
{
    public static class GraphicsReferedExtention
    {
        /// <summary>
        /// 矩形区域是否与另一个矩形区域重叠
        /// </summary>
        /// <param name="self"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool overlays(this Rectangle self, Rectangle rect)
        {
            return GraphicsUtil.rectangleOverlayed(self, rect);
        }

        /// <summary>
        /// 矩形区域是否与另一个矩形区域重叠
        /// </summary>
        /// <param name="self"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool overlays(this RectangleF self, RectangleF rect)
        {
            return GraphicsUtil.rectangleOverlayed(self, rect);
        }

        /// <summary>
        /// 点是否包含在GraphicsPath内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool isInPath(this PointF point, GraphicsPath path)
        {
            return GraphicsUtil.pointInPath(point, path);
        }

        /// <summary>
        /// 点是否包含在GraphicsPath内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool isInPath(this Point point, GraphicsPath path)
        {
            return GraphicsUtil.pointInPath(point, path);
        }

        /// <summary>
        /// 点是否包含在GraphicsPath内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool isInRectagle(this PointF point, RectangleF rect)
        {
            return GraphicsUtil.pointInRectagle(point, rect);
        }

        /// <summary>
        /// 点是否包含在GraphicsPath内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool isInRectagle(this Point point, Rectangle rect)
        {
            return GraphicsUtil.pointInRectagle(point, rect);
        }

        /// <summary>
        /// GraphicsPath内是否包含点
        /// </summary>
        /// <param name="path"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool containsPoint(this GraphicsPath path, PointF point)
        {
            return GraphicsUtil.pointInPath(point, path);
        }

        /// <summary>
        /// GraphicsPath内是否包含点
        /// </summary>
        /// <param name="path"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool containsPoint(this GraphicsPath path, Point point)
        {
            return GraphicsUtil.pointInPath(point, path);
        }

        /// <summary>
        /// Rectagle内是否包含点
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool containsPoint(this RectangleF rect, PointF point)
        {
            return GraphicsUtil.pointInRectagle(point, rect);
        }

        /// <summary>
        /// Rectagle内是否包含点
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool containsPoint(this Rectangle rect, Point point)
        {
            return GraphicsUtil.pointInRectagle(point, rect);
        }

        /// <summary>
        /// 获取圆角矩形路径
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rectangle">原矩形坐标</param>
        /// <param name="radius">圆角半径</param>
        /// <param name="filter">圆角点筛选</param>
        /// <returns></returns>
        public static GraphicsPath generateRoundedRectangle(
               this Graphics g,
               RectangleF rectangle,
               float radius,
               RectangleCorner filter)
        {
            return GraphicsUtil.generateRoundedRectangle(g, rectangle, radius, filter);
        }

        /// <summary>
        /// 获取胶囊形状路径
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rectangle">原矩形坐标</param>
        /// <returns></returns>
        public static GraphicsPath generateCapsule(
            this Graphics g,
              RectangleF rectangle)
        {
            return GraphicsUtil.generateCapsule(g, rectangle);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void drawRoundedRectangle(
                this Graphics g,
                Pen pen,
                float x,
                float y,
                float width,
                float height,
                float radius,
                RectangleCorner filter)
        {
            GraphicsUtil.drawRoundedRectangle(g, pen, x, y, width, height, radius);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public static void drawRoundedRectangle(
                this Graphics g,
                Pen pen,
                float x,
                float y,
                float width,
                float height,
                float radius)
        {
            GraphicsUtil.drawRoundedRectangle(g, pen, x, y, width, height, radius);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public static void drawRoundedRectangle(
                this Graphics g,
                Pen pen,
                int x,
                int y,
                int width,
                int height,
                int radius)
        {
            GraphicsUtil.drawRoundedRectangle(g, pen, x, y, width, height, radius);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void drawRoundedRectangle(
            this Graphics g,
            Pen pen,
            Rectangle rectangle,
            int radius,
            RectangleCorner filter)
        {
            GraphicsUtil.drawRoundedRectangle(g, pen, rectangle, radius, filter);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        public static void drawRoundedRectangle(
            this Graphics g,
            Pen pen,
            Rectangle rectangle,
            int radius)
        {
            GraphicsUtil.drawRoundedRectangle(g, pen, rectangle, radius);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void drawRoundedRectangle(
            this Graphics g,
            Pen pen,
            RectangleF rectangle,
            int radius,
            RectangleCorner filter)
        {
            GraphicsUtil.drawRoundedRectangle(g, pen, rectangle, radius, filter);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        public static void drawRoundedRectangle(
            this Graphics g,
            Pen pen,
            RectangleF rectangle,
            int radius)
        {
            GraphicsUtil.drawRoundedRectangle(g, pen, rectangle, radius);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void fillRoundedRectangle(
                this Graphics g,
                Brush brush,
                float x,
                float y,
                float width,
                float height,
                float radius,
                RectangleCorner filter)
        {
            GraphicsUtil.fillRoundedRectangle(g, brush, x, y, width, height, radius);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public static void fillRoundedRectangle(
                this Graphics g,
                Brush brush,
                float x,
                float y,
                float width,
                float height,
                float radius)
        {
            GraphicsUtil.fillRoundedRectangle(g, brush, x, y, width, height, radius);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public static void fillRoundedRectangle(
                this Graphics g,
                Brush brush,
                int x,
                int y,
                int width,
                int height,
                int radius)
        {
            GraphicsUtil.fillRoundedRectangle(g, brush, x, y, width, height, radius);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void fillRoundedRectangle(
            this Graphics g,
            Brush brush,
            Rectangle rectangle,
            int radius,
            RectangleCorner filter)
        {
            GraphicsUtil.fillRoundedRectangle(g, brush, rectangle, radius, filter);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        public static void fillRoundedRectangle(
            this Graphics g,
            Brush brush,
            Rectangle rectangle,
            int radius)
        {
            GraphicsUtil.fillRoundedRectangle(g, brush, rectangle, radius);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void fillRoundedRectangle(
            this Graphics g,
            Brush brush,
            RectangleF rectangle,
            int radius,
            RectangleCorner filter)
        {
            GraphicsUtil.fillRoundedRectangle(g, brush, rectangle, radius, filter);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        public static void fillRoundedRectangle(
            this Graphics g,
            Brush brush,
            RectangleF rectangle,
            int radius)
        {
            GraphicsUtil.fillRoundedRectangle(g, brush, rectangle, radius);
        }

        /// <summary>
        /// 利用九宫图绘制图像
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="image">所需绘制的图片</param>
        /// <param name="target_rect">目标矩形</param>
        /// <param name="src_rect">来源矩形</param>
        public static void drawImageWithNineRect(this Graphics g, Image image, Rectangle target_rect, Rectangle src_rect)
        {
            GraphicsUtil.drawImageWithNineRect(g, image, target_rect, src_rect);
        }

        /// <summary>
        /// 在某个矩形区域内画逐渐变透明的边框
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="rect">绘图矩形区域</param>
        /// <param name="color">主颜色</param>
        /// <param name="edge_alpha">边框位置的透明度</param>
        /// <param name="center_alpha">中心区域透明度</param>
        /// <param name="edge_width">渐变边框宽度</param>
        public static void drawFadedEdgeBox(this Graphics g, Rectangle rect, Color color, int edge_alpha, int center_alpha, int edge_width)
        {
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            var start_color = color.alpha(edge_alpha);
            var end_color = color.alpha(center_alpha);
            //上
            var path = new GraphicsPath();
            path.AddLines(new Point[] {
                new Point(rect.X, rect.Y),
                new Point(rect.X + rect.Width, rect.Y),
                new Point(rect.X + rect.Width - edge_width, rect.Y + edge_width),
                new Point(rect.X + edge_width, rect.Y + edge_width) });
            var brush = new LinearGradientBrush(new Rectangle(rect.X, rect.Y, rect.Width, edge_width + 1), start_color, end_color, LinearGradientMode.Vertical);
            g.FillPath(brush, path);
            //右
            path = new GraphicsPath();
            path.AddLines(new Point[] {
                new Point(rect.X + rect.Width - edge_width, rect.Y + edge_width),
                new Point(rect.X + rect.Width, rect.Y),
                new Point(rect.X + rect.Width, rect.Y + rect.Height),
                new Point(rect.X + rect.Width - edge_width, rect.Y + rect.Height - edge_width) });
            brush = new LinearGradientBrush(new Rectangle(rect.X + rect.Width - edge_width - 1, rect.Y, edge_width + 1, rect.Height), end_color, start_color, LinearGradientMode.Horizontal);
            g.FillPath(brush, path);
            //下
            path = new GraphicsPath();
            path.AddLines(new Point[]
            {
                    new Point(rect.X,rect.Y+rect.Height),
                    new Point(rect.X+edge_width,rect.Y+rect.Height-edge_width),
                    new Point(rect.X+rect.Width-edge_width,rect.Y+rect.Height-edge_width),
                    new Point(rect.X+rect.Width,rect.Y+rect.Height)
            });
            brush = new LinearGradientBrush(new Rectangle(rect.X, rect.Y + rect.Height - edge_width - 1, rect.Width, edge_width + 1), end_color, start_color, LinearGradientMode.Vertical);
            g.FillPath(brush, path);
            //左
            path = new GraphicsPath();
            path.AddLines(new Point[] {
                new Point(rect.X, rect.Y),
                new Point(rect.X + edge_width, rect.Y + edge_width),
                new Point(rect.X + edge_width, rect.Y + rect.Height - edge_width),
                new Point(rect.X, rect.Y + rect.Height) });
            brush = new LinearGradientBrush(new Rectangle(rect.X, rect.Y, edge_width + 1, rect.Height), start_color, end_color, LinearGradientMode.Horizontal);
            g.FillPath(brush, path);
            //中
            g.FillRectangle(new SolidBrush(end_color), new Rectangle(rect.X + edge_width, rect.Y + edge_width, rect.Width - 2 * edge_width, rect.Height - 2 * edge_width));
        }

        /// <summary>
        /// 为矩形画4个边角
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="rect">绘图矩形区域</param>
        /// <param name="color">边角颜色</param>
        /// <param name="length">边角长度</param>
        /// <param name="width">边角线宽</param>
        public static void drawCorner(this Graphics g, Rectangle rect, Color color, int length, int width)
        {
            using (var pen = new Pen(color, width))
            {
                pen.EndCap = LineCap.Round;
                g.DrawLine(pen, new Point(rect.X, rect.Y + width / 2), new Point(rect.X + length, rect.Y + width / 2));
                g.DrawLine(pen, new Point(rect.X + width / 2, rect.Y), new Point(rect.X + width / 2, rect.Y + length));

                g.DrawLine(pen, new Point(rect.X + rect.Width, rect.Y + width / 2), new Point(rect.X + rect.Width - length, rect.Y + width / 2));
                g.DrawLine(pen, new Point(rect.X + rect.Width - width / 2, rect.Y), new Point(rect.X + rect.Width - width / 2, rect.Y + length));

                g.DrawLine(pen, new Point(rect.X + rect.Width - width / 2, rect.Y + rect.Height), new Point(rect.X + rect.Width - width / 2, rect.Y + rect.Height - length));
                g.DrawLine(pen, new Point(rect.X + rect.Width, rect.Y + rect.Height - width / 2), new Point(rect.X + rect.Width - length, rect.Y + rect.Height - width / 2));

                g.DrawLine(pen, new Point(rect.X, rect.Y + rect.Height - width / 2), new Point(rect.X + length, rect.Y + rect.Height - width / 2));
                g.DrawLine(pen, new Point(rect.X + width / 2, rect.Y + rect.Height), new Point(rect.X + width / 2, rect.Y + rect.Height - length));
            }
        }
    }
}
