using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 数据库更新时要进行的程序运行操作
    /// </summary>
    [DBVersion(0, 0, 0)]
    public class DBDataProcess
    {
        protected DBVersion _start_db_version = null;
        /// <summary>
        /// 起始数据库版本号
        /// </summary>
        public DBVersion start_db_version
        {
            get
            {
                if (_start_db_version == null)
                {
                    _start_db_version = this.getAttribute<DBVersion>();
                    if (_start_db_version == null)
                        _start_db_version = new DBVersion("");
                }
                return _start_db_version;
            }
        }

        /// <summary>
        /// 通过当前数据库版本号判断是否需要执行本数据处理
        /// </summary>
        /// <param name="current_db_version"></param>
        /// <returns></returns>
        public bool shouldPerformProcess(string current_db_version)
        {
            if (start_db_version.compare(current_db_version) == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 通过当前数据库版本号判断是否需要执行本数据处理
        /// </summary>
        /// <param name="current_db_version"></param>
        /// <returns></returns>
        public bool shouldPerformProcess(DBVersion current_db_version)
        {
            return shouldPerformProcess(current_db_version.db_version);
        }

        /// <summary>
        /// 数据处理操作, 需要继承后实现
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public virtual void processData(DBConnection connection)
        {

        }
    }
}
