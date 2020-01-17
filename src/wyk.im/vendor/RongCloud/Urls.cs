namespace wyk.im.vendor.RongCloud
{
    public class Urls
    {
        const string SERVER_URL = "http://api-cn.ronghub.com/";
        const string RETURN_FORMAT = "json";
        const string METHOD_GET_TOKEN = "user/getToken";
        const string METHOD_REFRESH_USER = "user/refresh";
        const string METHOD_CHECK_ONLINE = "user/checkOnline";

        public static string urlGetToken()
        {
            return url(SERVER_URL, METHOD_GET_TOKEN, RETURN_FORMAT);
        }

        public static string urlRefreshUserInfo()
        {
            return url(SERVER_URL, METHOD_REFRESH_USER, RETURN_FORMAT);
        }

        public static string urlCheckUserOnline()
        {
            return url(SERVER_URL, METHOD_CHECK_ONLINE, RETURN_FORMAT);
        }

        public static string url(string server, string method,string return_format)
        {
            return string.Format("{0}{1}.{2}", server, method, return_format);
        }
    }
}
