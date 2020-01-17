using System.ComponentModel;

namespace wyk.ui.enums
{
    /// <summary>
    /// 控件状态
    /// </summary>
    public enum ControlState
    {
        [Description("正常状态")]
        Normal = 0,
        [Description("鼠标进入")]
        Highlight = 1,
        [Description("鼠标按下")]
        Down = 2,
        [Description("获得焦点")]
        Focus = 3,
        [Description("控件禁用")]
        Disabled = 4
    }
}
