using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using wyk.basic;

namespace wyk.sms.vendor.YunPian
{
    /// <summary>
    /// 云片短信发送
    /// 测试用户key : dffc302c08de65f69dc9673951be6a5e
    /// 测试云片账户: 15939048001
    /// </summary>
    public class SMSUnit_YunPian : SMSUnit
    {
        public SMSUnit_YunPian(string APIKey, string sign) : base(APIKey, sign)
        {
            provider = SMSProvider.YunPian;
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
            var sb = new StringBuilder();
            sb.Append("apikey=");
            sb.Append(service_key);
            sb.Append("&mobile=");
            sb.Append(mobile);
            sb.Append("&text=");
            sb.Append(HttpUtility.UrlEncode(string.Format("【{0}】{1}", sign, content)));
            if (!rid.isNull())
                sb.Append("&uid=" + rid);
            var response = post(Urls.urlSMSSingle(), sb.ToString());
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
            var sb = new StringBuilder();
            sb.Append("apikey=");
            sb.Append(service_key);
            sb.Append("&mobile=");
            sb.Append(sb_mobile.ToString());
            sb.Append("&text=");
            sb.Append(HttpUtility.UrlEncode(string.Format("【{0}】{1}", sign, content)));
            if (!rid.isNull())
                sb.Append("&uid=" + rid);
            var response = post(Urls.urlSMSList(), sb.ToString());
            return getResponseList(response);
        }

        /// <summary>
        /// 发送单条模板短信
        /// </summary>
        /// <param name="template_id">模板ID</param>
        /// <param name="pm">模板参数</param>
        /// <param name="mobile">目标手机号</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <param name="filter_nonnumber">是否过滤手机号中包含的非数字字符</param>
        /// <returns>发送结果</returns>
        public override SMSResponse sendTemplate(long template_id, Dictionary<string, string> pm, string mobile, string rid, bool filter_nonnumber)
        {
            if (service_key.isNull())
                return SMSResponse.errorNotInitialized();
            if (filter_nonnumber)
                mobile = mobile.getOnlyNumber();
            if (!mobile.isPhoneNumber())
                return SMSResponse.custom(9901, "手机号传入有误");
            var sb = new StringBuilder();
            sb.Append("apikey=");
            sb.Append(service_key);
            sb.Append("&mobile=");
            sb.Append(mobile);
            sb.Append("&tpl_id=" + template_id);
            sb.Append("&tpl_value=" + HttpUtility.UrlEncode(serializeTemplateParam(pm)));
            if (!rid.isNull())
                sb.Append("&uid=" + rid);
            var response = post(Urls.urlSMSTemplateSingle(), sb.ToString());
            return getResponse(response);
        }

        /// <summary>
        /// 发送同内容的多条短信
        /// </summary>
        /// <param name="template_id">模板ID</param>
        /// <param name="pm">模板参数</param>
        /// <param name="mobile_list">目标手机号列表</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <param name="filter_nonnumber">是否过滤手机号中包含的非数字字符</param>
        /// <returns>发送结果</returns>
        public override SMSResponseList sendTemplate(long template_id, Dictionary<string, string> pm, List<string> mobile_list, string rid, bool filter_nonnumber)
        {
            if (service_key.isNull())
                return SMSResponseList.errorNotInitialized();
            var sb_mobile = new StringBuilder();
            foreach (var item in mobile_list)
            {
                var mob = item;
                if (filter_nonnumber)
                    mob = item.getOnlyNumber();
                if (!mob.isPhoneNumber())
                    continue;
                if (sb_mobile.Length > 0)
                    sb_mobile.Append(",");
                sb_mobile.Append(mob.Trim());
            }
            if (sb_mobile.Length <= 0)
                return SMSResponseList.custom(9901, "手机号传入有误");
            var sb = new StringBuilder();
            sb.Append("apikey=");
            sb.Append(service_key);
            sb.Append("&mobile=");
            sb.Append(sb_mobile.ToString());
            sb.Append("&tpl_id=" + template_id);
            sb.Append("&tpl_value=" + HttpUtility.UrlEncode(serializeTemplateParam(pm)));
            if (!rid.isNull())
                sb.Append("&uid=" + rid);
            var response = post(Urls.urlSMSTemplateList(), sb.ToString());
            return getResponseList(response);
        }

        /// <summary>
        /// 发送语音验证码
        /// </summary>
        /// <param name="auth_code">验证码, 一般为4~6位数字</param>
        /// <param name="mobile">目标手机号</param>
        /// <param name="rid">记录ID, 用于返回结果后的后续处理, 非必填</param>
        /// <param name="filter_nonnumber">是否过滤手机号中包含的非数字字符</param>
        /// <returns>发送结果</returns>
        public override SMSResponse sendVoiceAuth(string auth_code, string mobile, string rid, bool filter_nonnumber)
        {
            if (service_key.isNull())
                return SMSResponse.errorNotInitialized();
            if (auth_code.isNull())
                return SMSResponse.custom(9900, "传入内容不能为空");
            if (filter_nonnumber)
                mobile = mobile.getOnlyNumber();
            if (!mobile.isPhoneNumber())
                return SMSResponse.custom(9901, "手机号传入有误");
            var sb = new StringBuilder();
            sb.Append("apikey=");
            sb.Append(service_key);
            sb.Append("&mobile=");
            sb.Append(mobile);
            sb.Append("&code=");
            sb.Append(auth_code);
            if (!rid.isNull())
                sb.Append("&uid=" + rid);
            var response = post(Urls.urlAuthCodeVoice(), sb.ToString());
            return getResponse(response);
        }

        #region 功能函数
        public override SMSResult resultByContent(string content)
        {
            try
            {
                return resultByContent(JsonConvert.DeserializeObject<JObject>(content));
            }
            catch { }
            return null;
        }

        public override SMSResult resultByContent(JObject obj)
        {
            if (obj == null)
                return null;
            try
            {
                var result = new SMSResult();
                result.sid = obj["sid"].ToString();
                result.ReceivedTime = obj["user_receive_time"].ToString();
                try
                {
                    result.uid = obj["uid"].ToString();
                }
                catch { }
                try
                {
                    result.mobile = obj["mobile"].ToString();
                }
                catch { }
                try
                {
                    result.carrier_code = obj["error_msg"].ToString();
                }
                catch { }
                try
                {
                    result.carrier_msg = obj["error_detail"].ToString();
                }
                catch { }
                try
                {
                    result.status = obj["report_status"].ToString();
                }
                catch { }
                try
                {
                    result.duration = Convert.ToInt32(obj["duration"]);
                }
                catch { }
                return result;
            }
            catch { }
            return null;
        }
        #endregion

        #region 私有函数
        private string post(string url, string data)
        {
            byte[] dataArray = Encoding.UTF8.GetBytes(data);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
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
                    res.code = Convert.ToInt32(response_object["code"]);
                }
                catch { return SMSResponse.errorDataFormatError(); }
                try
                {
                    res.msg = response_object["msg"].ToString();
                }
                catch { }
                try
                {
                    res.count = Convert.ToInt32(response_object["count"]);
                }
                catch { }
                try
                {
                    res.fee = Convert.ToDouble(response_object["fee"]);
                }
                catch { }
                try
                {
                    res.unit = response_object["unit"].ToString();
                }
                catch { }
                try
                {
                    res.mobile = response_object["mobile"].ToString();
                }
                catch { }
                try
                {
                    res.sid = response_object["sid"].ToString();
                }
                catch { }
                return res;
            }
            catch { }
            return SMSResponse.errorDataFormatError();
        }

        private SMSResponseList getResponseList(string response_content)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<JObject>(response_content);
                var res = new SMSResponseList();
                try
                {
                    res.total_count = Convert.ToInt32(obj["total_count"]);
                }
                catch { }
                try
                {
                    res.total_fee = Convert.ToDouble(obj["total_fee"]);
                }
                catch { }
                try
                {
                    res.unit = obj["unit"].ToString();
                }
                catch { }
                try
                {
                    var data = obj["data"] as JArray;
                    foreach (JObject item in data)
                    {
                        var sub = getResponse(item);
                        res.responses.Add(sub);
                    }
                }
                catch { }
            }
            catch { }
            return SMSResponseList.errorDataFormatError();
        }

        private string serializeTemplateParam(Dictionary<string, string> pm)
        {
            if (pm == null)
                return "";
            var sb = new StringBuilder();
            foreach (var key in pm.Keys)
            {
                try
                {
                    if (sb.Length > 0)
                        sb.Append("&");
                    var cur_key = key;
                    if (!cur_key.StartsWith("#"))
                        cur_key = "#" + cur_key;
                    if (!cur_key.EndsWith("#"))
                        cur_key += "#";
                    sb.Append(HttpUtility.UrlEncode(cur_key));
                    sb.Append("=");
                    sb.Append(HttpUtility.UrlEncode(pm[key]));
                }
                catch { }
            }
            return sb.ToString();
        }
        #endregion
    }
}
