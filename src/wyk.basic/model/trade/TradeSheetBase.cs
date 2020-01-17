using System;

namespace wyk.basic
{
    /// <summary>
    /// 交易订单基本信息
    /// </summary>
    public class TradeSheetBase
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string sheet_no = "";
        /// <summary>
        /// 客户openid
        /// </summary>
        public string customer_open_id = "";
        /// <summary>
        /// 商品名称
        /// </summary>
        public string product_name = "";
        /// <summary>
        /// 支付金额(元)
        /// </summary>
        public double pay_amount = 0;
        /// <summary>
        /// 客户IP
        /// </summary>
        public string client_ip = "";
        /// <summary>
        /// 客户端信息
        /// </summary>
        public string device_info = "";

        /// <summary>
        /// 支付金额(分)
        /// </summary>
        public int PayAmountCent
        {
            get => Convert.ToInt32(pay_amount * 100);
            set => pay_amount = Convert.ToDouble(value) / 100;
        }
    }
}