namespace wyk.basic
{
    /// <summary>
    /// 乡/镇
    /// 第五级行政区域
    /// (上一级行政区域为县/区[District], 下一级行政区域为街道[Street])
    /// </summary>
    public class Town : AreaBase
    {
        #region constructor
        public Town() { }

        public Town(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        #endregion
        /// <summary>
        /// 县/区ID
        /// </summary>
        public int district_id = 0;
    }
}
