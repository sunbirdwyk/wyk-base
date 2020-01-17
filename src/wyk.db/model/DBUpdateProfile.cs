using System.Collections.Generic;
using System.Reflection;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 数据库更新描述文件, 每个文件代表一个版本的数据库更新
    /// 注: DBVersion tag用于标注当前数据库更新起始版本号
    /// </summary>
    [DBVersion(0, 0, 0)]
    public class DBUpdateProfile
    {
        #region demo
        /*
        [DBUpdateItem()]
        private string demo_sql = "alter c_person add column test1";
        [DBUpdateItem("c_person", DBDataType.Integer, 0, 0, "", true, false, false, "")]
        private string demo_add_column = "test1";
        [DBUpdateItem("c_person")]
        private string demo_delete_column = "test1";
        */
        #endregion

        protected DBVersion _start_db_version = null;
        /// <summary>
        /// 起始数据库版本号
        /// </summary>
        public DBVersion start_db_version
        {
            get
            {
                if (_start_db_version == null)
                {
                    _start_db_version = this.getAttribute<DBVersion>();
                    if (_start_db_version == null)
                        _start_db_version = new DBVersion("");
                }
                return _start_db_version;
            }
        }

        /// <summary>
        /// 通过当前数据库版本号判断是否需要执行本描述文件升级
        /// </summary>
        /// <param name="current_db_version"></param>
        /// <returns></returns>
        public bool shouldUpdate(string current_db_version)
        {
            if (start_db_version.compare(current_db_version) == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 通过当前数据库版本号判断是否需要执行本描述文件升级
        /// </summary>
        /// <param name="current_db_version"></param>
        /// <returns></returns>
        public bool shouldUpdate(DBVersion current_db_version)
        {
            return shouldUpdate(current_db_version.db_version);
        }

        /// <summary>
        /// 获取当前需要更新的sql语句
        /// </summary>
        /// <param name="db_type">数据库类型</param>
        /// <returns></returns>
        public List<string> getUpdateSqlList(DBType db_type)
        {
            List<string> sql_list = new List<string>();
            FieldInfo[] fields = this.GetType().GetFields();
            foreach (FieldInfo fi in fields)
            {
                try
                {
                    if (fi.FieldType != typeof(string))
                        continue;
                    var item = fi.getAttribute<DBUpdateItem>();
                    if (item != null)
                    {
                        string value = fi.GetValue(this) as string;
                        if (value.Trim() == "")
                            continue;
                        switch (item.update_type)
                        {
                            case DBUpdateType.Sql:
                            default:
                                sql_list.Add(value);
                                break;
                            case DBUpdateType.DeleteColumn:
                                DBColumn column = new DBColumn(value, DBDataType.Bit, 0);
                                sql_list.Add(column.getDeleteColumnSql(db_type, item.table_name));
                                break;
                            case DBUpdateType.AddColumn:
                                item.column_info.allow_null = true;//新增列如果不允许空时插入不进去, 所以需要强制设置为允许空
                                item.column_info.name = value;
                                sql_list.Add(item.column_info.getAddColumnSql(db_type, item.table_name));
                                break;
                        }
                    }
                }
                catch { }
            }
            return sql_list;
        }
    }
}
