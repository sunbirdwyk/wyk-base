using System;
using System.Data;
using System.Reflection;

namespace wyk.basic
{
    public static class ObjectReferedExtention
    {
        /// <summary>
        /// 判断当前object是否为空值(包括0,空字符串等)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool isNull(this object obj, Type type)
        {
            return ObjectUtil.isNull(type, obj);
        }

        /// <summary>
        /// 判断当前object是否为空值(包括0,空字符串等)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool isNull(this object obj)
        {
            if (obj == null)
                return true;
            return ObjectUtil.isNull(obj.GetType(), obj);
        }

        /// <summary>
        /// 获取object指定类型的值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object objectForType(this object obj, Type type)
        {
            return ObjectUtil.objectForType(type, obj);
        }

        /// <summary>
        /// 获取某个实例的某个field值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static object getValue(this object obj, FieldInfo field)
        {
            if (field == null || obj == null)
                return null;
            return field.GetValue(obj);
        }

        /// <summary>
        /// 获取某个实例的property值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static object getValue(this object obj, PropertyInfo property)
        {
            if (property == null || obj == null)
                return null;
            return property.GetValue(obj);
        }

        /// <summary>
        /// 根据名称获取某个实例的某项属性(field/property)值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value_name">属性名称</param>
        /// <returns></returns>
        public static object getValue(this object obj, string value_name)
        {
            if (value_name.isNull())
                return null;
            try
            {
                var fi = obj.GetType().GetField(value_name);
                if (fi != null)
                    return obj.getValue(fi);
            }
            catch { }
            try
            {
                var pi = obj.GetType().GetProperty(value_name);
                if (pi != null)
                    return obj.getValue(pi);
            }
            catch { }
            return null;
        }

        /// <summary>
        /// 为实例设置某个field值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        public static void setValue(this object obj, FieldInfo field, object value)
        {
            if (field == null || obj == null)
                return;
            try
            {
                field.SetValue(obj, value.objectForType(field.FieldType));
            }
            catch { }
        }

        /// <summary>
        /// 为实例设置某个property值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        public static void setValue(this object obj, PropertyInfo property, object value)
        {
            if (property == null || obj == null)
                return;
            try
            {
                property.SetValue(obj, value.objectForType(property.PropertyType));
            }
            catch { }
        }

        /// <summary>
        /// 为某个实例设置某项属性(field/property)值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value_name">属性名称</param>
        /// <param name="value"></param>
        public static void setValue(this object obj, string value_name, object value)
        {
            if (value_name.isNull())
                return;
            var fi = obj.GetType().GetField(value_name);
            if (fi != null)
                obj.setValue(fi, value);
            var pi = obj.GetType().GetProperty(value_name);
            if (pi != null)
                obj.setValue(pi, value);
        }

        /// <summary>
        /// 为实例设置DataRow中的所有值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="datarow"></param>
        public static void setValues(this object obj, DataRow datarow)
        {
            var fields = obj.GetType().GetFields();
            var props = obj.GetType().GetProperties();
            obj.setValues(datarow, fields, props);
        }

        /// <summary>
        /// 为实例设置DataRow中的所有值, 提供此类所包含的所有fields和properties 以提高效率
        /// 此方法通常用于批量设置时使用
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="datarow"></param>
        /// <param name="fields"></param>
        /// <param name="properties"></param>
        public static void setValues(this object obj, DataRow datarow, FieldInfo[] fields, PropertyInfo[] properties)
        {
            foreach (var f in fields)
            {
                try
                {
                    obj.setValue(f, datarow[f.Name]);
                }
                catch { }
            }
            foreach (var p in properties)
            {
                try
                {
                    obj.setValue(p, datarow[p.Name]);
                }
                catch { }
            }
        }
    }
}
