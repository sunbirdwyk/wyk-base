using System.ComponentModel;

namespace wyk.basic
{
    /// <summary>
    /// 指定接下来的操作
    /// </summary>
    public enum FollowAction
    {
        /// <summary>
        /// 无任何操作
        /// </summary>
        [Description("无任何操作")]
        None,
        /// <summary>
        /// 插入新记录
        /// </summary>
        [Description("插入新记录")]
        Insert,
        /// <summary>
        /// 更新记录
        /// </summary>
        [Description("更新记录")]
        Update,
        /// <summary>
        /// 删除记录
        /// </summary>
        [Description("删除记录")]
        Delete,
        /// <summary>
        /// 刷新当前页面
        /// </summary>
        [Description("刷新")]
        Refresh,
        /// <summary>
        /// 关闭当前页面
        /// </summary>
        [Description("关闭")]
        Close,
        /// <summary>
        /// 关闭当前页面并刷新父页面
        /// </summary>
        [Description("关闭并刷新")]
        CloseAndRefresh,
        /// <summary>
        /// 错误提示(弹框提示)
        /// </summary>
        [Description("错误提示(弹框)")]
        Alert,
        /// <summary>
        /// 错误信息(无弹框提示时使用)
        /// </summary>
        [Description("错误信息")]
        ErrorMessage,
        /// <summary>
        /// 自定义, 此时需要实例中建立另一个字段来判断具体什么操作
        /// </summary>
        [Description("自定义")]
        Custom
    }
}
