using Newtonsoft.Json;
using System;
using wyk.basic;

namespace wyk.api
{
    /// <summary>
    /// 简易版带有登录信息和权限状态的LoginRecord
    /// </summary>
    public class LoginSessionBase
    {
        /// <summary>
        /// 登录token
        /// </summary>
        public string token = "";
        /// <summary>
        /// sys_account中对应的ID
        /// </summary>
        public int account_id = 0;
        /// <summary>
        /// 用户名, 登录使用的用户名
        /// </summary>
        public string user_name = "";
        /// <summary>
        /// 用户类型 DEV, P, D, M等, 根据不同的系统此处的值不同
        /// </summary>
        public string account_type = "";

        /// <summary>
        /// 登录人的姓名
        /// </summary>
        public string opt_name = "";

        /// <summary>
        /// 登录时间
        /// </summary>
        [JsonIgnore]
        public string login_time = "";
        /// <summary>
        /// 过期时间
        /// </summary>
        [JsonIgnore]
        public DateTime expire_time = DateTimeUtil.defaultTime();
       
        /// <summary>
        /// 对应人员ID, 如account_type为D, 对应c_doctor表的ID, 如果为P,对应c_patient的ID, 其他为0
        /// </summary>
        public int refered_id = 0;
     
        public LoginSessionBase() { }
     
        /// <summary>
        /// 判断当前登录状态是否过期
        /// </summary>
        /// <returns></returns>
        public bool isExpired()
        {
            if (expire_time.isDefault() || expire_time < DateTime.Now)
                return true;
            return false;
        }
    }
}
