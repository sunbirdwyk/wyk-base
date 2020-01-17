using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using wyk.basic;

namespace wyk.db
{
    public class SequenceDAO
    {
        [JsonIgnore]
        public static DBConnection connection
        {
            get => DBUtil.connection;
        }
        /// <summary>
        /// 为指定日期设置Sequence值
        /// </summary>
        /// <param name="seq_type">类型</param>
        /// <param name="date">日期</param>
        /// <param name="index">值</param>
        /// <returns></returns>
        public static string setIndexForDaily(string seq_type, DateTime date, long index)
        {
            var query = $"update {connection.left_quote}{DBUtil.sequence_table_daily}{connection.right_quote} set record_index={index} where record_date={connection.dateValue(date)} and seq_type='{seq_type}' ";
            return DBQuery.execute(query);
        }

        /// <summary>
        /// 获取下一个指定日期的Sequence值
        /// </summary>
        /// <param name="seq_type">类型</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public static long getNextIndexForDaily(string seq_type, DateTime date)
        {
            switch (connection.db_type)
            {
                case DBType.SqlServer:
                    try
                    {
                        long index = -1;
                        var date_str = connection.dateValue(date);
                        var query = $"update {DBUtil.sequence_table_daily} with(xlock,holdlock) set record_index=(select record_index from{DBUtil.sequence_table_daily} where record_date={date_str} and seq_type='{seq_type}' )+1 where  record_date={date_str} and seq_type='{seq_type}' ";
                        var query2 = $"select record_index from {DBUtil.sequence_table_daily} where  record_date={date_str} and seq_type='{seq_type}' ";
                        using (OleDbConnection conn = new OleDbConnection(DBUtil.connection_string))
                        {
                            conn.Open();
                            OleDbTransaction trans = conn.BeginTransaction();
                            OleDbCommand command = new OleDbCommand(query, conn, trans);
                            try
                            {
                                command.ExecuteNonQuery();
                                command.CommandText = query2;
                                using (OleDbDataReader dataReader = command.ExecuteReader())
                                {
                                    dataReader.Read();
                                    try
                                    {
                                        if (dataReader.IsDBNull(0))
                                            index = -1;
                                        else
                                            index = dataReader.GetInt64(0);
                                    }
                                    catch { }
                                    dataReader.Close();
                                }
                                trans.Commit();
                                conn.Close();
                            }
                            catch
                            {
                                trans.Rollback();
                            }
                        }
                        if (index > 0)
                            return index;
                        query = $"insert into {DBUtil.sequence_table_daily} with (TABLOCKX) (seq_type,record_date,record_index) values ('{seq_type}',{date_str}, 1) ";
                        var msg = DBQuery.execute(query);
                        if (msg.hasContents())
                            return -1;
                        else
                            return 1;
                    }
                    catch { }
                    break;
                case DBType.Access:
                    try
                    {
                        long index = -1;
                        var date_str = connection.dateValue(date);
                        var query = $"update {DBUtil.sequence_table_daily} set record_index=(select record_index from {DBUtil.sequence_table_daily} where record_date={date_str} and seq_type='{seq_type}')+1 where record_date={date_str} and seq_type='{seq_type}' ";
                        var msg = DBQuery.execute(query);
                        if (msg.isNull())
                        {
                            query = $"select record_index from {DBUtil.sequence_table_daily} where record_date={date_str} and seq_type='{seq_type}' ";
                            try
                            {
                                index = Convert.ToInt64(DBQuery.query(query).Rows[0][0]);
                            }
                            catch { }
                        }
                        if (index > 0)
                            return index;
                        query = $"insert into {DBUtil.sequence_table_daily} (seq_type,record_date,record_index) values ('{seq_type}',{date_str}, 1) ";
                        msg = DBQuery.execute(query);
                        if (msg.hasContents())
                            return -1;
                        else
                            return 1;
                    }
                    catch { }
                    break;
                case DBType.MySql:
                    try
                    {
                        long index = -1;
                        var date_str = connection.dateValue(date);
                        var query = $"lock tables {connection.left_quote}{DBUtil.sequence_table_daily}{connection.right_quote} write; update {connection.left_quote}{DBUtil.sequence_table_daily}{connection.right_quote} set record_index=(select record_index from {connection.left_quote}{DBUtil.sequence_table_daily}{connection.right_quote} where record_date={date_str} and seq_type='{seq_type}')+1 where record_date={date_str} and seq_type='{seq_type}'; unlock tables; ";
                        var msg = DBQuery.execute(query);
                        if (msg.isNull())
                        {
                            query = $"select record_index from {connection.left_quote}{DBUtil.sequence_table_daily}{connection.right_quote} where record_date={date_str} and seq_type='{seq_type}' ";
                            try
                            {
                                index = Convert.ToInt64(DBQuery.query(query).Rows[0][0]);
                            }
                            catch { }
                        }
                        if (index > 0)
                            return index;
                        query = $"insert into {connection.left_quote}{DBUtil.sequence_table_daily}{connection.right_quote} (seq_type,record_date,record_index) values ('{seq_type}',{date_str}, 1) ";
                        msg = DBQuery.execute(query);
                        if (msg.hasContents())
                            return -1;
                        else
                            return 1;
                    }
                    catch { }
                    break;
                case DBType.Oracle:
                    try
                    {
                        long index = -1;
                        var date_str = connection.dateValue(date);
                        var query = $"update {DBUtil.sequence_table_daily} set record_index=(select record_index from {DBUtil.sequence_table_daily} where record_date={date_str} and seq_type='{seq_type}' for update)+1 where record_date={date_str} and seq_type='{seq_type}' ";
                        var msg = DBQuery.execute(query);
                        if (msg.isNull())
                        {
                            query = $"select record_index from {DBUtil.sequence_table_daily} where record_date={date_str} and seq_type='{seq_type}' ";
                            try
                            {
                                index = Convert.ToInt64(DBQuery.query(query).Rows[0][0]);
                            }
                            catch { }
                        }
                        if (index > 0)
                            return index;
                        query = $"insert into {DBUtil.sequence_table_daily} (seq_type,record_date,record_index) values ('{seq_type}',{date_str}, 1) ";
                        msg = DBQuery.execute(query);
                        if (msg.hasContents())
                            return -1;
                        else
                            return 1;
                    }
                    catch { }
                    break;
            }
            return -1;
        }

        /// <summary>
        /// 获取当前指定日期的Sequence值
        /// </summary>
        /// <param name="seq_type">类型</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public static long getCurrentIndexForDaily(string seq_type, DateTime date)
        {
            string query =$"select record_index from {connection.left_quote}{DBUtil.sequence_table_daily}{connection.right_quote} where record_date={connection.dateValue(date)} and seq_type='{seq_type}' ";
            try
            {
                return Convert.ToInt64(DBQuery.query(query).Rows[0][0]);
            }
            catch { }
            return 0;
        }

        /// <summary>
        /// 设置全局Sequence值
        /// </summary>
        /// <param name="seq_type">类型</param>
        /// <param name="index">值</param>
        /// <returns></returns>
        public static string setIndexForAll(string seq_type, long index)
        {
            var query = $"update {connection.left_quote}{DBUtil.sequence_table_all}{connection.right_quote} set record_index={index} where seq_type='{seq_type}' ";
            return DBQuery.execute(query);
        }

        /// <summary>
        /// 获取下一个全局Sequence值
        /// </summary>
        /// <param name="seq_type">类型</param>
        /// <returns></returns>
        public static long getNextIndexForAll(string seq_type)
        {
            switch (connection.db_type)
            {
                case DBType.SqlServer:
                    try
                    {
                        long index = -1;
                        var query = $"update {DBUtil.sequence_table_all} with(xlock,holdlock) set record_index=(select record_index from {DBUtil.sequence_table_all} where seq_type='{seq_type}' )+1 where seq_type='{seq_type}' ";
                        var query2 = $"select record_index from {DBUtil.sequence_table_all} where seq_type='{seq_type}' ";
                        using (OleDbConnection conn = new OleDbConnection(DBUtil.connection_string))
                        {
                            conn.Open();
                            OleDbTransaction trans = conn.BeginTransaction();
                            OleDbCommand command = new OleDbCommand(query, conn, trans);
                            try
                            {
                                command.ExecuteNonQuery();
                                command.CommandText = query2;
                                using (OleDbDataReader dataReader = command.ExecuteReader())
                                {
                                    dataReader.Read();
                                    try
                                    {
                                        if (dataReader.IsDBNull(0))
                                            index = -1;
                                        else
                                            index = dataReader.GetInt64(0);
                                    }
                                    catch { }
                                    dataReader.Close();
                                }
                                trans.Commit();
                                conn.Close();
                            }
                            catch
                            {
                                trans.Rollback();
                            }
                        }
                        if (index > 0)
                            return index;
                        query = $"insert into {DBUtil.sequence_table_all} with (TABLOCKX) (seq_type,record_index) values ('{seq_type}', 1) ";
                        var msg = DBQuery.execute(query);
                        if (msg.hasContents())
                            return -1;
                        else
                            return 1;
                    }
                    catch { }
                    break;
                case DBType.Access:
                    try
                    {
                        long index = -1;
                        var query = $"update {DBUtil.sequence_table_all} set record_index=(select record_index from {DBUtil.sequence_table_all} where seq_type='{seq_type}' )+1 where seq_type='{seq_type}' ";
                        var msg = DBQuery.execute(query);
                        if (msg.isNull())
                        {
                            try
                            {
                                query = $"select record_index from {DBUtil.sequence_table_all} where seq_type='{seq_type}' ";
                                index = Convert.ToInt64(DBQuery.query(query).Rows[0][0]);
                            }
                            catch { }
                        }
                        if (index > 0)
                            return index;
                        query = $"insert into {DBUtil.sequence_table_all} (seq_type,record_index) values ('{seq_type}', 1) ";
                        msg = DBQuery.execute(query);
                        if (msg.hasContents())
                            return -1;
                        else
                            return 1;
                    }
                    catch { }
                    break;
                case DBType.MySql:
                    try
                    {
                        long index = -1;
                        var query = $"lock tables {connection.left_quote}{DBUtil.sequence_table_all}{connection.right_quote} write; update {connection.left_quote}{DBUtil.sequence_table_all}{connection.right_quote} set record_index=(select record_index from {connection.left_quote}{DBUtil.sequence_table_all}{connection.right_quote} where seq_type='{seq_type}' )+1 where seq_type='{seq_type}';unlock tables; ";
                        var msg = DBQuery.execute(query);
                        if (msg.isNull())
                        {
                            try
                            {
                                query = $"select record_index from {connection.left_quote}{DBUtil.sequence_table_all}{connection.right_quote} where seq_type='{seq_type}' ";
                                index = Convert.ToInt64(DBQuery.query(query).Rows[0][0]);
                            }
                            catch { }
                        }
                        if (index > 0)
                            return index;
                        query = $"insert into {DBUtil.sequence_table_all} with (TABLOCKX) (seq_type,record_index) values ('{seq_type}', 1) ";
                        msg = DBQuery.execute(query);
                        if (msg.hasContents())
                            return -1;
                        else
                            return 1;
                    }
                    catch { }
                    break;
                case DBType.Oracle:
                    try
                    {
                        long index = -1;
                        var query = $"update {DBUtil.sequence_table_all} set record_index=(select record_index from {DBUtil.sequence_table_all} where seq_type='{seq_type}' for update)+1 where seq_type='{seq_type}' ";
                        var msg = DBQuery.execute(query);
                        if (msg.isNull())
                        {
                            try
                            {
                                query = $"select record_index from {DBUtil.sequence_table_all} where seq_type='{seq_type}' ";
                                index = Convert.ToInt64(DBQuery.query(query).Rows[0][0]);
                            }
                            catch { }
                        }
                        if (index > 0)
                            return index;
                        query = $"insert into {DBUtil.sequence_table_all} (seq_type,record_index) values ('{seq_type}', 1) ";
                        msg = DBQuery.execute(query);
                        if (msg.hasContents())
                            return -1;
                        else
                            return 1;
                    }
                    catch { }
                    break;
            }
            return -1;
        }

        /// <summary>
        /// 获取当前全局Sequence值
        /// </summary>
        /// <param name="seq_type">类型</param>
        /// <returns></returns>
        public static long getCurrentIndexForAll(string seq_type)
        {
            string query = $"select record_index from {connection.left_quote}{DBUtil.sequence_table_all}{connection.right_quote} where seq_type='{seq_type}' ";
            try
            {
                return Convert.ToInt64(DBQuery.query(query).Rows[0][0]);
            }
            catch { }
            return 0;
        }
    }
}