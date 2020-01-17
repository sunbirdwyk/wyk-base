using Newtonsoft.Json;
using System.Drawing;

namespace wyk.basic
{
    /// <summary>
    /// 页码样式
    /// </summary>
    public class UIPageNumber
    {
        /// <summary>
        /// 是否显示页码
        /// </summary>
        public bool show_page_number = false;
        /// <summary>
        /// 页码起始点离页脚起始线的距离(mm)
        /// 将此值和UIHeaderFooter.post_space设置为一样时, 如果和页脚字体大小相同则可与页脚第一行对齐
        /// </summary>
        public float start_space = 1.2f;
        /// <summary>
        /// 页码内容, 页码替换符为 {P}, 如 "第{P}页"
        /// </summary>
        public string format = "{P}";
        /// <summary>
        /// 页码字体
        /// </summary>
        [JsonIgnore]
        public UIFont Font = new UIFont("微软雅黑", 9, FontStyle.Regular, Color.Gray, AlignHorizontal.Center);
        public string font
        {
            get => Font.content;
            set => Font.content = value;
        }
        /// <summary>
        /// 跳过显示的页数
        /// </summary>
        public int skip_page_count = 0;

        /// <summary>
        /// 页码是否在附加页显示
        /// </summary>
        public bool show_on_extra_page = false;

        /// <summary>
        /// 使用替换字段将header/footer中可替换的字段处理掉
        /// </summary>
        /// <param name="replace_info"></param>
        public void processContentForReplaceInfo(ReplaceInfoList replace_info)
        {
            format = replace_info.process(format);
        }
    }
}
