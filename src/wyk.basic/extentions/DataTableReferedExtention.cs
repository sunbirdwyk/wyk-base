using System.Collections;
using System.Data;

namespace wyk.basic
{
    public static class DataTableReferedExtention
    {
        /// <summary>
        /// 将当前DataTable转为XML格式的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string toXML(this DataTable data)
        {
            return DataTableUtil.toXML(data);
        }

        /// <summary>
        /// 将当前DataTable转为XML格式的字符串(简), 此方式生成的字符串长度较短
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string toXMLSimple(this DataTable data)
        {
            return DataTableUtil.toXMLSimple(data);
        }

        /// <summary>
        /// 将当前DataTable转为HTML格式的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="invisible_columns"></param>
        /// <returns></returns>
        public static string toHTML(this DataTable data, string invisible_columns)
        {
            return DataTableUtil.toHTML(data, invisible_columns);
        }
        /// <summary>
        /// 将当前DataTable转为HTML格式的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string toHTML(this DataTable data)
        {
            return DataTableUtil.toHTML(data, "");
        }

        /// <summary>
        /// 将当前DataTable转换为特殊字符分隔的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="aes"></param>
        /// <param name="encrypt_columns"></param>
        /// <returns></returns>
        public static string toContentString(this DataTable data, AESCryptoBase aes, ArrayList encrypt_columns)
        {
            return DataTableUtil.toContentString(data, aes, encrypt_columns);
        }

        /// <summary>
        /// 将当前DataTable转换为特殊字符分隔的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string toContentString(this DataTable data)
        {
            return DataTableUtil.toContentString(data, null, new ArrayList());
        }
    }
}