using System;
using System.Reflection;
using wyk.basic;

namespace wyk.wx
{
    public class WXUserInfo
    {
        /// <summary>
        /// 用户的openid
        /// </summary>
        public string openid = "";
        /// <summary>
        /// 用户的unionid(如果存在)
        /// </summary>
        public string unionid = "";
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nickname = "";
        /// <summary>
        /// 用户性别, 1为男性, 2为女性, 0为未知
        /// </summary>
        public string sex = "";
        /// <summary>
        /// 省份
        /// </summary>
        public string province = "";
        /// <summary>
        /// 城市
        /// </summary>
        public string city = "";
        /// <summary>
        /// 国家代码
        /// </summary>
        public string country = "";
        /// <summary>
        /// 头像url
        /// </summary>
        public string headimgurl = "";

        /// <summary>
        /// 关注公众号状态
        /// </summary>
        public string subscribe = "";

        /// <summary>
        /// 关注公众号时间
        /// </summary>
        public string subscribe_time = "";

        /// <summary>
        /// 关注公众号场景
        /// </summary>
        public string subscribe_scene = "";

        public string getGender()
        {
            if (sex == "1")
                return "男";
            else if (sex == "2")
                return "女";
            else
                return "";
        }

        public bool subscribed()
        {
            if (subscribe == "1")
                return true;
            return false;
        }

        public DateTime subscribeTime()
        {
            try
            {
                return DateTimeUtil.fromSince1970UTCInterval(Convert.ToInt64(subscribe_time));
            }
            catch { return DateTimeUtil.defaultTime(); }
        }

        public WXUserInfo() { }
        public WXUserInfo(WXResponseBase response)
        {
           var  fields = this.GetType().GetFields();
            foreach (FieldInfo fi in fields)
            {
                this.setValue(fi, response.getValue(fi.Name));
            }
        }
    }
}
