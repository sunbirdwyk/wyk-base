using System.Collections.Generic;

namespace wyk.sms
{
    public class SMSResponseList
    {
        /// <summary>
        /// 代码, 0表示成功, 其他表示错误
        /// </summary>
        public int code = 0;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string msg = "";
        /// <summary>
        /// 总条数
        /// </summary>
        public int total_count = 0;
        /// <summary>
        /// 总金额
        /// </summary>
        public double total_fee = 0;
        /// <summary>
        /// 总金额计量单位(货币类型) 如 RMB
        /// </summary>
        public string unit = "";

        public List<SMSResponse> responses = new List<SMSResponse>();

        public SMSResponseList() { }

        public static SMSResponseList errorNotSupported()
        {
            return custom(9000, "当前供应商暂不支持此方式, 请与软件供应商联系");
        }
        public static SMSResponseList errorNotInitialized()
        {
            return custom(9001, "短信功能还没有初始化, 暂时不能使用");
        }
        public static SMSResponseList errorDataFormatError()
        {
            return custom(9002, "返回的数据格式有误, 请与软件供应商联系");
        }

        public static SMSResponseList custom(int code, string msg)
        {
            var res = new SMSResponseList();
            res.code = code;
            res.msg = msg;
            return res;
        }
    }
}
