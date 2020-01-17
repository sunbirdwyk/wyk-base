using System;
using wyk.basic;

namespace wyk.wx
{
    public class WXTradeResQueryOrder : WXTradeResponseBase
    {
        /// <summary>
        /// 是否关注公众账号
        /// 用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
        /// </summary>
        public string is_subscribe = "";
        /// <summary>
        /// 交易类型
        /// 调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP，MICROPAY
        /// </summary>
        public string trade_type = "";
        /// <summary>
        /// 交易状态
        /// SUCCESS—支付成功
        /// REFUND—转入退款
        /// NOTPAY—未支付
        /// CLOSED—已关闭
        /// REVOKED—已撤销（刷卡支付）
        /// USERPAYING--用户支付中
        /// PAYERROR--支付失败(其他原因，如银行返回失败)
        /// </summary>
        public string trade_state = "";
        /// <summary>
        /// 付款银行
        /// </summary>
        public string bank_type = "";
        /// <summary>
        /// 标价金额(分)
        /// </summary>
        public string total_fee = "";
        /// <summary>
        /// 标价币种
        /// </summary>
        public string fee_type = "";
        /// <summary>
        /// 微信支付订单号
        /// </summary>
        public string transaction_id = "";
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no = "";
        /// <summary>
        /// 附加数据, 原样返回
        /// </summary>
        public string attach = "";
        /// <summary>
        /// 支付完成时间
        /// 订单支付时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010
        /// </summary>
        public string time_end = "";
        /// <summary>
        /// 交易状态描述
        /// 对当前查询订单状态的描述和下一步操作的指引
        /// 例: 支付失败，请重新下单支付
        /// </summary>
        public string trade_state_desc = "";

        public WXTradeResQueryOrder() { }
        public WXTradeResQueryOrder(string error_message)
        {
            return_code = "FAIL";
            return_msg = error_message;
        }

        public DateTime getTradeTime()
        {
            var trade_time = time_end.Insert(4, "-").Insert(7, "-").Insert(10, " ").Insert(13, ":").Insert(16, ":");
            try
            {
                return Convert.ToDateTime(trade_time);
            }
            catch { return DateTimeUtil.defaultTime(); }
        }

        public override bool isSuccess()
        {
            if (!base.isSuccess())
                return false;
            if (trade_state == CODE_SUCCESS)
                return true;
            return false;
        }

        public override string errorMessage()
        {
            if (isSuccess())
                return "";
            var msg= base.errorMessage();
            if (msg.isNull())
                return trade_state_desc;
            return msg;
        }
    }
}
