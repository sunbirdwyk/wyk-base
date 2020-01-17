using System;
using System.Reflection;
using System.Xml;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 数据库列信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class DBColumn : Attribute
    {
        /// <summary>
        /// 对应DBTable中的FieldInfo, 取值时需要
        /// </summary>
        public FieldInfo field_info = null;
        /// <summary>
        /// 列名
        /// </summary>
        public string name;

        /// <summary>
        /// 数据类型
        /// </summary>
        public DBDataType data_type;

        /// <summary>
        /// 数据长度(如有需要, 如果有两个长度时, 此长度为第一个长度)
        /// </summary>
        public int data_length;

        /// <summary>
        /// 数据长度(如有需要, 此长度代表第二个长度)
        /// </summary>
        public int data_length2;

        /// <summary>
        /// 默认值
        /// </summary>
        public string default_value = "";

        /// <summary>
        /// 是否允许NULL值
        /// </summary>
        public bool allow_null;

        /// <summary>
        /// 是否为标识(自增长), 仅对数字型有效(byte, int, long)
        /// </summary>
        public bool is_identity;

        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool is_primary;

        /// <summary>
        /// 数据值说明
        /// </summary>
        public string data_description;

        /// <summary>
        /// 是否设置Json忽略标签
        /// </summary>
        public bool json_ignore;

        /// <summary>
        /// 是否为报告替换值, 是的话填入替换名(不带大括号{})
        /// </summary>
        public string replace_name;

        #region constructor
        public DBColumn()
        {
            name = "";
            data_type = DBDataType.Integer;
            data_length = 0;
            data_length2 = 0;
            allow_null = true;
            is_identity = false;
            is_primary = false;
            data_description = "";
            json_ignore = false;
        }

        public DBColumn(string Name, DBDataType DataType, int Length)
        {
            name = Name;
            data_type = DataType;
            data_length = Length;
            data_length2 = 0;
            allow_null = true;
            is_identity = false;
            is_primary = false;
            data_description = "";
            json_ignore = false;
        }

        public DBColumn(string Name, DBDataType DataType, int Length, bool IsPrimary)
        {
            name = Name;
            data_type = DataType;
            data_length = Length;
            data_length2 = 0;
            allow_null = false;
            is_identity = false;
            is_primary = IsPrimary;
            data_description = "";
            json_ignore = false;
        }

        public DBColumn(string Name, DBDataType DataType, int Length, bool IsPrimary, bool IsIdentity)
        {
            name = Name;
            data_type = DataType;
            data_length = Length;
            data_length2 = 0;
            allow_null = false;
            is_identity = IsIdentity;
            is_primary = IsPrimary;
            data_description = "";
            json_ignore = false;
        }

        public DBColumn(string Name, DBDataType DataType, int Length, int Length2)
        {
            name = Name;
            data_type = DataType;
            data_length = Length;
            data_length2 = Length2;
            allow_null = true;
            is_identity = false;
            is_primary = false;
            data_description = "";
            json_ignore = false;
        }

        public DBColumn(string Name, DBDataType DataType, int Length, int Length2, bool AllowNull)
        {
            name = Name;
            data_type = DataType;
            data_length = Length;
            data_length2 = Length2;
            allow_null = AllowNull;
            is_identity = false;
            is_primary = false;
            data_description = "";
            json_ignore = false;
        }

        public DBColumn(string Name, DBDataType DataType, int Length, int Length2, string DefaultValue, bool AllowNull, bool IsPrimary, bool IsIdentity, string Description, bool JsonIgnore)
        {
            name = Name;
            data_type = DataType;
            data_length = Length;
            data_length2 = Length2;
            default_value = DefaultValue;
            allow_null = AllowNull;
            is_identity = IsIdentity;
            is_primary = IsPrimary;
            data_description = Description;
            json_ignore = JsonIgnore;
        }
        #endregion

        public DBColumn Copy()
        {
            DBColumn col = new DBColumn(name, data_type, data_length);
            col.data_length2 = data_length2;
            col.default_value = default_value;
            col.allow_null = allow_null;
            col.is_identity = is_identity;
            col.is_primary = is_primary;
            col.data_description = data_description;
            col.field_info = field_info;
            col.json_ignore = json_ignore;
            col.replace_name = replace_name;
            return col;
        }

        public string dataTypeForDB(DBType db_type)
        {
            if (data_type == DBDataType.Varchar)
                data_length2 = 0;
            else if (data_type != DBDataType.Numeric)
            {
                data_length = 0;
                data_length2 = 0;
            }
            string res = getColumnTypeName(db_type, data_type);
            if (data_length > 0)
            {
                if (data_length2 > 0)
                    res += "(" + data_length + "," + data_length2 + ")";
                else
                    res += "(" + data_length + ")";
            }
            return res;
        }

        public static string dataTypeNameFromType(DBDataType data_type)
        {
            switch (data_type)
            {
                case DBDataType.Bit:
                    return "Bit";
                case DBDataType.Byte:
                    return "Byte";
                case DBDataType.Short:
                    return "Short";
                default:
                case DBDataType.Integer:
                    return "Integer";
                case DBDataType.Long:
                    return "Long";
                case DBDataType.Numeric:
                    return "Numeric";
                case DBDataType.Varchar:
                    return "Varchar";
                case DBDataType.Text:
                    return "Text";
                case DBDataType.DateTime:
                    return "DateTime";
                case DBDataType.Binary:
                    return "Binary";
            }
        }

        public static DBDataType dataTypeFromName(string name)
        {
            switch (name.ToLower())
            {
                case "bit":
                    return DBDataType.Bit;
                case "byte":
                    return DBDataType.Byte;
                case "short":
                case "int16":
                    return DBDataType.Short;
                case "int":
                case "integer":
                case "int32":
                default:
                    return DBDataType.Integer;
                case "int64":
                case "long":
                    return DBDataType.Long;
                case "number":
                case "numeric":
                    return DBDataType.Numeric;
                case "datetime":
                    return DBDataType.DateTime;
                case "varchar":
                    return DBDataType.Varchar;
                case "text":
                    return DBDataType.Text;
                case "binary":
                    return DBDataType.Binary;
            }
        }

        public string DataType
        {
            get => dataTypeNameFromType(data_type);
            set => data_type = dataTypeFromName(value);
        }

        public string XMLContentString
        {
            get
            {
                string content = "<db_column ";
                content += " name=\"" + name + "\" ";
                content += " type=\"" + DataType + "\" ";
                if (is_primary)
                    content += " primary=\"1\" ";
                if (allow_null)
                    content += " allownull=\"1\" ";
                if (is_identity)
                    content += " identity=\"1\" ";
                if (data_length > 0)
                    content += " length=\"" + data_length + "\" ";
                if (data_length2 > 0)
                    content += " length2=\"" + data_length2 + "\" ";
                if (default_value != "")
                    content += " default_value=\"" + default_value + "\" ";
                if (json_ignore)
                    content += " json_ignore=\"1\" ";
                if (!replace_name.isNull())
                    content += " replace_name=\"" + replace_name + "\" ";
                if (data_description != "")
                    content += " description=\"" + StringUtil.toXMLContent(data_description) + "\" ";
                content += "></db_column>";
                return content;
            }
        }

        public XmlNode XMLNode
        {
            set
            {
                name = "";
                data_type = DBDataType.Integer;
                data_length = 0;
                data_length2 = 0;
                allow_null = false;
                is_identity = false;
                is_primary = false;
                data_description = "";
                if (value.Name != "db_column")
                    return;
                try
                {
                    name = value.Attributes["name"].Value;
                }
                catch { }
                try
                {
                    DataType = value.Attributes["type"].Value;
                }
                catch { }
                try
                {
                    is_primary = value.Attributes["primary"].Value == "1";
                }
                catch { }
                try
                {
                    allow_null = value.Attributes["allownull"].Value == "1";
                }
                catch { }
                try
                {
                    is_identity = value.Attributes["identity"].Value == "1";
                }
                catch { }
                try
                {
                    data_length = Convert.ToInt32(value.Attributes["length"].Value);
                }
                catch { }
                try
                {
                    data_length2 = Convert.ToInt32(value.Attributes["length2"].Value);
                }
                catch { }
                try
                {
                    default_value = value.Attributes["default_value"].Value;
                }
                catch { }
                try
                {
                    json_ignore = value.Attributes["json_ignore"].Value == "1";
                }
                catch { }
                try
                {
                    replace_name = value.Attributes["replace_name"].Value;
                }
                catch { }
                try
                {
                    data_description = StringUtil.fromXMLContent(value.Attributes["description"].Value);
                }
                catch { }

            }
        }

        public string getCreateTableContent(DBType db_type)
        {
            string content = "";
            switch (db_type)
            {
                case DBType.Access:
                    content += " [" + name + "] ";
                    if (is_identity)
                        content += "COUNTER";
                    else
                    {
                        content += dataTypeForDB(db_type);
                    }
                    if (allow_null)
                        content += " NULL ";
                    else
                        content += " NOT NULL ";
                    if (is_primary)
                        content += " PRIMARY KEY ";
                    break;
                case DBType.Oracle:
                    content += " " + name + " ";
                    content += dataTypeForDB(db_type);
                    if (allow_null)
                        content += " null ";
                    else
                        content += " not null ";
                    if (is_primary)
                        content += " primary key ";
                    if (default_value != "")
                    {
                        switch (data_type)
                        {
                            case DBDataType.Byte:
                            case DBDataType.DateTime:
                            case DBDataType.Integer:
                            case DBDataType.Long:
                            case DBDataType.Numeric:
                            case DBDataType.Short:
                                content += " default " + default_value;
                                break;
                            default:
                                content += " default '" + default_value + "' ";
                                break;
                        }
                    }
                    break;
                case DBType.SqlServer:
                    content += " [" + name + "] ";
                    content += dataTypeForDB(db_type);
                    if (allow_null)
                        content += " NULL ";
                    else
                        content += " NOT NULL ";
                    if (is_identity)
                        content += " IDENTITY ";
                    break;
                case DBType.MySql:
                    content += " `" + name + "` ";
                    content += dataTypeForDB(db_type);
                    if (allow_null)
                        content += " NULL ";
                    else
                        content += " NOT NULL ";
                    if (is_identity)
                        content += " AUTO_INCREMENT ";
                    break;
            }
            return content;
        }

        public static string getColumnTypeName(DBType db_type, DBDataType data_type)
        {
            switch (db_type)
            {
                case DBType.Access:
                    switch (data_type)
                    {
                        case DBDataType.Bit:
                            return "Bit";
                        case DBDataType.Binary:
                            return "Binary";
                        case DBDataType.Byte:
                            return "TinyInt";
                        case DBDataType.DateTime:
                            return "DateTime";
                        case DBDataType.Integer:
                        case DBDataType.Long:
                            return "Int";
                        case DBDataType.Text:
                            return "NText";
                        case DBDataType.Numeric:
                            return "Float";
                        case DBDataType.Short:
                            return "SmallInt";
                        case DBDataType.Varchar:
                            return "NVarChar";
                        default:
                            return "";
                    }
                case DBType.Oracle:
                    switch (data_type)
                    {
                        case DBDataType.Binary:
                            return "BLOB";
                        case DBDataType.Bit://由于不存在此字段,使用INTEGER代替,相应判断类型也需要做相应更改
                            return "INTEGER";
                        case DBDataType.Byte:
                            return "INTEGER";
                        case DBDataType.DateTime:
                            return "TIMESTAMP";
                        case DBDataType.Integer:
                            return "INTEGER";
                        case DBDataType.Long:
                            return "NUMBER(63)";
                        case DBDataType.Text:
                            return "NCLOB";
                        case DBDataType.Numeric:
                            return "NUMBER";
                        case DBDataType.Varchar:
                            return "NVARCHAR2";
                        case DBDataType.Short:
                            return "INTEGER";
                        default:
                            return "";
                    }
                case DBType.SqlServer:
                    switch (data_type)
                    {
                        case DBDataType.Binary:
                            return "binary";
                        case DBDataType.Bit:
                            return "bit";
                        case DBDataType.Byte:
                            return "tinyint";
                        case DBDataType.DateTime:
                            return "datetime";
                        case DBDataType.Integer:
                            return "int";
                        case DBDataType.Long:
                            return "bigint";
                        case DBDataType.Text:
                            return "ntext";
                        case DBDataType.Numeric:
                            return "numeric";
                        case DBDataType.Varchar:
                            return "nvarchar";
                        case DBDataType.Short:
                            return "smallint";
                        default:
                            return "";
                    }
                case DBType.MySql:
                    switch (data_type)
                    {
                        case DBDataType.Binary:
                            return "longblob";
                        case DBDataType.Bit:
                            return "bit";
                        case DBDataType.Byte:
                            return "tinyint";
                        case DBDataType.DateTime:
                            return "datetime";
                        case DBDataType.Integer:
                            return "int";
                        case DBDataType.Long:
                            return "bigint";
                        case DBDataType.Text:
                            return "longtext";
                        case DBDataType.Numeric:
                            return "decimal";
                        case DBDataType.Varchar:
                            return "varchar";
                        case DBDataType.Short:
                            return "smallint";
                        default:
                            return "";
                    }
                default:
                    return "";
            }
        }

        public string getSetDefaultSql(DBType db_type, string table_name)
        {
            string content = "";
            if (default_value == "")
                return "";
            switch (db_type)
            {
                case DBType.Access:
                case DBType.SqlServer:
                    content = "ALTER TABLE [" + table_name + "] ADD CONSTRAINT DV_" + table_name + "_" + name + " DEFAULT '" + default_value + "' FOR [" + name + "]";
                    break;
                case DBType.Oracle:
                    break;
                case DBType.MySql:
                    content = "ALTER TABLE `" + table_name + "` ALTER " + name + " SET DEFAULT '" + default_value + "' ";
                    break;
            }
            return content;
        }

        public string getDeleteColumnSql(DBType db_type, string table_name)
        {
            switch (db_type)
            {
                case DBType.SqlServer:
                case DBType.Access:
                default:
                    return "ALTER TABLE [" + table_name + "] DROP COLUMN " + name;
                case DBType.MySql:
                    return "ALTER TABLE `" + table_name + "` DROP " + name;
            }
        }

        public string getAddColumnSql(DBType db_type, string table_name)
        {
            switch (db_type)
            {
                case DBType.SqlServer:
                case DBType.Access:
                    return "ALTER TABLE [" + table_name + "] ADD " + getCreateTableContent(db_type);
                case DBType.MySql:
                    return "ALTER TABLE `" + table_name + "` ADD " + getCreateTableContent(db_type);
                default:
                    return "ALTER TABLE " + table_name + " ADD " + getCreateTableContent(db_type);
            }
        }
    }
}