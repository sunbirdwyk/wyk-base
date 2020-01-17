using System.ComponentModel;
using wyk.basic;

namespace wyk.ui
{
    /// <summary>
    /// 按钮的功能类型
    /// </summary>
    public enum ButtonFuctionType
    {
        //常规按钮, 不锁定颜色
        [Description("常规")]
        Normal,
        //主要按钮, 锁定为当前父窗体的主色(标题栏背景色)
        [Description("主要")]
        Primary,
        //主要按钮, 锁定为当前父窗体的次要颜色(状态栏背景色)
        [Description("次要")]
        Secondary,
        //取消按钮, 锁定为相应的功能颜色
        [Description("取消")]
        [ReferedColor(100, 130, 130)]
        Cancel,
        //警告按钮, 锁定为相应的功能颜色
        [Description("警告")]
        [ReferedColor(240, 150, 10)]
        Warning,
        //成功按钮, 锁定为相应的功能颜色
        [Description("成功")]
        [ReferedColor(40, 210, 160)]
        Success,
        //信息按钮, 锁定为相应的功能颜色
        [Description("信息")]
        [ReferedColor(10, 180, 240)]
        Infomation,
        //错误按钮, 锁定为相应的功能颜色
        [Description("错误")]
        [ReferedColor(240, 80, 80)]
        Error,
    }
}
