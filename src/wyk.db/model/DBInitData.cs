using System.Collections.Generic;
using System.Data.OleDb;
using System.Xml;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 数据库初始数据项
    /// 注: 每个实例代表一条表中的数据, 由key/value组成, key为列名
    /// </summary>
    public class DBInitData
    {
        public List<DBInitDataItem> item_list = new List<DBInitDataItem>();

        public DBInitData() { }
        public DBInitData(XmlNode xn)
        {
            item_list = new List<DBInitDataItem>();
            if (xn != null)
            {
                foreach (XmlNode item in xn.ChildNodes)
                {
                    var di = new DBInitDataItem();
                    di.column_name = item.Name;
                    di.DataType = item.Attributes["type"].Value;
                    di.column_value = item.InnerText.xmlDecode();
                    item_list.Add(di);
                }
            }
        }
        public DBInitData(DBTable table)
        {
            item_list = new List<DBInitDataItem>();
            foreach(var column in table.columns)
            {
                if (column.data_type == DBDataType.Binary)
                    continue;
                var di = new DBInitDataItem();
                di.column_name = column.name;
                di.data_type = column.data_type;
                di.StringValue = column.default_value;
                item_list.Add(di);
            }
        }

        public DBInitDataItem dataWithName(string name)
        {
            foreach(var di in item_list)
            {
                if (di.column_name == name)
                    return di;
            }
            return null;
        }

        public string stringValueWithName(string name)
        {
            foreach(var di in item_list)
            {
                if (di.column_name == name)
                    return di.StringValue;
            }
            return "";
        }

        public object valueWithName(string name)
        {
            foreach (var di in item_list)
            {
                if (di.column_name == name)
                    return di.column_value;
            }
            return "";
        }

        public string insertData(string table_name)
        {
            var pm = new List<DBParameter>();
            foreach (var di in item_list)
            {
                if (di.column_value == null)
                    continue;
                var param = di.getParameter(table_name);
                if (param != null)
                    pm.Add(param);
            }
            return DBQuery.insert(table_name, pm);
        }
    }
}
