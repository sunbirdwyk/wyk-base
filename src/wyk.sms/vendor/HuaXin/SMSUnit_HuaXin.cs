using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using wyk.basic;

namespace wyk.sms.vendor.HuaXin
{
    /// <summary>
    /// 金达中慧账号UserId: 59840
    /// </summary>
    public class SMSUnit_HuaXin : SMSUnit
    {
        private string password_md5 = "";
        public SMSUnit_HuaXin(string user_name, string password, string sign) : base(user_name, password, sign)
        {
            password_md5 = MD5Crypto.encrypt32(password).ToUpper();
            provider = SMSProvider.HuaXin;
        }

        /// <summary>
        /// 发送单条短信
        /// </summary>
        /// <param name="content">短信内容</param>
        /// <param name="mobile">目标手机号</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <param name="filter_nonnumber">是否过滤手机号中包含的非数字字符</param>
        /// <returns>发送结果</returns>
        public override SMSResponse send(string content, string mobile, string rid, bool filter_nonnumber)
        {
            if (service_key.isNull())
                return SMSResponse.errorNotInitialized();
            if (content.isNull())
                return SMSResponse.custom(9900, "传入内容不能为空");
            if (filter_nonnumber)
                mobile = mobile.getOnlyNumber();
            if (!mobile.isPhoneNumber())
                return SMSResponse.custom(9901, "手机号传入有误");
            var send_content = new SMSSendContent(string.Format("【{0}】{1}", sign, content), mobile, service_key, service_secret);
            //var data = string.Format("UserId={0}&Text64={1}", rid, encodeContent(send_content));
            var response = post(textContent(send_content), "");
            //var response = post(Urls.urlSMSEncoded() + "?" + data, "");
            return getResponse(response);
        }

        /// <summary>
        /// 发送同内容的多条短信
        /// </summary>
        /// <param name="content">短信内容</param>
        /// <param name="mobile_list">目标手机号列表</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <param name="filter_nonnumber">是否过滤手机号中包含的非数字字符</param>
        /// <returns>发送结果</returns>
        public override SMSResponseList send(string content, List<string> mobile_list, string rid, bool filter_nonnumber)
        {
            if (service_key.isNull())
                return SMSResponseList.errorNotInitialized();
            if (content.isNull())
                return SMSResponseList.custom(9900, "传入内容不能为空");
            var sb_mobile = new StringBuilder();
            foreach (var item in mobile_list)
            {
                var mob = item;
                if (filter_nonnumber)
                    mob = mob.getOnlyNumber();
                if (!mob.isPhoneNumber())
                    continue;
                if (sb_mobile.Length > 0)
                    sb_mobile.Append(",");
                sb_mobile.Append(mob.Trim());
            }
            if (sb_mobile.Length <= 0)
                return SMSResponseList.custom(9901, "手机号传入有误");
            var send_content = new SMSSendContent(string.Format("【{0}】{1}", sign, content), mobile_list, service_key, service_secret);
            //var data = string.Format("UserId={0}&Text64={1}", rid, encodeContent(send_content));
            var response = post(textContent(send_content), "");
            //var response = post(Urls.urlSMSEncoded() + "?" + data, "");
            var res = getResponse(response);
            var res_list = new SMSResponseList();
            res_list.code = res.code;
            res_list.msg = res.msg;
            res_list.total_count = res.count;
            res_list.responses.Add(res);
            return res_list;
        }

        #region 功能函数
        private string textContent(SMSSendContent content)
        {
            var res = string.Format("{0}?action=send&userid={1}&account={2}&password={3}&mobile={4}&content={5}&sendTime=&extno=", Urls.urlSMSJson(), "test", service_key, password_md5, content.Moblie, HttpUtility.UrlEncode(content.Text));
            return res;
        }
        private string encodeContent(SMSSendContent content)
        {
            var key_original = Encoding.UTF8.GetBytes(service_secret);
            var key = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                if (key_original.Length > i)
                    key[i] = key_original[i];
            }
            byte[] inputByteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(content));
            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            dCSP.Mode = CipherMode.CBC;
            dCSP.Padding = PaddingMode.PKCS7;
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(key, key), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return HttpUtility.UrlEncode(Convert.ToBase64String(mStream.ToArray()));
        }

        private string post(string url, string data)
        {
            byte[] dataArray = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.ContentLength = dataArray.Length;
            using (var dataStream = request.GetRequestStream())
                dataStream.Write(dataArray, 0, dataArray.Length);
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                        return reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                using (var stream = e.Response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                        return reader.ReadToEnd();
                }
            }
        }


        private SMSResponse getResponse(string response_content)
        {
            var obj = JsonConvert.DeserializeObject<JObject>(response_content);
            return getResponse(obj);
        }

        private SMSResponse getResponse(JObject response_object)
        {
            try
            {
                var res = new SMSResponse();
                try
                {
                    res.code = Convert.ToInt32(response_object["returnstatus"]);
                }
                catch { res.code = -1; }
                try
                {
                    res.code = Convert.ToInt32(response_object["StatusCode"]);
                }
                catch { res.code = -1; }
                if (res.code == -1)
                    return SMSResponse.errorDataFormatError();
                try
                {
                    res.msg = response_object["message"].ToString();
                }
                catch { }
                try
                {
                    res.msg = response_object["Description"].ToString();
                }
                catch { }
                try
                {
                    res.count = Convert.ToInt32(response_object["successCounts"]);
                }
                catch { }
                try
                {
                    res.count = Convert.ToInt32(response_object["SuccessCounts"]);
                }
                catch { }
                try
                {
                    res.balance = Convert.ToDouble(response_object["remainpoint"]);
                }
                catch { }
                try
                {
                    res.balance = Convert.ToDouble(response_object["Amount"]);
                }
                catch { }
                try
                {
                    res.sid = response_object["taskID"].ToString();
                }
                catch { }
                try
                {
                    res.sid = response_object["MsgId"].ToString();
                }
                catch { }
                return res;
            }
            catch { }
            return SMSResponse.errorDataFormatError();
        }
        #endregion

        #region 功能类
        class SMSSendContent
        {
            public string UserName = "";
            public string Secret = "";
            public string Stamp = "";
            public string Moblie = "";
            public string Text = "";
            public string Ext = "";
            public string SendTime = "";

            public SMSSendContent(string content, string mobile, string username, string password)
            {
                UserName = username;
                Stamp = DateTime.Now.ToString("MMddHHmmss");
                Moblie = mobile;
                Text = content;
                Secret = MD5Crypto.encrypt32( password+Stamp);
            }

            public SMSSendContent(string content, List<string> mobiles, string username, string password)
            {
                UserName = username;
                Stamp = DateTime.Now.ToString("MMddHHmmss");
                setMobiles(mobiles);
                Text = content;
                Secret = MD5Crypto.encrypt32(password + Stamp);
            }

            public void setMobiles(List<string> mobile_list)
            {
                var sb = new StringBuilder();
                foreach (var m in mobile_list)
                {
                    if (m.isNull())
                        continue;
                    if (sb.Length > 0)
                        sb.Append(",");
                    sb.Append(m.Trim());
                }
                Moblie = sb.ToString();
            }
        }
        #endregion
    }
}