using Newtonsoft.Json;
using System.Collections.Generic;

namespace wyk.basic
{
    public class UIDocumentContent
    {
        [JsonIgnore]
        protected ReplaceInfoList _replace_info_list = null;
        [JsonIgnore]
        public ReplaceInfoList replace_info_list
        {
            get
            {
                if (_replace_info_list == null)
                {
                    _replace_info_list = ReplaceInfoList.fromObject(this);
                }
                return _replace_info_list;
            }
        }
        [JsonIgnore]
        public List<UIPageInfo> extra_pages = new List<UIPageInfo>();

        public bool showPrePage(int index)
        {
            if (index <= 0)
                return false;
            foreach(var page in extra_pages)
            {
                if (page.page_type == UIPageType.Preset && page.page_index == index)
                    return true;
            }
            return false;
        }

        public bool showPostPage(int index)
        {
            if (index <= 0)
                return false;
            foreach (var page in extra_pages)
            {
                if (page.page_type == UIPageType.Postset && page.page_index == index)
                    return true;
            }
            return false;
        }
    }
}
