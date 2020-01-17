namespace wyk.wx
{
    public class WXMsgItem_News : WXMsgSubItem
    {
        [WXMsgProperty]
        public string Title = "";
        [WXMsgProperty]
        public string Description = "";
        [WXMsgProperty]
        public string PicUrl = "";
        [WXMsgProperty]
        public string Url = "";
    }
}