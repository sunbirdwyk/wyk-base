using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace wyk.api
{
    public class ApiDescriptionUtil
    {
        static Dictionary<string, TypeDescription> desc_types = new Dictionary<string, TypeDescription>();
        static Dictionary<string, FieldDescription> desc_fields = new Dictionary<string, FieldDescription>();
        static Dictionary<string, PropertyDescription> desc_properties = new Dictionary<string, PropertyDescription>();
        static Dictionary<string, MethodDescription> desc_methods = new Dictionary<string, MethodDescription>();

        /// <summary>
        /// 将所有注释信息加载到内存中
        /// </summary>
        public static void init()
        {
            clear();
            var path = $"{Path.Combine(Directory.GetCurrentDirectory(), "documents")}";
            var files = Directory.GetFiles(path, "*.xml");
            foreach (var f in files)
            {
                try
                {
                    var xDoc = new XmlDocument();
                    xDoc.Load(f);
                    var root = xDoc.SelectSingleNode("doc").SelectSingleNode("members");
                    foreach (XmlNode xn in root.ChildNodes)
                    {
                        try
                        {
                            var name = xn.Attributes["name"].Value;
                            var text = xn.SelectSingleNode("summary").InnerText.Trim('\r').Trim('\n').Trim('\r').Trim(Convert.ToChar(30)).Trim();
                            switch (name.Substring(0, 2))
                            {
                                case "T:":
                                    desc_types[name] = new TypeDescription(name, text);
                                    break;
                                case "F:":
                                    desc_fields[name] = new FieldDescription(name, text);
                                    break;
                                case "P:":
                                    desc_properties[name] = new PropertyDescription(name, text);
                                    break;
                                case "M:":
                                    var mi = new MethodDescription(name, text);
                                    try
                                    {
                                        mi.returns = xn.SelectSingleNode("returns").InnerText;
                                    }
                                    catch { }
                                    try
                                    {
                                        foreach (XmlNode pmn in xn.SelectNodes("param"))
                                        {
                                            try
                                            {
                                                var pm = new MethodParamDescription();
                                                pm.name = pmn.Attributes["name"].Value;
                                                pm.description = pmn.InnerText;
                                                mi.parameters.Add(pm);
                                            }
                                            catch { }
                                        }
                                    }
                                    catch { }
                                    desc_methods[name] = mi;
                                    break;
                            }
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 获取方法Method的注释信息
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static MethodDescription getDescription(MethodInfo method)
        {
            var pm = new StringBuilder();
            foreach (var pi in method.GetParameters())
            {
                if (pm.Length > 0)
                    pm.Append(",");
                pm.Append(pi.ParameterType);
            }
            string search_name;
            if (pm.Length > 0)
                search_name = $"{MethodDescription.PREFIX}{method.DeclaringType.FullName}.{method.Name}({pm.ToString()})";
            else
                search_name = $"{MethodDescription.PREFIX}{method.DeclaringType.FullName}.{method.Name}";
            if (desc_methods.ContainsKey(search_name))
                return desc_methods[search_name];
            return new MethodDescription();
        }

        /// <summary>
        /// 获取字段FieldInfo的注释信息
        /// </summary>
        /// <param name="field_info"></param>
        /// <returns></returns>
        public static FieldDescription getDescription(Type object_type, FieldInfo field_info)
        {
            var search_name = $"{FieldDescription.PREFIX}{object_type.FullName}.{field_info.Name}";
            if (desc_fields.ContainsKey(search_name))
                return desc_fields[search_name];
            return new FieldDescription();
        }

        /// <summary>
        /// 获取属性Property的注释信息
        /// </summary>
        /// <param name="prop_info"></param>
        /// <returns></returns>
        public static PropertyDescription getDescription(Type object_type, PropertyInfo prop_info)
        {
            var search_name = $"{PropertyDescription.PREFIX}{object_type.FullName}.{prop_info.Name}";
            if (desc_properties.ContainsKey(search_name))
                return desc_properties[search_name];
            return new PropertyDescription();
        }

        /// <summary>
        /// 获取类的注释信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TypeDescription getDescription(Type type)
        {
            var search_name = $"{TypeDescription.PREFIX}{type.FullName}";
            if (desc_types.ContainsKey(search_name))
                return desc_types[search_name];
            return new TypeDescription();
        }

        public static List<ApiSpecParameter> getParametersForType(Type type)
        {
            var pm = new List<ApiSpecParameter>();
            foreach (var fi in type.GetFields())
            {
                if (fi.IsPublic)
                    pm.Add(new ApiSpecParameter(fi.Name, fi.FieldType.Name, getDescription(type, fi).summary));

            }
            foreach (var pi in type.GetProperties())
            {
                if (pi.CanWrite)
                    pm.Add(new ApiSpecParameter(pi.Name, pi.PropertyType.Name, getDescription(type, pi).summary));
            }
            return pm;
        }


        public static void clear()
        {
            desc_fields.Clear();
            desc_methods.Clear();
            desc_properties.Clear();
            desc_types.Clear();
        }
    }
}