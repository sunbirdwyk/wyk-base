using System;

namespace wyk.db
{
    /// <summary>
    /// 用于标记下拉字典的表内容
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DBCommonDictionaryInfo : Attribute
    {
        /// <summary>
        /// 对应的数据表名
        /// </summary>
        public string table_name = "";
        /// <summary>
        /// 字典项ID
        /// </summary>
        public string id_column = "id";
        /// <summary>
        /// 字典类
        /// </summary>
        public string type_column = "dic_type";
        /// <summary>
        /// 字典值
        /// </summary>
        public string content_column = "content";
        /// <summary>
        /// 字典值简写(前50位)
        /// </summary>
        public string shortcut_column = "shortcut";
        /// <summary>
        /// 字典序号列名
        /// </summary>
        public string index_column = "idx";

        /// <summary>
        /// 域ID列名
        /// </summary>
        public string domain_column = "";

        public DBCommonDictionaryInfo(string TableName)
        {
            table_name = TableName;
        }

        public DBCommonDictionaryInfo(string TableName, string DomainColumn)
        {
            table_name = TableName;
            domain_column = DomainColumn;
        }

        public DBCommonDictionaryInfo(string TableName, string IDColumn, string TypeColumn, string ContentColumn, string ShortcutColumn, string IndexColumn)
        {
            table_name = TableName;
            id_column = IDColumn;
            type_column = TypeColumn;
            content_column = ContentColumn;
            shortcut_column = ShortcutColumn;
            index_column = IndexColumn;
        }

        public DBCommonDictionaryInfo(string TableName, string IDColumn, string TypeColumn, string ContentColumn, string ShortcutColumn, string IndexColumn, string DomainColumn)
        {
            table_name = TableName;
            id_column = IDColumn;
            type_column = TypeColumn;
            content_column = ContentColumn;
            shortcut_column = ShortcutColumn;
            index_column = IndexColumn;
            domain_column = DomainColumn;
        }
    }
}
