using System;
using System.Text;

namespace wyk.basic
{
    public static class DateTimeReferedExtention
    {
        /// <summary>
        /// 获取农历日期
        /// </summary>
        /// <param name="date">公历日期</param>
        /// <param name="with_year">是否包含年</param>
        /// <param name="with_sx">是否包含生肖(包含年时生效)</param>
        /// <returns></returns>
        public static string lunisolarDate(this DateTime date,bool with_year,bool with_sx)
        {
            var sb = new StringBuilder();
            if (with_year)
            {
                sb.Append(LunisolarCalendarUtil.year(date));
                if (with_sx)
                    sb.Append(LunisolarCalendarUtil.sx(date));
                sb.Append("年");
            }
            sb.Append(LunisolarCalendarUtil.month(date));
            sb.Append("月");
            sb.Append(LunisolarCalendarUtil.lunisolarDay(date));
            return sb.ToString();
        }

        /// <summary>
        /// 判断时间是否为默认时间
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static bool isDefault(this DateTime datetime)
        {
            return DateTimeUtil.isDefaultTime(datetime);
        }

        /// <summary>
        /// 根据时间(出生日期)计算年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static int toAge(this DateTime birthday)
        {
            return DateTimeUtil.ageByBirthday(birthday);
        }

        /// <summary>
        /// 获取1970年1月1日0点以来的秒数
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long toIntervalSince1970(this DateTime datetime)
        {
            return DateTimeUtil.toIntervalSince1970UTC(datetime);
        }

        /// <summary>
        /// 获取1970年1月1日0点以来的毫秒数
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long toIntervalMSSince1970(this DateTime datetime)
        {
            return DateTimeUtil.toIntervalMSSince1970UTC(datetime);
        }

        public static string toString(this DateTime datetime, string format)
        {
            if (datetime.isDefault())
                return "";
            return datetime.ToString(format);
        }

        public static string toString(this DateTime datetime)
        {
            return datetime.toString("yyyy-MM-dd HH:mm:ss");
        }
    }
}