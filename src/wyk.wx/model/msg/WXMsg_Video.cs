namespace wyk.wx
{
    [WXMsgType(WXMsgType.video)]
    public class WXMsg_Video : WXMsg
    {
        [WXMsgProperty]
        public string MediaId = "";

        [WXMsgProperty]
        public string ThumbMediaId = "";

        [WXMsgProperty]
        public long MsgId = 0;

        public WXMsg_Video() { }
        public WXMsg_Video(string xml) : base(xml)
        {

        }
    }
}