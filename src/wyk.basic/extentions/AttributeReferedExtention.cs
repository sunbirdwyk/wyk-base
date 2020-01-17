using System;
using System.Reflection;

namespace wyk.basic
{
    public static class AttributeReferedExtention
    {
        #region Enum
        /// <summary>
        /// 获取attribute(Enum)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <returns></returns>
        public static T getAttribute<T>(this Enum en)
        {
            try
            {
                var mil = en.GetType().GetMember(en.ToString());
                if (mil != null && mil.Length > 0)
                {
                    var attr = mil[0].getAttribute<T>();
                    return attr;
                }
            }
            catch { }
            return default;
        }
        #endregion

        #region FieldInfo
        /// <summary>
        /// 获取attribute(FieldInfo)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="check_base">是否检查基类, 开启此选项后, 可以通过基类查到继承后的Attribute</param>
        /// <returns></returns>
        public static T getAttribute<T>(this FieldInfo field, bool check_base)
        {
            object[] attrs;
            if (check_base)
            {
                attrs = field.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var type = attr.GetType();
                    if (type == typeof(T) || type.IsSubclassOf(typeof(T)))
                        return (T)attr;
                }
            }
            else
            {
                var attr = field.GetCustomAttributes(typeof(T), true);
                if (attr != null && attr.Length > 0)
                    return (T)attr[0];
            }
            return default;
        }

        /// <summary>
        /// 获取attribute(FieldInfo)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        public static T getAttribute<T>(this FieldInfo field)
        {
            return field.getAttribute<T>(false);
        }
        #endregion

        #region PropertyInfo
        /// <summary>
        /// 获取attribute(PropertyInfo)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <param name="check_base">是否检查基类, 开启此选项后, 可以通过基类查到继承后的Attribute</param>
        /// <returns></returns>
        public static T getAttribute<T>(this PropertyInfo property, bool check_base)
        {
            object[] attrs;
            if (check_base)
            {
                attrs = property.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var type = attr.GetType();
                    if (type == typeof(T) || type.IsSubclassOf(typeof(T)))
                        return (T)attr;
                }
            }
            else
            {
                var attr = property.GetCustomAttributes(typeof(T), true);
                if (attr != null && attr.Length > 0)
                    return (T)attr[0];
            }
            return default;
        }

        /// <summary>
        /// 获取attribute(PropertyInfo)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        public static T getAttribute<T>(this PropertyInfo property)
        {
            return property.getAttribute<T>(false);
        }
        #endregion

        #region MethodInfo
        /// <summary>
        /// 获取attribute(MethodInfo)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <param name="check_base">是否检查基类, 开启此选项后, 可以通过基类查到继承后的Attribute</param>
        /// <returns></returns>
        public static T getAttribute<T>(this MethodInfo method, bool check_base)
        {
            object[] attrs;
            if (check_base)
            {
                attrs = method.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var type = attr.GetType();
                    if (type == typeof(T) || type.IsSubclassOf(typeof(T)))
                        return (T)attr;
                }
            }
            else
            {
                var attr = method.GetCustomAttributes(typeof(T), true);
                if (attr != null && attr.Length > 0)
                    return (T)attr[0];
            }
            return default;
        }

        /// <summary>
        /// 获取attribute(MethodInfo)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        public static T getAttribute<T>(this MethodInfo method)
        {
            return method.getAttribute<T>(false);
        }
        #endregion

        #region MemberInfo
        /// <summary>
        /// 获取attribute(MemberInfo)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <param name="check_base">是否检查基类, 开启此选项后, 可以通过基类查到继承后的Attribute</param>
        /// <returns></returns>
        public static T getAttribute<T>(this MemberInfo member, bool check_base)
        {
            object[] attrs;
            if (check_base)
            {
                attrs = member.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var type = attr.GetType();
                    if (type == typeof(T) || type.IsSubclassOf(typeof(T)))
                        return (T)attr;
                }
            }
            else
            {
                var attr = member.GetCustomAttributes(typeof(T), true);
                if (attr != null && attr.Length > 0)
                    return (T)attr[0];
            }
            return default;
        }

        /// <summary>
        /// 获取attribute(MemberInfo)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <returns></returns>
        public static T getAttribute<T>(this MemberInfo member)
        {
            return member.getAttribute<T>(false);
        }
        #endregion

        #region ParameterInfo
        /// <summary>
        /// 获取attribute(ParameterInfo)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        /// <param name="check_base">是否检查基类, 开启此选项后, 可以通过基类查到继承后的Attribute</param>
        /// <returns></returns>
        public static T getAttribute<T>(this ParameterInfo parameter, bool check_base)
        {
            object[] attrs;
            if (check_base)
            {
                attrs = parameter.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var type = attr.GetType();
                    if (type == typeof(T) || type.IsSubclassOf(typeof(T)))
                        return (T)attr;
                }
            }
            else
            {
                var attr = parameter.GetCustomAttributes(typeof(T), true);
                if (attr != null && attr.Length > 0)
                    return (T)attr[0];
            }
            return default;
        }

        /// <summary>
        /// 获取attribute(ParameterInfo)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static T getAttribute<T>(this ParameterInfo parameter)
        {
            return parameter.getAttribute<T>(false);
        }
        #endregion

        #region Common Object And Types
        /// <summary>
        /// 获取attribute(object, Type)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="check_base">是否检查基类, 开启此选项后, 可以通过基类查到继承后的Attribute</param>
        /// <returns></returns>
        public static T getAttribute<T>(this object obj, bool check_base)
        {
            object[] attrs;
            if (check_base)
            {
                if (obj.getValue("BaseType") == null)
                    attrs = obj.GetType().GetCustomAttributes(true);
                else
                    attrs = ((Type)obj).GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var type = attr.GetType();
                    if (type == typeof(T) || type.IsSubclassOf(typeof(T)))
                        return (T)attr;
                }
            }
            else
            {
                if (obj.getValue("BaseType") == null)
                    attrs = obj.GetType().GetCustomAttributes(typeof(T), true);
                else
                    attrs = ((Type)obj).GetCustomAttributes(typeof(T), true);
                if (attrs != null && attrs.Length > 0)
                    return (T)attrs[0];
            }
            return default;
        }

        /// <summary>
        /// 获取attribute(object, Type)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T getAttribute<T>(this object obj)
        {
            return obj.getAttribute<T>(false);
        }
        #endregion
    }
}