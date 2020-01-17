using System.Collections.Generic;
using System.Reflection;
using wyk.basic;

namespace wyk.wx
{
    /// <summary>
    /// 微信返回的xml格式的结果基类, 通常为微信支付相关
    /// </summary>
    public class WXTradeResponseBase
    {
        protected const string CODE_SUCCESS = "SUCCESS";
        protected const string CODE_FAIL = "FAIL";

        /// <summary>
        /// 返回状态码
        /// SUCCESS/FAIL   此字段是通信标识，非交易标识，交易是否成功需要查看后续字段来判断
        /// </summary>
        public string return_code = "";
        /// <summary>
        /// 返回信息
        /// 当return_code为FAIL时返回信息为错误原因 ，例如: 签名失败 / 参数格式校验错误
        /// </summary>
        public string return_msg = "";
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string app_id = "";
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id = "";
        /// <summary>
        /// 设备号
        /// 自定义参数，可以为请求支付的终端设备号等
        /// </summary>
        public string device_info = "";
        /// <summary>
        /// 随机字符串
        /// 微信返回的随机字符串
        /// </summary>
        public string nonce_str = "";
        /// <summary>
        /// 客户openid
        /// </summary>
        public string openid = "";
        /// <summary>
        /// 签名
        /// 微信返回的签名值
        /// </summary>
        public string sign = "";
        /// <summary>
        /// 业务结果
        /// SUCCESS/FAIL
        /// </summary>
        public string result_code = "";
        /// <summary>
        /// 错误代码
        /// 当result_code为FAIL时返回错误代码
        /// </summary>
        public string err_code = "";
        /// <summary>
        /// 错误代码描述
        /// 当result_code为FAIL时返回错误描述，详细参见下文错误列表
        /// </summary>
        public string err_code_des = "";

        private Dictionary<string, string> content = new Dictionary<string, string>();
        public WXTradeResponseBase() { }
        public WXTradeResponseBase(string content_string)
        {
            setContentString(content_string);
        }

        public void setContentString(string content_string)
        {
            content = WXUtil.fromXml(content_string);
            initProperties();
        }

        protected string getValue(string key)
        {
            try
            {
                return content[key];
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 将字典中的数据装载到各个field中
        /// </summary>
        public void initProperties()
        {
            FieldInfo[] fields = this.GetType().GetFields();
            foreach (FieldInfo fi in fields)
            {
                try
                {
                    this.setValue(fi, content[fi.Name]);
                }
                catch { }
            }
        }

        /// <summary>
        /// 判断结果是否为成功
        /// </summary>
        /// <returns></returns>
        public virtual bool isSuccess()
        {
            if (return_code != CODE_SUCCESS)
                return false;
            if (result_code != CODE_SUCCESS)
                return false;
            return true;
        }

        public virtual string errorMessage()
        {
            if (return_code != CODE_SUCCESS)
                return return_msg + "(Code:" + return_code + ")";
            if (result_code != CODE_SUCCESS)
                return err_code_des + "(Code:" + err_code + ")";
            return "";
        }
    }
}