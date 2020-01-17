namespace wyk.wx
{
    [WXMsgType(WXEventType.unsubscribe)]
    public class WXEvent_Unsubscribe : WXMsg
    {
        [WXMsgProperty]
        public string EventKey = "";

        public WXEvent_Unsubscribe() { }
        public WXEvent_Unsubscribe(string xml) : base(xml)
        {

        }
    }
}