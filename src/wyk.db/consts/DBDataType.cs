using System.ComponentModel;

namespace wyk.db
{
    public enum DBDataType
    {
        [Description("布尔值")]
        Bit = 0,
        [Description("字节")]
        Byte,
        [Description("短整型")]
        Short,
        [Description("整型")]
        Integer,
        [Description("长整型")]
        Long,
        [Description("数值")]
        Numeric,
        [Description("文本")]
        Varchar,
        [Description("长文本")]
        Text,
        [Description("日期时间")]
        DateTime,
        [Description("二进制")]
        Binary
    }
}
