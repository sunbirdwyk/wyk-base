using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;

namespace wyk.db
{
    /// <summary>
    /// SqlServer功能单元
    /// </summary>
    public class SqlServerUtil
    {
        [DllImport("odbc32.dll")]
        private static extern short SQLAllocHandle(short hType, IntPtr inputHandle, out IntPtr outputHandle);
        [DllImport("odbc32.dll")]
        private static extern short SQLSetEnvAttr(IntPtr henv, int attribute, IntPtr valuePtr, int strLength);
        [DllImport("odbc32.dll")]
        private static extern short SQLFreeHandle(short hType, IntPtr handle);
        [DllImport("odbc32.dll", CharSet = CharSet.Ansi)]
        private static extern short SQLBrowseConnect(IntPtr hconn, StringBuilder inString,
        short inStringLength, StringBuilder outString, short outStringLength,
        out short outLengthNeeded);

        private const short SQL_HANDLE_ENV = 1;
        private const short SQL_HANDLE_DBC = 2;
        private const int SQL_ATTR_ODBC_VERSION = 200;
        private const int SQL_OV_ODBC3 = 3;
        private const short SQL_SUCCESS = 0;

        private const short SQL_NEED_DATA = 99;
        private const short DEFAULT_RESULT_SIZE = 1024;
        private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";

        private SqlServerUtil() { }

        /// <summary>
        /// 获取当前可用SqlServer数据库服务器列表
        /// </summary>
        /// <returns></returns>
        public static string[] getServers()
        {
            DataTable dataSources = SqlClientFactory.Instance.CreateDataSourceEnumerator().GetDataSources();

            DataColumn column = dataSources.Columns["InstanceName"];
            DataColumn column2 = dataSources.Columns["ServerName"];

            DataRowCollection rows = dataSources.Rows;
            ArrayList list = new ArrayList();
            string server = string.Empty;
            for (int i = 0; i < rows.Count; i++)
            {
                string str2 = rows[i][column2] as string;
                string str = rows[i][column] as string;
                if (((str == null) || (str.Length == 0)) || ("MSSQLSERVER" == str))
                {
                    server = str2;
                }
                else
                {
                    server = str2 + @"/" + str;
                }
                list.Add(server);
            }
            return list.ToArray(typeof(string)) as string[];
            #region old method
            /*
            errorMessage = "";
            string[] retval = null;
            string txt = string.Empty;
            IntPtr henv = IntPtr.Zero;
            IntPtr hconn = IntPtr.Zero;
            StringBuilder inString = new StringBuilder(SQL_DRIVER_STR);
            StringBuilder outString = new StringBuilder(DEFAULT_RESULT_SIZE);
            short inStringLength = (short)inString.Length;
            short lenNeeded = 0;

            try
            {
                if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_ENV, henv, out henv))
                {
                    if (SQL_SUCCESS == SQLSetEnvAttr(henv, SQL_ATTR_ODBC_VERSION, (IntPtr)SQL_OV_ODBC3, 0))
                    {
                        if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_DBC, henv, out hconn))
                        {
                            if (SQL_NEED_DATA == SQLBrowseConnect(hconn, inString, inStringLength, outString,
                            DEFAULT_RESULT_SIZE, out lenNeeded))
                            {
                                if (DEFAULT_RESULT_SIZE < lenNeeded)
                                {
                                    outString.Capacity = lenNeeded;
                                    if (SQL_NEED_DATA != SQLBrowseConnect(hconn, inString, inStringLength, outString,
                                    lenNeeded, out lenNeeded))
                                    {
                                        throw new ApplicationException("Unabled to aquire SQL Servers from ODBC driver.");
                                    }
                                }
                                txt = outString.ToString();
                                int start = txt.IndexOf("{") + 1;
                                int len = txt.IndexOf("}") - start;
                                if ((start > 0) && (len > 0))
                                {
                                    txt = txt.Substring(start, len);
                                }
                                else
                                {
                                    txt = string.Empty;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Throw away any error if we are not in debug mode
                errorMessage = ex.ToString();
                txt = string.Empty;
            }
            finally
            {
                if (hconn != IntPtr.Zero)
                {
                    SQLFreeHandle(SQL_HANDLE_DBC, hconn);
                }
                if (henv != IntPtr.Zero)
                {
                    SQLFreeHandle(SQL_HANDLE_ENV, hconn);
                }
            }

            if (txt.Length > 0)
            {
                retval = txt.Split(",".ToCharArray());
            }

            return retval;
            */
            #endregion
        }

        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string[] getDatabases(DBConnection connection)
        {
            ArrayList list = new ArrayList();
            var query = "select name from sys.databases where database_id > 4";
            SqlConnection conn = new SqlConnection(connection.SqlServerConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    IDataReader dr = cmd.ExecuteReader();
                    list.Clear();
                    while (dr.Read())
                    {
                        list.Add(dr["name"].ToString());
                    }
                    dr.Close();
                }

            }
            catch { }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Dispose();
                }
            }
            return list.ToArray(typeof(string)) as string[];
        }

        /// <summary>
        /// 获取数据表列表
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string[] getTables(DBConnection connection)
        {
            ArrayList list = new ArrayList();
            SqlConnection conn = new SqlConnection(connection.SqlServerConnectionString);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    DataTable data = conn.GetSchema("Tables");
                    foreach (DataRow row in data.Rows)
                    {
                        list.Add(row[2].ToString());
                    }
                }
            }
            catch { }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.Dispose();
                }

            }
            return list.ToArray(typeof(string)) as string[];
        }

        /// <summary>
        /// 获取列列表
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string[] getColumns(string table_name ,DBConnection connection)
        {
            ArrayList list = new ArrayList();
            SqlConnection conn = new SqlConnection(connection.SqlServerConnectionString);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("Select Name FROM SysColumns Where id=Object_Id('" + table_name + "')", conn);
                SqlDataReader objReader = cmd.ExecuteReader();
                while (objReader.Read())
                {
                    list.Add(objReader[0].ToString());

                }
            }
            catch { }
            conn.Close();
            return list.ToArray(typeof(string)) as string[];
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="database_name">要备份的数据源名称</param>
        /// <param name="backup_to_folderpath">备份到的数据库文件名称及路径</param>
        /// <param name="backup_name">备份文件名</param>
        /// <param name="connection">连接串</param>
        /// <returns></returns>
        public static string backupDataBase(string database_name, string backup_to_folderpath, string backup_name, DBConnection connection)
        {
            string name = backup_name + DateTime.Now.ToString("_yyyyMMdd_HHmmss");
            string sql;
            SqlConnection conn = new SqlConnection(connection.SqlServerConnectionString);
            conn.Open();        //打开数据库连接
            string backuppath = backup_to_folderpath.Trim('\\').Trim('/') + "\\" + name + ".bak";
            //备份数据库到指定的数据库文件(完全备份)
            sql = "BACKUP DATABASE " + database_name + "  TO  DISK = N'" + backuppath + "'  WITH INIT ";
            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                string str = err.Message;
                conn.Close();
                return str;
            }
            conn.Close();//关闭数据库连接
            return "";
        }

        /// <summary>
        /// 还原指定的数据库文件
        /// </summary>
        /// <param name="database_name">要还原的数据库</param>
        /// <param name="database_file">数据库备份文件及路径</param>
        /// <param name="connection">连接串</param>
        /// <returns></returns>
        public static string restoreDataBase(string database_name, string database_file, DBConnection connection)
        {
            //还原指定的数据库文件
            string sql = "RESTORE DATABASE " + database_name + " from DISK = '" + database_file + "' ";
            SqlConnection conn = new SqlConnection(connection.SqlServerConnectionString);
            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.CommandType = CommandType.Text;
            conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                string str = err.Message;
                conn.Close();
                return str;
            }
            conn.Close();//关闭数据库连接
            return "";
        }
    }
}