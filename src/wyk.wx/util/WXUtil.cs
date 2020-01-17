using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using wyk.basic;

namespace wyk.wx
{
    public class WXUtil
    {
        #region functions
        /// <summary>
        /// 获取微信用随机字符串
        /// </summary>
        /// <returns></returns>
        public static string getNonceStr()
        {
            return StringUtil.getRandomString(16, false);
        }

        /// <summary>
        /// 获取签名内容
        /// </summary>
        /// <param name="pm"></param>
        /// <returns></returns>
        public static string signatureContent(SortedDictionary<string, string> pm)
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in pm)
            {
                if (sb.Length > 0)
                    sb.Append("&");
                sb.Append(kv.Key + "=" + kv.Value);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取wxconfig的签名
        /// </summary>
        /// <param name="noncestr"></param>
        /// <param name="timestamp"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string wxConfigSignature(string noncestr, long timestamp, string url, string js_api_ticket)
        {
            var pm = new SortedDictionary<string, string>();
            pm["jsapi_ticket"] = js_api_ticket;
            pm["noncestr"] = noncestr;
            pm["timestamp"] = timestamp.ToString();
            pm["url"] = url.Split('#')[0];
            return ShaCrypto.encrypt1(signatureContent(pm));
        }

        public static string wxMsgEventSignature(string timestamp, string nonce, string event_token)
        {
            var pm = new SortedDictionary<string, string>();
            pm[timestamp] = timestamp;
            pm[nonce] = nonce;
            pm[event_token] = event_token;
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in pm)
            {
                sb.Append(kv.Value);
            }
            return ShaCrypto.encrypt1(sb.ToString());
        }

        public static string wxTradeSignature(SortedDictionary<string, string> pm, string mch_secret)
        {
            string sign_content = signatureContent(pm);
            sign_content += "&key=" + mch_secret;
            var signature = MD5Crypto.encrypt32(sign_content).ToUpper();
            return signature;
        }


        public static string toXml(IDictionary<string, string> pm)
        {
            return toXml(pm, "");
        }

        /// <summary>
        /// 获取传递给接口的body内容
        /// </summary>
        /// <param name="pm">参数列表</param>
        /// <param name="cdata_columms">cdata列, 逗号隔开</param>
        /// <returns></returns>
        public static string toXml(IDictionary<string, string> pm, string cdata_columms)
        {
            List<string> cdatas = new List<string>();
            if (cdata_columms != "")
            {
                string[] sub = cdata_columms.Split(',');
                foreach (string s in sub)
                {
                    if (s != "")
                        cdatas.Add(s);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<xml>");
            foreach (KeyValuePair<string, string> kv in pm)
            {
                bool is_cdata = cdatas.Contains(kv.Key);
                sb.AppendFormat("  <{0}>{1}{2}{3}</{4}>\r\n", kv.Key, is_cdata ? "<![CDATA[" : "", kv.Value, is_cdata ? "]]>" : "", kv.Key);
            }
            sb.AppendLine("</xml>");
            return sb.ToString();
        }

        /// <summary>
        /// 微信返回的xml类型结果转换为字典
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Dictionary<string, string> fromXml(string xml)
        {
            var result = new Dictionary<string, string>();
            XmlDocument xdoc = new XmlDocument();
            try
            {
                xdoc.LoadXml(xml);
                XmlNode root = xdoc.SelectSingleNode("xml");
                foreach (XmlNode xn in root.ChildNodes)
                {
                    string value = xn.InnerText.Trim();
                    if (value.StartsWith("<![CDATA["))
                    {
                        value = value.Substring(9);
                        if (value.EndsWith("]]>"))
                            value = value.Substring(0, value.Length - 2);
                    }
                    result[xn.Name.Trim()] = value;
                }
            }
            catch { }
            return result;
        }
        #endregion

        #region base
        /// <summary>
        /// 从微信服务器获取新的AccessToken
        /// </summary>
        /// <param name="app_id">公众号appid</param>
        /// <param name="app_secret">公众号app_secret</param>
        /// <param name="access_token">返回输出的access_token</param>
        /// <param name="expire_time">返回输出的token过期时间</param>
        public static void fetchAccessToken(string app_id,string app_secret, out string access_token, out DateTime expire_time)
        {
            var pm = new Dictionary<string, string>();
            pm["grant_type"] = "client_credential";
            pm["appid"] = app_id;
            pm["secret"] = app_secret;
            string result = HttpUtil.get(WXUrls.ACCESS_TOKEN, null, pm);
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            try
            {
                access_token = data["access_token"].ToString();
                int expire = Convert.ToInt32(data["expires_in"]);
                expire_time = DateTime.Now.AddSeconds(expire);
            }
            catch
            {
                access_token = "";
                expire_time = DateTimeUtil.defaultTime();
            }
        }

        /// <summary>
        /// 从微信服务器获取JSApiTicket
        /// </summary>
        /// <param name="access_token">公众号access_token</param>
        /// <param name="js_api_ticket">返回输出的js_api_ticket</param>
        /// <param name="expire_time">返回输出的ticket过期时间</param>
        public static void fetchJSApiTicket(string access_token, out string js_api_ticket, out DateTime expire_time)
        {
            var pm = new Dictionary<string, string>();
            pm["access_token"] = access_token;
            pm["type"] = "jsapi";
            string result = HttpUtil.get(WXUrls.JSAPI_TICKET, null, pm);
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            try
            {
                js_api_ticket = data["ticket"].ToString();
                int expire = Convert.ToInt32(data["expires_in"]);
                expire_time = DateTime.Now.AddSeconds(expire);
            }
            catch
            {
                js_api_ticket = "";
                expire_time = DateTimeUtil.defaultTime();
            }
        }
        #endregion

        #region user
        /// <summary>
        /// 根据微信授权code获取微信信息
        /// </summary>
        /// <param name="code">微信授权code</param>
        /// <param name="app_id">公众号appid</param>
        /// <param name="app_secret">公众号app_secret</param>
        /// <returns></returns>
        public static WXUserInfo userInfoByCode(string code, string app_id, string app_secret)
        {
            WXGetBase get = new WXGetBase();
            get.set("appid", app_id);
            get.set("secret", app_secret);
            get.set("code", code);
            get.set("grant_type", "authorization_code");
            var response = HttpUtil.get(WXUrls.WEB_AUTH_ACCESS_TOKEN, null, get.parameters);
            var result = new WXResponseBase(response);
            if (!result.isSuccess())
                return null;
            string access_token = result.getValueString("access_token");
            string open_id = result.getValueString("openid");
            if (open_id.isNull() || access_token.isNull())
                return null;
            get.clear();
            get.set("access_token", access_token);
            get.set("openid", open_id);
            get.set("lang", "zh_CN");
            response = HttpUtil.get(WXUrls.GET_USERINFO, null, get.parameters);
            result = new WXResponseBase(response);
            if (result.isSuccess())
                return new WXUserInfo(result);
            return null;
        }

        /// <summary>
        /// 根据用户openid获取微信信息
        /// </summary>
        /// <param name="open_id">用户openid</param>
        /// <param name="access_token">公众号的access_token</param>
        /// <returns></returns>
        public static WXUserInfo userInfoByOpenId(string open_id, string access_token)
        {
            if (open_id.isNull())
                return null;
            WXGetBase get = new WXGetBase();
            get.clear();
            get.set("access_token", access_token);
            get.set("openid", open_id);
            get.set("lang", "zh_CN");
            var response = HttpUtil.get(WXUrls.GET_USERINFO, null, get.parameters);
            var result = new WXResponseBase(response);
            if (result.isSuccess())
                return new WXUserInfo(result);
            return null;
        }
        #endregion

        #region function
        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <param name="access_token">公众号的access_token</param>
        /// <returns></returns>
        public static string deleteCustomMenu(string access_token)
        {
            string url = WXUrls.CUSTOM_MENU_DELETE + "?access_token=" + access_token;
            string response = HttpUtil.get(url, null, null);
            var result = new WXResponseBase(response);
            if (result.isSuccess())
                return "";
            return result.errorMessage();
        }

        /// <summary>
        /// 创建自定义菜单(默认路径)
        /// </summary>
        /// <param name="access_token">公众号的access_token</param>
        /// <returns></returns>
        public static string refreshCustomMenuByPath(string access_token)
        {
            string config_path = AppDomain.CurrentDomain.BaseDirectory + "Resources/custom_menu.json";
            return refreshCustomMenuByPath(config_path, access_token);
        }

        /// <summary>
        /// 创建自定义菜单(指定路径)
        /// </summary>
        /// <param name="path">自定义菜单路径</param>
        /// <param name="access_token">公众号的access_token</param>
        /// <returns></returns>
        public static string refreshCustomMenuByPath(string path, string access_token)
        {
            if (!File.Exists(path))
            {
                return "菜单定义文件不存在, 如果您指定了菜单路径, 请检查文件是否存在, 如果您使用的默认路径, 请查看是否存在'~/Resources/custom_menu.json'";
            }
            try
            {
                TextReader tr = File.OpenText(path);
                string content = tr.ReadToEnd();
                tr.Close();
                if (content.isNull())
                    return "自定义菜单内容为空";
                return refreshCustomMenu(content, access_token);
            }
            catch (Exception ex) { return ex.Message; }
        }

        /// <summary>
        /// 创建自定义菜单(指定内容)
        /// </summary>
        /// <param name="menu_content">自定义菜单内容</param>
        /// <param name="access_token">公众号的access_token</param>
        /// <returns></returns>
        public static string refreshCustomMenu(string menu_content, string access_token)
        {
            try
            {
                Dictionary<string, object> test = JsonConvert.DeserializeObject<Dictionary<string, object>>(menu_content);
                if (test == null)
                    return "自定义菜单内容格式有误";
                string msg = deleteCustomMenu(access_token);
                if (msg != "")
                    return "删除原菜单失败, 错误信息:" + msg;
                var url = WXUrls.CUSTOM_MENU_CREATE + "?access_token=" + access_token;
                var response = HttpUtil.postJson(url, null, menu_content);
                var result = new WXResponseBase(response);
                if (result.isSuccess())
                    return "";
                return result.errorMessage();
            }
            catch (Exception ex) { return ex.Message; }
        }

        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="access_token">公众号的access_token</param>
        /// <returns></returns>
        public static string sendTemplateMessage(WXTemplateMessageBase message, string access_token)
        {
            try
            {
                if (access_token.isNull())
                {
                    return "access_token 有误";
                }
                string body = message.getContent();
                if (body.isNull())
                {
                    return "模板消息内容有误";
                }

                string url = WXUrls.TEMPLATE_MESSAGE + "?access_token=" + access_token;
                string response = HttpUtil.postJson(url, null, body);
                var result = new WXResponseBase(response);
                if (result.isSuccess())
                    return "";
                return result.errorMessage();
            }
            catch (Exception ex) { return ex.Message; }
        }

        /// <summary>
        /// 获取永久二维码(带参数, 有个数限制)
        /// </summary>
        /// <param name="parameter">场景参数</param>
        /// <param name="access_token">公众号的access_token</param>
        /// <returns></returns>
        public static WXResQRCode requestLimitedQRCode(string parameter, string access_token)
        {
            string url = WXUrls.REQUEST_QRCODE + "?access_token=" + access_token;
            WXPostBase post = new WXPostBase();
            post.set("action_name", "QR_LIMIT_STR_SCENE");
            var scene = new Dictionary<string, object>();
            scene["scene_str"] = parameter;
            var action_info = new Dictionary<string, object>();
            action_info["scene"] = scene;
            post.set("action_info", action_info);
            string response = HttpUtil.postJson(url, null, post.getContent());
            var result = new WXResQRCode(response);
            return result;
        }

        /// <summary>
        /// 获取临时二维码, 有效时间为最大值
        /// </summary>
        /// <param name="parameter">场景参数</param>
        /// <param name="access_token">公众号的access_token</param>
        /// <returns></returns>
        public static WXResQRCode requestTemporaryQRCode(string parameter, string access_token)
        {
            return requestTemporaryQRCode(parameter, 2592000, access_token);
        }

        /// <summary>
        /// 获取临时二维码, 有效时间自定义
        /// </summary>
        /// <param name="parameter">场景参数</param>
        /// <param name="expire_seconds">过期时间(最大不超过2592000(30天)</param>
        /// <param name="access_token">公众号的access_token</param>
        /// <returns></returns>
        public static WXResQRCode requestTemporaryQRCode(string parameter, int expire_seconds, string access_token)
        {
            string url = WXUrls.REQUEST_QRCODE + "?access_token=" + access_token;
            WXPostBase post = new WXPostBase();
            post.set("expire_seconds", expire_seconds);
            post.set("action_name", "QR_STR_SCENE");
            var scene = new Dictionary<string, object>();
            scene["scene_str"] = parameter;
            var action_info = new Dictionary<string, object>();
            action_info["scene"] = scene;
            post.set("action_info", action_info);
            string response = HttpUtil.postJson(url, null, post.getContent());
            var result = new WXResQRCode(response);
            return result;
        }

        /// <summary>
        /// 根据二维码接口返回的ticket获取二维码图片
        /// </summary>
        /// <param name="ticket">二维码ticket</param>
        /// <returns></returns>
        public static Image getQRCodeImage(string ticket)
        {
            try
            {
                if (ticket.isNull())
                    return null;
                var pm = new Dictionary<string, string>();
                pm["ticket"] = ticket.urlEncode();
                return HttpUtil.getImage(WXUrls.GET_QRCODE, pm);
            }
            catch { }
            return null;
        }
        #endregion

        #region trade
        /// <summary>
        /// 统一下单, 获取预付单号
        /// </summary>
        /// <param name="trade_sheet">交易订单</param>
        /// <param name="pay_notify_url">交易通知回调URL</param>
        /// <param name="app_id">公众号appid</param>
        /// <param name="mch_id">公众号mch_id</param>
        /// <param name="mch_secret">公众号mch_secret</param>
        /// <returns></returns>
        public static WXTradeResUnifiedOrder unifiedOrder(TradeSheetBase trade_sheet, string pay_notify_url, string app_id, string mch_id, string mch_secret)
        {
            if (trade_sheet == null || trade_sheet.sheet_no.isNull())
            {
                return new WXTradeResUnifiedOrder("传入订单信息有误");
            }
            //将支付金额转换为分
            if (trade_sheet.PayAmountCent <= 0)
            {
                return new WXTradeResUnifiedOrder("传入金额有误");
            }
            var post = new WXTradePostUnifiedOrder();
            post.device_info = trade_sheet.device_info;
            if (post.device_info.isNull())
                post.device_info = "WEB";
            post.body = trade_sheet.product_name;
            post.out_trade_no = trade_sheet.sheet_no;
            post.total_fee = trade_sheet.PayAmountCent.ToString();
            post.spbill_create_ip = trade_sheet.client_ip;
            post.trade_type = "JSAPI";
            post.openid = trade_sheet.customer_open_id;
            post.notify_url = pay_notify_url;
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(post.getContent(app_id, mch_id, mch_secret)));
            string response = HttpUtil.postStream(WXUrls.UNIFIED_ORDER, null, stream);
            var result = new WXTradeResUnifiedOrder();
            result.setContentString(response);
            return result;
        }

        /// <summary>
        /// 查询订单信息, sheet_no和transaction_id二选一填写, 另一个填空字符串
        /// </summary>
        /// <param name="sheet_no"></param>
        /// <param name="transaction_id"></param>
        /// <param name="app_id">公众号appid</param>
        /// <param name="mch_id">公众号mch_id</param>
        /// <param name="mch_secret">公众号mch_secret</param>
        /// <returns></returns>
        public static WXTradeResQueryOrder queryOrder(string sheet_no, string transaction_id, string app_id, string mch_id, string mch_secret)
        {
            if (sheet_no.isNull() && transaction_id.isNull())
                return new WXTradeResQueryOrder("传入订单信息有误");
            var post = new WXTradePostQueryOrder();
            if (!transaction_id.isNull())
                post.transaction_id = transaction_id;
            else
                post.out_trade_no = sheet_no;
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(post.getContent(app_id, mch_id, mch_secret)));
            string response = HttpUtil.postStream(WXUrls.ORDER_QUERY, null, stream);
            var result = new WXTradeResQueryOrder();
            result.setContentString(response);
            return result;
        }
        #endregion
    }
}
