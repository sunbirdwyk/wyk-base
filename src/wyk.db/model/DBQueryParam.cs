using System;
using System.Collections.Generic;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 数据库查询条件参数
    /// </summary>
    public class DBQueryParam
    {
        public DBColumn column = null;
        public object value = null;

        public DBQueryParam() { }
        public DBQueryParam(DBColumn column, object value)
        {
            this.column = column;
            this.value = value;
        }

        public DBQueryParam(DBTable table, string column_name, object value)
        {
            column = table.columnWithName(column_name);
            this.value = value;
        }

        /// <summary>
        /// 使用当前参数创建一个查询参数列表
        /// 注: 如果查询条件不可用, 创建列表中则不会包含本参数
        /// </summary>
        /// <returns></returns>
        public DBQueryParamList createList()
        {
            DBQueryParamList list = new DBQueryParamList();
            if (isAvailable())
                list.add(this);
            return list;
        }

        /// <summary>
        /// 判定当前查询参数是否可用
        /// </summary>
        /// <returns></returns>
        public bool isAvailable()
        {
            if (column == null || column.name.isNull())
                return false;
            return true;
        }

        /// <summary>
        /// 判定当前查询参数和值是否正常可用(值不能为空)
        /// </summary>
        /// <returns></returns>
        public bool isAvailableWithValue()
        {
            if (!isAvailable())
                return false;
            if (value == null)
                return false;
            return true;
        }

        /// <summary>
        /// 获取查询语句的条件部分
        /// </summary>
        /// <returns></returns>
        public string queryString()
        {
            if (column == null || column.name == "" || value == null)
                return "";
            string post_fix = "";
            switch (column.data_type)
            {
                case DBDataType.Binary:
                case DBDataType.DateTime:
                    //注: 这个位置可能会有问题
                    post_fix= DBUtil.connection.param(column.name);
                    break;
                case DBDataType.Bit:
                    try
                    {
                        post_fix = Convert.ToBoolean(value) ? "'1'" : "'0'";
                    }
                    catch { post_fix = "'0'"; }
                    break;
                case DBDataType.Byte:
                case DBDataType.Integer:
                case DBDataType.Long:
                case DBDataType.Numeric:
                case DBDataType.Short:
                    post_fix = value.ToString();
                    break;
                case DBDataType.Text:
                case DBDataType.Varchar:
                    post_fix = $"'{value}'";
                    break;
                default:
                    return "";
            }
            return $"{column.name}={post_fix}";
        }

        /// <summary>
        /// 获取查询语句中需要设置的参数(当前只有binary和datetime需要设置)
        /// </summary>
        /// <returns></returns>
        public DBParameter queryParameter()
        {
            if (column == null || column.name == "" || value == null)
                return null;
            switch (column.data_type)
            {
                case DBDataType.DateTime:
                case DBDataType.Binary:
                    return new DBParameter(column.name, value);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 设置查询语句参数到参数列表(当前只有binary和datetime需要设置)
        /// </summary>
        /// <param name="pm"></param>
        public void setQueryParameter(ref List<DBParameter> pm)
        {
            if (pm == null || pm.Count == 0)
                pm = new List<DBParameter>();
            DBParameter param = queryParameter();
            if (param != null)
                pm.Add(param);
        }

        /// <summary>
        /// 操作语句中的参数(当column满足条件时, 此函数总会获得参数)
        /// </summary>
        /// <returns></returns>
        public DBParameter operationParameter()
        {
            if (column == null || column.name == "")
                return null;
            if (value == null)
                return new DBParameter(column.name, DBNull.Value);
            else
                return new DBParameter(column.name, value);
        }

        public void setOperationParameter(ref List<DBParameter> pm)
        {
            if (pm == null || pm.Count == 0)
                pm = new List<DBParameter>();
            DBParameter param = operationParameter();
            if (param != null)
                pm.Add(param);
        }
    }
}