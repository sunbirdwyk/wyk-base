using Newtonsoft.Json;
using System;

namespace wyk.basic
{
    /* 权限层次,当前设置权限层次为0~9, 0 为最小权限,9为最大权限,当前未用到9
    * 0 - 不可显示,不可做任何操作
    * 1 - 可查看,不可做任何操作
    * 2 - 可查看,可修改,可做操作(设置值等),不可新增,删除
    * 3 - 可查看,可修改,可做操作(设置值等),可新增,不可删除
    * 4 - 可查看,可修改,可做操作(设置值等),可新增,可删除
    * (注:'修改'和'操作'为同一级别)
    */
    public class PrivilegeItem
    {
        /// <summary>
        /// 变量名(反射自FieldInfo)
        /// </summary>
        [JsonIgnore]
        public string field_name = "";
   
        [JsonIgnore]
        public int index = 0;
        public string name = "";
        [JsonIgnore]
        public PrivilegeItemType type = PrivilegeItemType.Usable2;

        /// <summary>
        /// 系统可以对不同的账户类型设置不同的权限列表, 不同账户类型分配不同的TAG, 这里指示哪些TAG可以显示本条目
        /// 如果所有类型都需要显示此条目, 则设置为空
        /// </summary>
        [JsonIgnore]
        public string[] supported_privilege_tags = null;
        [JsonIgnore]
        public byte _privilege_level = 0;
        /// <summary>
        /// 权限项值
        /// </summary>
        public byte privilege_level
        {
            get => _privilege_level;
            set
            {
                if (value < 0 || value > 9)
                    _privilege_level = 0;
                else
                    _privilege_level = value;
            }
        }
        [JsonIgnore]
        /// <summary>
        /// 权限项的字符值
        /// </summary>
        public char PrivilegeLevel
        {
            get => Convert.ToChar(_privilege_level.ToString());
            set
            {
                try
                {
                    privilege_level = Convert.ToByte(value.ToString());
                }
                catch { privilege_level = 0; }
            }
        }
        /// <summary>
        /// 权限项值的显示字符串
        /// </summary>
        public string PrivilegeLevelDisplay
        {
            get
            {
                if (_privilege_level >= nameList.Length)
                    return nameList[nameList.Length - 1];
                try
                {
                    return nameList[_privilege_level];
                }
                catch { }
                return nameList[0];
            }
            set
            {
                privilege_level = 0;
                string[] name_list = nameList;
                for (int i = 0; i < name_list.Length; i++)
                {
                    if (name_list[i].ToLower() == value.ToLower())
                    {
                        privilege_level = Convert.ToByte(i);
                        break;
                    }
                }
            }
        }

        public PrivilegeItem() { }

        public PrivilegeItem(int Index, string Name)
        {
            index = Index;
            name = Name;
        }

        public PrivilegeItem(int Index, string Name, PrivilegeItemType Type)
        {
            index = Index;
            name = Name;
            type = Type;
        }

        public PrivilegeItem(int Index, string Name, PrivilegeItemType Type, string[] SupportedPrivilegeTags)
        {
            index = Index;
            name = Name;
            type = Type;
            supported_privilege_tags = SupportedPrivilegeTags;
        }

        public bool supportsTag(string privilege_tag)
        {
            if (supported_privilege_tags == null || privilege_tag == "")
                return true;
            foreach (string tag in supported_privilege_tags)
            {
                if (tag == privilege_tag)
                    return true;
            }
            return false;
        }

        public bool isUseable
        {
            get { return privilege_level > 0; }
        }

        public bool canEdit
        {
            get { return privilege_level > 1; }
        }

        public bool canAdd
        {
            get { return privilege_level > 2; }
        }

        public bool canDelete
        {
            get { return privilege_level > 3; }
        }

        public string[] nameList
        {
            get
            {
                switch (type)
                {
                    case PrivilegeItemType.Usable2:
                    default:
                        return new string[] { "不可用", "可用" };
                    case PrivilegeItemType.Operation3:
                        return new string[] { "不可用", "查看", "修改" };
                    case PrivilegeItemType.Operation4:
                        return new string[] { "不可用", "查看", "修改", "新增" };
                    case PrivilegeItemType.Operation5:
                        return new string[] { "不可用", "查看", "修改", "新增", "删除" };
                }
            }
        }

        public string highestPrivilegeName
        {
            get { return nameList[nameList.Length - 1]; }
        }
    }
}