namespace wyk.wx
{
    public class WXRespMsg_Image : WXRespMsg
    {
        [WXMsgProperty]
        public WXMsgItem_Image Image = new WXMsgItem_Image();

        public WXRespMsg_Image() { }
        public WXRespMsg_Image(string xml) : base(xml)
        {

        }
    }
}