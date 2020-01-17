using System.ComponentModel;

namespace wyk.basic
{
    public enum ValueStatus
    {
        [Description("未知")]
        [ReferedResource("")]
        Unknown,
        [Description("正常")]
        [ReferedResource("√")]
        Normal,
        [Description("偏低")]
        [ReferedResource("↓")]
        Low,
        [Description("偏高")]
        [ReferedResource("↑")]
        High,
        [Description("异常")]
        [ReferedResource("×")]
        Abnormal,
    }
}