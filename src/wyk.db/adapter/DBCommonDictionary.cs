using System.Collections.Generic;

namespace wyk.db
{
    /// <summary>
    /// 下拉框列表字典
    /// </summary>
    public class DBCommonDictionary
    {
        /// <summary>
        /// 变量名(反射自FieldInfo)
        /// </summary>
        public string field_name = "";

        public List<DBCommonDictionaryItem> items = new List<DBCommonDictionaryItem>();

        public DBCommonDictionaryItem get(int id)
        {
            foreach(DBCommonDictionaryItem item in items)
            {
                if (item.id == id)
                    return item;
            }
            return null;
        }

        public DBCommonDictionaryItem get(string content)
        {
            foreach(DBCommonDictionaryItem item in items)
            {
                if (item.content == content)
                    return item;
            }
            return null;
        }
    }
}
