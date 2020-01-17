using System;

namespace wyk.api
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ApiInfoBase : Attribute
    {
        public string type = "";
        public string description = "";
        public ApiInfoBase()
        {
        }
        public ApiInfoBase(string type, string description)
        {
            this.type = type;
            this.description = description;
        }
    }
}