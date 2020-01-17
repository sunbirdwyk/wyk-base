namespace wyk.wx
{
    [WXMsgType(WXEventType.subscribe)]
    public class WXEvent_Subscribe : WXMsg
    { 
        [WXMsgProperty]
        public string EventKey = "";

        [WXMsgProperty]
        public string Ticket = "";

        public WXEvent_Subscribe() { }
        public WXEvent_Subscribe(string xml) : base(xml)
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