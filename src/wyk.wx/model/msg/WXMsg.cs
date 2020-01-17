using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using wyk.basic;

namespace wyk.wx
{
    public class WXMsg
    {
        [WXMsgProperty]
        public string ToUserName = "";
        [WXMsgProperty]
        public string FromUserName = "";
        [WXMsgProperty]
        public long CreateTime = 0;
        [WXMsgProperty]
        public string MsgType = "";

        [WXMsgProperty]
        public string Event = "";

        public WXMsg() { }
        public WXMsg(string xml)
        {
            XMLContent = xml;
        }

        static Dictionary<string, Type> _msg_types = null;
        static Dictionary<string, Type> msg_types
        {
            get
            {
                if(_msg_types==null)
                {
                    _msg_types = new Dictionary<string, Type>();
                    var types = Assembly.GetExecutingAssembly().GetTypes();
                    foreach(var t in types)
                    {
                        var t_info = t.getAttribute<WXMsgTypeAttribute>();
                        if (t_info == null)
                            continue;
                        var key = t_info.msg_type.name() + "|" + t_info.event_type.name();
                        _msg_types.Add(key, t);
                    }
                }
                return _msg_types;
            }
        }

        public static WXMsg load(string xml)
        {
            try
            {
                var msg = new WXMsg(xml);
                var key = msg.msg_type.name() + "|" + msg.event_type.name();
                if (msg_types.ContainsKey(key))
                    return Activator.CreateInstance(msg_types[key], xml) as WXMsg;
            }
            catch { }
            return new WXMsg(xml);
        }

        public DateTime create_time
        {
            get
            {
                try
                {
                    return DateTimeUtil.fromSince1970UTCInterval(Convert.ToInt64(CreateTime) * 1000);
                }
                catch { }
                return DateTimeUtil.defaultTime();
            }
            set
            {
                CreateTime = value.Ticks / 1000;
            }
        }

        public WXMsgType msg_type
        {
            get => MsgType.enumFromName<WXMsgType>();
            set => MsgType = value.name();
        }

        public WXEventType event_type
        {
            get => Event.enumFromName<WXEventType>();
            set => Event = value.name();
        }

        public string XMLContent
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("<xml>");
                var fields = this.GetType().GetFields();
                foreach(var fi in fields)
                {
                    if (fi.getAttribute<WXMsgPropertyAttribute>() == null)
                        continue;
                    try
                    {
                        if (fi.FieldType == typeof(string))
                            sb.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", fi.Name, fi.GetValue(this));
                        else
                            sb.AppendFormat("<{0}>{1}></{0}>", fi.Name, fi.GetValue(this));
                    }
                    catch { }
                }
                sb.Append("</xml>");
                return sb.ToString();
            }
            set
            {
                XmlDocument xDoc = new XmlDocument();
                try
                {
                    xDoc.LoadXml(value);
                    var root = xDoc.SelectSingleNode("xml");
                    foreach(XmlNode node in root.ChildNodes)
                    {
                        try
                        {
                            var v = node.InnerText;
                            if (v.StartsWith("<![CDATA[")&&v.Length>=11)
                                v = v.Substring(9, v.Length - 11);
                            this.setValue(node.Name, v);
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }
        #region examples
        /*  unsubscribe
        <xml><ToUserName><![CDATA[gh_804ab4d12162]]></ToUserName>
        <FromUserName><![CDATA[oK4WJ1YzAiMl6vPUoymk7wbnGx6Y]]></FromUserName>
        <CreateTime>1527491846</CreateTime>
        <MsgType><![CDATA[event]]></MsgType>
        <Event><![CDATA[unsubscribe]]></Event>
        <EventKey><![CDATA[]]></EventKey>
        </xml>
        */
        /* subscribe
        <xml><ToUserName><![CDATA[gh_804ab4d12162]]></ToUserName>
        <FromUserName><![CDATA[oK4WJ1YzAiMl6vPUoymk7wbnGx6Y]]></FromUserName>
        <CreateTime>1527491854</CreateTime>
        <MsgType><![CDATA[event]]></MsgType>
        <Event><![CDATA[subscribe]]></Event>
        <EventKey><![CDATA[qrscene_1]]></EventKey>
        <Ticket><![CDATA[gQGq8TwAAAAAAAAAAS5odHRwOi8vd2VpeGluLnFxLmNvbS9xLzAyMEdhUXdySDVlOWwxMDAwMGcwM1IAAgTIqwtbAwQAAAAA]]></Ticket>
        </xml>
        */
        /* MenuClick
        <xml><ToUserName><![CDATA[gh_804ab4d12162]]></ToUserName>
        <FromUserName><![CDATA[oK4WJ1YzAiMl6vPUoymk7wbnGx6Y]]></FromUserName>
        <CreateTime>1528027331</CreateTime>
        <MsgType><![CDATA[event]]></MsgType>
        <Event><![CDATA[VIEW]]></Event>
        <EventKey><![CDATA[https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx273f05631ca32704&redirect_uri=http%3A%2F%2Fbqws.jkw123.cn%2FClient%2FProductList&response_type=code&scope=snsapi_userinfo&state=1#wechat_redirect]]></EventKey>
        <MenuId>477500067</MenuId>
        </xml>
        */
        /* text
        <xml><ToUserName><![CDATA[gh_804ab4d12162]]></ToUserName>
        <FromUserName><![CDATA[oK4WJ1YzAiMl6vPUoymk7wbnGx6Y]]></FromUserName>
        <CreateTime>1527498046</CreateTime>
        <MsgType><![CDATA[text]]></MsgType>
        <Content><![CDATA[你好，这是测试消息]]></Content>
        <MsgId>6560554152751386473</MsgId>
        </xml>
        */
        #endregion

    }
}