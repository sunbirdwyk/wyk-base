using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace wyk.basic
{
    /// <summary>
    /// 权限组基础类
    /// </summary>
    public class PrivilegeGroup
    {
        [JsonIgnore]
        protected string _privilege_content = null;

        /// <summary>
        /// 权限组名称, 需要子类重写
        /// </summary>
        /// <returns></returns>
        public virtual string groupName()
        {
            return "";
        }

        /// <summary>
        /// 变量名(反射自FieldInfo)
        /// </summary>
        [JsonIgnore]
        public string field_name = "";

        [JsonIgnore]
        List<PrivilegeItem> _privilege_items = null;
        public List<PrivilegeItem> privilege_items
        {
            get
            {
                if (_privilege_items == null)
                {
                    _privilege_items = new List<PrivilegeItem>();
                    FieldInfo[] fields = this.GetType().GetFields();
                    foreach (FieldInfo fi in fields)
                    {
                        if (fi.FieldType == typeof(PrivilegeItem))
                        {
                            try
                            {
                                PrivilegeItem item = fi.GetValue(this) as PrivilegeItem;
                                item.field_name = fi.Name;
                                if (supportsTagForAll() != null && item.supported_privilege_tags == null)
                                    item.supported_privilege_tags = supportsTagForAll();
                                privilege_items.Add(item);
                            }
                            catch { }
                        }
                    }
                }
                return _privilege_items;
            }
            set
            {
                _privilege_items = null;
                foreach (var item in value)
                {
                    for (int i = 0; i < privilege_items.Count; i++)
                    {
                        if (privilege_items[i].name == item.name)
                        {
                            privilege_items[i].privilege_level = item.privilege_level;
                            break;
                        }
                    }
                }
            }
        }

        public virtual string[] supportsTagForAll()
        {
            return null;
        }

        /// <summary>
        /// 权限项总数
        /// </summary>
        public int totalItemCount()
        {
            return privilege_items.Count;
        }

        /// <summary>
        /// 最大的权限项序号
        /// </summary>
        private int maxItemIndex()
        {
            int index = 0;
            foreach (PrivilegeItem item in privilege_items)
            {
                if (item.index > index)
                    index = item.index;
            }
            return index;
        }

        /// <summary>
        /// 根据权限项序号获取权限项
        /// </summary>
        /// <param name="index">权限项序号</param>
        /// <returns></returns>
        public PrivilegeItem itemWithIndex(int index)
        {
            foreach (PrivilegeItem item in privilege_items)
            {
                if (item.index == index)
                    return item;
            }
            return null;
        }

        /// <summary>
        /// 根据权限项名获取权限项
        /// </summary>
        /// <param name="name">权限项名</param>
        /// <returns></returns>
        public PrivilegeItem itemWithName(string name)
        {
            foreach (PrivilegeItem item in privilege_items)
            {
                if (item.name == name)
                    return item;
            }
            return null;
        }

        /// <summary>
        /// 根据权限项的变量名获取权限项
        /// </summary>
        /// <param name="field_name">权限项变量名</param>
        /// <returns></returns>
        public PrivilegeItem itemWithFieldName(string field_name)
        {
            foreach (PrivilegeItem item in privilege_items)
            {
                if (item.field_name == field_name)
                    return item;
            }
            return null;
        }

        /// <summary>
        /// 给所有权限项设置值
        /// </summary>
        /// <param name="level"></param>
        public void setAllPriviegeLevel(byte level)
        {
            foreach (PrivilegeItem item in privilege_items)
            {
                item.privilege_level = level;
            }
        }

        /// <summary>
        /// 给所有权限项设置值
        /// </summary>
        /// <param name="level"></param>
        /// <param name="privilege_tag"></param>
        public void setAllPriviegeLevel(byte level, string privilege_tag)
        {
            foreach (PrivilegeItem item in privilege_items)
            {
                if (item.supportsTag(privilege_tag))
                    item.privilege_level = level;
            }
        }

        /// <summary>
        /// 根据index设置level
        /// </summary>
        /// <param name="index"></param>
        /// <param name="level"></param>
        public void setPrivilegeLevel(int index, byte level)
        {
            for (int i = 0; i < privilege_items.Count; i++)
            {
                if (privilege_items[i].index == index)
                {
                    privilege_items[i].privilege_level = level;
                    break;
                }
            }
        }

        /// <summary>
        /// 根据index设置level
        /// </summary>
        /// <param name="index"></param>
        /// <param name="level"></param>
        public void setPrivilegeLevel(int index, char level)
        {
            byte l = 0;
            try
            {
                l = Convert.ToByte(level.ToString());
            }
            catch { }
            setPrivilegeLevel(index, l);
        }

        /// <summary>
        /// 给所有权限项设置最大的权限
        /// </summary>
        public void setAllPrivilegeLevelToHighest()
        {
            setAllPriviegeLevel(9);
        }

        public string privilegeContent()
        {
            if (_privilege_content == null)
            {
                _privilege_content = "";
                for (int i = 1; i <= maxItemIndex(); i++)
                {
                    PrivilegeItem item = itemWithIndex(i);
                    if (item != null)
                        _privilege_content += item.PrivilegeLevel;
                    else
                        _privilege_content += "0";
                }
            }
            return _privilege_content;
        }

        public void setPrivilegeContent(string content)
        {
            if (_privilege_content == content)
                return;
            _privilege_content = content;
            char[] parts = _privilege_content.ToCharArray();
            setAllPriviegeLevel(0);
            for (int i = 0; i < parts.Length; i++)
            {
                setPrivilegeLevel(i + 1, parts[i]);
            }
        }

        /// <summary>
        /// 按Index排序好的支持某个权限标签的权限项集合
        /// </summary>
        /// <param name="privilege_tag"></param>
        /// <returns></returns>
        public List<PrivilegeItem> privilegeItemsForTag(string privilege_tag)
        {
            List<PrivilegeItem> items = new List<PrivilegeItem>();
            foreach (PrivilegeItem item in privilege_items)
            {
                if (item.supportsTag(privilege_tag))
                {
                    int idx = -1;
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].index > item.index)
                        {
                            idx = i;
                            break;
                        }
                    }
                    if (idx >= 0)
                        items.Insert(idx, item);
                    else
                        items.Add(item);
                }
            }
            return items;
        }

        /// <summary>
        /// 将当前组的支持权限项加入权限设置表
        /// </summary>
        /// <param name="table"></param>
        /// <param name="privilege_tag"></param>
        public void addToPrivilegeConfigTable(ref DataTable table, string privilege_tag)
        {
            if (table == null)
                table = new DataTable();
            if (table.Columns.Count != 3)
            {
                table.Columns.Clear();
                table.Columns.Add("权限组");
                table.Columns.Add("权限名");
                table.Columns.Add("权限级别");
            }
            List<PrivilegeItem> items = privilegeItemsForTag(privilege_tag);
            foreach (PrivilegeItem item in items)
            {
                DataRow dr = table.NewRow();
                dr[0] = groupName();
                dr[1] = item.name;
                dr[2] = item.PrivilegeLevelDisplay;
                table.Rows.Add(dr);
            }
        }
    }
}