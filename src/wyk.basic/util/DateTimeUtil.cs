using System;

namespace wyk.basic
{
    /// <summary>
    /// 时间处理单元
    /// </summary>
    public class DateTimeUtil
    {
        public static DateTime defaultTime()
        {
            return new DateTime(1900, 1, 1);
        }

        public static bool isDefaultTime(DateTime datetime)
        {
            if (datetime.Ticks == 0)
                return true;
            if (datetime == defaultTime())
                return true;
            return false;
        }

        /// <summary>
        /// 从1970年1月1日起的时间Tick获取当前时间(UTC)
        /// 通常是由java或objective-c生成的时间
        /// </summary>
        /// <param name="interval">毫秒数</param>
        /// <returns></returns>
        public static DateTime fromSince1970UTCInterval(long interval)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(interval).ToLocalTime();
        }

        /// <summary>
        /// 将时间转为1970年1月1日起的时间值(秒)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long toIntervalSince1970UTC(DateTime datetime)
        {
            TimeSpan ts = datetime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 将时间转为1970年1月1日起的时间值(毫秒)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long toIntervalMSSince1970UTC(DateTime datetime)
        {
            TimeSpan ts = datetime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }

        /// <summary>
        /// 根据年龄计算出生日期(日期默认为1月1日)
        /// </summary>
        /// <param name="age">年龄</param>
        /// <returns>出生日期</returns>
        public static DateTime birthdayByAge(int age)
        {
            return new DateTime(DateTime.Now.AddYears(-age).Year, 1, 1);
        }

        /// <summary>
        /// 根据出生日期计算年龄
        /// </summary>
        /// <param name="birthday">出生日期</param>
        /// <returns>年龄</returns>
        public static int ageByBirthday(DateTime birthday)
        {
            if (birthday.isDefault())
                return 0;
            else
            {
                int years = DateTime.Today.Year - birthday.Year;
                if (DateTime.Today.Month > birthday.Month || (DateTime.Today.Month == birthday.Month && DateTime.Today.Day >= birthday.Day))
                {
                }
                else
                {
                    years--;
                }
                return years;
            }
        }

        /// <summary>
        /// 获取当地日升、日落的时间
        /// </summary>
        public static bool getSunTime(double longitude, double latitude, DateTime now, out DateTime rise_time, out DateTime set_time)
        {
            return SunTimeCalculator.getSunTime(longitude, latitude, now, out rise_time, out set_time);
        }
    }

    class SunTimeCalculator
    {
        private static int[] days_of_nonleapyear_month = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private static int[] days_of_leapyear_month = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private static double h = -0.833;//日出日落时太阳的位置

        private static double UTo = 180.0;//上次计算的日落日出时间，初始迭代值180.0

        private static bool isLeapYear(int year)
        {
            return year % 400 == 0 || (year % 100 != 0 && year % 4 == 0);
        }

        /// <summary>
        /// 求格林威治时间公元2000年1月1日到计算日的世纪数
        /// </summary>
        private static double getCenturies(DateTime now, double sun_time)
        {
            var total_days = 0;
            for (int i = 2000; i < now.Year; i++)
            {
                total_days += isLeapYear(i) ? 366 : 365;
            }

            for (int i = 0; i < now.Month - 1; i++)
            {
                total_days += isLeapYear(now.Year) ? days_of_leapyear_month[i] : days_of_nonleapyear_month[i];
            }
            total_days += now.Day;

            return (total_days + sun_time / 360) / 36525;
        }

        /// <summary>
        /// 求太阳的平黄径
        /// </summary>
        private static double getLSun(double centuries)
        {
            return 280.46 + 36000.77 * centuries;
        }

        /// <summary>
        /// 求太阳的平近点角
        /// </summary>
        private static double getGSun(double centuries)
        {
            return 357.528 + 35999.05 * centuries;
        }

        /// <summary>
        /// 求黄道经度
        /// </summary>
        private static double getEclipticLongitude(double l_sun, double g_sun)
        {
            return l_sun + 1.915 * Math.Sin(g_sun * Math.PI / 180) + 0.02 * Math.Sin(2 * g_sun * Math.PI / 180);
        }

        /// <summary>
        /// 求地球倾角
        /// </summary>
        private static double getEarthTilt(double centuries)
        {
            return 23.4393 - 0.013 * centuries;
        }

        /// <summary>
        /// 求太阳偏差
        /// </summary>
        private static double getSunDeviation(double earth_tilt, double ecliptic_longitude)
        {
            return 180 / Math.PI * Math.Asin(Math.Sin(Math.PI / 180 * earth_tilt) * Math.Sin(Math.PI / 180 * ecliptic_longitude));
        }

        /// <summary>
        /// 求格林威治时间的太阳时间角
        /// </summary>
        private static double getGHA(double sun_time, double g_sun, double ecliptic_longitude)
        {
            var arg1 = g_sun * Math.PI / 180;
            var arg2 = ecliptic_longitude * Math.PI / 180;
            return sun_time - 180 - 1.915 * Math.Sin(arg1) - 0.02 * Math.Sin(2 * arg1) + 2.466 * Math.Sin(2 * arg2) - 0.053 * Math.Sin(4 * arg2);
        }

        /// <summary>
        /// 求修正值
        /// </summary>
        private static double getCorrections(double position, double latitude, double sun_deviation)
        {
            var arg = position * Math.PI / 180;
            var arg1 = latitude * Math.PI / 180;
            var arg2 = sun_deviation * Math.PI / 180;
            return 180 / Math.PI * Math.Acos((Math.Sin(arg) - Math.Sin(arg1) * Math.Sin(arg2)) / (Math.Cos(arg1) * Math.Cos(arg2)));
        }

        /// <summary>
        /// 计算日出时间
        /// </summary>
        private static double calculateRiseTime(double sun_time, double gha, double longitude, double corrections)
        {
            return sun_time - gha - longitude - corrections;
        }

        /// <summary>
        /// 计算日落时间
        /// </summary>
        private static double calculateSetTime(double sun_time, double gha, double longitude, double corrections)
        {
            return sun_time - gha - longitude + corrections;
        }

        /// <summary>
        /// 求日出时间
        /// </summary>
        private static double getRiseTime(double sun_time, double last_sun_time, double longitude, double latitude, DateTime now)
        {
            if (Math.Abs(sun_time - last_sun_time) >= 0.1)
            {
                last_sun_time = sun_time;
                var centuries = getCenturies(now, last_sun_time);
                var l_sun = getLSun(centuries);
                var g_sun = getGSun(centuries);
                var ecliptic_longitude = getEclipticLongitude(l_sun, g_sun);
                var gha = getGHA(last_sun_time, g_sun, ecliptic_longitude);
                var earth_tilt = getEarthTilt(centuries);
                var sun_deviation = getSunDeviation(earth_tilt, ecliptic_longitude);
                var corrections = getCorrections(h, latitude, sun_deviation);
                sun_time = calculateRiseTime(last_sun_time, gha, longitude, corrections);
                getRiseTime(sun_time, last_sun_time, longitude, latitude, now);
            }
            return sun_time;
        }

        /// <summary>
        /// 求日落时间
        /// </summary>
        private static double getSetTime(double sun_time, double last_sun_time, double longitude, double latitude, DateTime now)
        {
            if (Math.Abs(sun_time - last_sun_time) >= 0.1)
            {
                last_sun_time = sun_time;
                var centuries = getCenturies(now, last_sun_time);
                var l_sun = getLSun(centuries);
                var g_sun = getGSun(centuries);
                var ecliptic_longitude = getEclipticLongitude(l_sun, g_sun);
                var gha = getGHA(last_sun_time, g_sun, ecliptic_longitude);
                var earth_tilt = getEarthTilt(centuries);
                var sun_deviation = getSunDeviation(earth_tilt, ecliptic_longitude);
                var corrections = getCorrections(h, latitude, sun_deviation);
                sun_time = calculateSetTime(last_sun_time, gha, longitude, corrections);
                getSetTime(sun_time, last_sun_time, longitude, latitude, now);
            }
            return sun_time;
        }

        /// <summary>
        /// 求当前所在时区
        /// </summary>
        private static int getZone(double longitude)
        {
            if (longitude >= 0)
                return (int)(longitude / 15.0 + 1);
            else
                return (int)(longitude / 15.0 - 1);
        }

        private static DateTime getSunRise(double longitude, double latitude, DateTime now)
        {
            var centuries = getCenturies(now, UTo);
            var l_sun = getLSun(centuries);
            var g_sun = getGSun(centuries);
            var ecliptic_longitude = getEclipticLongitude(l_sun, g_sun);
            var gha = getGHA(UTo, g_sun, ecliptic_longitude);
            var earth_tilt = getEarthTilt(centuries);
            var sun_deviation = getSunDeviation(earth_tilt, ecliptic_longitude);
            var corrections = getCorrections(h, latitude, sun_deviation);
            var sun_time = calculateRiseTime(UTo, gha, longitude, corrections);
            var sun_rise_time = getRiseTime(sun_time, UTo, longitude, latitude, now);
            var zone = getZone(longitude);
            var hour = (int)(sun_rise_time / 15 + zone);
            var minute = (int)(60 * (sun_rise_time / 15 + zone - (int)(sun_rise_time / 15 + zone)));
            return new DateTime(now.Year, now.Month, now.Day, hour, minute, 0);
        }

        private static DateTime getSunSet(double longitude, double latitude, DateTime now)
        {
            var centuries = getCenturies(now, UTo);
            var l_sun = getLSun(centuries);
            var g_sun = getGSun(centuries);
            var ecliptic_longitude = getEclipticLongitude(l_sun, g_sun);
            var gha = getGHA(UTo, g_sun, ecliptic_longitude);
            var earth_tilt = getEarthTilt(centuries);
            var sun_deviation = getSunDeviation(earth_tilt, ecliptic_longitude);
            var corrections = getCorrections(h, latitude, sun_deviation);
            var sun_time = calculateSetTime(UTo, gha, longitude, corrections);
            var sun_set_time = getSetTime(sun_time, UTo, longitude, latitude, now);
            var zone = getZone(longitude);
            var hour = (int)(sun_set_time / 15 + zone);
            var minute = (int)(60 * (sun_set_time / 15 + zone - (int)(sun_set_time / 15 + zone)));
            return new DateTime(now.Year, now.Month, now.Day, hour, minute, 0);
        }

        public static bool getSunTime(double longitude, double latitude, DateTime now, out DateTime rise_time, out DateTime set_time)
        {
            rise_time = now;
            set_time = now;
            try
            {
                rise_time = getSunRise(longitude, latitude, now);
                set_time = getSunSet(longitude, latitude, now);
                return true;
            }
            catch { return false; }
        }
    }
}
