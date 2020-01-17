using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Xml;
using wyk.basic;

namespace wyk.db
{
    /// <summary>
    /// 数据库初始数据描述文件
    /// 注: 一个实例代表一个表中的初始数据, 对应一个数据表描述文件
    /// </summary>
    public class DBInitDataProfile
    {
        /// <summary>
        /// 数据表名
        /// </summary>
        public string table_name = "";
        /// <summary>
        /// 表数据集
        /// </summary>
        public List<DBInitData> data_list = new List<DBInitData>();

        public DBInitDataProfile() { }

        public static DBInitDataProfile fromXMLFile(string path)
        {
            DBInitDataProfile profile = new DBInitDataProfile();
            try
            {
                TextReader tr = File.OpenText(path);
                profile.XMLContent = tr.ReadToEnd();
                tr.Close();
            }
            catch { }
            return profile;
        }

        public string insertAllData()
        {
            string msg = "";
            foreach (DBInitData item in data_list)
            {
                msg += item.insertData(table_name);
            }
            return msg;
        }

        public string toXmlFile(string root_folder)
        {
            string path = root_folder.TrimEnd('\\').TrimEnd('/') + "\\" + table_name + ".data";
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
                TextWriter tw = File.CreateText(path);
                tw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                tw.Write(XMLContent);
                tw.Flush();
                tw.Close();
            }
            catch (Exception ex) { return ex.Message; }
            return "";
        }

        public string XMLContent
        {
            get
            {
                string content = "<db_data name=\"" + table_name + "\">\r\n";
                foreach (DBInitData data in data_list)
                {
                    content += "  <data>\r\n";
                    foreach (DBInitDataItem di in data.item_list)
                    {
                        content += "    <" + di.column_name + " type=\"" + di.DataType + "\">" + di.StringValue.xmlEncode() + "</" + di.column_name + ">\r\n";
                    }
                    content += "  </data>\r\n";
                }
                content += "</db_data>\r\n";
                return content;
            }
            set
            {
                table_name = "";
                data_list = new List<DBInitData>();
                try
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(value);
                    XmlNode root = xDoc.SelectSingleNode("db_data");
                    table_name = root.Attributes["name"].Value;
                    XmlNodeList xnlist = root.SelectNodes("data");
                    foreach (XmlNode xn in xnlist)
                    {
                        data_list.Add(new DBInitData(xn));
                    }
                }
                catch { }
            }
        }
    }
}
