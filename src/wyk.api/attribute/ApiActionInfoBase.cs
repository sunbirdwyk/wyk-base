using System;
using System.Text;

namespace wyk.api
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiActionInfoBase : Attribute
    {
        public bool needs_login = false;
        public bool request_log = true;
        public bool response_log = true;
        public string[] allowed_account_type = null;

        public ApiActionInfoBase() { }
        public ApiActionInfoBase(bool needs_login)
        {
            this.needs_login = needs_login;
        }
        public ApiActionInfoBase(string[] allowed_account_type_list)
        {
            this.needs_login = true;
            this.allowed_account_type = allowed_account_type_list;
        }
        public ApiActionInfoBase(bool needs_login, bool log)
        {
            this.needs_login = needs_login;
            this.request_log = log;
            this.response_log = log;
        }

        public ApiActionInfoBase(bool log, string[] allowed_account_type_list)
        {
            this.needs_login = true;
            this.request_log = log;
            this.response_log = log;
            this.allowed_account_type = allowed_account_type_list;
        }

        public ApiActionInfoBase(bool request_log, bool response_log, string[] allowed_account_type_list)
        {
            this.needs_login = true;
            this.request_log = request_log;
            this.response_log = response_log;
            this.allowed_account_type = allowed_account_type_list;
        }

        /// <summary>
        /// 检查是否允许此账户类型访问
        /// </summary>
        /// <param name="account_type_name">账户类型Enum名称</param>
        /// <returns></returns>
        public bool allows(string account_type_name)
        {
            if (allowed_account_type == null || allowed_account_type.Length == 0)
                return true;
            foreach (var acc in allowed_account_type)
            {
                if (acc == account_type_name)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 检查是否允许此账户类型访问
        /// </summary>
        /// <typeparam name="TEnum">账户类型枚举</typeparam>
        /// <param name="account_type">枚举项目名称</param>
        /// <returns></returns>
        public bool allows<TEnum>(TEnum account_type)
        {
            return allows(account_type.ToString());
        }

        /// <summary>
        /// 获取Api的登录信息, 是否需要登录, 允许的账户类型等
        /// </summary>
        /// <returns></returns>
        public string loginInfo()
        {
            if (!needs_login)
                return "无需登录";
            var sb = new StringBuilder();
            sb.Append("需要登录");
            if (allowed_account_type == null || allowed_account_type.Length == 0)
                sb.Append("(所有账户)");
            else
            {
                sb.Append("(");
                sb.Append(string.Join(",", allowed_account_type));
                sb.Append(")");
            }
            return sb.ToString();
        }
    }
}
