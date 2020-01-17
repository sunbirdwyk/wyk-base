using System;
using System.Configuration;
using System.Drawing;
using wyk.basic;

namespace wyk.wx
{
    public class WXUnit
    {
        #region properties
        public string APP_ID = "";
        public string APP_SECRET = "";
        
        public string MCH_ID = "";
        public string MCH_SECRET = "";
        public string PAY_NOTIFY_URL = "";

        public string EVENT_TOKEN = "";
        public string ENCODING_AES_KEY = "";



        private string _access_token = "";
        private DateTime _access_token_expire = DateTimeUtil.defaultTime();

        private string _jsapi_ticket = "";
        private DateTime _jsapi_tikcket_expire = DateTimeUtil.defaultTime();
        #endregion

        public WXUnit() { }

        public WXUnit(string app_id, string app_secret)
        {
            APP_ID = app_id;
            APP_SECRET = app_secret;
        }

        public WXUnit(string app_id, string app_secret, string mch_id, string mch_secret, string pay_notify_url)
        {
            APP_ID = app_id;
            APP_SECRET = app_secret;
            MCH_ID = mch_id;
            MCH_SECRET = mch_secret;
            PAY_NOTIFY_URL = pay_notify_url;
        }

        public WXUnit(string app_id, string app_secret, string mch_id, string mch_secret, string pay_notify_url, string encoding_aes_key, string event_token)
        {
            APP_ID = app_id;
            APP_SECRET = app_secret;
            MCH_ID = mch_id;
            MCH_SECRET = mch_secret;
            PAY_NOTIFY_URL = pay_notify_url;
            ENCODING_AES_KEY = encoding_aes_key;
            EVENT_TOKEN = event_token;
        }

        #region initialize
        /// <summary>
        /// 代码设置wx必要的各种id和key
        /// </summary>
        /// <param name="app_id"></param>
        /// <param name="app_secret"></param>
        /// <param name="mch_id"></param>
        /// <param name="mch_secret"></param>
        /// <param name="pay_notify_url"></param>
        /// <param name="encoding_aes_key"></param>
        /// <param name="event_token"></param>
        public void config(string app_id, string app_secret, string mch_id, string mch_secret,string pay_notify_url, string encoding_aes_key, string event_token)
        {
            APP_ID = app_id;
            APP_SECRET = app_secret;
            MCH_ID = mch_id;
            MCH_SECRET = mch_secret;
            PAY_NOTIFY_URL = pay_notify_url;
            ENCODING_AES_KEY = encoding_aes_key;
            EVENT_TOKEN = event_token;
    
        }

        /// <summary>
        /// 从web.config中获取设置的各种id和key
        /// </summary>
        public void load()
        {
            try
            {
                APP_ID = ConfigurationManager.AppSettings["wx_app_id"];
            }
            catch { }
            try
            {
                APP_SECRET = ConfigurationManager.AppSettings["wx_app_secret"];
            }
            catch { }
            try
            {
                MCH_ID = ConfigurationManager.AppSettings["wx_mch_id"];
            }
            catch { }
            try
            {
                MCH_SECRET = ConfigurationManager.AppSettings["wx_mch_secret"];
            }
            catch { }
            try
            {
                PAY_NOTIFY_URL = ConfigurationManager.AppSettings["wx_pay_notify_url"];
            }
            catch { }
            try
            {
                ENCODING_AES_KEY = ConfigurationManager.AppSettings["wx_encoding_aes_key"];
            }
            catch { }
            try
            {
                EVENT_TOKEN = ConfigurationManager.AppSettings["wx_event_token"];
            }
            catch { }
        }
        #endregion

        #region base
        public string getAccessToken()
        {
            if (!_access_token.isNull() && _access_token_expire > DateTime.Now.AddSeconds(30))
                return _access_token;
            WXUtil.fetchAccessToken(APP_ID, APP_SECRET, out _access_token, out _access_token_expire);
            return _access_token;
        }

        public string getJSApiTicket()
        {
            if (!_jsapi_ticket.isNull() && _jsapi_tikcket_expire > DateTime.Now.AddSeconds(30))
                return _jsapi_ticket;
            WXUtil.fetchJSApiTicket(getAccessToken(), out _jsapi_ticket, out _jsapi_tikcket_expire);
            return _jsapi_ticket;
        }
        #endregion

        #region user
        /// <summary>
        /// 根据微信授权code获取微信信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public WXUserInfo userInfoByCode(string code)
        {
            return WXUtil.userInfoByCode(code, APP_ID, APP_SECRET);
        }

        /// <summary>
        /// 根据用户openid获取微信信息
        /// </summary>
        /// <param name="open_id"></param>
        /// <returns></returns>
        public WXUserInfo userInfoByOpenId(string open_id)
        {
            return WXUtil.userInfoByOpenId(open_id, getAccessToken());
        }
        #endregion

        #region function
        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <returns></returns>
        public string deleteCustomMenu()
        {
            return WXUtil.deleteCustomMenu(getAccessToken());
        }

        /// <summary>
        /// 创建自定义菜单(默认路径)
        /// </summary>
        /// <returns></returns>
        public string refreshCustomMenu()
        {
            string config_path = AppDomain.CurrentDomain.BaseDirectory + "Resources/custom_menu.json";
            return refreshCustomMenu(config_path);
        }

        /// <summary>
        /// 创建自定义菜单(指定路径)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string refreshCustomMenu(string path)
        {
            return WXUtil.refreshCustomMenuByPath(path, getAccessToken());
        }

        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string sendTemplateMessage(WXTemplateMessageBase message)
        {
            return WXUtil.sendTemplateMessage(message, getAccessToken());
        }

        /// <summary>
        /// 获取永久二维码(带参数, 有个数限制)
        /// </summary>
        /// <param name="parameter">场景参数</param>
        /// <returns></returns>
        public WXResQRCode requestLimitedQRCode(string parameter)
        {
            return WXUtil.requestLimitedQRCode(parameter, getAccessToken());
        }

        /// <summary>
        /// 获取临时二维码, 有效时间为最大值
        /// </summary>
        /// <param name="parameter">场景参数</param>
        public WXResQRCode requestTemporaryQRCode(string parameter)
        {
            return requestTemporaryQRCode(parameter, 2592000);
        }

        /// <summary>
        /// 获取临时二维码, 有效时间自定义
        /// </summary>
        /// <param name="parameter">场景参数</param>
        /// <param name="expire_seconds">过期时间(最大不超过2592000(30天)</param>
        public WXResQRCode requestTemporaryQRCode(string parameter, int expire_seconds)
        {
            return WXUtil.requestTemporaryQRCode(parameter, expire_seconds, getAccessToken());
        }

        /// <summary>
        /// 根据二维码接口返回的ticket获取二维码图片
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public Image getQRCodeImage(string ticket)
        {
            return WXUtil.getQRCodeImage(ticket);
        }
        #endregion

        #region trade
        /// <summary>
        /// 统一下单, 获取预付单号
        /// </summary>
        /// <param name="trade_sheet">交易订单</param>
        /// <returns></returns>
        public WXTradeResUnifiedOrder unifiedOrder(TradeSheetBase trade_sheet)
        {
            return WXUtil.unifiedOrder(trade_sheet, PAY_NOTIFY_URL, APP_ID, MCH_ID, MCH_SECRET);
        }

        /// <summary>
        /// 查询订单信息, sheet_no和transaction_id二选一填写, 另一个填空字符串
        /// </summary>
        /// <param name="sheet_no"></param>
        /// <param name="transaction_id"></param>
        /// <returns></returns>
        public WXTradeResQueryOrder queryOrder(string sheet_no, string transaction_id)
        {
            return WXUtil.queryOrder(sheet_no, transaction_id, APP_ID, MCH_ID, MCH_SECRET);
        }
        #endregion
    }
}