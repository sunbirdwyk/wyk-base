using System.ComponentModel;

namespace wyk.basic
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LogLevel
    {
        [Description("详细")]
        Verbose,
        [Description("信息")]
        Info,
        [Description("调试")]
        Debug,
        [Description("警告")]
        Warning,
        [Description("错误")]
        Error,
        [Description("严重")]
        Fetal
    }
}
