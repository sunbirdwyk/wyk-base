using System.ComponentModel;

namespace wyk.ui
{
    /// <summary>
    /// 通知消息样式
    /// </summary>
    public enum NotificationUIStyle
    {
        [Description("深色")]
        Dark,
        [Description("浅色")]
        Light,
        [Description("蓝")]
        Blue,
        [Description("蓝(浅色)")]
        BlueLight,
        [Description("绿")]
        Green,
        [Description("绿(浅色)")]
        GreenLight,
        [Description("红")]
        Red,
        [Description("红(浅色)")]
        RedLight,
        [Description("橙")]
        Orange,
        [Description("橙(浅色)")]
        OrangeLight
    }
}
