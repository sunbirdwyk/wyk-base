using Newtonsoft.Json;
using System;
using System.Drawing;

namespace wyk.basic
{
    public class BarcodeContent
    {
        /// <summary>
        /// 条码内容
        /// </summary>
        public string content = "";

        /// <summary>
        /// 条码单位宽度(pt)
        /// </summary>
        public float unit = 2;
        /// <summary>
        /// 条码高度(pt)
        /// </summary>
        public float height = 30;
        /// <summary>
        /// 条码类型
        /// </summary>
        [JsonIgnore]
        public BarcodeType Type = BarcodeType.Code39;
        public string type
        {
            get => Type.ToString();
            set { if (!Enum.TryParse(value, out Type)) Type = BarcodeType.Code39; }
        }
        /// <summary>
        /// 前景色/条码颜色
        /// </summary>
        [JsonIgnore]
        public Color BarColor = Color.Black;
        public string bar_color
        {
            get => BarColor.hexString();
            set => BarColor = value.color();
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

        public BarcodeContent() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="content">条码内容</param>
        /// <param name="height">条码高度(pt)</param>
        public BarcodeContent(string content, float height)
        {
            this.content = content;
            this.height = height;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="content">条码内容</param>
        /// <param name="height">条码高度(pt)</param>
        /// <param name="unit">条码单位宽度(pt)</param>
        public BarcodeContent(string content, float height, float unit)
        {
            this.content = content;
            this.height = height;
            this.unit = unit;
        }
    }
}
