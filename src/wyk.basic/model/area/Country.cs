using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using wyk.basic.fixed_data;

namespace wyk.basic
{
    /// <summary>
    /// 国籍(国家)
    /// 最高级(1级)行政区域
    /// (下一级行政区域为省[Province])
    /// </summary>
    public class Country : AreaBase
    {
        [JsonIgnore]
        List<Province> _provinces = null;

        #region constructor
        public Country() { }

        public Country(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        #endregion

        [JsonIgnore]
        public List<Province> provinces
        {
            get
            {
                if (_provinces == null)
                {
                    _provinces = new List<Province>();
                    ProvinceList list = new ProvinceList();
                    FieldInfo[] fields = list.GetType().GetFields();
                    foreach (FieldInfo fi in fields)
                    {
                        if (fi.FieldType == typeof(Province))
                        {
                            Province province = fi.GetValue(list) as Province;
                            if (province.country_id == id)
                                _provinces.Add(province);
                        }
                    }
                }
                return _provinces;
            }
            set => _provinces = value;
        }

        public Province provinceById(int id)
        {
            foreach (Province item in provinces)
            {
                if (item.id == id)
                    return item;
            }
            return null;
        }

        public Province provinceByName(string name)
        {
            foreach (Province item in provinces)
            {
                if (item.name == name)
                    return item;
            }
            return null;
        }

        public List<Province> provincesWithFilter(string filter)
        {
            var list = new List<Province>();
            foreach (var item in provinces)
            {
                if (filter.isNull() || item.name.IndexOf(filter) >= 0 || item.shortcut.IndexOf(filter) >= 0)
                    list.Add(item);
            }
            return list;
        }

        public Province provinceByCode(string code)
        {
            foreach (Province item in provinces)
            {
                if (item.idcard_code == code)
                    return item;
            }
            return null;
        }
    }
}