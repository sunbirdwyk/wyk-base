using System.ComponentModel;

namespace wyk.basic
{
    /// <summary>
    /// 文档(单据/报告等)页面类型
    /// </summary>
    public enum UIPageType
    {
        [Description("前置页")]
        Preset,
        [Description("内容页")]
        Content,
        [Description("后置页")]
        Postset,
    }
}
