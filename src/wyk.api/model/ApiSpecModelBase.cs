using System.Drawing;
using wyk.basic;

namespace wyk.api
{
    /// <summary>
    /// 用于显示的Api Model信息(简易, 用于列表显示)
    /// </summary>
    public class ApiSpecModelBase
    {
        /// <summary>
        /// 接口Model的ID(Api的friendly id)
        /// </summary>
        public string id = "";
        /// <summary>
        /// 调用方法(GET/POST等)
        /// </summary>
        public string method = "";
        /// <summary>
        /// 接口名称(简)
        /// </summary>
        public string name = "";
        /// <summary>
        /// 相对路径(简)
        /// </summary>
        public string relative_path = "";
        /// <summary>
        /// 说明
        /// </summary>
        public string description = "";
        /// <summary>
        /// 相对路径的前缀
        /// </summary>
        public string path_prefix = "";

        /// <summary>
        /// 获取全路径
        /// </summary>
        /// <param name="scheme">协议(http/https)</param>
        /// <param name="authority">主机名和端口号</param>
        /// <returns></returns>
        public string fullUrl(string scheme, string authority)
        {
            return string.Format("{0}://{1}/{2}{3}", scheme, authority, path_prefix, relative_path);
        }


        public string methodColorString()
        {
            switch (method.ToUpper())
            {
                case "GET":
                    return "#068950";
                case "POST":
                    return "#ba2424";
                case "PUT":
                    return "#0842cc";
                case "DELETE":
                    return "#d36304";
                default:
                    return "#000000";
            }
        }

        public Color methodColor()
        {
            return methodColorString().color();
        }
    }
}
