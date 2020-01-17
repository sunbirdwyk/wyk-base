using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using wyk.basic;

namespace wyk.db
{
    public class DBInitializer
    {
        /// <summary>
        /// 创建数据库(公用, 当前支持Access 和 Sql Server)
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string createDatabase(DBConnection connection)
        {
            switch (connection.db_type)
            {
                case DBType.Access:
                    return createDatabaseForAccess(connection);
                case DBType.SqlServer:
                    return createDatabaseForSqlServer(connection);
                case DBType.MySql:
                    return createDatabaseForMySql(connection);
                default:
                    return "当前不支持的数据库类型!";
            }
        }

        /// <summary>
        /// 创建 Access 数据库
        /// </summary>
        /// <param name="path">数据库路径</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        static string createDatabaseForAccess(DBConnection connection)
        {
            try
            {
                IOUtil.createDirectoryIfNotExist(IOUtil.directoryPath(connection.server_name));
                var path = connection.server_name.Replace(AppDomain.CurrentDomain.BaseDirectory, "");
                ADOX.Catalog cc = new ADOX.Catalog();
                var psw_part = connection.password.hasContents() ? $"Jet OLEDB:Database Password={connection.password};" : "";
                var initialize_string = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path};{psw_part}Jet OLEDB:Engine Type=5";
                cc.Create(initialize_string);
                cc = null;
                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        /// <summary>
        /// 创建 Sql Server 数据库
        /// </summary>
        /// <param name="db_name">数据库名</param>
        /// <param name="server">服务器名</param>
        /// <param name="user">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        static string createDatabaseForSqlServer(DBConnection connection)
        {
            try
            {
                var auth_part = connection.windows_verification ? "Integrated Security=SSPI;" : $"User ID={connection.user_name};Password={connection.password};";
                var connection_string =$"Data Source={connection.server_name};Persist Security Info=True;{auth_part}";
                using (var conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    var create_db = $"create database {connection.database}";
                    using (var cmd = new SqlCommand(create_db, conn))
                        cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        static string createDatabaseForMySql(DBConnection connection)
        {
            try
            {
                var port_part = connection.port != 0 ? $"Port={connection.port};" : "";
                var connection_string = $"Server={connection.server_name};Uid={connection.user_name};Pwd={connection.password};{port_part}";
                using (var conn = new MySqlConnection(connection_string))
                {
                    conn.Open();
                    var create_db = $"create database {connection.database}; use {connection.database};";
                    using (var cmd = new MySqlCommand(create_db, conn))
                        cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        /// <summary>
        /// 创建 Sql Server 数据表
        /// </summary>
        /// <param name="table">数据表信息</param>
        /// <param name="connection">数据库连接</param>
        /// <returns></returns>
        public static string createTable(DBTable table, DBConnection connection)
        {
            string err = "";
            List<string> sql_list = table.getCreateTableSqlList(connection.db_type);
            for (int i = 0; i < sql_list.Count; i++)
            {
                var msg = DBQuery.execute(sql_list[i], connection);
                err += msg;
            }
            return err;
        }

        /// <summary>
        /// 创建 Sql Server 数据表
        /// </summary>
        /// <param name="table">数据表信息</param>
        /// <param name="connection_string">数据库连接串</param>
        /// <returns></returns>
        public static string createTable(DBTable table, string connection_string)
        {
            DBConnection connection = new DBConnection(connection_string);
            return createTable(table, connection);
        }



        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="reference_path"></param>
        /// <returns></returns>
        public static string initialize(DBConnection connection, string reference_path)
        {
            string msg = createDatabase(connection);
            if (msg != "")
                return msg;
            List<DBTable> tables = new List<DBTable>();
            try
            {
                string[] table_paths = Directory.GetFiles(reference_path, "*.table");
                foreach (string table_p in table_paths)
                {
                    DBTable tb = DBTable.fromXmlFile(table_p);
                    if (tb.table_name != "")
                    {
                        tables.Add(tb);
                    }
                }
            }
            catch { }
            if (tables.Count == 0)
            {
                msg = "无法获取可用的表描述文件!";
                return msg;
            }
            string table_err = "";
            foreach (DBTable table in tables)
            {
                table_err += createTable(table, connection);
            }
            msg += table_err;
            //初始化数据库版本号
            DBInitDataConfig config = new DBInitDataConfig();
            config.loadFrom(reference_path);
            if (config.CurrentDBVersion != "1.0.0")
            {
                var query = "insert into " + config.configuration_table_name + " (" + config.configuration_key_column + "," + config.configuration_value_column + ") values ('" + config.configuration_db_version_key + "','" + config.CurrentDBVersion + "')";
                DBQuery.execute(query, connection);
            }
            //初始化数据 
            List<DBInitDataProfile> data = new List<DBInitDataProfile>();
            try
            {
                string[] data_paths = Directory.GetFiles(reference_path, "*.data");
                foreach (string data_p in data_paths)
                {
                    DBInitDataProfile dp = DBInitDataProfile.fromXMLFile(data_p);
                    if (dp.table_name.Length > 0)
                        data.Add(dp);
                }
            }
            catch { }
            if (data.Count > 0)
            {
                foreach (DBInitDataProfile profile in data)
                {
                    profile.insertAllData();
                }
            }
            return msg;
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="connection_string"></param>
        /// <param name="reference_path"></param>
        /// <returns></returns>
        public static string initialize(string connection_string, string reference_path)
        {
            return initialize(new DBConnection(connection_string), reference_path);
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string initialize(DBConnection connection)
        {
            var ref_path = AppDomain.CurrentDomain.BaseDirectory + "db_initial\\";
            return initialize(connection, ref_path);
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="connection_string"></param>
        /// <returns></returns>
        public static string initialize(string connection_string)
        {
            var ref_path = AppDomain.CurrentDomain.BaseDirectory + "db_initial\\";
            return initialize(new DBConnection(connection_string), ref_path);
        }
    }
}
