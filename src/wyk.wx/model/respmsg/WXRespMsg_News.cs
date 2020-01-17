using System.Collections.Generic;

namespace wyk.wx
{
    public class WXRespMsg_News : WXRespMsg
    {
        [WXMsgProperty]
        public int ArticleCount = 0;

        [WXMsgProperty]
        public List<WXMsgItem_News> Articles = new List<WXMsgItem_News>();

        public WXRespMsg_News() { }
        public WXRespMsg_News(string xml) : base(xml)
        {

        }
    }
}