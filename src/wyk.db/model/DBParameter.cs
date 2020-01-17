using MySql.Data.MySqlClient;
using System;
using System.Data.OleDb;

namespace wyk.db
{
    /// <summary>
    /// 数据查询参数, 用于中转OleDbParameter/MySqlParameter, 以及其他Parameter
    /// </summary>
    public class DBParameter
    {
        public string name = "";
        public object value = DBNull.Value;

        public DBParameter() { }
        public DBParameter(string name, object value)
        {
            this.name = name;
            this.value = value;
        }


        public OleDbParameter oledbParam()
        {
            return new OleDbParameter(name, value);
        }

        public MySqlParameter mysqlParam()
        {
            return new MySqlParameter(name, value);
        }
    }
}