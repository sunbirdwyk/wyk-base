using Newtonsoft.Json;
using System;
using wyk.basic;

namespace wyk.sms
{
    /// <summary>
    /// 服务器推送返回的信息(每条短信), 内容为接收后的状态
    /// </summary>
    public class SMSResult
    {
        /// <summary>
        /// 运营商返回代码
        /// </summary>
        public string carrier_code = "";
        /// <summary>
        /// 运营商返回代码的解释信息
        /// </summary>
        public string carrier_msg = "";
        /// <summary>
        /// 服务提供商短信ID
        /// </summary>
        public string sid = "";
        /// <summary>
        /// 用户自定义ID
        /// </summary>
        public string uid = "";
        /// <summary>
        /// 短信接收时间
        /// </summary>
        [JsonIgnore]
        public DateTime recieved_time = DateTimeUtil.defaultTime();
        /// <summary>
        /// 接收手机号
        /// </summary>
        public string mobile = "";
        /// <summary>
        /// 状态
        /// </summary>
        public string status = "";
        /// <summary>
        /// 语音验证码等持续的时间
        /// </summary>
        public int duration = 0;

        public bool success
        {
            get => status.ToLower() == "success";
            set
            {
                if (value)
                    status = "SUCCESS";
                else
                    status = "FAIL";
            }
        }

        public string ReceivedTime
        {
            get => recieved_time.toString();
            set => recieved_time = value.datetime();
        }
    }
}
