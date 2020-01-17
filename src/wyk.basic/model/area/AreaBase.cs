using Newtonsoft.Json;

namespace wyk.basic
{
    /// <summary>
    /// 区域基类, 包含id, name, shortcut
    /// </summary>
    public class AreaBase
    {
        [JsonIgnore]
        protected string _shortcut = "";
        [JsonIgnore]
        protected string _name = "";

        /// <summary>
        /// ID
        /// </summary>
        public int id = 0;

        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
            get => _name;
            set
            {
                _name = value;
                _shortcut = CharacterUtil.getPinyinShort(_name);
            }
        }

        /// <summary>
        /// 名称拼音简写
        /// </summary>
        [JsonIgnore]
        public string shortcut
        {
            get
            {
                if (_shortcut == "")
                {
                    _shortcut = CharacterUtil.getPinyinShort(_name);
                }
                return _shortcut;
            }
            set => _shortcut = value;
        }
    }
}