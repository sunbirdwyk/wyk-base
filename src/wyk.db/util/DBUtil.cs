using System.Data;
using System.Threading;

namespace wyk.db
{
    /// <summary>
    /// 数据库功能单元
    /// </summary>
    public class DBUtil
    {
        /// <summary>
        /// 建立一个公共的数据库访问连接串, 在程序最开始设置一次, 之后就不需要再使用
        /// </summary>
        public static DBConnection connection = new DBConnection();
        public static string connection_string
        {
            get => connection.connection_string;
            set
            {
                if (connection.connection_string != value)
                {
                    connection.connection_string = value;
                    connection.refreshDBProperties();
                }
            }
        }
        /// <summary>
        /// 默认的全局sequence表名, 如有不同, 请在程序开始时设置一次
        /// </summary>
        public static string sequence_table_all = "seq_all";
        /// <summary>
        /// 默认的每日sequence表名, 如有不同, 请在程序开始时设置一次
        /// </summary>
        public static string sequence_table_daily = "seq_daily";

        /// <summary>
        /// 使用默认数据库连接测试连接状态
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool testConnection(out string msg)
        {
            return testConnection(connection, out msg);
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="connection_string">连接串</param>
        /// <param name="msg">错误信息</param>
        /// <returns>是否连接成功</returns>
        public static bool testConnection(string connection_string, out string msg)
        {
            return testConnection(new DBConnection(connection_string), out msg);
        }

        /// <summary>
        /// 测试连接
        /// 可设置超时
        /// 毫秒
        /// </summary>
        /// <param name="connection_string">连接串</param>
        /// <param name="msg">错误信息</param>
        /// <returns>是否连接成功</returns>
        public static bool testConnection(string connection_string, out string msg, int time_out)
        {
            return testConnection(new DBConnection(connection_string), out msg, time_out);
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="connection">连接</param>
        /// <param name="msg">错误信息</param>
        /// <returns>是否连接成功</returns>
        public static bool testConnection(DBConnection connection, out string msg)
        {
            DataTable dt = DBQuery.schema(connection, DBSchemaName.Tables, out string err);
            if (err == "")
            {
                if (dt.Rows.Count > 0)
                {
                    msg = "连接成功!";
                    return true;
                }
                else
                {
                    msg = "连接失败!出现未知错误,请重新设置!";
                    return false;
                }

            }
            else
            {
                msg = "连接失败!错误信息:\r\n" + err;
                return false;
            }
        }

        /// <summary>
        /// 测试连接
        /// 可设置超时
        /// 毫秒
        /// </summary>
        /// <param name="connection">连接</param>
        /// <param name="msg">错误信息</param>
        /// <returns>是否连接成功</returns>
        public static bool testConnection(DBConnection connection, out string msg, int time_out)
        {
            var err = "";
            DataTable dt = new DataTable();
            Thread thread = new Thread(() => { dt = DBQuery.schema(connection, DBSchemaName.Tables, out err); });
            thread.Start();
            thread.Join(time_out);
            if (err == "")
            {
                if (dt.Rows.Count > 0)
                {
                    msg = "连接成功!";
                    return true;
                }
                else
                {
                    msg = "连接失败!出现未知错误,请重新设置!";
                    return false;
                }
            }
            else
            {
                msg = "连接失败!错误信息:\r\n" + err;
                return false;
            }
        }
    }
}
