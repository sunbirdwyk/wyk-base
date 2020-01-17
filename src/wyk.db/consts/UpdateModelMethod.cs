using System.ComponentModel;

namespace wyk.db
{
    public enum UpdateModelMethod
    {
        [Description("原值为空时赋值")]
        SetWhenNull, 
        [Description("新实例时设置")]
        SetWhenNew, 
        [Description("UpdateModel的值非空时设置")]
        SetIfUpdateNotNull, 
        [Description("总是赋值")]
        Always 
    }
}
