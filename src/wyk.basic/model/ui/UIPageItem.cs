using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Text;

namespace wyk.basic
{
    public class UIPageItem
    {
        /// <summary>
        /// 元素ID, 通常为从第一个元素开始为1, 后面顺序加1, 用于在编辑时确认当前所编辑的元素
        /// </summary>
        public int item_id = 0;
        /// <summary>
        /// 所在页面信息(页面类型, 顺序号)
        /// </summary>
        [JsonIgnore]
        public UIPageInfo PageInfo
        {
            get => new UIPageInfo(page_type, page_index);
            set { page_type = UIPageInfo.PageTypeToString(value.page_type); page_index = value.page_index; }
        }
        public string page_type = UIPageInfo.PAGE_TYPE_CONTENT;
        public int page_index = 0;
        /// <summary>
        /// 元素类型(文本/图片/矩形等)
        /// </summary>
        [JsonIgnore]
        public UIPageItemType ItemType = UIPageItemType.Text;

        public string item_type
        {
            get => ItemType.name();
            set => ItemType = value.enumFromName<UIPageItemType>();
        }

        /// <summary>
        /// 边界信息(位置,大小)
        /// </summary>
        [JsonIgnore]
        public UIBounds Bounds = new UIBounds();
      
        public string bounds
        {
            get => Bounds.content;
            set => Bounds = new UIBounds(value);
        }
        /// <summary>
        /// 字体/颜色/对齐方式
        /// </summary>
        [JsonIgnore]
        public UIFont Font = new UIFont();
        public string font
        {
            get => Font.content;
            set => Font = new UIFont(value);
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string content = "";
        /// <summary>
        /// 其他参数
        /// </summary>
        public ObjectDictionary Parameters = new ObjectDictionary();
        [JsonIgnore]
        public string parameters
        {
            get => JsonConvert.SerializeObject(Parameters);
            set
            {
                Parameters = JsonConvert.DeserializeObject<ObjectDictionary>(parameters);
                if (Parameters == null)
                    Parameters = new ObjectDictionary();
            }
        }

        /// <summary>
        /// 内容图片, BarCode和QRCode时使用, 先在外面生成好对应的图片, 然后再传入文档/报告生成函数中进行绘制
        /// </summary>
        [JsonIgnore]
        public Image content_image = null;

        public string display()
        {

            var sb = new StringBuilder();
            sb.Append("[");
            var show_content = "";
            switch (ItemType)
            {
                case UIPageItemType.Text:
                    sb.Append("Text");
                    show_content = content;
                    break;
                case UIPageItemType.Rectangle:
                    sb.Append("Rect");
                    show_content = string.Format("{0}×{1}", Math.Round(Bounds.width, 2), Math.Round(Bounds.height, 2));
                    break;
                case UIPageItemType.Picture:
                    sb.Append("Pic");
                    if (is_bg_image)
                        show_content = "背景图片";
                    else
                        show_content = "普通图片";
                    break;
                case UIPageItemType.BarCode:
                    sb.Append("Bar");
                    show_content = content;
                    break;
                case UIPageItemType.QRCode:
                    sb.Append("QR");
                    show_content = content;
                    break;
            }
            sb.Append("](");
            sb.Append(Math.Round(Bounds.x, 2));
            sb.Append(",");
            sb.Append(Math.Round(Bounds.y, 2));
            sb.Append(")");
            sb.Append(show_content);
            return sb.ToString();
        }

        #region 页面元素参数 
        /// <summary>
        /// Rectangle
        /// 是否为实心矩形(是否填充矩形内部)
        /// </summary>
        [JsonIgnore]
        public bool is_solid
        {
            get => Parameters.getBoolean("solid");
            set => Parameters.set("solid", value);
        }
        /// <summary>
        /// Rectangle
        /// 线宽, 当矩形元素的is_solid属性为false时, 此值决定矩形框的边线宽度
        /// </summary>
        [JsonIgnore]
        public float line_width
        {
            get
            {
                var v = Parameters.getFloat("line_width");
                if (v < 0.1)
                    v = 0.1f;
                return v;
            }
            set => Parameters.set("line_width", value);
        }
        /// <summary>
        /// Picture
        /// 图片网址URL
        /// </summary>
        [JsonIgnore]
        public string picture_url
        {
            get => Parameters.getString("picture_url");
            set => Parameters.set("picture_url", value);
        }
        /// <summary>
        /// Picture 的图片
        /// 为了与旧版兼容, picture_url中可以放入base64的内容
        /// </summary>
        [JsonIgnore]
        public Image picture
        {
            get
            {
                var pic_url = picture_url;
                if (pic_url.StartsWith("[base64]"))
                    return ImageUtil.fromBase64(pic_url.Substring(8));
                else
                    return ImageUtil.fromUrl(pic_url);
            }
            set => picture_url = "[base64]" + value.base64();
        }
        /// <summary>
        /// Picture
        /// 图片型元素是否为背景图片
        /// </summary>
        [JsonIgnore]
        public bool is_bg_image
        {
            get => Parameters.getBoolean("bg_image");
            set => Parameters.set("bg_image", value);
        }


        /// <summary>
        /// BarCode
        /// 条码类型
        /// </summary>
        [JsonIgnore]
        public string barcode_type
        {
            get => Parameters.getString("barcode_type");
            set => Parameters.set("barcode_type", value);
        }
        /// <summary>
        /// BarCode
        /// 条码单位宽度(pt)
        /// </summary>
        [JsonIgnore]
        public float barcode_unit
        {
            get
            {
                var v = Parameters.getFloat("barcode_unit");
                if (v <= 0)
                    v = 2;
                return v;
            }
            set => Parameters.set("barcode_unit", value);
        }
        /// <summary>
        /// BarCode
        /// 条码背景色
        /// </summary>
        [JsonIgnore]
        public string barcode_bg_color
        {
            get => Parameters.getString("barcode_bg_color");
            set => Parameters.set("barcode_bg_color", value);
        }

        /// <summary>
        /// BarCode
        /// 获取条码配置信息
        /// </summary>
        [JsonIgnore]
        public BarcodeContent barcode_content
        {
            get
            {
                var bar_content = new BarcodeContent();
                bar_content.type = barcode_type;
                bar_content.unit = barcode_unit;
                bar_content.back_color = barcode_bg_color;
                bar_content.bar_color = Font.color.hexString();
                bar_content.content = content;
                return bar_content;
            }
            set
            {
                barcode_type = value.type;
                barcode_unit = value.unit;
                barcode_bg_color = value.back_color;
                Font.color = value.bar_color.color();
                content = value.content;
            }
        }

        /// <summary>
        /// QRCode
        /// 二维码图片的大小(测量度, 值越大二维码图片越大, 默认4)
        /// 注: 此处大小非常规的测量单位, 具体大小应参考实际生成出来的大小来确定
        /// </summary>
        [JsonIgnore]
        public int qr_size
        {
            get
            {
                var v = Parameters.getInt("qr_size");
                if (v <= 0)
                    v = 4;
                return v;
            }
            set => Parameters.set("qr_size", value);
        }
        /// <summary>
        /// QRCode
        /// 二维码背景色
        /// </summary>
        [JsonIgnore]
        public string qr_bg_color
        {
            get => Parameters.getString("qr_bg_color");
            set => Parameters.set("qr_bg_color", value);
        }
        /// <summary>
        /// QRCode
        /// 二维码中Logo图片的宽度, px
        /// </summary>
        [JsonIgnore]
        public int logo_width
        {
            get
            {
                var v = Parameters.getInt("logo_width");
                if (v <= 0)
                    v = 30;
                return v;
            }
            set => Parameters.set("logo_width", value);
        }
        /// <summary>
        /// QRCode
        /// 二维码中Logo图片的高度, px
        /// </summary>
        [JsonIgnore]
        public int logo_height
        {
            get
            {
                var v = Parameters.getInt("logo_height");
                if (v <= 0)
                    v = 30;
                return v;
            }
            set => Parameters.set("logo_height", value);
        }
        /// <summary>
        /// QRCode
        /// 二维码中的Logo图片的网址URL
        /// </summary>
        [JsonIgnore]
        public string logo_url
        {
            get => Parameters.getString("logo_url");
            set => Parameters.set("logo_url", value);
        }

        /// <summary>
        /// 将logo以base64的形式设置到logo_url中
        /// 用于支持旧版
        /// </summary>
        /// <param name="logo"></param>
        public void setLogoToUrlWithBase64(Image logo)
        {
            logo_url = "[base64]" + logo.base64();
        }

        [JsonIgnore]
        public QRCodeContent qrcode_content
        {
            get
            {
                var qr_content = new QRCodeContent();
                qr_content.scale = qr_size;
                qr_content.back_color = qr_bg_color;
                qr_content.logo_width = logo_width;
                qr_content.logo_height = logo_height;
                qr_content.logo_url = logo_url;
                qr_content.ForeColor = Font.color;
                qr_content.content = content;
                return qr_content;
            }
            set
            {
                qr_size = value.scale;
                qr_bg_color = value.back_color;
                logo_width = value.logo_width;
                logo_height = value.logo_height;
                logo_url = value.logo_url;
                Font.color = value.ForeColor;
                content = value.content;
            }
        }

        /// <summary>
        /// BarCode / QRCode
        /// 生成预览图片后的ID
        /// 保存此ID后再次预览图片时不需要再重复生成此图片
        /// </summary>
        [JsonIgnore]
        public string preview_id
        {
            get => Parameters.getString("preview_id");
            set => Parameters.set("preview_id", value);
        }
        #endregion

    }
}
