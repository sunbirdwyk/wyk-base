namespace wyk.ui.consts
{
    /// <summary>
    /// Windows 窗口样式
    /// </summary>
    public class WindowStyle
    {
        /// <summary>
        /// 创建一个重叠窗口。重叠窗口通常具有标题条和边界。
        /// </summary>
        public const uint WS_OVERLAPPED = 0x00000000;
        /// <summary>
        /// 创建一个弹出式窗口，不能与WS_CHILD风格一起使用。
        /// </summary>
        public const uint WS_POPUP = 0x80000000;
        /// <summary>
        /// 窗口为子窗口，不能应用于弹出式窗口风格(WS_POPUP)。
        /// </summary>
        public const uint WS_CHILD = 0x40000000;
        /// <summary>
        /// 创建一个初始状态为最小化的窗口。仅与WS_OVERLAPPED风格一起使用。
        /// </summary>
        public const uint WS_MINIMIZE = 0x20000000;
        /// <summary>
        /// 创建一个最初可见的窗口。
        /// </summary>
        public const uint WS_VISIBLE = 0x10000000;
        /// <summary>
        /// 创建一个初始状态为禁止的窗口。
        /// </summary>
        public const uint WS_DISABLED = 0x08000000;
        /// <summary>
        /// 剪裁相关的子窗口，这意味着，当一个特定的子窗口接收到重绘消息时，WS_CLIPSIBLINGS
        /// 风格将在子窗口要重画的区域中去掉与其它子窗口重叠的部分。
        /// （如果没有指定WS_CLIPSIBLINGS风格，并且子窗口有重叠，当你在一个子窗口的客户区绘
        /// 图时，它可能会画在相邻的子窗口的客户区中。）只与WS_CHILD风格一起使用。
        /// </summary>
        public const uint WS_CLIPSIBLINGS = 0x04000000;
        /// <summary>
        /// 绘制父窗口时，不绘制子窗口的裁剪区域。使用在建立父窗口时。
        /// </summary>
        public const uint WS_CLIPCHILDREN = 0x02000000;
        /// <summary>
        /// 创建一个最大化的窗口。
        /// </summary>
        public const uint WS_MAXIMIZE = 0x01000000;
        /// <summary>
        /// 窗口包含标题部分, 必须和WS_BORDER风格配合，但不能与WS_DLGFRAME风格一起使用。
        /// </summary>
        public const uint WS_CAPTION = 0x00C00000;
        /// <summary>
        /// 有边框窗口
        /// </summary>
        public const uint WS_BORDER = 0x00800000;
        /// <summary>
        /// 创建一个窗口，具有双重边界，但是没有标题条。
        /// </summary>
        public const uint WS_DLGFRAME = 0x00400000;
        /// <summary>
        /// 创建一个具有垂直滚动条的窗口。
        /// </summary>
        public const uint WS_VSCROLL = 0x00200000;
        /// <summary>
        /// 创建一个具有水平滚动条的窗口。
        /// </summary>
        public const uint WS_HSCROLL = 0x00100000;
        /// <summary>
        /// 创建一个在标题条上具有控制菜单的窗口。仅对带标题条的窗口使用。
        /// (WS_SYSTMENU决定了窗口是否有系统菜单，当然在有标题栏的窗口中，这个标志还决定了
        /// 窗口左上角的小图标是否存在，以及右上角的按钮是否存在（关闭按钮）)
        /// </summary>
        public const uint WS_SYSMENU = 0x00080000;
        /// <summary>
        /// 创建一个具有厚边框的窗口，可以通过厚边框来改变窗口大小。
        /// (WS_THICKFRAME决定了窗口边缘是否可以拖拽)
        /// </summary>
        public const uint WS_THICKFRAME = 0x00040000;
        /// <summary>
        /// 指定一组控件中的第一个，用户可以用箭头键在这组控件中移动。在第一个控件后面把
        /// WS_GROUP风格设置为FALSE的控件都属于这一组。下一个具有WS_GROUP风格的控
        /// 件将开始下一组（这意味着一个组在下一组的开始处结束）。
        /// </summary>
        public const uint WS_GROUP = 0x00020000;
        /// <summary>
        /// 指定了一些控件中的一个，用户可以通过TAB键来移过它。TAB键使用户移动到下一个用WS_TABSTOP风格定义的控件。
        /// </summary>
        public const uint WS_TABSTOP = 0x00010000;
        /***************************
         * WS_MINIMIZEBOX和WS_MAXIMIZEBOX则决定了系统菜单中的最小化，最大化是否可用，
         * 以及窗口右上角是否有最大化和最小化按钮，当然这两个标志必须在WS_SYSMENU存在的情
         * 况下才有效，否则是没有系统菜单，而且右上角是不会出现任何按钮的。
         ***************************/
        /// <summary>
        /// 创建一个具有最小化按钮的窗口。
        /// </summary>
        public const uint WS_MINIMIZEBOX = 0x00020000;
        /// <summary>
        /// 创建一个具有最大化按钮的窗口。
        /// </summary>
        public const uint WS_MAXIMIZEBOX = 0x00010000;
        /// <summary>
        /// 产生一个层叠的窗口。一个层叠的窗口有一个标题和一个边框。与WS_OVERLAPPED风格相同。
        /// </summary>
        public const uint WS_TILED = WS_OVERLAPPED;
        /// <summary>
        /// 创建一个初始状态为最小化状态的窗口。与WS_MINIMIZE风格相同。
        /// </summary>
        public const uint WS_ICONIC = WS_MINIMIZE;
        /// <summary>
        /// 创建一个可调边框的窗口，与WS_THICKFRAME风格相同。
        /// </summary>
        public const uint WS_SIZEBOX = WS_THICKFRAME;
        /// <summary>
        /// 创建一个具有WS_OVERLAPPED,WS_CAPTION,WS_SYSMENU,MS_THICKFRAME风格的窗口。
        /// </summary>
        public const uint WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;
        /// <summary>
        /// 创建一个具有WS_OVERLAPPED,WS_CAPTION,WS_SYSMENU,WS_THICKFRAME,WS_MINIMIZEBOX和WS_MAXIMIZEBOX风格的重叠式窗口。
        /// </summary>
        public const uint WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU |
                                 WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
        /// <summary>
        /// 创建一个具有WS_BORDER，WS_POPUP和WS_SYSMENU风格的弹出窗口。为了使控制菜单可见，必须与WS_POPUPWINDOW一起使用WS_CAPTION风格。
        /// </summary>
        public const uint WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU);
        /// <summary>
        /// 窗口为子窗口，同WS_CHILD
        /// </summary>
        public const uint WS_CHILDWINDOW = (WS_CHILD);
    }
}
