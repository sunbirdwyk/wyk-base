namespace wyk.wx
{
    [WXMsgType(WXMsgType.location)]
    public class WXMsg_Location : WXMsg
    {
        [WXMsgProperty]
        public double Location_X = 0;

        [WXMsgProperty]
        public double Location_Y = 0;

        [WXMsgProperty]
        public double Scale = 0;

        [WXMsgProperty]
        public string Label = "";

        [WXMsgProperty]
        public long MsgId = 0;

        public WXMsg_Location() { }
        public WXMsg_Location(string xml) : base(xml)
        {

        }
    }
}