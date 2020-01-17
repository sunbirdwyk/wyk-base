namespace wyk.wx
{
    [WXMsgType(WXMsgType.text)]
    public class WXMsg_Text : WXMsg
    {
        [WXMsgProperty]
        public string Content = "";

        [WXMsgProperty]
        public long MsgId = 0;

        public WXMsg_Text() { }
        public WXMsg_Text(string xml) : base(xml)
        {

        }
    }
}