using System.ComponentModel;

namespace wyk.basic
{
    /// <summary>
    /// 连接状态
    /// </summary>
    public enum ConnectionStatus
    {
        [Description("未知")]
        Unknown,
        [Description("连接中")]
        Connecting,
        [Description("已连接")]
        Connected,
        [Description("已断开")]
        Disconnected
    }
}
