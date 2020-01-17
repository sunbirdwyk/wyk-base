using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using wyk.basic.fixed_data;

namespace wyk.basic
{
    /// <summary>
    /// 市
    /// 第三级行政区域
    /// (上一级行政区域为省[Province],下一级行政区域为县/区[District])
    /// </summary>
    public class City : AreaBase
    {
        [JsonIgnore]
        List<District> _districts = null;
        #region constructor
        public City() { }
        public City(int province_id, int id, string name, string idcard_code)
        {
            this.province_id = province_id;
            this.id = id;
            this.name = name;
            this.idcard_code = idcard_code;
        }
        #endregion
        /// <summary>
        /// 省ID
        /// </summary>
        public int province_id = 0;
        /// <summary>
        /// 身份证号省代码(身份证号3~4位)
        /// </summary>
        public string idcard_code = "";

        [JsonIgnore]
        public List<District> districts
        {
            get
            {
                if (_districts == null)
                {
                    _districts = new List<District>();
                    DistrictList list = new DistrictList();
                    FieldInfo[] fields = list.GetType().GetFields();
                    foreach (FieldInfo fi in fields)
                    {
                        if (fi.FieldType == typeof(District))
                        {
                            District district = fi.GetValue(list) as District;
                            if (district.city_id == id)
                                _districts.Add(district);
                        }
                    }
                }
                return _districts;
            }
            set => _districts = value;
        }

        public District districtById(int id)
        {
            foreach (District item in districts)
            {
                if (item.id == id)
                    return item;
            }
            return null;
        }

        public District districtByName(string name)
        {
            foreach (District item in districts)
            {
                if (item.name == name)
                    return item;
            }
            return null;
        }

        public District districtByCode(string code)
        {
            foreach (District item in districts)
            {
                if (item.idcard_code == code)
                    return item;
            }
            return null;
        }

        public List<District> districtsWithFilter(string filter)
        {
            var list = new List<District>();
            foreach (var item in districts)
            {
                if (filter.isNull() || item.name.IndexOf(filter) >= 0 || item.shortcut.IndexOf(filter) >= 0)
                    list.Add(item);
            }
            return list;
        }

        public string[] districtNames()
        {
            string[] list = new string[districts.Count];
            for (int i = 0; i < districts.Count; i++)
                list[i] = districts[i].name;
            return list;
        }
    }
}