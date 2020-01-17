using System;

namespace wyk.basic
{
    /// <summary>
    /// 日期区间辅助Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DateRangeAttribute : Attribute
    {
        /// <summary>
        /// 日期区间名称(英文, 存储用)
        /// </summary>
        public string name;
        /// <summary>
        /// 日期区间显示内容(名称, 中文)
        /// </summary>
        public string display;
        /// <summary>
        /// 日期区间单位
        /// </summary>
        public DateFieldType range_type;
        /// <summary>
        /// 日期区间跨度值
        /// </summary>
        public int range_value;
        #region Constructor
        public DateRangeAttribute(string Name, int RangeValue)
        {
            name = Name;
            range_type = DateFieldType.Day;
            range_value = RangeValue;
            display = "";
        }

        public DateRangeAttribute(string Name, string Display, int RangeValue)
        {
            name = Name;
            range_type = DateFieldType.Day;
            range_value = RangeValue;
            display = Display;
        }

        public DateRangeAttribute(string Name, DateFieldType RangeType, int RangeValue)
        {
            name = Name;
            range_type = RangeType;
            range_value = RangeValue;
            display = "";
        }

        public DateRangeAttribute(string Name, string Display, DateFieldType RangeType, int RangeValue)
        {
            name = Name;
            range_type = RangeType;
            range_value = RangeValue;
            display = Display;
        }
        #endregion

        /// <summary>
        /// 获取日期区间(结束日期为当天)
        /// </summary>
        /// <param name="start">输出开始日期</param>
        /// <param name="end">输出结束日期</param>
        public void getDateRange(out DateTime start, out DateTime end)
        {
            getDateRange(DateTime.Now, out start, out end);
        }

        /// <summary>
        /// 获取日期区间
        /// </summary>
        /// <param name="current">当前日期(结束日期)</param>
        /// <param name="start">输出开始日期</param>
        /// <param name="end">输出结束日期</param>
        public void getDateRange(DateTime current, out DateTime start, out DateTime end)
        {
            if (range_value <= 0)
            {
                start = DateTimeUtil.defaultTime();
                end = DateTimeUtil.defaultTime();
                return;
            }
            end = current.Date;
            switch (range_type)
            {
                case DateFieldType.MiliSecond:
                    start = end.AddMilliseconds(range_value).AddMilliseconds(-1);
                    break;
                case DateFieldType.Second:
                    start = end.AddSeconds(range_value).AddMilliseconds(-1);
                    break;
                case DateFieldType.Minute:
                    start = end.AddMinutes(range_value).AddMilliseconds(-1);
                    break;
                case DateFieldType.Hour:
                    start = end.AddHours(range_value).AddMilliseconds(-1);
                    break;
                case DateFieldType.Day:
                    start = end.AddDays(range_value).AddMilliseconds(-1);
                    break;
                case DateFieldType.Month:
                    start = end.AddMonths(range_value).AddMilliseconds(-1);
                    break;
                case DateFieldType.Year:
                    start = end.AddYears(range_value).AddMilliseconds(-1);
                    break;
                default:
                    start = end;
                    break;
            }
        }
    }
}
