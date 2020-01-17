using Newtonsoft.Json;
using System.Drawing;

namespace wyk.basic
{
    public class UIContent
    {
        /// <summary>
        /// 边框颜色
        /// </summary>
        [JsonIgnore]
        public Color BorderColor = Color.FromArgb(224, 224, 224);
        public string border_color
        {
            get => BorderColor.hexString();
            set => BorderColor = value.color();
        }

        /// <summary>
        /// 是否显示边框
        /// </summary>
        public bool show_border = true;

        /// <summary>
        /// 行高
        /// </summary>
        public float line_height = 1.0f;

        [JsonIgnore]
        public UIFont TitleFont = new UIFont("微软雅黑", 11, FontStyle.Bold, Color.White, AlignHorizontal.Left);
        /// <summary>
        /// 标题字体设置
        /// </summary>
        public string title_font
        {
            get => TitleFont.content;
            set => TitleFont.content = value;
        }
        [JsonIgnore]
        public UIPadding TitlePadding = UIPadding.instanceByPx(8);
        /// <summary>
        /// 标题字体边距
        /// </summary>
        public string title_padding
        {
            get => TitlePadding.content_mm;
            set => TitlePadding.content_mm = value;
        }
        [JsonIgnore]
        public Color TitleBGColor = Color.FromArgb(150, 150, 150);
        /// <summary>
        /// 标题背景色
        /// </summary>
        public string title_bg_color
        {
            get => TitleBGColor.hexString();
            set => TitleBGColor = value.color();
        }

        [JsonIgnore]
        public UIFont TextTitleFont = new UIFont("微软雅黑", 9, FontStyle.Bold, Color.FromArgb(50, 50, 50), AlignHorizontal.Left);
        /// <summary>
        /// 项目标题字体设置
        /// </summary>
        public string texttitle_font
        {
            get => TextTitleFont.content;
            set => TextTitleFont.content = value;
        }
        [JsonIgnore]
        public UIPadding TextTitlePadding = UIPadding.instanceByPx(5);
        /// <summary>
        /// 项目标题字体边距
        /// </summary>
        public string texttitle_padding
        {
            get => TextTitlePadding.content_mm;
            set => TextTitlePadding.content_mm = value;
        }
        [JsonIgnore]
        public Color TextTitleBGColor = Color.White;
        /// <summary>
        /// 项目标题背景色
        /// </summary>
        public string texttitle_bg_color
        {
            get => TextTitleBGColor.hexString();
            set => TextTitleBGColor = value.color();
        }

        [JsonIgnore]
        public UIFont ContentFont = new UIFont("微软雅黑", 9, FontStyle.Regular, Color.FromArgb(50, 50, 50), AlignHorizontal.Left);
        /// <summary>
        /// 内容字体设置
        /// </summary>
        public string content_font
        {
            get => ContentFont.content;
            set => ContentFont.content = value;
        }
        [JsonIgnore]
        public UIPadding ContentPadding = UIPadding.instanceByPx(5);
        /// <summary>
        /// 内容字体边距
        /// </summary>
        public string content_padding
        {
            get => ContentPadding.content_mm;
            set => ContentPadding.content_mm = value;
        }
        [JsonIgnore]
        public Color ContentBGColor = Color.White;
        /// <summary>
        /// 内容背景色
        /// </summary>
        public string content_bg_color
        {
            get => ContentBGColor.hexString();
            set => ContentBGColor = value.color();
        }


        /// <summary>
        /// 异常项目字体是否粗体
        /// </summary>
        public bool abnormal_bold = false;
        public Color AbnormalColor = Color.Red;

        /// <summary>
        /// 异常项目字体颜色
        /// </summary>
        public string abnormal_color
        {
            get => AbnormalColor.hexString();
            set => AbnormalColor = value.color();
        }
    }
}