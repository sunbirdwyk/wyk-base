using System.ComponentModel;

namespace wyk.basic
{
    /// <summary>
    /// 支付状态
    /// </summary>
    public enum PayStatus
    {
        [Description("未支付")]
        NotPaid = 0,
        [Description("部分已支付")]
        PartiallyPaid,
        [Description("已支付")]
        Paid,
    }
}
