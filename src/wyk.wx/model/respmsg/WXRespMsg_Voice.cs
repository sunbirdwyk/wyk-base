namespace wyk.wx
{
    public class WXRespMsg_Voice : WXRespMsg
    {
        [WXMsgProperty]
        public WXMsgItem_Voice Voice = new WXMsgItem_Voice();

        public WXRespMsg_Voice() { }
        public WXRespMsg_Voice(string xml) : base(xml)
        {

        }
    }
}