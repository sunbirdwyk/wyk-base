using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 数据库表信息(Attribute)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DBTable : Attribute
    {
        const string CLASS_NAME_PREFIX = "DBTA";

        /// <summary>
        /// 表名
        /// </summary>
        public string table_name = "";

        /// <summary>
        /// 表功能说明
        /// </summary>
        public string table_description = "";

        public DBTable()
        {
            table_name = "";
            table_description = "";
        }

        public DBTable(string TableName)
        {
            table_name = TableName;
            table_description = "";
        }

        public DBTable(string TableName, string Description)
        {
            table_name = TableName;
            table_description = Description;
        }

        public List<DBColumn> columns = new List<DBColumn>();
        public void loadColumns(Type type)
        {
            columns = new List<DBColumn>();
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo info in fields)
            {
                var column = info.getAttribute<DBColumn>();
                if (column != null)
                {
                    column.field_info = info;
                    columns.Add(column);
                }
            }
        }

        private List<DBColumn> _primary_columns = null;
        private List<DBColumn> _common_columns = null;

        public List<DBColumn> primary_columns
        {
            get
            {
                if (_primary_columns == null)
                {
                    _primary_columns = new List<DBColumn>();
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (columns[i].is_primary)
                            _primary_columns.Add(columns[i]);
                    }
                }
                return _primary_columns;
            }
        }

        public List<DBColumn> common_columns
        {
            get
            {
                if (_common_columns == null)
                {
                    _common_columns = new List<DBColumn>();
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (!columns[i].is_primary)
                            _common_columns.Add(columns[i]);
                    }
                }
                return _common_columns;
            }
        }

        /// <summary>
        /// 获取建表主要sql
        /// </summary>
        /// <param name="db_type"></param>
        /// <returns></returns>
        public string getCreateTableSqlMain(DBType db_type)
        {
            var sql = new StringBuilder();
            switch (db_type)
            {
                default:
                    break;
                case DBType.Access:
                    sql.Append($" Create TABLE {table_name} (");
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (columns[i].name != "")
                            sql.Append($"{columns[i].getCreateTableContent(db_type)},");
                    }
                    if (sql[sql.Length - 1] == ',')
                        sql.Remove(sql.Length - 1, 1);
                    sql.Append(")");
                    break;
                case DBType.SqlServer:
                    sql.Append($"CREATE TABLE dbo.{table_name} ( ");
                    bool has_text = false;
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (columns[i].name != "")
                            sql.Append($"{columns[i].getCreateTableContent(db_type)},");
                        if (columns[i].data_type == DBDataType.Text)
                            has_text = true;
                    }
                    if (sql[sql.Length - 1] == ',')
                        sql.Remove(sql.Length - 1, 1);
                    sql.Append(" ) ON [PRIMARY] ");
                    if (has_text)
                        sql.Append(" TEXTIMAGE_ON [PRIMARY] ");
                    break;
                case DBType.Oracle:
                    sql.Append($"create table {table_name} (");
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (columns[i].name != "")
                            sql.Append($"{columns[i].getCreateTableContent(db_type)},");
                    }
                    if (sql[sql.Length - 1] == ',')
                        sql.Remove(sql.Length - 1, 1);
                    sql.Append(")");
                    break;
                case DBType.MySql:
                    sql.Append($"CREATE TABLE `{table_name}` ( ");
                    var primary = new StringBuilder();
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (columns[i].name != "")
                        {
                            sql.Append($"{columns[i].getCreateTableContent(db_type)},");
                            if(columns[i].is_primary)
                            {
                                if (primary.Length > 0)
                                    primary.Append(",");
                                primary.Append($"`{columns[i].name}`");
                            }
                        }
                    }
                    if (primary.Length > 0)
                        sql.Append($" PRIMARY KEY ({primary.ToString()}) ");
                    else if (sql[sql.Length - 1] == ',')
                        sql.Remove(sql.Length - 1, 1);
                    sql.Append(" ) ENGINE=InnoDB DEFAULT CHARSET=utf8 ");
                    break;
            }
            return sql.ToString();
        }

        /// <summary>
        /// 获取建表的sql语句集合（主要sql和设置主键之类的sql）
        /// </summary>
        /// <param name="db_type"></param>
        /// <returns></returns>
        public List<string> getCreateTableSqlList(DBType db_type)
        {
            if (db_type == DBType.Unknown)
                db_type = DBType.SqlServer;
            List<string> sqls = new List<string>();
            sqls.Add(getCreateTableSqlMain(db_type));
            if (db_type == DBType.SqlServer)
            {
                string pk_sql = getPrimaryKeyCreateSqlForSqlServer();
                if (pk_sql != "")
                    sqls.Add(pk_sql);
            }
            if (db_type == DBType.SqlServer || db_type == DBType.Access)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    string dv_sql = columns[i].getSetDefaultSql(db_type, table_name);
                    if (dv_sql != "")
                        sqls.Add(dv_sql);
                }
            }
            return sqls;
        }

        /// <summary>
        /// 获取主键设置sql
        /// </summary>
        /// <returns></returns>
        public string getPrimaryKeyCreateSqlForSqlServer()
        {
            var pk_cols = primary_columns;
            if (pk_cols.Count == 0)
                return "";
            var content = new StringBuilder();
            content.Append($"ALTER TABLE dbo.{table_name} ADD CONSTRAINT PK_{table_name} PRIMARY KEY CLUSTERED ( ");
            for (int i = 0; i < pk_cols.Count; i++)
            {
                content.Append($"{pk_cols[i].name},");
            }
            if (content[content.Length - 1] == ',')
                content.Remove(content.Length - 1, 1);
            content.Append(" ) ON [PRIMARY] ");
            return content.ToString();
        }

        /// <summary>
        /// 将表结构写到xml文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DBTable fromXmlFile(string path)
        {
            DBTable tb = new DBTable();
            try
            {
                TextReader tr = File.OpenText(path);
                string xml = tr.ReadToEnd();
                tr.Close();
                tb.XMLContent = xml;
            }
            catch { }
            return tb;
        }

        /// <summary>
        /// 从xml描述文件读取表结构信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string toXmlFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch { }
            }
            string xml = XMLContent;
            xml = $"<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n{xml}";
            try
            {
                TextWriter tw = File.CreateText(path);
                tw.Write(xml);
                tw.Flush();
                tw.Close();
            }
            catch (Exception ex) { return ex.Message; }
            return "";
        }

        /// <summary>
        /// xml描述文件内容
        /// </summary>
        public string XMLContent
        {
            get
            {
                string content = "";
                content += $"<db_table name=\"{table_name}\" description=\"{StringUtil.toXMLContent(table_description)}\">\r\n";
                for (int i = 0; i < columns.Count; i++)
                {
                    content += columns[i].XMLContentString + "\r\n";
                }
                content += "</db_table>\r\n";
                return content;
            }
            set
            {
                table_name = "";
                columns = new List<DBColumn>();
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(value);
                XmlNode root = xDoc.SelectSingleNode("db_table");
                try
                {
                    table_name = root.Attributes["name"].Value;
                    try
                    {
                        table_description = StringUtil.fromXMLContent(root.Attributes["description"].Value);
                    }
                    catch { }
                    XmlNodeList xnl = root.SelectNodes("db_column");
                    foreach (XmlNode xn in xnl)
                    {
                        try
                        {
                            DBColumn col = new DBColumn();
                            col.XMLNode = xn;
                            if (col.name != "")
                                columns.Add(col);
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 获取自动生成Class时的默认类名
        /// </summary>
        /// <returns></returns>
        public string getClassName()
        {
            return CLASS_NAME_PREFIX + "_" + table_name.camelStringFromDash(true, false);
        }

        /// <summary>
        /// 获取自动生成class时的类内容
        /// </summary>
        /// <param name="class_namespace"></param>
        /// <returns></returns>
        public string getClassContent(string class_namespace)
        {
            string content = "";
            content += "using Newtonsoft.Json;\r\n";
            content += "using System;\r\n";
            content += "using wyk.basic;\r\n";
            content += "using wyk.db;\r\n";
            content += "\r\n";
            content += "namespace " + class_namespace + "\r\n";
            content += "{\r\n";
            content += "    /// <summary>\r\n";
            content += "    /// 表名:" + getClassName() + "\r\n";
            content += "    /// 描述:" + table_description + "\r\n";
            content += "    /// Auto generated by wyk.db.DBTableManager \r\n";
            content += "    /// </summary>\r\n";
            content += "    [DBTable(\"" + table_name + "\", \"" + table_description.Replace("\"", "'").Replace("\r\n", "") + "\")]\r\n";
            content += "    public class " + getClassName() + " : DBTableAdapter\r\n";
            content += "    {\r\n";
            foreach (DBColumn column in columns)
            {
                content += "        /// <summary>\r\n";
                content += "        /// " + column.data_description + "\r\n";
                content += "        /// </summary>\r\n";
                content += "        [DBColumn(\"" + column.name + "\", DBDataType." + column.data_type.ToString() + ", " + column.data_length + ", " + column.data_length2 + ", \"" + column.default_value + "\", " + (column.allow_null ? "true" : "false") + ", " + (column.is_primary ? "true" : "false") + ", " + (column.is_identity ? "true" : "false") + ", \"" + column.data_description.Replace("\"", "'").Replace("\r\n", "") + "\", " + (column.json_ignore ? "true" : "false") + ")]\r\n";
                string default_value = "";
                if (column.json_ignore)
                    content += "        [JsonIgnore]\r\n";
                if (!column.replace_name.isNull()&&column.data_type!= DBDataType.DateTime)
                    content += "        [ReplaceInfo(\"" + column.replace_name.Trim() + "\", \""+column.data_description.Replace("\"", "'").Replace("\r\n", "") + "\")]\r\n";
                switch (column.data_type)
                {
                    case DBDataType.Bit:
                        default_value = column.default_value.Trim() == "true" ? "true" : "false";
                        content += "        public bool " + column.name + " = " + default_value + ";\r\n";
                        break;
                    case DBDataType.Byte:
                        byte byte_value = 0;
                        try
                        {
                            byte_value = Convert.ToByte(column.default_value);
                        }
                        catch { }
                        default_value = byte_value.ToString();
                        content += "        public byte " + column.name + " = " + default_value + ";\r\n";
                        break;
                    case DBDataType.Short:
                        short short_value = 0;
                        try
                        {
                            short_value = Convert.ToInt16(column.default_value);
                        }
                        catch { }
                        default_value = short_value.ToString();
                        content += "        public short " + column.name + " = " + default_value + ";\r\n";
                        break;
                    case DBDataType.Integer:
                        int int_value = 0;
                        try
                        {
                            int_value = Convert.ToInt32(column.default_value);
                        }
                        catch { }
                        default_value = int_value.ToString();
                        content += "        public int " + column.name + " = " + default_value + ";\r\n";
                        break;
                    case DBDataType.Long:
                        long long_value = 0;
                        try
                        {
                            long_value = Convert.ToInt64(column.default_value);
                        }
                        catch { }
                        default_value = long_value.ToString();
                        content += "        public long " + column.name + " = " + default_value + ";\r\n";
                        break;
                    case DBDataType.Numeric:
                        double double_value = 0;
                        try
                        {
                            double_value = Convert.ToDouble(column.default_value);
                        }
                        catch { }
                        default_value = double_value.ToString();
                        content += "        public double " + column.name + " = " + default_value + ";\r\n";
                        break;
                    case DBDataType.Varchar:
                    case DBDataType.Text:
                        content += "        public string " + column.name + " = \"" + default_value + "\";\r\n";
                        break;
                    case DBDataType.DateTime:
                        DateTime time_value = DateTimeUtil.defaultTime();
                        try
                        {
                            time_value = Convert.ToDateTime(column.default_value);
                        }
                        catch { }
                        if (time_value.isDefault())
                            default_value = "DateTimeUtil.defaultTime()";
                        else
                            default_value = "new DateTime(" + time_value.Year + ", " + time_value.Month + ", " + time_value.Day + ", " + time_value.Hour + ", " + time_value.Minute + ", " + time_value.Second + ");";
                        if (!column.json_ignore)
                            content += "        [JsonIgnore]\r\n";
                        content += "        public DateTime " + column.name + " = " + default_value + ";\r\n";
                        if (column.json_ignore)
                            content += "        [JsonIgnore]\r\n";
                        if (!column.replace_name.isNull())
                            content += "        [ReplaceInfo(\"" + column.replace_name.Trim() + "\", \"" + column.data_description.Replace("\"", "'").Replace("\r\n", "") + "\")]\r\n";
                        content += "        public string " + column.name.camelStringFromDash(true, false) + "\r\n";
                        content += "        {\r\n";
                        content += "            get\r\n";
                        content += "            {\r\n";
                        content += "                if (DateTimeUtil.isDefaultTime(" + column.name.Trim() + "))\r\n";
                        content += "                    return \"\";\r\n";
                        content += "                else\r\n";
                        if (column.name.Trim().ToLower() == "birthday")
                            content += "                    return " + column.name.Trim() + ".ToString(\"yyyy-MM-dd\");\r\n";
                        else
                            content += "                    return " + column.name.Trim() + ".ToString(\"yyyy-MM-dd HH:mm:ss\");\r\n";
                        content += "            }\r\n";
                        content += "            set\r\n";
                        content += "            {\r\n";
                        content += "                " + column.name.Trim() + " = value.datetime();\r\n";
                        content += "            }\r\n";
                        content += "        }\r\n";
                        break;
                    case DBDataType.Binary:
                        //目前二进制类型无法设置默认值
                        if (!column.json_ignore)
                            content += "        [JsonIgnore]\r\n";
                        content += "        public byte[] " + column.name + " = null;\r\n";
                        break;
                }
                content += "\r\n";
            }
            content += "    }\r\n";
            content += "}\r\n";
            return content;
        }

        /// <summary>
        /// 根据field名获取列信息（通常field名和列名相同， 所以此方法不常用）
        /// </summary>
        /// <param name="field_name"></param>
        /// <returns></returns>
        public DBColumn columnWithFieldName(string field_name)
        {
            foreach (DBColumn column in columns)
            {
                if (column.field_info.Name == field_name)
                    return column;
            }
            return null;
        }

        /// <summary>
        /// 根据列名获取类信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DBColumn columnWithName(string name)
        {
            foreach (DBColumn column in columns)
            {
                if (column.name == name)
                    return column;
            }
            return null;
        }
    }
}

