using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;

namespace wyk.basic
{
    /// <summary>
    /// 应用程序信息类, 供Updater更新时使用
    /// 记录了应用程序的代码, 访问方式, 更新方式, 版本号等信息
    /// </summary>
    public class ApplicationInfo
    {
        [JsonIgnore]
        public const string APP_CODE_UPDATER = "Updater";
        [JsonIgnore]
        public const string APP_NAME_UPDATER = "程序更新";

        public string code = "";
        public string name = "";
        [JsonIgnore]
        string _current_version = "";
        [JsonIgnore]
        public string current_version
        {
            get
            {
                if (_current_version.isNull())
                    _current_version = "1.0.0";
                return _current_version;
            }
            set => _current_version = value;
        }
        [JsonIgnore]
        public string new_version = "";
        [JsonIgnore]
        public Image image = null;
        public string server_url = "";
        [JsonIgnore]
        string _execute = "";
        public string execute {
            get => _execute;
            set
            {
                _execute = value;
                _execute_path = null;
            }
        }
        [JsonIgnore]
        string _execute_path = null;
        [JsonIgnore]
        public string execute_path
        {
            get
            {
                if (_execute_path == null)
                    _execute_path = AppDomain.CurrentDomain.BaseDirectory + execute;
                return _execute_path;
            }
        }
        
        public ApplicationInfo() { }

        public bool available()
        {
            if (code.isNull())
                return false;
            if (name.isNull())
                return false;
            if (server_url.isNull())
                return false;
            if (execute.isNull()||!execute.Trim().ToLower().EndsWith(".exe"))
                return false;
            if (!File.Exists(execute_path))
                return false;
            return true;
        }

        public bool isUpToDate()
        {
            if (new_version.isNull())
                return true;
            var compare = CommonUtil.versionCompare(current_version, new_version);
            if (compare < 0)
                return false;
            return true;
        }
    }
}
