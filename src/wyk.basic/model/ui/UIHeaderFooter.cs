using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;

namespace wyk.basic
{
    public class UIHeaderFooter
    {
        /// <summary>
        /// 是否显示分隔线, 分隔线显示在margintop(bottom)的位置
        /// </summary>
        public bool show_seperator = false;
        /// <summary>
        /// 分隔线宽度(mm)
        /// </summary>
        public float seperator_width = 0.1f;
        /// <summary>
        /// 分隔线颜色
        /// </summary>
        public string seperator_color
        {
            get => SeperatorColor.hexString();
            set => SeperatorColor = value.color();
        }
        [JsonIgnore]
        public Color SeperatorColor = Color.FromArgb(128, 128, 128); //#808080

        /// <summary>
        /// 内容
        /// </summary>
        [JsonIgnore]
        public List<string> content_list = new List<string>();
        public string content_lines
        {
            get => JsonConvert.SerializeObject(content_list);
            set
            {
                try
                {
                    content_list = JsonConvert.DeserializeObject<List<string>>(value);
                }
                catch { content_list = null; }
                if (content_list == null)
                    content_list = new List<string>();
            }
        }
        /// <summary>
        /// 内容字体(包含字体样式, 颜色, 对齐方式)
        /// </summary>
        [JsonIgnore]
        public List<UIFont> content_font_list = new List<UIFont>();
        public string content_fonts
        {
            get
            {
                var list = new List<string>();
                foreach (UIFont f in content_font_list)
                {
                    list.Add(f.content);
                }
                return JsonConvert.SerializeObject(list);
            }
            set
            {
                try
                {
                    var list = JsonConvert.DeserializeObject<List<string>>(value);
                    content_font_list = new List<UIFont>();
                    foreach (string item in list)
                    {
                        UIFont font = new UIFont();
                        font.content = item;
                        content_font_list.Add(font);
                    }
                }
                catch { content_font_list = new List<UIFont>(); }
            }
        }
        /// <summary>
        /// 每行间隔(mm)
        /// </summary>
        public float line_space = 0.8f;
        /// <summary>
        /// 跳过显示的页数
        /// </summary>
        public int skip_page_count = 0;
        /// <summary>
        /// 文字起始距离(页眉为最后一行文字与分隔线的距离, 页脚为第一行与分隔线的距离)
        /// </summary>
        public float post_space = 1.2f;
        /// <summary>
        /// 分隔线起始距离(页眉为内容上边距与分隔线的距离, 页脚为内容下边距与分隔线的距离)
        /// </summary>
        public float pre_space = 3f;

        /// <summary>
        /// 页眉/页脚是否在附加页显示
        /// </summary>
        public bool show_on_extra_page = false;

        /// <summary>
        /// 根据行号设置行内容
        /// </summary>
        /// <param name="line_number">行号, 起始1, 不能超过10</param>
        /// <param name="content">行内容</param>
        /// <param name="font">字体</param>
        /// <param name="color">文字颜色</param>
        /// <param name="alignment">对齐方式</param>
        public void setContent(int line_number, string content, Font font, Color color, AlignHorizontal alignment)
        {
            if (line_number > 10)
                return;
            while (content_list.Count < line_number)
                content_list.Add("");
            while (content_font_list.Count < line_number)
                content_font_list.Add(new UIFont("微软雅黑", 9, FontStyle.Regular,Color.Black, AlignHorizontal.Left));
            UIFont uifont = new UIFont(font, color, alignment);
            content_list[line_number - 1] = content;
            content_font_list[line_number - 1] = uifont;
        }

        /// <summary>
        /// 根据行号设置行内容
        /// </summary>
        /// <param name="line_number">行号, 起始1, 不能超过10</param>
        /// <param name="content">行内容</param>
        /// <param name="font">字体配置</param>
        public void setContent(int line_number, string content, UIFont font)
        {
            if (line_number > 10)
                return;
            while (content_list.Count < line_number)
                content_list.Add("");
            while (content_font_list.Count < line_number)
                content_font_list.Add(new UIFont("微软雅黑", 9, FontStyle.Regular, Color.Black, AlignHorizontal.Left));
            content_list[line_number - 1] = content;
            content_font_list[line_number - 1] = font;
        }

        /// <summary>
        /// 根据行号设置行内容, 默认LightGray, (微软雅黑,8,Normal)
        /// </summary>
        /// <param name="line_number">行号, 起始1, 不能超过10</param>
        /// <param name="content">行内容</param>
        /// <param name="alignment">对齐方式</param>
        public void setContent(int line_number, string content, AlignHorizontal alignment)
        {
            setContent(line_number, content, new Font("微软雅黑", 9, FontStyle.Regular), Color.Gray, alignment);
        }

        /// <summary>
        /// 添加一行内容, 最大行数不能超过10
        /// </summary>
        /// <param name="content">行内容</param>
        /// <param name="font">字体</param>
        /// <param name="color">文字颜色</param>
        /// <param name="alignment">对齐方式</param>
        public void addContent(string content, Font font, Color color, AlignHorizontal alignment)
        {
            setContent(content_list.Count + 1, content, font, color, alignment);
        }

        /// <summary>
        /// 添加一行内容, 最大行数不能超过10, 默认LightGray, (微软雅黑,8,Normal)
        /// </summary>
        /// <param name="content"></param>
        /// <param name="alignment"></param>
        public void addContent(string content, AlignHorizontal alignment)
        {
            setContent(content_list.Count + 1, content, alignment);
        }

        /// <summary>
        /// 设置分隔线相关内容
        /// </summary>
        /// <param name="show_seperator">是否显示分隔线</param>
        /// <param name="seperator_width">分隔线宽度</param>
        /// <param name="seperator_color">分隔线颜色</param>
        public void setSeperator(bool show_seperator, float seperator_width, Color seperator_color)
        {
            this.show_seperator = show_seperator;
            this.seperator_width = seperator_width;
            this.SeperatorColor = seperator_color;
        }

        /// <summary>
        /// 使用替换字段将header/footer中可替换的字段处理掉
        /// </summary>
        /// <param name="replace_info"></param>
        public void processContentForReplaceInfo(ReplaceInfoList replace_info)
        {
            for(int i = 0; i < content_list.Count; i++)
            {
                content_list[i] = replace_info.process(content_list[i]);
            }
        }
    }
}
