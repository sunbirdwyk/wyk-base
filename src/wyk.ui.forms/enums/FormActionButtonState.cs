using System.ComponentModel;

namespace wyk.ui.enums
{
    /// <summary>
    /// Form动作按钮状态
    /// </summary>
    public enum FormActionButtonState
    {
        /// <summary>
        /// 正常状态, 常规状态
        /// </summary>
        [Description("正常")]
        Normal,
        /// <summary>
        /// 高亮状态, Hover状态
        /// </summary>
        [Description("高亮")]
        Highlight,
        /// <summary>
        /// 按下状态
        /// </summary>
        [Description("按下")]
        Down,
        /// <summary>
        /// 按下离开状态
        /// </summary>
        [Description("按下离开")]
        DownLeave
    }
}
