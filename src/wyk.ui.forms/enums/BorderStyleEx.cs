using System.ComponentModel;

namespace wyk.ui
{
    /// <summary>
    /// 边框样式(扩展)
    /// </summary>
    public enum BorderStyleEx
    {
        [Description("无边框")]
        None,
        /// <summary>
        /// 普通矩形边框
        /// </summary>
        [Description("矩形")]
        Rectangle,
        /// <summary>
        /// 圆角矩形边框
        /// </summary>
        [Description("圆角矩形")]
        RoundedRectangle,
        /// <summary>
        /// 胶囊形边框
        /// </summary>
        [Description("胶囊形")]
        Capsule,
        /// <summary>
        /// 下划线(只有下边框)
        /// </summary>
        [Description("下划线")]
        BottomLine 
    }
}
