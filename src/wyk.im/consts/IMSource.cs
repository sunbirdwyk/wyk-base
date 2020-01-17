using System.ComponentModel;

namespace wyk.im
{
    /// <summary>
    /// 消息发送源
    /// </summary>
    public enum IMSource
    {
        [Description("未知")]
        Unknown,
        [Description("iOS")]
        iOS,
        [Description("Android")]
        Android,
        [Description("Web端")]
        Websocket,
        [Description("小程序")]
        MiniProgram,
    }
}
