using System.ComponentModel;

namespace wyk.ui
{
    /// <summary>
    /// 图表标题(标注)类型
    /// </summary>
    public enum ChartTextType
    {
        [Description("无标题")]
        None,
        [Description("图表块上")]
        Over,
        [Description("图表块周围")]
        Surround,
    }
}
