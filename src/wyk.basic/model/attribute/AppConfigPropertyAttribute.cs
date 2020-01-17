using System;

namespace wyk.basic
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class AppConfigPropertyAttribute : Attribute
    {
        public AppConfigPropertyAttribute() { }
    }
}
