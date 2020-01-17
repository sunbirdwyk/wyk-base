using Newtonsoft.Json;
using System.Collections.Generic;

namespace wyk.basic
{
    /// <summary>
    /// 页面样式配置基类
    /// </summary>
    public class UIDocumentConfigBase
    {
        /// <summary>
        /// 页面宽,高, mm, 例: 210,297
        /// </summary>
        [JsonIgnore]
        public string page_size
        {
            get => PageSize.size.Width + "," + PageSize.size.Height;
            set => PageSize = new UIPageSize(value);
         
        }
        public UIPageSize PageSize = new UIPageSize("A4");
     
        /// <summary>
        /// 页面边距, mm, (上,右,下,左)
        /// </summary>
        [JsonIgnore]
        public string page_padding
        {
            get => PagePadding.content_mm;
            set => PagePadding.content_mm = value;
        }
        public UIPadding PagePadding = UIPadding.instanceByMM(15);

        /// <summary>
        /// 页眉设置
        /// </summary>
        [JsonIgnore]
        public string header_config
        {
            get => JsonConvert.SerializeObject(HeaderConfig);
            set
            {
                HeaderConfig = JsonConvert.DeserializeObject<UIHeaderFooter>(value);
                if (HeaderConfig == null)
                    HeaderConfig = new UIHeaderFooter();
            }
        }
        public UIHeaderFooter HeaderConfig = new UIHeaderFooter();

        /// <summary>
        /// 页脚设置
        /// </summary>
        [JsonIgnore]
        public string footer_config
        {
            get => JsonConvert.SerializeObject(FooterConfig);
            set
            {
                FooterConfig = JsonConvert.DeserializeObject<UIHeaderFooter>(value);
                if (FooterConfig == null)
                    FooterConfig = new UIHeaderFooter();
            }
        }
        public UIHeaderFooter FooterConfig = new UIHeaderFooter();

        /// <summary>
        /// 前附加页页数
        /// </summary>
        public int pre_page_count = 0;
        /// <summary>
        /// 后附加页页数
        /// </summary>
        public int post_page_count = 0;

        /// <summary>
        /// 内容样式设置
        /// </summary>
        [JsonIgnore]
        public string content_config
        {
            get => JsonConvert.SerializeObject(ContentConfig);
            set
            {
                ContentConfig = JsonConvert.DeserializeObject<UIContent>(value);
                if (ContentConfig == null)
                    ContentConfig = new UIContent();
            }
        }
        public UIContent ContentConfig = new UIContent();

        /// <summary>
        /// 页码样式设置
        /// </summary>
        [JsonIgnore]
        public string page_number
        {
            get => JsonConvert.SerializeObject(PageNumber);
            set
            {
                PageNumber = JsonConvert.DeserializeObject<UIPageNumber>(value);
                if (PageNumber == null)
                    PageNumber = new UIPageNumber();
            }
        }
        public UIPageNumber PageNumber = new UIPageNumber();

        public List<UIPageItem> page_items = null;

        #region Page Items Functions
        /// <summary>
        /// 获取某页的页面元素列表
        /// </summary>
        /// <param name="page_info">页面信息</param>
        /// <returns></returns>
        public List<UIPageItem> itemsForPage(UIPageInfo page_info)
        {
            return itemsForPage(page_items, page_info);
        }

        /// <summary>
        /// 从1开始重新为每个页面元素赋ID
        /// </summary>
        public void resetPageItemIds()
        {
            for (int i = 1; i <= page_items.Count; i++)
                page_items[i - 1].item_id = i;
        }

        /// <summary>
        /// 获取某页的页面元素列表(静态)
        /// </summary>
        /// <param name="item_list">页面元素总列表</param>
        /// <param name="type">页面类型</param>
        /// <param name="index">页序号</param>
        /// <returns></returns>
        public static List<UIPageItem> itemsForPage(List<UIPageItem> item_list, UIPageInfo page_info)
        {
            var list = new List<UIPageItem>();
            if (item_list == null || item_list.Count == 0)
                return list;
            foreach (var item in item_list)
            {
                if (item.PageInfo.Equals(page_info))
                    list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// 使用替换字段将header/footer中可替换的字段处理掉
        /// </summary>
        /// <param name="replace_info"></param>
        public void processContentForReplaceInfo(ReplaceInfoList replace_info)
        {
            HeaderConfig.processContentForReplaceInfo(replace_info);
            FooterConfig.processContentForReplaceInfo(replace_info);
            PageNumber.processContentForReplaceInfo(replace_info);
            for (int i = 0; i < page_items.Count; i++)
            {
                if (page_items[i].ItemType == UIPageItemType.Picture ||
                    page_items[i].ItemType == UIPageItemType.Rectangle)
                    continue;
                page_items[i].content = replace_info.process(page_items[i].content);
            }
        }
        #endregion
    }
}
