using Microsoft.AspNetCore.Http;
using System.Net.Http;
using wyk.basic;

namespace wyk.api
{
    /// <summary>
    /// 从request的header中获取的api信息
    /// </summary>
    public class ApiHeaderInfo
    {
        public string token = "";
        public string device = "";
        public string user_agent = "";

        public ApiHeaderInfo() { }
        public ApiHeaderInfo(string token, string device, string user_agent)
        {
            this.token = token;
            this.device = device;
            this.user_agent = user_agent;
        }

        public void loadFromRequest(HttpRequestMessage request)
        {
            try
            {
                foreach (string token in request.Headers.GetValues("token"))
                {
                    this.token = token;
                    if (!token.isNull())
                        break;
                }
            }
            catch { }
            try
            {
                foreach (string device in request.Headers.GetValues("device"))
                {
                    this.device = device;
                    if (!device.isNull())
                        break;
                }
            }
            catch { }
            try
            {
                user_agent = request.Headers.UserAgent.ToString();
            }
            catch { }
        }

        public void loadFromRequest(HttpRequest request)
        {
            try
            {
                foreach (string token in request.Headers["token"])
                {
                    this.token = token;
                    if (token != "")
                        break;
                }
            }
            catch { }
            try
            {
                foreach (string device in request.Headers["device"])
                {
                    this.device = device;
                    if (device != "")
                        break;
                }
            }
            catch { }
            try
            {
                user_agent = request.Headers["UserAgent"];
            }
            catch { }
        }

        public static ApiHeaderInfo load(HttpRequestMessage request)
        {
            ApiHeaderInfo info = new ApiHeaderInfo();
            info.loadFromRequest(request);
            return info;
        }

        public static ApiHeaderInfo load(HttpRequest request)
        {
            ApiHeaderInfo info = new ApiHeaderInfo();
            info.loadFromRequest(request);
            return info;
        }
    }
}
