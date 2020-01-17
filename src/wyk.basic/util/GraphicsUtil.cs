using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace wyk.basic
{
    /// <summary>
    /// 图形操作单元
    /// </summary>
    public class GraphicsUtil
    {
        /// <summary>
        /// 判断两个矩形区域是否重叠
        /// </summary>
        /// <param name="rect1"></param>
        /// <param name="rect2"></param>
        /// <returns></returns>
        public static bool rectangleOverlayed(Rectangle rect1, Rectangle rect2)
        {
            if (pointInRectagle(new PointF(rect1.X, rect1.Y), rect2))
                return true;
            if (pointInRectagle(new PointF(rect1.X + rect1.Width, rect1.Y), rect2))
                return true;
            if (pointInRectagle(new PointF(rect1.X + rect1.Width, rect1.Y + rect1.Height), rect2))
                return true;
            if (pointInRectagle(new PointF(rect1.X, rect1.Y + rect1.Height), rect2))
                return true;
            return false;
        }

        /// <summary>
        /// 判断两个矩形区域是否重叠
        /// </summary>
        /// <param name="rect1"></param>
        /// <param name="rect2"></param>
        /// <returns></returns>
        public static bool rectangleOverlayed(RectangleF rect1, RectangleF rect2)
        {
            if (pointInRectagle(new PointF(rect1.X, rect1.Y), rect2))
                return true;
            if (pointInRectagle(new PointF(rect1.X + rect1.Width, rect1.Y), rect2))
                return true;
            if (pointInRectagle(new PointF(rect1.X + rect1.Width, rect1.Y + rect1.Height), rect2))
                return true;
            if (pointInRectagle(new PointF(rect1.X, rect1.Y + rect1.Height), rect2))
                return true;
            return false;
        }

        /// <summary>
        /// 判断点是否在绘图路径内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool pointInPath(PointF point, GraphicsPath path)
        {
            Region region = new Region();
            region.MakeEmpty();
            region.Union(path);
            return  region.IsVisible(point);
        }

        /// <summary>
        /// 判断点是否在绘图路径内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool pointInPath(Point point, GraphicsPath path)
        {
            Region region = new Region();
            region.MakeEmpty();
            region.Union(path);
            return region.IsVisible(point);
        }

        /// <summary>
        /// 判断点是否在绘图路径内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool pointInRectagle(PointF point, RectangleF rect)
        {
            /*Region region = new Region();
            region.MakeEmpty();
            region.Union(rect);
            return region.IsVisible(point);*/
            if (point.X >= rect.X &&
                point.X <= rect.X + rect.Width &&
                point.Y >= rect.Y &&
                point.Y <= rect.Y + rect.Height)
                return true;
            return false;
        }

        /// <summary>
        /// 判断点是否在绘图路径内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool pointInRectagle(Point point, Rectangle rect)
        {
            /*Region region = new Region();
            region.MakeEmpty();
            region.Union(rect);
            return region.IsVisible(point);*/
            if (point.X >= rect.X &&
                point.X <= rect.X + rect.Width &&
                point.Y >= rect.Y &&
                point.Y <= rect.Y + rect.Height)
                return true;
            return false;
        }

        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="angle">角度</param>
        /// <returns></returns>
        public static float radianFromAngle(float angle)
        {
            return (float)(angle * Math.PI / 180);
        }

        /// <summary>
        /// 弧度转角度
        /// </summary>
        /// <param name="radian">弧度</param>
        /// <returns></returns>
        public static float angleFromRadian(float radian)
        {
            return (float)(radian * 180 / Math.PI);
        }

        /// <summary>
        /// 以某点为中心旋转另一个点
        /// </summary>
        /// <param name="center">中心点</param>
        /// <param name="point">待旋转的点</param>
        /// <param name="angle">角度</param>
        /// <returns></returns>
        public static PointF pointRotate(PointF center, PointF point, float angle)
        {
            float radian = radianFromAngle(angle);
            double x = (point.X - center.X) * Math.Cos(radian) + (point.Y - center.Y) * Math.Sin(radian) + center.X;
            double y = -(point.X - center.X) * Math.Sin(radian) + (point.Y - center.Y) * Math.Cos(radian) + center.Y;
            return new PointF((float)x, (float)y);
        }

        /// <summary>
        /// 获取圆角矩形路径
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="rectangle">原矩形坐标</param>
        /// <param name="radius">圆角半径</param>
        /// <param name="filter">圆角点筛选</param>
        /// <returns></returns>
        public static GraphicsPath generateRoundedRectangle(
               Graphics graphics,
               RectangleF rectangle,
               float radius,
               RectangleCorner filter)
        {
            float diameter;
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0.0F || filter == RectangleCorner.None)
            {
                path.AddRectangle(rectangle);
                path.CloseFigure();
                return path;
            }
            else
            {
                if (radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
                    return generateCapsule(graphics, rectangle);
                diameter = radius * 2.0F;
                SizeF sizeF = new SizeF(diameter, diameter);
                RectangleF arc = new RectangleF(rectangle.Location, sizeF);
                if ((RectangleCorner.TopLeft & filter) == RectangleCorner.TopLeft)
                    path.AddArc(arc, 180, 90);
                else
                {
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                    path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                }
                arc.X = rectangle.Right - diameter;
                if ((RectangleCorner.TopRight & filter) == RectangleCorner.TopRight)
                    path.AddArc(arc, 270, 90);
                else
                {
                    path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                    path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X + arc.Width, arc.Y);
                }
                arc.Y = rectangle.Bottom - diameter;
                if ((RectangleCorner.BottomRight & filter) == RectangleCorner.BottomRight)
                    path.AddArc(arc, 0, 90);
                else
                {
                    path.AddLine(arc.X + arc.Width, arc.Y, arc.X + arc.Width, arc.Y + arc.Height);
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X + arc.Width, arc.Y + arc.Height);
                }
                arc.X = rectangle.Left;
                if ((RectangleCorner.BottomLeft & filter) == RectangleCorner.BottomLeft)
                    path.AddArc(arc, 90, 90);
                else
                {
                    path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X, arc.Y + arc.Height);
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                }
                path.CloseFigure();
            }
            return path;
        }

        /// <summary>
        /// 获取胶囊形状路径
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="rectangle">原矩形坐标</param>
        /// <returns></returns>
        public static GraphicsPath generateCapsule(
                Graphics graphics,
                RectangleF rectangle)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();
            try
            {
                if (rectangle.Width > rectangle.Height)
                {
                    diameter = rectangle.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(rectangle.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = rectangle.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (rectangle.Width < rectangle.Height)
                {
                    diameter = rectangle.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(rectangle.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = rectangle.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else path.AddEllipse(rectangle);
            }
            catch { path.AddEllipse(rectangle); }
            finally { path.CloseFigure(); }
            return path;
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void drawRoundedRectangle(
                Graphics graphics,
                Pen pen,
                float x,
                float y,
                float width,
                float height,
                float radius,
                RectangleCorner filter)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = generateRoundedRectangle(graphics, rectangle, radius, filter);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public static void drawRoundedRectangle(
                Graphics graphics,
                Pen pen,
                float x,
                float y,
                float width,
                float height,
                float radius)
        {
            drawRoundedRectangle(graphics,
                    pen,
                    x,
                    y,
                    width,
                    height,
                    radius,
                    RectangleCorner.All);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public static void drawRoundedRectangle(
                Graphics graphics,
                Pen pen,
                int x,
                int y,
                int width,
                int height,
                int radius)
        {
            drawRoundedRectangle(graphics,
                    pen,
                    Convert.ToSingle(x),
                    Convert.ToSingle(y),
                    Convert.ToSingle(width),
                    Convert.ToSingle(height),
                    Convert.ToSingle(radius));
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void drawRoundedRectangle(
            Graphics graphics,
            Pen pen,
            Rectangle rectangle,
            int radius,
            RectangleCorner filter)
        {
            drawRoundedRectangle(graphics,
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        public static void drawRoundedRectangle(
            Graphics graphics,
            Pen pen,
            Rectangle rectangle,
            int radius)
        {
            drawRoundedRectangle(graphics,
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleCorner.All);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void drawRoundedRectangle(
            Graphics graphics,
            Pen pen,
            RectangleF rectangle,
            int radius,
            RectangleCorner filter)
        {
            drawRoundedRectangle(graphics,
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        public static void drawRoundedRectangle(
            Graphics graphics,
            Pen pen,
            RectangleF rectangle,
            int radius)
        {
            drawRoundedRectangle(graphics,
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleCorner.All);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void fillRoundedRectangle(
                Graphics graphics,
                Brush brush,
                float x,
                float y,
                float width,
                float height,
                float radius,
                RectangleCorner filter)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = generateRoundedRectangle(graphics, rectangle, radius, filter);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(brush, path);
            graphics.SmoothingMode = old;
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public static void fillRoundedRectangle(
                Graphics graphics,
                Brush brush,
                float x,
                float y,
                float width,
                float height,
                float radius)
        {
            fillRoundedRectangle(graphics,
                    brush,
                    x,
                    y,
                    width,
                    height,
                    radius,
                    RectangleCorner.All);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        public static void fillRoundedRectangle(
                Graphics graphics,
                Brush brush,
                int x,
                int y,
                int width,
                int height,
                int radius)
        {
            fillRoundedRectangle(graphics,
                    brush,
                    Convert.ToSingle(x),
                    Convert.ToSingle(y),
                    Convert.ToSingle(width),
                    Convert.ToSingle(height),
                    Convert.ToSingle(radius));
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void fillRoundedRectangle(
            Graphics graphics,
            Brush brush,
            Rectangle rectangle,
            int radius,
            RectangleCorner filter)
        {
            fillRoundedRectangle(graphics,
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        public static void fillRoundedRectangle(
            Graphics graphics,
            Brush brush,
            Rectangle rectangle,
            int radius)
        {
            fillRoundedRectangle(graphics,
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleCorner.All);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        /// <param name="filter"></param>
        public static void fillRoundedRectangle(
            Graphics graphics,
            Brush brush,
            RectangleF rectangle,
            int radius,
            RectangleCorner filter)
        {
            fillRoundedRectangle(graphics,
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }

        /// <summary>
        /// 填充圆角矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="rectangle"></param>
        /// <param name="radius"></param>
        public static void fillRoundedRectangle(
            Graphics graphics,
            Brush brush,
            RectangleF rectangle,
            int radius)
        {
            fillRoundedRectangle(graphics,
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleCorner.All);
        }

        /// <summary>
        /// 利用九宫图绘制图像
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="img">所需绘制的图片</param>
        /// <param name="target_rect">目标矩形</param>
        /// <param name="src_rect">来源矩形</param>
        public static void drawImageWithNineRect(Graphics g, Image img, Rectangle target_rect, Rectangle src_rect)
        {
            int offset = 5;
            Rectangle NineRect = new Rectangle(img.Width / 2 - offset, img.Height / 2 - offset, 2 * offset, 2 * offset);
            int x = 0, y = 0, nWidth, nHeight;
            int xSrc = 0, ySrc = 0, nSrcWidth, nSrcHeight;
            int nDestWidth, nDestHeight;
            nDestWidth = target_rect.Width;
            nDestHeight = target_rect.Height;
            // 左上-------------------------------------;
            x = target_rect.Left;
            y = target_rect.Top;
            nWidth = NineRect.Left - src_rect.Left;
            nHeight = NineRect.Top - src_rect.Top;
            xSrc = src_rect.Left;
            ySrc = src_rect.Top;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
            // 上-------------------------------------;
            x = target_rect.Left + NineRect.Left - src_rect.Left;
            nWidth = nDestWidth - nWidth - (src_rect.Right - NineRect.Right);
            xSrc = NineRect.Left;
            nSrcWidth = NineRect.Right - NineRect.Left;
            nSrcHeight = NineRect.Top - src_rect.Top;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);
            // 右上-------------------------------------;
            x = target_rect.Right - (src_rect.Right - NineRect.Right);
            nWidth = src_rect.Right - NineRect.Right;
            xSrc = NineRect.Right;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
            // 左-------------------------------------;
            x = target_rect.Left;
            y = target_rect.Top + NineRect.Top - src_rect.Top;
            nWidth = NineRect.Left - src_rect.Left;
            nHeight = target_rect.Bottom - y - (src_rect.Bottom - NineRect.Bottom);
            xSrc = src_rect.Left;
            ySrc = NineRect.Top;
            nSrcWidth = NineRect.Left - src_rect.Left;
            nSrcHeight = NineRect.Bottom - NineRect.Top;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);
            // 中-------------------------------------;
            x = target_rect.Left + NineRect.Left - src_rect.Left;
            nWidth = nDestWidth - nWidth - (src_rect.Right - NineRect.Right);
            xSrc = NineRect.Left;
            nSrcWidth = NineRect.Right - NineRect.Left;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);

            // 右-------------------------------------;
            x = target_rect.Right - (src_rect.Right - NineRect.Right);
            nWidth = src_rect.Right - NineRect.Right;
            xSrc = NineRect.Right;
            nSrcWidth = src_rect.Right - NineRect.Right;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);

            // 左下-------------------------------------;
            x = target_rect.Left;
            y = target_rect.Bottom - (src_rect.Bottom - NineRect.Bottom);
            nWidth = NineRect.Left - src_rect.Left;
            nHeight = src_rect.Bottom - NineRect.Bottom;
            xSrc = src_rect.Left;
            ySrc = NineRect.Bottom;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
            // 下-------------------------------------;
            x = target_rect.Left + NineRect.Left - src_rect.Left;
            nWidth = nDestWidth - nWidth - (src_rect.Right - NineRect.Right);
            xSrc = NineRect.Left;
            nSrcWidth = NineRect.Right - NineRect.Left;
            nSrcHeight = src_rect.Bottom - NineRect.Bottom;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);
            // 右下-------------------------------------;
            x = target_rect.Right - (src_rect.Right - NineRect.Right);
            nWidth = src_rect.Right - NineRect.Right;
            xSrc = NineRect.Right;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// 建立带有圆角样式的路径。
        /// </summary>
        /// <param name="rect">用来建立路径的矩形</param>
        /// <param name="radius">圆角的大小</param>
        /// <returns>建立的路径</returns>
        public static GraphicsPath getRoundedRectGraphicsPath(Rectangle rect, int radius)
        {
            int diameter = 2 * radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            // 左上角
            path.AddArc(arcRect, 180, 90);
            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}