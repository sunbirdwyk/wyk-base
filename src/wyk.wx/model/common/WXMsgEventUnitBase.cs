using wyk.basic;

namespace wyk.wx
{
    public class WXMsgEventUnitBase 
    {
        protected bool shouldWriteLog()
        {
            return true;
        }

        protected void writeLog(string content)
        {
            if (!shouldWriteLog())
                return;
            LogUtil.i(content);
        }
        public string process(string msg_content, params object[] parameters)
        {
            writeLog(msg_content);
            var msg = WXMsg.load(msg_content);
            switch (msg.msg_type)
            {
                case WXMsgType.@event:
                    return processForEvent(msg, parameters);
                default:
                    return processForCommon(msg, parameters);
            }
        }

        #region 事件处理(event)
        protected virtual string processForEvent(WXMsg msg, params object[] parameters)
        {
            return "";
        }
        #endregion

        #region 常规消息处理
        protected virtual string processForCommon(WXMsg msg, params object[] parameters)
        {
            return "";
        }
        #endregion
    }
}