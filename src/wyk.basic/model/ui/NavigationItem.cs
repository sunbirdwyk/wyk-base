namespace wyk.basic
{
    /// <summary>
    /// 导航栏项目
    /// </summary>
    public class NavigationItem
    {
        /// <summary>
        /// 显示文本内容
        /// </summary>
        public string text = "";
        /// <summary>
        /// 值
        /// </summary>
        public string value = "";
        /// <summary>
        /// 未选中时的图片
        /// </summary>
        public string image = "";
        /// <summary>
        /// 已选中时的图片
        /// </summary>
        public string image_selected = "";
        /// <summary>
        /// 相关联的分割线id（隐藏时需要同时隐藏此id的元素
        /// </summary>
        public string ref_seprator = "";

        public NavigationItem() { }
        public NavigationItem(string text, string value)
        {
            this.text = text;
            this.value = value;
        }
        public NavigationItem(string text, string value, string image)
        {
            this.text = text;
            this.value = value;
            this.image = image;
        }
    }
}
