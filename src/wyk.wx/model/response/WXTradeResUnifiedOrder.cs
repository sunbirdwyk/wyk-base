namespace wyk.wx
{
    public class WXTradeResUnifiedOrder : WXTradeResponseBase
    {
        /// <summary>
        /// 预支付会话标识
        /// </summary>
        public string prepay_id = "";
        /// <summary>
        /// 交易类型
        /// JSAPI 公众号支付  |  NATIVE 扫码支付  |  APP APP支付
        /// </summary>
        public string trade_type = "";
        /// <summary>
        /// 扫码支付二维码url, trade_type为NATIVE时返回
        /// </summary>
        public string code_url = "";

        public WXTradeResUnifiedOrder() { }
        public WXTradeResUnifiedOrder(string error_message)
        {
            return_code = "FAIL";
            return_msg = error_message;
        }
    }
}
