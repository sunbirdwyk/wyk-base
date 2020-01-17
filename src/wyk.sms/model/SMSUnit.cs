using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using wyk.basic;

namespace wyk.sms
{
    /// <summary>
    /// 发送短信的基本类
    /// </summary>
    public class SMSUnit
    {
        public string service_key = "";
        public string service_secret = "";
        public SMSProvider provider = SMSProvider.Unknown;
        public string sign = "";//短信签名
        public SMSUnit(string service_key, string sign)
        {
            this.service_key = service_key;
            this.sign = sign;
            if (this.sign.isNull())
                this.sign = "金达中慧";
        }

        public SMSUnit(string user_name, string password, string sign)
        {
            service_key = user_name;
            service_secret = password;
            this.sign = sign;
            if (this.sign.isNull())
                this.sign = "金达中慧";
        }

        /// <summary>
        /// 发送单条短信
        /// </summary>
        /// <param name="content">短信内容</param>
        /// <param name="mobile">目标手机号</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <param name="filter_nonnumber">是否过滤手机号中包含的非数字字符</param>
        /// <returns>发送结果</returns>
        public virtual SMSResponse send(string content, string mobile, string rid, bool filter_nonnumber)
        {
            return SMSResponse.errorNotSupported();
        }

        /// <summary>
        /// 发送同内容的多条短信
        /// </summary>
        /// <param name="content">短信内容</param>
        /// <param name="mobile_list">目标手机号列表</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <param name="filter_nonnumber">是否过滤手机号中包含的非数字字符</param>
        /// <returns>发送结果</returns>
        public virtual SMSResponseList send(string content, List<string> mobile_list, string rid, bool filter_nonnumber)
        {
            return SMSResponseList.errorNotSupported();
        }

        /// <summary>
        /// 发送单条模板短信
        /// </summary>
        /// <param name="template_id">模板ID</param>
        /// <param name="pm">模板参数</param>
        /// <param name="mobile">目标手机号</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <param name="filter_nonnumber">是否过滤手机号中包含的非数字字符</param>
        /// <returns>发送结果</returns>
        public virtual SMSResponse sendTemplate(long template_id, Dictionary<string, string> pm, string mobile, string rid, bool filter_nonnumber)
        {
            return SMSResponse.errorNotSupported();
        }

        /// <summary>
        /// 发送同内容的多条短信
        /// </summary>
        /// <param name="template_id">模板ID</param>
        /// <param name="pm">模板参数</param>
        /// <param name="mobile_list">目标手机号列表</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <param name="filter_nonnumber">是否过滤手机号中包含的非数字字符</param>
        /// <returns>发送结果</returns>
        public virtual SMSResponseList sendTemplate(long template_id, Dictionary<string, string> pm, List<string> mobile_list, string rid, bool filter_nonnumber)
        {
            return SMSResponseList.errorNotSupported();
        }

        /// <summary>
        /// 发送语音验证码
        /// </summary>
        /// <param name="auth_code">验证码, 一般为4~6位数字</param>
        /// <param name="mobile">目标手机号</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <param name="filter_nonnumber">是否过滤手机号中包含的非数字字符</param>
        /// <returns>发送结果</returns>
        public virtual SMSResponse sendVoiceAuth(string auth_code, string mobile, string rid, bool filter_nonnumber)
        {
            return SMSResponse.errorNotSupported();
        }

        /// <summary>
        /// 将返回结果转换为SMSResult
        /// </summary>
        /// <param name="content">返回结果(string)</param>
        /// <returns></returns>
        public virtual SMSResult resultByContent(string content)
        {
            return null;
        }

        /// <summary>
        /// 将返回结果的JsonObject转换为SMSResult
        /// </summary>
        /// <param name="obj">返回结果(JObject)</param>
        /// <returns></returns>
        public virtual SMSResult resultByContent(JObject obj)
        {
            return null;
        }
    }
}
