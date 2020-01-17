using Newtonsoft.Json;
using System.Collections.Generic;

namespace wyk.wx
{
    /// <summary>
    /// get参数传递
    /// </summary>
    public class WXGetBase
    {
        public Dictionary<string, string> parameters = new Dictionary<string, string>();

        public void clear()
        {
            parameters = new Dictionary<string, string>();
        }

        public void set(string key, string value)
        {
            parameters[key] = value;
        }

        public string getContent()
        {
            return JsonConvert.SerializeObject(parameters);
        }
    }
}
