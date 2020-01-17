using System.Collections.Generic;

namespace wyk.basic
{
    public class NavigationContent
    {
        /// <summary>
        /// 子项目集合
        /// </summary>
        public List<NavigationItem> nav_items = new List<NavigationItem>();
        /// <summary>
        /// 当前所选子项目Value
        /// </summary>
        public string selected = "";

        /// <summary>
        /// 子项目css class
        /// </summary>
        public string item_class = "nav-item";
        /// <summary>
        /// 子项目css class(已选中)
        /// </summary>
        public string item_class_selected = "nav-item-sel";
        /// <summary>
        /// 容器css class
        /// </summary>
        public string container_class = "nav-container";

        /// <summary>
        /// 当前选中子项目的顺序号
        /// </summary>
        public int selectedIndex
        {
            get
            {
                if (selected.isNull())
                    return -1;
                for (int i = 0; i < nav_items.Count; i++)
                {
                    if (nav_items[i].value == selected)
                        return i;
                }
                return -1;
            }
            set
            {
                if (value < 0 || value >= nav_items.Count)
                    selected = "";
                else
                    selected = nav_items[value].value;
            }
        }

        public void initCSS(string item_class, string item_class_selected, string container_class)
        {
            this.item_class = item_class;
            this.item_class_selected = item_class_selected;
            this.container_class = container_class;
        }

        public void initItems<TEnum>()
        {
            nav_items = new List<NavigationItem>();
            var all = EnumUtil.allValuePair<TEnum>();
            foreach (var item in all.pair_list)
            {
                nav_items.Add(new NavigationItem(item.name, item.value));
            }
        }
    }
}
