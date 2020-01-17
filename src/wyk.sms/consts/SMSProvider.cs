using System.ComponentModel;

namespace wyk.sms
{
    public enum SMSProvider
    {
        [Description("未知")]
        Unknown,
        /// <summary>
        /// 云片 https://www.yunpian.com  
        /// </summary>
        [Description("云片")]
        YunPian,
        /// <summary>
        /// 云片 https://http://www.ipyy.cn
        /// </summary>
        [Description("华信")]
        HuaXin,
    }
}
