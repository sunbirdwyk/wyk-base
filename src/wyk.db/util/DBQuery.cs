using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 数据库查询
    /// </summary>
    public class DBQuery
    {
        /// <summary>
        /// 处理Access相关的参数(筛选provicer)
        /// </summary>
        /// <param name="pm_list"></param>
        /// <param name="provider"></param>
        public static void processParamsForAccess(ref List<OleDbParameter> pm_list, string provider)
        {
            if (pm_list == null)
                return;
            if (!provider.StartsWith("Microsoft.Jet.OLEDB."))
                return;
            processParamsForAccess(ref pm_list);
        }

        /// <summary>
        /// 处理Access相关的参数
        /// </summary>
        /// <param name="pm_list"></param>
        public static void processParamsForAccess(ref List<OleDbParameter> pm_list)
        {
            if (pm_list == null)
                return;
            foreach (var pm in pm_list)
            {
                if (pm.DbType == DbType.Date ||
                    pm.DbType == DbType.DateTime ||
                    pm.DbType == DbType.DateTime2 ||
                    pm.DbType == DbType.DateTimeOffset)
                {
                    pm.Value = pm.Value.ToString();
                }
            }
        }

        /// <summary>
        /// 删除表中的数据
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="keys">参数列表</param>
        /// <returns></returns>
        public static string delete(string table_name, List<DBParameter> keys)
        {
            return delete(table_name, keys, DBUtil.connection);
        }

        /// <summary>
        /// 删除表中的数据
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="keys">参数列表</param>
        /// <param name="connection_string"></param>
        /// <returns></returns>
        public static string delete(string table_name, List<DBParameter> keys, string connection_string)
        {
            var connection = new DBConnection(connection_string);
            return delete(table_name, keys, connection);
        }
        /// <summary>
        /// 删除表中的数据
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="keys">查询参数列表</param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string delete(string table_name, List<DBParameter> keys, DBConnection connection)
        {
            var pklist = new StringBuilder();
            for (int i = 0; i < keys.Count; i++)
            {
                if (pklist.Length > 0)
                    pklist.Append(" and ");
                pklist.Append($"{connection.left_quote}{keys[i].name}{connection.right_quote}={connection.param(keys[i].name)}");
            }
            var query = $"delete from {table_name} where {pklist.ToString()} ";
            return execute(query, connection, keys);
        }

        /// <summary>
        /// 更新表中的数据
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="columns">更新列参数列表</param>
        /// <param name="keys">查询参数列表</param>
        /// <returns></returns>
        public static string update(string table_name, List<DBParameter> columns, List<DBParameter> keys)
        {
            return update(table_name, columns, keys, DBUtil.connection);
        }

        /// <summary>
        /// 更新表中的数据
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="columns">更新列参数列表</param>
        /// <param name="keys">查询参数列表</param>
        /// <param name="connection_string"></param>
        /// <returns></returns>
        public static string update(string table_name, List<DBParameter> columns, List<DBParameter> keys, string connection_string)
        {
            var connection = new DBConnection(connection_string);
            return update(table_name, columns, keys, connection);
        }

        /// <summary>
        /// 更新表中的数据
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="columns">更新列参数列表</param>
        /// <param name="keys">查询参数列表</param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string update(string table_name, List<DBParameter> columns, List<DBParameter> keys, DBConnection connection)
        {
            var columnlist = new StringBuilder();
            var pklist = new StringBuilder();
            for (int i = 0; i < columns.Count; i++)
                columnlist.Append($"{connection.left_quote}{columns[i].name}{connection.right_quote}={connection.param(columns[i].name)},");
            if (columnlist[columnlist.Length - 1] == ',')
                columnlist.Remove(columnlist.Length - 1, 1);
            for (int i = 0; i < keys.Count; i++)
            {
                if (pklist.Length > 0)
                    pklist.Append(" and ");
                pklist.Append($"{connection.left_quote}{keys[i].name}{connection.right_quote}={connection.param(keys[i].name)}");
                columns.Add(keys[i]);
            }
            var query = $"update {table_name} set {columnlist.ToString()} where {pklist.ToString()}";
            return execute(query, connection, columns);
        }

        /// <summary>
        ///  插入数据至目标表(没有自增长标识列(sequence列))
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="columns">插入列参数列表</param>
        /// <returns></returns>
        public static string insert(string table_name, List<DBParameter> columns)
        {
            return insert(table_name, columns, DBUtil.connection);
        }

        /// <summary>
        /// 插入数据至目标表(没有自增长标识列(sequence列))
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="columns">插入列参数列表</param>
        /// <param name="connection_string"></param>
        /// <returns></returns>
        public static string insert(string table_name, List<DBParameter> columns, string connection_string)
        {
            var connection = new DBConnection(connection_string);
            return insert(table_name, columns, connection);
        }

        /// <summary>
        /// 插入数据至目标表(没有自增长标识列(sequence列))
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="columns">插入列参数列表</param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string insert(string table_name, List<DBParameter> columns, DBConnection connection)
        {
            var columnlist = new StringBuilder();
            var paramlist = new StringBuilder();
            for (int i = 0; i < columns.Count; i++)
            {
                columnlist.Append($"{connection.left_quote}{columns[i].name}{connection.right_quote},");
                paramlist.Append($"{connection.param(columns[i].name)},");
            }
            if (columnlist[columnlist.Length - 1] == ',')
                columnlist.Remove(columnlist.Length - 1, 1);
            if (paramlist[paramlist.Length - 1] == ',')
                paramlist.Remove(paramlist.Length - 1, 1);
            var query = $"insert into {connection.left_quote}{table_name}{connection.right_quote} ({columnlist.ToString()}) values({paramlist.ToString()})";
            return execute(query, connection, columns);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="query_string"></param>
        /// <returns></returns>
        public static DataTable query(string query_string)
        {
            return query(query_string, DBUtil.connection);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="query_string"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable query(string query_string, List<DBParameter> parameters)
        {
            return query(query_string, DBUtil.connection, parameters);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="query_string"></param>
        /// <param name="connection_string"></param>
        /// <returns></returns>
        public static DataTable query(string query_string, string connection_string)
        {
            var connection = new DBConnection(connection_string);
            return query(query_string, connection);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="query_string"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable query(string query_string, DBConnection connection)
        {
            return query(query_string, connection, null, out string msg);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="query_string"></param>
        /// <param name="parameters"></param>
        /// <param name="connection_string"></param>
        /// <returns></returns>
        public static DataTable query(string query_string, string connection_string, List<DBParameter> parameters)
        {
            return query(query_string, connection_string, parameters, out string msg);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="query_string"></param>
        /// <param name="parameters"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable query(string query_string, DBConnection connection, List<DBParameter> parameters)
        {
            return query(query_string, connection, parameters, out string msg);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="query_string">查询语句</param>
        /// <param name="connection_string">连接串</param>
        /// <param name="parameters">参数</param>
        /// <param name="error_message">错误信息</param>
        /// <returns>查询结果</returns>
        public static DataTable query(string query_string, string connection_string, List<DBParameter> parameters, out string error_message)
        {
            var connection = new DBConnection(connection_string);
            return query(query_string, connection, parameters, out error_message);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="query_string">查询语句</param>
        /// <param name="connection">连接串</param>
        /// <param name="parameters">参数</param>
        /// <param name="error_message">错误信息</param>
        /// <returns>查询结果</returns>
        public static DataTable query(string query_string, DBConnection connection, List<DBParameter> parameters, out string error_message)
        {
            error_message = "";
            var data = new DataTable();
            if (connection.connection_string.isNull())
            {
                error_message = "连接串设置有误";
                return data;
            }
            if (connection.db_type == DBType.Unknown)
                connection.db_type = DBType.SqlServer;
            switch (connection.db_type)
            {
                case DBType.MySql:
                    try
                    {
                        using (var conn = new MySqlConnection(connection.connection_string))
                        {
                            List<MySqlParameter> pml = null;
                            if (parameters != null && parameters.Count > 0)
                            {
                                pml = new List<MySqlParameter>();
                                foreach (var pm in parameters)
                                    pml.Add(pm.mysqlParam());
                            }
                            var scomm = new MySqlCommand(query_string, conn);
                            if (pml != null && pml.Count > 0)
                                foreach (var pm in pml)
                                    scomm.Parameters.Add(pm);
                            conn.Open();
                            using (var dataReader = scomm.ExecuteReader())
                            {
                                int i = 0;
                                int columnCount = 0;
                                while (dataReader.Read())
                                {
                                    if (i == 0)
                                    {
                                        columnCount = dataReader.FieldCount;
                                        if (columnCount == 0)
                                            return data;
                                        else
                                            for (int c = 0; c < columnCount; c++)
                                            {
                                                var dc = new DataColumn(dataReader.GetName(c));
                                                data.Columns.Add(dc);
                                            }
                                    }
                                    var dr = data.NewRow();
                                    for (int c = 0; c < columnCount; c++)
                                    {
                                        if (dataReader.IsDBNull(c))
                                            dr[c] = null;
                                        else
                                            dr[c] = dataReader.GetValue(c);
                                    }
                                    data.Rows.Add(dr);
                                    i++;
                                }
                                dataReader.Close();
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        error_message = ex.ToString();
                    }
                    break;
                default:
                    try
                    {
                        using (OleDbConnection conn = new OleDbConnection(connection.connection_string))
                        {
                            List<OleDbParameter> pml = null;
                            if (parameters != null && parameters.Count > 0)
                            {
                                pml = new List<OleDbParameter>();
                                foreach (var pm in parameters)
                                    pml.Add(pm.oledbParam());
                            }
                            processParamsForAccess(ref pml, conn.Provider);
                            var scomm = new OleDbCommand(query_string, conn);
                            if (pml != null && pml.Count > 0)
                                foreach (var pm in pml)
                                    scomm.Parameters.Add(pm);
                            conn.Open();
                            using (var dataReader = scomm.ExecuteReader())
                            {
                                int i = 0;
                                int columnCount = 0;
                                while (dataReader.Read())
                                {
                                    if (i == 0)
                                    {
                                        columnCount = dataReader.FieldCount;
                                        if (columnCount == 0)
                                            return data;
                                        else
                                            for (int c = 0; c < columnCount; c++)
                                            {
                                                var dc = new DataColumn(dataReader.GetName(c));
                                                data.Columns.Add(dc);
                                            }
                                    }
                                    var dr = data.NewRow();
                                    for (int c = 0; c < columnCount; c++)
                                    {
                                        if (dataReader.IsDBNull(c))
                                            dr[c] = null;
                                        else
                                            dr[c] = dataReader.GetValue(c);
                                    }
                                    data.Rows.Add(dr);
                                    i++;
                                }
                                dataReader.Close();
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        error_message = ex.ToString();
                    }
                    break;
            }
            return data;
        }

        /// <summary>
        /// 执行查询 (含二进制列)
        /// </summary>
        /// <param name="query_string"></param>
        /// <param name="connection_string"></param>
        /// <param name="parameters"></param>
        /// <param name="error_message"></param>
        /// <param name="binary_columns"></param>
        /// <returns></returns>
        public static DataTable query(string query_string, string connection_string, List<DBParameter> parameters, out string error_message, string[] binary_columns)
        {
            var connection = new DBConnection(connection_string);
            return query(query_string, connection, parameters, out error_message, binary_columns);
        }

        /// <summary>
        /// 执行查询 (含二进制列)
        /// </summary>
        /// <param name="query_string">查询语句</param>
        /// <param name="connection">连接串</param>
        /// <param name="parameters">参数</param>
        /// <param name="error_message">错误信息</param>
        /// <param name="binary_columns">二进制列列表</param>
        /// <returns>查询结果</returns>
        public static DataTable query(string query_string, DBConnection connection, List<DBParameter> parameters, out string error_message, string[] binary_columns)
        {
            error_message = "";
            var data = new DataTable();
            if (connection.connection_string.isNull())
            {
                error_message = "连接串设置有误";
                return data;
            }
            if (connection.db_type == DBType.Unknown)
                connection.db_type = DBType.SqlServer;
            var binaryCols = new int[binary_columns.Length];
            switch (connection.db_type)
            {
                case DBType.MySql:
                    try
                    {
                        using (var conn = new MySqlConnection(connection.connection_string))
                        {
                            List<MySqlParameter> pml = null;
                            if (parameters != null && parameters.Count > 0)
                            {
                                pml = new List<MySqlParameter>();
                                foreach (var pm in parameters)
                                    pml.Add(pm.mysqlParam());
                            }
                            MySqlCommand scomm = new MySqlCommand(query_string, conn);
                            if (pml != null && pml.Count > 0)
                                foreach (var pm in pml)
                                    scomm.Parameters.Add(pm);
                            conn.Open();
                            using (var dataReader = scomm.ExecuteReader())
                            {
                                int i = 0;
                                int columnCount = 0;
                                while (dataReader.Read())
                                {
                                    if (i == 0)
                                    {
                                        columnCount = dataReader.FieldCount;
                                        if (columnCount == 0)
                                            return data;
                                        else
                                            for (int c = 0; c < columnCount; c++)
                                            {
                                                string col = dataReader.GetName(c);
                                                int idx = indexOf(binary_columns, col);
                                                if (idx >= 0)
                                                    binaryCols[idx] = c;
                                                var dc = new DataColumn(col);
                                                data.Columns.Add(dc);
                                            }
                                    }
                                    var dr = data.NewRow();
                                    for (int c = 0; c < columnCount; c++)
                                    {
                                        if (dataReader.IsDBNull(c))
                                            dr[c] = null;
                                        else
                                        {
                                            if (indexOf(binaryCols, c) >= 0)
                                            {
                                                try
                                                {
                                                    dr[c] = Convert.ToBase64String((byte[])dataReader.GetValue(c));
                                                }
                                                catch { }
                                            }
                                            else
                                                dr[c] = dataReader.GetValue(c);
                                        }
                                    }
                                    data.Rows.Add(dr);
                                    i++;
                                }
                                dataReader.Close();
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        error_message = ex.ToString();
                    }
                    break;
                default:
                    try
                    {
                        using (var conn = new OleDbConnection(connection.connection_string))
                        {
                            List<OleDbParameter> pml = null;
                            if (parameters != null && parameters.Count > 0)
                            {
                                pml = new List<OleDbParameter>();
                                foreach (var pm in parameters)
                                    pml.Add(pm.oledbParam());
                            }
                            processParamsForAccess(ref pml, conn.Provider);
                            var scomm = new OleDbCommand(query_string, conn);
                            if (pml != null && pml.Count > 0)
                                foreach (var pm in pml)
                                    scomm.Parameters.Add(pm);
                            conn.Open();
                            using (var dataReader = scomm.ExecuteReader())
                            {
                                int i = 0;
                                int columnCount = 0;
                                while (dataReader.Read())
                                {
                                    if (i == 0)
                                    {
                                        columnCount = dataReader.FieldCount;
                                        if (columnCount == 0)
                                            return data;
                                        else
                                            for (int c = 0; c < columnCount; c++)
                                            {
                                                string col = dataReader.GetName(c);
                                                int idx = indexOf(binary_columns, col);
                                                if (idx >= 0)
                                                    binaryCols[idx] = c;
                                                var dc = new DataColumn(col);
                                                data.Columns.Add(dc);
                                            }
                                    }
                                    var dr = data.NewRow();
                                    for (int c = 0; c < columnCount; c++)
                                    {
                                        if (dataReader.IsDBNull(c))
                                            dr[c] = null;
                                        else
                                        {
                                            if (indexOf(binaryCols, c) >= 0)
                                            {
                                                try
                                                {
                                                    dr[c] = Convert.ToBase64String((byte[])dataReader.GetValue(c));
                                                }
                                                catch { }
                                            }
                                            else
                                                dr[c] = dataReader.GetValue(c);
                                        }
                                    }
                                    data.Rows.Add(dr);
                                    i++;
                                }
                                dataReader.Close();
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        error_message = ex.ToString();
                    }
                    break;
            }
            return data;
        }

        /// <summary>
        /// 执行非查询(Insert Update Delete等)
        /// </summary>
        /// <param name="sql_string"></param>
        /// <returns></returns>
        public static string execute(string sql_string)
        {
            execute(sql_string, DBUtil.connection, null, out string msg);
            return msg;
        }

        /// <summary>
        /// 执行非查询(Insert Update Delete等)
        /// </summary>
        /// <param name="sql_string"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string execute(string sql_string, List<DBParameter> parameters)
        {
            execute(sql_string, DBUtil.connection, parameters, out string msg);
            return msg;
        }

        /// <summary>
        /// 执行非查询(Insert Update Delete等)
        /// </summary>
        /// <param name="sql_string"></param>
        /// <param name="connection_string"></param>
        /// <returns></returns>
        public static string execute(string sql_string, string connection_string)
        {
            execute(sql_string, connection_string, null, out string msg);
            return msg;
        }

        /// <summary>
        /// 执行非查询(Insert Update Delete等)
        /// </summary>
        /// <param name="sql_string"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string execute(string sql_string, DBConnection connection)
        {
            execute(sql_string, connection, null, out string msg);
            return msg;
        }

        /// <summary>
        /// 执行非查询(Insert Update Delete等)
        /// </summary>
        /// <param name="sql_string"></param>
        /// <param name="parameters"></param>
        /// <param name="connection_string"></param>
        /// <returns></returns>
        public static string execute(string sql_string, string connection_string, List<DBParameter> parameters)
        {
            execute(sql_string, connection_string, parameters, out string msg);
            return msg;
        }

        /// <summary>
        /// 执行非查询(Insert Update Delete等)
        /// </summary>
        /// <param name="sql_string"></param>
        /// <param name="parameters"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string execute(string sql_string, DBConnection connection, List<DBParameter> parameters)
        {
            execute(sql_string, connection, parameters, out string msg);
            return msg;
        }

        /// <summary>
        /// 执行非查询(Insert Update Delete等)
        /// </summary>
        /// <param name="sql_string">语句</param>
        /// <param name="connection_string">连接串</param>
        /// <param name="parameters">参数</param>
        /// <param name="error_message">错误信息</param>
        /// <returns>影响行数</returns>
        public static int execute(string sql_string, string connection_string, List<DBParameter> parameters, out string error_message)
        {
            var connection = new DBConnection(connection_string);
            return execute(sql_string, connection, parameters, out error_message);
        }

        /// <summary>
        /// 执行非查询(Insert Update Delete等)
        /// </summary>
        /// <param name="sql_string">语句</param>
        /// <param name="connection">连接串</param>
        /// <param name="parameters">参数</param>
        /// <param name="error_message">错误信息</param>
        /// <returns>影响行数</returns>
        public static int execute(string sql_string, DBConnection connection, List<DBParameter> parameters, out string error_message)
        {
            error_message = "";
            int infected_rows = 0;
            if (connection.connection_string.isNull())
            {
                error_message = "连接串设置有误";
                return infected_rows;
            }
            if (connection.db_type == DBType.Unknown)
                connection.db_type = DBType.SqlServer;
            switch (connection.db_type)
            {
                case DBType.MySql:
                    try
                    {
                        using (var conn = new MySqlConnection(connection.connection_string))
                        {
                            List<MySqlParameter> pml = null;
                            if (parameters != null && parameters.Count > 0)
                            {
                                pml = new List<MySqlParameter>();
                                foreach (var pm in parameters)
                                    pml.Add(pm.mysqlParam());
                            }
                            var scomm = new MySqlCommand(sql_string, conn);
                            if (pml != null && pml.Count > 0)
                                foreach (var pm in pml)
                                    scomm.Parameters.Add(pm);
                            conn.Open();
                            infected_rows = scomm.ExecuteNonQuery();
                            conn.Close();
                        }
                        return infected_rows;
                    }
                    catch (Exception ex)
                    {
                        error_message = ex.ToString();
                        return -1;
                    }
                default:
                    try
                    {
                        using (OleDbConnection conn = new OleDbConnection(connection.connection_string))
                        {
                            List<OleDbParameter> pml = null;
                            if (parameters != null && parameters.Count > 0)
                            {
                                pml = new List<OleDbParameter>();
                                foreach (var pm in parameters)
                                    pml.Add(pm.oledbParam());
                            }
                            processParamsForAccess(ref pml, conn.Provider);
                            OleDbCommand scomm = new OleDbCommand(sql_string, conn);
                            if (parameters != null && parameters.Count > 0)
                                foreach (var pm in pml)
                                    scomm.Parameters.Add(pm);
                            conn.Open();
                            infected_rows = scomm.ExecuteNonQuery();
                            conn.Close();
                        }
                        return infected_rows;
                    }
                    catch (Exception ex)
                    {
                        error_message = ex.ToString();
                        return -1;
                    }
            }
        }

        /// <summary>
        /// 获取结构内容
        /// </summary>
        /// <param name="connection_string"></param>
        /// <param name="name"></param>
        /// <param name="error_message"></param>
        /// <returns></returns>
        public static DataTable schema(string connection_string, string name, out string error_message)
        {
            var connection = new DBConnection(connection_string);
            return schema(connection, name, out error_message);
        }

        /// <summary>
        /// 获取结构内容
        /// </summary>
        /// <param name="connection">连接串</param>
        /// <param name="name">结构名</param>
        /// <param name="error_message">错误信息</param>
        /// <returns>结构表</returns>
        public static DataTable schema(DBConnection connection, string name, out string error_message)
        {
            error_message = "";
            DataTable dt = new DataTable();
            switch (connection.db_type)
            {
                case DBType.MySql:
                    try
                    {
                        OleDbConnection conn = new OleDbConnection(connection.connection_string);
                        conn.Open();
                        try
                        {
                            dt = conn.GetSchema(name);
                        }
                        catch
                        {
                            dt = conn.GetSchema();
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        error_message = ex.ToString();
                    }
                    break;
                default:
                    try
                    {
                        OleDbConnection conn = new OleDbConnection(connection.connection_string);
                        conn.Open();
                        try
                        {
                            dt = conn.GetSchema(name);
                        }
                        catch
                        {
                            dt = conn.GetSchema();
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        error_message = ex.ToString();
                    }
                    break;
            }
            return dt;
        }

        /// <summary>
        /// 获取结构内容
        /// </summary>
        /// <param name="name">结构名</param>
        /// <param name="error_message">错误信息</param>
        /// <returns></returns>
        public static DataTable schema(string name, out string error_message)
        {
            return schema(DBUtil.connection, name, out error_message);
        }

        /// <summary>
        /// 获取结构内容
        /// </summary>
        /// <param name="name">结构名</param>
        /// <returns></returns>
        public static DataTable schema(string name)
        {
            return schema(DBUtil.connection, name, out string msg);
        }
        #region private methods
        /// <summary>
        /// 获取更新数据表的sql语句
        /// </summary>
        /// <param name="column_list">更新列列表</param>
        /// <param name="key_list">查询列列表</param>
        /// <param name="table_name">表名</param>
        /// <returns></returns>
        private static string getUpdateSql(string[] column_list, string[] key_list, string table_name, DBType db_type)
        {
            var query = new StringBuilder();
            query.Append($"update {table_name} set ");
            foreach (string col in column_list)
            {
                if (indexOf(key_list, col) < 0)
                {
                    if (db_type == DBType.MySql)
                        query.Append($"{col}=@{col},");
                    else
                        query.Append($"{col}=?,");
                }
            }
            if (query[query.Length - 1] == ',')
                query.Remove(query.Length - 1, 1);
            query.Append(" where ");
            int count = 0;
            foreach (string pk in key_list)
            {
                if (pk.Trim() == "")
                    continue;
                if (count > 0)
                    query.Append(" and ");
                if (db_type == DBType.MySql)
                    query.Append($"{pk}=@{pk}");
                else
                    query.Append($"{pk}=?");
            }
            return query.ToString();
        }

        /// <summary>
        /// 获取插入表sql语句
        /// </summary>
        /// <param name="column_list">插入列列表</param>
        /// <param name="table_name">表名</param>
        /// <returns></returns>
        private static string getInsertSql(string[] column_list, string table_name, DBType db_type)
        {
            return $"insert into {table_name} ({getColumnList(column_list, db_type)}) values ({getParamList(column_list, db_type)}) ";
        }

        private static string getParamList(string[] column_list, DBType db_type)
        {
            var list = new StringBuilder();
            foreach (string col in column_list)
            {
                if (col.isNull())
                    continue;
                if (db_type == DBType.MySql)
                    list.Append($"@{col},");
                else
                    list.Append("?,");
            }
            if (list[list.Length - 1] == ',')
                list.Remove(list.Length - 1, 1);
            return list.ToString();
        }

        private static string getColumnList(string[] column_list, DBType db_type)
        {
            var list = new StringBuilder();
            foreach (string col in column_list)
            {
                if (col.isNull())
                    continue;
                if (db_type == DBType.MySql)
                    list.Append($"`{col}`,");
                else
                    list.Append($"[{col}],");
            }
            if (list[list.Length - 1] == ',')
                list.Remove(list.Length - 1, 1);
            return list.ToString();
        }

        private static int indexOf(int[] list, int item)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == item)
                    return i;
            }
            return -1;
        }

        private static int indexOf(string[] list, string item)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == item)
                    return i;
            }
            return -1;
        }
        #endregion

        #region oracle 相关函数已禁用, 仅留存参考
        /*
        /// <summary>
        /// 使用Adapter执行查询
        /// </summary>
        /// <param name="query_string">查询语句</param>
        /// <param name="connection_string">连接串</param>
        /// <param name="parameters">参数</param>
        /// <param name="error_message">错误信息</param>
        /// <returns>查询结果</returns>
        public static DataTable queryWithAdapter(string query_string, string connection_string, List<DBParameter> parameters, ref string error_message)
        {
            error_message = "";
            DataTable data = new DataTable();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connection_string))
                {
                    processParamsForAccess(ref parameters, conn.Provider);
                    OleDbDataAdapter odda = new OleDbDataAdapter(query_string, conn);
                    if (parameters != null && parameters.Count > 0)
                        foreach (DBParameter parameter in parameters)
                            odda.SelectCommand.Parameters.Add(parameter);
                    conn.Open();
                    odda.Fill(data);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                error_message = ex.ToString();
            }
            return data;
        }

        /// <summary>
        /// 使用Adapter执行查询
        /// </summary>
        /// <param name="query_string">查询语句</param>
        /// <param name="connection">连接串</param>
        /// <param name="parameters">参数</param>
        /// <param name="error_message">错误信息</param>
        /// <returns>查询结果</returns>
        public static DataTable queryWithAdapter(string query_string, DBConnection connection, List<DBParameter> parameters, ref string error_message)
        {
            return queryWithAdapter(query_string, connection.connection_string, parameters, ref error_message);
        }

        /// <summary>
        /// 插入数据至目标表(含有自增长标识列(seqence列))
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="sequence_column">标识列名(sequence列名)</param>
        /// <param name="sequence_name">sequence名</param>
        /// <param name="columns">插入列参数列表</param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string insert(string table_name, string sequence_column, string sequence_name, List<DBParameter> columns, DBConnection connection)
        {
            string msg = "";
            string columnlist = "";
            string paramlist = "";
            if (connection.db_type == DBType.Oracle)
            {
                if (sequence_column.Trim() != "")
                {
                    columnlist += sequence_column + ",";
                    paramlist += "?,";
                    columns.Insert(0, new DBParameter(sequence_column, getSeqNextValue(sequence_name, connection)));
                }
            }
            for (int i = 0; i < columns.Count; i++)
            {
                columnlist += columns[i].ParameterName + ",";
                paramlist += "?,";
            }
            columnlist = columnlist.TrimEnd(',');
            paramlist = paramlist.TrimEnd(',');
            var query = "insert into " + table_name + " (" + columnlist + ") values(" + paramlist + ")";
            processNonQuery(query, connection, columns, ref msg);
            return msg;
        }

        /// <summary>
        /// 获取sequence下一个值(Oracle)
        /// </summary>
        /// <param name="sequence_name">sequence名称</param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static long getSeqNextValue(string sequence_name, DBConnection connection)
        {
            if (connection.db_type != DBType.Oracle)
                return -1;
            string msg = "";
            var query = "select " + sequence_name + ".nextval from dual";
            try
            {
                return Convert.ToInt64(processQuery(query, connection, null, ref msg).Rows[0][0]);
            }
            catch { }
            return -1;
        }

        /// <summary>
        /// 获取sequence当前值(Oracle)
        /// </summary>
        /// <param name="sequence_name">sequence名称</param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static long getSeqCurrentValue(string sequence_name, DBConnection connection)
        {
            if (connection.db_type != DBType.Oracle)
                return -1;
            string msg = "";
            var query = "select " + sequence_name + ".currval from dual";
            try
            {
                return Convert.ToInt64(processQuery(query, connection, null, ref msg).Rows[0][0]);
            }
            catch { }
            return -1;
        }
        */
        #endregion
    }
}