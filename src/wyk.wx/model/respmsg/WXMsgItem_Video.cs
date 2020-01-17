namespace wyk.wx
{
    public class WXMsgItem_Video : WXMsgSubItem
    {
        [WXMsgProperty]
        public string MediaId = "";
        [WXMsgProperty]
        public string Title = "";
        [WXMsgProperty]
        public string Description = "";
    }
}