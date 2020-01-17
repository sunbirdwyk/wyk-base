namespace wyk.api
{
    public class ApiSpecParameter
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        public string name = "";
        /// <summary>
        /// 参数类型
        /// </summary>
        public string type = "";
        /// <summary>
        /// 参数说明
        /// </summary>
        public string description = "";

        public ApiSpecParameter() { }
        public ApiSpecParameter(string name, string type, string description)
        {
            this.name = name;
            this.type = type;
            this.description = description;
        }
    }
}