using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace wyk.basic
{
    /// <summary>
    /// 权限管理基础类
    /// </summary>
    public class PrivilegeBase
    {
        protected string _privilege_content = null;

        [JsonIgnore]
        public string account_name = "";
        [JsonIgnore]
        List<PrivilegeGroup> _privilege_groups = null;
        [JsonIgnore]
        public List<PrivilegeGroup> privilege_groups
        {
            get
            {
                if (_privilege_groups == null)
                {
                    _privilege_groups = new List<PrivilegeGroup>();
                    FieldInfo[] fields = this.GetType().GetFields();
                    foreach (FieldInfo fi in fields)
                    {
                        if (fi.FieldType.BaseType == typeof(PrivilegeGroup))
                        {
                            try
                            {
                                PrivilegeGroup item = fi.GetValue(this) as PrivilegeGroup;
                                item.field_name = fi.Name;
                                _privilege_groups.Add(item);
                            }
                            catch { }
                        }
                    }
                }
                return _privilege_groups;
            }
        }

        /// <summary>
        /// 根据组名获取权限组
        /// </summary>
        /// <param name="name">权限组名</param>
        /// <returns></returns>
        public PrivilegeGroup groupWithName(string name)
        {
            foreach (PrivilegeGroup group in privilege_groups)
            {
                if (group.groupName() == name)
                    return group;
            }
            return null;
        }

        /// <summary>
        /// 根据权限组变量名获取权限组
        /// </summary>
        /// <param name="field_name">权限组变量名</param>
        /// <returns></returns>
        public PrivilegeGroup groupWithFieldName(string field_name)
        {
            foreach (PrivilegeGroup group in privilege_groups)
            {
                if (group.field_name == field_name)
                    return group;
            }
            return null;
        }

        /// <summary>
        /// 明文形式的权限信息, 用于服务器内部使用登录信息快速获取权限
        /// </summary>
        /// <returns></returns>
        public string privilegeContentPlain()
        {
            string content = "";
            foreach (PrivilegeGroup group in privilege_groups)
            {
                if (content != "")
                    content += Convert.ToChar(29);
                content += group.groupName() + Convert.ToChar(30) + group.privilegeContent();
            }
            return content;
        }

        /// <summary>
        /// 设置明文内容的权限字符串
        /// </summary>
        /// <param name="content"></param>
        public void setPrivilegeContentPlain(string content)
        {
            string[] parts = content.Split(Convert.ToChar(29));
            try
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    string[] subs = parts[i].Split(Convert.ToChar(30));
                    try
                    {
                        PrivilegeGroup group = groupWithName(subs[0]);
                        if (group != null)
                            group.setPrivilegeContent(subs[1]);
                    }
                    catch { }
                }
            }
            catch { }
        }

        /// <summary>
        /// 加密后的权限信息
        /// </summary>
        /// <returns></returns>
        public string privilegeContent()
        {
            if (_privilege_content == null)
            {
                var content = new StringBuilder();
                content.Append(account_name);
                foreach (PrivilegeGroup group in privilege_groups)
                {
                    content.Append(Convert.ToChar(29));
                    content.Append(group.groupName());
                    content.Append(Convert.ToChar(30));
                    content.Append(group.privilegeContent());
                }
                _privilege_content = new AESCryptoBase().encrypt256(content.ToString());
            }
            return _privilege_content;
        }

        /// <summary>
        /// 加密后的权限信息
        /// </summary>
        /// <param name="account_name">当前账号用户名</param>
        /// <returns></returns>
        public string privilegeContent(string account_name)
        {
            this.account_name = account_name;
            return privilegeContent();
        }

        /// <summary>
        /// 读取加密后的权限信息
        /// </summary>
        /// <param name="content"></param>
        public void setPrivilegeContent(string content)
        {
            if (_privilege_content == content)
                return;
            _privilege_content = content;
            string[] parts = new AESCryptoBase().decrypt256(_privilege_content).Split(Convert.ToChar(29));
            try
            {
                account_name = parts[0];
                for (int i = 1; i < parts.Length; i++)
                {
                    string[] subs = parts[i].Split(Convert.ToChar(30));
                    try
                    {
                        var group = groupWithName(subs[0]);
                        if (group != null)
                            group.setPrivilegeContent(subs[1]);
                    }
                    catch { }
                }
            }
            catch { }
        }

        public DataTable privilegeConfigTable()
        {
            return privilegeConfigTable("");
        }

        public DataTable privilegeConfigTable(string privilege_tag)
        {
            var table = new DataTable();
            foreach (var group in privilege_groups)
            {
                group.addToPrivilegeConfigTable(ref table, privilege_tag);
            }
            return table;
        }

        public List<PrivilegeItem> privilegeConfigItems()
        {
            return privilegeConfigItems("");
        }

        public List<PrivilegeItem> privilegeConfigItems(string privilege_tag)
        {
            var list = new List<PrivilegeItem>();
            foreach (var group in privilege_groups)
            {
                List<PrivilegeItem> items;
                if (privilege_tag.hasContents())
                    items = group.privilegeItemsForTag(privilege_tag);
                else
                    items = group.privilege_items;
                foreach (var item in items)
                    list.Add(item);
            }
            return list;
        }

        public void setAllPrivilegeLevel(byte level)
        {
            foreach (PrivilegeGroup group in privilege_groups)
            {
                group.setAllPriviegeLevel(level);
            }
        }

        public void setAllPrivilegeLevel(byte level, string privilege_tag)
        {
            foreach (PrivilegeGroup group in privilege_groups)
            {
                group.setAllPriviegeLevel(level, privilege_tag);
            }
        }

        public void setAllPrivilegeLevelToHighest()
        {
            setAllPrivilegeLevel(9,"");
        }

        public void setAllPrivilegeLevelToHighest(string privilege_tag)
        {
            setAllPrivilegeLevel(9, privilege_tag);
        }
    }
    /*
    public class Privilege : PrivilegeBase
    {
        public PrivilegeGroup_Config config = new PrivilegeGroup_Config();
        public PrivilegeGroup_Function function = new PrivilegeGroup_Function();
        public PrivilegeGroup_UserInfo user_info = new PrivilegeGroup_UserInfo();
       
    }

    public class PrivilegeGroup_Config : PrivilegeGroup
    {
        public PrivilegeItem client_key_mgmt = new PrivilegeItem(1, "Key管理");
        public PrivilegeItem hospital_info = new PrivilegeItem(2, "医院信息", PrivilegeItemType.Operation3);
        public PrivilegeItem drop_down = new PrivilegeItem(3, "下拉框字典", PrivilegeItemType.Operation5);
    }

    public class PrivilegeGroup_Function : PrivilegeGroup
    {
        public PrivilegeItem test_function1 = new PrivilegeItem(1, "testFuncton1");
        public PrivilegeItem test_function2 = new PrivilegeItem(2, "Function2", PrivilegeItemType.Operation3);
        public PrivilegeItem test_function3 = new PrivilegeItem(3, "Function3", PrivilegeItemType.Operation5);
    }

    public class PrivilegeGroup_UserInfo : PrivilegeGroup
    {
        public PrivilegeItem test_userinfo1 = new PrivilegeItem(1, "UserInfo1");
        public PrivilegeItem test_userinfo2 = new PrivilegeItem(2, "UserINfo2", PrivilegeItemType.Operation3);
        public PrivilegeItem test_userInfo3 = new PrivilegeItem(3, "UserInfo3", PrivilegeItemType.Operation5);
    }*/
}