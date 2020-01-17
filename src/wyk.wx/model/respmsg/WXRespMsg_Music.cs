namespace wyk.wx
{
    public class WXRespMsg_Music : WXRespMsg
    {
        [WXMsgProperty]
        public WXMsgItem_Music Music = new WXMsgItem_Music();

        public WXRespMsg_Music() { }
        public WXRespMsg_Music(string xml) : base(xml)
        {

        }
    }
}