namespace wyk.wx
{
    public class WXUrls
    {
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        public const string ACCESS_TOKEN = "https://api.weixin.qq.com/cgi-bin/token";

        /// <summary>
        /// 获取JSApiTicket
        /// </summary>
        public const string JSAPI_TICKET = "https://api.weixin.qq.com/cgi-bin/ticket/getticket";

        /// <summary>
        /// 获取用户网页授权AccessToken
        /// </summary>
        public const string WEB_AUTH_ACCESS_TOKEN = "https://api.weixin.qq.com/sns/oauth2/access_token";

        /// <summary>
        /// 刷新用户网页授权AccessToken
        /// </summary>
        public const string WEB_AUTH_REFRESH_TOKEN = "https://api.weixin.qq.com/sns/oauth2/refresh_token";

        /// <summary>
        /// 统一下单
        /// </summary>
        public const string UNIFIED_ORDER = "https://api.mch.weixin.qq.com/pay/unifiedorder";

        /// <summary>
        /// 查询订单
        /// </summary>
        public const string ORDER_QUERY = "https://api.mch.weixin.qq.com/pay/orderquery";

        /// <summary>
        /// 请求生成二维码
        /// </summary>
        public const string REQUEST_QRCODE = "https://api.weixin.qq.com/cgi-bin/qrcode/create";

        /// <summary>
        /// 获取已生成的二维码
        /// </summary>
        public const string GET_QRCODE = "https://mp.weixin.qq.com/cgi-bin/showqrcode";

        /// <summary>
        /// 获取用户信息
        /// </summary>
        public const string GET_USERINFO = "https://api.weixin.qq.com/sns/userinfo";

        /// <summary>
        /// 生成自定义菜单
        /// </summary>
        public const string CUSTOM_MENU_CREATE = "https://api.weixin.qq.com/cgi-bin/menu/create";

        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        public const string CUSTOM_MENU_DELETE = "https://api.weixin.qq.com/cgi-bin/menu/delete";

        /// <summary>
        /// 发送模板消息
        /// </summary>
        public const string TEMPLATE_MESSAGE = "https://api.weixin.qq.com/cgi-bin/message/template/send";
    }
}
