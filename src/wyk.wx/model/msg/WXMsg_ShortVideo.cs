namespace wyk.wx
{
    [WXMsgType(WXMsgType.shortvideo)]
    public class WXMsg_ShortVideo : WXMsg
    {
        [WXMsgProperty]
        public string MediaId = "";

        [WXMsgProperty]
        public string ThumbMediaId = "";

        [WXMsgProperty]
        public long MsgId = 0;

        public WXMsg_ShortVideo() { }
        public WXMsg_ShortVideo(string xml) : base(xml)
        {

        }
    }
}