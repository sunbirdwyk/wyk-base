using System.Collections.Generic;

namespace wyk.db
{
    public class DBQueryParamList
    {
        private List<DBQueryParam> _pm_list;

        public List<DBQueryParam> pm_list
        {
            get
            {
                if (_pm_list == null)
                    _pm_list = new List<DBQueryParam>();
                return _pm_list;
            }
            set => _pm_list = value;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <returns></returns>
        public static DBQueryParamList create()
        {
            return new DBQueryParamList();
        }

        /// <summary>
        /// 添加查询参数, 如果参数不可用, 不添加, 如果查询参数重复则覆盖
        /// </summary>
        /// <param name="pm"></param>
        /// <returns></returns>
        public DBQueryParamList add(DBQueryParam pm)
        {
            if (pm == null)
                return this;
            if (!pm.isAvailable())
                return this;
            int index = -1;
            for(int i = 0; i < pm_list.Count; i++)
            {
                if(pm_list[i].column.name == pm.column.name)
                {
                    index = i;
                    break;
                }
            }
            if (index >= 0)
                pm_list[index] = pm;
            else
                pm_list.Add(pm);
            return this;
        }

        /// <summary>
        /// 查询参数数量
        /// </summary>
        public int count
        {
            get
            {
                return pm_list.Count;
            }
        }

        /// <summary>
        /// 清空查询参数列表
        /// </summary>
        /// <returns></returns>
        public DBQueryParamList clear()
        {
            pm_list = new List<DBQueryParam>();
            return this;
        }

        /// <summary>
        /// 从列表中删除某个参数
        /// </summary>
        /// <param name="pm"></param>
        /// <returns></returns>
        public DBQueryParamList delete(DBQueryParam pm)
        {
            return delete(pm.column.name);
        }

        /// <summary>
        /// 从列表中删除某个参数
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public DBQueryParamList delete(DBColumn column)
        {
            return delete(column.name);
        }

        /// <summary>
        /// 从列表中删除某个参数
        /// </summary>
        /// <param name="column_name"></param>
        /// <returns></returns>
        public DBQueryParamList delete(string column_name)
        {
            for(int i = 0; i < pm_list.Count; i++)
            {
                if(pm_list[i].column.name == column_name)
                {
                    pm_list.RemoveAt(i);
                    break;
                }
            }
            return this;
        }
    }
}