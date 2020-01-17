namespace wyk.wx
{
    public class WXRespMsg_Text : WXRespMsg
    {
        [WXMsgProperty]
        public string Content = "";

        public WXRespMsg_Text() { }
        public WXRespMsg_Text(string xml) : base(xml)
        {

        }
    }
}