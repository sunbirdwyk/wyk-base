namespace wyk.wx
{
    public class WXTradePostUnifiedOrder : WXTradePostBase
    {
        /// <summary>
        /// 设备号
        /// 自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"
        /// </summary>
        public string device_info = "";
        /// <summary>
        /// 商品描述
        /// </summary>
        public string body = "";
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no = "";
        /// <summary>
        /// 标价金额
        /// </summary>
        public string total_fee = "";
        /// <summary>
        /// 终端IP
        /// </summary>
        public string spbill_create_ip = "";
        /// <summary>
        /// 交易类型   JSAPI 公众号支付 / NATIVE 扫码支付 / APP APP支付
        /// </summary>
        public string trade_type = "";
        /// <summary>
        /// 指定支付方式
        /// 上传此参数no_credit--可限制用户不能使用信用卡支付
        /// </summary>
        public string limit_pay = "";
        /// <summary>
        /// 用户标识
        /// </summary>
        public string openid = "";
        /// <summary>
        /// 通知地址
        /// 异步接收微信支付结果通知的回调地址，通知url必须为外网可访问的url，不能携带参数
        /// </summary>
        public string notify_url = "";
    }
}
