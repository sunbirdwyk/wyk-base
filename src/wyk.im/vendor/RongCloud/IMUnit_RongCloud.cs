using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using wyk.basic;

namespace wyk.im.vendor.RongCloud
{
    public class IMUnit_RongCloud : IMUnit
    {
        /// <summary>
        /// token 有效期(天), 0或负值表示永久有效
        /// </summary>
        const int TOKEN_EXPIRE_DAYS = 30;
        string key = "";
        string secret = "";

        public IMUnit_RongCloud(string key, string secret)
        {
            this.key = key;
            this.secret = secret;
        }

        #region override functions 
        public override string token(string user_id, string name, string avatar_url)
        {
            var pm = new StringDictionary();
            pm.set("userId", user_id);
            pm.set("name", name);
            pm.set("portraitUri", avatar_url);
            var data = Encoding.UTF8.GetBytes(HttpUtil.joinParam(pm));
            var result = HttpUtil.postBytes(Urls.urlGetToken(), headers(),data,Encoding.UTF8);
            JObject res = JsonConvert.DeserializeObject<JObject>(result);
            try
            {
                if (isSuccess(res))
                    return res["token"].ToString();
            }
            catch { }
            return "";
        }

        public override bool refreshUser(string user_id, string name, string avatar_url)
        {
            var pm = new StringDictionary();
            pm.set("userId", user_id);
            pm.set("name", name);
            pm.set("portraitUri", avatar_url);
            var data = Encoding.UTF8.GetBytes(HttpUtil.joinParam(pm));
            var result = HttpUtil.postBytes(Urls.urlRefreshUserInfo(), headers(), data, Encoding.UTF8);
            JObject res = JsonConvert.DeserializeObject<JObject>(result);
            if (isSuccess(res))
                return true;
            return false;
        }

        public override IMOnlineStatus userOnlineStatus(string user_id)
        {
            var pm = new StringDictionary();
            pm.set("userId", user_id);
            var data = Encoding.UTF8.GetBytes(HttpUtil.joinParam(pm));
            var result = HttpUtil.postBytes(Urls.urlCheckUserOnline(), headers(), data, Encoding.UTF8);
            JObject res = JsonConvert.DeserializeObject<JObject>(result);
            try
            {
                if (isSuccess(res))
                {
                    var status = Convert.ToInt32(res["status"]);
                    if (status == 1)
                        return IMOnlineStatus.Online;
                    else if (status == 0)
                        return IMOnlineStatus.OffLine;
                    else
                        return IMOnlineStatus.Unknown;
                }
            }
            catch { }
            return IMOnlineStatus.Unknown;
        }

        public override int tokenExpireDays()
        {
            return TOKEN_EXPIRE_DAYS;
        }

        public override IMMessageInfo messageInfoFromServerContent(string content)
        {
            try
            {
                var info = new IMMessageInfo();
                var parts = content.Split('&');
                foreach(var part in parts)
                {
                    if (part.isNull())
                        continue;
                    try
                    {
                        var subs = part.Split('=');
                        var sub = HttpUtility.UrlDecode(subs[1]);
                        switch(subs[0])
                        {
                            case "fromUserId":
                                info.from_user = sub;
                                break;
                            case "toUserId":
                                info.to_user = sub;
                                break;
                            case "objectName":
                                info.message_type = toIMMessageType(sub);
                                break;
                            case "content":
                                info.content = content;
                                break;
                            case "channelType":
                                info.conversation_type = toIMConversationType(sub);
                                break;
                            case "msgTimestamp":
                                info.message_time = DateTimeUtil.fromSince1970UTCInterval(Convert.ToInt64(sub));
                                break;
                            case "msgUID":
                                info.message_id = sub;
                                break;
                            case "sensitiveType":
                                //不记录此项值
                                break;
                            case "source":
                                info.source = toIMSource(sub);
                                break;
                            case "groupUserIds":
                                var arr = JsonConvert.DeserializeObject<JArray>(sub);
                                info.group_users = new List<string>();
                                foreach(string i in arr)
                                {
                                    if (i.isNull())
                                        continue;
                                    info.group_users.Add(i);
                                }
                                break;
                        }
                    }
                    catch { }
                }
            }
            catch { }
            return null;
        }

        public override bool checkIMServerSignature(HttpRequestMessage request)
        {
            try
            {
                var nonce = request.RequestUri.query("nonce");
                if (nonce.isNull())
                    return false;
                var timestamp = request.RequestUri.query("timestamp");
                if (timestamp.isNull())
                    timestamp = request.RequestUri.query("signTimestamp");
                if (timestamp.isNull())
                    return false;
                var sig_server = request.RequestUri.query("signature");
                if (sig_server.isNull())
                    return false;
                if (signature(nonce, timestamp) == sig_server)
                    return true;
            }
            catch { }
            return false;
        }
        #endregion

        #region private
        private IMMessageType toIMMessageType(string type_str)
        {
            switch (type_str)
            {
                case "RC:TxtMsg":
                    return IMMessageType.Text;
                case "RC:VcMsg":
                    return IMMessageType.Voice;
                case "RC:ImgMsg":
                    return IMMessageType.Image;
                case "RC:ImgTextMsg":
                    return IMMessageType.ImageText;
                case "RC:FileMsg":
                    return IMMessageType.File;
                case "RC:LBSMsg":
                    return IMMessageType.Location;
                case "RC:SightMsg":
                    return IMMessageType.MicroVideo;
                case "RC:PSImgTxtMsg":
                    return IMMessageType.PS;
                case "RC:PSMultiImgTxtMsg":
                    return IMMessageType.PSMulti;
                case "RC:ContactNtf":
                    return IMMessageType.ContactNotify;
                case "RC:ProfileNtf":
                    return IMMessageType.Profile;
                case "RC:CmdNtf":
                    return IMMessageType.CommandNotify;
                case "RC:InfoNtf":
                    return IMMessageType.InfoBar;
                case "RC:GrpNtf":
                    return IMMessageType.GroupNotify;
                case "RC:ReadNtf":
                    return IMMessageType.ReadNotify;
                case "RC:PSCmd":
                    return IMMessageType.PSCommand;
                case "RC:CmdMsg":
                    return IMMessageType.Command;
                case "RC:TypSts":
                    return IMMessageType.TypingStatus;
                case "RC:RRRspMsg":
                    return IMMessageType.GroupReadNotify;
                default:
                    return IMMessageType.Custom;
            }
        }

        private IMConversationType toIMConversationType(string type_str)
        {
            switch (type_str)
            {
                case "PERSON":
                    return IMConversationType.SingleChat;
                case "PERSONS":
                    return IMConversationType.Discussion;
                case "GROUP":
                    return IMConversationType.ChatGroup;
                case "TEMPGROUP":
                    return IMConversationType.ChatRoom;
                case "CUSTOMERSERVICE":
                    return IMConversationType.CustomerService;
                case "NOTIFY":
                    return IMConversationType.SystemNotify;
                case "MC":
                    return IMConversationType.AppPubService;
                case "MP":
                    return IMConversationType.PubService;
                default:
                    return IMConversationType.Unknown;
            }
        }

        private IMSource toIMSource(string source)
        {// iOS、Android、Websocket、MiniProgram
            switch (source)
            {
                case "iOS":
                    return IMSource.iOS;
                case "Android":
                    return IMSource.Android;
                case "Websocket":
                    return IMSource.Websocket;
                case "MiniProgram":
                    return IMSource.MiniProgram;
                default:
                    return IMSource.Unknown;
            }
        }
               
        private string nonce()
        {
            return StringUtil.getRandomString(8, false);
        }

        private string signature(string nonce, string timestamp)
        {
            return ShaCrypto.encrypt1(string.Format("{0}{1}{2}", secret, nonce, timestamp));
        }

        private bool isSuccess(JObject result)
        {
            try
            {
                if (Convert.ToInt32(result["code"]) == 200)
                    return true;
            }
            catch { }
            return false;
        }

        private StringDictionary headers()
        {
            var dic = new StringDictionary();
            dic.set("Content-Type", "application/x-www-form-urlencoded");
            dic.set("App-Key", key);
            var nonce_str = nonce();
            var timestamp = DateTime.Now.toIntervalMSSince1970().ToString();
            dic.set("Nonce", nonce_str);
            dic.set("Timestamp", timestamp);
            dic.set("Signature", signature(nonce_str, timestamp));
            return dic;
        }
        #endregion
    }
}
