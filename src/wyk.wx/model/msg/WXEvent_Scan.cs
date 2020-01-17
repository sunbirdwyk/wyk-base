namespace wyk.wx
{
    [WXMsgType(WXEventType.SCAN)]
    public class WXEvent_Scan : WXMsg
    {
        [WXMsgProperty]
        public string EventKey = "";

        [WXMsgProperty]
        public string Ticket = "";

        public WXEvent_Scan() { }
        public WXEvent_Scan(string xml) : base(xml)
        {

        }

        public string scene()
        {
            if (EventKey.StartsWith("qrscene_"))
                return EventKey.Substring(8);
            return EventKey;
        }
    }
}