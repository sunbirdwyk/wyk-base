using Newtonsoft.Json;
using System.Collections.Generic;

namespace wyk.wx
{
    /// <summary>
    /// 以json为主体的post参数传递
    /// </summary>
    public class WXPostBase
    {
        public Dictionary<string, object> parameters = new Dictionary<string, object>();

        public void clear()
        {
            parameters = new Dictionary<string, object>();
        }

        public void set(string key, object value)
        {
            parameters[key] = value;
        }

        public string getContent()
        {
            return JsonConvert.SerializeObject(parameters);
        }
    }
}
