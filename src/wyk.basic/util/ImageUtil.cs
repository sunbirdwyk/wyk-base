using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;

namespace wyk.basic
{
    /// <summary>
    /// 图片处理单元
    /// </summary>
    public class ImageUtil
    {
        /// <summary>
        /// 将字节流转换为图片
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Image fromBytes(byte[] bytes)
        {
            Image image = null;
            using (var ms = new MemoryStream(bytes))
            {
                try
                {
                    ms.Position = 0;
                    image = Image.FromStream(ms);
                }
                catch { }
            }
            return image;
        }

        /// <summary>
        /// 绘制阴影效果的字符串的图像
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="font">字体</param>
        /// <param name="fore_color">颜色</param>
        /// <param name="shadow_color">阴影颜色</param>
        /// <param name="shadow_width">阴影的宽度</param>
        /// <returns></returns>
        public static Image imageWithShadowEffectForString(string str, Font font, Color fore_color, Color shadow_color, int shadow_width)
        {
            Bitmap result = null;
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF size = g.MeasureString(str, font);
                using (Bitmap shadow = new Bitmap((int)size.Width, (int)size.Height))
                using (Graphics shadow_g = Graphics.FromImage(shadow))
                using (SolidBrush brush_shadow = new SolidBrush(shadow_color))
                using (SolidBrush brush_fore = new SolidBrush(fore_color))
                {
                    shadow_g.SmoothingMode = SmoothingMode.HighQuality;//设置为高质量
                    shadow_g.InterpolationMode = InterpolationMode.HighQualityBilinear;//设置为高质量的收缩
                    shadow_g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;//消除锯齿
                    shadow_g.DrawString(str, font, brush_shadow, 0, 0);
                    result = new Bitmap(shadow.Width + shadow_width, shadow.Height + shadow_width);
                    using (Graphics result_g = Graphics.FromImage(result))
                    {
                        result_g.SmoothingMode = SmoothingMode.HighQuality;//设置为高质量
                        result_g.InterpolationMode = InterpolationMode.HighQualityBilinear;//设置为高质量的收缩
                        result_g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;//消除锯齿
                        for (int x = 0; x <= shadow_width; x++)
                        {
                            for (int y = 0; y <= shadow_width; y++)
                            {
                                result_g.DrawImageUnscaled(shadow, x, y);
                            }
                        }
                        result_g.DrawString(str, font, brush_fore, shadow_width / 2, shadow_width / 2);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取当前命名空间下的资源图片
        /// </summary>
        /// <param name="path">图片资源路径</param>
        public static Image imageFromResourceStream(string path)
        {
            return Image.FromStream(
                Assembly.GetExecutingAssembly().
                GetManifestResourceStream(
                MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + path));
        }

        /// <summary>
        /// 获取纯色图片(默认大小50*50)
        /// </summary>
        /// <param name="color">颜色</param>
        /// <returns></returns>
        public static Image imageWithColor(Color color)
        {
            return imageWithColor(color, new Size(50, 50));
        }

        /// <summary>
        /// 获取纯色图片
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="size">大小</param>
        /// <returns></returns>
        public static Image imageWithColor(Color color, Size size)
        {
            Bitmap bm = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bm);
            g.FillRectangle(new SolidBrush(color), 0, 0, bm.Width, bm.Height);
            g.Dispose();
            return bm;
        }

        /// <summary>
        /// 将彩色图片转换为灰色图片
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static Image transToGrayImage(Image original)
        {
            Bitmap bitmap = new Bitmap(original);
            //定义锁定bitmap的rect的指定范围区域
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            //加锁区域像素
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            //位图的首地址
            var ptr = bitmapData.Scan0;
            //stride：扫描行
            int len = bitmapData.Stride * bitmap.Height;
            var bytes = new byte[len];
            //锁定区域的像素值copy到byte数组中
            Marshal.Copy(ptr, bytes, 0, len);
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width * 3; j = j + 3)
                {
                    var color = bytes[i * bitmapData.Stride + j + 2] * 0.299
                          + bytes[i * bitmapData.Stride + j + 1] * 0.587
                          + bytes[i * bitmapData.Stride + j] * 0.114;

                    bytes[i * bitmapData.Stride + j]
                         = bytes[i * bitmapData.Stride + j + 1]
                         = bytes[i * bitmapData.Stride + j + 2] = (byte)color;
                }
            }
            //copy回位图
            Marshal.Copy(bytes, 0, ptr, len);
            //解锁
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }

        /// <summary>
        /// 通过url获取图片
        /// </summary>
        /// <param name="url">图片url或文件地址</param>
        /// <returns></returns>
        public static Image fromUrl(string url)
        {
            try
            {
                if (url.Substring(0, 4).ToLower() == "http")
                {
                    var request = WebRequest.Create(url) as HttpWebRequest;
                    var response = request.GetResponse() as HttpWebResponse;
                    var st = response.GetResponseStream();
                    var ms = new MemoryStream();
                    long totalDownloadedByte = 0;
                    byte[] by = new byte[1024];
                    int osize = 0;
                    do
                    {
                        osize = st.Read(by, 0, by.Length);
                        totalDownloadedByte = osize + totalDownloadedByte;
                        ms.Write(by, 0, osize);
                    } while (osize > 0);
                    var image = Image.FromStream(ms);
                    ms.Close();
                    st.Close();
                    return image;
                }
                else
                {
                    var fs = new FileStream(url, FileMode.Open);
                    var image = Image.FromStream(fs);
                    fs.Close();
                    return image;
                }
            }
            catch { }
            return null;
        }

        public static Image fromBase64(string base64)
        {
            try
            {
                if (base64.Substring(0, 11).ToLower() == "data:image/")
                    base64 = base64.Split(',')[1];
            }
            catch { }
            try
            {
                byte[] b = Convert.FromBase64String(base64);
                MemoryStream ms = new MemoryStream(b);
                Image image = Image.FromStream(ms);
                ms.Close();
                return image;
            }
            catch { }
            return null;
        }
    }
}