using System.Collections.Generic;

namespace wyk.api
{
    /// <summary>
    /// 用于显示的Api Model 信息(详情)
    /// </summary>
    public class ApiSpecModel : ApiSpecModelBase
    {
        /// <summary>
        /// 所属控制器名称
        /// </summary>
        public string controller_name = "";
        /// <summary>
        /// 登录信息(是否需要登录, 可接受的账户类型等)
        /// </summary>
        public string login_info = "";
        /// <summary>
        /// URI 参数列表
        /// </summary>
        public List<ApiSpecParameter> uri_parameters = new List<ApiSpecParameter>();
        /// <summary>
        /// POST 时 Body参数说明
        /// </summary>
        public string request_description = "";
        /// <summary>
        /// POST 时 Body参数列表
        /// </summary>
        public List<ApiSpecParameter> request_body_parameters = new List<ApiSpecParameter>();
        /// <summary>
        /// Request 示例
        /// </summary>
        public string request_sample = "";
        /// <summary>
        /// 返回信息说明
        /// </summary>
        public string return_description = "";
    }
}
