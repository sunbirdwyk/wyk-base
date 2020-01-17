using System;

namespace wyk.db
{
    /// <summary>
    /// SqlServer 数据库信息
    /// </summary>
    public class SqlServerInfo
    {
        public string product_name = "";
        public string product_version = "";
        public string edition = "";
        public string product_level = "";
        public string server_name = "";
        public string instance_name = "";

        public int getMainProductVersion()
        {
            try
            {
                return Convert.ToInt32(product_version.Split('.')[0]);
            }
            catch { }
            return 0;
        }
    }
}
