using System.Collections.Generic;
using System.Reflection;
using wyk.db.preset;

namespace wyk.db
{
    /// <summary>
    /// 用于建立预创建表的操作类, 提供一些默认表(如配置, 基本字典, sequence等)的预创建
    /// </summary>
    public class DBPresetUtil
    {
        static List<DBTable> _preset_tables = null;

        public static List<DBTable> preset_tables
        {
            get
            {
                if(_preset_tables==null)
                {
                    _preset_tables = new List<DBTable>();
                    DBPresetTable table_pre = new DBPresetTable();
                    FieldInfo[] fields = table_pre.GetType().GetFields();
                    foreach(FieldInfo fi in fields)
                    {
                        if(fi.FieldType == typeof(DBTable))
                        {
                            DBTable table = fi.GetValue(table_pre) as DBTable;
                            _preset_tables.Add(table);
                        }
                    }
                    DBPresetColumn column_pre = new DBPresetColumn();
                    fields = column_pre.GetType().GetFields();
                    foreach(FieldInfo fi in fields)
                    {
                        if(fi.FieldType == typeof(DBColumn))
                        {
                            DBColumn column = fi.GetValue(column_pre) as DBColumn;
                            int idx = fi.Name.LastIndexOf('_');
                            string table_name = "";
                            if (idx >= 0)
                                table_name = fi.Name.Substring(0, idx);
                            else
                                table_name = fi.Name;
                            foreach(DBTable table in _preset_tables)
                            {
                                if(table.table_name == table_name)
                                {
                                    table.columns.Add(column);
                                    break;
                                }
                            }
                        }
                    }
                }
                return _preset_tables;
            }
        }
    }
}