using System;
using System.Collections;
using System.Data;
using System.Xml;

namespace wyk.basic
{
    /// <summary>
    /// DataTable操作单元(部分)
    /// </summary>
    public class DataTableUtil
    {
        /// <summary>
        /// 通过XML格式的字符串转换为DataTable
        /// </summary>
        /// <param name="xml_content"></param>
        /// <returns></returns>
        public static DataTable fromXML(string xml_content)
        {
            DataTable table = new DataTable();
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xml_content);
                XmlNode root = xDoc.SelectSingleNode("table");
                XmlNodeList rows = root.SelectNodes("tr");
                if (rows.Count == 0)
                    rows = root.SelectSingleNode("tbody").SelectNodes("tr");
                if (rows.Count == 0)
                    return table;
                int startrow = 0;
                XmlNodeList headers = null;
                try
                {
                    headers = root.SelectSingleNode("thead").SelectSingleNode("tr").SelectNodes("th");
                }
                catch { }
                if (headers == null || headers.Count == 0)
                {
                    try
                    {
                        headers = root.SelectSingleNode("thead").SelectSingleNode("tr").SelectNodes("td");
                    }
                    catch { }
                }
                if (headers == null || headers.Count == 0)
                {
                    headers = rows[0].ChildNodes;
                    startrow = 1;
                }
                foreach (XmlNode xn in headers)
                {
                    if (xn.Name.ToLower() == "td" || xn.Name.ToLower() == "th")
                        table.Columns.Add(StringUtil.fromXMLContent(xn.InnerText));
                }
                for (int i = startrow; i < rows.Count; i++)
                {
                    DataRow dr = table.NewRow();
                    XmlNodeList xnl = rows[i].ChildNodes;
                    for (int j = 0; j < xnl.Count; j++)
                    {
                        string content = StringUtil.fromXMLContent(xnl[j].InnerText);
                        try
                        {
                            dr[j] = content;
                        }
                        catch { }
                    }
                    table.Rows.Add(dr);
                }
            }
            catch { }
            return table;
        }

        /// <summary>
        /// 将当前DataTable转为XML格式的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string toXML(DataTable data)
        {
            string res = "<table>";
            res += "<tr>";
            for (int i = 0; i < data.Columns.Count; i++)
            {
                res += "<td>" + StringUtil.toXMLContent(data.Columns[i].ColumnName) + "</td>";
            }
            res += "</tr>";
            for (int i = 0; i < data.Rows.Count; i++)
            {
                res += "<tr>";
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    res += "<td>" + StringUtil.toXMLContent(data.Rows[i][j].ToString()) + "</td>";
                }
                res += "</tr>";
            }
            res += "</table>";
            return res;
        }

        /// <summary>
        /// 通过HTML格式的字符串转换为DataTable
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static DataTable fromHTMLTable(string html)
        {
            DataTable table = new DataTable();
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(html);
                XmlNode root = xDoc.SelectSingleNode("table");
                XmlNodeList rows = root.SelectNodes("tr");
                if (rows.Count == 0)
                    rows = root.SelectSingleNode("tbody").SelectNodes("tr");
                if (rows.Count == 0)
                    return table;
                int startrow = 0;
                XmlNodeList headers = null;
                try
                {
                    headers = root.SelectSingleNode("thead").SelectSingleNode("tr").SelectNodes("th");
                }
                catch { }
                if (headers == null || headers.Count == 0)
                {
                    try
                    {
                        headers = root.SelectSingleNode("thead").SelectSingleNode("tr").SelectNodes("td");
                    }
                    catch { }
                }
                if (headers == null || headers.Count == 0)
                {
                    headers = rows[0].ChildNodes;
                    startrow = 1;
                }
                foreach (XmlNode xn in headers)
                {
                    if (xn.Name.ToLower() == "td" || xn.Name.ToLower() == "th")
                        table.Columns.Add(xn.InnerText.htmlEncode());
                }
                for (int i = startrow; i < rows.Count; i++)
                {
                    DataRow dr = table.NewRow();
                    XmlNodeList xnl = rows[i].ChildNodes;
                    for (int j = 0; j < xnl.Count; j++)
                    {
                        string content = xnl[j].InnerText.htmlDecode();
                        try
                        {
                            dr[j] = content;
                        }
                        catch { }
                    }
                    table.Rows.Add(dr);
                }
            }
            catch { }
            return table;
        }

        /// <summary>
        /// 将当前DataTable转为HTML格式的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="invisible_columns">不可见的列(,隔开)</param>
        /// <returns></returns>
        public static string toHTML(DataTable data, string invisible_columns)
        {
            System.Drawing.Color c_header_background = System.Drawing.Color.DarkGreen;
            System.Drawing.Color c_header_text = System.Drawing.Color.White;
            System.Drawing.Color c_content_background = System.Drawing.Color.Honeydew;
            System.Drawing.Color c_content = System.Drawing.Color.Black;
            int fs_header = 14;
            int fs_content = 12;
            bool b_header = true;
            bool b_content = false;
            string[] invisible_cols = invisible_columns.Split(',');
            string res = "<table cellpadding=\"0\" cellspacing=\"0\" style=\"border-left:1px solid #808080; border-top:1px solid #808080;\">";
            res += "<tr>";
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (stringArrayContains(invisible_cols, i.ToString()))
                    continue;
                res += "<td style=\"font-family:微软雅黑; font-size:" + fs_header.ToString() + "px; font-weight:" + (b_header ? "bold" : "regular") + "; background-color:" + ColorUtil.stringForColor(c_header_background) + "; color:" + ColorUtil.stringForColor(c_header_text) + ";padding:3px 3px 3px 3px; text-align:left; vertical-align:middle;border-right:1px solid #808080; border-bottom:1px solid #808080;\">" + data.Columns[i].ColumnName.htmlEncode() + "</td>";
            }
            res += "</tr>";
            for (int i = 0; i < data.Rows.Count; i++)
            {
                res += "<tr>";
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    if (stringArrayContains(invisible_cols, j.ToString()))
                        continue;
                    res += "<td style=\"font-family:微软雅黑; font-size:" + fs_content.ToString() + "px; font-weight:" + (b_content ? "bold" : "regular") + "; background-color:" + ColorUtil.stringForColor(c_content_background) + "; color:" + ColorUtil.stringForColor(c_content) + ";padding:3px 3px 3px 3px; text-align:left; vertical-align:middle;border-right:1px solid #808080; border-bottom:1px solid #808080;\">" + data.Rows[i][j].ToString().htmlEncode() + "</td>";
                }
                res += "</tr>";
            }
            res += "</table>";
            return res;
        }

        private static bool stringArrayContains(string[] list, string item)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Trim() == item.Trim())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 将当前DataTable转为XML格式的字符串(简), 此方式生成的字符串长度较短
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string toXMLSimple(DataTable data)
        {
            string result = "";
            try
            {
                result += "<t>";
                result += "<h>";
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    result += "<c>" + StringUtil.toXMLContent(data.Columns[i].ColumnName) + "</c>";
                }
                result += "</h>";
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    result += "<r>";
                    for (int j = 0; j < data.Columns.Count; j++)
                    {
                        result += "<d>" + StringUtil.toXMLContent(data.Rows[i][j].ToString()) + "</d>";
                    }
                    result += "</r>";
                }
                result += "</t>";
            }
            catch
            {
                result = "";
            }
            return result;
        }

        /// <summary>
        /// 通过简化的XML格式的字符串转换为DataTable
        /// </summary>
        /// <param name="xml_content"></param>
        /// <returns></returns>
        public static DataTable fromXMLSimple(string xml_content)
        {
            try
            {
                DataTable data = new DataTable();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xml_content);
                XmlNode root = xml.SelectSingleNode("t");
                XmlNodeList columns = root.SelectSingleNode("h").SelectNodes("c");
                foreach (XmlNode col in columns)
                {
                    data.Columns.Add(StringUtil.fromXMLContent(col.InnerText.Trim()));
                }
                if (data.Columns.Count <= 0)
                    return null;
                XmlNodeList rows = root.SelectNodes("r");
                foreach (XmlNode row in rows)
                {
                    DataRow dr = data.NewRow();
                    XmlNodeList cells = row.SelectNodes("d");
                    for (int i = 0; i < cells.Count; i++)
                    {
                        try
                        {
                            if (i < data.Columns.Count)
                                dr[i] = StringUtil.fromXMLContent(cells[i].InnerText);
                        }
                        catch { }
                    }
                    data.Rows.Add(dr);
                }
                if (data.Rows.Count <= 0)
                    return null;
                return data;
            }
            catch { }
            return null;
        }

        /// <summary>
        /// 将当前DataTable转换为特殊字符分隔的字符串
        /// </summary>
        /// <param name="table"></param>
        /// <param name="aes"></param>
        /// <param name="encrypt_columns"></param>
        /// <returns></returns>
        public static string toContentString(DataTable table, AESCryptoBase aes, ArrayList encrypt_columns)
        {
            string res = "";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                res += table.Columns[i].ColumnName + Convert.ToChar(31);
            }
            res = res.TrimEnd(Convert.ToChar(31)) + Convert.ToChar(30);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (arrayListContains(encrypt_columns, j))//加密列,做加密处理
                        res += aes.encrypt128(table.Rows[i][j].ToString()) + Convert.ToChar(31);
                    else//非加密列,常规处理
                        res += table.Rows[i][j].ToString() + Convert.ToChar(31);
                }
                res = res.TrimEnd(Convert.ToChar(31)) + Convert.ToChar(30);
            }
            res = res.TrimEnd(Convert.ToChar(30));
            return res;
        }

        public static DataTable fromContentString(string content_string, AESCryptoBase aes, ArrayList encrypt_columns)
        {
            try
            {
                if (content_string.Trim() == "")
                    return new DataTable();
                string[] rows = content_string.Split(Convert.ToChar(30));
                if (rows[0].Trim() == "")
                    return new DataTable();
                string[] headers = rows[0].Split(Convert.ToChar(31));
                DataTable res = new DataTable();
                for (int i = 0; i < headers.Length; i++)
                {
                    res.Columns.Add(headers[i]);
                }
                for (int i = 1; i < rows.Length; i++)
                {
                    try
                    {
                        string[] rowcontent = rows[i].Split(Convert.ToChar(31));
                        DataRow dr = res.NewRow();
                        for (int j = 0; j < rowcontent.Length; j++)
                        {
                            try
                            {
                                if (arrayListContains(encrypt_columns, j))
                                    dr[j] = aes.decrypt128(rowcontent[j]);
                                else
                                    dr[j] = rowcontent[j];
                            }
                            catch { }
                        }
                        res.Rows.Add(dr);
                    }
                    catch { }
                }
                return res;
            }
            catch { return new DataTable(); }
        }

        private static bool arrayListContains(ArrayList list, int item)
        {
            if (list == null || list.Count == 0)
                return false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ToString() == item.ToString())
                {
                    return true;
                }
            }
            return false;
        }
    }
}