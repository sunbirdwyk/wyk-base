using System.ComponentModel;

namespace wyk.wx
{
    /// <summary>
    /// 微信事件类型
    /// </summary>
    public enum WXEventType
    {
        [Description("未知")]
        Unknown,
        [Description("关注公众号")]
        subscribe,
        [Description("取消关注公众号")]
        unsubscribe,
        [Description("扫码进入公众号")]
        SCAN,
        [Description("点击菜单拉取消息")]
        CLICK,
        [Description("点击菜单跳转链接")]
        VIEW,
        [Description("上报地理位置")]
        LOCATION,
    }
}