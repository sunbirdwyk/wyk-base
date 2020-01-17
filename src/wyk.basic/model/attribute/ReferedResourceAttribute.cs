using System;

namespace wyk.basic
{
    /// <summary>
    /// 指示与当前标签主体相关的资源
    /// </summary>
    public class ReferedResourceAttribute : Attribute
    {
        public string name = "";

        public ReferedResourceAttribute(string name)
        {
            this.name = name;
        }
    }
}