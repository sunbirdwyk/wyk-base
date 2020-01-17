using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 基础DB Access 类, T中传入的为相关联的DBTableAdapter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBBaseDAO<T>
    {
        /// <summary>
        /// 数据库连接串, 获取DBUtil的数据库连接串
        /// </summary>
        [JsonIgnore]
        public static string connection_string
        {
            get=> DBUtil.connection_string;
        }

        [JsonIgnore]
        public static DBConnection connection
        {
            get => DBUtil.connection;
        }

        protected static DBTable _table = null;

        /// <summary>
        /// 关联数据表适配类的表信息
        /// </summary>
        public static DBTable table
        {
            get
            {
                if (_table == null)
                {
                    _table = typeof(T).getAttribute<DBTable>();
                    if (_table == null)
                        _table = new DBTable();
                    else
                        _table.loadColumns(typeof(T));
                }
                return _table;
            }
        }

        /// <summary>
        /// 关联的数据表名
        /// </summary>
        public static string TABLE_NAME
        {
            get
            {
                return table.table_name;
            }
        }

        /// <summary>
        /// 生成查询参数
        /// </summary>
        /// <param name="column_name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DBQueryParam queryParam(string column_name, object value)
        {
            return new DBQueryParam(table, column_name, value);
        }

        /// <summary>
        /// 根据列名数组生成DBColumn集合
        /// </summary>
        /// <param name="column_names"></param>
        /// <returns></returns>
        public static List<DBColumn> columns(string[] column_names)
        {
            var cols = new List<DBColumn>();
            if (column_names != null)
            {
                foreach (var col_name in column_names)
                {
                    var col = table.columnWithName(col_name);
                    if (col != null)
                        cols.Add(col);
                }
            }
            return cols;
        }

        /// <summary>
        /// 从查询到的结果DataTable转为适配类列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static List<T> itemListByDataTable(DataTable data)
        {
            var list = new List<T>();
            foreach (DataRow dr in data.Rows)
            {
                var item = Activator.CreateInstance<T>();
                try
                {
                    var info = item.GetType().GetField("is_new");
                    info.SetValue(item, false);
                }
                catch { }
                foreach (var column in table.columns)
                {
                    try
                    {
                        item.setValue(column.field_info, dr[column.name]);
                    }
                    catch { }
                }
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// 获取表中记录总数
        /// </summary>
        /// <returns></returns>
        public static int totalCount()
        {
            var query = $"select count(*) from {connection.left_quote}{TABLE_NAME}{connection.right_quote} ";
            int count = 0;
            try
            {
                count = Convert.ToInt32(DBQuery.query(query, connection, null, out string msg).Rows[0][0]);
            }
            catch { }
            return count;
        }

        /// <summary>
        /// 根据查询条件获取总数, 注: 如果不传参数则返回表中的总记录数
        /// </summary>
        /// <param name="query_param"></param>
        /// <returns></returns>
        public static int count(DBQueryParamList query_param)
        {
            if (query_param == null || query_param.count == 0)
                return totalCount();
            var query = new StringBuilder();
            query.Append($"select count(*) from {connection.left_quote}{TABLE_NAME}{connection.right_quote} ");
            var query_string = new StringBuilder();
            var pm = new List<DBParameter>();
            foreach (var param in query_param.pm_list)
            {
                //如果有参数传递为空值, 则代表本次查询不能查询到想要的结果(会把结果集扩大化), 此时返回为查询失败
                if (!param.isAvailableWithValue())
                    return 0;
                if (query_string.Length > 0)
                    query_string.Append(" and ");
                query_string.Append(param.queryString());
                param.setQueryParameter(ref pm);
            }
            if (query_string.Length > 0)
                query.Append($" where {query_string.ToString()} ");
            DataTable data = DBQuery.query(query.ToString(), connection, pm, out string msg);
            try
            {
                return Convert.ToInt32(data.Rows[0][0]);
            }
            catch { }
            return 0;
        }

        /// <summary>
        /// 通过查询参数获取适配类
        /// </summary>
        /// <param name="query_param">查询参数</param>
        /// <returns>查询结果</returns>
        public static T get(DBQueryParamList query_param)
        {
            if (query_param == null || query_param.count == 0)
                return default(T);
            var query = new StringBuilder();
            query.Append($"select * from {connection.left_quote}{TABLE_NAME}{connection.right_quote} ");
            var query_string = new StringBuilder();
            List<DBParameter> pm = new List<DBParameter>();
            foreach (DBQueryParam param in query_param.pm_list)
            {
                //如果有参数传递为空值, 则代表本次查询不能查询到想要的结果(会把结果集扩大化), 此时返回为查询失败
                if (!param.isAvailableWithValue())
                    return default(T);
                if (query_string.Length > 0)
                    query_string.Append(" and ");
                query_string.Append(param.queryString());
                param.setQueryParameter(ref pm);
            }
            if (query_string.Length > 0)
                query.Append($" where {query_string.ToString()} ");
            DataTable data = DBQuery.query(query.ToString(), connection, pm, out string msg);
            try
            {
                return itemListByDataTable(data)[0];
            }
            catch { }
            return default(T);
        }

        /// <summary>
        /// 通过ID获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string nameById(int id)
        {
            return nameById(id, "id", "name");
        }

        /// <summary>
        /// 通过ID获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id_column"></param>
        /// <param name="name_column"></param>
        /// <returns></returns>
        public static string nameById(int id, string id_column, string name_column)
        {
            if (id <= 0 || id_column.isNull() || name_column.isNull())
                return "";
            try
            {
                var query = $"select {connection.left_quote}{name_column} from {connection.left_quote}{TABLE_NAME}{connection.right_quote} where {connection.left_quote}{id_column}{connection.right_quote}='" + id + "' ";
                return DBQuery.query(query).Rows[0][0].ToString();
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 通过id获取适配类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T get(int id)
        {
            return get(queryParam("id", id).createList());
        }

        /// <summary>
        /// 通过查询参数获取适配类列表
        /// </summary>
        /// <param name="query_param">查询参数</param>
        /// <param name="order_by">排序列</param>
        /// <param name="is_desc"></param>
        /// <returns>查询结果</returns>
        public static List<T> getList(DBQueryParamList query_param, List<DBColumn> order_by, bool is_desc)
        {
            return getList(query_param, order_by, is_desc, null);
        }

        /// <summary>
        /// 通过查询参数获取适配类列表
        /// </summary>
        /// <param name="query_param">查询参数</param>
        /// <param name="order_by">排序列</param>
        /// <param name="is_desc"></param>
        /// <param name="ignore_columns">不获取记录内容的列(通常为存储内容比较多的列)</param>
        /// <returns>查询结果</returns>
        public static List<T> getList(DBQueryParamList query_param, List<DBColumn> order_by, bool is_desc, List<DBColumn> ignore_columns)
        {
            var query = new StringBuilder();
            if (ignore_columns == null || ignore_columns.Count == 0)
                query.Append($"select * from {connection.left_quote}{TABLE_NAME}{connection.right_quote} ");
            else
            {
                query.Append("select ");
                foreach (DBColumn col in table.columns)
                {
                    bool found = false;
                    foreach (DBColumn ic in ignore_columns)
                    {
                        if (ic.name == col.name)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        query.Append($"{connection.left_quote}{col.name}{connection.right_quote},");
                    }
                }
                if (query[query.Length - 1] == ',')
                    query.Remove(query.Length - 1, 1);
                query.Append($" from {connection.left_quote}{TABLE_NAME}{connection.right_quote} ");
            }

            var query_string = new StringBuilder();
            List<DBParameter> pm = new List<DBParameter>();
            if (query_param != null)
            {
                foreach (DBQueryParam param in query_param.pm_list)
                {
                    //如果有参数传递为空值, 则代表本次查询不能查询到想要的结果(会把结果集扩大化), 此时返回为查询失败
                    if (!param.isAvailableWithValue())
                        return default;
                    if (query_string.Length > 0)
                        query_string.Append(" and ");
                    query_string.Append(param.queryString());
                    param.setQueryParameter(ref pm);
                }
            }
            if (query_string.Length > 0)
                query.Append($" where { query_string.ToString()} ");
            query_string.Clear();
            if (order_by != null)
            {
                foreach (DBColumn col in order_by)
                {
                    if (col == null)
                        continue;
                    if (query_string.Length > 0)
                        query_string.Append(",");
                    if (col.name != "")
                        query_string.Append($"{connection.left_quote}{col.name}{connection.right_quote}");
                }
            }
            if (query_string.Length > 0)
            {
                query.Append($" order by {query_string} ");
                if (is_desc)
                    query.Append(" desc ");
            }
            DataTable data = DBQuery.query(query.ToString(), connection, pm, out string msg);
            try
            {
                return itemListByDataTable(data);
            }
            catch { }
            return default;
        }

        /// <summary>
        /// 根据日期段和查询语句获取适配类列表
        /// </summary>
        /// <param name="query_param">查询参数</param>
        /// <param name="date_column">日期列</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="order_by">排序列</param>
        /// <param name="is_desc"></param>
        /// <returns>查询结果</returns>
        public static List<T> getList(DBQueryParamList query_param, DBColumn date_column, DateTime start, DateTime end, List<DBColumn> order_by, bool is_desc)
        {
            return getList(query_param, date_column, start, end, order_by, is_desc, null);
        }

        /// <summary>
        /// 根据日期段和查询语句获取适配类列表
        /// </summary>
        /// <param name="query_param">查询参数</param>
        /// <param name="date_column">日期列</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="order_by">排序列</param>
        /// <param name="is_desc"></param>
        /// <param name="ignore_columns">不获取记录内容的列(通常为存储内容比较多的列)</param>
        /// <returns>查询结果</returns>
        public static List<T> getList(DBQueryParamList query_param, DBColumn date_column, DateTime start, DateTime end, List<DBColumn> order_by, bool is_desc, List<DBColumn> ignore_columns)
        {
            var query = new StringBuilder();
            query.Append($"select * from {connection.left_quote}{TABLE_NAME}{connection.right_quote} ");
            var query_string = new StringBuilder();
            List<DBParameter> pm = new List<DBParameter>();
            if (query_param != null)
            {
                foreach (DBQueryParam param in query_param.pm_list)
                {
                    //如果有参数传递为空值, 则代表本次查询不能查询到想要的结果(会把结果集扩大化), 此时返回为查询失败
                    if (!param.isAvailableWithValue())
                        return default;
                    if (query_string.Length > 0)
                        query_string.Append(" and ");
                    query_string.Append(param.queryString());
                    param.setQueryParameter(ref pm);
                }
            }
            if (date_column != null && date_column.name != "")
            {
                if (start != DateTimeUtil.defaultTime())
                {
                    if (query_string.Length > 0)
                        query_string.Append(" and ");
                    query_string.Append($" {connection.left_quote}{date_column.name}{connection.right_quote}>={connection.param(date_column.name)} ");
                    pm.Add(new DBParameter("start_date", start.Date));
                }
                if (end != DateTimeUtil.defaultTime())
                {
                    if (query_string.Length > 0)
                        query_string.Append(" and ");
                    query_string.Append($" {connection.left_quote}{date_column.name}{connection.right_quote}<{connection.param(date_column.name)} ");
                    pm.Add(new DBParameter("end_date", end.AddDays(1).Date));
                }
            }
            if (query_string.Length > 0)
                query.Append($" where {query_string.ToString()} ");
            query_string.Clear();
            if (order_by != null)
            {
                foreach (DBColumn col in order_by)
                {
                    if (col == null)
                        continue;
                    if (query_string.Length > 0)
                        query_string.Append(",");
                    if (col.name != "")
                        query_string.Append($"{connection.left_quote}{col.name}{connection.right_quote}");
                }
            }

            if (query_string.Length > 0)
            {
                query.Append($" order by { query_string.ToString()} ");
                if (is_desc)
                    query.Append(" desc ");
            }
            DataTable data = DBQuery.query(query.ToString(), connection, pm, out string msg);
            try
            {
                return itemListByDataTable(data);
            }
            catch { }
            return default;
        }

        /// <summary>
        /// 根据查询条件更新表中的某几列
        /// </summary>
        /// <param name="update_param"></param>
        /// <param name="query_param"></param>
        /// <returns></returns>
        public static string update(DBQueryParamList update_param, DBQueryParamList query_param)
        {
            if (update_param == null || update_param.count == 0)
                return "未传入更新列参数";
            if (query_param == null || query_param.count == 0)
                return "未传入查询列参数";
            var query = new StringBuilder();
            query.Append($"update {connection.left_quote}{TABLE_NAME}{connection.right_quote} set ");
            var update_str = new StringBuilder();
            foreach (DBQueryParam pm in update_param.pm_list)
            {
                if (!pm.isAvailableWithValue())
                    return "更新列参数传入有误";
                if (update_str.Length>0)
                    update_str .Append( ", ");
                update_str .Append( pm.queryString());
            }
            if (update_str .Length<=0)
                return "更新列参数传入为空";
            var query_str = new StringBuilder();
            foreach (DBQueryParam pm in query_param.pm_list)
            {
                if (!pm.isAvailableWithValue())
                    return "查询列参数传入有误";
                if (query_str.Length>0)
                    query_str .Append( " and ");
                query_str .Append( pm.queryString());
            }
            if (query_str .Length<=0)
                return "查询列参数传入为空";
            query.Append($"{update_str.ToString()} where {query_str.ToString()} ");
            DBQuery.execute(query.ToString(), connection, null, out string msg);
            return msg;
        }

        /// <summary>
        /// 通过查询参数删除表数据
        /// </summary>
        /// <param name="query_param">查询参数</param>
        /// <param name="connection_string"></param>
        /// <returns>错误信息</returns>
        public static string delete(DBQueryParamList query_param)
        {
            if (query_param == null || query_param.count == 0)
            {
                return "删除语句必须传入筛选参数!";
            }
            List<DBParameter> pk = new List<DBParameter>();
            foreach (DBQueryParam param in query_param.pm_list)
            {
                //如果有参数传递为空值, 则代表本次删除不能查询到精确的结果(会把结果集扩大化, 删除不想删除的东西), 此时返回为删除失败
                if (!param.isAvailableWithValue())
                    return "传入参数有误!";
                param.setOperationParameter(ref pk);
            }
            if (pk == null || pk.Count == 0)
                return "您没有设置查询参数, 不能继续, 因为不允许您删除当前表的所有数据";
            return DBQuery.delete(TABLE_NAME, pk, connection);
        }

        /// <summary>
        /// 根据 id 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string delete(int id)
        {
            return delete(queryParam("id", id).createList());
        }
    }
}