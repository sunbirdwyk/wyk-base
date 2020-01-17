using System;
using System.ComponentModel;
using System.Data;

namespace wyk.basic
{
    public class EnumUtil
    {
        /// <summary>
        /// 获取枚举项目的显示名称
        /// </summary>
        /// <param name="en">枚举项目</param>
        /// <returns></returns>
        public static string getDisplay(Enum en)
        {
            try
            {
                var mil = en.GetType().GetMember(en.ToString());
                if (mil != null && mil.Length > 0)
                {
                    var attr = mil[0].getAttribute<DescriptionAttribute>();
                    return attr.Description;
                }
            }
            catch { }
            return en.ToString();
        }

        /// <summary>
        /// 获取枚举项目的显示名称
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="name">枚举项目的项目名称</param>
        /// <returns></returns>
        public static string getDisplay<TEnum>(string name)
        {
            try
            {
                var mil = typeof(TEnum).GetMember(name);
                if (mil != null && mil.Length > 0)
                {
                    return mil[0].getAttribute<DescriptionAttribute>().Description;
                }
            }
            catch { }
            return name;
        }

        /// <summary>
        /// 通过枚举项目的项目名称获取枚举项目
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str">项目名称</param>
        /// <returns></returns>
        public static TEnum fromName<TEnum>(string str)
        {
            try
            {
                TEnum res = (TEnum)Enum.Parse(typeof(TEnum), str);
                return res;
            }
            catch { }
            return default(TEnum);
        }

        /// <summary>
        /// 通过枚举项目的显示名称获取枚举项目
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="name">显示名称</param>
        /// <returns></returns>
        public static TEnum fromDisplay<TEnum>(string name)
        {
            var type = typeof(TEnum);
            try
            {
                foreach (var mi in Enum.GetNames(type))
                {
                    try
                    {
                        var mil = type.GetMember(mi);
                        if (mil != null && mil.Length > 0)
                        {
                            var attr = mil[0].getAttribute<DescriptionAttribute>();
                            if (attr != null &&attr.Description == name)
                                return fromName<TEnum>(mi);
                        }
                    }
                    catch { }
                }
            }
            catch { }
            return fromName<TEnum>(name);
        }

        /// <summary>
        /// 获取枚举类型的所有值(int数组)
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static Array allValues<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum));
        }

        /// <summary>
        /// 获取枚举类型的所有项目名称(string数组)
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static string[] allNames<TEnum>()
        {
            return Enum.GetNames(typeof(TEnum));
        }

        /// <summary>
        /// 获取枚举类型的所有显示名称(string数组)
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static string[] allDisplays<TEnum>()
        {
            try
            {
                var names = allNames<TEnum>();
                var displays = new string[names.Length];
                for (var i = 0; i < names.Length; i++)
                {
                    displays[i] = getDisplay<TEnum>(names[i]);
                }
                return displays;
            }
            catch { }
            return null;
        }

        /// <summary>
        /// 获取枚举类型的所有  显示名称(name)-项目名称(value)  集合
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static ValuePairList allValuePair<TEnum>()
        {
            var list = new ValuePairList();
            try
            {
                var names = allNames<TEnum>();
                for (var i = 0; i < names.Length; i++)
                {
                    var display = getDisplay<TEnum>(names[i]);
                    list.set(display, names[i]);
                }
            }
            catch { }
            return list;
        }

        public static string[] enumNames<TEnum>(TEnum[] enums)
        {
            if (enums == null)
                return null;
            var arr = new string[enums.Length];
            try
            {
                for (int i = 0; i < enums.Length; i++)
                    arr[i] = enums[i].ToString();
            }
            catch { }
            return arr;
        }

        public static string[] enumDisplays<TEnum>(TEnum[] enums)
        {
            if (enums == null)
                return null;
            var arr = new string[enums.Length];
            try
            {
                for (int i = 0; i < enums.Length; i++)
                    arr[i] = getDisplay<TEnum>(enums[i].ToString());
            }
            catch { }
            return arr;
        }

        public static TEnum[] enumFromNames<TEnum>(string[] names)
        {
            if (names == null)
                return null;
            var arr = new TEnum[names.Length];
            try
            {
                for (int i = 0; i < names.Length; i++)
                    arr[i] = fromName<TEnum>(names[i]);
            }
            catch { }
            return arr;
        }

        public static TEnum[] enumFromDisplays<TEnum>(string[] displays)
        {
            if (displays == null)
                return null;
            var arr = new TEnum[displays.Length];
            try
            {
                for (int i = 0; i < displays.Length; i++)
                    arr[i] = fromDisplay<TEnum>(displays[i]);
            }
            catch { }
            return arr;
        }

        public static DataTable dataTableForDropDown<TEnum>(string filter)
        {
            var data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("name");
            foreach (var vp in allValuePair<TEnum>().pair_list)
            {
                if (filter.isNull() || vp.value.IndexOf(filter) >= 0 || vp.name.IndexOf(filter) >= 0 || vp.name.pinyinShort().IndexOf(filter) >= 0)
                {
                    var row = data.NewRow();
                    row[0] = vp.value;
                    row[1] = vp.name;
                    data.Rows.Add(row);
                }
            }
            return data;
        }
    }
}
