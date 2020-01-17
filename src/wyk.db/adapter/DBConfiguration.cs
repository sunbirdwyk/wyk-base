using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 映射数据库中配置表的类, 通常配置表为两列, 名称列/值列, 每条记录代表一个配置信息
    /// 注: 继承此类后添加的所有string类型的field都会成为配置表中的一条记录
    /// </summary>
    [DBConfigurationInfo("sys_configuration")]
    public class DBConfiguration
    {
        [JsonIgnore]
        public DBConnection connection = new DBConnection();
        [JsonIgnore]
        public string connection_string
        {
            get
            {
                if (connection == null)
                    return "";
                return connection.connection_string;
            }
            set
            {
                if (connection == null)
                    connection = new DBConnection(value);
                else
                {
                    connection.connection_string = value;
                    connection.refreshDBProperties();
                }
            }
        }

        /// <summary>
        /// 域Id
        /// 注: 如果支持多域, load之前需要先设置domain_id
        /// </summary>
        public int domain_id = 0;

        [JsonIgnore]
        private List<FieldInfo> _config_fields = null;
        /// <summary>
        /// 配置名列表
        /// </summary>
        [JsonIgnore]
        public List<FieldInfo> ConfigFields
        {
            get
            {
                if (_config_fields == null)
                {
                    _config_fields = new List<FieldInfo>();
                    FieldInfo[] fields = this.GetType().GetFields();
                    foreach (FieldInfo fi in fields)
                    {
                        if (fi.FieldType != typeof(string))
                            continue;
                        _config_fields.Add(fi);
                    }
                }
                return _config_fields;
            }
        }

        [JsonIgnore]
        protected DBConfigurationInfo _config_info = null;
        /// <summary>
        /// Attribute信息
        /// </summary>
        [JsonIgnore]
        public DBConfigurationInfo config_info
        {
            get
            {
                if (_config_info == null)
                {
                    _config_info = this.getAttribute<DBConfigurationInfo>();
                    if (_config_info == null)
                        _config_info = new DBConfigurationInfo("");
                }
                return _config_info;
            }
        }

        /// <summary>
        /// 配置总数
        /// </summary>
        /// <returns></returns>
        public int itemCount()
        {
            return ConfigFields.Count;
        }

        /// <summary>
        /// 从数据库中加载数据
        /// </summary>
        /// <param name="connection"></param>
        private void load(DBConnection connection)
        {
            var query =
                   $"select {connection.left_quote}{config_info.name_column}{connection.right_quote} as {connection.left_quote}name{connection.right_quote}, " +
                   $"  {connection.left_quote}{config_info.value_column}{connection.right_quote} as {connection.left_quote}value{connection.right_quote} " +
                   $"from {connection.left_quote}{config_info.table_name}{connection.right_quote} ";
            if (config_info.domain_column.hasContents())
            {
                query += $" where {connection.left_quote}{config_info.domain_column}{connection.right_quote}={domain_id} ";
            }

            DataTable data = DBQuery.query(query, connection, null, out _);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                try
                {
                    string name = data.Rows[i]["name"].ToString();
                    string value = data.Rows[i]["value"].ToString();
                    set(name, value);
                }
                catch { }
            }
            
        }

        /// <summary>
        /// 从数据库中加载数据
        /// </summary>
        /// <param name="connection_string"></param>
        public void load(string connection_string)
        {
            this.connection_string = connection_string;
            load(connection);
        }

        public void load()
        {
            load(DBUtil.connection);
        }

        /// <summary>
        /// 保存当前配置到数据库
        /// </summary>
        /// <returns></returns>
        public string save()
        {
            string msg = "";
            foreach (FieldInfo fi in ConfigFields)
            {
                msg += save(fi);
            }
            return msg;
        }

        /// <summary>
        /// 保存当前配置到数据库(单条数据)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string save(string name)
        {
            foreach (FieldInfo fi in ConfigFields)
            {
                if (fi.Name == name)
                {
                    return save(fi);
                }
            }
            return "Field '" + name + "' Not Found!";
        }

        /// <summary>
        /// 保存当前配置到数据库(单条数据)
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public string save(FieldInfo field)
        {
            var pk = new List<DBParameter>();
            pk.Add(new DBParameter(config_info.name_column, field.Name));
            if (config_info.domain_column != "")
                pk.Add(new DBParameter(config_info.domain_column, domain_id));
            DBQuery.delete(config_info.table_name, pk, connection);
            var pm = new List<DBParameter>();
            pm.Add(new DBParameter(config_info.name_column, field.Name));
            pm.Add(new DBParameter(config_info.value_column, field.GetValue(this)));
            if (config_info.domain_column != "")
                pm.Add(new DBParameter(config_info.domain_column, domain_id));
            return DBQuery.insert(config_info.table_name, pm, connection);
        }

        /// <summary>
        /// 根据名称获取配置值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string get(string name)
        {
            foreach (FieldInfo fi in ConfigFields)
            {
                if (fi.Name == name)
                {
                    return fi.GetValue(this) as string;
                }
            }
            return "";
        }

        /// <summary>
        /// 设置配置值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string set(string name, string value)
        {
            return set(name, value, false);
        }

        /// <summary>
        /// 设置配置值, 并决定是否保存到数据库
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="save_to_db"></param>
        /// <returns></returns>
        public string set(string name, string value, bool save_to_db)
        {
            foreach (FieldInfo fi in ConfigFields)
            {
                if (fi.Name == name)
                {
                    fi.SetValue(this, value);
                    if (save_to_db)
                        return save(name);
                    return "";
                }
            }
            return "Field Not Found!";
        }

        public bool configFieldsContains(string name)
        {
            foreach(var f in ConfigFields)
            {
                if (f.Name == name)
                    return true;
            }
            return false;
        }
    }
}