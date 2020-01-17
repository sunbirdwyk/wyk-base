using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 数据库更新操作基类
    /// </summary>
    [DBVersion(0, 0, 0)]
    public class DBUpdater
    {
        protected DBVersion _db_version = null;
        /// <summary>
        /// 当前数据库版本号
        /// </summary>
        public DBVersion db_version
        {
            get
            {
                if (_db_version == null)
                {
                    _db_version = this.getAttribute<DBVersion>();
                    if (_db_version == null)
                        _db_version = new DBVersion("");
                }
                return _db_version;
            }
        }

        /// <summary>
        /// 判断当前数据库是否需要更新
        /// </summary>
        /// <param name="current_db_version">当前数据库存储的数据库版本号</param>
        /// <returns></returns>
        public bool needsDBUpdate(string current_db_version)
        {
            if (db_version.compare(current_db_version) == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 更新数据库
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="assembly_name">资源库路径, 例如 IMC.Test.DB</param>
        /// <param name="msg">错误信息</param>
        /// <returns>当前更新后的数据库版本号</returns>
        public DBVersion updateDB(DBConnection connection, string assembly_name, ref string msg)
        {
            DBVersion current_db_version = getCurrentDBVersion(connection);
            if (db_version.compare(current_db_version) != 1)
            {//当前最新版本号小于等于数据库版本号, 无需更新
                msg = "当前数据库无需更新!";
                return db_version;
            }
            //获取所有数据库升级描述文件
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load(assembly_name);
            }
            catch
            {
                msg = "无法获取更新描述文件!";
                return db_version;
            }
            Type[] types = assembly.GetTypes();
            List<DBUpdateProfile> update_profiles = new List<DBUpdateProfile>();
            List<DBDataProcess> data_processes = new List<DBDataProcess>();
            //获取描述文件后按照版本号先后顺序排列
            foreach (Type type in types)
            {
                try
                {
                    if (type.BaseType == typeof(DBUpdateProfile))
                    {//数据库更新
                        DBUpdateProfile profile = Activator.CreateInstance(type) as DBUpdateProfile;
                        //过滤掉之前更新过的记录
                        if (!profile.shouldUpdate(current_db_version))
                            continue;
                        int index = -1;
                        for (int i = 0; i < update_profiles.Count; i++)
                        {
                            if (update_profiles[i].start_db_version.compare(profile.start_db_version) == 1)
                            {
                                index = i;
                                break;
                            }
                        }
                        if (index >= 0)
                            update_profiles.Insert(index, profile);
                        else
                            update_profiles.Add(profile);
                    }
                    else if (type.BaseType == typeof(DBDataProcess))
                    {//数据处理操作
                        DBDataProcess process = Activator.CreateInstance(type) as DBDataProcess;
                        //过滤掉之前更新过的记录
                        if (!process.shouldPerformProcess(current_db_version))
                            continue;
                        data_processes.Add(process);
                    }
                }
                catch { }
            }
            //更新数据库
            foreach (DBUpdateProfile profile in update_profiles)
            {
                List<string> sqls = profile.getUpdateSqlList(connection.db_type);
                foreach (var query in sqls)
                    DBQuery.query(query, connection);
                //查找是否有相关的数据更新操作, 有则进行更新
                foreach (DBDataProcess process in data_processes)
                {
                    if (process.start_db_version.compare(profile.start_db_version) == 0)
                    {
                        process.processData(connection);
                    }
                }
            }
            //更新版本号到数据库相关表(需继承后实现)
            msg = updateNewVersionInfoToDB(connection);
            return db_version;
        }

        /// <summary>
        /// 更新数据库
        /// </summary>
        /// <param name="connection_string">数据库连接串</param>
        /// <param name="assembly_name">资源库路径, 例如 IMC.Test.DB</param>
        /// <param name="msg">错误信息</param>
        /// <returns>当前更新后的数据库版本号</returns>
        public DBVersion updateDB(string connection_string, string assembly_name, ref string msg)
        {
            return updateDB(new DBConnection(connection_string), assembly_name, ref msg);
        }

        /// <summary>
        /// 获取当前数据库版本号
        /// 需要继承后实现
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public virtual DBVersion getCurrentDBVersion(DBConnection connection)
        {
            var query = "select param_value from sys_configuration where param_name='current_db_version'";
            DataTable data = DBQuery.query(query, connection);
            string version = "";
            try
            {
                version = data.Rows[0][0].ToString();
            }
            catch { }
            if (version == "")
                version = "1.0.0";
            return new DBVersion(version);
        }

        /// <summary>
        /// 获取当前数据库版本号
        /// </summary>
        /// <param name="connection_string"></param>
        /// <returns></returns>
        public DBVersion getCurrentDBVersion(string connection_string)
        {
            return getCurrentDBVersion(new DBConnection(connection_string));
        }

        /// <summary>
        /// 将新的数据库版本号更新到数据库相关表中, 需继承实现
        /// </summary>
        /// <param name="connection"></param>
        /// <returns>错误信息</returns>
        public virtual string updateNewVersionInfoToDB(DBConnection connection)
        {
            var query = "delete from sys_configuration where param_name='current_db_version'";
            var msg = DBQuery.execute(query, connection);
            if (msg.hasContents())
                return msg;
            query = "insert into sys_configuration (param_name,param_value) values ('current_db_version','" + db_version.db_version + "')";
            return DBQuery.execute(query, connection);
        }
    }
}