using System.Collections.Generic;

namespace wyk.basic
{
    /// <summary>
    /// 街道
    /// 第六级行政区域, 目前为最小行政区域单位
    /// (上一级行政区域为乡/镇[Town])
    /// </summary>
    public class Street : AreaBase
    {
        #region constructor
        public Street() { }

        public Street(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        #endregion
        /// <summary>
        /// 乡/镇ID
        /// </summary>
        public int town_id = 0;
    }
}
