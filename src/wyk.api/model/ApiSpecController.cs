using System.Collections.Generic;

namespace wyk.api
{
    /// <summary>
    /// 用于显示的Api Controller 信息
    /// </summary>
    public class ApiSpecController
    {
        /// <summary>
        /// 控制器所属接口类型
        /// </summary>
        public string type = "";
        /// <summary>
        /// 控制器名称(不带Controller)
        /// </summary>
        public string name = "";
        /// <summary>
        /// 控制器的显示说明
        /// </summary>
        public string display = "";
        /// <summary>
        /// 接口Model列表(简)
        /// </summary>
        public List<ApiSpecModel> models = new List<ApiSpecModel>();
    }
}
