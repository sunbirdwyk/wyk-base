using System.ComponentModel;

namespace wyk.im
{
    public enum IMOnlineStatus
    {
        [Description("未知")]
        Unknown,
        [Description("离线")]
        OffLine,
        [Description("在线")]
        Online,
    }
}
