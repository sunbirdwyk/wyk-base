namespace wyk.ui.consts
{
    /// <summary>
    /// Windows 窗口样式(扩展)
    /// </summary>
    public class WindowStyleEx
    {
        /// <summary>
        /// 指明一个具有双重边界的窗口，当你在dwStyle参数中指定了WS_CAPTION风格
        /// 标志时，它可以具有标题条（可选）。
        /// </summary>
        public const uint WS_EX_DLGMODALFRAME = 0x00000001;
        /// <summary>
        /// 指定用这个风格创建的子窗口在被创建或销毁的时候将不向父窗口发送WM_PARENTNOTIFY消息。
        /// </summary>
        public const uint WS_EX_NOPARENTNOTIFY = 0x00000004;
        /// <summary>
        /// 指定用这个风格创建的窗口必须被放在所有非顶层窗口的上面，即使这个窗口
        /// 已经不处于激活状态，它还是保留在最上面。应用程序可以用SetWindowsPos
        /// 成员函数来加入或去掉这个属性。
        /// </summary>
        public const uint WS_EX_TOPMOST = 0x00000008;
        /// <summary>
        /// 指明用这个风格创建的窗口能够接受拖放文件。
        /// </summary>
        public const uint WS_EX_ACCEPTFILES = 0x00000010;
        /// <summary>
        /// 指定了用这个风格创建的窗口是透明的。这意味着，在这个窗口下面的任何窗口
        /// 都不会被这个窗口挡住。用这个风格创建的窗口只有当它下面的窗口都更新过以
        /// 后才接收WM_PAINT消息。
        /// </summary>
        public const uint WS_EX_TRANSPARENT = 0x00000020;
        /// <summary>
        /// 创建一个MDI子窗口。
        /// </summary>
        public const uint WS_EX_MDICHILD = 0x00000040;
        /// <summary>
        /// 创建一个工具窗口，目的是被用作浮动工具条。工具窗口具有标题条，比通常的
        /// 标题条要短，窗口的标题是用小字体显示的。工具窗口不出现在任务条或用户按
        /// 下ALT+TAB时出现的窗口中。
        /// </summary>
        public const uint WS_EX_TOOLWINDOW = 0x00000080;
        /// <summary>
        /// 指定了具有凸起边框的窗口
        /// </summary>
        public const uint WS_EX_WINDOWEDGE = 0x00000100;
        /// <summary>
        /// 指明窗口具有3D外观，这意味着，边框具有下沉的边界。
        /// </summary>
        public const uint WS_EX_CLIENTEDGE = 0x00000200;
        /// <summary>
        /// 在窗口的标题条中包含问号。当用户单击问号时，鼠标光标的形状变为带指针的
        /// 问号。如果用户随后单击一个子窗口，子窗口将接收到一个WM_HELP消息。
        /// </summary>
        public const uint WS_EX_CONTEXTHELP = 0x00000400;
        /// <summary>
        /// 赋予窗口右对齐属性。这与窗口类有关。
        /// </summary>
        public const uint WS_EX_RIGHT = 0x00001000;
        /// <summary>
        /// 指定窗口具有左对齐属性。这是缺省值。
        /// </summary>
        public const uint WS_EX_LEFT = 0x00000000;
        /// <summary>
        /// 按照从右到左的顺序显示窗口文本。
        /// </summary>
        public const uint WS_EX_RTLREADING = 0x00002000;
        /// <summary>
        /// 按照从左到右的方式显示窗口文本。这是缺省方式。
        /// </summary>
        public const uint WS_EX_LTRREADING = 0x00000000;
        /// <summary>
        /// 将垂直滚动条放在客户区的左边。
        /// </summary>
        public const uint WS_EX_LEFTSCROLLBAR = 0x00004000;
        /// <summary>
        /// 将垂直滚动条（如果有）放在客户区的右边。这是缺省方式。
        /// </summary>
        public const uint WS_EX_RIGHTSCROLLBAR = 0x00000000;
        /// <summary>
        /// 允许用户用TAB键遍历窗口的子窗口。
        /// </summary>
        public const uint WS_EX_CONTROLPARENT = 0x00010000;
        /// <summary>
        /// 创建一个具有三维边界的窗口，用于不接受用户输入的项。
        /// </summary>
        public const uint WS_EX_STATICEDGE = 0x00020000;
        /// <summary>
        /// 当窗口可见时将一个顶层窗口放置在任务栏上。
        /// </summary>
        public const uint WS_EX_APPWINDOW = 0x00040000;
        /// <summary>
        /// 组合了WS_EX_CLIENTEDGE和WS_EX_WIND-OWEDGE风格。
        /// </summary>
        public const uint WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
        /// <summary>
        /// 组合了WS_EX_WINDOWEDGE和WS_EX_TOPMOST风格。
        /// </summary>
        public const uint WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
        /// <summary>
        /// 使窗体支持透明
        /// </summary>
        public const uint WS_EX_LAYERED = 0x00080000;
        /// <summary>
        /// Windows 2000/XP:用此参数创建的窗体不会传递他的窗口布局给他的子窗口
        /// </summary>
        public const uint WS_EX_NOINHERITLAYOUT = 0x00100000;
        /// <summary>
        /// 阿拉伯以及西伯来版本的98/ME,2000/XP创建一个水平起点在右边的窗口. 越往左边水平坐标值变大.
        /// </summary>
        public const uint WS_EX_LAYOUTRTL = 0x00400000;
        /// <summary>
        /// Windows XP:将一个窗体的所有子窗口使用双缓冲按照从低到高方式绘制出 来,
        /// 参阅remark项.如果这个视窗已经使用经典样式中的下列值CS_OWNDC ,
        /// CS_CLASSDC,WS_EX_CONTEXTHELP.此参数将不能使用.   
        ///     这个样式的视窗在 标题栏上有一个问号,当拥护点击着个问号,鼠标变成一个问
        /// 号,如果用户然后点击一个子窗口,子窗就会收到一条WM_HELP消息.子窗口将把这
        /// 个消息传递给他的父进程,这个父进程将用HELP_WM_HELP命令调用WinHelp函数.
        /// 这个帮助程序常常弹出一个典型的包含其子窗口的帮助的窗口本参数不能和
        /// WS_MAXIMIZEBOX ,WS_MINIMIZEBOX一起使用.
        /// </summary>
        public const uint WS_EX_COMPOSITED = 0x02000000;
        /// <summary>
        /// Windows 2000/XP:一个使用此参数创建的顶级窗口不会变成前台窗口,当用 户点击
        /// 他时.系统不会将此窗口放到前台,当用户最小化或者关闭这个前台窗口. 要激活这样的
        /// 窗口,使用SetActiveWindow或者SetForegroundWindow函数此类型的窗口默认不
        /// 会显示在任务栏上.要强行将这样的窗口显示到任务栏上,使用WS_EX_APPWINDOW参数.
        /// </summary>
        public const uint WS_EX_NOACTIVATE = 0x08000000;
    }
}
