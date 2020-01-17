using Newtonsoft.Json;
using System;

namespace wyk.db
{
    /// <summary>
    /// 数据库连接
    /// 注: 当前统一使用OleDb方式连接
    /// </summary>
    public class DBConnection
    {
        //数据库连接字符串
        string _connection_string = "";

        //数据库相关信息
        DBType _db_type = DBType.Unknown;
        string _server_name = "";
        string _database = "";
        string _user_name = "";
        string _password = "";
        int _port = 0;
        bool _windows_verification = false;

        public DBConnection() { }
        public DBConnection(string connection_string)
        {
            this.connection_string = connection_string;
        }

        /// <summary>
        /// 初始化数据库信息
        /// </summary>
        public void initDBProperties()
        {
            _db_type = DBType.Unknown;
            _server_name = "";
            _database = "";
            _user_name = "";
            _password = "";
            _port = 0;
            _windows_verification = false;
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string connection_string
        {
            get => _connection_string;
            set
            {
                _connection_string = value;
                refreshDBProperties();
            }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DBType db_type
        {
            get => _db_type;
            set
            {
                _db_type = value;
                refreshConnectionString();
            }
        }

        /// <summary>
        /// 服务器名/IP, Access数据库为文件路径
        /// </summary>
        public string server_name
        {
            get => _server_name;
            set
            {
                _server_name = value;
                refreshConnectionString();
            }
        }

        /// <summary>
        /// 数据库名(Access,Oracle此项无用)
        /// </summary>
        public string database
        {
            get => _database;
            set
            {
                _database = value;
                refreshConnectionString();
            }
        }

        /// <summary>
        /// 用户名(Access此项无用)
        /// </summary>
        public string user_name
        {
            get => _user_name;
            set
            {
                _user_name = value;
                refreshConnectionString();
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string password
        {
            get => _password;
            set
            {
                _password = value;
                refreshConnectionString();
            }
        }

        public int port
        {
            get => _port;
            set
            {
                _port = value;
                refreshConnectionString();
            }
        }


        /// <summary>
        /// 是否为Windows验证登录(只有Sql Server 有用)
        /// </summary>
        public bool windows_verification
        {
            get => _windows_verification;
            set
            {
                _windows_verification = value;
                refreshConnectionString();
            }
        }

        /// <summary>
        /// 编写查询语句时, 为了排除列名和表名使用保留字段, 会为表名和列名默认添加上左右引号
        /// 引号内容根据数据库类型的不同而不同, 例如:
        /// SqlServer/Access: []
        /// MySql: ``
        /// </summary>
        [JsonIgnore]
        public string left_quote
        {
            get
            {
                switch (db_type)
                {
                    case DBType.SqlServer:
                    case DBType.Access:
                        return "[";
                    case DBType.MySql:
                        return "`";
                    case DBType.Oracle:
                        return "\"";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 编写查询语句时, 为了排除列名和表名使用保留字段, 会为表名和列名默认添加上左右引号
        /// 引号内容根据数据库类型的不同而不同, 例如:
        /// SqlServer/Access: []
        /// MySql: ``
        /// </summary>
        [JsonIgnore]
        public string right_quote
        {
            get
            {
                switch (db_type)
                {
                    case DBType.SqlServer:
                    case DBType.Access:
                        return "]";
                    case DBType.MySql:
                        return "`";
                    case DBType.Oracle:
                        return "\"";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 各个不同数据库中 distinct语法的内容
        /// SqlServer/Access/MySql: distinct
        /// Oracle: unique
        /// </summary>
        [JsonIgnore]
        public string distinct_sql
        {
            get
            {
                switch (db_type)
                {
                    case DBType.SqlServer:
                    case DBType.Access:
                    case DBType.MySql:
                        return "distinct";
                    case DBType.Oracle:
                        return "unique";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 查询参数格式
        /// </summary>
        /// <param name="col_name"></param>
        /// <returns></returns>
        public string param(string col_name)
        {
            switch (db_type)
            {
                case DBType.SqlServer:
                case DBType.Access:
                case DBType.Oracle:
                    return "?";
                case DBType.MySql:
                    return $"@{col_name}";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 查询xx条记录(起~止)样式(在查询语句前部, 通常用于SqlServer 和 Access)
        /// 注: 由于SqlServer和Access不支持查询记录段, 这里只能查询前x条记录, 当前只有SqlServer和Access使用此函数, 所以, start是无用字段, 为了适应以后的情况, 先暂时保留此字段, 注意自己需要在返回结果中截取
        /// </summary>
        /// <param name="start">起始号(当前为无用字段)</param>
        /// <param name="end">截止号</param>
        /// <returns></returns>
        public string topCountOnStart(int start, int end)
        {
            switch (db_type)
            {
                case DBType.SqlServer:
                case DBType.Access:
                    if (end > 0)
                        return $" top {end} ";
                    return "";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 查询前XX条记录(止)样式(在查询语句前部, 通常用于SqlServer 和 Access)
        /// </summary>
        /// <param name="count">记录数(为0时无作用)</param>
        /// <returns></returns>
        public string topCountOnStart(int count)
        {
            return topCountOnStart(0, count);
        }

        /// <summary>
        /// 查询xx条记录(起~止)样式(在查询语句后部, 通常用于Oracle 和 MySql)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string topCountOnEnd(int start, int end)
        {
            switch (db_type)
            {
                case DBType.MySql:
                    if (start > 0)
                    {
                        if (end > 0)
                            return $" limit {start - 1},{end - start + 1} ";
                        else
                            return $" limit {start - 1},-1 ";
                    }
                    else
                    {
                        if (end > 0)
                            return $" limit {end} ";
                        else
                            return "";
                    }
                case DBType.Oracle:
                    if (start > 0)
                    {
                        if (end > 0)
                            return $" and rownum>={start} and rownum<={end} ";
                        else
                            return $" and rownum>={start} ";
                    }
                    else
                    {
                        if (end > 0)
                            return $" and rownum<={end} ";
                        else
                            return "";
                    }
                default:
                    return "";
            }
        }

        /// <summary>
        /// 查询前XX条记录(止)样式(在查询语句后部, 通常用于Oracle 和 MySql)
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public string topCountOnEnd(int count)
        {
            return topCountOnEnd(0, count);
        }

        public string dateValue(DateTime date)
        {
            switch (db_type)
            {
                case DBType.Access:
                    return $"#{date.ToString("yyyy-MM-dd")}#";
                case DBType.MySql:
                case DBType.SqlServer:
                    return $"cast('{date.ToString("yyyy-MM-dd")}' as datetime)";
                case DBType.Oracle:
                    return $"to_date('{date.ToString("yyyy-MM-dd")}', 'yyyy-mm-dd')";
                default:
                    return "[NO SUPPORT]";
            }
        }

        public string datetimeValue(DateTime datetime)
        {
            switch (db_type)
            {
                case DBType.Access:
                    return $"#{datetime.ToString("yyyy-MM-dd HH:mm:ss")}#";
                case DBType.MySql:
                case DBType.SqlServer:
                    return $"cast('{datetime.ToString("yyyy-MM-dd HH:mm:ss")}' as datetime)";
                case DBType.Oracle:
                    return $"to_date('{datetime.ToString("yyyy-MM-dd HH:mm:ss")}', 'yyyy-mm-dd hh24:mi:ss')";
                default:
                    return "[NO SUPPORT]";
            }
        }

        /// <summary>
        /// 根据连接字符串刷新数据库信息
        /// </summary>
        public void refreshDBProperties()
        {
            initDBProperties();
            string test = _connection_string.ToLower();
            string[] parts = _connection_string.Split(';');
            if (test.IndexOf("provider=") >= 0)
            {//如果符合OleDb的数据库连接串格式
                if (test.IndexOf("microsoft.jet.oledb") >= 0)
                {//Access
                    _db_type = DBType.Access;
                    foreach (string s in parts)
                    {
                        string[] subs = s.Split('=');
                        switch (subs[0].ToLower().Trim())
                        {
                            case "data source":
                                _server_name = subs[1].Trim().Trim('\"').Trim();
                                break;
                            case "database password":
                                _password = subs[1];
                                break;
                        }
                    }
                }
                else if (test.IndexOf("msdaora") >= 0 || test.IndexOf("oraoledb") >= 0)
                {
                    _db_type = DBType.Oracle;
                    foreach (string s in parts)
                    {
                        string[] subs = s.Split('=');
                        switch (subs[0].ToLower().Trim())
                        {
                            case "user id":
                            case "uid":
                                _user_name = subs[1];
                                break;
                            case "password":
                            case "psw":
                            case "pwd":
                                _password = subs[1];
                                break;
                            case "data source":
                            case "server":
                            case "database":
                                _server_name = subs[1];
                                break;
                        }
                    }
                }
                else if (test.IndexOf("sqloledb") >= 0)
                {
                    _db_type = DBType.SqlServer;
                    foreach (string s in parts)
                    {
                        string[] subs = s.Split('=');
                        switch (subs[0].ToLower().Trim())
                        {
                            case "user id":
                            case "uid":
                                _user_name = subs[1];
                                break;
                            case "password":
                            case "psw":
                            case "pwd":
                                _password = subs[1];
                                break;
                            case "data source":
                            case "server":
                                _server_name = subs[1];
                                break;
                            case "initial catalog":
                            case "database":
                                _database = subs[1];
                                break;
                            case "integrated security":
                                if (subs[1].Trim().ToLower() == "true" || subs[1].Trim().ToLower() == "sspi")
                                    _windows_verification = true;
                                else
                                    _windows_verification = false;
                                break;
                        }
                    }
                }
            }
            else
            {//如果非OleDb连接串格式, 尝试使用SqlServer连接串格式转化
                bool maybe_mysql = true;//注: 根据各个字段来判断是否倾向于MySql, 否则倾向于SqlServer

                foreach (string s in parts)
                {
                    string[] subs = s.Split('=');
                    switch (subs[0].ToLower().Trim())
                    {
                        case "user id":
                            _user_name = subs[1];
                            maybe_mysql = false;
                            break;
                        case "uid":
                            _user_name = subs[1];
                            break;
                        case "password":
                        case "psw":
                            _password = subs[1];
                            maybe_mysql = false;
                            break;
                        case "pwd":
                            _password = subs[1];
                            break;
                        case "data source":
                            _server_name = subs[1];
                            maybe_mysql = false;
                            break;
                        case "server":
                            _server_name = subs[1];
                            break;
                        case "initial catalog":
                            _database = subs[1];
                            maybe_mysql = false;
                            break;
                        case "database":
                            _database = subs[1];
                            break;
                        case "persist security info":
                            maybe_mysql = false;
                            break;
                        case "integrated security":
                            maybe_mysql = false;
                            if (subs[1].Trim().ToLower() == "true" || subs[1].Trim().ToLower() == "sspi")
                                _windows_verification = true;
                            else
                                _windows_verification = false;
                            break;
                        case "port":
                            try
                            {
                                port = Convert.ToInt32(subs[1]);
                            }
                            catch { }
                            break;

                    }
                }
                if( _server_name.Trim() != "" && _database.Trim() != "")
                {
                    if (_db_type == DBType.Unknown) //如果数据库类型为未知, 则根据倾向来判断使用哪个数据库
                    {
                        _db_type = maybe_mysql ? DBType.MySql : DBType.SqlServer;
                        refreshConnectionString();
                    }
                }
                else
                {
                    _db_type = DBType.Unknown;
                    _connection_string = "";
                }
            }
        }

        /// <summary>
        /// 根据数据库信息刷新连接字符串
        /// </summary>
        public void refreshConnectionString()
        {
            switch (_db_type)
            {
                case DBType.Access:
                    if (_password == "")
                        _connection_string = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{_server_name}\";";
                    else
                        _connection_string = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{_server_name}\";Persist Security Info=True;User ID=Admin;Jet OLEDB:Database Password={_password};";
                    break;
                case DBType.Oracle:
                    _connection_string = $"Provider=MSDAORA.1;Persist Security Info=True;User ID={_user_name};Password={_password};Data Source={_server_name};";
                    break;
                case DBType.SqlServer:
                    var auth_part = _windows_verification ? "Integrated Security=SSPI;" : $"User ID={_user_name};Password={_password};";
                    _connection_string = $"Provider=SQLOLEDB;Data Source={_server_name};Initial Catalog={_database};Persist Security Info=True;{auth_part}";
                    break;
                case DBType.MySql:
                    var port_part = port != 0 ? $"Port={port};" : "";
                    _connection_string = $"Server={_server_name};{port_part}Database={_database};Uid={_user_name};Pwd={_password};";
                    break;
                default:
                    _connection_string = "";
                    break;
            }
        }

        /// <summary>
        /// 获取用于连接SqlServer的数据库连接串
        /// </summary>
        public string SqlServerConnectionString
        {
            get
            {
                if (_db_type != DBType.SqlServer)
                    return "";
                string sqlserver_conn = "";
                sqlserver_conn += "Data Source=" + _server_name + ";Initial Catalog=" + _database + ";Persist Security Info=True;";
                if (_windows_verification)
                    sqlserver_conn += "Integrated Security=SSPI;";
                else
                    sqlserver_conn += "User ID=" + _user_name + ";Password=" + _password + ";";
                return sqlserver_conn;
            }
            set
            {
                _db_type = DBType.SqlServer;
                string[] parts = connection_string.Split(';');
                foreach (string s in parts)
                {
                    string[] subs = s.Split('=');
                    if (subs[0].ToLower().Trim() == "user id" || subs[0].ToLower().Trim() == "uid")
                    {
                        _user_name = subs[1];
                    }
                    if (subs[0].ToLower().Trim() == "password" || subs[0].ToLower().Trim() == "psw" || subs[0].ToLower().Trim() == "pwd")
                    {
                        _password = subs[1];
                    }
                    if (subs[0].ToLower().Trim() == "data source" || subs[0].ToLower().Trim() == "server")
                    {
                        _server_name = subs[1];
                    }
                    if (subs[0].ToLower().Trim() == "initial catalog" || subs[0].ToLower().Trim() == "database")
                    {
                        _database = subs[1];
                    }
                    if (subs[0].ToLower().Trim() == "integrated security")
                    {
                        if (subs[1].Trim().ToLower() == "true" || subs[1].Trim().ToLower() == "sspi")
                            _windows_verification = true;
                        else
                            _windows_verification = false;
                    }
                }
            }
        }
    }
}
