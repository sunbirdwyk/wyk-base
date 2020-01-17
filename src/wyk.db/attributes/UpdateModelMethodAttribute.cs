using System;

namespace wyk.db
{
    /// <summary>
    /// 为UpdateModel的属性设置标识
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class UpdateModelMethodAttribute : Attribute
    {
        /// <summary>
        /// 赋值类型
        /// </summary>
        public UpdateModelMethod method = UpdateModelMethod.Always;

        public UpdateModelMethodAttribute() { }
        public UpdateModelMethodAttribute(UpdateModelMethod method)
        {
            this.method = method;
        }
    }
}
