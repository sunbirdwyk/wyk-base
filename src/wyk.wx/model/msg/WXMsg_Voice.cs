namespace wyk.wx
{
    [WXMsgType(WXMsgType.voice)]
    public class WXMsg_Voice : WXMsg
    {
        [WXMsgProperty]
        public string MediaId = "";

        [WXMsgProperty]
        public string Format = "";
        //注: 开通语音识别后，用户每次发送语音给公众号时，微信会在推送的语音消息XML数据包中，增加一个Recognition字段
        [WXMsgProperty]
        public string Recognition = ""; //语音识别结果(UTF-8编码)

        [WXMsgProperty]
        public long MsgId = 0;

        public WXMsg_Voice() { }
        public WXMsg_Voice(string xml) : base(xml)
        {

        }
    }
}