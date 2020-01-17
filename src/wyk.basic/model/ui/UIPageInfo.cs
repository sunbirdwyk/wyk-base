using System;

namespace wyk.basic
{
    /// <summary>
    /// 文档(单据/报告等)的页面信息
    /// </summary>
    public class UIPageInfo
    {
        public const string PAGE_TYPE_PRE = "Pre";
        public const string PAGE_TYPE_CONTENT = "Content";
        public const string PAGE_TYPE_POST = "Post";

        /// <summary>
        /// 页面类型
        /// </summary>
        public UIPageType page_type = UIPageType.Content;
        public string PageType
        {
            get => PageTypeToString(page_type);
            set => page_type = PageTypeFromString(value);
        }
        /// <summary>
        /// 页面序号
        /// 注: 此处非页码, 此序号为当前页在此页面类型中的顺序号, 页面类型为Content时, 此值无意义
        /// </summary>
        public int page_index = 0;

        public UIPageInfo() { }
        public UIPageInfo(UIPageType type, int index)
        {
            page_type = type;
            setPageIndex(index);
        }
        public UIPageInfo(string type, int index)
        {
            page_type = PageTypeFromString(type);
            setPageIndex(index);
        }

        public static UIPageInfo fromString(string string_value)
        {
            var info = new UIPageInfo();
            info.StringValue = string_value;
            return info;
        }

        public static UIPageInfo fromDisplay(string display)
        {
            var info = new UIPageInfo();
            info.Display = display;
            return info;
        }

        public void setPageIndex(int index)
        {
            switch (page_type)
            {
                case UIPageType.Content:
                default:
                    page_index = 0;
                    break;
                case UIPageType.Postset:
                case UIPageType.Preset:
                    page_index = index;
                    if (page_index <= 0)
                        page_index = 1;
                    break;
            }
        }

        public bool Equals(UIPageInfo page_info)
        {
            if (page_type != page_info.page_type)
                return false;
            if (page_type != UIPageType.Content && page_index != page_info.page_index)
                return false;
            return true;
        }

        public string StringValue
        {
            get
            {
                switch (page_type)
                {
                    case UIPageType.Postset:
                        return PAGE_TYPE_POST + "_" + page_index;
                    case UIPageType.Preset:
                        return PAGE_TYPE_PRE + "_" + page_index;
                    case UIPageType.Content:
                    default:
                        return PAGE_TYPE_CONTENT;
                }
            }
            set
            {
                try
                {
                    var parts = value.Split('_');
                    page_type = PageTypeFromString(parts[0]);
                    setPageIndex(Convert.ToInt32(parts[1]));
                }
                catch
                {
                    page_type = UIPageType.Content;
                    page_index = 0;
                }
            }
        }

        public string Display
        {
            get
            {
                switch (page_type)
                {
                    case UIPageType.Postset:
                        return "后附加页" + page_index;
                    case UIPageType.Preset:
                        return "前附加页" + page_index;
                    case UIPageType.Content:
                    default:
                        return "内容页";
                }
            }
            set
            {
                page_type = UIPageType.Content;
                page_index = 0;
                try
                {
                    var prefix = value.Substring(0, 4);
                    if (prefix == "前附加页")
                    {
                        page_index = Convert.ToInt32(value.Substring(4));
                        page_type = UIPageType.Preset;
                    }
                    else if (prefix == "后附加页")
                    {
                        page_index = Convert.ToInt32(value.Substring(4));
                        page_type = UIPageType.Postset;
                    }
                }
                catch { }
            }
        }

        public static string PageTypeToString(UIPageType page_type)
        {
            switch (page_type)
            {
                case UIPageType.Content:
                default:
                    return PAGE_TYPE_CONTENT;
                case UIPageType.Postset:
                    return PAGE_TYPE_POST;
                case UIPageType.Preset:
                    return PAGE_TYPE_PRE;
            }
        }

        public static UIPageType PageTypeFromString(string page_type)
        {
            switch (page_type.ToLower())
            {
                case "content":
                default:
                    return UIPageType.Content;
                case "pre":
                case "preset":
                    return UIPageType.Preset;
                case "post":
                case "postset":
                    return UIPageType.Postset;
            }
        }
    }
}