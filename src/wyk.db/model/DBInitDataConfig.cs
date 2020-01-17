using System;
using wyk.basic;

namespace wyk.db
{
    public class DBInitDataConfig : AppConfigBase
    {
        [AppConfigProperty]
        public string current_db_version = "";
        [AppConfigProperty]
        public string configuration_table_name = "sys_configuration";
        [AppConfigProperty]
        public string configuration_key_column = "param_name";
        [AppConfigProperty]
        public string configuration_value_column = "param_value";
        [AppConfigProperty]
        public string configuration_db_version_key = "current_db_version";

        public string CurrentDBVersion
        {
            get
            {
                if (current_db_version == "")
                    return "1.0.0";
                return current_db_version;
            }
            set
            {
                string[] parts = value.Split('.');
                int v1 = 1;
                int v2 = 0;
                int v3 = 0;
                try
                {
                    v1 = Convert.ToInt32(parts[0]);
                }
                catch { }
                try
                {
                    v2 = Convert.ToInt32(parts[1]);
                }
                catch { }
                try
                {
                    v3 = Convert.ToInt32(parts[2]);
                }
                catch { }
                if (v1 <= 0)
                    v1 = 1;
                if (v2 < 0)
                    v2 = 0;
                if (v3 < 0)
                    v3 = 0;
                current_db_version = v1 + "." + v2 + "." + v3;
            }
        }

        protected override string configFileName()
        {
            return "tables.config";
        }

        private string configPath(string root_folder)
        {
            return root_folder.Trim().Trim('\\').Trim('/') + "\\" + configFileName();
        }

        /// <summary>
        /// 从指定根目录加载配置文件
        /// </summary>
        /// <param name="root_folder">配置文件根目录</param>
        /// <returns></returns>
        public string loadFrom(string root_folder)
        {
            return load(configPath(root_folder));
        }

        /// <summary>
        /// 将配置文件保存到指定根目录
        /// </summary>
        /// <param name="root_folder">配置文件根目录</param>
        /// <returns></returns>
        public string saveTo(string root_folder)
        {
            return save(configPath(root_folder));
        }
    }
}
