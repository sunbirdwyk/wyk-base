namespace wyk.sms.vendor.HuaXin
{
    public class Urls
    {
        const string SERVER_URL = "https://dx.ipyy.net";
        const string METHOD_SMS = "sms.aspx";
        const string METHOD_SMS_GBK = "smsGBK.aspx";
        const string METHOD_SMS_JSON = "smsJson.aspx";
        const string METHOD_SMS_ENCODED = "ensms.ashx";
        const string URL_VOICE_AUTH = "http://yypt.51nche.com/voice/smscode/send.do";
        /// <summary>
        /// 对应UTF-8
        /// </summary>
        /// <returns></returns>
        public static string urlSMS()
        {
            return url(SERVER_URL, METHOD_SMS);
        }

        /// <summary>
        /// 对应GB2312
        /// </summary>
        /// <returns></returns>
        public static string urlSMSGBK()
        {
            return url(SERVER_URL, METHOD_SMS_GBK);
        }

        /// <summary>
        /// 对应UTF-8(返回值为json格式)
        /// </summary>
        /// <returns></returns>
        public static string urlSMSJson()
        {
            return url(SERVER_URL, METHOD_SMS_JSON);
        }

        /// <summary>
        /// 对应UTF-8(加密传输,使用json)
        /// </summary>
        /// <returns></returns>
        public static string urlSMSEncoded()
        {
            return url(SERVER_URL, METHOD_SMS_ENCODED);
        }

        public static string urlVoiceAuth()
        {
            return URL_VOICE_AUTH;
        }

        public static string url(string server, string method)
        {
            return string.Format("{0}/{1}", server, method);
        }

    }
}