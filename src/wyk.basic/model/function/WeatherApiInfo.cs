using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace wyk.basic
{
    /// <summary>
    /// 天气预报信息(与API返回对应)
    /// https://www.tianqiapi.com/api/?version=v1
    /// </summary>
    public class WeatherApiInfo
    {
        public string cityid = "";
        public string update_time = "";
        public string city = "";
        public List<WeatherApiInfoDay> data = new List<WeatherApiInfoDay>();
    }
    /// <summary>
    /// 每日天气信息
    /// </summary>
    public class WeatherApiInfoDay
    {
        public string day = "";
        public string date = "";
        public string week = "";
        public string wea = "";
        public string wea_img = "";
        public int air = 0;
        public int humidity = 0;
        public string air_level = "";
        public string air_tips = "";
        public string tem1 = "";
        public string tem2 = "";
        public string tem = "";
        public string win_speed = "";
        public List<string> win = new List<string>();
        public List<WeatherApiInfoHour> hours = new List<WeatherApiInfoHour>();
        public List<WeatherApiInfoIndex> index = new List<WeatherApiInfoIndex>();
    }

    /// <summary>
    /// 天气预警信息
    /// </summary>
    public class WeatherApiInfoAlarm
    {
        public string alarm_type = "";
        public string alarm_level = "";
        public string alarm_content = "";
    }

    /// <summary>
    /// 分时天气数据
    /// </summary>
    public class WeatherApiInfoHour
    {
        public string day = "";
        public string wea = "";
        public string tem = "";
        public string win = "";
        public string win_speed = "";
    }

    public class WeatherApiInfoIndex
    {
        public string title = "";
        public string level = "";
        public string desc = "";
    }
}