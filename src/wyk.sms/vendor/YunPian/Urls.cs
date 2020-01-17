namespace wyk.sms.vendor.YunPian
{
    public class Urls
    {
        const string SERVER_URL = "https://sms.yunpian.com";
        const string VERSION = "v2";
        const string METHOD_SMS_SINGLE = "sms/single_send.json";
        const string METHOD_SMS_LIST = "sms/batch_send.json";
        const string METHOD_SMS_TEMP_SINGLE = "sms/tpl_single_send.json";
        const string METHOD_SMS_TEMP_LIST = "sms/tpl_batch_send.json";
        const string METHOD_AUTHCODE_VOICE = "voice/send.json";

        public static string urlSMSSingle()
        {
            return url(SERVER_URL, VERSION, METHOD_SMS_SINGLE);
        }

        public static string urlSMSList()
        {
            return url(SERVER_URL, VERSION, METHOD_SMS_LIST);
        }

        public static string urlSMSTemplateSingle()
        {
            return url(SERVER_URL, VERSION, METHOD_SMS_TEMP_SINGLE);
        }

        public static string urlSMSTemplateList()
        {
            return url(SERVER_URL, VERSION, METHOD_SMS_TEMP_LIST);
        }

        public static string urlAuthCodeVoice()
        {
            return url(SERVER_URL, VERSION, METHOD_AUTHCODE_VOICE);
        }

        public static string url(string server, string version, string method)
        {
            return string.Format("{0}/{1}/{2}", server, version, method);
        }
    }
}
