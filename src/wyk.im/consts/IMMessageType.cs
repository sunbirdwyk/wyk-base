using System.ComponentModel;

namespace wyk.im
{
    /// <summary>
    /// 聊天消息类型
    /// </summary>
    public enum IMMessageType
    {
        [Description("自定义")]
        Custom,
        [Description("文本")]
        Text,
        [Description("图片")]
        Image,
        [Description("语音")]
        Voice,
        [Description("图文")]
        ImageText,
        [Description("文件")]
        File,
        [Description("位置")]
        Location,
        [Description("小视频")]
        MicroVideo,
        [Description("公众服务(单图文)")]
        ///Public Service, 以下PS同
        PS,
        [Description("公众服务(多图文)")]
        PSMulti,
        [Description("好友通知")]
        ContactNotify,
        [Description("提示条通知")]
        InfoBar,
        [Description("资料通知")]
        Profile,
        [Description("命令")]
        Command,
        [Description("通用命令通知")]
        CommandNotify,
        [Description("群组通知")]
        GroupNotify,
        [Description("已读通知")]
        ReadNotify,
        [Description("公众服务命令")]
        PSCommand,
        [Description("输入状态通知")]
        TypingStatus,
        [Description("群消息已读回执")]
        GroupReadNotify,
    }
}
