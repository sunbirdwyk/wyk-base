using System;
using System.Collections.Generic;
using System.Xml;

namespace wyk.basic
{
    public class ValuePairList
    {
        public List<ValuePair> pair_list = new List<ValuePair>();

        public int getIndex(string name)
        {
            for (int i = 0; i < pair_list.Count; i++)
            {
                if (pair_list[i].name == name)
                    return i;
            }
            return -1;
        }

        public ValuePair get(string name)
        {
            for (int i = 0; i < pair_list.Count; i++)
            {
                if (pair_list[i].name == name)
                    return pair_list[i];
            }
            return new ValuePair();
        }

        public void set(string name, string value)
        {
            ValuePair pair = new ValuePair(name, value);
            set(pair);
        }

        public void set(ValuePair item)
        {
            int index = getIndex(item.name);
            if (index < 0)
                pair_list.Add(item);
            else
                pair_list[index] = item;
        }

        public string[] nameItemRange()
        {
            if (pair_list.Count == 0)
                return null;
            string[] range = new string[pair_list.Count];
            for (int i = 0; i < pair_list.Count; i++)
            {
                range[i] = pair_list[i].name;
            }
            return range;
        }

        public string[] valueItemRange()
        {
            if (pair_list.Count == 0)
                return null;
            string[] range = new string[pair_list.Count];
            for (int i = 0; i < pair_list.Count; i++)
            {
                range[i] = pair_list[i].value;
            }
            return range;
        }

        public static ValuePairList valuePairList(string[] range)
        {
            ValuePairList list = new ValuePairList();
            list.pair_list = valuePair(range);
            return list;
        }

        public static List<ValuePair> valuePair(string[] range)
        {
            if (range == null || range.Length <= 0)
                return new List<ValuePair>();
            List<ValuePair> list = new List<ValuePair>();
            for (int i = 0; i < range.Length; i++)
            {
                if (range[i] == "")
                    continue;
                ValuePair pair = new ValuePair();
                pair.name = range[i];
                pair.value = pair.name;
                list.Add(pair);
            }
            return list;
        }

        public string ContentStringXML
        {
            get
            {
                string res = "<vpl>";
                for (int i = 0; i < pair_list.Count; i++)
                {
                    res += pair_list[i].ContentStringXML;
                }
                res += "</vpl>";
                return res;
            }
            set
            {
                pair_list = new List<ValuePair>();
                try
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(value);
                    XmlNodeList xnl = xDoc.SelectSingleNode("vpl").SelectNodes("p");
                    foreach (XmlNode xn in xnl)
                    {
                        ValuePair pair = new ValuePair();
                        pair.setValueByXmlNode(xn);
                        if (pair.name != "")
                            pair_list.Add(pair);
                    }
                }
                catch { }
            }
        }

        public string ContentString
        {
            get
            {
                string res = "";
                for (int i = 0; i < pair_list.Count; i++)
                {
                    if (i > 0)
                        res += Convert.ToChar(30);
                    res += pair_list[i].ContentString;
                }
                return res;
            }
            set
            {
                pair_list = new List<ValuePair>();
                string[] parts = value.Split(Convert.ToChar(30));
                for (int i = 0; i < parts.Length; i++)
                {
                    ValuePair pair = new ValuePair();
                    pair.ContentString = parts[i];
                    if (pair.name != "")
                        set(pair);
                }
            }
        }
    }
}