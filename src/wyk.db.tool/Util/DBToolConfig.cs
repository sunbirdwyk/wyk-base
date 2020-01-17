using Newtonsoft.Json;
using wyk.basic;
using wyk.db.tool.Model;

namespace wyk.db.tool.Util
{
    public class DBToolConfig : AppConfigBase
    {
        /// <summary>
        /// 当前的数据库维护项目组
        /// </summary>
        [AppConfigProperty]
        public string current_project = "";

        /// <summary>
        /// 数据库维护项目组
        /// </summary>
        [AppConfigProperty]
        public string maintain_group
        {
            get => JsonConvert.SerializeObject(MaintainGroup);
            set
            {
                var group = JsonConvert.DeserializeObject<MaintainGroup>(value);
                if (group == null)
                    group = new MaintainGroup();
                MaintainGroup = group;
            }
        }

        public MaintainGroup MaintainGroup = new MaintainGroup();
    }
}
