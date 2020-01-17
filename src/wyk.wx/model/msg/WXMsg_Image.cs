namespace wyk.wx
{
    [WXMsgType(WXMsgType.image)]
    public class WXMsg_Image : WXMsg
    {
        [WXMsgProperty]
        public string PicUrl = "";

        [WXMsgProperty]
        public string MediaId = "";

        [WXMsgProperty]
        public long MsgId = 0;

        public WXMsg_Image() { }
        public WXMsg_Image(string xml) : base(xml)
        {

        }
    }
}