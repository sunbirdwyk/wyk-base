using System;
using System.Data;
using System.Reflection;

namespace wyk.basic
{
    public class ObjectUtil
    {
        /// <summary>
        /// object获取相应类型的值
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="value">原始值</param>
        /// <returns>指定类型的值</returns>
        public static object objectForType(Type type, object value)
        {
            switch (type.Name.ToLower())
            {
                case "int":
                case "int32":
                case "integer":
                    try
                    {
                        return Convert.ToInt32(value);
                    }
                    catch { return 0; }
                case "uint":
                case "uint32":
                    try
                    {
                        return Convert.ToUInt32(value);
                    }
                    catch { return 0; }
                case "long":
                case "int64":
                    try
                    {
                        return Convert.ToInt64(value);
                    }
                    catch { return 0; }
                case "uint64":
                case "ulong":
                    try
                    {
                        return Convert.ToUInt64(value);
                    }
                    catch { return 0; }
                case "byte":
                    try
                    {
                        return Convert.ToByte(value);
                    }
                    catch { return 0; }
                case "short":
                case "int16":
                    try
                    {
                        return Convert.ToInt16(value);
                    }
                    catch { return 0; }
                case "uint16":
                case "ushort":
                    try
                    {
                        return Convert.ToUInt16(value);
                    }
                    catch { return 0; }
                case "double":
                    try
                    {
                        return Convert.ToDouble(value);
                    }
                    catch { return 0; }
                case "float":
                    try
                    {
                        return (float)Convert.ToDouble(value);
                    }
                    catch { return 0; }
                case "char":
                    try
                    {
                        return Convert.ToChar(value);
                    }
                    catch { return ' '; }
                case "string":
                    try
                    {
                        return Convert.ToString(value);
                    }
                    catch { return ""; }
                case "bool":
                case "bit":
                case "boolean":
                    try
                    {
                        return Convert.ToBoolean(value);
                    }
                    catch { return false; }
                case "datetime":
                    try
                    {
                        return Convert.ToDateTime(value);
                    }
                    catch { return DateTimeUtil.defaultTime(); }
                case "decimal":
                    try
                    {
                        return Convert.ToDecimal(value);
                    }
                    catch { return 0; }
                default:
                    return value;
            }
        }

        /// <summary>
        /// 判断object是否为空值(包含0, 空字符串)
        /// </summary>
        /// <param name="type">object类型</param>
        /// <param name="obj">原始值</param>
        /// <returns>是否为空值</returns>
        public static bool isNull(Type type, object obj)
        {
            if (obj == null)
                return true;
            switch (type.Name.ToLower())
            {
                case "int":
                case "int32":
                case "integer":
                case "uint":
                case "uint32":
                case "long":
                case "int64":
                case "uint64":
                case "ulong":
                case "byte":
                case "short":
                case "int16":
                case "uint16":
                case "ushort":
                case "double":
                case "float":
                    try
                    {
                        var value = Convert.ToDouble(obj);
                        if (value == 0)
                            return true;
                    }
                    catch { return true; }
                    return false;
                case "char":
                    try
                    {
                        var value = Convert.ToChar(obj);
                        if (value == ' ')
                            return true;
                    }
                    catch { return true; }
                    return false;
                case "string":
                    try
                    {
                        var value = Convert.ToString(obj);
                        if (value == "")
                            return true;
                    }
                    catch { return true; }
                    return false;
                case "bool":
                case "bit":
                case "boolean":
                    try
                    {
                        var value = Convert.ToBoolean(obj);
                        if (value == false)
                            return true;
                    }
                    catch { return true; }
                    return false;
                case "datetime":
                    try
                    {
                        var value = Convert.ToDateTime(obj);
                        if (value.isDefault())
                            return true;
                    }
                    catch { return true; }
                    return false;
                case "decimal":
                    try
                    {
                        var value = Convert.ToDecimal(obj);
                        if (value == 0)
                            return true;
                    }
                    catch { return true; }
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 获取某个类的实例并通过DataRow初始化值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datarow"></param>
        /// <returns></returns>
        public static T objectWithData<T>(DataRow datarow)
        {
            var fields = typeof(T).GetFields();
            var props = typeof(T).GetProperties();
            return objectWithData<T>(datarow, fields, props);
        }

        /// <summary>
        /// 获取某个类的实例并通过DataRow初始化值, 提供此类所包含的所有fields和properties 以提高效率
        /// 此方法通常用于批量获取实例时使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datarow"></param>
        /// <param name="fields"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static T objectWithData<T>(DataRow datarow, FieldInfo[] fields, PropertyInfo[] properties)
        {
            try
            {
                T obj = (T)Activator.CreateInstance(typeof(T));
                obj.setValues(datarow, fields, properties);
                return obj;
            }
            catch { }
            return default(T);
        }
    }
}
