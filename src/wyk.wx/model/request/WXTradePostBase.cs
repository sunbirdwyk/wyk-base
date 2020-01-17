using System.Collections.Generic;
using System.Reflection;
using wyk.basic;

namespace wyk.wx
{
    /// <summary>
    /// 微信支付提交信息
    /// </summary>
    public class WXTradePostBase
    {
        /// <summary>
        /// 获取当前提交的body内容
        /// </summary>
        /// <returns></returns>
        public string getContent(string app_id,string mch_id,string mch_secret)
        {
            var sd= new SortedDictionary<string, string>();
            sd["appid"] = app_id;
            sd["mch_id"] = mch_id;
            sd["nonce_str"] = WXUtil.getNonceStr();
            var fields = this.GetType().GetFields();
            foreach(FieldInfo fi in fields)
            {
                string value = fi.GetValue(this).ToString();
                if (value.isNull())
                    continue;
                sd[fi.Name] = value;
            }
            sd["sign"] = WXUtil.wxTradeSignature(sd,mch_secret);
            return WXUtil.toXml(sd);
        }
    }
}
