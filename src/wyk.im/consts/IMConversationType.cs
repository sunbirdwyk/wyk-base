using System.ComponentModel;

namespace wyk.im
{
    /// <summary>
    /// 聊天会话类型
    /// </summary>
    public enum IMConversationType
    {
        [Description("未知")]
        Unknown,
        [Description("单聊")]
        SingleChat,
        [Description("讨论组")]
        Discussion,
        [Description("群聊")]
        ChatGroup,
        [Description("聊天室")]
        ChatRoom,
        [Description("客户服务")]
        CustomerService,
        [Description("系统通知")]
        SystemNotify,
        [Description("应用公众服务")]
        AppPubService,
        [Description("公众服务")]
        PubService
    }
}
