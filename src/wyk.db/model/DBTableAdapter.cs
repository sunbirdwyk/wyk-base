using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Text;
using wyk.basic;
using wyk.db.model;

namespace wyk.db
{
    /// <summary>
    /// 与表对应的适配类
    /// </summary>
    [DBTable("", "")]
    public class DBTableAdapter
    {
        /// <summary>
        /// 获取Table信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static DBTable tableInfo<T>()
        {
            var table = typeof(T).getAttribute<DBTable>();
            if (table == null)
                table = new DBTable();
            else
                table.loadColumns(typeof(T));
            return table;
        }

        /// <summary>
        /// 根据更新Model获取当前实例
        ///  --如果记录不存在, 返回带有更新Model内容的新实例
        ///  --如果记录存在, 返回原有实例并根据情况更新传入model中的内容
        ///  --如果返回为空值, 则表示传入的model与现有实例的某些值冲突, 无法赋值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="update_model"></param>
        /// <returns></returns>
        public static T instanceByUpdate<T>(UpdateModelBase update_model)
        {
            var pm = DBQueryParamList.create();
            var table = tableInfo<T>();
            T instance = default(T);
            try
            {
                foreach (var col in table.primary_columns)
                {
                    pm.add(new DBQueryParam(col, update_model.getValue(col.name)));
                }
                instance = get<T>(pm);
            }
            catch { }
            if (instance == null)
                instance = Activator.CreateInstance<T>();
            if (update_model != null)
                update_model.setValuesTo(ref instance);
            try
            {
                var method = typeof(T).GetMethod("processRefFeilds");
                if (method != null)
                    method.Invoke(instance, null);
            }
            catch { }
            return instance;
        }

        /// <summary>
        /// 通过查询参数获取实例
        /// </summary>
        /// <param name="query_param">查询参数</param>
        /// <returns></returns>
        public static T get<T>(DBQueryParamList query_param)
        {
            var table = tableInfo<T>();
            if (query_param == null || query_param.count == 0)
                return default(T);
            var query = new StringBuilder();
            query.Append($"select * from {DBUtil.connection.left_quote}{table.table_name}{DBUtil.connection.right_quote}");
            var query_string = new StringBuilder();
            List<DBParameter> pm = new List<DBParameter>();
            foreach (DBQueryParam param in query_param.pm_list)
            {
                //如果有参数传递为空值, 则代表本次查询不能查询到想要的结果(会把结果集扩大化), 此时返回为查询失败
                if (!param.isAvailableWithValue())
                    return default(T);
                if (query_string.Length>0)
                    query_string.Append(" and ");
                query_string.Append(param.queryString());
                param.setQueryParameter(ref pm);
            }
            if (query_string.Length > 0)
                query.Append($" where {query_string.ToString()}");
            DataTable data = DBQuery.query(query.ToString(), pm);
            try
            {
                var result = Activator.CreateInstance<T>();
                foreach (DBColumn column in table.columns)
                {
                    result.setValue(column.field_info, data.Rows[0][column.name]);
                }
                try
                {
                    FieldInfo info = result.GetType().GetField("is_new");
                    info.SetValue(result, false);
                }
                catch { }
                return result;
            }
            catch { }
            return default(T);
        }

        /// <summary>
        /// 根据查询参数获取其中的某些值
        /// </summary>
        /// <param name="value_columns">获取值的列</param>
        /// <param name="query_param">查询参数</param>
        /// <returns></returns>
        public static T getValues<T>(List<DBColumn> value_columns, DBQueryParamList query_param)
        {
            var table = tableInfo<T>();
            if (query_param == null || query_param.count == 0)
                return default(T);
            var query = new StringBuilder();
            query.Append("select ");
            foreach (DBColumn col in value_columns)
            {
                query.Append($"{DBUtil.connection.left_quote}{col.name}{DBUtil.connection.right_quote},");
            }
            if (query[query.Length - 1] == ',')
                query.Remove(query.Length - 1, 1);
            query.Append($" from {DBUtil.connection.left_quote}{table.table_name}{DBUtil.connection.right_quote} ");
            var query_string = new StringBuilder();
            var pm = new List<DBParameter>();
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
            if (query_string.Length > 0)
                query.Append($" where {query_string.ToString()}");
            var data = DBQuery.query(query.ToString(), pm);
            try
            {
                var result = Activator.CreateInstance<T>();
                foreach (DBColumn column in value_columns)
                {
                    result.setValue(column.field_info, data.Rows[0][column.name]);
                }
                return result;
            }
            catch { }
            return default;
        }

        /// <summary>
        /// 通过ID获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string nameById<T>(int id)
        {
            return nameById<T>(id, "id", "name");
        }

        /// <summary>
        /// 通过ID获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id_column"></param>
        /// <param name="name_column"></param>
        /// <returns></returns>
        public static string nameById<T>(int id, string id_column, string name_column)
        {
            if (id <= 0 || id_column.isNull() || name_column.isNull())
                return "";
            var table = tableInfo<T>();
            try
            {
                string query = $"select {DBUtil.connection.left_quote}{name_column}{DBUtil.connection.right_quote} from {DBUtil.connection.left_quote}{table.table_name}{DBUtil.connection.right_quote} where {DBUtil.connection.left_quote}{id_column}{DBUtil.connection.right_quote}='{id}' ";
                return DBQuery.query(query).Rows[0][0].ToString();
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 在保存之前预处理的数据, 例如根据ID获取名称, 获取新ID, 获取新顺序号等, 需要在子类重写
        /// </summary>
        public virtual void processRefFeilds()
        {

        }


        /// <summary>
        /// 数据库连接串, 获取DBUtil的数据库连接串
        /// </summary>
        [JsonIgnore]
        public DBConnection connection
        {
            get
            {
                return DBUtil.connection;
            }
        }
        /// <summary>
        /// 用于标识是否为新实例, 用于决定update()调用时用insert还是update
        /// </summary>
        [JsonIgnore]
        public bool is_new = true;

        /// <summary>
        /// 表信息
        /// </summary>
        [JsonIgnore]
        protected DBTable _table = null;
        [JsonIgnore]
        public DBTable table
        {
            get
            {
                if (_table == null)
                {
                    _table = this.getAttribute<DBTable>();
                    if (_table == null)
                        _table = new DBTable();
                    else
                        _table.loadColumns(this.GetType());
                }
                return _table;
            }
        }

        /// <summary>
        /// 通过列名获取列信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DBColumn columnWithName(string name)
        {
            return table.columnWithName(name);
        }

        /// <summary>
        /// 根据列名数组生成DBColumn集合
        /// </summary>
        /// <param name="column_names"></param>
        /// <returns></returns>
        public List<DBColumn> columns(string[] column_names)
        {
            List<DBColumn> cols = new List<DBColumn>();
            if (column_names != null)
            {
                foreach (string col_name in column_names)
                {
                    DBColumn col = table.columnWithName(col_name);
                    if (col != null)
                        cols.Add(col);
                }
            }
            return cols;
        }

        /// <summary>
        /// 生成查询参数
        /// </summary>
        /// <param name="column_name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DBQueryParam queryParam(string column_name, object value)
        {
            return new DBQueryParam(table, column_name, value);
        }

        /// <summary>
        /// 设置数据结果行的值
        /// </summary>
        /// <param name="row"></param>
        public void setValueByRowData(DataRow row)
        {
            foreach (DBColumn column in table.columns)
            {
                this.setValue(column.field_info, row[column.name]);
            }
        }

        /// <summary>
        /// 获取下一个ID
        /// </summary>
        /// <param name="id_column"></param>
        /// <returns></returns>
        public int nextId(DBColumn id_column)
        {
            if (id_column == null)
                return nextId();
            return nextId(id_column.name);
        }

        /// <summary>
        /// 获取下一个ID
        /// </summary>
        /// <param name="id_column"></param>
        /// <returns></returns>
        public int nextId(string id_column)
        {
            if (id_column == "")
                id_column = "id";
            var query = $"select max({connection.left_quote}{id_column}{connection.right_quote}) from {connection.left_quote}{table.table_name}{connection.right_quote} ";
            int id = 0;
            try
            {
                id = Convert.ToInt32(DBQuery.query(query).Rows[0][0]);
            }
            catch { }
            id++;
            return id;
        }

        /// <summary>
        /// 获取下一个ID
        /// </summary>
        /// <returns></returns>
        public int nextId()
        {
            return nextId("id");
        }

        public int nextIndex(DBQueryParamList query_param, string index_column)
        {
            if (index_column == "")
                index_column = "idx";
            var query = new StringBuilder();
            query.Append($"select max({connection.left_quote}{index_column}{connection.right_quote}) from {connection.left_quote}{table.table_name}{connection.right_quote} ");
            var query_string = new StringBuilder();
            var pm = new List<DBParameter>();
            if (query_param != null && query_param.count > 0)
            {
                foreach (DBQueryParam param in query_param.pm_list)
                {
                    if (query_string.Length > 0)
                        query_string.Append(" and ");
                    query_string.Append(param.queryString());
                    param.setQueryParameter(ref pm);
                }
            }
            if (query_string.Length > 0)
                query.Append($" where {query_string.ToString()}");
            int idx = 0;
            try
            {
                idx = Convert.ToInt32(DBQuery.query(query.ToString(), pm).Rows[0][0]);
            }
            catch { }
            idx++;
            return idx;
        }

        /// <summary>
        /// 将当前数据插入数据库
        /// </summary>
        /// <returns>错误信息</returns>
        public string insert()
        {
            if (table.primary_columns.Count == 1 && table.primary_columns[0].name == "id")
            {//判断如果当前的主键有且只有一个id时, 判断id是否为0, 是的话获取下一个id值
                try
                {
                    var id = Convert.ToInt32(this.getValue(table.primary_columns[0].field_info));
                    if (id <= 0)
                        this.setValue(table.primary_columns[0].field_info, nextId());
                }
                catch { }
            }
            var pm = new List<DBParameter>();
            foreach (DBColumn col in table.columns)
            {
                pm.Add(new DBParameter(col.name, col.field_info.GetValue(this)));
            }
            return DBQuery.insert(table.table_name, pm, connection);
        }

        /// <summary>
        /// 将当前数据更新到数据库
        /// </summary>
        /// <returns>错误信息</returns>
        public string update()
        {
            if (is_new)
                return insert();
            var pm = new List<DBParameter>();
            foreach (DBColumn column in table.common_columns)
            {
                pm.Add(new DBParameter(column.name, column.field_info.GetValue(this)));
            }
            var pk = new List<DBParameter>();
            foreach (DBColumn column in table.primary_columns)
            {
                pk.Add(new DBParameter(column.name, column.field_info.GetValue(this)));
            }
            return DBQuery.update(table.table_name, pm, pk, connection);
        }

        /// <summary>
        /// 更新表中的部分记录
        /// </summary>
        /// <param name="update_columns">需要更新的列</param>
        /// <returns></returns>
        public string update(List<DBColumn> update_columns)
        {
            if (is_new)
            {
                return "还没有插入该记录, 不能更新";
            }
            var pm = new List<DBParameter>();
            foreach (DBColumn column in update_columns)
            {
                pm.Add(new DBParameter(column.name, column.field_info.GetValue(this)));
            }
            var pk = new List<DBParameter>();
            foreach (DBColumn column in table.primary_columns)
            {
                pk.Add(new DBParameter(column.name, column.field_info.GetValue(this)));
            }
            return DBQuery.update(table.table_name, pm, pk, connection);
        }

        public string update(string[] column_names)
        {
            return update(columns(column_names));
        }

        /// <summary>
        /// 从数据库删除当前数据
        /// </summary>
        /// <param name="connection_string"></param>
        /// <returns>错误信息</returns>
        public string delete()
        {
            var pk = new List<DBParameter>();
            foreach (DBColumn column in table.primary_columns)
            {
                pk.Add(new DBParameter(column.name, column.field_info.GetValue(this)));
            }
            return DBQuery.delete(table.table_name, pk, connection);
        }

        /// <summary>
        /// 交换某列的两个值
        /// </summary>
        /// <param name="target_column">要交换的列</param>
        /// <param name="value1">值1(原值)</param>
        /// <param name="value2">值2(要交换的值)</param>
        /// <param name="key_column">主键列</param>
        /// <param name="key1">主键值1(当前实例主键)</param>
        /// <param name="key2">主键值2(被交换的实例的主键)</param>
        /// <returns></returns>
        public string exchangeColumnValue(DBColumn target_column, object value1, object value2, DBColumn key_column, object key1, object key2)
        {
            var pm = new List<DBParameter>();
            var sql = $"update {connection.left_quote}{table.table_name}{connection.right_quote} set {connection.left_quote}{target_column.name}{connection.right_quote}={connection.param(target_column.name)} where {new DBQueryParam(key_column, key1).queryString()} ";
            pm.Add(new DBParameter(target_column.name, value2));
            var msg = DBQuery.execute(sql.ToString(), pm);
            if (msg != "")
            {
                return msg;
            }
            pm = new List<DBParameter>();
            sql = $"update {connection.left_quote}{table.table_name}{connection.right_quote} set {connection.left_quote}{target_column.name}{connection.right_quote}={connection.param(target_column.name)} where {new DBQueryParam(key_column, key2).queryString()} ";
            pm.Add(new DBParameter(target_column.name, value1));
            msg = DBQuery.execute(sql, pm);
            if (msg != "")
            {
                pm = new List<DBParameter>();
                sql = $"update {connection.left_quote}{table.table_name}{connection.right_quote} set {connection.left_quote}{target_column.name}{connection.right_quote}={connection.param(target_column.name)} where {new DBQueryParam(key_column, key1).queryString()} ";
                pm.Add(new DBParameter(target_column.name, value1));
                DBQuery.execute(sql, pm);
                return msg;
            }
            return "";
        }

        /// <summary>
        /// 顺序号上移(默认的id/idx, 全表匹配)
        /// </summary>
        /// <returns></returns>
        public DBIndexChangeResult indexUp()
        {
            return indexUp("id", "idx", null);
        }

        /// <summary>
        /// 顺序号上移(默认的id/idx, 自定义查询条件)
        /// </summary>
        /// <param name="query_param"></param>
        /// <returns></returns>
        public DBIndexChangeResult indexUp(DBQueryParamList query_param)
        {
            return indexUp("id", "idx", query_param);
        }

        /// <summary>
        /// 顺序号上移, 自定义id/index列, 自定义查询条件
        /// </summary>
        /// <param name="id_column"></param>
        /// <param name="index_column"></param>
        /// <param name="query_param"></param>
        /// <returns></returns>
        public DBIndexChangeResult indexUp(string id_column, string index_column, DBQueryParamList query_param)
        {
            return indexUp(table.columnWithName(id_column), table.columnWithName(index_column), query_param);
        }

        /// <summary>
        /// 顺序号上移, 自定义id/index列, 自定义查询条件
        /// </summary>
        /// <param name="id_column"></param>
        /// <param name="index_column"></param>
        /// <param name="query_param"></param>
        /// <returns></returns>
        public DBIndexChangeResult indexUp(DBColumn id_column, DBColumn index_column, DBQueryParamList query_param)
        {
            var result = new DBIndexChangeResult();
            if (id_column == null || index_column == null || index_column.data_type != DBDataType.Integer)
            {
                result.error_message = "传入id列或index列有误";
                return result;
            }
            result.current_id = id_column.field_info.GetValue(this);
            result.current_index = Convert.ToInt32(index_column.field_info.GetValue(this));
            var query = new StringBuilder();
            query.Append($"select max({connection.left_quote}{index_column.name}{connection.right_quote}) from {connection.left_quote}{table.table_name}{connection.right_quote} where ");
            query.Append($"{connection.left_quote}{index_column.name}{connection.right_quote}<{result.current_index} ");
            var query_extra = new StringBuilder();
            if (query_param != null && query_param.count > 0)
            {
                foreach (DBQueryParam param in query_param.pm_list)
                {
                    if (!param.isAvailableWithValue())
                    {
                        result.error_message = "自定义查询条件有误";
                        return result;
                    }
                    query_extra.Append($" and {param.queryString()} ");
                }
            }
            query.Append(query_extra.ToString());
            DataTable data = DBQuery.query(query.ToString());
            try
            {
                result.target_index = Convert.ToInt32(data.Rows[0][0]);
            }
            catch { }
            query.Clear();
            query.Append($"select {connection.left_quote}{id_column.name}{connection.right_quote} from {connection.left_quote}{table.table_name}{connection.right_quote} where {connection.left_quote}{index_column.name}{connection.right_quote}={result.target_index} ");
            query_extra.Clear();
            if (query_param != null && query_param.count > 0)
            {
                foreach (DBQueryParam param in query_param.pm_list)
                {
                    if (!param.isAvailableWithValue())
                    {
                        result.error_message = "自定义查询条件有误";
                        return result;
                    }
                    query_extra.Append($" and {param.queryString()} ");
                }
            }
            query.Append(query_extra.ToString());
            data = DBQuery.query(query.ToString());
            try
            {
                result.target_id = Convert.ToInt32(data.Rows[0][0]);
            }
            catch { }
            if (result.target_index <= 0)
            {
                result.error_message = "当前项目已在最顶部";
                return result;
            }
            var msg = exchangeColumnValue(index_column, result.current_index, result.target_index, id_column, result.current_id, result.target_id);
            if (msg != "")
            {
                result.error_message = "更新顺序号失败, 错误信息" + msg;
                return result;
            }
            int target_index = result.target_index;
            result.target_index = result.current_index;
            result.current_index = target_index;
            return result;
        }

        /// <summary>
        /// 顺序号下移(默认的id/idx, 全表匹配)
        /// </summary>
        /// <returns></returns>
        public DBIndexChangeResult indexDown()
        {
            return indexDown("id", "idx", null);
        }

        /// <summary>
        /// 顺序号上移(默认的id/idx, 自定义查询条件)
        /// </summary>
        /// <param name="query_param"></param>
        /// <returns></returns>
        public DBIndexChangeResult indexDown(DBQueryParamList query_param)
        {
            return indexDown("id", "idx", query_param);
        }

        /// <summary>
        /// 顺序号下移, 自定义id/index列, 自定义查询条件
        /// </summary>
        /// <param name="id_column"></param>
        /// <param name="index_column"></param>
        /// <param name="query_param"></param>
        /// <returns></returns>
        public DBIndexChangeResult indexDown(string id_column, string index_column, DBQueryParamList query_param)
        {
            return indexDown(table.columnWithName(id_column), table.columnWithName(index_column), query_param);
        }

        /// <summary>
        /// 顺序号下移, 自定义id/index列, 自定义查询条件
        /// </summary>
        /// <param name="id_column"></param>
        /// <param name="index_column"></param>
        /// <param name="query_param"></param>
        /// <returns></returns>
        public DBIndexChangeResult indexDown(DBColumn id_column, DBColumn index_column, DBQueryParamList query_param)
        {
            DBIndexChangeResult result = new DBIndexChangeResult();
            if (id_column == null || index_column == null || index_column.data_type != DBDataType.Integer)
            {
                result.error_message = "传入id列或index列有误";
                return result;
            }
            result.current_id = id_column.field_info.GetValue(this);
            result.current_index = Convert.ToInt32(index_column.field_info.GetValue(this));
            var query = new StringBuilder();
            query.Append($"select min({connection.left_quote}{index_column.name}{connection.right_quote}) from {connection.left_quote}{table.table_name}{connection.right_quote} where ");
            query.Append($" {connection.left_quote}{index_column.name}{connection.right_quote}>{result.current_index} ");
            var query_extra = new StringBuilder();
            if (query_param != null && query_param.count > 0)
            {
                foreach (DBQueryParam param in query_param.pm_list)
                {
                    if (!param.isAvailableWithValue())
                    {
                        result.error_message = "自定义查询条件有误";
                        return result;
                    }
                    query_extra.Append($" and {param.queryString()} ");
                }
            }
            query.Append(query_extra.ToString());
            var data = DBQuery.query(query.ToString());
            try
            {
                result.target_index = Convert.ToInt32(data.Rows[0][0]);
            }
            catch { }
            query.Clear();
            query.Append($"select {connection.left_quote}{id_column.name}{connection.right_quote} from {connection.left_quote}{table.table_name}{connection.right_quote} where {connection.left_quote}{index_column.name}{connection.right_quote}={result.target_index} ");
            query_extra.Clear();
            if (query_param != null && query_param.count > 0)
            {
                foreach (DBQueryParam param in query_param.pm_list)
                {
                    if (!param.isAvailableWithValue())
                    {
                        result.error_message = "自定义查询条件有误";
                        return result;
                    }
                    query_extra.Append($" and {param.queryString()} ");
                }
            }
            query.Append(query_extra);
            data = DBQuery.query(query.ToString());
            try
            {
                result.target_id = Convert.ToInt32(data.Rows[0][0]);
            }
            catch { }
            if (result.target_index <= 0)
            {
                result.error_message = "当前项目已在最底部";
                return result;
            }
            var msg = exchangeColumnValue(index_column, result.current_index, result.target_index, id_column, result.current_id, result.target_id);
            if (msg != "")
            {
                result.error_message = "更新顺序号失败, 错误信息" + msg;
                return result;
            }
            int target_index = result.target_index;
            result.target_index = result.current_index;
            result.current_index = target_index;
            return result;
        }

        /// <summary>
        /// 检测当前实例是否重复,默认id
        /// </summary>
        /// <param name="check_columns">检测重复的列</param>
        /// <returns></returns>
        public bool checkDuplicate<T>(List<DBColumn> check_columns)
        {
            return checkDuplicate<T>("id", check_columns);
        }

        /// <summary>
        /// 检测当前实例是否重复
        /// </summary>
        /// <param name="id_column">id列名</param>
        /// <param name="query_param">检测重复的查询条件</param>
        /// <returns></returns>
        public bool checkDuplicate<T>(string id_column, List<DBColumn> check_columns)
        {
            return checkDuplicate<T>(table.columnWithName(id_column), check_columns);
        }

        /// <summary>
        /// 检测当前实例是否重复
        /// </summary>
        /// <param name="id_column">id列</param>
        /// <param name="query_param">检测重复的查询条件</param>
        /// <returns></returns>
        public bool checkDuplicate<T>(DBColumn id_column, List<DBColumn> check_columns)
        {
            if (check_columns == null || check_columns.Count <= 0)
                return false;
            var pm = DBQueryParamList.create();
            foreach (DBColumn col in check_columns)
            {
                pm.add(new DBQueryParam(col, col.field_info.GetValue(this)));
            }
            var value_columns = new List<DBColumn>();
            value_columns.Add(id_column);
            var test = getValues<T>(value_columns, pm);
            if (test == null)
                return false;
            var value = id_column.field_info.GetValue(this);
            try
            {
                if (value.GetType() == typeof(string))
                {
                    var id = id_column.field_info.GetValue(test).ToString();
                    if (!id.isNull() && value.ToString() != id)
                        return true;
                    else
                        return false;
                }
                else
                {
                    try
                    {
                        var id = Convert.ToInt64(id_column.field_info.GetValue(test));
                        if (id > 0 && id != Convert.ToInt64(value))
                            return true;
                        else
                            return false;
                    }
                    catch { }
                }
            }
            catch { }
            return false;
        }

        /// <summary>
        /// 根据查询条件获取表中最近的一条记录
        /// </summary>
        /// <param name="query_param"></param>
        /// <param name="time_column"></param>
        public void loadLatestRecord(DBQueryParamList query_param, string time_column)
        {
            var query = new StringBuilder();
            query.Append($"select {connection.topCountOnStart(1)} * from {connection.left_quote}{table.table_name}{connection.right_quote} where 1=1 ");
            var query_extra = new StringBuilder();
            if (query_param != null && query_param.count > 0)
            {
                foreach (DBQueryParam param in query_param.pm_list)
                {
                    if (!param.isAvailableWithValue())
                    {
                        return;
                    }
                    query_extra.Append($" and {param.queryString()} ");
                }
            }
            else
                return;
            query.Append(query_extra);
            query.Append($" order by {connection.left_quote}{time_column}{connection.right_quote} desc ");
            query.Append(connection.topCountOnEnd(1));
            DataTable data = DBQuery.query(query.ToString());
            try
            {
                setValueByRowData(data.Rows[0]);
            }
            catch { }
        }

        /// <summary>
        /// 根据查询条件获取表中最近的一条记录
        /// </summary>
        /// <param name="query_param"></param>
        /// <param name="time_column"></param>
        public void loadLatestRecord(DBQueryParamList query_param, DBColumn time_column)
        {
            loadLatestRecord(query_param, time_column.name);
        }
    }
}