using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using wyk.basic;

namespace wyk.wx
{
    public class WXRespMsg
    {
        [WXMsgProperty]
        public string ToUserName = "";
        [WXMsgProperty]
        public string FromUserName = "";
        [WXMsgProperty]
        public long CreateTime = 0;
        [WXMsgProperty]
        public string MsgType = "";

        public WXRespMsg() { }
        public WXRespMsg(string xml)
        {
            XMLContent = xml;
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

        public WXRespMsgType msg_type
        {
            get => MsgType.enumFromName<WXRespMsgType>();
            set => MsgType = value.name();
        }

        public string XMLContent
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("<xml>");
                var fields = this.GetType().GetFields();
                foreach (var fi in fields)
                {
                    if (fi.getAttribute<WXMsgPropertyAttribute>() == null)
                        continue;
                    try
                    {
                        if (fi.FieldType == typeof(string))
                            sb.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", fi.Name, fi.GetValue(this));
                        else if (fi.FieldType.BaseType == typeof(WXMsgSubItem))
                        {
                            var item = fi.GetValue(this) as WXMsgSubItem;
                            sb.Append(item.getXml(fi.Name));
                        }
                        else if(fi.FieldType== typeof(List<WXMsgItem_News>))
                        {
                            var items = fi.GetValue(this) as List<WXMsgItem_News>;
                            sb.AppendFormat("<{0}>", fi.Name);
                            foreach(var item in items)
                            {
                                sb.Append("<item>");
                                var fields2 = typeof(WXMsgItem_News).GetFields();
                                foreach(var fi2 in fields2)
                                {
                                    if (fi2.getAttribute<WXMsgPropertyAttribute>() == null)
                                        continue;
                                    if (fi2.FieldType == typeof(string))
                                        sb.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", fi2.Name, fi2.GetValue(this));
                                    else
                                        sb.AppendFormat("<{0}>{1}></{0}>", fi2.Name, fi2.GetValue(this));
                                }
                            }
                        }
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
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        try
                        {
                            var v = node.InnerText;
                            FieldInfo fi = this.GetType().GetField(node.Name);
                            if (fi.FieldType.BaseType == typeof(WXMsgSubItem))
                            {
                                var item = Activator.CreateInstance(fi.FieldType) as WXMsgSubItem;
                                item.setXml(v);
                                fi.SetValue(this, item);
                            }
                            else if (fi.FieldType == typeof(List<WXMsgItem_News>))
                            {
                                var items = new List<WXMsgItem_News>();
                                var cnl = node.SelectNodes("item");
                                foreach (XmlNode xn in cnl)
                                {
                                    var item = new WXMsgItem_News();
                                    item.setRootXmlNode(xn);
                                    items.Add(item);
                                }
                            }
                            else
                            {
                                if (v.StartsWith("<![CDATA[") && v.Length >= 11)
                                    v = v.Substring(9, v.Length - 11);
                                this.setValue(node.Name, v);
                            }
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }
    }
}