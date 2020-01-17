using System.ComponentModel;

namespace wyk.basic
{
    /// <summary>
    /// 文档(单据/报告等)中页面元素的类型
    /// </summary>
    public enum UIPageItemType
    {
        [Description("文字")]
        Text,
        /// <summary>
        /// 矩形, 线条
        /// </summary>
        [Description("矩形")]
        Rectangle,
        [Description("图片")]
        Picture,
        [Description("条码")]
        BarCode,
        [Description("二维码")]
        QRCode
    }
}
