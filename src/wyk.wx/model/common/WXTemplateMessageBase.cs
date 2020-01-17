using Newtonsoft.Json;
using System.Collections.Generic;

namespace wyk.wx
{
    public class WXTemplateMessageBase
    {
        /// <summary>
        /// 模板ID
        /// </summary>
        public string template_id = "";
        /// <summary>
        /// 目标用户openid
        /// </summary>
        public string openid = "";
        /// <summary>
        /// 点击后跳转的url
        /// </summary>
        public string url = "";

        /// <summary>
        /// 前置文字
        /// </summary>
        public string prefix = "";
        /// <summary>
        /// 关键词集合
        /// </summary>
        public List<string> keywords = new List<string>();
        /// <summary>
        /// 结尾文字
        /// </summary>
        public string postfix = "";

        /// <summary>
        /// 获取提交接口数据时post的参数内容, 需要子类实现
        /// </summary>
        /// <returns></returns>
        public virtual string getContent()
        {
            try
            {
                var pmd = new Dictionary<string, object>();
                pmd["touser"] = openid;
                pmd["template_id"] = template_id;
                pmd["url"] = url;
                pmd["topcolor"] = "#2B95E1";
                var data = new Dictionary<string, object>();
                var dataItem = new Dictionary<string, string>();
                dataItem["value"] = prefix;
                dataItem["color"] = "#333333";
                data["first"] = dataItem;
                for (int i = 0; i < keywords.Count; i++)
                {
                    dataItem = new Dictionary<string, string>();
                    dataItem["value"] = keywords[i];
                    dataItem["color"] = "#0d4b7a";
                    data["keyword" + (i + 1)] = dataItem;
                }
                dataItem = new Dictionary<string, string>();
                dataItem["value"] = postfix;
                dataItem["color"] = "#333333";
                data["remark"] = dataItem;
                pmd["data"] = data;
                return JsonConvert.SerializeObject(pmd);
            }
            catch { }
            return "";
        }
    }
}
