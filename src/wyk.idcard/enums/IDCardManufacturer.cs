using System.ComponentModel;

namespace wyk.idcard
{
    public enum IDCardManufacturer
    {
        [Description("未知")]
        Unknown,
        [Description("华视")]
        ChinaVision,
        [Description("国腾")]
        GoldTel,
        [Description("通用")]
        Common,
        [Description("智羿星")]
        ZhiYiXing,
    }
}