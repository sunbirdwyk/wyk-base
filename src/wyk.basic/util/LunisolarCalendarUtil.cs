using System;
using System.Globalization;
using System.Text;

namespace wyk.basic
{
    public class LunisolarCalendarUtil
    {
        private static ChineseLunisolarCalendar _lc = null;

        private static ChineseLunisolarCalendar lc
        {
            get
            {
                if (_lc == null)
                    _lc = new ChineseLunisolarCalendar();
                return _lc;
            }
        }

        ///<summary>
        /// 十天干
        ///</summary>
        private static string[] TG_LIST = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
        ///<summary>
        /// 十二地支
        ///</summary>
        private static string[] DZ_LIST = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
        ///<summary>
        /// 农历天干地支年
        ///</summary>
        ///<param name="year">农历年</param>
        ///<return s></return s>
        public static string year(DateTime date)
        {
            var year = lc.GetYear(date);
            if (year > 3)
            {
                int tgIndex = (year - 4) % 10;
                int dzIndex = (year - 4) % 12;
                return string.Concat(TG_LIST[tgIndex], DZ_LIST[dzIndex]);
            }
            return "";
        }

        ///<summary>
        /// 十二生肖
        ///</summary>
        private static string[] SX_LIST = { "鼠", "牛", "虎", "免", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };
        /// <summary>
        /// 农历生肖
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string sx(DateTime date)
        {
            var year = lc.GetYear(date);
            if (year > 3)
            {
                int dzIndex = (year - 4) % 12;
                return SX_LIST[dzIndex];
            }
            return "";
        }

        ///<summary>
        /// 农历月
        ///</summary>
        private static string[] months = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊" };

        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days1 = { "初", "十", "廿", "三" };
        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days2 = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };


        ///<summary>
        /// 农历月
        ///</summary>
        ///<param name="month">月份</param>
        ///<return s></return s>
        public static string month(DateTime date)
        {
            var month = lc.GetMonth(date);
            int leap_month = lc.GetLeapMonth(lc.GetYear(date));
            bool is_leap = false;
            if (leap_month > 0)
            {
                if (leap_month == month)
                {
                    //闰月
                    is_leap = true;
                    month--;
                }
                else if (month > leap_month)
                {
                    month--;
                }
            }
            if (month < 13 && month > 0)
            {
                return string.Format("{0}{1}", is_leap ? "润" : "", months[month - 1]);
            }
            return "";
        }

        ///<summary>
        /// 农历日
        ///</summary>
        ///<param name="day">天</param>
        ///<return s></return s>
        public static string lunisolarDay(DateTime date)
        {
            var day = lc.GetDayOfMonth(date);
            if (day > 0 && day < 32)
            {
                if (day != 20 && day != 30)
                {
                    return string.Concat(days1[(day - 1) / 10], days2[(day - 1) % 10]);
                }
                else
                {
                    return string.Concat(days2[(day - 1) / 10], days1[1]);
                }
            }
            return "";
        }
    }
}
