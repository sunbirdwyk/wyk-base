using System.ComponentModel;

namespace wyk.basic
{
    /// <summary>
    /// 日期单位
    /// </summary>
    public enum DateFieldType
    {
        [Description("毫秒")]
        MiliSecond = 1,
        [Description("秒")]
        Second,
        [Description("分钟")]
        Minute,
        [Description("小时")]
        Hour,
        [Description("日")]
        Day,
        [Description("月")]
        Month,
        [Description("年")]
        Year
    }
}
