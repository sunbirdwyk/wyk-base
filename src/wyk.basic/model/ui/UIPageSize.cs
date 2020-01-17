using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace wyk.basic
{
    /// <summary>
    /// 页面尺寸大小管理类
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class UIPageSize : Attribute
    {
        #region static properties
        //A系列
        [UIPageSize(841, 1189)]
        public const string A0 = "A0";
        [UIPageSize(594, 841)]
        public const string A1 = "A1";
        [UIPageSize(420, 594)]
        public const string A2 = "A2";
        [UIPageSize(297, 420)]
        public const string A3 = "A3";
        [UIPageSize(210, 297)]
        public const string A4 = "A4";
        [UIPageSize(148, 210)]
        public const string A5 = "A5";
        [UIPageSize(105, 148)]
        public const string A6 = "A6";
        [UIPageSize(74, 105)]
        public const string A7 = "A7";
        [UIPageSize(52, 74)]
        public const string A8 = "A8";
        //B系列
        [UIPageSize(1000, 1414)]
        public const string B0 = "B0";
        [UIPageSize(707, 1000)]
        public const string B1 = "B1";
        [UIPageSize(500, 707)]
        public const string B2 = "B2";
        [UIPageSize(353, 500)]
        public const string B3 = "B3";
        [UIPageSize(250, 353)]
        public const string B4 = "B4";
        [UIPageSize(176, 250)]
        public const string B5 = "B5";
        [UIPageSize(125, 176)]
        public const string B6 = "B6";
        [UIPageSize(88, 125)]
        public const string B7 = "B7";
        [UIPageSize(62, 88)]
        public const string B8 = "B8";
        #endregion

        /// <summary>
        /// 支持的标准页面尺寸(临时存储)
        /// </summary>
        [JsonIgnore]
        static List<UIPageSize> _standard_page_sizes = null;

        /// <summary>
        /// 支持的标准页面尺寸
        /// </summary>
        [JsonIgnore]
        public static List<UIPageSize> standardPageSizes
        {
            get
            {
                if (_standard_page_sizes == null)
                {
                    _standard_page_sizes = new List<UIPageSize>();
                    FieldInfo[] fields = typeof(UIPageSize).GetFields();
                    foreach (FieldInfo info in fields)
                    {
                        try
                        {
                            var attr = info.getAttribute<UIPageSize>();
                            if (attr != null)
                            {
                                var ps = new UIPageSize(info.GetValue(attr).ToString(), attr.size.Width, attr.size.Height);
                                _standard_page_sizes.Add(ps);
                            }
                        }
                        catch { }
                    }
                }
                return _standard_page_sizes;
            }
        }
        public static string[] standardPageSizeNames()
        {
            var res = new string[standardPageSizes.Count];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = standardPageSizes[i].name;
            }
            return res;
        }
        [JsonIgnore]
        SizeF _size = new SizeF(0, 0);
        [JsonIgnore]
        string _name = "A4";

        public UIPageSize() { }

        /// <summary>
        /// 初始化页面大小设置(页尺寸名称, 如: A4)
        /// </summary>
        /// <param name="Name">页面尺寸名称</param>
        public UIPageSize(string Name)
        {
            name = Name;
        }

        /// <summary>
        /// 初始化页面大小设置(mm)
        /// </summary>
        /// <param name="Width">页面宽度(mm)</param>
        /// <param name="Height">页面高度(mm)</param>
        public UIPageSize(float Width, float Height)
        {
            size = new SizeF(Width, Height);
        }

        /// <summary>
        /// 初始化页面大小设置(mm)
        /// </summary>
        /// <param name="Name">页面名称</param>
        /// <param name="Width">页面宽度(mm)</param>
        /// <param name="Height">页面高度(mm)</param>
        public UIPageSize(string Name, float Width, float Height)
        {
            _name = Name;
            _size = new SizeF(Width, Height);
        }
        [JsonIgnore]
        public SizeF size
        {
            get => _size;
            set
            {
                _size = value;
                bool found = false;
                foreach (UIPageSize ps in standardPageSizes)
                {
                    if (ps.size == _size)
                    {
                        found = true;
                        _name = ps.name;
                        break;
                    }
                }
                if (!found)
                {
                    _name = "[自定义]";
                }
            }
        }
        [JsonIgnore]
        public Size size_px
        {
            get => new Size(UIUtil.pxFromMM(_size.Width), UIUtil.pxFromMM(_size.Height));
            set => size = new SizeF(UIUtil.mmFromPx(value.Width), UIUtil.mmFromPx(value.Height));
        }
        [JsonIgnore]
        public SizeF size_pt
        {
            get => new SizeF(UIUtil.ptFromMM(_size.Width), UIUtil.ptFromMM(_size.Height));
            set => size = new SizeF(UIUtil.mmFromPt(value.Width), UIUtil.mmFromPt(value.Height));
        }
        public float width
        {
            get => size.Width;
            set => size = new SizeF(value, size.Height);
        }

        public float height
        {
            get => size.Height;
            set => size = new SizeF(size.Width, value);
        }

        public int width_px
        {
            get => size_px.Width;
            set => size_px = new Size(value, size_px.Height);
        }

        public int height_px
        {
            get => size_px.Height;
            set => size_px = new Size(size_px.Width, value);
        }

        public float width_pt
        {
            get => size_pt.Width;
            set => size_pt = new SizeF(value, size_pt.Height);
        }

        public float height_pt
        {
            get => size_pt.Height;
            set => size_pt = new SizeF(size_pt.Width, value);
        }

        public string name
        {
            get => _name;
            set
            {
                if (value.IndexOf(',') >= 0)
                {
                    var parts = value.Split(',');
                    var ps = new SizeF();
                    try
                    {
                        ps.Width = (float)Convert.ToDouble(parts[0]);
                    }
                    catch { ps.Width = 210; }
                    try
                    {
                        ps.Height = (float)Convert.ToDouble(parts[1]);
                    }
                    catch { ps.Height = 297; }
                    size = ps;
                }
                else
                {
                    _name = value.ToUpper();
                    foreach (UIPageSize ps in standardPageSizes)
                    {
                        if (ps.name == _name)
                        {
                            _size = ps.size;
                            break;
                        }
                    }
                }
            }
        }
    }
}