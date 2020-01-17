using System;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 数据库初始数据表中的一条数据
    /// </summary>
    public class DBInitDataItem
    {
        public string[] special_values = new string[] { "[ID]", "[GUID]", "[DATETIME]", "[DATE]" };
        public string column_name = "";
        public DBDataType data_type = DBDataType.Integer;
        public object column_value = null;

        public DBParameter getParameter(string table_name)
        {
            if (column_value == null)
                return null;
            switch (StringValue)
            {
                case "[ID]":
                    var query = "select max(" + column_name + ") from " + table_name;
                    var data = DBQuery.query(query);
                    int id = 0;
                    try
                    {
                        id = Convert.ToInt32(data.Rows[0][0]);
                    }
                    catch { }
                    id++;
                    return new DBParameter(column_name, id);
                case "[GUID]":
                    return new DBParameter(column_name, Guid.NewGuid().ToString());
                case "[DATETIME]":
                    return new DBParameter(column_name, DateTime.Now);
                case "[DATE]":
                    return new DBParameter(column_name, DateTime.Today);
                default:
                   return new DBParameter(column_name, column_value);
            }
        }

        /// <summary>
        /// 字符串值, 注: 设置此值时必须先设置DataType
        /// </summary>
        public string StringValue
        {
            get
            {
                switch (data_type)
                {
                    case DBDataType.Bit:
                        bool bv = false;
                        try
                        {
                            bv = Convert.ToBoolean(column_value);
                        }
                        catch { }
                        return bv ? "true" : "false";
                    case DBDataType.Binary:
                        try
                        {
                            return Convert.ToBase64String(column_value as byte[]);
                        }
                        catch { }
                        return "";
                    case DBDataType.DateTime:
                        try
                        {
                            DateTime dt = (DateTime)column_value;
                            if (dt.isDefault())
                                return "";
                            return dt.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        catch { return ""; }
                    default:
                        if (column_value != null)
                            return column_value.ToString();
                        return "";
                }
            }
            set
            {
                if (value == "")
                {
                    column_value = null;
                    return;
                }
                foreach(string sn in special_values)
                {
                    if (sn == value)
                    {
                        column_value = sn;
                        return;
                    }
                }
                switch (data_type)
                {
                    case DBDataType.Binary:
                        try
                        {
                            column_value = Convert.FromBase64String(value);
                        }
                        catch { column_value = null; }
                        break;
                    case DBDataType.Bit:
                        try
                        {
                            if (value == "1" || value.ToLower() == "true")
                                column_value = true;
                            else
                                column_value = Convert.ToBoolean(value);
                        }
                        catch { column_value = false; }
                        break;
                    case DBDataType.Byte:
                        try
                        {
                            column_value = Convert.ToByte(value);
                        }
                        catch { column_value = null; }
                        break;
                    case DBDataType.DateTime:
                        try
                        {
                            column_value = Convert.ToDateTime(value);
                        }
                        catch { column_value = null; }
                        break;
                    case DBDataType.Integer:
                        try
                        {
                            column_value = Convert.ToInt32(value);
                        }
                        catch { column_value = null; }
                        break;
                    case DBDataType.Long:
                        try
                        {
                            column_value = Convert.ToInt64(value);
                        }
                        catch { column_value = null; }
                        break;
                    case DBDataType.Numeric:
                        try
                        {
                            column_value = Convert.ToDouble(value);
                        }
                        catch { column_value = null; }
                        break;
                    case DBDataType.Short:
                        try
                        {
                            column_value = Convert.ToInt16(value);
                        }
                        catch { column_value = null; }
                        break;
                    case DBDataType.Text:
                    case DBDataType.Varchar:
                        column_value = value;
                        break;
                }
            }
        }

        public string DataType
        {
            get => DBColumn.dataTypeNameFromType(data_type);
            set => data_type = DBColumn.dataTypeFromName(value);
        }
    }
}
