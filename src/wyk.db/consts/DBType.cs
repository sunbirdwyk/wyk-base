using System.ComponentModel;

namespace wyk.db
{
    /// <summary>
    /// 数据库类型枚举
    /// </summary>
    public enum DBType
    {
        [Description("未知类型")]
        Unknown = 0,
        SqlServer,
        Oracle,
        Access,
        MySql,
    }
}