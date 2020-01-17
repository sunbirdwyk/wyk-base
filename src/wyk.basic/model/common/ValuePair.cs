using System;
using System.Xml;

namespace wyk.basic
{
    /// <summary>
    /// Key/Value 键值对
    /// </summary>
    public class ValuePair
    {
        public string name = "";
        public string value = "";

        public ValuePair() { }
        public ValuePair(string Name, string Value)
        {
            name = Name;
            value = Value;
        }
        public string ContentStringXML
        {
            get => "<p name=\"" + StringUtil.toXMLContent(name) + "\">" + StringUtil.toXMLContent(value) + "</p>";
            set
            {
                name = "";
                this.value = "";
                try
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(value);
                    XmlNode xn = xDoc.SelectSingleNode("p");
                    try
                    {
                        name = StringUtil.fromXMLContent(xn.Attributes["name"].Value);
                    }
                    catch { }
                    try
                    {
                        this.value = StringUtil.fromXMLContent(xn.InnerText);
                    }
                    catch { }
                }
                catch { }
            }
        }

        public void setValueByXmlNode(XmlNode xn)
        {
            name = "";
            value = "";
            if (xn.Name != "p")
                return;
            try
            {
                name = StringUtil.fromXMLContent(xn.Attributes["name"].Value);
            }
            catch { }
            try
            {
                this.value = StringUtil.fromXMLContent(xn.InnerText);
            }
            catch { }
        }

        public string ContentString
        {
            get => name + Convert.ToChar(31) + value;
            set
            {
                string[] subs = value.Split(Convert.ToChar(31));
                if (subs[0].Trim() == "")
                {
                    name = "";
                    this.value = "";
                    return;
                }
                name = subs[0];
                this.value = "";
                try
                {
                    this.value = subs[1];
                }
                catch { }

            }
        }

        public int IntValue
        {
            get
            {
                try
                {
                    return Convert.ToInt32(value);
                }
                catch { }
                return 0;
            }
            set => this.value = value.ToString();
        }

        public double DoubleValue
        {
            get
            {
                try
                {
                    return Convert.ToDouble(value);
                }
                catch { }
                return 0;
            }
            set => this.value = value.ToString();
        }
    }
}