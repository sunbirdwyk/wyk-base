using System;
using System.Collections.Generic;
using System.Reflection;

namespace wyk.basic
{
    /// <summary>
    /// 日期区间
    /// 每个Field为一个Range项, 每个Field的值为显示的名称
    /// </summary>
    public class DateRange
    {
        [DateRangeAttribute("Custom", 0)]
        public string Custom = "自定义";
        [DateRangeAttribute("OneDay", 1)]
        public string OneDay = "一天";
        [DateRangeAttribute("OneWeek", 7)]
        public string OneWeek = "一周";
        [DateRangeAttribute("HalfMonth", 15)]
        public string HalfMonth = "半个月";
        [DateRangeAttribute("OneMonth", DateFieldType.Month, 1)]
        public string OneMonth = "一个月";
        [DateRangeAttribute("ThreeMonth", DateFieldType.Month, 3)]
        public string ThreeMonth = "三个月";
        [DateRangeAttribute("自定义", DateFieldType.Month, 6)]
        public string HalfYear = "半年";
        [DateRangeAttribute("自定义", DateFieldType.Year, 1)]
        public string OneYear = "一年";
        [DateRangeAttribute("自定义", -1)]
        public string All = "全部";

        /// <summary>
        /// 所有Attributes的临时存储, 多次调用只需获取一次
        /// </summary>
        private static List<DateRangeAttribute> _attributes;

        private static List<DateRangeAttribute> attributes
        {
            get
            {
                if (_attributes == null)
                {
                    DateRange daterange = new DateRange();
                    FieldInfo[] fields = daterange.GetType().GetFields();
                    _attributes = new List<DateRangeAttribute>();
                    foreach (FieldInfo fi in fields)
                    {
                        try
                        {
                            var attr = fi.getAttribute<DateRangeAttribute>();
                            attr.display = fi.GetValue(daterange) as string;
                            _attributes.Add(attr);
                        }
                        catch { }
                    }
                }
                return _attributes;
            }
        }

        /// <summary>
        /// 获取所有的显示内容值列表
        /// </summary>
        /// <returns></returns>
        public static string[] allDisplayList()
        {
            string[] list = new string[attributes.Count];
            for (int i = 0; i < attributes.Count; i++)
            {
                list[i] = attributes[i].display;
            }
            return list;
        }

        /// <summary>
        /// 获取所有的名称列表
        /// </summary>
        /// <returns></returns>
        public static string[] allNameList()
        {
            string[] list = new string[attributes.Count];
            for (int i = 0; i < attributes.Count; i++)
            {
                list[i] = attributes[i].name;
            }
            return list;
        }

        /// <summary>
        /// 根据名称获取显示值
        /// </summary>
        /// <param name="name">区间名称</param>
        /// <returns></returns>
        public static string displayWithName(string name)
        {
            foreach (DateRangeAttribute attribute in attributes)
            {
                if (attribute.name == name.Trim())
                {
                    return attribute.display;
                }
            }
            return "";
        }

        /// <summary>
        /// 根据日期区间获取显示值(只判断日期)
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public static string displayWithDateRange(DateTime start, DateTime end)
        {
            DateRangeAttribute attribute = attributeWithDateRange(start, end);
            if (attribute != null)
                return attribute.display;
            return "自定义";
        }

        /// <summary>
        /// 根据日期区间获取显示值(只判断日期), 结束日期为当天
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <returns></returns>
        public static string displayWithDateRange(DateTime start)
        {
            return displayWithDateRange(start, DateTime.Today);
        }

        /// <summary>
        /// 根据显示值获取名称
        /// </summary>
        /// <param name="display">显示值</param>
        /// <returns></returns>
        public static string nameWithDisplay(string display)
        {
            foreach (DateRangeAttribute attribute in attributes)
            {
                if (attribute.display == display.Trim())
                {
                    return attribute.name;
                }
            }
            return "";
        }

        /// <summary>
        /// 根据日期获取名称(只判断日期)
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public static string nameWithDateRange(DateTime start, DateTime end)
        {
            DateRangeAttribute attribute = attributeWithDateRange(start, end);
            if (attribute != null)
                return attribute.name;
            return "Custom";
        }

        /// <summary>
        /// 根据日期获取名称(只判断日期), 结束日期为当天
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <returns></returns>
        public static string nameWithDateRange(DateTime start)
        {
            return nameWithDateRange(start, DateTime.Today);
        }

        /// <summary>
        /// 根据名称获取Attribute
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public static DateRangeAttribute attributeWithName(string name)
        {
            foreach (DateRangeAttribute attribute in attributes)
            {
                if (attribute.name == name.Trim())
                {
                    return attribute;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据显示值获取Attribute
        /// </summary>
        /// <param name="display">显示值</param>
        /// <returns></returns>
        public static DateRangeAttribute attributeWithDisplay(string display)
        {
            foreach (DateRangeAttribute attribute in attributes)
            {
                if (attribute.display == display.Trim())
                {
                    return attribute;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据日期区间获取Attribute(只判断日期)
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public static DateRangeAttribute attributeWithDateRange(DateTime start, DateTime end)
        {
            DateRangeAttribute custom = null;
            foreach (DateRangeAttribute attribute in attributes)
            {
                if (attribute.range_value < 0)
                    continue;
                if (attribute.range_value == 0)
                {
                    custom = attribute;
                    continue;
                }
                switch (attribute.range_type)
                {
                    case DateFieldType.Day:
                    default:
                        if (start.Date.AddDays(attribute.range_value).AddMilliseconds(-1).Date == end.Date)
                            return attribute;
                        break;
                    case DateFieldType.Month:
                        if (start.Date.AddMonths(attribute.range_value).AddMilliseconds(-1).Date == end.Date)
                            return attribute;
                        break;
                    case DateFieldType.Year:
                        if (start.Date.AddYears(attribute.range_value).AddMilliseconds(-1).Date == end.Date)
                            return attribute;
                        break;
                }
            }
            return custom;
        }

        /// <summary>
        /// 根据日期区间获取Attribute(只判断日期), 结束日期为当天
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateRangeAttribute attributeWithDateRange(DateTime start)
        {
            return attributeWithDateRange(start, DateTime.Today);
        }

        /// <summary>
        /// 根据名称获取日期区间(结束日期为当天)
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="start">输出开始日期</param>
        /// <param name="end">输出结束日期</param>
        public static void dateRangeWithName(string name, out DateTime start, out DateTime end)
        {
            dateRangeWithName(name, DateTime.Now, out start, out end);
        }

        /// <summary>
        /// 根据名称获取日期区间
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="current">当前日期(结束日期)</param>
        /// <param name="start">输出开始日期</param>
        /// <param name="end">输出结束日期</param>
        public static void dateRangeWithName(string name, DateTime current, out DateTime start, out DateTime end)
        {
            DateRangeAttribute attribute = attributeWithName(name);
            start = DateTimeUtil.defaultTime();
            end = DateTimeUtil.defaultTime();
            if (attribute != null)
            {
                attribute.getDateRange(current, out start, out end);
            }
        }

        /// <summary>
        /// 根据显示值获取日期区间(结束日期为当天)
        /// </summary>
        /// <param name="display">显示值</param>
        /// <param name="start">输出开始日期</param>
        /// <param name="end">输出结束日期</param>
        public static void dateRangeWithDisplay(string display, out DateTime start, out DateTime end)
        {
            dateRangeWithDisplay(display, DateTime.Now, out start, out end);
        }

        /// <summary>
        /// 根据显示值获取日期区间
        /// </summary>
        /// <param name="display">显示值</param>
        /// <param name="current">当前日期(结束日期)</param>
        /// <param name="start">输出开始日期</param>
        /// <param name="end">输出结束日期</param>
        public static void dateRangeWithDisplay(string display, DateTime current, out DateTime start, out DateTime end)
        {
            DateRangeAttribute attribute = attributeWithDisplay(display);
            start = DateTimeUtil.defaultTime();
            end = DateTimeUtil.defaultTime();
            if (attribute != null)
            {
                attribute.getDateRange(current, out start, out end);
            }
        }
    }
}