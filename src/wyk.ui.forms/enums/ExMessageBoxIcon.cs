using System.ComponentModel;

namespace wyk.ui
{
    /// <summary>
    /// 提示框图标
    /// </summary>
    public enum ExMessageBoxIcon
    {
        [Description("无")]
        None = 1,
        [Description("错误")]
        Error,
        [Description("信息")]
        Information,
        [Description("成功")]
        Successed,
        [Description("提问")]
        Question,
        [Description("警示")]
        Warning
    }
}
