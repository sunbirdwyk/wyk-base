using System.Reflection;

namespace wyk.basic
{
    public static class FieldInfoReferedExtention
    {
        /// <summary>
        /// 判断当前field的值是否为空
        /// </summary>
        /// <param name="field"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool isNullValue(this FieldInfo field, object obj)
        {
            return field.GetValue(obj).isNull(field.FieldType);
        }
    }
}
