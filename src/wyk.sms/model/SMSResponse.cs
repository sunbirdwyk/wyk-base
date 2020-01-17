namespace wyk.sms
{
    /// <summary>
    /// 发送短信后实时返回的信息(单条短信), 内容为发送信息的状态
    /// </summary>
    public class SMSResponse
    {
        /// <summary>
        /// 代码, 0表示成功, 其他表示出错
        /// </summary>
        public int code = 0;
        /// <summary>
        /// 消息, 代码不为0时为错误信息
        /// </summary>
        public string msg = "";
        /// <summary>
        /// 发送成功短信数
        /// </summary>
        public int count = 0;
        /// <summary>
        /// 发送费用
        /// </summary>
        public double fee = 0;
        /// <summary>
        /// 费用的计量单位(货币类型), 如 RMB
        /// </summary>
        public string unit = "";
        /// <summary>
        /// 账户余额
        /// </summary>
        public double balance = 0;
        /// <summary>
        /// 发送目标手机号
        /// </summary>
        public string mobile = "";
        /// <summary>
        /// 短信ID
        /// </summary>
        public string sid = "";

        public SMSResponse() { }

        public static SMSResponse errorNotSupported()
        {
            return custom(9000, "当前供应商暂不支持此方式, 请与软件供应商联系");
        }
        public static SMSResponse errorNotInitialized()
        {
            return custom(9001, "短信功能还没有初始化, 暂时不能使用");
        }
        public static SMSResponse errorDataFormatError()
        {
            return custom(9002, "返回的数据格式有误, 请与软件供应商联系");
        }

        public static SMSResponse custom(int code, string msg)
        {
            var res = new SMSResponse();
            res.code = code;
            res.msg = msg;
            return res;
        }
    }
}
