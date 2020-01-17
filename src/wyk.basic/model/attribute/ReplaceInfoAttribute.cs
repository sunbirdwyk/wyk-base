using System;

namespace wyk.basic
{
    /// <summary>
    /// 报告等显示内容设置的替换字段标志
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ReplaceInfoAttribute : Attribute
    {
        /// <summary>
        /// 替换字段名(设置时不包含{})
        /// </summary>
        public string name = "";
        /// <summary>
        /// 替换字段说明(选填)
        /// </summary>
        public string description = "";

        /// <summary>
        /// 替换值
        /// </summary>
        public object value = null;

        /// <summary>
        /// 同一个字段赋多个替换名字时使用
        /// </summary>
        public string[] multiple_names = null;

        private string _replace_name = null;
        public string replace_name
        {
            get
            {
                if(_replace_name==null)
                {
                    if (name.StartsWith("${"))
                        _replace_name = name;
                    else
                        _replace_name = "{" + name + "}";
                }
                return _replace_name;
            }
        }

        public ReplaceInfoAttribute(string name)
        {
            this.name = name;
        }

        public ReplaceInfoAttribute(string[] names)
        {
            multiple_names = names;
            if (multiple_names != null && multiple_names.Length > 0)
                name = multiple_names[0];
        }

        public ReplaceInfoAttribute(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public ReplaceInfoAttribute(string name, string description, object value)
        {
            this.name = name;
            this.description = description;
            this.value = value;
        }
    }
}