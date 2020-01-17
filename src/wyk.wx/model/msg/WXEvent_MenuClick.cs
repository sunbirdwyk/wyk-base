namespace wyk.wx
{
    [WXMsgType(WXEventType.CLICK)]
    public class WXEvent_MenuClick : WXMsg
    {
        [WXMsgProperty]
        public string EventKey = "";

        public WXEvent_MenuClick() { }
        public WXEvent_MenuClick(string xml) : base(xml)
        {

        }
    }
}