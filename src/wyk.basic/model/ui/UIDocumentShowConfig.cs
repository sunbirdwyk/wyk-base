using System.Collections.Generic;

namespace wyk.basic
{
    public class UIDocumentShowConfig
    {
        public List<UIPageInfo> extra_pages = new List<UIPageInfo>();

        public bool showPrePage(int index)
        {
            if (index <= 0)
                return false;
            foreach (var page in extra_pages)
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

        public void setExtraPageShow(UIPageType type,int index, bool status)
        {
            if (status)
            {
                for(int i = 0; i < extra_pages.Count; i++)
                {
                    if (extra_pages[i].page_type == type && extra_pages[i].page_index == index)
                        return;
                }
                extra_pages.Add(new UIPageInfo(type, index));
            }
            else
            {
                for (int i = 0; i < extra_pages.Count; i++)
                {
                    if (extra_pages[i].page_type == type && extra_pages[i].page_index == index)
                    {
                        extra_pages.RemoveAt(i);
                        return;
                    }
                }
            }
        }

        public void setAllExtraPage(int pre, int post)
        {
            extra_pages = new List<UIPageInfo>();
            for (int i = 1; i <= pre; i++)
                extra_pages.Add(new UIPageInfo(UIPageType.Preset, i));
            for (int i = 1; i <= post; i++)
                extra_pages.Add(new UIPageInfo(UIPageType.Postset, i));
        }
    }
}
