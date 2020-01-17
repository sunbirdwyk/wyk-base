namespace wyk.wx
{
    public class WXMsgItem_Music : WXMsgSubItem
    {
        [WXMsgProperty]
        public string Title = "";
        [WXMsgProperty]
        public string Description = "";
        [WXMsgProperty]
        public string MusicUrl = "";
        [WXMsgProperty]
        public string HQMusicUrl = "";
        [WXMsgProperty]
        public string ThumbMediaId = "";
    }
}