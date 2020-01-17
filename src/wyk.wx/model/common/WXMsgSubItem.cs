using System.Text;
using System.Xml;
using wyk.basic;

namespace wyk.wx
{
    public class WXMsgSubItem
    {
        public void setXml(string xml)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xml);
                setRootXmlNode(xDoc.FirstChild);
            }
            catch { }
        }

        public void setRootXmlNode(XmlNode root_node)
        {
            foreach (XmlNode node in root_node.ChildNodes)
            {
                try
                {
                    var v = node.InnerText;
                    if (v.StartsWith("<![CDATA[") && v.Length >= 11)
                        v = v.Substring(9, v.Length - 11);
                    this.setValue(node.Name, v);
                }
                catch { }
            }
        }

        public string getXml(string root_name)
        {
            var sb = new StringBuilder();
            sb.Append("<"+ root_name + ">");
            var fields = this.GetType().GetFields();
            foreach (var fi in fields)
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
            sb.Append("</"+ root_name + ">");
            return sb.ToString();
        }
    }
}