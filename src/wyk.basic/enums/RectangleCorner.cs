using System.ComponentModel;

namespace wyk.basic
{
    /// <summary>
    /// 方框边角筛选
    /// </summary>
    public enum RectangleCorner
    {
        [Description("无")]
        None = 0,
        [Description("左上")]
        TopLeft = 1,
        [Description("右上")]
        TopRight = 2,
        [Description("左下")]
        BottomLeft = 4,
        [Description("右下")]
        BottomRight = 8,
        [Description("全部")]
        All = TopLeft | TopRight | BottomLeft | BottomRight
    }
}
