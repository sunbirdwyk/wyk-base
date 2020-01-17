using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using wyk.basic.fixed_data;

namespace wyk.basic
{
    /// <summary>
    /// 区域相关操作类
    /// </summary>
    public class AreaUtil
    {
        [JsonIgnore]
        static List<Country> _countries = null;

        /// <summary>
        /// 获取当前支持的所有国家列表
        /// </summary>
        [JsonIgnore]
        public static List<Country> countries
        {
            get
            {
                if (_countries == null)
                {
                    _countries = new List<Country>();
                    CountryList list = new CountryList();
                    FieldInfo[] fields = list.GetType().GetFields();
                    foreach (FieldInfo fi in fields)
                    {
                        if (fi.FieldType == typeof(Country))
                        {
                            Country country = fi.GetValue(list) as Country;
                            _countries.Add(country);
                        }
                    }
                }
                return _countries;
            }
        }

        /// <summary>
        /// 获取当前支持的所有省列表(中国)
        /// </summary>
        [JsonIgnore]
        public static List<Province> provinces
        {
            get
            {
                if (countries == null || countries.Count <= 0)
                    return new List<Province>();
                return countries[0].provinces;
            }
        }

        public static bool isValidAreaCode(string area_code)
        {
            Province province = null;
            City city = null;
            District district = null;
            AreaUtil.areaByCode(area_code, out province, out city, out district);
            if (province.id > 0 && city.id > 0 && district.id > 0 && district.id != 999999)
                return true;
            return false;
        }

        public static Province provinceById(int id)
        {
            try
            {
                return countries[0].provinceById(id);
            }
            catch { return null; }
        }

        public static Province provinceByName(string name)
        {
            try
            {
                return countries[0].provinceByName(name);
            }
            catch { return null; }
        }

        public static Province provinceByCode(string code)
        {
            try
            {
                return countries[0].provinceByCode(code);
            }
            catch { return null; }
        }

        public static City cityByCode(string code)
        {
            if (code.isNull() || code.Length != 4)
                return null;
            try
            {
                Province province = provinceByCode(code.Substring(0, 2));
                if (province == null)
                    return null;
                return province.cityByCode(code);
            }
            catch { }
            return null;
        }

        public static District districtByCode(string code)
        {
            if (code.isNull() || code.Length != 6)
                return null;
            try
            {
                City city = cityByCode(code.Substring(0, 4));
                if (city == null)
                    return null;
                return city.districtByCode(code);
            }
            catch { }
            return null;
        }

        /// <summary>
        /// 根据区域代码获取省市区信息
        /// </summary>
        /// <param name="area_code">区域代码(通常为身份证号前6位)</param>
        /// <param name="province">省</param>
        /// <param name="city">市</param>
        /// <param name="district">县/区</param>
        public static void areaByCode(string area_code, out Province province, out City city, out District district)
        {
            province = new Province();
            city = new City();
            district = new District();
            if (area_code.Length != 6)
                return;
            string province_code = area_code.Substring(0, 2);
            foreach (Province p in provinces)
            {
                if (p.idcard_code == province_code)
                {
                    province = p;
                    string city_code = area_code.Substring(2, 2);
                    foreach (City c in p.cities)
                    {
                        if (c.idcard_code == city_code)
                        {
                            city = c;
                            string district_code = area_code.Substring(4);
                            foreach (District d in c.districts)
                            {
                                if (d.idcard_code == district_code)
                                {
                                    district = d;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            if (province.id > 0 && city.id > 0 && district.id == 0)
            {
                district.id = 999999;
                district.name = "市辖区";
            }
        }

        /// <summary>
        /// 根据区域代码获取省市区字符串
        /// </summary>
        /// <param name="area_code">区域代码(通常为身份证号前6位)</param>
        /// <param name="separator">分隔符</param>
        /// <returns>省市区字符串</returns>
        public static string areaStringByCode(string area_code, string separator)
        {
            Province province = null;
            City city = null;
            District district = null;
            areaByCode(area_code, out province, out city, out district);
            return province.name + separator + city.name + separator + district.name;
        }

        /// <summary>
        /// 根据区域代码获取省市区字符串
        /// </summary>
        /// <param name="area_code">区域代码(通常为身份证号前6位)</param>
        /// <returns>省市区字符串</returns>
        public static string areaStringByCode(string area_code)
        {
            return areaStringByCode(area_code, "");
        }

        /// <summary>
        /// 获取省名列表
        /// </summary>
        /// <returns></returns>
        public static string[] provinceNames()
        {
            string[] list = new string[provinces.Count];
            for(int i = 0; i < provinces.Count; i++)
            {
                list[i] = provinces[i].name;
            }
            return list;
        }

        /// <summary>
        /// 根据筛选条件获取省列表
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <returns></returns>
        public static List<Province> provincesWithFilter(string filter)
        {
            var list = new List<Province>();
            foreach (var item in provinces)
            {
                if (filter.isNull() || item.name.IndexOf(filter) >= 0 || item.shortcut.IndexOf(filter) >= 0)
                    list.Add(item);
            }
            return list;
        }
    }
}