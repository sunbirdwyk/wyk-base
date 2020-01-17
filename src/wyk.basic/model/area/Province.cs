using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using wyk.basic.fixed_data;

namespace wyk.basic
{
    /// <summary>
    /// 省
    /// 第二级行政区域
    /// (上级行政区域为国家[Country], 下一级行政区域为市[City])
    /// </summary>
    public class Province : AreaBase
    {
        [JsonIgnore]
        List<City> _cities = null;

        #region constructor
        public Province() { }
        public Province(int id, string name, string symbol, string idcard_code)
        {
            this.id = id;
            this.country_id = 1;
            this.name = name;
            this.symbol = symbol;
            this.symbol2 = "";
            this.idcard_code = idcard_code;
        }

        public Province(int id, string name, string symbol, string symbol2, string idcard_code)
        {
            this.id = id;
            this.country_id = 1;
            this.name = name;
            this.symbol = symbol;
            this.symbol2 = symbol2;
            this.idcard_code = idcard_code;
        }

        public Province(int country_id, int id, string name, string symbol, string symbol2, string idcard_code)
        {
            this.id = id;
            this.country_id = country_id;
            this.name = name;
            this.symbol = symbol;
            this.symbol2 = symbol2;
            this.idcard_code = idcard_code;
        }
        #endregion

        /// <summary>
        /// 国籍(国家)ID
        /// </summary>
        public int country_id = 0;
        /// <summary>
        /// 省简称
        /// </summary>
        public string symbol = "";
        /// <summary>
        /// 省简称2(有的省有两个简称)
        /// </summary>
        public string symbol2 = "";
        /// <summary>
        /// 身份证号省代码(身份证号前两位)
        /// </summary>
        public string idcard_code = "";

        [JsonIgnore]
        public List<City> cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new List<City>();
                    CityList list = new CityList();
                    FieldInfo[] fields = list.GetType().GetFields();
                    foreach (FieldInfo fi in fields)
                    {
                        if (fi.FieldType == typeof(City))
                        {
                            City city = fi.GetValue(list) as City;
                            if (city.province_id == id)
                                _cities.Add(city);
                        }
                    }
                }
                return _cities;
            }
            set => _cities = value;
        }

        public City cityById(int id)
        {
            foreach (City item in cities)
            {
                if (item.id == id)
                    return item;
            }
            return null;
        }

        public City cityByName(string name)
        {
            foreach (City item in cities)
            {
                if (item.name == name)
                    return item;
            }
            return null;
        }

        public City cityByCode(string code)
        {
            foreach (City item in cities)
            {
                if (item.idcard_code == code)
                    return item;
            }
            return null;
        }

        public List<City> citiesWithFilter(string filter)
        {
            var list = new List<City>();
            foreach (var item in cities)
            {
                if (filter.isNull() || item.name.IndexOf(filter) >= 0 || item.shortcut.IndexOf(filter) >= 0)
                    list.Add(item);
            }
            return list;
        }

        public string[] cityNames()
        {
            string[] list = new string[cities.Count];
            for (int i = 0; i < cities.Count; i++)
                list[i] = cities[i].name;
            return list;
        }
    }
}
