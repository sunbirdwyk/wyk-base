namespace wyk.wx
{
    /// <summary>
    /// 微信公众号相关机密信息
    /// </summary>
    public class WXAppInfo
    {
        /// <summary>
        /// 公众号主体ID, 需要更新主体信息时使用
        /// </summary>
        public int oa_id = 0;

        #region 公众号相关机密信息
        public string app_id = "";
        public string app_secret = "";
        public string mch_id = "";
        public string mch_secret = "";
        public string event_token = "";
        public string encoding_aes_key = "";
        public string pay_notify_url = "";
        #endregion

        /// <summary>
        /// 自定义菜单内容
        /// </summary>
        public string menu = "";
    }
}
