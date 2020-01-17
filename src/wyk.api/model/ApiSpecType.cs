using System.Collections.Generic;

namespace wyk.api
{
    public class ApiSpecType
    {
        public string name = "";

        public List<ApiSpecController> controllers = new List<ApiSpecController>();

        public ApiSpecType() { }
        public ApiSpecType(string name)
        {
            this.name = name;
        }
    }
}
