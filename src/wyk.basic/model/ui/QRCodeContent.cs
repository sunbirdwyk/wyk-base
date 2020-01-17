using Newtonsoft.Json;
using System.Drawing;

namespace wyk.basic
{
    public class QRCodeContent
    {
        /*
         * logo获取优先级:
         * 1. logo
         * 2. logo_base64
         * 3. logo_url
         */
        /// <summary>
        /// logo的url地址, 可为文件地址
        /// 与logo图像/base64 三选一即可
        /// </summary>
        public string logo_url = "";
        /// <summary>
        /// logo图像
        /// 与logo的url地址/base64 三选一即可
        /// </summary>
        [JsonIgnore]
        public Image logo = null;
        /// <summary>
        /// logo的base64字符串
        /// 与logo的url地址/logo图像 三选一即可
        /// </summary>
        public string logo_base64 = "";

        /// <summary>
        /// 二维码内容
        /// </summary>
        public string content = "";

        /// <summary>
        /// 文本编码类型, 默认为空, 一般不需要修改
        /// </summary>
        public string encoding = "";
        /// <summary>
        /// 编码格式, 默认为BYTE, 一般不需要更改
        /// BYTE/NUMERIC/ALPHA_NUMERIC
        /// </summary>
        public string encode_mode = "BYTE";
        /// <summary>
        /// 测量度, 值越大二维码图片越大, 默认4
        /// </summary>
        public int scale = 4;
        /// <summary>
        /// 版本号, 默认为7, 一般不需要更改
        /// </summary>
        public int version = 7;
        /// <summary>
        /// 中间logo图的宽度(px)
        /// </summary>
        public int logo_width = 30;
        /// <summary>
        /// 中间logo图的高度(px)
        /// </summary>
        public int logo_height = 30;
        /// <summary>
        /// 校验类型, 默认为M, 一般不需要更改
        /// M/H/L/Q
        /// </summary>
        public string checksum = "M";

        /// <summary>
        /// 将logo图片序列化之后存入url字段, 用于支持旧版
        /// </summary>
        /// <param name="logo"></param>
        public void setLogoPicToUrlWithBase64(Image logo)
        {
            logo_url = "[base64]" + logo.base64();
        }

        /// <summary>
        /// 前景色, 二维码颜色
        /// </summary>
        [JsonIgnore]
        public Color ForeColor = Color.Black;
        public string fore_color
        {
            get => ForeColor.hexString();
            set => ForeColor = value.color();
        }

        /// <summary>
        /// 背景色
        /// </summary>
        [JsonIgnore]
        public Color BackColor = Color.White;
        public string back_color
        {
            get => BackColor.hexString();
            set => BackColor = value.color();
        }
    }
}
