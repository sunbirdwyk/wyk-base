using System.ComponentModel;

namespace wyk.basic
{   
    /// <summary>
    /// 九向对齐方式
    /// </summary>
    public enum Align9Direction
    {
        [Description("左上")]
        TopLeft,
        [Description("中上")]
        TopCenter,
        [Description("右上")]
        TopRight,
        [Description("左中")]
        MiddleLeft,
        [Description("居中")]
        MiddleCenter,
        [Description("右中")]
        MiddleRight,
        [Description("左下")]
        BottomLeft,
        [Description("中下")]
        BottomCenter,
        [Description("右下")]
        BottomRight,
    }
}
