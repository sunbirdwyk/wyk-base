using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using wyk.basic;

namespace wyk.db
{
    [DBCommonDictionaryInfo("dic_common_dictionary")]
    public class DBCommonDictionaryList
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

        public int domain_id = 0;

        protected DBCommonDictionaryInfo _dictionary_info = null;
        /// <summary>
        /// Attribute信息
        /// </summary>
        public DBCommonDictionaryInfo dictionary_info
        {
            get
            {
                if (_dictionary_info == null)
                {
                    _dictionary_info = this.getAttribute<DBCommonDictionaryInfo>();
                    if (_dictionary_info == null)
                        _dictionary_info = new DBCommonDictionaryInfo("");
                }
                return _dictionary_info;
            }
        }

        List<DBCommonDictionary> _dictionaries = null;
        public List<DBCommonDictionary> dictionaries
        {
            get
            {
                if (_dictionaries == null)
                {
                    _dictionaries = new List<DBCommonDictionary>();
                    FieldInfo[] fields = this.GetType().GetFields();
                    foreach (FieldInfo fi in fields)
                    {
                        if (fi.FieldType == typeof(DBCommonDictionary))
                        {
                            try
                            {
                                DBCommonDictionary item = fi.GetValue(this) as DBCommonDictionary;
                                item.field_name = fi.Name;
                                _dictionaries.Add(item);
                            }
                            catch { }
                        }
                    }
                }
                return _dictionaries;
            }
        }

        /// <summary>
        /// 获取下个Id
        /// </summary>
        /// <returns></returns>
        public int nextId()
        {
            string query = $"select max({connection.left_quote}{dictionary_info.id_column}{connection.right_quote}) from {connection.left_quote}{dictionary_info.table_name}{connection.right_quote}";
            int id = 0;
            DataTable data = DBQuery.query(query, connection, null, out string msg);
            try
            {
                id = Convert.ToInt32(data.Rows[0][0]);
            }
            catch { }
            return id + 1;
        }

        /// <summary>
        /// 获取下个Index
        /// </summary>
        /// <param name="dictionary_type"></param>
        /// <returns></returns>
        public int nextIndex(string dictionary_type)
        {
            string query =
                $"select max({connection.left_quote}{dictionary_info.index_column}{connection.right_quote}) " +
                $"from {connection.left_quote}{dictionary_info.table_name}{connection.right_quote} " +
                $"where {connection.left_quote}{dictionary_info.type_column}{connection.right_quote}='{dictionary_type}' ";
            if (dictionary_info.domain_column != "")
                query += $" and {connection.left_quote}{dictionary_info.domain_column}{connection.right_quote}={domain_id} ";
            int index = 0;
            DataTable data = DBQuery.query(query, connection, null, out string msg);
            try
            {
                index = Convert.ToInt32(data.Rows[0][0]);
            }
            catch { }
            return index + 1;
        }

        /// <summary>
        /// 从数据库中加载数据
        /// </summary>
        /// <param name="connection"></param>
        private void load(DBConnection connection)
        {
            load(connection.connection_string);
        }

        /// <summary>
        /// 从数据库中加载数据
        /// </summary>
        /// <param name="connection_string"></param>
        private void load(string connection_string)
        {
            this.connection_string = connection_string;
            var query =
                $"select {connection.left_quote}{dictionary_info.id_column}{connection.right_quote} as {connection.left_quote}id{connection.right_quote}, " +
                $"{connection.left_quote}{dictionary_info.type_column}{connection.right_quote} as {connection.left_quote}type{connection.right_quote}, " +
                $"{connection.left_quote}{dictionary_info.content_column}{connection.right_quote} as {connection.left_quote}content{connection.right_quote}, " +
                $"{connection.left_quote}{dictionary_info.shortcut_column}{connection.right_quote} as {connection.left_quote}shortcut{connection.right_quote}, " +
                $"{connection.left_quote}{dictionary_info.index_column}{connection.right_quote} as {connection.left_quote}index{connection.right_quote} " +
                $"from {connection.left_quote}{dictionary_info.table_name}{connection.right_quote} ";
            if (dictionary_info.domain_column.hasContents())
                query += $" where {connection.left_quote}{dictionary_info.domain_column}{connection.right_quote}={domain_id} ";
            query += $" order by {connection.left_quote}{dictionary_info.type_column}{connection.right_quote},{connection.left_quote}{dictionary_info.index_column}{connection.right_quote} ";
            DataTable data = DBQuery.query(query, connection, null, out string msg);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                try
                {
                    string type = data.Rows[i]["type"].ToString();
                    DBCommonDictionary dic = dictionaryWithField(type);
                    if (dic == null)
                        continue;
                    DBCommonDictionaryItem item = new DBCommonDictionaryItem();
                    item.id = Convert.ToInt32(data.Rows[i]["id"]);
                    item.content = data.Rows[i]["content"].ToString();
                    item.shortcut = data.Rows[i]["shortcut"].ToString();
                    try
                    {
                        item.index = Convert.ToInt32(data.Rows[i]["index"]);
                    }
                    catch { }
                    dic.items.Add(item);
                }
                catch { }
            }
        }

        public void load()
        {
            load(DBUtil.connection_string);
        }

        /// <summary>
        /// 保存当前配置到数据库
        /// </summary>
        /// <returns></returns>
        public string save()
        {
            string msg = "";
            foreach (DBCommonDictionary dictionary in dictionaries)
            {
                msg += save(dictionary);
            }
            return msg;
        }

        /// <summary>
        /// 保存当前配置到数据库(单项字典)
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string save(DBCommonDictionary dictionary)
        {
            string msg = "";
            foreach (DBCommonDictionaryItem item in dictionary.items)
            {
                msg += save(item);
            }
            return msg;
        }

        /// <summary>
        /// 保存当前配置到数据库(单条数据)
        /// </summary>
        /// <param name="dic_item"></param>
        /// <returns></returns>
        public string save(DBCommonDictionaryItem dic_item)
        {
            bool is_update = false;
            if (dic_item.id > 0)
            {
                DBCommonDictionaryItem test = queryItem(dic_item.id);
                if (test.id > 0)
                    is_update = true;
            }
            else
            {
                dic_item.id = nextId();
            }
            if (dic_item.index <= 0)
                dic_item.index = nextIndex(dic_item.dic_type);
            if (is_update)
            {
                var pm = new List<DBParameter>();
                pm.Add(new DBParameter(dictionary_info.type_column, dic_item.dic_type));
                pm.Add(new DBParameter(dictionary_info.content_column, dic_item.content));
                pm.Add(new DBParameter(dictionary_info.shortcut_column, dic_item.shortcut));
                pm.Add(new DBParameter(dictionary_info.index_column, dic_item.index));
                if (dictionary_info.domain_column != "")
                    pm.Add(new DBParameter(dictionary_info.domain_column, domain_id));
                var pk = new List<DBParameter>();
                pk.Add(new DBParameter(dictionary_info.id_column, dic_item.id));
                return DBQuery.update(dictionary_info.table_name, pm, pk, connection);
            }
            else
            {
                var pm = new List<DBParameter>();
                pm.Add(new DBParameter(dictionary_info.id_column, dic_item.id));
                pm.Add(new DBParameter(dictionary_info.type_column, dic_item.dic_type));
                pm.Add(new DBParameter(dictionary_info.content_column, dic_item.content));
                pm.Add(new DBParameter(dictionary_info.shortcut_column, dic_item.shortcut));
                pm.Add(new DBParameter(dictionary_info.index_column, dic_item.index));
                if (dictionary_info.domain_column != "")
                    pm.Add(new DBParameter(dictionary_info.domain_column, domain_id));
                return DBQuery.insert(dictionary_info.table_name, pm, connection);
            }
        }

        public DBCommonDictionaryItem queryItem(int id)
        {
            var query =
                $"select * " +
                $"from {connection.left_quote}{dictionary_info.table_name}{connection.right_quote} " +
                $"where {connection.left_quote}{dictionary_info.id_column}{connection.right_quote}={id} ";
            DataTable data = DBQuery.query(query, connection, null, out string msg);
            DBCommonDictionaryItem item = new DBCommonDictionaryItem();
            try
            {
                item.id = Convert.ToInt32(data.Rows[0][dictionary_info.id_column]);
                item.dic_type = data.Rows[0][dictionary_info.type_column].ToString();
                item.content = data.Rows[0][dictionary_info.shortcut_column].ToString();
                item.index = Convert.ToInt32(data.Rows[0][dictionary_info.index_column]);
            }
            catch { }
            return item;
        }

        public string setItem(string content, string type)
        {
            DBCommonDictionary dic = dictionaryWithField(type);
            if (dic == null)
                return "字典类型有误";
            DBCommonDictionaryItem item = dic.get(content);
            if (item == null)
            {
                item = new DBCommonDictionaryItem();
                item.id = nextId();
                item.content = content;
                item.dic_type = type;
                item.shortcut = CharacterUtil.getPinyinShort(content, 50);
                item.index = nextIndex(type);
                dic.items.Add(item);
                return save(item);
            }
            return "";
        }

        public DBCommonDictionary dictionaryWithField(string field_name)
        {
            foreach (DBCommonDictionary dictionary in dictionaries)
            {
                if (dictionary.field_name == field_name)
                    return dictionary;
            }
            return null;
        }

        public DataTable getDictionaryInfoTable(string type, string filter)
        {
            var query =
                $"select {connection.left_quote}{dictionary_info.id_column}{connection.right_quote} as {connection.left_quote}id{connection.right_quote}, " +
                $"  {connection.left_quote}{dictionary_info.content_column}{connection.right_quote} as {connection.left_quote}content{connection.right_quote} " +
                $"from {connection.left_quote}{dictionary_info.table_name}{connection.right_quote} " +
                $"where {connection.left_quote}{dictionary_info.type_column}{connection.right_quote}='{type}' " +
                $"   and ({connection.left_quote}{dictionary_info.content_column}{connection.right_quote} like '{filter}%' or {connection.left_quote}{dictionary_info.shortcut_column}{connection.right_quote} like '{filter}%') ";
            if (dictionary_info.domain_column != "")
                query += $" and {connection.left_quote}{dictionary_info.domain_column}{connection.right_quote}={domain_id} ";
            query += $" order by {connection.left_quote}{dictionary_info.index_column}{connection.right_quote} ";
            DataTable data = DBQuery.query(query, connection, null, out string msg);
            return data;
        }
    }

    /*
    [DBDropDownDictionaryInfo("table_name")]
    public class DBCommonDictionaryList : DBCommonDictionaryList
    {
        public DBCommonDictionary dictionary1 = new DBCommonDictionary();
        public DBCommonDictionary dictionary2 = new DBCommonDictionary();
        public DBCommonDictionary dictionary3 = new DBCommonDictionary();
        public DBCommonDictionary dictionary4 = new DBCommonDictionary();
    }*/
}
