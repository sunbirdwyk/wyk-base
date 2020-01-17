namespace wyk.wx
{
    [WXMsgType(WXEventType.VIEW)]
    public class WXEvent_MenuView : WXMsg
    {
        [WXMsgProperty]
        public string EventKey = "";

        public WXEvent_MenuView() { }
        public WXEvent_MenuView(string xml) : base(xml)
        {

        }
    }
}