using Newtonsoft.Json;
using System.Collections.Generic;

namespace wyk.basic
{
    /// <summary>
    /// 县/区
    /// 第四级行政区域
    /// (上一级行政区域为市[City], 下一级行政区域为乡/镇[Town])
    /// </summary>
    public class District : AreaBase
    {
        [JsonIgnore]
        List<Town> _towns = null;
        #region constructor
        public District() { }

        public District(int city_id, int id, string name, string idcard_code)
        {
            this.city_id = city_id;
            this.id = id;
            this.name = name;
            this.idcard_code = idcard_code;
        }
        #endregion
        /// <summary>
        /// 市ID
        /// </summary>
        public int city_id = 0;
        /// <summary>
        /// 身份证号省代码(身份证号5~6位)
        /// </summary>
        public string idcard_code = "";

        [JsonIgnore]
        public List<Town> towns
        {
            get
            {
                if (_towns == null)
                {
                    _towns = new List<Town>();
                }
                return _towns;
            }
            set => _towns = value;
        }

        public List<Town> townsWithFilter(string filter)
        {
            var list = new List<Town>();
            foreach (var item in towns)
            {
                if (filter.isNull() || item.name.IndexOf(filter) >= 0 || item.shortcut.IndexOf(filter) >= 0)
                    list.Add(item);
            }
            return list;
        }
    }
}