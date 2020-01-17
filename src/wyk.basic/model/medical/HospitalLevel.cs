namespace wyk.basic
{
    /// <summary>
    /// 医院等级划分类
    /// </summary>
    public class HospitalLevel
    {
        public string name = "无分级";
        public int value = 0;

        public HospitalLevel() { }
        public HospitalLevel(string name ,int value)
        {
            this.name = name;
            this.value = value;
        }

        /// <summary>
        /// "全部"选项
        /// </summary>
        /// <returns></returns>
        public static HospitalLevel allItem()
        {
            return new HospitalLevel("[全部]", -1);
        }
    }
}
