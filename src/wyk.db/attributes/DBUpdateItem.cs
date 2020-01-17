using System;

namespace wyk.db
{
    /// <summary>
    /// 数据库更新子项信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DBUpdateItem : Attribute
    {
        /// <summary>
        /// 数据库更新类型
        /// </summary>
        public DBUpdateType update_type = DBUpdateType.Sql;
        /// <summary>
        /// 相关数据表, 只有AddColumn/DeleteColumn可用
        /// </summary>
        public string table_name = "";
        /// <summary>
        /// 相关列信息, 只有AddColumn可用
        /// </summary>
        public DBColumn column_info = null;

        public DBUpdateItem()
        {
            update_type = DBUpdateType.Sql;
            table_name = "";
            column_info = null;
        }

        public DBUpdateItem(DBUpdateType UpdateType)
        {
            update_type = UpdateType;
            table_name = "";
            column_info = null;
        }

        public DBUpdateItem(DBUpdateType UpdateType, string TableName)
        {
            update_type = UpdateType;
            table_name = TableName;
            column_info = null;
        }

        public DBUpdateItem(string TableName)
        {
            if (TableName == "")
                update_type = DBUpdateType.Sql;
            else
                update_type = DBUpdateType.DeleteColumn;
            table_name = TableName;
            column_info = null;
        }

        public DBUpdateItem(string TableName, DBDataType DataType, int Length, int Length2, string DefaultValue, bool AllowNull, bool IsPrimary, bool IsIdentity, string Description, bool JsonIgnore)
        {
            if (TableName == "")
                update_type = DBUpdateType.Sql;
            else
                update_type = DBUpdateType.AddColumn;
            table_name = TableName;
            column_info = new DBColumn("", DataType, Length, Length2, DefaultValue, AllowNull, IsPrimary, IsIdentity, Description, JsonIgnore);
        }

        public DBUpdateItem(DBUpdateType UpdateType, string TableName, DBDataType DataType, int Length, int Length2, string DefaultValue, bool AllowNull, bool IsPrimary, bool IsIdentity, string Description, bool JsonIgnore)
        {
            update_type = UpdateType;
            table_name = TableName;
            column_info = new DBColumn("", DataType, Length, Length2, DefaultValue, AllowNull, IsPrimary, IsIdentity, Description, JsonIgnore);
        }
    }
}
