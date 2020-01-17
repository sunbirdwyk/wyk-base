using System.ComponentModel;

namespace wyk.wx
{
    /// <summary>
    /// 微信消息类型
    /// </summary>
    public enum WXMsgType
    {
        [Description("未知")]
        Unknown,
        [Description("事件")]
        @event,
        [Description("文本")]
        text,
        [Description("图片")]
        image,
        [Description("语音")]
        voice,
        [Description("视频")]
        video,
        [Description("小视频")]
        shortvideo,
        [Description("位置")]
        location,
        [Description("链接")]
        link,
    }
}