using System.ComponentModel;

namespace wyk.db
{
    /// <summary>
    /// 数据库更新类型
    /// </summary>
    public enum DBUpdateType
    {
        [Description("新增列")]
        AddColumn,
        [Description("删除列")]
        DeleteColumn,
        [Description("Sql语句")]
        Sql
    }
}
