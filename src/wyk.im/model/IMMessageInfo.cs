using System;
using System.Collections.Generic;
using wyk.basic;

namespace wyk.im
{
    /// <summary>
    /// 消息历史记录
    /// </summary>
    public class IMMessageInfo
    {
        public string message_id = "";
        public string from_user = "";
        public string to_user = "";
        public DateTime message_time = DateTimeUtil.defaultTime();
        public IMMessageType message_type = IMMessageType.Custom;
        public string content = "";
        public IMConversationType conversation_type = IMConversationType.Unknown;
        public IMSource source = IMSource.Unknown;
        public List<string> group_users = null;
        public IMProvider platform = IMProvider.Unknown;
        public DateTime enter_time = DateTimeUtil.defaultTime();
    }
}
