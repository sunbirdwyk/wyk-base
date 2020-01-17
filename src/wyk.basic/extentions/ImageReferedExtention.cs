using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace wyk.basic
{
    public static class ImageReferedExtention
    {
        /// <summary>
        /// 将图片转为字节数组(Png)
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] toBytes(this Image image)
        {
            return image.toBytes(ImageFormat.Png);
        }

        /// <summary>
        /// 将图片转为字节数组
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format">图片格式</param>
        /// <returns></returns>
        public static byte[] toBytes(this Image image, ImageFormat format)
        {
            byte[] bytes = null;
            using(var ms= new MemoryStream())
            {
                image.Save(ms, format);
                bytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(bytes, 0, bytes.Length);
            }
            return bytes;
        }

        /// <summary>
        /// 将彩色图片转换为灰色图片
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static Image grayImage(this Image original)
        {
            return ImageUtil.transToGrayImage(original);
        }

        /// <summary>
        /// 将图片转换为base64字符串(png)
        /// 注:在网页中使用需要加上 data:image/png;base64,
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string base64(this Image image)
        {
            return base64(image, ImageFormat.Png);
        }

        /// <summary>
        /// 将图片转换为base64字符串
        /// 注:在网页中使用需要加上 data:image/[图片格式];base64,
        /// 网页支持的图片格式有:gif/png/jpeg/x-icon
        /// </summary>
        /// <param name="image"></param>
        /// <param name="image_format">图片格式</param>
        /// <returns></returns>
        public static string base64(this Image image, ImageFormat image_format)
        {
            try
            {
                var ms = new MemoryStream();
                image.Save(ms, image_format);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 将图片缩放至最大允许大小(锁定比例)
        /// 如果图片未超过最大值, 返回原图
        /// </summary>
        /// <param name="image">原图片</param>
        /// <param name="max_size">最大大小</param>
        /// <returns></returns>
        public static Image scaleForMaxSize(this Image image, Size max_size)
        {
            return image.scaleForMaxSize(max_size.Width, max_size.Height);
        }

        /// <summary>
        /// 将图片缩放至最大允许大小(锁定比例)
        /// 如果图片未超过最大值, 返回原图
        /// </summary>
        /// <param name="image">原图片</param>
        /// <param name="max_width">最大宽度</param>
        /// <param name="max_height">最大高度</param>
        /// <returns></returns>
        public static Image scaleForMaxSize(this Image image, int max_width, int max_height)
        {
            if (image.Width <= max_width && image.Height <= max_height)
                return image;
            int width = image.Width;
            int height = image.Height;
            if (width > max_width)
            {
                height = height * max_width / width;
                width = max_width;
            }
            if (height > max_height)
            {
                width = width * max_width / height;
                height = max_height;
            }
            var bm = new Bitmap(image, width, height);
            return bm;
        }
    }
}
