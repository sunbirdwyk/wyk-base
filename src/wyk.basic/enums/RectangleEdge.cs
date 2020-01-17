using System.ComponentModel;

namespace wyk.basic
{
    /// <summary>
    /// 矩形边框筛选
    /// </summary>
    public enum RectangleEdge
    {
        /// <summary>
        /// 无边线
        /// </summary>
        [Description("无边线")]
        None = 0,
        /// <summary>
        /// 上边线
        /// </summary>
        [Description("上")]
        Top = 1,
        /// <summary>
        /// 右边线
        /// </summary>
        [Description("右")]
        Right = 2,
        /// <summary>
        /// 下边线
        /// </summary>
        [Description("下")]
        Bottom = 4,
        /// <summary>
        /// 左边线
        /// </summary>
        [Description("左")]
        Left = 8,
        /// <summary>
        /// 全部边线
        /// </summary>
        [Description("全部")]
        All = Top | Right | Bottom | Left
    }
}
