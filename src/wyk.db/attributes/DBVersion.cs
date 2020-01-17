using System;

namespace wyk.db
{
    /// <summary>
    /// 数据库更新描述文件信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DBVersion : Attribute
    {
        /// <summary>
        /// 数据库版本号
        /// 格式 X.X.X   (X为正整数)
        /// </summary>
        public string db_version = "";

        public DBVersion(string DBVersion)
        {
            db_version = DBVersion;
        }

        public DBVersion(int v1, int v2, int v3)
        {
            db_version = (v1 >= 0 ? v1 : 0) + "." + (v2 >= 0 ? v2 : 0) + "." + (v3 >= 0 ? v3 : 0);
        }

        /// <summary>
        /// 与其他数据库版本做比较, 相等返回0, 当前版本较小返回-1, 当前版本较大返回1, 格式有误返回-2
        /// </summary>
        /// <param name="db_version">相比较的数据库版本实例</param>
        /// <returns>相等返回0, 当前版本较小返回-1, 当前版本较大返回1, 格式有误返回-2</returns>
        public int compare(DBVersion db_version)
        {
            return compare(db_version.db_version);
        }

        /// <summary>
        /// 与其他数据库版本做比较, 相等返回0, 当前版本较小返回-1, 当前版本较大返回1, 格式有误返回-2
        /// </summary>
        /// <param name="db_version">相比较的数据库版本, 格式 X.X.X (X为正整数)</param>
        /// <returns>相等返回0, 当前版本较小返回-1, 当前版本较大返回1, 格式有误返回-2</returns>
        public int compare(string db_version)
        {
            string[] parts = this.db_version.Split('.');
            if (parts.Length != 3)
                return -2;
            string[] parts2 = db_version.Split('.');
            if (parts2.Length != 3)
                return -2;
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    int ver = Convert.ToInt32(parts[i]);
                    int ver2 = Convert.ToInt32(parts2[i]);
                    if (ver < 0 || ver2 < 0)
                        return -2;
                    if (ver < ver2)
                        return -1;
                    else if (ver > ver2)
                        return 1;
                }
                return 0;
            }
            catch { return -2; }
        }

        /// <summary>
        /// 数据库版本号的数组
        /// </summary>
        public int[] DBVersionArray
        {
            get
            {
                int[] res = new int[] { 0, 0, 0 };
                string[] parts = db_version.Split('.');
                if (parts.Length == 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            res[i] = Convert.ToInt32(parts[i]);
                        }
                        catch { }
                    }
                }
                return res;
            }
            set
            {
                db_version = "";
                if (value.Length == 3)
                    db_version = value[0] + "." + value[1] + "." + value[2];
            }
        }
    }
}
