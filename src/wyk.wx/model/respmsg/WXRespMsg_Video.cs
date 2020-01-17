namespace wyk.wx
{
    public class WXRespMsg_Video : WXRespMsg
    {
        [WXMsgProperty]
        public WXMsgItem_Video Video = new WXMsgItem_Video();

        public WXRespMsg_Video() { }
        public WXRespMsg_Video(string xml) : base(xml)
        {

        }
    }
}