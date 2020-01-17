namespace wyk.wx
{
    [WXMsgType(WXMsgType.link)]
    public class WXMsg_Link : WXMsg
    {
        [WXMsgProperty]
        public string Title = "";

        [WXMsgProperty]
        public string Description = "";

        [WXMsgProperty]
        public string Url = "";

        [WXMsgProperty]
        public long MsgId = 0;

        public WXMsg_Link() { }
        public WXMsg_Link(string xml) : base(xml)
        {

        }
    }
}