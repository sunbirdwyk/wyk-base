using System.Collections.Generic;
using System.Configuration;
using wyk.basic;

namespace wyk.sms
{
    public class SMSManager
    {
        public static SMSProvider provider = SMSProvider.YunPian;
        public static SMSUnit unit = null;

        public static void load()
        {
            var provider = "";
            var key = "";
            var secret = "";
            var sign = "";
            try
            {
                provider = ConfigurationManager.AppSettings["sms_provider"];
            }
            catch { }
            try
            {
                key = ConfigurationManager.AppSettings["sms_key"];
            }
            catch { }
            try
            {
                secret = ConfigurationManager.AppSettings["sms_secret"];
            }
            catch { }
            try
            {
                sign = ConfigurationManager.AppSettings["sms_sign"];
            }
            catch { }
            init(provider, key, secret, sign);
        }

        public static void init(SMSProvider provider, string service_key, string service_secret, string sign)
        {
            SMSManager.provider = provider;
            if (service_key.isNull())
            {
                unit = null;
                return;
            }
            switch (provider)
            {
                case SMSProvider.YunPian:
                    if (unit == null || unit.provider != SMSProvider.YunPian)
                        unit = new vendor.YunPian.SMSUnit_YunPian(service_key, sign);
                    else
                    {
                        unit.service_key = service_key;
                        unit.sign = sign;
                    }
                    break;
                case SMSProvider.HuaXin:
                    if (unit == null || unit.provider != SMSProvider.HuaXin)
                        unit = new vendor.HuaXin.SMSUnit_HuaXin(service_key, service_secret, sign);
                    else
                    {
                        unit.service_key = service_key;
                        unit.service_secret = service_secret;
                        unit.sign = sign;
                    }
                    break;
                default:
                    unit = null;
                    break;
            }
        }

        public static void init(string provider, string service_key, string service_secret, string sign)
        {
            init(provider.enumFromName<SMSProvider>(), service_key, service_secret, sign);
        }

        /// <summary>
        /// 发送单条短信
        /// </summary>
        /// <param name="content">短信内容</param>
        /// <param name="mobile">目标手机号</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <returns>发送结果</returns>
        public static SMSResponse send(string content, string mobile, string rid, bool filter_nonnumber)
        {
            if (unit == null)
                return SMSResponse.errorNotInitialized();
            return unit.send(content, mobile, rid, filter_nonnumber);
        }

        /// <summary>
        /// 发送同内容的多条短信
        /// </summary>
        /// <param name="content">短信内容</param>
        /// <param name="mobile_list">目标手机号列表</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <returns>发送结果</returns>
        public static SMSResponseList send(string content, List<string> mobile_list, string rid, bool filter_nonnumber)
        {
            if (unit == null)
                return SMSResponseList.errorNotInitialized();
            return unit.send(content, mobile_list, rid, filter_nonnumber);
        }

        /// <summary>
        /// 发送单条模板短信
        /// </summary>
        /// <param name="template_id">模板ID</param>
        /// <param name="pm">模板参数</param>
        /// <param name="mobile">目标手机号</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <returns>发送结果</returns>
        public static SMSResponse sendTemplate(long template_id, Dictionary<string, string> pm, string mobile, string rid, bool filter_nonnumber)
        {
            if (unit == null)
                return SMSResponse.errorNotInitialized();
            return unit.sendTemplate(template_id, pm, mobile, rid, filter_nonnumber);
        }

        /// <summary>
        /// 发送同内容的多条短信
        /// </summary>
        /// <param name="template_id">模板ID</param>
        /// <param name="pm">模板参数</param>
        /// <param name="mobile_list">目标手机号列表</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <returns>发送结果</returns>
        public static SMSResponseList sendTemplate(long template_id, Dictionary<string, string> pm, List<string> mobile_list, string rid, bool filter_nonnumber)
        {
            if (unit == null)
                return SMSResponseList.errorNotInitialized();
            return unit.sendTemplate(template_id, pm, mobile_list, rid, filter_nonnumber);
        }

        /// <summary>
        /// 发送语音验证码
        /// </summary>
        /// <param name="auth_code">验证码, 一般为4~6位数字</param>
        /// <param name="mobile">目标手机号</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <returns>发送结果</returns>
        public static SMSResponse sendVoiceAuth(string auth_code, string mobile, string rid, bool filter_nonnumber)
        {
            if (unit == null)
                return SMSResponse.errorNotInitialized();
            return unit.sendVoiceAuth(auth_code, mobile, rid, filter_nonnumber);
        }
    }
}