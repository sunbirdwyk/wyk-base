using System.ComponentModel;

namespace wyk.ui.enums
{
    /// <summary>
    /// Form标题栏的显示类型
    /// </summary>
    public enum FormTitleBarUIMode
    {
        /// <summary>
        /// 独立显示, 控件无法放在标题栏内
        /// </summary>
        [Description("独立显示")]
        Separated,
        /// <summary>
        /// Form内显示, 控件可以放在标题栏内
        /// </summary>
        [Description("Form内显示")]
        Within
    }
}
