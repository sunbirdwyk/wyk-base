namespace wyk.api.fw
{
    public static class ApiHeaderInfoExtentions
    {
        public static void loadFromRequest(this ApiHeaderInfo info, System.Web.HttpRequest request)
        {
            try
            {
                foreach (string token in request.Headers.GetValues("token"))
                {
                    info.token = token;
                    if (token != "")
                        break;
                }
            }
            catch { }
            try
            {
                foreach (string device in request.Headers.GetValues("device"))
                {
                    info.device = device;
                    if (device != "")
                        break;
                }
            }
            catch { }
            try
            {
                info.user_agent = request.UserAgent.ToString();
            }
            catch { }
        }
    }
}