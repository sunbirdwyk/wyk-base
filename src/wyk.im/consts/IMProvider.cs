using System.ComponentModel;

namespace wyk.im
{
    /// <summary>
    /// IM服务提供商
    /// </summary>
    public enum IMProvider
    {
        [Description("未知")]
        Unknown,
        /// <summary>
        /// 融云 https://www.rongcloud.cn
        /// </summary>
        [Description("融云")]
        RongCloud,
    }
}
