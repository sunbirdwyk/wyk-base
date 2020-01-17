using Newtonsoft.Json;
using System;

namespace wyk.basic
{
    /// <summary>
    /// Padding管理类
    /// </summary>
    public class UIPadding
    {
        /// <summary>
        /// padding-top in mm
        /// </summary>
        public float top = 0;
        /// <summary>
        /// padding-right in mm
        /// </summary>
        public float right = 0;
        /// <summary>
        /// padding-bottom in mm
        /// </summary>
        public float bottom = 0;
        /// <summary>
        /// padding-left in mm
        /// </summary>
        public float left = 0;

        public UIPadding() { }

        public static UIPadding instanceByPx(int all)
        {
            return instanceByPx(all, all, all, all);
        }

        public static UIPadding instanceByPx(int top, int right, int bottom, int left)
        {
            UIPadding padding = new UIPadding();
            padding.top_px = top;
            padding.right_px = right;
            padding.bottom_px = bottom;
            padding.left_px = left;
            return padding;
        }

        public static UIPadding instanceByPt(float all)
        {
            return instanceByPt(all, all, all, all);
        }

        public static UIPadding instanceByPt(float top, float right, float bottom, float left)
        {
            UIPadding padding = new UIPadding();
            padding.top_pt = top;
            padding.right_pt = right;
            padding.bottom_pt = bottom;
            padding.left_pt = left;
            return padding;
        }

        public static UIPadding instanceByMM(float all)
        {
            return instanceByMM(all, all, all, all);
        }

        public static UIPadding instanceByMM(float top, float right, float bottom, float left)
        {
            UIPadding padding = new UIPadding();
            padding.top = top;
            padding.right = right;
            padding.bottom = bottom;
            padding.left = left;
            return padding;
        }

        /// <summary>
        /// mm为单位的字符串, 逗号分隔
        /// </summary>
        [JsonIgnore]
        public string content_mm
        {
            get => getContent(UIUnit.mm, ",");
            set => setContent(value, UIUnit.mm);
        }

        /// <summary>
        /// pt为单位的字符串, 逗号分隔
        /// </summary>
        [JsonIgnore]
        public string content_pt
        {
            get => getContent(UIUnit.pt, ",");
            set => setContent(value, UIUnit.pt);
        }

        /// <summary>
        /// px 为单位的字符串, 空格分隔
        /// </summary>
        [JsonIgnore]
        public string content_px
        {
            get => getContent(UIUnit.px, ",");
            set => setContent(value, UIUnit.px);
        }

        public string getContent(UIUnit unit, string seperator)
        {
            switch (unit)
            {
                case UIUnit.mm:
                default:
                    return string.Format("{0}{4}{1}{4}{2}{4}{3}", top, right, bottom, left, seperator);
                case UIUnit.pt:
                    return string.Format("{0}{4}{1}{4}{2}{4}{3}", top_pt, right_pt, bottom_pt, left_pt, seperator);
                case UIUnit.px:
                    return string.Format("{0}{4}{1}{4}{2}{4}{3}", top_px, right_px, bottom_px, left_px, seperator);
            }
        }
        public void setContent(string content, UIUnit unit)
        {
            string[] parts = null;
            if (content.IndexOf(',') >= 0)
                parts = content.Split(',');
            else
                parts = content.Split(' ');
            switch (unit)
            {
                case UIUnit.mm:
                default:
                    try
                    {
                        top = (float)Convert.ToDouble(parts[0]);
                    }
                    catch { top = 0; }
                    try
                    {
                        right = (float)Convert.ToDouble(parts[1]);
                    }
                    catch { right = 0; }
                    try
                    {
                        bottom = (float)Convert.ToDouble(parts[2]);
                    }
                    catch { bottom = 0; }
                    try
                    {
                        left = (float)Convert.ToDouble(parts[3]);
                    }
                    catch { left = 0; }
                    break;
                case UIUnit.pt:
                    try
                    {
                        top_pt = (float)Convert.ToDouble(parts[0]);
                    }
                    catch { top_pt = 0; }
                    try
                    {
                        right_pt = (float)Convert.ToDouble(parts[1]);
                    }
                    catch { right_pt = 0; }
                    try
                    {
                        bottom_pt = (float)Convert.ToDouble(parts[2]);
                    }
                    catch { bottom_pt = 0; }
                    try
                    {
                        left_pt = (float)Convert.ToDouble(parts[3]);
                    }
                    catch { left_pt = 0; }
                    break;
                case UIUnit.px:
                    try
                    {
                        top_px = Convert.ToInt32(parts[0]);
                    }
                    catch { top_px = 0; }
                    try
                    {
                        right_px = Convert.ToInt32(parts[1]);
                    }
                    catch { right_px = 0; }
                    try
                    {
                        bottom_px = Convert.ToInt32(parts[2]);
                    }
                    catch { bottom_px = 0; }
                    try
                    {
                        left_px = Convert.ToInt32(parts[3]);
                    }
                    catch { left_px = 0; }
                    break;
            }
        }

        [JsonIgnore]
        public string cssStyle
        {
            get
            {
                if (top == 0 && right == 0 && bottom == 0 && left == 0)
                    return "";
                return string.Format("padding:{0}px {1}px {2}px {3}px;", top_px, right_px, bottom_px, left_px);
            }
        }

        public int top_px
        {
            get => UIUtil.pxFromMM(top);
            set => top = UIUtil.mmFromPx(value);
        }

        public int right_px
        {
            get => UIUtil.pxFromMM(right);
            set => right = UIUtil.mmFromPx(value);
        }
        public int bottom_px
        {
            get => UIUtil.pxFromMM(bottom);
            set => bottom = UIUtil.mmFromPx(value);
        }
        public int left_px
        {
            get => UIUtil.pxFromMM(left);
            set => left = UIUtil.mmFromPx(value);
        }

        public float top_pt
        {
            get => UIUtil.ptFromMM(top);
            set => top = UIUtil.mmFromPt(value);
        }
        public float right_pt
        {
            get => UIUtil.ptFromMM(right);
            set => right = UIUtil.mmFromPt(value);
        }
        public float bottom_pt
        {
            get => UIUtil.ptFromMM(bottom);
            set => bottom = UIUtil.mmFromPt(value);
        }
        public float left_pt
        {
            get => UIUtil.ptFromMM(left);
            set => left = UIUtil.mmFromPt(value);
        }
    }
}