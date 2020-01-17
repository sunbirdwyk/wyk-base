using System;

namespace wyk.wx
{
    public class WXMsgTypeAttribute : Attribute
    {
        public WXMsgType msg_type = WXMsgType.Unknown;
        public WXEventType event_type = WXEventType.Unknown;


        public WXMsgTypeAttribute(WXMsgType msg_type)
        {
            this.msg_type = msg_type;
            event_type = WXEventType.Unknown;
        }

        public WXMsgTypeAttribute(WXEventType event_type)
        {
            msg_type = WXMsgType.@event;
            this.event_type = event_type;
        }
    }
}