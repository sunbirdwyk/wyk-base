using System.Reflection;

namespace wyk.basic
{
    public static class PropertyReferedExtention
    {
        public static bool isNullValue(this PropertyInfo property, object obj)
        {
            return property.GetValue(obj).isNull(property.PropertyType);
        }
    }
}
