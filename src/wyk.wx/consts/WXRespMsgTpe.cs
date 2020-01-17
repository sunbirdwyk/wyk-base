using System.ComponentModel;

namespace wyk.wx
{
    /// <summary>
    /// 微信消息类型
    /// </summary>
    public enum WXRespMsgType
    {
        [Description("未知")]
        Unknown,
        [Description("文本")]
        text,
        [Description("图片")]
        image,
        [Description("语音")]
        voice,
        [Description("视频")]
        video,
        [Description("音乐")]
        music,
        [Description("图文")]
        news,
    }
}