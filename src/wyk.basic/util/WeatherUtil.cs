using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace wyk.basic
{
    public class WeatherUtil
    {
        static List<WeatherArea> _areas = null;
        static string city_id = "";

        public static List<WeatherArea> weatherAreas()
        {
            if (_areas == null)
            {
                _areas = new List<WeatherArea>();
                try
                {
                    WebRequest wr = WebRequest.Create("https://cdn.huyahaha.com/tianqiapi/city.json");
                    Stream s = wr.GetResponse().GetResponseStream();
                    StreamReader sr = new StreamReader(s, Encoding.Default);
                    string data_str = sr.ReadToEnd(); //读取网站的数据
                    sr.Close();
                    s.Close();
                    _areas = JsonConvert.DeserializeObject<List<WeatherArea>>(data_str);
                }
                catch { _areas = new List<WeatherArea>(); }
            }
            return _areas;
        }

        public static WeatherApiInfo weather()
        {
            var url = "https://www.tianqiapi.com/api/?version=v1&appid=68369522&appsecret=HFArjY4H";
            if (!city_id.isNull())
                url += "&cityid=" + city_id;
            try
            {
                WebRequest wr = WebRequest.Create(url);
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string data_str = sr.ReadToEnd(); //读取网站的数据
                sr.Close();
                s.Close();
                var weather = JsonConvert.DeserializeObject<WeatherApiInfo>(data_str);
                if (city_id.isNull())
                    city_id = weather.cityid;
                return weather;
            }
            catch { }
            return null;
        }
    }
}