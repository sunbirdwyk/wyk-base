using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace wyk.basic
{
    public class ReplaceInfoList
    {
        public List<ReplaceInfoAttribute> infos = new List<ReplaceInfoAttribute>();

        public static void addItemToList(ReplaceInfoAttribute attr, List<ReplaceInfoAttribute> list)
        {
            for (int i=0;i<list.Count;i++)
            {
                if (list[i].name == attr.name)
                    return;
                if(attr.name.IndexOf( list[i].name)>=0)
                {
                    list.Insert(i, attr);
                    return;
                }
            }
            list.Add(attr);
        }

        public static void addItemsToList(List<ReplaceInfoAttribute> items, List<ReplaceInfoAttribute> list)
        {
            if (items == null)
                return;
            foreach (var item in items)
                addItemToList(item, list);
        }

        public static ReplaceInfoList fromObject(object obj)
        {
            var list = new ReplaceInfoList();
            list.infos = getReplaceInfos(obj);
            addItemsToList(getFixedReplaceInfos(), list.infos);
            return list;
        }

        public static List<ReplaceInfoAttribute> getReplaceInfos(object obj)
        {
            var list = new List<ReplaceInfoAttribute>();
            if (obj.GetType().Name.StartsWith("List"))
                return list;
            var fields = obj.GetType().GetFields();
            foreach (var field in fields)
            {
                if (!field.IsPublic || field.IsStatic)
                    continue;
                var value = obj.getValue(field);
                if (value.isNull())
                    continue;
                var attr = field.getAttribute<ReplaceInfoAttribute>();
                if (attr != null)
                {
                    if (attr.multiple_names != null && attr.multiple_names.Length > 0)
                    {
                        try
                        {
                            foreach (string attr_name in attr.multiple_names)
                            {
                                if (attr_name.isNull())
                                    continue;
                                var attrbute = new ReplaceInfoAttribute(attr_name);
                                attrbute.value = value;
                                addItemToList(attrbute, list);
                            }
                        }
                        catch { }
                    }
                    else if (!attr.name.isNull())
                    {
                        attr.value = value;
                        addItemToList(attr, list);
                    }
                }
                var items = getReplaceInfos(value);
                addItemsToList(items, list);
            }
            var properties = obj.GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (!prop.CanWrite)
                    continue;
                var value = obj.getValue(prop);
                if (value.isNull())
                    continue;
                var attr = prop.getAttribute<ReplaceInfoAttribute>();
                if (attr != null)
                {
                    if (attr.multiple_names != null && attr.multiple_names.Length > 0)
                    {
                        try
                        {
                            foreach (string attr_name in attr.multiple_names)
                            {
                                if (attr_name.isNull())
                                    continue;
                                var attrbute = new ReplaceInfoAttribute(attr_name);
                                attrbute.value = value;
                                addItemToList(attrbute, list);
                            }
                        }
                        catch { }
                    }
                    else if (!attr.name.isNull())
                    {
                        attr.value = value;
                        addItemToList(attr, list);
                    }
                }
                var items = getReplaceInfos(value);
                addItemsToList(items, list);
            }
            return list;
        }

        public static List<ReplaceInfoAttribute> getFixedReplaceInfos()
        {
            List<ReplaceInfoAttribute> list = new List<ReplaceInfoAttribute>();
            var attr = new ReplaceInfoAttribute("当前日期","",DateTime.Today.ToString("yyyy-MM-dd"));
            list.Add(attr);
            attr = new ReplaceInfoAttribute("当前时间", "", DateTime.Now.ToString("HH:mm:ss"));
            list.Add(attr);
            return list;
        }

        /// <summary>
        /// 处理字符串内的可替换字段
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string process(string source)
        {
            var result = source;
            foreach (var attr in infos)
            {
                try
                {
                    if (attr.name.isNull() || attr.value.isNull())
                        continue;
                    if (result.IndexOf(attr.replace_name) >= 0) {
                        string value;
                        if (attr.value.GetType().Name.StartsWith("List"))
                            value = JsonConvert.SerializeObject(attr.value);
                        else
                            value = attr.value.ToString();
                        result = result.Replace(attr.replace_name, value);
                    }
                }
                catch { }
            }
            return result;
        }
    }
}
