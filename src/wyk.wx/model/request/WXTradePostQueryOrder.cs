namespace wyk.wx
{
    public class WXTradePostQueryOrder : WXTradePostBase
    {
        /*
         * 注: 微信订单号和商户订单号二选一, 如果两个都填, 只取微信订单号
         */
        /// <summary>
        /// 微信订单号
        /// </summary>
        public string transaction_id = "";
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no = "";
    }
}
