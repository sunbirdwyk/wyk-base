using System;

namespace wyk.basic
{
    public class ReferedCodeAttribute : Attribute
    {
        public string code = "";

        public ReferedCodeAttribute(string code)
        {
            this.code = code;
        }
    }
}