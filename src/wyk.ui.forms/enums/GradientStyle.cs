using System.ComponentModel;

namespace wyk.ui
{
    /// <summary>
    /// 渐变类型
    /// </summary>
    public enum GradientStyle
    {
        [Description("无渐变")]
        None,
        [Description("线性")]
        Linear,
        [Description("辐射型(从中心到周围")]
        Radiant,
    }
}
