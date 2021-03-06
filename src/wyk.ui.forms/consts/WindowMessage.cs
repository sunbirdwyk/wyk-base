﻿namespace wyk.ui.consts
{
    /// <summary>
    /// 窗口消息
    /// </summary>
    public class WindowMessage
    {
        /// <summary>
        /// 空消息,可检测程序是否有响应等
        /// </summary>
        public const int WM_NULL = 0x0000;
        /// <summary>
        /// 新建一个窗口
        /// </summary>
        public const int WM_CREATE = 0x0001;
        /// <summary>
        /// 销毁一个窗口
        /// </summary>
        public const int WM_DESTROY = 0x0002;
        /// <summary>
        /// 移动一个窗口
        /// </summary>
        public const int WM_MOVE = 0x0003;
        /// <summary>
        /// 改变一个窗口的大小
        /// </summary>
        public const int WM_SIZE = 0x0005;
        /// <summary>
        /// 一个窗口被激活或失去激活状态
        /// </summary>
        public const int WM_ACTIVATE = 0x0006;
        /// <summary>
        /// 将焦点转向一个窗口
        /// </summary>
        public const int WM_SETFOCUS = 0x0007;
        /// <summary>
        /// 使一个窗口失去焦点
        /// </summary>
        public const int WM_KILLFOCUS = 0x0008;
        /// <summary>
        /// 使一个窗口处于可用状态
        /// </summary>
        public const int WM_ENABLE = 0x000A;
        /// <summary>
        /// 设置窗口是否能重绘
        /// </summary>
        public const int WM_SETREDRAW = 0x000B;
        /// <summary>
        /// 设置一个窗口的文本
        /// </summary>
        public const int WM_SETTEXT = 0x000C;
        /// <summary>
        /// 复制窗口的文本到缓冲区
        /// </summary>
        public const int WM_GETTEXT = 0x000D;
        /// <summary>
        /// 得到窗口的文本长度(不含结束符)
        /// </summary>
        public const int WM_GETTEXTLENGTH = 0x000E;
        /// <summary>
        /// 窗口重绘
        /// </summary>
        public const int WM_PAINT = 0x000F;
        /// <summary>
        /// 用户关闭窗口时会发送本消息,紧接着会发送WM_DESTROY消息
        /// </summary>
        public const int WM_CLOSE = 0x0010;
        /// <summary>
        /// 关机或注销时系统会按优先级给各进程发送WM_QUERYENDSESSION,告诉应用程序要关机或注销了
        /// </summary>
        public const int WM_QUERYENDSESSION = 0x0011;
        /// <summary>
        /// 关闭消息循环结束程序的运行
        /// </summary>
        public const int WM_QUIT = 0x0012;
        /// <summary>
        /// 最小化的窗口即将被恢复以前的大小位置
        /// </summary>
        public const int WM_QUERYOPEN = 0x0013;
        /// <summary>
        /// 当一个窗口的背景必须被擦除时本消息会被触发(如:窗口大小改变时)
        /// </summary>
        public const int WM_ERASEBKGND = 0x0014;
        /// <summary>
        /// 当系统颜色改变时,发送本消息给所有顶级窗口
        /// </summary>
        public const int WM_SYSCOLORCHANGE = 0x0015;
        /// <summary>
        /// 关机或注销时系统会发出WM_QUERYENDSESSION消息,然后将本消息发送给应用程序,通知程序会话结束
        /// </summary>
        public const int WM_ENDSESSION = 0x0016;
        /// <summary>
        /// 发送本消息给一个窗口,以便隐藏或显示该窗口
        /// </summary>
        public const int WM_SHOWWINDOW = 0x0018;
        /// <summary>
        /// 读写 win.ini 时会发送本消息给所有顶层窗口,通知其它进程该文件已被更改
        /// </summary>
        public const int WM_WININICHANGE = 0x001A;
        /// <summary>
        /// 改变设备模式设置 win.ini 时,处理本消息的应用程序可重新初始化它们的设备模式设置
        /// </summary>
        public const int WM_DEVMODECHANGE = 0x001B;
        /// <summary>
        /// 窗口进程激活状态改动,正被激活的窗口属于不同的应用程序
        /// </summary>
        public const int WM_ACTIVATEAPP = 0x001C;
        /// <summary>
        /// 当系统的字体资源库变化时发送本消息给所有顶级窗口
        /// </summary>
        public const int WM_FONTCHANGE = 0x001D;
        /// <summary>
        /// 当系统的时间变化时发送本消息给所有顶级窗口
        /// </summary>
        public const int WM_TIMECHANGE = 0x001E;
        /// <summary>
        /// 发送本消息来取消某种正在进行的模态(操作)(如鼠示捕获),例如:启动一个模态窗口时,父窗会收到本消息;该消息无参数
        /// </summary>
        public const int WM_CANCELMODE = 0x001F;
        /// <summary>
        /// 若鼠标光标在某窗口内移动且鼠标没被捕获时,就会发送本消息给某个窗口
        /// </summary>
        public const int WM_SETCURSOR = 0x0020;
        /// <summary>
        /// 当鼠标光标在某个未激活窗口内,而用户正按着鼠标的某个键时,会发送本消息给当前窗口
        /// </summary>
        public const int WM_MOUSEACTIVATE = 0x0021;
        /// <summary>
        /// 点击窗口标题栏或当窗口被激活、移动、大小改变时,会发送本消息给MDI子窗口
        /// </summary>
        public const int WM_CHILDACTIVATE = 0x0022;
        /// <summary>
        /// 本消息由基于计算机的训练程序发送,通过WH_JOURNALPALYBACK的HOOK程序分离出用户输入消息
        /// </summary>
        public const int WM_QUEUESYNC = 0x0023;
        /// <summary>
        /// 当窗口将要改变大小或位置时,由系统发送本消息给窗口,用户拖动一个可重置大小的窗口时便会发出本消息
        /// </summary>
        public const int WM_GETMINMAXINFO = 0x0024;
        /// <summary>
        /// 当一个最小化的窗口图标将被重绘时发送本消息
        /// </summary>
        public const int WM_PAINTICON = 0x0026;
        /// <summary>
        /// 本消息发送给某个最小化的窗口,仅当它在画图标前它的背景必须被重画
        /// </summary>
        public const int WM_ICONERASEBKGND = 0x0027;
        /// <summary>
        /// 发送本消息给一个对话框程序窗口过程,以便在各控件间设置键盘焦点位置
        /// </summary>
        public const int WM_NEXTDLGCTL = 0x0028;
        /// <summary>
        /// 每当打印管理列队增加或减少一条作业时就会发出本消息
        /// </summary>
        public const int WM_SPOOLERSTATUS = 0x002A;
        /// <summary>
        /// 按钮、组合框、列表框、菜单的外观改变时会发送本消息给这些控件的所有者
        /// </summary>
        public const int WM_DRAWITEM = 0x002B;
        /// <summary>
        /// 按钮、组合框、列表框、列表控件、菜单项被创建时会发送本消息给这些控件的所有者
        /// </summary>
        public const int WM_MEASUREITEM = 0x002C;
        /// <summary>
        /// 当列表框或组合框被销毁或通过LB_DELETESTRING、LB_RESETCONTENT、CB_DELETESTRING或CB_RESETCONTENT消息删除某些项时,会发送本消息给这些控件的所有者
        /// </summary>
        public const int WM_DELETEITEM = 0x002D;
        /// <summary>
        /// LBS_WANTKEYBOARDINPUT风格的列表框会发出本消息给其所有者,以便响应WM_KEYDOWN消息
        /// </summary>
        public const int WM_VKEYTOITEM = 0x002E;
        /// <summary>
        /// LBS_WANTKEYBOARDINPUT风格的列表框会发送本消息给其所有者,以便响应WM_CHAR消息
        /// </summary>
        public const int WM_CHARTOITEM = 0x002F;
        /// <summary>
        /// 指定控件所用字体
        /// </summary>
        public const int WM_SETFONT = 0x0030;
        /// <summary>
        /// 得到当前控件绘制其文本所用的字体
        /// </summary>
        public const int WM_GETFONT = 0x0031;
        /// <summary>
        /// 为某窗口关联一个热键
        /// </summary>
        public const int WM_SETHOTKEY = 0x0032;
        /// <summary>
        /// 确定某热键与某窗口是否相关联
        /// </summary>
        public const int WM_GETHOTKEY = 0x0033;
        /// <summary>
        /// 本消息发送给最小化的窗口(iconic),当该窗口将被拖放而其窗口类中没有定义图标,应用程序能返回一个图标或光标的句柄。当用户拖放图标时系统会显示这个图标或光标
        /// </summary>
        public const int WM_QUERYDRAGICON = 0x0037;
        /// <summary>
        /// 可发送本消息来确定组合框(CBS_SORT)或列表框(LBS_SORT)中新增项的相对位置
        /// </summary>
        public const int WM_COMPAREITEM = 0x0039;
        /// <summary>
        /// oleacc.dll(COM组件)(Microsoft Active Accessibility:方便残疾人使用电脑的一种技术)发送本消息激活服务程序以便获取它所包含的关联对象的信息
        /// </summary>
        public const int WM_GETOBJECT = 0x003D;
        /// <summary>
        /// 显示内存已经很少了
        /// </summary>
        public const int WM_COMPACTING = 0x0041;
        /// <summary>
        /// Win3.1中,当串口事件产生时,通讯设备驱动程序发送消息本消息给系统,指示输入输出队列的状态
        /// </summary>
        public const int WM_COMMNOTIFY = 0x0044;
        /// <summary>
        /// 本消息会发送给那些大小和位置(Z_Order)将被改变的窗口,以调用SetWindowPos函数或其它窗口管理函数
        /// </summary>
        public const int WM_WINDOWPOSCHANGING = 0x0046;
        /// <summary>
        /// 本消息会发送给那些大小和位置(Z_Order)已被改变的窗口,以调用SetWindowPos函数或其它窗口管理函数
        /// </summary>
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        /// <summary>
        /// 当系统将要进入暂停状态时发送本消息(适用于16位的windows)
        /// </summary>
        public const int WM_POWER = 0x0048;
        /// <summary>
        /// 当一个应用程序传递数据给另一个应用程序时发送本消息
        /// </summary>
        public const int WM_COPYDATA = 0x004A;
        /// <summary>
        /// 当用户取消程序日志激活状态时,发送本消息给那个应用程序。该消息使用空窗口句柄发送
        /// </summary>
        public const int WM_CANCELJOURNAL = 0x004B;
        /// <summary>
        /// 当某控件的某事件已发生或该控件需得到一些信息时,发送本消息给其父窗
        /// </summary>
        public const int WM_NOTIFY = 0x004E;
        /// <summary>
        /// 当用户通过过单击任务栏上的语言指示符或某快捷键组合选择改变输入法时系统会向焦点窗口发送本消息
        /// </summary>
        public const int WM_INPUTLANGCHANGEREQUEST = 0x0050;
        /// <summary>
        /// 切换输入法后,系统会发送本消息给受影响的顶层窗口
        /// </summary>
        public const int WM_INPUTLANGCHANGE = 0x0051;
        /// <summary>
        /// 程序已初始化windows帮助例程时会发送本消息给应用程序
        /// </summary>
        public const int WM_TCARD = 0x0052;
        /// <summary>
        /// 按下<F1>后,若某菜单是激活的,就发送本消息给此窗口关联的菜单;否则就发送给有焦点的窗口;若当前都没有焦点,就把本消息发送给当前激活的窗口
        /// </summary>
        public const int WM_HELP = 0x0053;
        /// <summary>
        /// 当用户已登入或退出后发送本消息给所有窗口;当用户登入或退出时系统更新用户的具体设置信息,在用户更新设置时系统马上发送本消息
        /// </summary>
        public const int WM_USERCHANGED = 0x0054;
        /// <summary>
        /// 公用控件、自定义控件和其父窗通过本消息判断控件在WM_NOTIFY通知消息中是使用ANSI还是UNICODE,使用本消息能使某个控件与它的父控件间进行相互通信
        /// </summary>
        public const int WM_NOTIFYFORMAT = 0x0055;
        /// <summary>
        /// 当用户在某窗口中点击右键就发送本消息给该窗口,设置右键菜单
        /// </summary>
        public const int WM_CONTEXTMENU = 0x007B;
        /// <summary>
        /// 当调用SetWindowLong函数将要改变一个或多个窗口的风格时,发送本消息给那个窗口
        /// </summary>
        public const int WM_STYLECHANGING = 0x007C;
        /// <summary>
        /// 当调用SetWindowLong函数改变一个或多个窗口的风格后,发送本消息给那个窗口
        /// </summary>
        public const int WM_STYLECHANGED = 0x007D;
        /// <summary>
        /// 当显示器的分辨率改变后,发送本消息给所有窗口
        /// </summary>
        public const int WM_DISPLAYCHANGE = 0x007E;
        /// <summary>
        /// 本消息发送给某个窗口,用于返回与某窗口有关联的大图标或小图标的句柄
        /// </summary>
        public const int WM_GETICON = 0x007F;
        /// <summary>
        /// 应用程序发送本消息让一个新的大图标或小图标与某窗口相关联
        /// </summary>
        public const int WM_SETICON = 0x0080;
        /// <summary>
        /// 当某窗口首次被创建时,本消息在WM_CREATE消息发送前发送
        /// </summary>
        public const int WM_NCCREATE = 0x0081;
        /// <summary>
        /// 本消息通知某窗口,非客户区正在销毁
        /// </summary>
        public const int WM_NCDESTROY = 0x0082;
        /// <summary>
        /// 当某窗口的客户区的大小和位置须被计算时发送本消息
        /// </summary>
        public const int WM_NCCALCSIZE = 0x0083;
        /// <summary>
        /// 当用户在在非客户区移动鼠标、按住或释放鼠标时发送本消息(击中测试);若鼠标没有被捕获,则本消息在窗口得到光标之后发出,否则消息发送到捕获到鼠标的窗口
        /// </summary>
        public const int WM_NCHITTEST = 0x0084;
        /// <summary>
        /// 当窗口框架(非客户区)必须被被重绘时,应用程序发送本消息给该窗口
        /// </summary>
        public const int WM_NCPAINT = 0x0085;
        /// <summary>
        /// 本消息发送给某窗口,在窗口的非客户区被激活时重绘窗口
        /// </summary>
        public const int WM_NCACTIVATE = 0x0086;
        /// <summary>
        /// 发送本消息给某个与对话框程序关联的控件,系统控制方位键和TAB键使输入进入该控件,通过响应本消息应用程序可把它当成一个特殊的输入控件并能处理它
        /// </summary>
        public const int WM_GETDLGCODE = 0x0087;
        /// <summary>
        /// 当避免联系独立的GUI线程时,本消息用于同步刷新,本消息由系统确定是否发送
        /// </summary>
        public const int WM_SYNCPAINT = 0x0088;
        /// <summary>
        /// 当光标在某窗口的非客户区内移动时,发送本消息给该窗口
        /// </summary>
        public const int WM_NCMOUSEMOVE = 0x00A0;
        /// <summary>
        /// 当光标在某窗口的非客户区内的同时按下鼠标左键,会发送本消息
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        /// <summary>
        /// 当用户释放鼠标左键的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCLBUTTONUP = 0x00A2;
        /// <summary>
        /// 当用户双击鼠标左键的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        /// <summary>
        /// 当用户按下鼠标右键的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCRBUTTONDOWN = 0x00A4;
        /// <summary>
        /// 当用户释放鼠标右键的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCRBUTTONUP = 0x00A5;
        /// <summary>
        /// 当用户双击鼠标右键的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCRBUTTONDBLCLK = 0x00A6;
        /// <summary>
        /// 当用户按下鼠标中键的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCMBUTTONDOWN = 0x00A7;
        /// <summary>
        /// 当用户释放鼠标中键的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCMBUTTONUP = 0x00A8;
        /// <summary>
        /// 当用户双击鼠标中键的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCMBUTTONDBLCLK = 0x00A9;
        /// <summary>
        /// 当用户按下鼠标X键(?)的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCXBUTTONDOWN = 0x00AB;
        /// <summary>
        /// 当用户释放鼠标X键(?)的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCXBUTTONUP = 0x00AC;
        /// <summary>
        /// 当用户双击鼠标X键(?)的同时光标在某窗口的非客户区内时,会发送本消息
        /// </summary>
        public const int WM_NCXBUTTONDBLCLK = 0x00AD;
        /// <summary>
        /// 设置滚动条上滑块的位置
        /// </summary>
        public const int SBM_SETPOS = 0x00E0;
        /// <summary>
        /// 获取滚动条上滑块的位置
        /// </summary>
        public const int SBM_GETPOS = 0x00E1;
        /// <summary>
        /// 设置滚动条的最大与最小位置值
        /// </summary>
        public const int SBM_SETRANGE = 0x00E2;
        /// <summary>
        /// 获取滚动条的最大与最小位置值
        /// </summary>
        public const int SBM_GETRANGE = 0x00E3;
        /// <summary>
        /// 设置滚动条的最大与最小位置值,并重绘滚动条
        /// </summary>
        public const int SBM_ENABLE_ARROWS = 0x00E4;
        /// <summary>
        /// 设置滚动条的最大与最小位置值,并重绘滚动条
        /// </summary>
        public const int SBM_SETRANGEREDRAW = 0x00E6;
        /// <summary>
        /// 设置滚动条的参数,本消息通过SCROLLINFO结构指定多种参数,具体指定哪些参数由结构中的fMask成员确定
        /// </summary>
        public const int SBM_SETSCROLLINFO = 0x00E9;
        /// <summary>
        /// 获取滚动条的参数,发送本消息后,将在SCROLLINFO结构中返回控件的多种参数,当然须事先设定结构的fMask成员以确定具体要取得哪些参数
        /// </summary>
        public const int SBM_GETSCROLLINFO = 0x00EA;
        /// <summary>
        /// 获取滚动条Bar的参数
        /// </summary>
        public const int SBM_GETSCROLLBARINFO = 0x00EB;
        /// <summary>
        /// 获取单选按钮或复选框的状态
        /// </summary>
        public const int BM_GETCHECK = 0x00F0;
        /// <summary>
        /// 设置单选按钮或复选框的状态
        /// </summary>
        public const int BM_SETCHECK = 0x00F1;
        /// <summary>
        /// 确定单选按钮或复选框的状态
        /// </summary>
        public const int BM_GETSTATE = 0x00F2;
        /// <summary>
        /// 改变按钮的高亮状态
        /// </summary>
        public const int BM_SETSTATE = 0x00F3;
        /// <summary>
        /// 改变按钮的风格
        /// </summary>
        public const int BM_SETSTYLE = 0x00F4;
        /// <summary>
        /// 模拟用户点击按钮
        /// </summary>
        public const int BM_CLICK = 0x00F5;
        /// <summary>
        /// 获取与按钮相关联的图片句柄(图标或位图)
        /// </summary>
        public const int BM_GETIMAGE = 0x00F6;
        /// <summary>
        /// 把按钮与某张图片相关联(图标或位图),注:按钮须有BS_ICON风格
        /// </summary>
        public const int BM_SETIMAGE = 0x00F7;
        /// <summary>
        /// 设置按钮不可点击??
        /// </summary>
        public const int BM_SETDONTCLICK = 0x00F8;

        public const int WM_INPUT_DEVICE_CHANGE = 0x00FE;

        public const int WM_INPUT = 0x00FF;

        public const int WM_KEYFIRST = 0x0100;

        public const int WM_KEYDOWN = 0x0100;

        public const int WM_KEYUP = 0x0101;

        public const int WM_CHAR = 0x0102;

        public const int WM_DEADCHAR = 0x0103;

        public const int WM_SYSKEYDOWN = 0x0104;

        public const int WM_SYSKEYUP = 0x0105;

        public const int WM_SYSCHAR = 0x0106;

        public const int WM_SYSDEADCHAR = 0x0107;

        public const int WM_KEYLAST = 0x0108;

        public const int WM_UNICHAR = 0x0109;

        public const int WM_IME_STARTCOMPOSITION = 0x010D;

        public const int WM_IME_ENDCOMPOSITION = 0x010E;

        public const int WM_IME_COMPOSITION = 0x010F;

        public const int WM_IME_KEYLAST = 0x010F;

        public const int WM_INITDIALOG = 0x0110;

        public const int WM_COMMAND = 0x0111;

        public const int WM_SYSCOMMAND = 0x0112;

        public const int WM_TIMER = 0x0113;

        public const int WM_HSCROLL = 0x0114;

        public const int WM_VSCROLL = 0x0115;

        public const int WM_INITMENU = 0x0116;

        public const int WM_INITMENUPOPUP = 0x0117;

        public const int WM_GESTURE = 0x0119;

        public const int WM_GESTURENOTIFY = 0x011A;

        public const int WM_MENUSELECT = 0x011F;

        public const int WM_MENUCHAR = 0x0120;

        public const int WM_ENTERIDLE = 0x0121;

        public const int WM_MENURBUTTONUP = 0x0122;

        public const int WM_MENUDRAG = 0x0123;

        public const int WM_MENUGETOBJECT = 0x0124;

        public const int WM_UNINITMENUPOPUP = 0x0125;

        public const int WM_MENUCOMMAND = 0x0126;

        public const int WM_CHANGEUISTATE = 0x0127;

        public const int WM_UPDATEUISTATE = 0x0128;

        public const int WM_QUERYUISTATE = 0x0129;

        public const int WM_CTLCOLORMSGBOX = 0x0132;

        public const int WM_CTLCOLOREDIT = 0x0133;

        public const int WM_CTLCOLORLISTBOX = 0x0134;

        public const int WM_CTLCOLORBTN = 0x0135;

        public const int WM_CTLCOLORDLG = 0x0136;

        public const int WM_CTLCOLORSCROLLBAR = 0x0137;

        public const int WM_CTLCOLORSTATIC = 0x0138;

        public const int CB_GETEDITSEL = 0x0140;

        public const int CB_LIMITTEXT = 0x0141;

        public const int CB_SETEDITSEL = 0x0142;

        public const int CB_ADDSTRING = 0x0143;

        public const int CB_DELETESTRING = 0x0144;

        public const int CB_DIR = 0x0145;

        public const int CB_GETCOUNT = 0x0146;

        public const int CB_GETCURSEL = 0x0147;

        public const int CB_GETLBTEXT = 0x0148;

        public const int CB_GETLBTEXTLEN = 0x0149;

        public const int CB_INSERTSTRING = 0x014A;

        public const int CB_RESETCONTENT = 0x014B;

        public const int CB_FINDSTRING = 0x014C;

        public const int CB_SELECTSTRING = 0x014D;

        public const int CB_SETCURSEL = 0x014E;

        public const int CB_SHOWDROPDOWN = 0x014F;

        public const int CB_GETITEMDATA = 0x0150;

        public const int CB_SETITEMDATA = 0x0151;

        public const int CB_GETDROPPEDCONTROLRECT = 0x0152;

        public const int CB_SETITEMHEIGHT = 0x0153;

        public const int CB_GETITEMHEIGHT = 0x0154;

        public const int CB_SETEXTENDEDUI = 0x0155;

        public const int CB_GETEXTENDEDUI = 0x0156;

        public const int CB_GETDROPPEDSTATE = 0x0157;

        public const int CB_FINDSTRINGEXACT = 0x0158;

        public const int CB_SETLOCALE = 0x0159;

        public const int CB_GETLOCALE = 0x015A;

        public const int CB_GETTOPINDEX = 0x015B;

        public const int CB_SETTOPINDEX = 0x015C;

        public const int CB_GETHORIZONTALEXTENT = 0x015D;

        public const int CB_SETHORIZONTALEXTENT = 0x015E;

        public const int CB_GETDROPPEDWIDTH = 0x015F;

        public const int CB_SETDROPPEDWIDTH = 0x0160;

        public const int CB_INITSTORAGE = 0x0161;

        public const int CB_MSGMAX = 0x0162;

        public const int CB_MULTIPLEADDSTRING = 0x0163;

        public const int CB_MSGMAX2 = 0x0163;

        public const int CB_GETCOMBOBOXINFO = 0x0164;

        public const int CB_MSGMAX3 = 0x0165;

        public const int STM_SETICON = 0x0170;

        public const int STM_GETICON = 0x0171;

        public const int STM_SETIMAGE = 0x0172;

        public const int STM_GETIMAGE = 0x0173;

        public const int STM_MSGMAX = 0x0174;

        public const int LB_ADDSTRING = 0x0180;

        public const int LB_INSERTSTRING = 0x0181;

        public const int LB_DELETESTRING = 0x0182;

        public const int LB_SELITEMRANGEEX = 0x0183;

        public const int LB_RESETCONTENT = 0x0184;

        public const int LB_SETSEL = 0x0185;

        public const int LB_SETCURSEL = 0x0186;

        public const int LB_GETSEL = 0x0187;

        public const int LB_GETCURSEL = 0x0188;

        public const int LB_GETTEXT = 0x0189;

        public const int LB_GETTEXTLEN = 0x018A;

        public const int LB_GETCOUNT = 0x018B;

        public const int LB_SELECTSTRING = 0x018C;

        public const int LB_DIR = 0x018D;

        public const int LB_GETTOPINDEX = 0x018E;

        public const int LB_FINDSTRING = 0x018F;

        public const int LB_GETSELCOUNT = 0x0190;

        public const int LB_GETSELITEMS = 0x0191;

        public const int LB_SETTABSTOPS = 0x0192;

        public const int LB_GETHORIZONTALEXTENT = 0x0193;

        public const int LB_SETHORIZONTALEXTENT = 0x0194;

        public const int LB_SETCOLUMNWIDTH = 0x0195;

        public const int LB_ADDFILE = 0x0196;

        public const int LB_SETTOPINDEX = 0x0197;

        public const int LB_GETITEMRECT = 0x0198;

        public const int LB_GETITEMDATA = 0x0199;

        public const int LB_SETITEMDATA = 0x019A;

        public const int LB_SELITEMRANGE = 0x019B;

        public const int LB_SETANCHORINDEX = 0x019C;

        public const int LB_GETANCHORINDEX = 0x019D;

        public const int LB_SETCARETINDEX = 0x019E;

        public const int LB_GETCARETINDEX = 0x019F;

        public const int LB_SETITEMHEIGHT = 0x01A0;

        public const int LB_GETITEMHEIGHT = 0x01A1;

        public const int LB_FINDSTRINGEXACT = 0x01A2;

        public const int LB_SETLOCALE = 0x01A5;

        public const int LB_GETLOCALE = 0x01A6;

        public const int LB_SETCOUNT = 0x01A7;

        public const int LB_INITSTORAGE = 0x01A8;

        public const int LB_ITEMFROMPOINT = 0x01A9;

        public const int LB_MULTIPLEADDSTRING = 0x01B1;

        public const int LB_GETLISTBOXINFO = 0x01B2;

        public const int LB_MSGMAX = 0x01B3;

        public const int MN_GETHMENU = 0x01E1;

        public const int WM_MOUSEFIRST = 0x0200;

        public const int WM_MOUSEMOVE = 0x0200;

        public const int WM_LBUTTONDOWN = 0x0201;

        public const int WM_LBUTTONUP = 0x0202;

        public const int WM_LBUTTONDBLCLK = 0x0203;

        public const int WM_RBUTTONDOWN = 0x0204;

        public const int WM_RBUTTONUP = 0x0205;

        public const int WM_RBUTTONDBLCLK = 0x0206;

        public const int WM_MBUTTONDOWN = 0x0207;

        public const int WM_MBUTTONUP = 0x0208;

        public const int WM_MBUTTONDBLCLK = 0x0209;

        public const int WM_MOUSELAST = 0x0209;

        public const int WM_MOUSEWHEEL = 0x020A;

        public const int WM_XBUTTONDOWN = 0x020B;

        public const int WM_XBUTTONUP = 0x020C;

        public const int WM_XBUTTONDBLCLK = 0x020D;

        public const int WM_MOUSEHWHEEL = 0x020E;

        public const int WM_PARENTNOTIFY = 0x0210;

        public const int WM_ENTERMENULOOP = 0x0211;

        public const int WM_EXITMENULOOP = 0x0212;

        public const int WM_NEXTMENU = 0x0213;

        public const int WM_SIZING = 0x0214;

        public const int WM_CAPTURECHANGED = 0x0215;

        public const int WM_MOVING = 0x0216;

        public const int WM_POWERBROADCAST = 0x0218;

        public const int WM_DEVICECHANGE = 0x0219;

        public const int WM_MDICREATE = 0x0220;

        public const int WM_MDIDESTROY = 0x0221;

        public const int WM_MDIACTIVATE = 0x0222;

        public const int WM_MDIRESTORE = 0x0223;

        public const int WM_MDINEXT = 0x0224;

        public const int WM_MDIMAXIMIZE = 0x0225;

        public const int WM_MDITILE = 0x0226;

        public const int WM_MDICASCADE = 0x0227;

        public const int WM_MDIICONARRANGE = 0x0228;

        public const int WM_MDIGETACTIVE = 0x0229;

        public const int WM_MDISETMENU = 0x0230;

        public const int WM_ENTERSIZEMOVE = 0x0231;

        public const int WM_EXITSIZEMOVE = 0x0232;

        public const int WM_DROPFILES = 0x0233;

        public const int WM_MDIREFRESHMENU = 0x0234;

        public const int WM_TOUCH = 0x0240;

        public const int WM_IME_SETCONTEXT = 0x0281;

        public const int WM_IME_NOTIFY = 0x0282;

        public const int WM_IME_CONTROL = 0x0283;

        public const int WM_IME_COMPOSITIONFULL = 0x0284;

        public const int WM_IME_SELECT = 0x0285;

        public const int WM_IME_CHAR = 0x0286;

        public const int WM_IME_REQUEST = 0x0288;

        public const int WM_IME_KEYDOWN = 0x0290;

        public const int WM_IME_KEYUP = 0x0291;

        public const int WM_NCMOUSEHOVER = 0x02A0;

        public const int WM_MOUSEHOVER = 0x02A1;

        public const int WM_NCMOUSELEAVE = 0x02A2;

        public const int WM_MOUSELEAVE = 0x02A3;

        public const int WM_WTSSESSION_CHANGE = 0x02B1;

        public const int WM_TABLET_FIRST = 0x02C0;

        public const int WM_TABLET_LAST = 0x02DF;

        public const int WM_CUT = 0x0300;

        public const int WM_COPY = 0x0301;

        public const int WM_PASTE = 0x0302;

        public const int WM_CLEAR = 0x0303;

        public const int WM_UNDO = 0x0304;

        public const int WM_RENDERFORMAT = 0x0305;

        public const int WM_RENDERALLFORMATS = 0x0306;

        public const int WM_DESTROYCLIPBOARD = 0x0307;

        public const int WM_DRAWCLIPBOARD = 0x0308;

        public const int WM_PAINTCLIPBOARD = 0x0309;

        public const int WM_VSCROLLCLIPBOARD = 0x030A;

        public const int WM_SIZECLIPBOARD = 0x030B;

        public const int WM_ASKCBFORMATNAME = 0x030C;

        public const int WM_CHANGECBCHAIN = 0x030D;

        public const int WM_HSCROLLCLIPBOARD = 0x030E;

        public const int WM_QUERYNEWPALETTE = 0x030F;

        public const int WM_PALETTEISCHANGING = 0x0310;

        public const int WM_PALETTECHANGED = 0x0311;

        public const int WM_HOTKEY = 0x0312;

        public const int WM_PRINT = 0x0317;

        public const int WM_PRINTCLIENT = 0x0318;

        public const int WM_APPCOMMAND = 0x0319;

        public const int WM_THEMECHANGED = 0x031A;

        public const int WM_CLIPBOARDUPDATE = 0x031D;

        public const int WM_DWMCOMPOSITIONCHANGED = 0x031E;

        public const int WM_DWMNCRENDERINGCHANGED = 0x031F;

        public const int WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320;

        public const int WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321;

        public const int WM_DWMSENDICONICTHUMBNAIL = 0x0323;

        public const int WM_DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326;

        public const int WM_GETTITLEBARINFOEX = 0x033F;

        public const int WM_HANDHELDFIRST = 0x0358;

        public const int WM_HANDHELDLAST = 0x035F;

        public const int WM_AFXFIRST = 0x0360;

        public const int WM_AFXLAST = 0x037F;

        public const int WM_PENWINFIRST = 0x0380;

        public const int WM_PENWINLAST = 0x038F;

        public const int WM_USER = 0x0400; //1024

        public const int DM_GETDEFID = (WM_USER + 0);

        public const int DM_SETDEFID = (WM_USER + 1);

        public const int DM_REPOSITION = (WM_USER + 2);

        public const int NCM_GETADDRESS = (WM_USER + 1);

        public const int NCM_SETALLOWTYPE = (WM_USER + 2);

        public const int NCM_GETALLOWTYPE = (WM_USER + 3);

        public const int NCM_DISPLAYERRORTIP = (WM_USER + 4);

        public const int PBM_SETRANGE = (WM_USER + 1);

        public const int PBM_SETPOS = (WM_USER + 2);

        public const int PBM_DELTAPOS = (WM_USER + 3);

        public const int PBM_SETSTEP = (WM_USER + 4);

        public const int PBM_STEPIT = (WM_USER + 5);

        public const int PBM_SETRANGE32 = (WM_USER + 6);

        public const int PBM_GETRANGE = (WM_USER + 7);

        public const int PBM_GETPOS = (WM_USER + 8);

        public const int PBM_SETBARCOLOR = (WM_USER + 9);

        public const int PBM_SETMARQUEE = (WM_USER + 10);

        public const int PBM_GETSTEP = (WM_USER + 13);

        public const int PBM_GETBKCOLOR = (WM_USER + 14);

        public const int PBM_GETBARCOLOR = (WM_USER + 15);

        public const int PBM_SETSTATE = (WM_USER + 16);

        public const int PBM_GETSTATE = (WM_USER + 17);

        public const int TTM_ACTIVATE = (WM_USER + 1);

        public const int TTM_SETDELAYTIME = (WM_USER + 3);

        public const int TTM_ADDTOOLA = (WM_USER + 4);

        public const int TTM_DELTOOLA = (WM_USER + 5);

        public const int TTM_NEWTOOLRECTA = (WM_USER + 6);

        public const int TTM_RELAYEVENT = (WM_USER + 7);

        public const int TTM_GETTOOLINFOA = (WM_USER + 8);

        public const int TTM_SETTOOLINFOA = (WM_USER + 9);

        public const int TTM_HITTESTA = (WM_USER + 10);

        public const int TTM_GETTEXTA = (WM_USER + 11);

        public const int TTM_UPDATETIPTEXTA = (WM_USER + 12);

        public const int TTM_GETTOOLCOUNT = (WM_USER + 13);

        public const int TTM_ENUMTOOLSA = (WM_USER + 14);

        public const int TTM_GETCURRENTTOOLA = (WM_USER + 15);

        public const int TTM_WINDOWFROMPOINT = (WM_USER + 16);

        public const int TTM_TRACKACTIVATE = (WM_USER + 17);

        public const int TTM_TRACKPOSITION = (WM_USER + 18);

        public const int TTM_SETTIPBKCOLOR = (WM_USER + 19);

        public const int TTM_SETTIPTEXTCOLOR = (WM_USER + 20);

        public const int TTM_GETDELAYTIME = (WM_USER + 21);

        public const int TTM_GETTIPBKCOLOR = (WM_USER + 22);

        public const int TTM_GETTIPTEXTCOLOR = (WM_USER + 23);

        public const int TTM_SETMAXTIPWIDTH = (WM_USER + 24);

        public const int TTM_GETMAXTIPWIDTH = (WM_USER + 25);

        public const int TTM_SETMARGIN = (WM_USER + 26);

        public const int TTM_GETMARGIN = (WM_USER + 27);

        public const int TTM_POP = (WM_USER + 28);

        public const int TTM_UPDATE = (WM_USER + 29);

        public const int TTM_GETBUBBLESIZE = (WM_USER + 30);

        public const int TTM_ADJUSTRECT = (WM_USER + 31);

        public const int TTM_SETTITLEA = (WM_USER + 32);

        public const int TTM_SETTITLEW = (WM_USER + 33);

        public const int TTM_POPUP = (WM_USER + 34);

        public const int TTM_GETTITLE = (WM_USER + 35);

        public const int TTM_ADDTOOLW = (WM_USER + 50);

        public const int TTM_DELTOOLW = (WM_USER + 51);

        public const int TTM_NEWTOOLRECTW = (WM_USER + 52);

        public const int TTM_GETTOOLINFOW = (WM_USER + 53);

        public const int TTM_SETTOOLINFOW = (WM_USER + 54);

        public const int TTM_HITTESTW = (WM_USER + 55);

        public const int TTM_GETTEXTW = (WM_USER + 56);

        public const int TTM_UPDATETIPTEXTW = (WM_USER + 57);

        public const int TTM_ENUMTOOLSW = (WM_USER + 58);

        public const int TTM_GETCURRENTTOOLW = (WM_USER + 59);

        public const int TB_ENABLEBUTTON = (WM_USER + 1);

        public const int TB_CHECKBUTTON = (WM_USER + 2);

        public const int TB_PRESSBUTTON = (WM_USER + 3);

        public const int TB_HIDEBUTTON = (WM_USER + 4);

        public const int TB_INDETERMINATE = (WM_USER + 5);

        public const int TB_MARKBUTTON = (WM_USER + 6);

        public const int TB_ISBUTTONENABLED = (WM_USER + 9);

        public const int TB_ISBUTTONCHECKED = (WM_USER + 10);

        public const int TB_ISBUTTONPRESSED = (WM_USER + 11);

        public const int TB_ISBUTTONHIDDEN = (WM_USER + 12);

        public const int TB_ISBUTTONINDETERMINATE = (WM_USER + 13);

        public const int TB_ISBUTTONHIGHLIGHTED = (WM_USER + 14);

        public const int TB_SETSTATE = (WM_USER + 17);

        public const int TB_GETSTATE = (WM_USER + 18);

        public const int TB_ADDBITMAP = (WM_USER + 19);

        public const int TB_ADDBUTTONSA = (WM_USER + 20);

        public const int TB_ADDBUTTONS = (WM_USER + 20);

        public const int TB_INSERTBUTTONA = (WM_USER + 21);

        public const int TB_INSERTBUTTON = (WM_USER + 21);

        public const int TB_DELETEBUTTON = (WM_USER + 22);

        public const int TB_GETBUTTON = (WM_USER + 23);

        public const int TB_BUTTONCOUNT = (WM_USER + 24);

        public const int TB_COMMANDTOINDEX = (WM_USER + 25);

        public const int TB_SAVERESTOREA = (WM_USER + 26);

        public const int TB_CUSTOMIZE = (WM_USER + 27);

        public const int TB_ADDSTRINGA = (WM_USER + 28);

        public const int TB_GETITEMRECT = (WM_USER + 29);

        public const int TB_BUTTONSTRUCTSIZE = (WM_USER + 30);

        public const int TB_SETBUTTONSIZE = (WM_USER + 31);

        public const int TB_SETBITMAPSIZE = (WM_USER + 32);

        public const int TB_AUTOSIZE = (WM_USER + 33);

        public const int TB_GETTOOLTIPS = (WM_USER + 35);

        public const int TB_SETTOOLTIPS = (WM_USER + 36);

        public const int TB_SETPARENT = (WM_USER + 37);

        public const int TB_SETROWS = (WM_USER + 39);

        public const int TB_GETROWS = (WM_USER + 40);

        public const int TB_GETBITMAPFLAGS = (WM_USER + 41);

        public const int TB_SETCMDID = (WM_USER + 42);

        public const int TB_CHANGEBITMAP = (WM_USER + 43);

        public const int TB_GETBITMAP = (WM_USER + 44);

        public const int TB_GETBUTTONTEXTA = (WM_USER + 45);

        public const int TB_REPLACEBITMAP = (WM_USER + 46);

        public const int TB_SETINDENT = (WM_USER + 47);

        public const int TB_SETIMAGELIST = (WM_USER + 48);

        public const int TB_GETIMAGELIST = (WM_USER + 49);

        public const int TB_LOADIMAGES = (WM_USER + 50);

        public const int TB_GETRECT = (WM_USER + 51);

        public const int TB_SETHOTIMAGELIST = (WM_USER + 52);

        public const int TB_GETHOTIMAGELIST = (WM_USER + 53);

        public const int TB_SETDISABLEDIMAGELIST = (WM_USER + 54);

        public const int TB_GETDISABLEDIMAGELIST = (WM_USER + 55);

        public const int TB_SETSTYLE = (WM_USER + 56);

        public const int TB_GETSTYLE = (WM_USER + 57);

        public const int TB_GETBUTTONSIZE = (WM_USER + 58);

        public const int TB_SETBUTTONWIDTH = (WM_USER + 59);

        public const int TB_SETMAXTEXTROWS = (WM_USER + 60);

        public const int TB_GETTEXTROWS = (WM_USER + 61);

        public const int TB_GETOBJECT = (WM_USER + 62);

        public const int TB_GETBUTTONINFOW = (WM_USER + 63);

        public const int TB_SETBUTTONINFOW = (WM_USER + 64);

        public const int TB_GETBUTTONINFOA = (WM_USER + 65);

        public const int TB_SETBUTTONINFOA = (WM_USER + 66);

        public const int TB_INSERTBUTTONW = (WM_USER + 67);

        public const int TB_ADDBUTTONSW = (WM_USER + 68);

        public const int TB_HITTEST = (WM_USER + 69);

        public const int TB_GETHOTITEM = (WM_USER + 71);

        public const int TB_SETHOTITEM = (WM_USER + 72);

        public const int TB_SETANCHORHIGHLIGHT = (WM_USER + 73);

        public const int TB_GETANCHORHIGHLIGHT = (WM_USER + 74);

        public const int TB_GETBUTTONTEXTW = (WM_USER + 75);

        public const int TB_SAVERESTOREW = (WM_USER + 76);

        public const int TB_ADDSTRINGW = (WM_USER + 77);

        public const int TB_MAPACCELERATORA = (WM_USER + 78);

        public const int TB_GETINSERTMARK = (WM_USER + 79);

        public const int TB_SETINSERTMARK = (WM_USER + 80);

        public const int TB_INSERTMARKHITTEST = (WM_USER + 81);

        public const int TB_MOVEBUTTON = (WM_USER + 82);

        public const int TB_GETMAXSIZE = (WM_USER + 83);

        public const int TB_SETEXTENDEDSTYLE = (WM_USER + 84);

        public const int TB_GETEXTENDEDSTYLE = (WM_USER + 85);

        public const int TB_GETPADDING = (WM_USER + 86);

        public const int TB_SETPADDING = (WM_USER + 87);

        public const int TB_SETINSERTMARKCOLOR = (WM_USER + 88);

        public const int TB_GETINSERTMARKCOLOR = (WM_USER + 89);

        public const int TB_MAPACCELERATORW = (WM_USER + 90);

        public const int TB_GETSTRINGW = (WM_USER + 91);

        public const int TB_GETSTRINGA = (WM_USER + 92);

        public const int TB_SETHOTITEM2 = (WM_USER + 94);

        public const int TB_SETLISTGAP = (WM_USER + 96);

        public const int TB_GETIMAGELISTCOUNT = (WM_USER + 98);

        public const int TB_GETIDEALSIZE = (WM_USER + 99);

        public const int TB_GETMETRICS = (WM_USER + 101);

        public const int TB_SETMETRICS = (WM_USER + 102);

        public const int TB_GETITEMDROPDOWNRECT = (WM_USER + 103);

        public const int TB_SETPRESSEDIMAGELIST = (WM_USER + 104);

        public const int TB_GETPRESSEDIMAGELIST = (WM_USER + 105);

        public const int UDM_SETRANGE = (WM_USER + 101);

        public const int UDM_GETRANGE = (WM_USER + 102);

        public const int UDM_SETPOS = (WM_USER + 103);

        public const int UDM_GETPOS = (WM_USER + 104);

        public const int UDM_SETBUDDY = (WM_USER + 105);

        public const int UDM_GETBUDDY = (WM_USER + 106);

        public const int UDM_SETACCEL = (WM_USER + 107);

        public const int UDM_GETACCEL = (WM_USER + 108);

        public const int UDM_SETBASE = (WM_USER + 109);

        public const int UDM_GETBASE = (WM_USER + 110);

        public const int UDM_SETRANGE32 = (WM_USER + 111);

        public const int UDM_GETRANGE32 = (WM_USER + 112);

        public const int UDM_SETPOS32 = (WM_USER + 113);

        public const int UDM_GETPOS32 = (WM_USER + 114);

        public const int TBM_GETPOS = (WM_USER);

        public const int TBM_GETRANGEMIN = (WM_USER + 1);

        public const int TBM_GETRANGEMAX = (WM_USER + 2);

        public const int TBM_GETTIC = (WM_USER + 3);

        public const int TBM_SETTIC = (WM_USER + 4);

        public const int TBM_SETPOS = (WM_USER + 5);

        public const int TBM_SETRANGE = (WM_USER + 6);

        public const int TBM_SETRANGEMIN = (WM_USER + 7);

        public const int TBM_SETRANGEMAX = (WM_USER + 8);

        public const int TBM_CLEARTICS = (WM_USER + 9);

        public const int TBM_SETSEL = (WM_USER + 10);

        public const int TBM_SETSELSTART = (WM_USER + 11);

        public const int TBM_SETSELEND = (WM_USER + 12);

        public const int TBM_GETPTICS = (WM_USER + 14);

        public const int TBM_GETTICPOS = (WM_USER + 15);

        public const int TBM_GETNUMTICS = (WM_USER + 16);

        public const int TBM_GETSELSTART = (WM_USER + 17);

        public const int TBM_GETSELEND = (WM_USER + 18);

        public const int TBM_CLEARSEL = (WM_USER + 19);

        public const int TBM_SETTICFREQ = (WM_USER + 20);

        public const int TBM_SETPAGESIZE = (WM_USER + 21);

        public const int TBM_GETPAGESIZE = (WM_USER + 22);

        public const int TBM_SETLINESIZE = (WM_USER + 23);

        public const int TBM_GETLINESIZE = (WM_USER + 24);

        public const int TBM_GETTHUMBRECT = (WM_USER + 25);

        public const int TBM_GETCHANNELRECT = (WM_USER + 26);

        public const int TBM_SETTHUMBLENGTH = (WM_USER + 27);

        public const int TBM_GETTHUMBLENGTH = (WM_USER + 28);

        public const int TBM_SETTOOLTIPS = (WM_USER + 29);

        public const int TBM_GETTOOLTIPS = (WM_USER + 30);

        public const int TBM_SETTIPSIDE = (WM_USER + 31);

        public const int TBM_SETBUDDY = (WM_USER + 32);

        public const int TBM_GETBUDDY = (WM_USER + 33);

        public const int TBM_SETPOSNOTIFY = (WM_USER + 34);

        public const int RB_INSERTBANDA = (WM_USER + 1);

        public const int RB_DELETEBAND = (WM_USER + 2);

        public const int RB_GETBARINFO = (WM_USER + 3);

        public const int RB_SETBARINFO = (WM_USER + 4);

        public const int RB_GETBANDINFO = (WM_USER + 5);

        public const int RB_SETBANDINFOA = (WM_USER + 6);

        public const int RB_SETPARENT = (WM_USER + 7);

        public const int RB_HITTEST = (WM_USER + 8);

        public const int RB_GETRECT = (WM_USER + 9);

        public const int RB_INSERTBANDW = (WM_USER + 10);

        public const int RB_SETBANDINFOW = (WM_USER + 11);

        public const int RB_GETBANDCOUNT = (WM_USER + 12);

        public const int RB_GETROWCOUNT = (WM_USER + 13);

        public const int RB_GETROWHEIGHT = (WM_USER + 14);

        public const int RB_IDTOINDEX = (WM_USER + 16);

        public const int RB_GETTOOLTIPS = (WM_USER + 17);

        public const int RB_SETTOOLTIPS = (WM_USER + 18);

        public const int RB_SETBKCOLOR = (WM_USER + 19);

        public const int RB_GETBKCOLOR = (WM_USER + 20);

        public const int RB_SETTEXTCOLOR = (WM_USER + 21);

        public const int RB_GETTEXTCOLOR = (WM_USER + 22);

        public const int RB_BEGINDRAG = (WM_USER + 24);

        public const int RB_ENDDRAG = (WM_USER + 25);

        public const int RB_DRAGMOVE = (WM_USER + 26);

        public const int RB_GETBARHEIGHT = (WM_USER + 27);

        public const int RB_GETBANDINFOW = (WM_USER + 28);

        public const int RB_GETBANDINFOA = (WM_USER + 29);

        public const int RB_MINIMIZEBAND = (WM_USER + 30);

        public const int RB_MAXIMIZEBAND = (WM_USER + 31);

        public const int RB_GETBANDBORDERS = (WM_USER + 34);

        public const int RB_SHOWBAND = (WM_USER + 35);

        public const int RB_SETPALETTE = (WM_USER + 37);

        public const int RB_GETPALETTE = (WM_USER + 38);

        public const int RB_MOVEBAND = (WM_USER + 39);

        public const int RB_GETBANDMARGINS = (WM_USER + 40);

        public const int RB_SETEXTENDEDSTYLE = (WM_USER + 41);

        public const int RB_GETEXTENDEDSTYLE = (WM_USER + 42);

        public const int RB_PUSHCHEVRON = (WM_USER + 43);

        public const int RB_SETBANDWIDTH = (WM_USER + 44);

        public const int SB_SETTEXTA = (WM_USER + 1);

        public const int SB_GETTEXTA = (WM_USER + 2);

        public const int SB_GETTEXTLENGTHA = (WM_USER + 3);

        public const int SB_SETPARTS = (WM_USER + 4);

        public const int SB_GETPARTS = (WM_USER + 6);

        public const int SB_GETBORDERS = (WM_USER + 7);

        public const int SB_SETMINHEIGHT = (WM_USER + 8);

        public const int SB_SIMPLE = (WM_USER + 9);

        public const int SB_GETRECT = (WM_USER + 10);

        public const int SB_SETTEXTW = (WM_USER + 11);

        public const int SB_GETTEXTLENGTHW = (WM_USER + 12);

        public const int SB_GETTEXTW = (WM_USER + 13);

        public const int SB_ISSIMPLE = (WM_USER + 14);

        public const int SB_SETICON = (WM_USER + 15);

        public const int SB_SETTIPTEXTA = (WM_USER + 16);

        public const int SB_SETTIPTEXTW = (WM_USER + 17);

        public const int SB_GETTIPTEXTA = (WM_USER + 18);

        public const int SB_GETTIPTEXTW = (WM_USER + 19);

        public const int SB_GETICON = (WM_USER + 20);

        public const int SB_SIMPLEID = 0x00ff;

        public const int EM_GETLIMITTEXT = (WM_USER + 37);

        public const int EM_POSFROMCHAR = (WM_USER + 38);

        public const int EM_CHARFROMPOS = (WM_USER + 39);

        public const int EM_SCROLLCARET = (WM_USER + 49);

        public const int EM_CANPASTE = (WM_USER + 50);

        public const int EM_DISPLAYBAND = (WM_USER + 51);

        public const int EM_EXGETSEL = (WM_USER + 52);

        public const int EM_EXLIMITTEXT = (WM_USER + 53);

        public const int EM_EXLINEFROMCHAR = (WM_USER + 54);

        public const int EM_EXSETSEL = (WM_USER + 55);

        public const int EM_FINDTEXT = (WM_USER + 56);

        public const int EM_FORMATRANGE = (WM_USER + 57);

        public const int EM_GETCHARFORMAT = (WM_USER + 58);

        public const int EM_GETEVENTMASK = (WM_USER + 59);

        public const int EM_GETOLEINTERFACE = (WM_USER + 60);

        public const int EM_GETPARAFORMAT = (WM_USER + 61);

        public const int EM_GETSELTEXT = (WM_USER + 62);

        public const int EM_HIDESELECTION = (WM_USER + 63);

        public const int EM_PASTESPECIAL = (WM_USER + 64);

        public const int EM_REQUESTRESIZE = (WM_USER + 65);

        public const int EM_SELECTIONTYPE = (WM_USER + 66);

        public const int EM_SETBKGNDCOLOR = (WM_USER + 67);

        public const int EM_SETCHARFORMAT = (WM_USER + 68);

        public const int EM_SETEVENTMASK = (WM_USER + 69);

        public const int EM_SETOLECALLBACK = (WM_USER + 70);

        public const int EM_SETPARAFORMAT = (WM_USER + 71);

        public const int EM_SETTARGETDEVICE = (WM_USER + 72);

        public const int EM_STREAMIN = (WM_USER + 73);

        public const int EM_STREAMOUT = (WM_USER + 74);

        public const int EM_GETTEXTRANGE = (WM_USER + 75);

        public const int EM_FINDWORDBREAK = (WM_USER + 76);

        public const int EM_SETOPTIONS = (WM_USER + 77);

        public const int EM_GETOPTIONS = (WM_USER + 78);

        public const int EM_FINDTEXTEX = (WM_USER + 79);

        public const int EM_GETWORDBREAKPROCEX = (WM_USER + 80);

        public const int EM_SETWORDBREAKPROCEX = (WM_USER + 81);

        public const int EM_SETUNDOLIMIT = (WM_USER + 82);

        public const int EM_REDO = (WM_USER + 84);

        public const int EM_CANREDO = (WM_USER + 85);

        public const int EM_GETUNDONAME = (WM_USER + 86);

        public const int EM_GETREDONAME = (WM_USER + 87);

        public const int EM_STOPGROUPTYPING = (WM_USER + 88);

        public const int EM_SETTEXTMODE = (WM_USER + 89);

        public const int EM_GETTEXTMODE = (WM_USER + 90);

        public const int EM_AUTOURLDETECT = (WM_USER + 91);

        public const int EM_GETAUTOURLDETECT = (WM_USER + 92);

        public const int EM_SETPALETTE = (WM_USER + 93);

        public const int EM_GETTEXTEX = (WM_USER + 94);

        public const int EM_GETTEXTLENGTHEX = (WM_USER + 95);

        public const int EM_SHOWSCROLLBAR = (WM_USER + 96);

        public const int EM_SETTEXTEX = (WM_USER + 97);

        public const int EM_SETPUNCTUATION = (WM_USER + 100);

        public const int EM_GETPUNCTUATION = (WM_USER + 101);

        public const int EM_SETWORDWRAPMODE = (WM_USER + 102);

        public const int EM_GETWORDWRAPMODE = (WM_USER + 103);

        public const int EM_SETIMECOLOR = (WM_USER + 104);

        public const int EM_GETIMECOLOR = (WM_USER + 105);

        public const int EM_SETIMEOPTIONS = (WM_USER + 106);

        public const int EM_GETIMEOPTIONS = (WM_USER + 107);

        public const int EM_CONVPOSITION = (WM_USER + 108);

        public const int EM_SETLANGOPTIONS = (WM_USER + 120);

        public const int EM_GETLANGOPTIONS = (WM_USER + 121);

        public const int EM_GETIMECOMPMODE = (WM_USER + 122);

        public const int EM_FINDTEXTW = (WM_USER + 123);

        public const int EM_FINDTEXTEXW = (WM_USER + 124);

        public const int EM_RECONVERSION = (WM_USER + 125);

        public const int EM_SETIMEMODEBIAS = (WM_USER + 126);

        public const int EM_GETIMEMODEBIAS = (WM_USER + 127);

        public const int EM_SETBIDIOPTIONS = (WM_USER + 200);

        public const int EM_GETBIDIOPTIONS = (WM_USER + 201);

        public const int EM_SETTYPOGRAPHYOPTIONS = (WM_USER + 202);

        public const int EM_GETTYPOGRAPHYOPTIONS = (WM_USER + 203);

        public const int EM_SETEDITSTYLE = (WM_USER + 204);

        public const int EM_GETEDITSTYLE = (WM_USER + 205);

        public const int EM_OUTLINE = (WM_USER + 220);

        public const int EM_GETSCROLLPOS = (WM_USER + 221);

        public const int EM_SETSCROLLPOS = (WM_USER + 222);

        public const int EM_SETFONTSIZE = (WM_USER + 223);

        public const int EM_GETZOOM = (WM_USER + 224);

        public const int EM_SETZOOM = (WM_USER + 225);

        public const int EM_GETVIEWKIND = (WM_USER + 226);

        public const int EM_SETVIEWKIND = (WM_USER + 227);

        public const int EM_GETPAGE = (WM_USER + 228);

        public const int EM_SETPAGE = (WM_USER + 229);

        public const int EM_GETHYPHENATEINFO = (WM_USER + 230);

        public const int EM_SETHYPHENATEINFO = (WM_USER + 231);

        public const int EM_GETPAGEROTATE = (WM_USER + 235);

        public const int EM_SETPAGEROTATE = (WM_USER + 236);

        public const int EM_GETCTFMODEBIAS = (WM_USER + 237);

        public const int EM_SETCTFMODEBIAS = (WM_USER + 238);

        public const int EM_GETCTFOPENSTATUS = (WM_USER + 240);

        public const int EM_SETCTFOPENSTATUS = (WM_USER + 241);

        public const int EM_GETIMECOMPTEXT = (WM_USER + 242);

        public const int EM_ISIME = (WM_USER + 243);

        public const int EM_GETIMEPROPERTY = (WM_USER + 244);

        public const int EM_GETQUERYRTFOBJ = (WM_USER + 269);

        public const int EM_SETQUERYRTFOBJ = (WM_USER + 270);

        public const int CBEM_INSERTITEMA = (WM_USER + 1);

        public const int CBEM_SETIMAGELIST = (WM_USER + 2);

        public const int CBEM_GETIMAGELIST = (WM_USER + 3);

        public const int CBEM_GETITEMA = (WM_USER + 4);

        public const int CBEM_SETITEMA = (WM_USER + 5);

        public const int CBEM_GETCOMBOCONTROL = (WM_USER + 6);

        public const int CBEM_GETEDITCONTROL = (WM_USER + 7);

        public const int CBEM_SETEXSTYLE = (WM_USER + 8);

        public const int CBEM_GETEXSTYLE = (WM_USER + 9);

        public const int CBEM_GETEXTENDEDSTYLE = (WM_USER + 9);

        public const int CBEM_HASEDITCHANGED = (WM_USER + 10);

        public const int CBEM_INSERTITEMW = (WM_USER + 11);

        public const int CBEM_SETITEMW = (WM_USER + 12);

        public const int CBEM_GETITEMW = (WM_USER + 13);

        public const int CBEM_SETEXTENDEDSTYLE = (WM_USER + 14);

        public const int ACM_OPENA = (WM_USER + 100);

        public const int ACM_PLAY = (WM_USER + 101);

        public const int ACM_STOP = (WM_USER + 102);

        public const int ACM_OPENW = (WM_USER + 103);

        public const int ACM_ISPLAYING = (WM_USER + 104);

        public const int IPM_CLEARADDRESS = (WM_USER + 100);

        public const int IPM_SETADDRESS = (WM_USER + 101);

        public const int IPM_GETADDRESS = (WM_USER + 102);

        public const int IPM_SETRANGE = (WM_USER + 103);

        public const int IPM_SETFOCUS = (WM_USER + 104);

        public const int IPM_ISBLANK = (WM_USER + 105);

        public const int PSM_SETCURSEL = (WM_USER + 101);

        public const int PSM_REMOVEPAGE = (WM_USER + 102);

        public const int PSM_ADDPAGE = (WM_USER + 103);

        public const int PSM_CHANGED = (WM_USER + 104);

        public const int PSM_RESTARTWINDOWS = (WM_USER + 105);

        public const int PSM_REBOOTSYSTEM = (WM_USER + 106);

        public const int PSM_CANCELTOCLOSE = (WM_USER + 107);

        public const int PSM_QUERYSIBLINGS = (WM_USER + 108);

        public const int PSM_UNCHANGED = (WM_USER + 109);

        public const int PSM_APPLY = (WM_USER + 110);

        public const int PSM_SETTITLEA = (WM_USER + 111);

        public const int PSM_SETWIZBUTTONS = (WM_USER + 112);

        public const int PSM_PRESSBUTTON = (WM_USER + 113);

        public const int PSM_SETCURSELID = (WM_USER + 114);

        public const int PSM_SETFINISHTEXTA = (WM_USER + 115);

        public const int PSM_GETTABCONTROL = (WM_USER + 116);

        public const int PSM_ISDIALOGMESSAGE = (WM_USER + 117);

        public const int PSM_GETCURRENTPAGEHWND = (WM_USER + 118);

        public const int PSM_INSERTPAGE = (WM_USER + 119);

        public const int PSM_SETTITLEW = (WM_USER + 120);

        public const int PSM_SETFINISHTEXTW = (WM_USER + 121);

        public const int PSM_SETHEADERTITLEA = (WM_USER + 125);

        public const int PSM_SETHEADERTITLEW = (WM_USER + 126);

        public const int PSM_SETHEADERSUBTITLEA = (WM_USER + 127);

        public const int PSM_SETHEADERSUBTITLEW = (WM_USER + 128);

        public const int PSM_HWNDTOINDEX = (WM_USER + 129);

        public const int PSM_INDEXTOHWND = (WM_USER + 130);

        public const int PSM_PAGETOINDEX = (WM_USER + 131);

        public const int PSM_INDEXTOPAGE = (WM_USER + 132);

        public const int PSM_IDTOINDEX = (WM_USER + 133);

        public const int PSM_INDEXTOID = (WM_USER + 134);

        public const int PSM_GETRESULT = (WM_USER + 135);

        public const int PSM_RECALCPAGESIZES = (WM_USER + 136);

        public const int PSM_SETNEXTTEXTW = (WM_USER + 137);

        public const int PSM_SHOWWIZBUTTONS = (WM_USER + 138);

        public const int PSM_ENABLEWIZBUTTONS = (WM_USER + 139);

        public const int PSM_SETBUTTONTEXTW = (WM_USER + 140);

        public const int DL_BEGINDRAG = (WM_USER + 133);

        public const int DL_DRAGGING = (WM_USER + 134);

        public const int DL_DROPPED = (WM_USER + 135);

        public const int DL_CANCELDRAG = (WM_USER + 136);

        public const int CDM_FIRST = (WM_USER + 100);

        public const int CDM_GETSPEC = (CDM_FIRST + 0x0000);

        public const int CDM_GETFILEPATH = (CDM_FIRST + 0x0001);

        public const int CDM_GETFOLDERPATH = (CDM_FIRST + 0x0002);

        public const int CDM_GETFOLDERIDLIST = (CDM_FIRST + 0x0003);

        public const int CDM_SETCONTROLTEXT = (CDM_FIRST + 0x0004);

        public const int CDM_HIDECONTROL = (CDM_FIRST + 0x0005);

        public const int CDM_SETDEFEXT = (CDM_FIRST + 0x0006);

        public const int CDM_LAST = (WM_USER + 200);

        public const int FM_GETFOCUS = (WM_USER + 0x0200);

        public const int FM_GETSELCOUNT = (WM_USER + 0x0202);

        public const int FM_GETSELCOUNTLFN = (WM_USER + 0x0203);

        public const int FM_REFRESH_WINDOWS = (WM_USER + 0x0206);

        public const int FM_RELOAD_EXTENSIONS = (WM_USER + 0x0207);

        public const int FM_GETDRIVEINFOA = (WM_USER + 0x0201);

        public const int FM_GETFILESELA = (WM_USER + 0x0204);

        public const int FM_GETFILESELLFNA = (WM_USER + 0x0205);

        public const int FM_GETDRIVEINFOW = (WM_USER + 0x0211);

        public const int FM_GETFILESELW = (WM_USER + 0x0214);

        public const int FM_GETFILESELLFNW = (WM_USER + 0x0215);

        public const int LM_HITTEST = (WM_USER + 0x300);

        public const int LM_GETIDEALHEIGHT = (WM_USER + 0x301);

        public const int LM_SETITEM = (WM_USER + 0x302);

        public const int LM_GETITEM = (WM_USER + 0x303);

        public const int DTM_FIRST = 0x1000;

        public const int DTM_GETSYSTEMTIME = (DTM_FIRST + 1);

        public const int DTM_SETSYSTEMTIME = (DTM_FIRST + 2);

        public const int DTM_GETRANGE = (DTM_FIRST + 3);

        public const int DTM_SETRANGE = (DTM_FIRST + 4);

        public const int DTM_SETFORMATA = (DTM_FIRST + 5);

        public const int DTM_SETMCCOLOR = (DTM_FIRST + 6);

        public const int DTM_GETMCCOLOR = (DTM_FIRST + 7);

        public const int DTM_GETMONTHCAL = (DTM_FIRST + 8);

        public const int DTM_SETMCFONT = (DTM_FIRST + 9);

        public const int DTM_GETMCFONT = (DTM_FIRST + 10);

        public const int DTM_SETMCSTYLE = (DTM_FIRST + 11);

        public const int DTM_GETMCSTYLE = (DTM_FIRST + 12);

        public const int DTM_CLOSEMONTHCAL = (DTM_FIRST + 13);

        public const int DTM_GETDATETIMEPICKERINFO = (DTM_FIRST + 14);

        public const int DTM_GETIDEALSIZE = (DTM_FIRST + 15);

        public const int DTM_SETFORMATW = (DTM_FIRST + 50);

        public const int LVM_FIRST = 0x1000;

        public const int LVM_GETBKCOLOR = (LVM_FIRST + 0);

        public const int LVM_SETBKCOLOR = (LVM_FIRST + 1);

        public const int LVM_GETIMAGELIST = (LVM_FIRST + 2);

        public const int LVM_SETIMAGELIST = (LVM_FIRST + 3);

        public const int LVM_GETITEMCOUNT = (LVM_FIRST + 4);

        public const int LVM_GETITEMA = (LVM_FIRST + 5);

        public const int LVM_SETITEMA = (LVM_FIRST + 6);

        public const int LVM_INSERTITEMA = (LVM_FIRST + 7);

        public const int LVM_DELETEITEM = (LVM_FIRST + 8);

        public const int LVM_DELETEALLITEMS = (LVM_FIRST + 9);

        public const int LVM_GETCALLBACKMASK = (LVM_FIRST + 10);

        public const int LVM_SETCALLBACKMASK = (LVM_FIRST + 11);

        public const int LVM_GETNEXTITEM = (LVM_FIRST + 12);

        public const int LVM_FINDITEMA = (LVM_FIRST + 13);

        public const int LVM_GETITEMRECT = (LVM_FIRST + 14);

        public const int LVM_SETITEMPOSITION = (LVM_FIRST + 15);

        public const int LVM_GETITEMPOSITION = (LVM_FIRST + 16);

        public const int LVM_GETSTRINGWIDTHA = (LVM_FIRST + 17);

        public const int LVM_HITTEST = (LVM_FIRST + 18);

        public const int LVM_ENSUREVISIBLE = (LVM_FIRST + 19);

        public const int LVM_SCROLL = (LVM_FIRST + 20);

        public const int LVM_REDRAWITEMS = (LVM_FIRST + 21);

        public const int LVM_ARRANGE = (LVM_FIRST + 22);

        public const int LVM_EDITLABELA = (LVM_FIRST + 23);

        public const int LVM_GETEDITCONTROL = (LVM_FIRST + 24);

        public const int LVM_GETCOLUMNA = (LVM_FIRST + 25);

        public const int LVM_SETCOLUMNA = (LVM_FIRST + 26);

        public const int LVM_INSERTCOLUMNA = (LVM_FIRST + 27);

        public const int LVM_DELETECOLUMN = (LVM_FIRST + 28);

        public const int LVM_GETCOLUMNWIDTH = (LVM_FIRST + 29);

        public const int LVM_SETCOLUMNWIDTH = (LVM_FIRST + 30);

        public const int LVM_GETHEADER = (LVM_FIRST + 31);

        public const int LVM_CREATEDRAGIMAGE = (LVM_FIRST + 33);

        public const int LVM_GETVIEWRECT = (LVM_FIRST + 34);

        public const int LVM_GETTEXTCOLOR = (LVM_FIRST + 35);

        public const int LVM_SETTEXTCOLOR = (LVM_FIRST + 36);

        public const int LVM_GETTEXTBKCOLOR = (LVM_FIRST + 37);

        public const int LVM_SETTEXTBKCOLOR = (LVM_FIRST + 38);

        public const int LVM_GETTOPINDEX = (LVM_FIRST + 39);

        public const int LVM_GETCOUNTPERPAGE = (LVM_FIRST + 40);

        public const int LVM_GETORIGIN = (LVM_FIRST + 41);

        public const int LVM_UPDATE = (LVM_FIRST + 42);

        public const int LVM_SETITEMSTATE = (LVM_FIRST + 43);

        public const int LVM_GETITEMSTATE = (LVM_FIRST + 44);

        public const int LVM_GETITEMTEXTA = (LVM_FIRST + 45);

        public const int LVM_SETITEMTEXTA = (LVM_FIRST + 46);

        public const int LVM_SETITEMCOUNT = (LVM_FIRST + 47);

        public const int LVM_SORTITEMS = (LVM_FIRST + 48);

        public const int LVM_SETITEMPOSITION32 = (LVM_FIRST + 49);

        public const int LVM_GETSELECTEDCOUNT = (LVM_FIRST + 50);

        public const int LVM_GETITEMSPACING = (LVM_FIRST + 51);

        public const int LVM_GETISEARCHSTRINGA = (LVM_FIRST + 52);

        public const int LVM_SETICONSPACING = (LVM_FIRST + 53);

        public const int LVM_SETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 54);

        public const int LVM_GETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 55);

        public const int LVM_GETSUBITEMRECT = (LVM_FIRST + 56);

        public const int LVM_SUBITEMHITTEST = (LVM_FIRST + 57);

        public const int LVM_SETCOLUMNORDERARRAY = (LVM_FIRST + 58);

        public const int LVM_GETCOLUMNORDERARRAY = (LVM_FIRST + 59);

        public const int LVM_SETHOTITEM = (LVM_FIRST + 60);

        public const int LVM_GETHOTITEM = (LVM_FIRST + 61);

        public const int LVM_SETHOTCURSOR = (LVM_FIRST + 62);

        public const int LVM_GETHOTCURSOR = (LVM_FIRST + 63);

        public const int LVM_APPROXIMATEVIEWRECT = (LVM_FIRST + 64);

        public const int LVM_SETWORKAREAS = (LVM_FIRST + 65);

        public const int LVM_GETSELECTIONMARK = (LVM_FIRST + 66);

        public const int LVM_SETSELECTIONMARK = (LVM_FIRST + 67);

        public const int LVM_SETBKIMAGEA = (LVM_FIRST + 68);

        public const int LVM_GETBKIMAGEA = (LVM_FIRST + 69);

        public const int LVM_GETWORKAREAS = (LVM_FIRST + 70);

        public const int LVM_SETHOVERTIME = (LVM_FIRST + 71);

        public const int LVM_GETHOVERTIME = (LVM_FIRST + 72);

        public const int LVM_GETNUMBEROFWORKAREAS = (LVM_FIRST + 73);

        public const int LVM_SETTOOLTIPS = (LVM_FIRST + 74);

        public const int LVM_GETITEMW = (LVM_FIRST + 75);

        public const int LVM_SETITEMW = (LVM_FIRST + 76);

        public const int LVM_INSERTITEMW = (LVM_FIRST + 77);

        public const int LVM_GETTOOLTIPS = (LVM_FIRST + 78);

        public const int LVM_SORTITEMSEX = (LVM_FIRST + 81);

        public const int LVM_FINDITEMW = (LVM_FIRST + 83);

        public const int LVM_GETGROUPSTATE = (LVM_FIRST + 92);

        public const int LVM_GETFOCUSEDGROUP = (LVM_FIRST + 93);

        public const int LVM_GETCOLUMNW = (LVM_FIRST + 95);

        public const int LVM_SETCOLUMNW = (LVM_FIRST + 96);

        public const int LVM_INSERTCOLUMNW = (LVM_FIRST + 97);

        public const int LVM_GETGROUPRECT = (LVM_FIRST + 98);

        public const int LVM_GETITEMTEXTW = (LVM_FIRST + 115);

        public const int LVM_SETITEMTEXTW = (LVM_FIRST + 116);

        public const int LVM_GETISEARCHSTRINGW = (LVM_FIRST + 117);

        public const int LVM_EDITLABELW = (LVM_FIRST + 118);

        public const int LVM_SETBKIMAGEW = (LVM_FIRST + 138);

        public const int LVM_GETBKIMAGEW = (LVM_FIRST + 139);

        public const int LVM_SETSELECTEDCOLUMN = (LVM_FIRST + 140);

        public const int LVM_SETVIEW = (LVM_FIRST + 142);

        public const int LVM_GETVIEW = (LVM_FIRST + 143);

        public const int LVM_INSERTGROUP = (LVM_FIRST + 145);

        public const int LVM_SETGROUPINFO = (LVM_FIRST + 147);

        public const int LVM_GETGROUPINFO = (LVM_FIRST + 149);

        public const int LVM_REMOVEGROUP = (LVM_FIRST + 150);

        public const int LVM_MOVEGROUP = (LVM_FIRST + 151);

        public const int LVM_GETGROUPCOUNT = (LVM_FIRST + 152);

        public const int LVM_GETGROUPINFOBYINDEX = (LVM_FIRST + 153);

        public const int LVM_MOVEITEMTOGROUP = (LVM_FIRST + 154);

        public const int LVM_SETGROUPMETRICS = (LVM_FIRST + 155);

        public const int LVM_GETGROUPMETRICS = (LVM_FIRST + 156);

        public const int LVM_ENABLEGROUPVIEW = (LVM_FIRST + 157);

        public const int LVM_SORTGROUPS = (LVM_FIRST + 158);

        public const int LVM_INSERTGROUPSORTED = (LVM_FIRST + 159);

        public const int LVM_REMOVEALLGROUPS = (LVM_FIRST + 160);

        public const int LVM_HASGROUP = (LVM_FIRST + 161);

        public const int LVM_SETTILEVIEWINFO = (LVM_FIRST + 162);

        public const int LVM_GETTILEVIEWINFO = (LVM_FIRST + 163);

        public const int LVM_SETTILEINFO = (LVM_FIRST + 164);

        public const int LVM_GETTILEINFO = (LVM_FIRST + 165);

        public const int LVM_SETINSERTMARK = (LVM_FIRST + 166);

        public const int LVM_GETINSERTMARK = (LVM_FIRST + 167);

        public const int LVM_INSERTMARKHITTEST = (LVM_FIRST + 168);

        public const int LVM_GETINSERTMARKRECT = (LVM_FIRST + 169);

        public const int LVM_SETINSERTMARKCOLOR = (LVM_FIRST + 170);

        public const int LVM_GETINSERTMARKCOLOR = (LVM_FIRST + 171);

        public const int LVM_SETINFOTIP = (LVM_FIRST + 173);

        public const int LVM_GETSELECTEDCOLUMN = (LVM_FIRST + 174);

        public const int LVM_ISGROUPVIEWENABLED = (LVM_FIRST + 175);

        public const int LVM_GETOUTLINECOLOR = (LVM_FIRST + 176);

        public const int LVM_SETOUTLINECOLOR = (LVM_FIRST + 177);

        public const int LVM_CANCELEDITLABEL = (LVM_FIRST + 179);

        public const int LVM_MAPINDEXTOID = (LVM_FIRST + 180);

        public const int LVM_MAPIDTOINDEX = (LVM_FIRST + 181);

        public const int LVM_ISITEMVISIBLE = (LVM_FIRST + 182);

        public const int LVM_GETEMPTYTEXT = (LVM_FIRST + 204);

        public const int LVM_GETFOOTERRECT = (LVM_FIRST + 205);

        public const int LVM_GETFOOTERINFO = (LVM_FIRST + 206);

        public const int LVM_GETFOOTERITEMRECT = (LVM_FIRST + 207);

        public const int LVM_GETFOOTERITEM = (LVM_FIRST + 208);

        public const int LVM_SETITEMINDEXSTATE = (LVM_FIRST + 210);

        public const int LVM_GETNEXTITEMINDEX = (LVM_FIRST + 211);

        public const int MCM_FIRST = 0x1000;

        public const int MCM_GETCURSEL = (MCM_FIRST + 1);

        public const int MCM_SETCURSEL = (MCM_FIRST + 2);

        public const int MCM_GETMAXSELCOUNT = (MCM_FIRST + 3);

        public const int MCM_SETMAXSELCOUNT = (MCM_FIRST + 4);

        public const int MCM_GETSELRANGE = (MCM_FIRST + 5);

        public const int MCM_SETSELRANGE = (MCM_FIRST + 6);

        public const int MCM_GETMONTHRANGE = (MCM_FIRST + 7);

        public const int MCM_SETDAYSTATE = (MCM_FIRST + 8);

        public const int MCM_GETMINREQRECT = (MCM_FIRST + 9);

        public const int MCM_SETCOLOR = (MCM_FIRST + 10);

        public const int MCM_GETCOLOR = (MCM_FIRST + 11);

        public const int MCM_SETTODAY = (MCM_FIRST + 12);

        public const int MCM_GETTODAY = (MCM_FIRST + 13);

        public const int MCM_HITTEST = (MCM_FIRST + 14);

        public const int MCM_SETFIRSTDAYOFWEEK = (MCM_FIRST + 15);

        public const int MCM_GETFIRSTDAYOFWEEK = (MCM_FIRST + 16);

        public const int MCM_GETRANGE = (MCM_FIRST + 17);

        public const int MCM_SETRANGE = (MCM_FIRST + 18);

        public const int MCM_GETMONTHDELTA = (MCM_FIRST + 19);

        public const int MCM_SETMONTHDELTA = (MCM_FIRST + 20);

        public const int MCM_GETMAXTODAYWIDTH = (MCM_FIRST + 21);

        public const int MCM_GETCURRENTVIEW = (MCM_FIRST + 22);

        public const int MCM_GETCALENDARCOUNT = (MCM_FIRST + 23);

        public const int MCM_GETCALENDARGRIDINFO = (MCM_FIRST + 24);

        public const int MCM_GETCALID = (MCM_FIRST + 27);

        public const int MCM_SETCALID = (MCM_FIRST + 28);

        public const int MCM_SIZERECTTOMIN = (MCM_FIRST + 29);

        public const int MCM_SETCALENDARBORDER = (MCM_FIRST + 30);

        public const int MCM_GETCALENDARBORDER = (MCM_FIRST + 31);

        public const int MCM_SETCURRENTVIEW = (MCM_FIRST + 32);

        public const int TV_FIRST = 0x1100;

        public const int TVM_INSERTITEMA = (TV_FIRST + 0);

        public const int TVM_DELETEITEM = (TV_FIRST + 1);

        public const int TVM_EXPAND = (TV_FIRST + 2);

        public const int TVM_GETITEMRECT = (TV_FIRST + 4);

        public const int TVM_GETCOUNT = (TV_FIRST + 5);

        public const int TVM_GETINDENT = (TV_FIRST + 6);

        public const int TVM_SETINDENT = (TV_FIRST + 7);

        public const int TVM_GETIMAGELIST = (TV_FIRST + 8);

        public const int TVM_SETIMAGELIST = (TV_FIRST + 9);

        public const int TVM_GETNEXTITEM = (TV_FIRST + 10);

        public const int TVM_SELECTITEM = (TV_FIRST + 11);

        public const int TVM_GETITEMA = (TV_FIRST + 12);

        public const int TVM_SETITEMA = (TV_FIRST + 13);

        public const int TVM_EDITLABELA = (TV_FIRST + 14);

        public const int TVM_GETEDITCONTROL = (TV_FIRST + 15);

        public const int TVM_GETVISIBLECOUNT = (TV_FIRST + 16);

        public const int TVM_HITTEST = (TV_FIRST + 17);

        public const int TVM_CREATEDRAGIMAGE = (TV_FIRST + 18);

        public const int TVM_SORTCHILDREN = (TV_FIRST + 19);

        public const int TVM_ENSUREVISIBLE = (TV_FIRST + 20);

        public const int TVM_SORTCHILDRENCB = (TV_FIRST + 21);

        public const int TVM_ENDEDITLABELNOW = (TV_FIRST + 22);

        public const int TVM_GETISEARCHSTRINGA = (TV_FIRST + 23);

        public const int TVM_SETTOOLTIPS = (TV_FIRST + 24);

        public const int TVM_GETTOOLTIPS = (TV_FIRST + 25);

        public const int TVM_SETINSERTMARK = (TV_FIRST + 26);

        public const int TVM_SETITEMHEIGHT = (TV_FIRST + 27);

        public const int TVM_GETITEMHEIGHT = (TV_FIRST + 28);

        public const int TVM_SETBKCOLOR = (TV_FIRST + 29);

        public const int TVM_SETTEXTCOLOR = (TV_FIRST + 30);

        public const int TVM_GETBKCOLOR = (TV_FIRST + 31);

        public const int TVM_GETTEXTCOLOR = (TV_FIRST + 32);

        public const int TVM_SETSCROLLTIME = (TV_FIRST + 33);

        public const int TVM_GETSCROLLTIME = (TV_FIRST + 34);

        public const int TVM_SETINSERTMARKCOLOR = (TV_FIRST + 37);

        public const int TVM_GETINSERTMARKCOLOR = (TV_FIRST + 38);

        public const int TVM_GETITEMSTATE = (TV_FIRST + 39);

        public const int TVM_SETLINECOLOR = (TV_FIRST + 40);

        public const int TVM_GETLINECOLOR = (TV_FIRST + 41);

        public const int TVM_MAPACCIDTOHTREEITEM = (TV_FIRST + 42);

        public const int TVM_MAPHTREEITEMTOACCID = (TV_FIRST + 43);

        public const int TVM_SETEXTENDEDSTYLE = (TV_FIRST + 44);

        public const int TVM_GETEXTENDEDSTYLE = (TV_FIRST + 45);

        public const int TVM_INSERTITEMW = (TV_FIRST + 50);

        public const int TVM_SETAUTOSCROLLINFO = (TV_FIRST + 59);

        public const int TVM_GETITEMW = (TV_FIRST + 62);

        public const int TVM_SETITEMW = (TV_FIRST + 63);

        public const int TVM_GETISEARCHSTRINGW = (TV_FIRST + 64);

        public const int TVM_EDITLABELW = (TV_FIRST + 65);

        public const int TVM_GETSELECTEDCOUNT = (TV_FIRST + 70);

        public const int TVM_SHOWINFOTIP = (TV_FIRST + 71);

        public const int TVM_GETITEMPARTRECT = (TV_FIRST + 72);

        public const int HDM_FIRST = 0x1200;

        public const int HDM_GETITEMCOUNT = (HDM_FIRST + 0);

        public const int HDM_INSERTITEMA = (HDM_FIRST + 1);

        public const int HDM_DELETEITEM = (HDM_FIRST + 2);

        public const int HDM_GETITEMA = (HDM_FIRST + 3);

        public const int HDM_SETITEMA = (HDM_FIRST + 4);

        public const int HDM_LAYOUT = (HDM_FIRST + 5);

        public const int HDM_HITTEST = (HDM_FIRST + 6);

        public const int HDM_GETITEMRECT = (HDM_FIRST + 7);

        public const int HDM_SETIMAGELIST = (HDM_FIRST + 8);

        public const int HDM_GETIMAGELIST = (HDM_FIRST + 9);

        public const int HDM_INSERTITEMW = (HDM_FIRST + 10);

        public const int HDM_GETITEMW = (HDM_FIRST + 11);

        public const int HDM_SETITEMW = (HDM_FIRST + 12);

        public const int HDM_ORDERTOINDEX = (HDM_FIRST + 15);

        public const int HDM_CREATEDRAGIMAGE = (HDM_FIRST + 16);

        public const int HDM_GETORDERARRAY = (HDM_FIRST + 17);

        public const int HDM_SETORDERARRAY = (HDM_FIRST + 18);

        public const int HDM_SETHOTDIVIDER = (HDM_FIRST + 19);

        public const int HDM_SETBITMAPMARGIN = (HDM_FIRST + 20);

        public const int HDM_GETBITMAPMARGIN = (HDM_FIRST + 21);

        public const int HDM_SETFILTERCHANGETIMEOUT = (HDM_FIRST + 22);

        public const int HDM_EDITFILTER = (HDM_FIRST + 23);

        public const int HDM_CLEARFILTER = (HDM_FIRST + 24);

        public const int HDM_GETITEMDROPDOWNRECT = (HDM_FIRST + 25);

        public const int HDM_GETOVERFLOWRECT = (HDM_FIRST + 26);

        public const int HDM_GETFOCUSEDITEM = (HDM_FIRST + 27);

        public const int HDM_SETFOCUSEDITEM = (HDM_FIRST + 28);

        public const int TCM_FIRST = 0x1300;

        public const int TCM_GETIMAGELIST = (TCM_FIRST + 2);

        public const int TCM_SETIMAGELIST = (TCM_FIRST + 3);

        public const int TCM_GETITEMCOUNT = (TCM_FIRST + 4);

        public const int TCM_GETITEMA = (TCM_FIRST + 5);

        public const int TCM_SETITEMA = (TCM_FIRST + 6);

        public const int TCM_INSERTITEMA = (TCM_FIRST + 7);

        public const int TCM_DELETEITEM = (TCM_FIRST + 8);

        public const int TCM_DELETEALLITEMS = (TCM_FIRST + 9);

        public const int TCM_GETITEMRECT = (TCM_FIRST + 10);

        public const int TCM_GETCURSEL = (TCM_FIRST + 11);

        public const int TCM_SETCURSEL = (TCM_FIRST + 12);

        public const int TCM_HITTEST = (TCM_FIRST + 13);

        public const int TCM_SETITEMEXTRA = (TCM_FIRST + 14);

        public const int TCM_ADJUSTRECT = (TCM_FIRST + 40);

        public const int TCM_SETITEMSIZE = (TCM_FIRST + 41);

        public const int TCM_REMOVEIMAGE = (TCM_FIRST + 42);

        public const int TCM_SETPADDING = (TCM_FIRST + 43);

        public const int TCM_GETROWCOUNT = (TCM_FIRST + 44);

        public const int TCM_GETTOOLTIPS = (TCM_FIRST + 45);

        public const int TCM_SETTOOLTIPS = (TCM_FIRST + 46);

        public const int TCM_GETCURFOCUS = (TCM_FIRST + 47);

        public const int TCM_SETCURFOCUS = (TCM_FIRST + 48);

        public const int TCM_SETMINTABWIDTH = (TCM_FIRST + 49);

        public const int TCM_DESELECTALL = (TCM_FIRST + 50);

        public const int TCM_HIGHLIGHTITEM = (TCM_FIRST + 51);

        public const int TCM_SETEXTENDEDSTYLE = (TCM_FIRST + 52);

        public const int TCM_GETEXTENDEDSTYLE = (TCM_FIRST + 53);

        public const int TCM_GETITEMW = (TCM_FIRST + 60);

        public const int TCM_SETITEMW = (TCM_FIRST + 61);

        public const int TCM_INSERTITEMW = (TCM_FIRST + 62);

        public const int PGM_FIRST = 0x1400;

        public const int PGM_SETCHILD = (PGM_FIRST + 1);

        public const int PGM_RECALCSIZE = (PGM_FIRST + 2);

        public const int PGM_FORWARDMOUSE = (PGM_FIRST + 3);

        public const int PGM_SETBKCOLOR = (PGM_FIRST + 4);

        public const int PGM_GETBKCOLOR = (PGM_FIRST + 5);

        public const int PGM_SETBORDER = (PGM_FIRST + 6);

        public const int PGM_GETBORDER = (PGM_FIRST + 7);

        public const int PGM_SETPOS = (PGM_FIRST + 8);

        public const int PGM_GETPOS = (PGM_FIRST + 9);

        public const int PGM_SETBUTTONSIZE = (PGM_FIRST + 10);

        public const int PGM_GETBUTTONSIZE = (PGM_FIRST + 11);

        public const int PGM_GETBUTTONSTATE = (PGM_FIRST + 12);

        public const int ECM_FIRST = 0x1500;

        public const int EM_SETCUEBANNER = (ECM_FIRST + 1);

        public const int EM_GETCUEBANNER = (ECM_FIRST + 2);

        public const int EM_SHOWBALLOONTIP = (ECM_FIRST + 3);

        public const int EM_HIDEBALLOONTIP = (ECM_FIRST + 4);

        public const int EM_SETHILITE = (ECM_FIRST + 5);

        public const int EM_GETHILITE = (ECM_FIRST + 6);

        public const int BCM_FIRST = 0x1600;

        public const int BCM_GETIDEALSIZE = (BCM_FIRST + 0x0001);

        public const int BCM_SETIMAGELIST = (BCM_FIRST + 0x0002);

        public const int BCM_GETIMAGELIST = (BCM_FIRST + 0x0003);

        public const int BCM_SETTEXTMARGIN = (BCM_FIRST + 0x0004);

        public const int BCM_GETTEXTMARGIN = (BCM_FIRST + 0x0005);

        public const int BCM_SETDROPDOWNSTATE = (BCM_FIRST + 0x0006);

        public const int BCM_SETSPLITINFO = (BCM_FIRST + 0x0007);

        public const int BCM_GETSPLITINFO = (BCM_FIRST + 0x0008);

        public const int BCM_SETNOTE = (BCM_FIRST + 0x0009);

        public const int BCM_GETNOTE = (BCM_FIRST + 0x000A);

        public const int BCM_GETNOTELENGTH = (BCM_FIRST + 0x000B);

        public const int BCM_SETSHIELD = (BCM_FIRST + 0x000C);

        public const int CBM_FIRST = 0x1700;

        public const int CB_SETMINVISIBLE = (CBM_FIRST + 1);

        public const int CB_GETMINVISIBLE = (CBM_FIRST + 2);

        public const int CB_SETCUEBANNER = (CBM_FIRST + 3);

        public const int CB_GETCUEBANNER = (CBM_FIRST + 4);

        public const int CCM_FIRST = 0x2000;

        public const int CCM_SETBKCOLOR = (CCM_FIRST + 1);

        public const int CCM_SETCOLORSCHEME = (CCM_FIRST + 2);

        public const int CCM_GETCOLORSCHEME = (CCM_FIRST + 3);

        public const int CCM_GETDROPTARGET = (CCM_FIRST + 4);

        public const int CCM_SETUNICODEFORMAT = (CCM_FIRST + 5);

        public const int CCM_GETUNICODEFORMAT = (CCM_FIRST + 6);

        public const int CCM_SETVERSION = (CCM_FIRST + 0x7);

        public const int CCM_GETVERSION = (CCM_FIRST + 0x8);

        public const int CCM_SETNOTIFYWINDOW = (CCM_FIRST + 0x9);

        public const int CCM_SETWINDOWTHEME = (CCM_FIRST + 0xb);

        public const int CCM_DPISCALE = (CCM_FIRST + 0xc);

        public const int CCM_LAST = (CCM_FIRST + 0x200);

        public const int WM_APP = 0x8000;

        #region IRP
        public const int IRP_MJ_CREATE = 0x00;

        public const int IRP_MJ_CREATE_NAMED_PIPE = 0x01;

        public const int IRP_MJ_CLOSE = 0x02;

        public const int IRP_MJ_READ = 0x03;

        public const int IRP_MJ_WRITE = 0x04;

        public const int IRP_MJ_QUERY_INFORMATION = 0x05;

        public const int IRP_MJ_SET_INFORMATION = 0x06;

        public const int IRP_MJ_QUERY_EA = 0x07;

        public const int IRP_MJ_SET_EA = 0x08;

        public const int IRP_MJ_FLUSH_BUFFERS = 0x09;

        public const int IRP_MJ_QUERY_VOLUME_INFORMATION = 0x0a;

        public const int IRP_MJ_SET_VOLUME_INFORMATION = 0x0b;

        public const int IRP_MJ_DIRECTORY_CONTROL = 0x0c;

        public const int IRP_MJ_FILE_SYSTEM_CONTROL = 0x0d;

        public const int IRP_MJ_DEVICE_CONTROL = 0x0e;

        public const int IRP_MJ_INTERNAL_DEVICE_CONTROL = 0x0f;

        public const int IRP_MJ_SHUTDOWN = 0x10;

        public const int IRP_MJ_LOCK_CONTROL = 0x11;

        public const int IRP_MJ_CLEANUP = 0x12;

        public const int IRP_MJ_CREATE_MAILSLOT = 0x13;

        public const int IRP_MJ_QUERY_SECURITY = 0x14;

        public const int IRP_MJ_SET_SECURITY = 0x15;

        public const int IRP_MJ_POWER = 0x16;

        public const int IRP_MJ_SYSTEM_CONTROL = 0x17;

        public const int IRP_MJ_DEVICE_CHANGE = 0x18;

        public const int IRP_MJ_QUERY_QUOTA = 0x19;

        public const int IRP_MJ_SET_QUOTA = 0x1a;

        public const int IRP_MJ_PNP = 0x1b;

        public const int IRP_MJ_PNP_POWER = IRP_MJ_PNP; // Obsolete....

        public const int IRP_MJ_MAXIMUM_FUNCTION = 0x1b;
        #endregion

        #region 其他一些Message的释义, 由于太多, 不一个一个搞了...
        /*
        //按钮控件通知消息
        166     IDSTR(BN_CLICKED),"用户单击了按钮,父窗通过WM_COMMAND来接收本通知消息",
        167     IDSTR(BN_DBLCLK),"用户双击了按钮(BS_OWNERDRAW或BS_RADIOBUTTON风格),父窗通过WM_COMMAND来接收本通知消息",
        168     IDSTR(BN_DISABLE),"按钮被禁止,父窗通过WM_COMMAND来接收本通知消息",
        169     IDSTR(BN_DOUBLECLICKED),"用户双击了按钮(与BN_DBLCLK同)(BS_OWNERDRAW或BS_RADIOBUTTON风格),父窗通过WM_COMMAND来接收本通知消息",
        170     IDSTR(BN_HILITE),"用户选择(即加亮)了按钮(与BN_PUSHED相同),父窗通过WM_COMMAND来接收本通知消息",
        171     IDSTR(BN_KILLFOCUS),"按钮失去了键盘焦点(按钮须有BS_NOTIFY风格才能发送本消息),父窗通过WM_COMMAND来接收本通知消息",
        172     IDSTR(BN_PAINT),"按钮应当重绘,父窗通过WM_COMMAND来接收本通知消息",
        173     IDSTR(BN_PUSHED),"用户加亮了按钮(与BN_HILITE相同),父窗通过WM_COMMAND来接收本通知消息",
        174     IDSTR(BN_SETFOCUS),"按钮收到键盘焦点(按钮须有BS_NOTIFY风格才能发送本消息),父窗通过WM_COMMAND息来接收本通知消息",
        175     IDSTR(BN_UNHILITE),"按钮的加亮应当去掉(与BN_UNPUSHED相同),父窗通过WM_COMMAND来接收本通知消息",
        176     IDSTR(BN_UNPUSHED),"按钮的加亮应当去掉(与BN_UNHILITE相同),父窗通过WM_COMMAND来接收本通知消息",
        177     
        178     IDSTR(WM_KEYFIRST),"用于WinCE系统,本消息在使用GetMessage和PeekMessage函数时,用于过滤键盘消息",
        179     IDSTR(WM_KEYDOWN),"当一个非系统按键被按下时(<ALT>键没有被按下),会发送本消息给拥有键盘焦点的窗口",
        180     IDSTR(WM_KEYUP),"当一个非系统按键被释放弹起时(<ALT>键没有被按下),会发送本消息给拥有键盘焦点的窗口",
        181     IDSTR(WM_CHAR),"按下某按键,并已发出WM_KEYDOWN、WM_KEYUP消息,本消息包含被按下的按键的字符码",
        182     IDSTR(WM_DEADCHAR),"\"死字符\"消息,当使用TranslateMessage函数翻译WM_KEYUP消息时,发送本消息给拥有键盘焦点的窗口,注:德语键盘上,有些按键只是给字符添加音标的,并不产生字符,故称\"死字符\"",
        183     IDSTR(WM_SYSKEYDOWN),"当用户按住<ALT>键的同时又按下其它键时,发送本消息给拥有焦点的窗口",
        184     IDSTR(WM_SYSKEYUP),"当用户释放一个按键的同时<ALT>键还按着时,发送本消息给拥有焦点的窗口",
        185     IDSTR(WM_SYSCHAR),"当WM_SYSKEYDOWN消息被TranslateMessage函数翻译后,发送本消息给拥有焦点的窗口,注:<ALT>键被按下",
        186     IDSTR(WM_SYSDEADCHAR),"\"死字符\"消息,当使用TranslateMessage函数翻译WM_SYSKEYDOWN消息时,发送本消息给拥有键盘焦点的窗口,注:德语键盘上,有些按键只是给字符添加音标的,并不产生字符,故称\"死字符\"",
        187     IDSTR(WM_KEYLAST),"用于WinCE系统,本消息在使用GetMessage和PeekMessage函数时,用于过滤键盘消息",
        188     IDSTR(WM_IME_STARTCOMPOSITION),"当用户开始输入编码时,系统立即发送该消息到IME中,IME打开编码窗口,注:输入法相关",
        189     IDSTR(WM_IME_ENDCOMPOSITION),"当编码结束时,IME发送本消息,用户程序可接受本消息,以便自己显示用户输入的编码,注:输入法相关",
        190     IDSTR(WM_IME_COMPOSITION),"当用户改变了编码状态时,发送本消息,应用程序可通过调用ImmGetCompositionString函数获取新的编码状态",
        191     IDSTR(WM_IME_KEYLAST),"当用户改变了编码状态时,发送本消息,应用程序可通过调用ImmGetCompositionString函数获取新的编码状态",
        192     IDSTR(WM_INITDIALOG),"在某对话框程序被显示前发送本消息给该对话框程序,通常用本消息对控件进行一些初始化工作和执行其它任务",
        193     IDSTR(WM_COMMAND),"用户选择一条菜单命令项或某控件发送一条通知消息给其父窗,或某快捷键被翻译时,本消息被发送",
        194     IDSTR(WM_SYSCOMMAND),"当用户选择一条系统菜单命令、用户最大化或最小化或还原或关闭时，窗口会收到本消息",
        195     IDSTR(WM_TIMER),"发生了定时器事件",
        196     IDSTR(WM_HSCROLL),"当窗口的标准水平滚动条产生一个滚动事件时,发送本消息给该窗口",
        197     IDSTR(WM_VSCROLL),"当窗口的标准垂直滚动条产生一个滚动事件时,发送本消息给该窗口",
        198     IDSTR(WM_INITMENU),"当一个菜单将被激活时发送本消息,它发生在用户点击了某菜单项或按下某菜单键。它允许程序在显示前更改菜单",
        199     IDSTR(WM_INITMENUPOPUP),"当一个下拉菜单或子菜单将被激活时发送本消息,它允许程序在它显示前更改菜单,却不更改全部菜单",
        200     IDSTR(WM_SYSTIMER),"系统用来通知光标跳动的一个消息",
        201     IDSTR(WM_MENUSELECT),"当用户选择一条菜单项时,发送本消息给菜单的所有者(一般是窗口)",
        202     IDSTR(WM_MENUCHAR),"当菜单已被激活且用户按下了某菜单字符键(菜单字符键用括号括着、带下划线,不同于快捷键),发送本消息给菜单的所有者",
        203     IDSTR(WM_ENTERIDLE),"当一个模态对话框或菜单进入空闲状态时,发送本消息给它的所有者,一个模态对话框或菜单进入空闲状态就是在处理完一条或几条先前的消息后,没有消息在消息列队中等待",
        204     IDSTR(WM_MENURBUTTONUP),"本消息允许程序为菜单项提供一个感知上下文的菜单(即快捷菜单),要为菜单项显示一下上下文菜单,请使用TPM_RECURSE标识调用TrackPopupMenuEx函数",
        205     IDSTR(WM_MENUDRAG),"当用户拖动菜单项时,发送本消息给拖放菜单的拥有者,可让菜单支持拖拽,可使用OLE拖放传输协议启动拖放操作,注:菜单要具有MNS_DRAGDROP风格",
        206     IDSTR(WM_MENUGETOBJECT),"当鼠标光标进入或离开菜单项时,本消息发送给支持拖放的菜单的拥有者,相关结构体:MENUGETOBJECTINFO,注:菜单要具有MNS_DRAGDROP风格",
        207     IDSTR(WM_UNINITMENUPOPUP),"当一条下拉菜单或子菜单被销毁时,发送本消息",
        208     IDSTR(WM_MENUCOMMAND),"当用户在一个菜单上作出选择时,会发送本消息,菜单要具有MNS_NOTIFYBYPOS风格(在MENUINFO结构体中设置)",
        209     IDSTR(WM_CTLCOLORMSGBOX),"系统绘制消息框前发送本消息给消息框的所有者窗口,通过响应本消息,所有者窗口可通过使用给定的相关显示设备的句柄来设置消息框的文本和背景色",
        210     IDSTR(WM_CTLCOLOREDIT),"当一个编辑框控件将要被绘制时,发送本消息给其父窗;通过响应本消息,所有者窗口可通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景色",
        211     IDSTR(WM_CTLCOLORLISTBOX),"当一个列表框控件将要被绘制前,发送本消息给其父窗;通过响应本消息,所有者窗口可通过使用给定的相关显示设备的句柄来设置列表框的文本和背景色",
        212     IDSTR(WM_CTLCOLORBTN),"息设置按钮的背景色",
        213     IDSTR(WM_CTLCOLORDLG),"设置对话框的背景色,通常是在WinnApp中使用SetDialogBkColor函数实现",
        214     IDSTR(WM_CTLCOLORSCROLLBAR),"设置滚动条的背景色",
        215     IDSTR(WM_CTLCOLORSTATIC),"设置一个静态控件的背景色",
        216     
        217     //组合框控件消息
        218     IDSTR(CB_GETEDITSEL),"用于取得组合框所包含编辑框子控件中当前被选中的字符串的起止位置,对应函数:GetEditSel",
        219     IDSTR(CB_LIMITTEXT),"用于限制组合框所包含编辑框子控件输入文本的长度",
        220     IDSTR(CB_SETEDITSEL),"用于选中组合框所包含编辑框子控件中的部分字符串,对应函数:GetEditSel",
        221     IDSTR(CB_ADDSTRING),"用于向组合框控件追加一个列表项(字符串)",
        222     IDSTR(CB_DELETESTRING),"用于删除组合框中指定的列表项(字符串)",
        223     IDSTR(CB_DIR),"用于向组合框控件所包含的列表框控件中添加一个文件名列表清单",
        224     IDSTR(CB_GETCOUNT),"用于返回组合框控件中列表项的总项数",
        225     IDSTR(CB_GETCURSEL),"用于返回当前被选择项的索引",
        226     IDSTR(CB_GETLBTEXT),"获取组合框控件中指定列表项的字符串",
        227     IDSTR(CB_GETLBTEXTLEN),"用于返回组合框控件中指定列表项的字符串的长度(不包括结束符0)",
        228     IDSTR(CB_INSERTSTRING),"在组合框控件所包含的列表框子控件中的指定位置插入字符串",
        229     IDSTR(CB_RESETCONTENT),"用于清除组合框控件所有列表项",
        230     IDSTR(CB_FINDSTRING),"在组合框控件中根据给定的字符串查找匹配字符串(忽略大小写)",
        231     IDSTR(CB_SELECTSTRING),"在组合框控件中设定与指定字符串相匹配的列表项为选中项",
        232     IDSTR(CB_SETCURSEL),"在组合框控件中设置指定的列表项为当前选择项",
        233     IDSTR(CB_SHOWDROPDOWN),"用于显示或关闭下拉式和下拉列表式组合框的列表框",
        234     IDSTR(CB_GETITEMDATA),"组合框控件每个列表项都有一个32位的附加数据,本消息用于返回指定列表项的附加数据",
        235     IDSTR(CB_SETITEMDATA),"用于更新组合框所包含的列表框所指定的列表项的32位附加数据",
        236     IDSTR(CB_GETDROPPEDCONTROLRECT),"用于取组合框中列表框的屏幕位置",
        237     IDSTR(CB_SETITEMHEIGHT),"指定组合框中列表项的显示高度(像素点)",
        238     IDSTR(CB_GETITEMHEIGHT),"用于返回指定列表项的高度(像素点)",
        239     IDSTR(CB_SETEXTENDEDUI),"指定下拉式或下拉列表式组合框是使用默认界面还是扩展界面",
        240     IDSTR(CB_GETEXTENDEDUI),"用于返回组合框是否存在扩展界面",
        241     IDSTR(CB_GETDROPPEDSTATE),"用于取组合框中列表框是否可见",
        242     IDSTR(CB_FINDSTRINGEXACT),"在组合框中查找字符串,忽略大小写,与CB_FINDSTRING不同,本消息必须整个字符串相同",
        243     IDSTR(CB_SETLOCALE),"设置组合框列表项当前用于排序的语言代码",
        244     IDSTR(CB_GETLOCALE),"获取组合框列表项当前用于排序的语言代码",
        245     IDSTR(CB_GETTOPINDEX),"获取组合框中列表框中第一个可见项的索引",
        246     IDSTR(CB_SETTOPINDEX),"用于将指定的组合框中列表项设置为列表框的第一个可见项",
        247     IDSTR(CB_GETHORIZONTALEXTENT),"用于返回组合框水平滚动的总宽度(像素点)(要具有水平滚动条)",
        248     IDSTR(CB_SETHORIZONTALEXTENT),"用于设定组合框中的列表框的宽度",
        249     IDSTR(CB_GETDROPPEDWIDTH),"取组合框中列表框的宽度(像素点)",
        250     IDSTR(CB_SETDROPPEDWIDTH),"用于设定组合框中的列表框的最大允许宽度",
        251     IDSTR(CB_INITSTORAGE),"只适用于Win95,当将要向组合框中列表框中加入大量表项时,本消息将预先分配一块内存,以免大量添加表项多次分配内存,从而加快程序运行速度",
        252     IDSTR(CB_MSGMAX),"该消息还具有三个消息值:0x0162,0x0163,0x0165,消息含义不明,搜索了整个Visual Studio 6的目录也只有其定义,却未见其使用的相关代码",
        253 
        254     //组合框控件通知消息
        255     IDSTR(CBN_CLOSEUP),"通知父窗(通过WM_COMMAND获知),组合框的列表框被关闭",
        256     IDSTR(CBN_DBLCLK),"通知父窗(通过WM_COMMAND获知),用户双击了组合框中的一个字符串",
        257     IDSTR(CBN_DROPDOWN),"通知父窗(通过WM_COMMAND获知),组合框的列表框被弹出",
        258     IDSTR(CBN_EDITCHANGE),"通知父窗(通过WM_COMMAND获知),用户修改了组合框所含编辑框中的文本",
        259     IDSTR(CBN_EDITUPDATE),"通知父窗(通过WM_COMMAND获知),组合框所含编辑框内的文本即将更新",
        260     IDSTR(CBN_ERRSPACE),"通知父窗(通过WM_COMMAND获知),组合框内存不足",
        261     IDSTR(CBN_KILLFOCUS),"通知父窗(通过WM_COMMAND获知),组合框失去输入焦点",
        262     IDSTR(CBN_SELCHANGE),"通知父窗(通过WM_COMMAND获知),选择了组合框中的一项",
        263     IDSTR(CBN_SELENDCANCEL),"通知父窗(通过WM_COMMAND获知),用户对组合框的选择应当被取消",
        264     IDSTR(CBN_SELENDOK),"通知父窗(通过WM_COMMAND获知),用户对组合框的选择是合法的",
        265     IDSTR(CBN_SETFOCUS),"通知父窗(通过WM_COMMAND获知),组合框获得输入焦点",
        266 
        267     //列表框控件消息
        268     IDSTR(LB_ADDSTRING),"向列表框中添加字符串",
        269     IDSTR(LB_INSERTSTRING),"向列表框中插入一个条目数据或字符串。不像LB_ADDSTRING消息,该消息不会激活LBS_SORT样式来对条目进行排序",
        270     IDSTR(LB_DELETESTRING),"删除列表框中的一个字符串",
        271     IDSTR(LB_SELITEMRANGEEX),"在多选状态下的列表框中选择一个或多个连续的条目",
        272     IDSTR(LB_RESETCONTENT),"清除列表框中所有列表项",
        273     IDSTR(LB_SETSEL),"在多选状态下的列表框中选择一个字符串",
        274     IDSTR(LB_SETCURSEL),"在列表框中选择一个字符串,并将其所在的条目滚动到视野内,并高亮新选中的字符串",
        275     IDSTR(LB_GETSEL),"获得列表框中一个条目的选择状态",
        276     IDSTR(LB_GETCURSEL),"获得列表框中当前被选条目的索引。仅在单选状态的列表框有效",
        277     IDSTR(LB_GETTEXT),"从列表框中获得一个字符串",
        278     IDSTR(LB_GETTEXTLEN),"获得一个列表框中字符串的长度",
        279     IDSTR(LB_GETCOUNT),"获得列表框中条目的数量",
        280     IDSTR(LB_SELECTSTRING),"仅适用于单选择列表框,设定与指定字符串相匹配的列表项为选中项,会滚动列表框以使选择项可见",
        281     IDSTR(LB_DIR),"在列表框中列出文件名",
        282     IDSTR(LB_GETTOPINDEX),"返回列表框中第一个可见项的索引",
        283     IDSTR(LB_FINDSTRING),"在列表框中查找匹配字符串(忽略大小写)",
        284     IDSTR(LB_GETSELCOUNT),"仅用于多重选择列表框,本消息用于返回选择项的数目",
        285     IDSTR(LB_GETSELITEMS),"仅用于多重选择列表框,本消息用于获得选中项的数目及位置",
        286     IDSTR(LB_SETTABSTOPS),"设置列表框的光标(输入焦点)站数及索引顺序表",
        287     IDSTR(LB_GETHORIZONTALEXTENT),"返回列表框的可滚动的宽度(像素点)",
        288     IDSTR(LB_SETHORIZONTALEXTENT),"本消息设置列表框的滚动宽度",
        289     IDSTR(LB_SETCOLUMNWIDTH),"为列表框指定列数",
        290     IDSTR(LB_ADDFILE),"为列表框增加文件名",
        291     IDSTR(LB_SETTOPINDEX),"用于列表框将中指定的列表项设置为列表框的第一个可见项,会将列表框滚动到合适的位置",
        292     IDSTR(LB_GETITEMRECT),"用于列表框中获得列表项的客户区的RECT",
        293     IDSTR(LB_GETITEMDATA),"列表框中每个列表项都有个32位附加数据,本消息用于返回指定列表项的附加数据",
        294     IDSTR(LB_SETITEMDATA),"用于更新列表框中指定列表项的32位附加数据",
        295     IDSTR(LB_SELITEMRANGE),"仅用于多重选择列表框,用来使指定范围内的列表项选中或落选",
        296     IDSTR(LB_SETANCHORINDEX),"用于列表框中设置鼠标最后选中的表项成指定表项",
        297     IDSTR(LB_GETANCHORINDEX),"用于列表框中鼠标最后选中的项的索引",
        298     IDSTR(LB_SETCARETINDEX),"用于列表框中设置键盘输入焦点到指定表项",
        299     IDSTR(LB_GETCARETINDEX),"用于列表框中返回具有矩形焦点的项目索引",
        300     IDSTR(LB_SETITEMHEIGHT),"用于列表框中指定列表项显示高度",
        301     IDSTR(LB_GETITEMHEIGHT),"用于列表框中返回列表框中某一项的高度(像素点)",
        302     IDSTR(LB_FINDSTRINGEXACT),"用于列表框中查找字符串(忽略大小写),与LB_FINDSTRING不同,本消息必须整个字符串相同",
        303     IDSTR(LB_SETLOCALE),"用于列表框中设置列表项当前用于排序的语言代码,当用户使用LB_ADDSTRING向组合框中的列表框中添加记录,并使用LBS_SORT风格进行重新排序时,必须使用该语言代码",
        304     IDSTR(LB_GETLOCALE),"用于列表框中获取列表项当前用于排序的语言代码,当用户使用LB_ADDSTRING向组合框中的列表框中添加记录,并使用LBS_SORT风格进行重新排序时,必须使用该语言代码",
        305     IDSTR(LB_SETCOUNT),"用于列表框中设置表项数目",
        306     IDSTR(LB_INITSTORAGE),"只适用于Win95版本,当将要向列表框中加入大量表项时,本消息将预先分配一块内存,以免在以后的操作中一次次分配内存",
        307     IDSTR(LB_ITEMFROMPOINT),"用于列表框中获得与指定点最近的项目索引",
        308     IDSTR(LB_MSGMAX),"该消息还具有三个消息值:0x01B0,0x01B1,0x01B3,,消息含义不明,搜索了整个Visual Studio 6的目录也只有其定义,却未见其使用的相关代码",
        309 
        310     //列表框控件通知消息
        311     IDSTR(LBN_DBLCLK),"通知父窗(通过WM_COMMAND获知),用户双击了列表框中的一项",
        312     IDSTR(LBN_ERRSPACE),"通知父窗(通过WM_COMMAND获知),列表框内存不够",
        313     IDSTR(LBN_KILLFOCUS),"通知父窗(通过WM_COMMAND获知),列表框正在失去输入焦点",
        314     IDSTR(LBN_SELCANCEL),"通知父窗(通过WM_COMMAND获知),选择被取消",
        315     IDSTR(LBN_SELCHANGE),"通知父窗(通过WM_COMMAND获知),选择了列表框中的另一项",
        316     IDSTR(LBN_SETFOCUS),"通知父窗(通过WM_COMMAND获知),列表框获得输入焦点",
        317 
        318     IDSTR(WM_MOUSEFIRST),"鼠标移动时发生(与WM_MOUSEMOVE等值),常用于判断鼠标消息的范围,比如:if(message >= WM_MOUSEFIRST)&&(message <= WM_MOUSELAST)",
        319     IDSTR(WM_MOUSEMOVE),"移动鼠标",
        320     IDSTR(WM_LBUTTONDOWN),"按下鼠标左键",
        321     IDSTR(WM_LBUTTONUP),"释放鼠标左键",
        322     IDSTR(WM_LBUTTONDBLCLK),"双击鼠标左键",
        323     IDSTR(WM_RBUTTONDOWN),"按下鼠标右键",
        324     IDSTR(WM_RBUTTONUP),"释放鼠标右键",
        325     IDSTR(WM_RBUTTONDBLCLK),"双击鼠标右键",
        326     IDSTR(WM_MBUTTONDOWN),"按下鼠标中键",
        327     IDSTR(WM_MBUTTONUP),"释放鼠标中键",
        328     IDSTR(WM_MBUTTONDBLCLK),"双击鼠标中键",
        329     IDSTR(WM_MOUSEWHEEL),"当鼠标轮子转动时,发送本消息给当前拥有焦点的控件",
        330     IDSTR(WM_MOUSELAST),"WM_MBUTTONDBLCLK的别名,通常用于判断鼠标消息的范围,对应的还有WM_MOUSEFIRST,例如:if(message > =  WM_MOUSEFIRST)&&(message <= WM_MOUSELAST)",
        331     IDSTR(WM_PARENTNOTIFY),"当MDI子窗口被创建或被销毁,或用户按了一下鼠标键而光标在子窗口上时,发送本消息给其父窗",
        332     IDSTR(WM_ENTERMENULOOP),"发送本消息通知应用程序的主窗口已进入菜单循环模式",
        333     IDSTR(WM_EXITMENULOOP),"发送本消息通知应用程序的主窗口已退出菜单循环模式",
        334     IDSTR(WM_NEXTMENU),"当使用左箭头光标键或右箭头光标键在菜单条与系统菜单之间切换时,会发送本消息给应用程序,相关结构体:MDINEXTMENU",
        335     IDSTR(WM_SIZING),"当用户正在调整窗口大小时,发送本消息给窗口;通过本消息应用程序可监视窗口大小和位置,也可修改它们",
        336     IDSTR(WM_CAPTURECHANGED),"当它失去捕获的鼠标时,发送本消息给窗口",
        337     IDSTR(WM_MOVING),"当用户在移动窗口时发送本消息,通过本消息应用程序以监视窗口大小和位置,也可修改它们",
        338     IDSTR(WM_POWERBROADCAST),"本消息发送给应用程序来通知它有关电源管理事件,比如待机休眠时会发送本消息",
        339     IDSTR(WM_DEVICECHANGE),"当设备的硬件配置改变时,发送本消息给应用程序或设备驱动程序",
        340     IDSTR(WM_MDICREATE),"发送本消息给多文档应用程序的客户窗口来创建一个MDI子窗口",
        341     IDSTR(WM_MDIDESTROY),"发送本消息给多文档应用程序的客户窗口来关闭一个MDI子窗口",
        342     IDSTR(WM_MDIACTIVATE),"发送本消息给多文档应用程序的客户窗口通知客户窗口激活另一个MDI子窗口,当客户窗口收到本消息后,它发出WM_MDIACTIVE消息给MDI子窗口(未激活)来激活它",
        343     IDSTR(WM_MDIRESTORE),"发送本消息给MDI客户窗口,让子窗口从最大最小化恢复到原来的大小",
        344     IDSTR(WM_MDINEXT),"发送本消息给MDI客户窗口,激活下一个或前一个窗口",
        345     IDSTR(WM_MDIMAXIMIZE),"发送本消息给MDI客户窗口来最大化一个MDI子窗口",
        346     IDSTR(WM_MDITILE),"发送本消息给MDI客户窗口,以平铺方式重新排列所有MDI子窗口",
        347     IDSTR(WM_MDICASCADE),"发送本消息给MDI客户窗口,以层叠方式重新排列所有MDI子窗口",
        348     IDSTR(WM_MDIICONARRANGE),"发送本消息给MDI客户窗口重新排列所有最小化的MDI子窗口",
        349     IDSTR(WM_MDIGETACTIVE),"发送本消息给MDI客户窗口以找到激活的子窗口句柄",
        350     IDSTR(WM_MDISETMENU),"发送本消息给MDI客户窗口,用MDI菜单代替子窗口的菜单",
        351     IDSTR(WM_ENTERSIZEMOVE),"当某窗口进入移动或调整大小的模式循环时,本消息发送到该窗口",
        352     IDSTR(WM_EXITSIZEMOVE),"确定用户改变窗口大小或改变窗口位置的事件是何时完成的",
        353     IDSTR(WM_DROPFILES),"鼠标拖放时,放下事件产生时发送本消息,比如:文件拖放功能",
        354     IDSTR(WM_MDIREFRESHMENU),"发送本消息给多文档应用程序的客户窗口,根据当前MDI子窗口更新MDI框架窗口的菜单",
        355     //0x0235
        356     //......
        357     //0x0280
        358     IDSTR(WM_IME_SETCONTEXT),"应用程序的窗口激活时,系统将向应用程序发送WM_IME_SETCONTEXT消息,注:输入法相关",
        359     IDSTR(WM_IME_NOTIFY),"可使用WM_IME_NOTIFY消息来通知关于IME窗口状态的常规改变,注:输入法相关",
        360     IDSTR(WM_IME_CONTROL),"可使用WM_IME_CONTROL消息来改变字母组合窗口的位置,注:输入法相关",
        361     IDSTR(WM_IME_COMPOSITIONFULL),"用户接口窗口不能增加编码窗口的尺寸时,IME用户接口窗口将发送WM_IME_COMPOSITIONFULL消息,可不处理,注:输入法相关",
        362     IDSTR(WM_IME_SELECT),"系统发出WM_IME_SELECT以便选择一个新的IME输入法,注:输入法相关",
        363     IDSTR(WM_IME_CHAR),"当打开输入法输入文字时,会发送WM_IME_CHAR消息",
        364     IDSTR(WM_IME_REQUEST),"应用程序请求输入法时,触发发送本消息",
        365     IDSTR(WM_IME_KEYDOWN),"在输入法录字窗口中按下按键时,触发发送本消息",
        366     IDSTR(WM_IME_KEYUP),"在输入法录字窗口中释放按键时,触发发送本消息",
        367     IDSTR(WM_MOUSEHOVER),"鼠标移过控件时,触发发送本消息",
        368     IDSTR(WM_MOUSELEAVE),"鼠标离开控件时,触发发送本消息",
        369     IDSTR(WM_CUT),"应用程序发送本消息给一个编辑框或组合框来删除当前选择的文本",
        370     IDSTR(WM_COPY),"应用程序发送本消息给一个编辑框或组合框,以便用CF_TEXT格式复制当前选择的文本到剪贴板",
        371     IDSTR(WM_PASTE),"应用程序发送本消息给编辑框或组合框,以便从剪贴板中得到数据",
        372     IDSTR(WM_CLEAR),"应用程序发送本消息给编辑框或组合框,以清除当前选择的内容",
        373     IDSTR(WM_UNDO),"应用程序发送本消息给编辑框或组合框,以撤消最后一次操作",
        374     IDSTR(WM_RENDERFORMAT),"应用程序需要系统剪切板数据时,触发发送本消息",
        375     IDSTR(WM_RENDERALLFORMATS),"应用程序退出时在程序退出时,系统会给当前程序发送该消息,要求提供所有格式的剪帖板数据,避免造成数据丢失",
        376     IDSTR(WM_DESTROYCLIPBOARD),"当调用EmptyClipboard函数时,发送本消息给剪贴板的所有者",
        377     IDSTR(WM_DRAWCLIPBOARD),"当剪贴板的内容变化时,发送本消息给剪贴板观察链的首个窗口;它允许用剪贴板观察窗口来显示剪贴板的新内容",
        378     IDSTR(WM_PAINTCLIPBOARD),"当剪贴板包含CF_OWNERDIPLAY格式的数据,并且剪贴板观察窗口的客户区需要重画时,触发发送本消息",
        379     IDSTR(WM_VSCROLLCLIPBOARD),"当剪贴板查看器的垂直滚动条被单击时,触发发送本消息",
        380     IDSTR(WM_SIZECLIPBOARD),"当剪贴板包含CF_OWNERDIPLAY格式的数据,并且剪贴板观察窗口的客户区域的大小已改变时,本消息通过剪贴板观察窗口发送给剪贴板的所有者",
        381     IDSTR(WM_ASKCBFORMATNAME),"通过剪贴板观察窗口发送本消息给剪贴板的所有者,以请求一个CF_OWNERDISPLAY格式的剪贴板的名字",
        382     IDSTR(WM_CHANGECBCHAIN),"当一个窗口从剪贴板观察链中移去时,发送本消息给剪贴板观察链的首个窗口",
        383     IDSTR(WM_HSCROLLCLIPBOARD),"本消息通过一个剪贴板观察窗口发送给剪贴板的所有者,它发生在当剪贴板包含CFOWNERDISPALY格式的数据,并且有个事件在剪贴板观察窗的水平滚动条上,所有者应滚动剪贴板图像并更新滚动条的值",
        384     IDSTR(WM_QUERYNEWPALETTE),"本消息发送给将要收到焦点的窗口,本消息能使窗口在收到焦点时同时有机会实现逻辑调色板",
        385     IDSTR(WM_PALETTEISCHANGING),"当一个应用程序正要实现它的逻辑调色板时,发本消息通知所有的应用程序",
        386     IDSTR(WM_PALETTECHANGED),"本消息在一个拥有焦点的窗口实现它的逻辑调色板后,发送本消息给所有顶级并重叠的窗口,以此来改变系统调色板",
        387     IDSTR(WM_HOTKEY),"当用户按下由RegisterHotKey函数注册的热键时,发送本消息",
        388     IDSTR(WM_PRINT),"发送本消息给一个窗口请求在指定的设备上下文中绘制自身,可用于窗口截图,但对子控件截图时得到的是与子控件等大的黑块",
        389     IDSTR(WM_PRINTCLIENT),"送本消息给一个窗口请求在指定的设备上下文中绘制其客户区(最通常是在一个打印机设备上下文中)",
        390     IDSTR(WM_HANDHELDFIRST),"消息含义未知,搜索了整个Visual Studio 6的目录也只有其定义,却未见其使用的相关代码",
        391     IDSTR(WM_HANDHELDLAST),"消息含义未知,搜索了整个Visual Studio 6的目录也只有其定义,却未见其使用的相关代码",
        392     IDSTR(WM_AFXFIRST),"指定首个AFX消息(MFC)",
        393     IDSTR(WM_QUERYAFXWNDPROC),"该消息被MFC内部用来确认窗口过程是否使用AfxWndProc",
        394     IDSTR(WM_SIZEPARENT),"MFC自定义的消息,MFC的主窗口框架布局是通过给子窗口发送响应WM_SIZEPARENT来完成的,框架窗口发送本消息用的是SendMessage,各个控制子窗口用OnSizeParent响应WM_SIZEPARENT消息",
        395     IDSTR(WM_IDLEUPDATECMDUI),"MFC自己定义和使用的消息,当应用程序进入空闲处理状态时,将发送本消息,导致所有工具栏用户对象的状态处理函数被调用,从而改变其状态,对应的消息响应函数为:OnIdleUpdateCmdUI",
        396     IDSTR(WM_INITIALUPDATE),"MFC发明的消息,用于处理菜单、快捷键,发送WM_INITIALUPDATE消息给所有子窗口,消息响应函数为:CView::OnInitialUpdate",
        397     IDSTR(WM_COMMANDHELP),"本消息用于实现MFC的上下文敏感帮助,按下<F1键>后消息被映射到CWinApp::OnHelp。该函数会向最外层框架窗口发送本消息,本消息响应过程是自顶向下的,对应的消息响应函数为:ON_WM_HELPINFO",
        398     IDSTR(WM_HELPHITTEST),"本消息用于实现MFC的上下文敏感帮助,本消息必须手工添加",
        399     IDSTR(WM_EXITHELPMODE),"本消息用于实现MFC的上下文敏感帮助,本消息必须手工添加",
        400     IDSTR(WM_RECALCPARENT),"MFC自己定义和使用的消息,对应的消息响应函数为:CMainFrame::OnReCalcParent,本消息由CView发送给CMainFrame框架窗口以便重新布置窗口",
        401     IDSTR(WM_SIZECHILD),"MFC自己定义和使用的消息,当用户重新调整COleResizeBar的大小时,由COleResizeBar发送给其所有者窗口),",
        402     IDSTR(WM_KICKIDLE),"本消息是MFC中对空闲进行处理的一个未公开的消息,消息泵并不处理WM_KICKIDLE消息,收到该消息后,直接返回,WM_KICKIDLE被用来刺激空闲处理的执行,它作为一个空消息促使::GetMessage()返回",
        403     IDSTR(WM_QUERYCENTERWND),"MFC内部保留的未公开消息,lParam:HWND to use as centering parent;",
        404     IDSTR(WM_DISABLEMODAL),"MFC内部保留的未公开消息,lResult = 0,disable during modal state;lResult = 1,don't disable",
        405     IDSTR(WM_FLOATSTATUS),"MFC内部保留的未公开消息,wParam combination of FS_* flags below",
        406     IDSTR(WM_ACTIVATETOPLEVEL),"MFC内部保留的未公开消息,wParam = nState(like WM_ACTIVATE);lParam = pointer to HWND[2];lParam[0] = hWnd getting WM_ACTIVATE;lParam[1] = hWndOther",
        407     IDSTR(WM_QUERY3DCONTROLS),"MFC内部保留的未公开消息,lResult != 0 if 3D controls wanted",
        408     IDSTR(WM_RESERVED_0370),"MFC内部保留的未公开、MFC自身也未使用的消息",
        409     IDSTR(WM_RESERVED_0371),"MFC内部保留的未公开、MFC自己也未使用的消息",
        410     IDSTR(WM_RESERVED_0372),"MFC内部保留的未公开、MFC自己也未使用的消息",
        411     IDSTR(WM_SOCKET_NOTIFY),"已在MSDN中公开的MFC内部消息,本消息告诉socket窗口socket事件已经发生(socket窗口:CSocketWnd,隐藏,接收本消息,响应:OnSocketNotify)),",
        412     IDSTR(WM_SOCKET_DEAD),"MFC内部消息,MFC维护死套接字的映射,死套接字是个已关闭的套接字,参见sockcore.cpp",
        413     IDSTR(WM_SETMESSAGESTRING),"MFC内部消息,发送给框架窗口要求其更新状态栏字符串信息,微软MFC TN024文档中有该消息的描述,响应函数:OnSetMessageString",
        414     IDSTR(WM_POPMESSAGESTRING),"MFC内部消息,用来重新设置状态栏,对应的字符串是\"Ready\",响应函数:OnPopMessageString",
        415     IDSTR(WM_HELPPROMPTADDR),"MFC内部消息,用来从相关联的框架窗口中检索m_dwPromptContext地址,注:<F1>上下文帮助相关",
        416     IDSTR(WM_OCC_LOADFROMSTREAM),"MFC内部消息,OCC即OLE control containers,参见相关LoadFromStream函数",
        417     IDSTR(WM_OCC_LOADFROMSTORAGE),"MFC内部消息,OCC即OLE control container,参见相关LoadFromStorage函数",
        418     IDSTR(WM_OCC_INITNEW),"MFC内部消息,OCC即OLE control container,参见相关InitNew函数",
        419     IDSTR(WM_OCC_LOADFROMSTREAM_EX),"MFC内部消息,OCC即OLE control container,参见相关LoadFromStreamEx函数",
        420     IDSTR(WM_OCC_LOADFROMSTORAGE_EX),"MFC内部消息,OCC即OLE control container,参见:ATLHOST.H/OCCMGR.CPP/WINCORE.CPP中相关代码",
        421     IDSTR(WM_QUEUE_SENTINEL),"MFC内部消息,用于重排消息队列,\"QUEUE SENTINEL\"意为消息哨兵",
        422     IDSTR(WM_RESERVED_037C),"MFC内部保留,供将来使用",
        423     IDSTR(WM_RESERVED_037D),"MFC内部保留,供将来使用",
        424     IDSTR(WM_RESERVED_037E),"MFC内部保留,供将来使用",
        425     IDSTR(WM_FORWARDMSG),"ATL中定义,让一个窗口接收的消息传递给另一个窗口进行处理",
        426     IDSTR(WM_AFXLAST),"指定末个afx消息",
        427     IDSTR(WM_PENWINFIRST),"指定首个Pen Window消息,参见:PENWIN.H/WINUSER.H",
        428     IDSTR(WM_PENWINLAST),"指定末个Pen Window消息,参见:PENWIN.H/WINUSER.H",
        429     
        430     //DDE消息(Dde.h)
        431     IDSTR(WM_DDE_FIRST),"指定首个DDE消息,其它的DDE消息以WM_DDE_FIRST + X的形式定义,如:WM_DDE_TERMINATE定义为:WM_DDE_FIRST+1",
        432     IDSTR(WM_DDE_INITIATE),"一个DDE客户程序提交本消息,以便开始一个与服务程序的会话来响应那个指定的程序和主题名",
        433     IDSTR(WM_DDE_TERMINATE),"一个DDE应用程序(无论是客户还是服务器)提交本消息以终止一个会话",
        434     IDSTR(WM_DDE_ADVISE),"一个DDE客户程序提交本消息给一个DDE服务程序,以便请求服务器每当数据项改变时更新它",
        435     IDSTR(WM_DDE_UNADVISE),"一个DDE客户程序通过本消息来通知一个DDE服务程序不要更新指定的项或一个特殊的剪贴板格式的项",
        436     IDSTR(WM_DDE_ACK),"本消息通知一个DDE程序已收到并正在处理WM_DDE_POKE,WM_DDE_EXECUTE,WM_DDE_DATA,WM_DDE_ADVISE,WM_DDE_UNADVISE或WM_DDE_INITIAT消息",
        437     IDSTR(WM_DDE_DATA),"一个DDE服务程序提交本消息给DDE客户程序,以便传递一个数据项给客户或通知客户的一条可用数据项",
        438     IDSTR(WM_DDE_REQUEST),"一个DDE客户程序提交本消息给一个DDE服务程序来请求一个数据项的值",
        439     IDSTR(WM_DDE_POKE),"一个DDE客户程序提交本消息给一个DDE服务程序,客户使用本消息来请求服务器接收一个未经同意的数据项;服务器通过答复WM_DDE_ACK消息提示是否它接收这个数据项",
        440     IDSTR(WM_DDE_EXECUTE),"一个DDE客户程序提交本消息给一个DDE服务程序,以便发送一个字符串给服务器,让它像串行命令一样被处理,服务器通过提交WM_DDE_ACK消息来作回应",
        441     IDSTR(WM_DDE_LAST),"指定末个DDE消息,与WM_DDE_EXECUTE消息等值",
        442 
        443     IDSTR(WM_HIBERNATE),"Windows CE内存不足时,系统会发送本消息给应用程序,从而使其处于非活动状态,直到有足够资源可用,是WINCE独有的消息",
        444     
        445     IDSTR(WM_APP),"用于帮助应用程序自定义私有消息,通常形式为:WM_APP + X",
        446     IDSTR(WM_USER),"用于帮助应用程序自定义私有消息,通常形式为:WM_USER + X",
        447   
        448     //工具提示控件消息
        449     IDSTR(TTM_ACTIVATE),"动态停用和启用工具提示控件,TTM即为ToolTip Message",
        450     IDSTR(TTM_SETDELAYTIME),"使用本消息可指定工具提示控件显示提示文本时的时间延迟(持续时间)(毫秒)",
        451     IDSTR(TTM_ADDTOOLA),"为某窗口注册添加工具提示控件,相关结构体:TOOLINFO",
        452     IDSTR(TTM_ADDTOOLW),"为某窗口注册添加工具提示控件,相关结构体:TOOLINFO",
        453     IDSTR(TTM_DELTOOLA),"为某窗口去除工具提示控件,相关结构体:TOOLINFO",
        454     IDSTR(TTM_DELTOOLW),"为某窗口去除工具提示控件,相关结构体:TOOLINFO",
        455     IDSTR(TTM_NEWTOOLRECTA),"为某窗口设置工具提示控件的矩形大小(rect)",
        456     IDSTR(TTM_NEWTOOLRECTW),"为某窗口设置工具提示控件的矩形大小(rect)",
        457     IDSTR(TTM_RELAYEVENT),"用于把鼠标消息传递给一个工具提示控件,让其进行处理",
        458     IDSTR(TTM_GETTOOLINFOA),"从工具提示控件中获取TOOLINFO结构体",
        459     IDSTR(TTM_GETTOOLINFOW),"从工具提示控件中获取TOOLINFO结构体",
        460     IDSTR(TTM_SETTOOLINFOA),"用于向工具提示控件中设置TOOLINFO结构体",
        461     IDSTR(TTM_SETTOOLINFOW),"用于向工具提示控件中设置TOOLINFO结构体",
        462     IDSTR(TTM_HITTESTA),"获取工具提示控件是否受到点击的信息,即测试鼠标坐标点是否在工具提示控件绑定的矩形内点击",
        463     IDSTR(TTM_HITTESTW),"获取工具提示控件是否受到点击的信息,即测试鼠标坐标点是否在工具提示控件绑定的矩形内点击",
        464     IDSTR(TTM_GETTEXTA),"从工具提示控件中获取文本数据",
        465     IDSTR(TTM_GETTEXTW),"从工具提示控件中获取文本数据",
        466     IDSTR(TTM_UPDATETIPTEXTA),"用于对工具提示控件进行文本设置",
        467     IDSTR(TTM_UPDATETIPTEXTW),"用于对工具提示控件进行文本设置",
        468     IDSTR(TTM_GETTOOLCOUNT),"获取被工具提示控件所维护的工具的数量",
        469     IDSTR(TTM_ENUMTOOLSA),"获取当前是哪个工具提示控件在显示文本",
        470     IDSTR(TTM_ENUMTOOLSW),"获取当前是哪个工具提示控件在显示文本",
        471     IDSTR(TTM_GETCURRENTTOOLA),"获取工具提示控件中当前工具的信息",
        472     IDSTR(TTM_GETCURRENTTOOLW),"获取工具提示控件中当前工具的信息",
        473     IDSTR(TTM_WINDOWFROMPOINT),"用于子类化一个窗口过程,使之能让工具提示控件为鼠标下的窗口显示工具提示文本",
        474     IDSTR(TTM_TRACKACTIVATE),"获取工具提示控件中当前工具的信息",
        475     IDSTR(TTM_TRACKPOSITION),"设置跟踪工具提示控件的坐标",
        476     IDSTR(TTM_SETTIPBKCOLOR),"设置工具提示控件的窗口背景色",
        477     IDSTR(TTM_SETTIPTEXTCOLOR),"设置工具提示控件的文本前景色",
        478     IDSTR(TTM_GETDELAYTIME),"使用本消息可获以工具提示控件显示提示文本时的时间延迟(持续时间)(毫秒)",
        479     IDSTR(TTM_GETTIPBKCOLOR),"获取工具提示控件的窗口背景色",
        480     IDSTR(TTM_GETTIPTEXTCOLOR),"获取工具提示控件的文本前景色",
        481     IDSTR(TTM_SETMAXTIPWIDTH),"设置工具提示控件窗口的最大宽度(像素点)",
        482     IDSTR(TTM_GETMAXTIPWIDTH),"获取工具提示控件窗口的最大宽度(像素点)",
        483     IDSTR(TTM_SETMARGIN),"设置工具提示控件窗口的四周边空(像素点)",
        484     IDSTR(TTM_GETMARGIN),"获取工具提示控件窗口的四周边空(像素点)",
        485     IDSTR(TTM_POP),"从一个视图中去除已显示的工具提示控件",
        486     IDSTR(TTM_UPDATE),"强制工具提示控件重绘其窗口",
        487     
        488     //Rich Edit控件消息(带格式编辑控件)
        489     IDSTR(EM_AUTOURLDETECT),"设置Rich Edit控件是否自动检测URL,若设置成自动检测URL,则输入的URL被加亮显示成蓝色",
        490     IDSTR(EM_CANPASTE),"可用于确定Rich Edit控件是否能以指定的剪贴板格式进行粘贴",
        491     IDSTR(EM_CANREDO),"判断在Rich Edit控件的Redo队列中是否有一些动作",
        492     IDSTR(EM_DISPLAYBAND),"将Rich Edit控件的输出发送至设备,通过反复使用EM_FORMATRANGE和EM_DISPLAYBAND消息,打印该控件内容的应用程序可实现条带化操作(将输出分割为较小部分用于打印)",
        493     IDSTR(EM_EXGETSEL),"确定Rich Edit控件中的当前选中内容",
        494     IDSTR(EM_EXLIMITTEXT),"Rich Edit控件包含的文本不能超过32K,但可使用本消息进行扩展,以突破这个限制",
        495     IDSTR(EM_EXLINEFROMCHAR),"判断给定字符属于Rich Edit控件的哪一行",
        496     IDSTR(EM_EXSETSEL),"设置Rich Edit控件的当前选择区域",
        497     IDSTR(EM_FINDTEXT),"搜索Rich Edit控件中的正文可通过发送EM_FINDTEXT或EM_FINDTEXTEX消息来完成",
        498     IDSTR(EM_FINDTEXTEX),"搜索Rich Edit控件中的正文可通过发送EM_FINDTEXT或EM_FINDTEXTEX消息来完成",
        499     IDSTR(EM_FINDWORDBREAK),"可在Rich Edit控件中查找断字符或确定一个字符类和断字标志位",
        500     IDSTR(EM_FORMATRANGE),"对于特定设备而言,要格式化Rich Edit控件中部分内容,可使用本消息,在输出设备文本格式化完成后,可使用EM_DISPLAYBAND消息将输出发送至设备(如:打印)",
        501     IDSTR(EM_GETCHARFORMAT),"获取Rich Edit控件中当前选中文本的字符格式属性",
        502     IDSTR(EM_GETEVENTMASK),"获取当前Rich Edit控件的事件掩码",
        503     IDSTR(EM_GETIMECOLOR),"在Rich Edit控件中获取IME组件的颜色,仅亚洲语言版本的操作系统有效",
        504     IDSTR(EM_GETIMECOMPMODE),"获取Rich Edit控件当前输入方式编辑(IME)模式",
        505     IDSTR(EM_GETIMEOPTIONS),"在Rich Edit控件中获取IME组件的选项,仅亚洲语言版本的操作系统有效",
        506     IDSTR(EM_GETLANGOPTIONS),"获取Rich Edit控件的IME和远东语言支持选项",
        507     IDSTR(EM_GETOLEINTERFACE),"Rich Edit控件支持由OLE所定义的客户端的支持,客户端可使用本消息从Rich Edit控件获取一个IRichEditOle接口,该接口允许它控制OLE对象",
        508     IDSTR(EM_GETOPTIONS),"获取Rich Edit控件的选项,仅亚洲语言版本的操作系统有效",
        509     IDSTR(EM_GETPARAFORMAT),"获取Rich Edit控件中当前选中文本的段落格式属性",
        510     IDSTR(EM_GETPUNCTUATION),"获取Rich Edit控件的当前标点字符),",
        511     IDSTR(EM_GETREDONAME),"获取Rich Edit控件的Redo队列中的下一动作的类型名称",
        512     IDSTR(EM_GETSELTEXT),"获取Rich Edit控件中的选中文本",
        513     IDSTR(EM_GETTEXTMODE),"获取Rich Edit控件的文本模式或Undo级别",
        514     IDSTR(EM_GETTEXTRANGE),"获取Rich Edit控件中给定范围的文本",
        515     IDSTR(EM_GETUNDONAME),"获取Rich Edit控件的Undo队列中的下一动作的类型名称",
        516     IDSTR(EM_GETWORDBREAKPROCEX),"获取Rich Edit控件的当前扩展断字处理过程的地址",
        517     IDSTR(EM_GETWORDWRAPMODE),"获取Rich Edit控件的当前自动换行与断字符选项",
        518     IDSTR(EM_HIDESELECTION),"可通过本消息在任何时候开启或隐藏Rich Edit控件中的选中区域的高亮显示",
        519     IDSTR(EM_PASTESPECIAL),"粘贴指定的剪贴板格式,本消息对具有\"特殊粘贴\"命令的应用程序很有用,该命令可让用户选择剪贴板格式",
        520     IDSTR(EM_REDO),"重做Rich Edit控件Redo队列中的下一动作",
        521     IDSTR(EM_REQUESTRESIZE),"强制一个无底Rich Edit控件发送EN_REQUESTRESIZE通知,该消息在处理WM_SIZE消息时很有用",
        522     IDSTR(EM_SELECTIONTYPE),"获取Rich Edit控件中当前选中内容的相关信息",
        523     IDSTR(EM_SETBKGNDCOLOR),"设置Rich Edit控件的背景色",
        524     IDSTR(EM_SETCHARFORMAT),"设置Rich Edit控件的字符格式",
        525     IDSTR(EM_SETEVENTMASK),"设置Rich Edit控件的事件掩码",
        526     IDSTR(EM_SETIMECOLOR),"在Rich Edit控件中设置IME组件的颜色,仅亚洲语言版本的操作系统有效",
        527     IDSTR(EM_SETIMEOPTIONS),"在Rich Edit控件中设置IME组件的选项,仅亚洲语言版本的操作系统有效",
        528     IDSTR(EM_SETLANGOPTIONS),"设置Rich Edit控件的IME和远东语言支持选项",
        529     IDSTR(EM_SETOLECALLBACK),"Rich Edit控件支持由OLE所定义的客户端的支持,客户端使用EM_SETOLECALLBACK消息注册一个IRichEditOleCallback接口,控件将使用它获取所需接口和存储",
        530     IDSTR(EM_SETOPTIONS),"设置Rich Edit控件的选项",
        531     IDSTR(EM_SETPARAFORMAT),"设置Rich Edit控件的段落格式",
        532     IDSTR(EM_SETPUNCTUATION),"设置Rich Edit控件的标点字符",
        533     IDSTR(EM_SETTARGETDEVICE),"指定一个用于Rich Edit控件的文本格式化的目标设备",
        534     IDSTR(EM_SETTEXTMODE),"设置Rich Edit控件的文本模式或Undo级别",
        535     IDSTR(EM_SETUNDOLIMIT),"设置Rich Edit控件的Undo队列的最大动作数目",
        536     IDSTR(EM_SETWORDBREAKPROCEX),"替换Rich Edit控件默认的扩展断字处理过程",
        537     IDSTR(EM_SETWORDWRAPMODE),"设置Rich Edit控件的自动换行与断字符选项",
        538     IDSTR(EM_STOPGROUPTYPING),"终止Rich Edit控件的当前Undo动作的连续键入动作的组合",
        539     IDSTR(EM_STREAMIN),"将数据读入Rich Edit控件(或说数据传入)",
        540     IDSTR(EM_STREAMOUT),"保存Rich Edit控件内容(或说数据传出)",
        541     
        542     //Listview控件消息
        543     IDSTR(LVM_FIRST),"指定Listview控件的首个消息,其它相关消息用LVM_FIRST + X的形式定义,比如:LVM_GETBKCOLOR为LVM_FIRST + 0",
        544     IDSTR(LVM_GETBKCOLOR),"获取Listview控件的背景色,宏:ListView_GetBkColor",
        545     IDSTR(LVM_SETBKCOLOR),"设置Listview控件的背景色,宏:ListView_SetBkColor",
        546     IDSTR(LVM_GETIMAGELIST),"获取Listview控件的图片列表句柄,宏:ListView_GetImageList",
        547     IDSTR(LVM_SETIMAGELIST),"设置Listview控件的图片列表,宏:ListView_SetImageList",
        548     IDSTR(LVM_GETITEMCOUNT),"获取Listview控件的项目总数,宏:ListView_GetItemCount",
        549     IDSTR(LVM_GETITEMA),"获取Listview控件的项目,宏:ListView_GetItem",
        550     IDSTR(LVM_GETITEMW),"获取Listview控件的项目,宏:ListView_GetItem",
        551     IDSTR(LVM_SETITEMA),"设置Listview控件的项目,宏:ListView_SetItem",
        552     IDSTR(LVM_SETITEMW),"设置Listview控件的项目,宏:ListView_SetItem ",
        553     IDSTR(LVM_INSERTITEMA),"向Listview控件插入项目,宏:ListView_InsertItem",
        554     IDSTR(LVM_INSERTITEMW),"向Listview控件插入项目,宏:ListView_InsertItem",
        555     IDSTR(LVM_DELETEITEM),"用于删除Listview控件中的一行项目,宏:ListView_DeleteItem",
        556     IDSTR(LVM_DELETEALLITEMS),"清空Listview控件所有项目,宏:ListView_DeleteAllItems",
        557     IDSTR(LVM_GETCALLBACKMASK),"获取Listview控件的回调掩码,宏:ListView_GetCallbackMask",
        558     IDSTR(LVM_SETCALLBACKMASK),"设置Listview控件的回调掩码,宏:ListView_SetCallbackMask",
        559     IDSTR(LVM_GETNEXTITEM),"获取Listview控件中的下一个项目,宏:ListView_GetNextItem",
        560     IDSTR(LVM_FINDITEMA),"在Listview控件中寻找项目,宏:ListView_FindItem",
        561     IDSTR(LVM_FINDITEMW),"在Listview控件中寻找项目,宏:ListView_FindItem",
        562     IDSTR(LVM_GETITEMRECT),"在Listview控件中获取指定项目的矩形范围,宏:ListView_GetItemRect",
        563     IDSTR(LVM_SETITEMPOSITION),"设置Listview控件的项目位置,宏:ListView_SetItemPosition",
        564     IDSTR(LVM_GETITEMPOSITION),"获取Listview控件的项目位置,宏:ListView_GetItemPosition",
        565     IDSTR(LVM_GETSTRINGWIDTHA),"在Listview控件中获取显示一个文本所需列宽,宏:ListView_GetStringWidth",
        566     IDSTR(LVM_GETSTRINGWIDTHW),"在Listview控件中获取显示一个文本所需列,宏:ListView_GetStringWidth",
        567     IDSTR(LVM_HITTEST),"在Listview控件中进行点击测试,判断某个鼠标坐标点是否落在Listview控件某个项目中,宏:ListView_HitTest",
        568     IDSTR(LVM_ENSUREVISIBLE),"Listview控件的某个项目保证能显示出来(可视),并决定一个项目的全部或部份是否可视,宏:ListView_EnsureVisible",
        569     IDSTR(LVM_SCROLL),"在Listview控件中移动滚动条,宏:ListView_Scroll",
        570     IDSTR(LVM_REDRAWITEMS),"在Listview控件中重绘项目,宏:ListView_RedrawItems",
        571     IDSTR(LVM_ARRANGE),"在Listview控件中图像显示时,排列项目,宏:ListView_Arrange",
        572     IDSTR(LVM_EDITLABELA),"编辑Listview控件中指定项目的文本(即label标签),宏:ListView_EditLabel",
        573     IDSTR(LVM_EDITLABELW),"编辑Listview控件中指定项目的文本(即label标签),宏:ListView_EditLabel",
        574     IDSTR(LVM_GETEDITCONTROL),"在Listview控件中,当列表控件正在进行编辑时,返回该编辑框的句柄,宏:ListView_GetEditControl",
        575     IDSTR(LVM_GETCOLUMNA),"获取Listview控件中某列的属性,宏:ListView_GetColumn",
        576     IDSTR(LVM_GETCOLUMNW),"获取Listview控件中某列的属性,宏:ListView_GetColumn",
        577     IDSTR(LVM_SETCOLUMNA),"设置Listview控件中某列的属性,宏:ListView_InsertColumn",
        578     IDSTR(LVM_SETCOLUMNW),"设置Listview控件中某列的属性,宏:ListView_InsertColumn",
        579     IDSTR(LVM_INSERTCOLUMNA),"向Listview控件插入一个列,宏:ListView_InsertColumn",
        580     IDSTR(LVM_INSERTCOLUMNW),"向Listview控件插入一个列,宏:ListView_InsertColumn",
        581     IDSTR(LVM_DELETECOLUMN),"删除Listview控件中的一个列,宏:ListView_DeleteColumn",
        582     IDSTR(LVM_GETCOLUMNWIDTH),"在Listview控件中获取指定列的宽度,宏:ListView_GetColumnWidth",
        583     IDSTR(LVM_SETCOLUMNWIDTH),"在Listview控件中设置指定列的宽度,宏:ListView_SetColumnWidth",
        584     IDSTR(LVM_GETHEADER),"在Listview控件中获取表头控件的句柄,宏:ListView_GetHeader",
        585     IDSTR(LVM_CREATEDRAGIMAGE),"在Listview控件中为指定的项目创建一个拖曳图像列表,宏:ListView_CreateDragImage",
        586     IDSTR(LVM_GETVIEWRECT),"当前所有项目所占用的矩形范围,宏:ListView_GetViewRect",
        587     IDSTR(LVM_GETTEXTCOLOR),"在Listview控件中获取文本颜色,宏:ListView_GetTextColor",
        588     IDSTR(LVM_SETTEXTCOLOR),"在Listview控件中设置文本颜色,宏:ListView_SetTextColor",
        589     IDSTR(LVM_GETTEXTBKCOLOR),"在Listview控件中获取文本背景色,宏:ListView_SetTextBkC",
        590     IDSTR(LVM_SETTEXTBKCOLOR),"在Listview控件中设置文本背景色,宏:ListView_SetTextBkColor",
        591     IDSTR(LVM_GETTOPINDEX),"在Listview控件中获取可视范围中首个项目的索引,宏:ListView_GetTopInd",
        592     IDSTR(LVM_GETCOUNTPERPAGE),"在Listview控件中获取当前可视项目数量,宏:ListView_GetCountPerPage",
        593     IDSTR(LVM_GETORIGIN),"在Listview控件中获取当前的原点,宏:ListView_GetOrigin",
        594     IDSTR(LVM_UPDATE),"用于刷新Listview控件,若该控件具有LVS_AUTOARRANGE风格,则会引起排列操作,宏:ListView_Update",
        595     IDSTR(LVM_SETITEMSTATE),"在Listview控件中设置项目状态,宏:ListView_SetItemState",
        596     IDSTR(LVM_GETITEMSTATE),"在Listview控件中获取项目状态,宏:ListView_GetItemS",
        597     IDSTR(LVM_GETITEMTEXTA),"在Listview控件中获取项目文本,宏:ListView_GetItemText",
        598     IDSTR(LVM_GETITEMTEXTW),"在Listview控件中获取项目文本,宏:ListView_GetItemText",
        599     IDSTR(LVM_SETITEMTEXTA),"在Listview控件中设置项目文本,宏:ListView_SetItemText",
        600     IDSTR(LVM_SETITEMTEXTW),"在Listview控件中设置项目文本,宏:ListView_SetItemText",
        601     IDSTR(LVM_SETITEMCOUNT),"在Listview控件(虚拟列表视图控件,LVS_OWNERDATA风格)中设置当前列表中项目的总数,宏:ListView_SetItemCount/ListView_SetItemCountEx",
        602     IDSTR(LVM_SORTITEMS),"在Listview控件中进行项目分类排序,宏:ListView_SortItems",
        603     IDSTR(LVM_SETITEMPOSITION32),"设置Listview控件的项目位置,LVM_SETITEMPOSITION消息不同的是,本消息使用32位的坐标,宏:ListView_SetItemPosition32",
        604     IDSTR(LVM_GETSELECTEDCOUNT),"获取Listview控件中被选择项目总数,宏:ListView_GetSelectedCount",
        605     IDSTR(LVM_GETITEMSPACING),"获取Listview控件的项目间距,宏:ListView_GetItemSpacing",
        606     IDSTR(LVM_GETISEARCHSTRINGA),"在Listview控件中获取增量搜索模式的字符串,宏:ListView_GetISearchString",
        607     IDSTR(LVM_GETISEARCHSTRINGW),"在Listview控件中获取增量搜索模式的字符串,宏:ListView_GetISearchString",
        608     IDSTR(LVM_SETICONSPACING),"在Listview控件中设置图标间距,宏:ListView_SetIconSpacing",
        609     IDSTR(LVM_SETEXTENDEDLISTVIEWSTYLE),"设置Listview控件的扩展风格,宏:ListView_SetExtendedListViewStyle/ListView_SetExtendedListViewStyleEx",
        610     IDSTR(LVM_GETEXTENDEDLISTVIEWSTYLE),"获取Listview控件的扩展风格,宏:ListView_GetExtendedListViewStyle",
        611     IDSTR(LVM_GETSUBITEMRECT),"获取Listview控件子项目的矩形范围,宏:ListView_GetSubItemRect",
        612     IDSTR(LVM_SUBITEMHITTEST),"对Listview控件进行点击测试,以确定哪个项目或子项目处于给定的位置,宏:ListView_SubItemHitTest",
        613     IDSTR(LVM_SETCOLUMNORDERARRAY),"在Listview控件中设置列显示的排序(从左至右),宏:ListView_SetColumnOrderArray",
        614     IDSTR(LVM_GETCOLUMNORDERARRAY),"在Listview控件中返回当前列中的左右对齐方式,宏:ListView_GetColumnOrderArray",
        615     IDSTR(LVM_SETHOTITEM),"在Listview控件中设置热点项目(热项),宏:ListView_SetHotItem",
        616     IDSTR(LVM_GETHOTITEM),"在Listview控件中获取热点项目(热项),宏:ListView_GetHotItem",
        617     IDSTR(LVM_SETHOTCURSOR),"在Listview控件中设置热点光标,宏:ListView_SetHotCursor",
        618     IDSTR(LVM_GETHOTCURSOR),"在Listview控件中获取热点光标,宏:ListView_GetHotCursor",
        619     IDSTR(LVM_APPROXIMATEVIEWRECT),"在Listview控件中计算显示一个项目所需的宽度和高度,宏:ListView_ApproximateViewRect",
        620     IDSTR(LVM_SETWORKAREAS),"在Listview控件中设置工作区,宏:ListView_SetWorkAreas",
        621     IDSTR(LVM_GETSELECTIONMARK),"在Listview控件中获取当前选择项目,宏:ListView_GetSelectionMark",
        622     IDSTR(LVM_SETSELECTIONMARK),"在Listview控件中设置当前选择项目,宏:ListView_SetSelectionMark",
        623     IDSTR(LVM_SETBKIMAGEA),"在Listview控件中设置设置背景图片,宏:ListView_SetBkImage",
        624     IDSTR(LVM_GETBKIMAGEA),"获取Listview控件的背景图片,宏:ListView_GetBkImage",
        625     IDSTR(LVM_GETWORKAREAS),"获取Listview控件的工作区矩形范围,宏:ListView_GetWorkAreas",
        626     IDSTR(LVM_SETHOVERTIME),"在Listview控件中设置鼠标在选择某项前停留在该项的延迟毫秒数,宏:ListView_SetHoverTime",
        627     IDSTR(LVM_GETHOVERTIME),"获取Listview控件的鼠标在选择某项前停留在该项的延迟毫秒数,宏:ListView_GetHoverTime",
        628     IDSTR(LVM_GETNUMBEROFWORKAREAS),"获取Listview控件的当前工作区中的项目数量,宏:ListView_GetNumberOfWorkAreas",
        629     IDSTR(LVM_SETTOOLTIPS),"设置Listview控件的工具提示控件,宏:ListView_SetToolTips",
        630     IDSTR(LVM_GETTOOLTIPS),"获取Listview控件的工具提示控件,宏:ListView_GetToolTips",
        631     IDSTR(LVM_SETBKIMAGEW),"以宽字符方式设置Listview控件的背景图,宏:ListView_SetBkImage",
        632     IDSTR(LVM_GETBKIMAGEW),"以宽字符方式获取Listview控件的背景图,宏:ListView_GetBkImage",
        633 
        634     //Listview控件通知消息
        635     IDSTR(LVN_ITEMCHANGING),"通知Listview控件的父窗:有个项目正被改变",
        636     IDSTR(LVN_ITEMCHANGED),"通知Listview控件的父窗:有个项目已经被改变",
        637     IDSTR(LVN_INSERTITEM),"通知Listview控件的父窗:有个新项目被插入了",
        638     IDSTR(LVN_DELETEITEM),"通知Listview控件的父窗:有个项目要被删除",
        639     IDSTR(LVN_DELETEALLITEMS),"通知Listview控件的父窗:所有项目要被删除",
        640     IDSTR(LVN_BEGINLABELEDITA),"通知Listview控件的父窗:一个项目的文本标签编辑的起点",
        641     IDSTR(LVN_BEGINLABELEDITW),"通知Listview控件的父窗:一个项目的文本标签编辑的起点",
        642     IDSTR(LVN_ENDLABELEDITA),"通知Listview控件的父窗:一个项目的文本标签编辑的终点",
        643     IDSTR(LVN_ENDLABELEDITW),"通知Listview控件的父窗:一个项目的文本标签编辑的终点",
        644     IDSTR(LVN_COLUMNCLICK),"通知Listview控件的父窗:一个列被点击了",
        645     IDSTR(LVN_BEGINDRAG),"通知Listview控件的父窗:鼠标左键的拖放操作开始了",
        646     IDSTR(LVN_BEGINRDRAG),"通知Listview控件的父窗:鼠标右键的拖放操作开始了",
        647     IDSTR(LVN_ODCACHEHINT),"通知消息,由虚列表控件在其可视区域的内容被改变时发送",
        648     IDSTR(LVN_ODFINDITEMA),"通知消息,由虚列表控件在需要其所有者查找特定的回调项目时发送",
        649     IDSTR(LVN_ODFINDITEMW),"通知消息,由虚列表控件在需要其所有者查找特定的回调项目时发送",
        650     IDSTR(LVN_ITEMACTIVATE),"通知消息,由虚列表控件在用户激活了某个项目时发送",
        651     IDSTR(LVN_ODSTATECHANGED),"通知消息,由虚列表控件在一个项目的状态或排列已被改变时发送",
        652     IDSTR(LVN_HOTTRACK),"通知消息,由虚列表控件在用户的鼠标掠过某个项目时发送",
        653     IDSTR(LVN_GETDISPINFOA),"由虚列表控件发送,请求父窗提供显示项目或对某个项目排序所需的信息",
        654     IDSTR(LVN_GETDISPINFOW),"由虚列表控件发送,请求父窗提供显示项目或对某个项目排序所需的信息",
        655     IDSTR(LVN_SETDISPINFOA),"通知Listview控件的父窗:它得更新某个项目的信息",
        656     IDSTR(LVN_SETDISPINFOW),"通知Listview控件的父窗:它得更新某个项目的信息",
        657     IDSTR(LVN_MARQUEEBEGIN),"通知Listview控件的父窗:某个边框选择已开始",
        658     IDSTR(LVN_GETINFOTIPA),"通知消息,由大图标的具有LVS_EX_INFOTIP扩展风格的Listview控件在它要请求附加的文本信息(显示于工具提示控件中)时发送",
        659     IDSTR(LVN_GETINFOTIPW),"通知消息,由大图标的具有LVS_EX_INFOTIP扩展风格的Listview控件在它要请求附加的文本信息(显示于工具提示控件中)时发送",
        660 
        661     //树控件消息
        662     IDSTR(TVM_CREATEDRAGIMAGE),"创建树控件的RAG图象,宏:TreeView_CreateDragImage",
        663     IDSTR(TVM_DELETEITEM),"删除树控件的项目,宏:TreeView_DeleteAllItems",
        664     IDSTR(TVM_EDITLABELA),"编辑树控件的标签,宏:TVN_BEGINLABELEDIT",
        665     IDSTR(TVM_EDITLABELW),"编辑树控件的标签,宏:TVN_BEGINLABELEDIT",
        666     IDSTR(TVM_ENDEDITLABELNOW),"结束编辑树控件的新标签,宏:TreeView_EndEditLabelNow",
        667     IDSTR(TVM_ENSUREVISIBLE),"保证树控件的某个项目可视,宏:TreeView_EnsureVisible",
        668     IDSTR(TVM_EXPAND),"扩展或收缩树控件某节点下的所有子节点,宏:TreeView_Expand",
        669     IDSTR(TVM_GETBKCOLOR),"获取树控件的背景色,宏:TreeView_GetBkColor",
        670     IDSTR(TVM_GETCOUNT),"获取树控件的项目数量,宏:TreeView_GetCount",
        671     IDSTR(TVM_GETEDITCONTROL),"获取树控件编辑框控件句柄(用于编辑某项文本),宏:TreeView_GetEditControl",
        672     IDSTR(TVM_GETIMAGELIST),"获取树控件的列表图片,返回图象句柄,宏:TreeView_GetImageList",
        673     IDSTR(TVM_GETINDENT),"获取树控件的子项相对于父项缩进的量(像素),宏:TreeView_GetIndent",
        674     IDSTR(TVM_GETINSERTMARKCOLOR),"返回一个包含当前插入编辑颜色的COLORREF,宏:TreeView_GetInsertMarkColor",
        675     IDSTR(TVM_GETISEARCHSTRING),"获取树控件的搜索文本,宏:TreeView_GetISearchString",
        676     IDSTR(TVM_GETITEMA),"获取树控件指定项的属性,相关结构:TVITEM,宏:TreeView_GetItem",
        677     IDSTR(TVM_GETITEMW),"获取树控件指定项的属性,相关结构:TVITEM,宏:TreeView_GetItem",
        678     IDSTR(TVM_GETITEMHEIGHT),"取树控件项目的行距,宏:TreeView_GetItemHeight",
        679     IDSTR(TVM_GETITEMRECT),"获取树控件项目的边界矩形,并确定该项是否可视,宏:TreeView_GetItemRect",
        680     IDSTR(TVM_GETNEXTITEM),"获取树控件下一项目的句柄,宏:TreeView_GetNextItem/TreeView_GetChild/TreeView_GetDropHilight/TreeView_GetFirstVisible/TreeView_GetLastVisible/TreeView_GetNextSibling/TreeView_GetNextVisible/TreeView_GetParent/TreeView_GetPrevSibling/TreeView_GetPrevVisible/TreeView_GetRoot/TreeView_GetSelection ",
        681     IDSTR(TVM_GETSCROLLTIME),"获取树控件的最大滚动时间(毫秒),宏:TreeView_GetScrollTime",
        682     IDSTR(TVM_GETTEXTCOLOR),"获取树控件的文本颜色,宏:TreeView_GetTextColor",
        683     IDSTR(TVM_GETTOOLTIPS),"获取树控件所使用的工具提示控件的句柄,宏:TreeView_GetToolTips",
        684     IDSTR(TVM_GETUNICODEFORMAT),"获取树控件的UNICODE格式标志,宏:TreeView_GetUnicodeFormat",
        685     IDSTR(TVM_GETVISIBLECOUNT),"获取树控件中的可视项目数量,宏:TreeView_GetVisibleCount",
        686     IDSTR(TVM_HITTEST),"树控件点击测试,宏:TreeView_HitTest",
        687     IDSTR(TVM_INSERTITEMA),"在树控件中插入项目,宏:TreeView_InsertItem",
        688     IDSTR(TVM_INSERTITEMW),"在树控件中插入项目,宏:TreeView_InsertItem",
        689     IDSTR(TVM_SELECTITEM),"选取树控件的项目,宏:TreeView_Select/TreeView_SelectItem/TreeView_SelectDropTarget",
        690     IDSTR(TVM_SETBKCOLOR),"设置树控件的背景色,宏:TreeView_SetBkColor",
        691     IDSTR(TVM_SETIMAGELIST),"设置树控件的图象列表,宏:TreeView_SetImageList",
        692     IDSTR(TVM_SETINDENT),"设置树控件缩进的宽度,并重画控件以反映新的宽度,宏:TreeView_SetIndent",
        693     IDSTR(TVM_SETINSERTMARK),"设置树控件的插入标志,宏:TreeView_SetInsertMark",
        694     IDSTR(TVM_SETINSERTMARKCOLOR),"设置树控件的插入标志色(返回包含先前的插入标记色的COLORREF值),宏:TreeView_SetInsertMarkColor",
        695     IDSTR(TVM_SETITEMA),"设置树控件的项目,相关结构:TVITEM,宏:TreeView_SetItem",
        696     IDSTR(TVM_SETITEMW),"设置树控件的项目,相关结构:TVITEM,宏:TreeView_SetItem",
        697     IDSTR(TVM_SETITEMHEIGHT),"设置树控件的项目高度(像素)(返回项目先前的高度),宏:TreeView_SetItemHeight",
        698     IDSTR(TVM_SETSCROLLTIME),"设置树控件的最大滚动时间(毫秒),宏:TreeView_SetScrollTime",
        699     IDSTR(TVM_SETTEXTCOLOR),"设置树控件的文本颜色,宏:TreeView_SetTextColor",
        700     IDSTR(TVM_SETTOOLTIPS),"设置树控件的工具提示控件(句柄),宏:TreeView_SetToolTips",
        701     IDSTR(TVM_SETUNICODEFORMAT),"设置树控件的UNICODE格式标志,宏:TreeView_SetUnicodeFormat",
        702     IDSTR(TVM_SORTCHILDREN),"对树控件中指定父项的子项进行排序,宏:TreeView_SortChildren",
        703     IDSTR(TVM_SORTCHILDRENCB),"通过一个用来比较各项的回调函数对树控件进行排序,宏:TreeView_SortChildrenCB",
        704 
        705     //树控件通知消息
        706     IDSTR(TVN_BEGINDRAG),"树控件中鼠标左键拖放开始",
        707     IDSTR(TVN_BEGINLABELEDIT),"开始编辑项目的标签",
        708     IDSTR(TVN_BEGINRDRAG),"树控件中鼠标右键拖放开始",
        709     IDSTR(TVN_DELETEITEM),"删除树控件中的项目",
        710     IDSTR(TVN_ENDLABELEDIT),"允许用户编辑项目的标签",
        711     IDSTR(TVN_GETDISPINFO),"在需要得到树控件的某结点信息时发送(如得到结点的显示字符)",
        712     IDSTR(TVN_GETINFOTIP),"获取工具提示控件信息",
        713     IDSTR(TVN_ITEMEXPANDED),"树控件某结点已被展开或收缩,所用结构:NMTREEVIEW",
        714     IDSTR(TVN_ITEMEXPANDING),"树控件某结点将被展开或收缩,所用结构:NMTREEVIEW",
        715     IDSTR(TVN_KEYDOWN),"用户在树控件中按下了某键盘按键,并且树控件获得了输入焦点",
        716     IDSTR(TVN_SELCHANGED),"用户已改变树控件项目的选择",
        717     IDSTR(TVN_SELCHANGING),"用户对树控件项目的选择将改变",
        718     IDSTR(TVN_SETDISPINFO),"通知更新树控件项目的信息",
        719     IDSTR(TVN_SINGLEEXPAND),"用户使用鼠标单击打开或关闭树控件项目时发送的通知消息",
        720 
        721     //Header Control标头控件消息
        722     IDSTR(HDM_DELETEITEM),"删除标头控件的列项目,宏:Header_DeleteItem",
        723     IDSTR(HDM_GETIMAGELIST),"获取标头控件的列图标列表,宏:Header_GetImageList",
        724     IDSTR(HDM_GETITEMA),"获取标头控件的列项目,宏:Header_GetItemRect",
        725     IDSTR(HDM_GETITEMW),"获取标头控件的列项目,宏:Header_GetItemRect",
        726     IDSTR(HDM_GETITEMCOUNT),"获取标头控件的列项目数量,宏:Header_GetItemCount ",
        727     IDSTR(HDM_GETITEMRECT),"获取标头控件的项目矩形范围,宏:Header_GetItemRect",
        728     IDSTR(HDM_GETORDERARRAY),"获取标头控件列的左右对齐方式(提供对标头项目排序的支持),宏:Header_GetOrderArray",
        729     IDSTR(HDM_GETUNICODEFORMAT),"获取标头控件列UNICODE格式标志,宏:Header_GetUnicodeFormat",
        730     IDSTR(HDM_HITTEST),"标头控件点击测试,找到鼠标点击的坐标",
        731     IDSTR(HDM_INSERTITEM),"为标头控件插入列项目,宏:Header_InsertItem",
        732     IDSTR(HDM_LAYOUT),"获取在一个指定矩形内的标头控件的大小和位置,宏:Header_Layout",
        733     IDSTR(HDM_ORDERTOINDEX),"获取标头控件列的左右对齐方式(项目索引,基于标头控件中项目的顺序,索引自左到右由0开始),宏:Header_OrderToIndex",
        734     IDSTR(HDM_SETHOTDIVIDER),"设置高亮度分隔符,提供对标头项目的拖放,宏:Header_SetHotDivider",
        735     IDSTR(HDM_SETIMAGELIST),"为标头控件设置图像列表,宏:Header_SetImageList",
        736     IDSTR(HDM_SETITEMA),"设置标头控件中项目的属性,宏:Header_SetItem",
        737     IDSTR(HDM_SETITEMW),"设置标头控件中项目的属性,宏:Header_SetItem",
        738     IDSTR(HDM_SETORDERARRAY),"设置标头控件列的左右对齐方式,宏:Header_SetOrderArray",
        739     IDSTR(HDM_SETUNICODEFORMAT),"设置Header Control控件列UNICODE格式标志,宏:Header_SetUnicodeFormat",
        740     
        741     //Static Control静态控件消息    
        742     IDSTR(STM_GETICON),"获取显示在静态控件中的图标的句柄,须具SS_ICON风格,宏:Static_GetIcon",
        743     IDSTR(STM_GETIMAGE),"获取显示在静态控件中的图像的句柄,支持图标(SS_ICON)、光标(SS_ICON)、位图(SS_BITMAP)、图元(SS_ENHMETAFILE)",
        744     IDSTR(STM_SETICON),"设置将要在静态控件中显示的图标(句柄),须具SS_ICON风格,宏:Static_SetIcon",
        745     IDSTR(STM_SETIMAGE),"设置将要在静态控件中显示的图像(句柄),支持图标(SS_ICON)、光标(SS_ICON)、位图(SS_BITMAP)、图元(SS_ENHMETAFILE),自定义宏(位图):#define Static_SetBitmap(hwndCtl, hBitmap)  ((HBITMAP)(UINT_PTR)SendMessage((hwndCtl), STM_SETIMAGE, IMAGE_BITMAP, (LPARAM)(HBITMAP)hBitmap))",
        746 
        747     //Static Control静态控件通知消息
        748     IDSTR(STN_CLICKED),"通知父窗(通过WM_COMMAND获知),用户点击了静态控件,须具SS_NOTIFY风格,",
        749     IDSTR(STN_DBLCLK),"通知父窗(通过WM_COMMAND获知),用户点击了静态控件,须具SS_NOTIFY风格",
        750     IDSTR(STN_DISABLE),"通知父窗(通过WM_COMMAND获知),静态控件被允许使用,须具SS_NOTIFY风格",
        751     IDSTR(STN_ENABLE),"通知父窗(通过WM_COMMAND获知),静态控件被禁用,须具SS_NOTIFY风格",
        752 
        753     //Toolbar Control工具栏控件消息
        754     IDSTR(TB_ADDBITMAP),"将一个或多个按钮图像添加到工具栏的按钮图像列表中,相关结构:TBADDBITMAP",
        755     IDSTR(TB_ADDBUTTONS),"向一个工具栏中添加一个或多个按钮,相关结构:TBBUTTON",
        756     IDSTR(TB_ADDSTRING),"添加一个新字符串到工具栏的内部字符串列表中",
        757     IDSTR(TB_AUTOSIZE),"调整工具栏的尺寸。当设置按钮或位图尺寸、添加字符串时,发送本消息",
        758     IDSTR(TB_BUTTONCOUNT),"获取工具栏当前按钮的个数",
        759     IDSTR(TB_BUTTONSTRUCTSIZE),"指定工具栏TBBUTTON结构的大小",
        760     IDSTR(TB_CHANGEBITMAP),"改变工具栏的按钮图像(图像列表中的索引)",
        761     IDSTR(TB_CHECKBUTTON),"核选或清除工具栏的指定按钮。当一个按钮被核选时,它看起来就像被按下一样",
        762     IDSTR(TB_COMMANDTOINDEX),"获取与指定命令标识符相关联的工具栏按钮的索引(从零开始)",
        763     IDSTR(TB_CUSTOMIZE),"显示\"自定义工具栏\"对话框,该对话框允许通过增删按钮来定制工具条",
        764     IDSTR(TB_DELETEBUTTON),"删除工具栏中的一个按钮",
        765     IDSTR(TB_ENABLEBUTTON),"使工具栏指定按钮有效或无效,注:当按钮有效时就可被按下或核选",
        766     IDSTR(TB_GETANCHORHIGHLIGHT),"获取工具栏的固定的加亮设置",
        767     IDSTR(TB_GETBITMAP),"获取与工具栏按钮相关联的位图的索引",
        768     IDSTR(TB_GETBITMAPFLAGS),"从工具栏获取位图标志(DWORD值)",
        769     IDSTR(TB_GETBUTTON),"获取工具栏指定按钮的信息",
        770     IDSTR(TB_GETBUTTONINFO),"获取工具栏中按钮的扩展信息,相关结构:TBBUTTONINFO",
        771     IDSTR(TB_GETBUTTONSIZE),"获取工具栏按钮的尺寸",
        772     IDSTR(TB_GETBUTTONTEXT),"获取工具栏按钮的文本",
        773     IDSTR(TB_GETCOLORSCHEME),"获取工具栏的色彩方案信息",
        774     IDSTR(TB_GETDISABLEDIMAGELIST),"获取工具栏中被设置为无效的图像列表",
        775     IDSTR(TB_GETEXTENDEDSTYLE),"获取工具栏的扩展风格",
        776     IDSTR(TB_GETHOTIMAGELIST),"获取工具栏的热点按钮的图像列表,当鼠标悬浮于热点按钮上时,按钮会加亮显示",
        777     IDSTR(TB_GETHOTITEM),"获取工具栏的热点项的索引(从零开始)",
        778     IDSTR(TB_GETIMAGELIST),"获取工具栏中用于显示按钮常规状态图像的列表",
        779     IDSTR(TB_GETINSERTMARK),"获取工具栏的插入标记,相关结构:TBINSERTMARK",
        780     IDSTR(TB_GETINSERTMARKCOLOR),"获取工具栏中包含当前插入标记的颜色(COLORREF值)",
        781     IDSTR(TB_GETITEMRECT),"获取工具栏中的一个按钮的边界矩形,不接收状态被设为TBSTATE_HIDDEN的按钮的边界矩形",
        782     IDSTR(TB_GETMAXSIZE),"获取工具栏中所有可见按钮与分隔条的总尺寸",
        783     IDSTR(TB_GETOBJECT),"获取工具栏的IDropTarget接口,IDropTarget用于实现以拖放方式获取资源等",
        784     IDSTR(TB_GETPADDING),"获取工具栏的填充距(像素)(padding:补白、填充距)",
        785     IDSTR(TB_GETRECT),"获取工具栏指定按钮的边界矩形信息",
        786     IDSTR(TB_GETROWS),"获取工具栏中当前显示的按钮行数,注:除非工具栏是用TBSTYLE_WRAPABLE风格创建的,否则行数总为1",
        787     IDSTR(TB_GETSTATE),"获取工具栏定按钮的状态信息,比如:是否是有效、被按下或被核选",
        788     IDSTR(TB_GETSTYLE),"获取工具栏当前风格",
        789     IDSTR(TB_GETTEXTROWS),"获取用于显示在工具栏按钮上的文本行的最大数字",
        790     IDSTR(TB_GETTOOLTIPS),"获取与工具栏相关联的工具提示控件(若有)的句柄,通常工具栏会自己创建并维护其工具提示控件,一般不必使用本消息",
        791     IDSTR(TB_GETUNICODEFORMAT),"获取工具栏的UNICODE格式标志",
        792     IDSTR(TB_HIDEBUTTON),"隐藏或显示工具栏指定按钮",
        793     IDSTR(TB_HITTEST),"点击测试,获取工具栏指定点的位置的整数值,若该值为零或正值,则表示该点所在按钮的索引(非分隔条),为负则该点不在某按钮上",
        794     IDSTR(TB_INDETERMINATE),"设置或清除工具栏指定按钮的不确定状态,不确定的按钮被显示为灰色",
        795     IDSTR(TB_INSERTBUTTON),"在工具栏中插入一个按钮",
        796     IDSTR(TB_INSERTMARKHITTEST),"为工具栏上的某点(该点坐标是相对于工具栏客户区的)获取插入标记的信息,相关结构:TBINSERTMARK",
        797     IDSTR(TB_ISBUTTONCHECKED),"确定工具栏指定按钮是否被核选",
        798     IDSTR(TB_ISBUTTONENABLED),"确定工具栏指定按钮是否有效",
        799     IDSTR(TB_ISBUTTONHIDDEN),"确定工具栏指定按钮是否被隐藏",
        800     IDSTR(TB_ISBUTTONHIGHLIGHTED),"检查工具栏指定按钮是否处于加亮状态",
        801     IDSTR(TB_ISBUTTONINDETERMINATE),"确定工具栏指定按钮是否处于不确定状态,不确定按钮被显示为灰色",
        802     IDSTR(TB_ISBUTTONPRESSED),"确定工具栏指定按钮是否被按下",
        803     IDSTR(TB_LOADIMAGES),"加载图像到工具栏图像列表中",
        804     IDSTR(TB_MAPACCELERATOR),"为一个工具栏按钮映射快捷键字符,该字符与按钮文本中加下划线的字符是一样的",
        805     IDSTR(TB_MARKBUTTON),"为工具栏指定按钮设置加亮状态",
        806     IDSTR(TB_MOVEBUTTON),"将一个工具栏按钮从一个索引移动到另一个索引",
        807     IDSTR(TB_PRESSBUTTON),"按下或释放工具栏的指定按钮",
        808     IDSTR(TB_REPLACEBITMAP),"以新位图替换工具栏中现有的位图,相关结构:TBREPLACEBITMAP",
        809     IDSTR(TB_SAVERESTORE),"保存或恢复工具栏的状态,相关结构:TBSAVEPARAMS",
        810     IDSTR(TB_SETANCHORHIGHLIGHT),"对工具栏进行加亮设置",
        811     IDSTR(TB_SETBITMAPSIZE),"设置添加到工具栏的位图尺寸",
        812     IDSTR(TB_SETBUTTONINFO),"设置工具栏指定按钮的信息",
        813     IDSTR(TB_SETBUTTONSIZE),"设置工具栏的按钮尺寸(尺寸必须与所载入的位图尺寸一样)",
        814     IDSTR(TB_SETBUTTONWIDTH),"设置工具栏按钮宽度的最大值和最小值",
        815     IDSTR(TB_SETCMDID),"设置工具栏指定按钮的命令标识符(按钮被按下时,标识符将被发送给属主窗口)",
        816     IDSTR(TB_SETCOLORSCHEME),"设置工具栏的色彩方案信息",
        817     IDSTR(TB_SETDISABLEDIMAGELIST),"设置工具栏中用来显示无效按钮的图像列表",
        818     IDSTR(TB_SETDRAWTEXTFLAGS),"设置工具栏的文本绘制标志",
        819     IDSTR(TB_SETEXTENDEDSTYLE),"设置工具栏的扩展风格",
        820     IDSTR(TB_SETHOTIMAGELIST),"设置工具栏中用于显示热点按钮的图像列表",
        821     IDSTR(TB_SETHOTITEM),"设置工具栏热点项索引(若无TBSTYLE_FLAT风格,则本消息将会被忽略)",
        822     IDSTR(TB_SETIMAGELIST),"设置工具栏的默认图像列表",
        823     IDSTR(TB_SETINDENT),"设置工具栏中首个按钮的缩进",
        824     IDSTR(TB_SETINSERTMARK),"设置工具栏的当前插入标记",
        825     IDSTR(TB_SETINSERTMARKCOLOR),"设置工具栏插入标记的颜色",
        826     IDSTR(TB_SETMAXTEXTROWS),"设置显示在工具栏按钮中的文本的最大行数",
        827     IDSTR(TB_SETPADDING),"设置工具栏的填充距(像素)(padding:补白、填充距)",
        828     IDSTR(TB_SETPARENT),"为工具栏指定一个父窗(用于发送通知消息)",
        829     IDSTR(TB_SETROWS),"设置工具栏按钮的行数",
        830     IDSTR(TB_SETSTATE),"设置工具条栏指定按钮的状态",
        831     IDSTR(TB_SETSTYLE),"设置工具栏的风格",
        832     IDSTR(TB_SETTOOLTIPS),"将一个工具提示控件与工具栏进行关联",
        833     IDSTR(TB_SETUNICODEFORMAT),"设置工具栏的UNICODE格式标志",
        834 
        835     //Toolbar Control工具栏通知消息
        836     IDSTR(TBN_BEGINADJUST),"通知工具栏的父窗:用户已开始自定义一个工具栏,相关结构:NMHDR",
        837     IDSTR(TBN_BEGINDRAG),"通知工具栏的父窗:用户已开始拖动工具栏的某个按钮,相关结构:NMTOOLBAR",
        838     IDSTR(TBN_CUSTHELP ),"通知工具栏的父窗:用户已经选择了自定义工具栏对话框上的帮助按钮,相关结构:NMHDR",
        839     IDSTR(TBN_ENDADJUST),"通知工具栏的父窗:用户已停止自定义一个工具栏,相关结构:NMHDR",
        840     IDSTR(TBN_ENDDRAG),"通知工具栏的父窗:用户已停止拖动工具栏的某个按钮,相关结构:NMTOOLBAR",
        841     IDSTR(TBN_GETBUTTONINFO),"获取工具栏的自定义信息(通知消息),相关结构:NMTOOLBAR",
        842     IDSTR(TBN_QUERYDELETE),"通知工具栏的父窗:用户自定义工具栏时一个按钮是否可被删除",
        843     IDSTR(TBN_QUERYINSERT),"通知工具栏的父窗:用户自定义工具栏时一个按钮是否可被插入到指定按钮的左侧",
        844     IDSTR(TBN_RESET),"通知工具栏的父窗:用户在自定义工具栏对话框中已经对工具栏进行重置了",
        845     IDSTR(TBN_TOOLBARCHANGE),"通知工具栏的父窗:用户已经定制完一个工具栏",
        846 
        847     //IP address control(IP地址控件)消息
        848     IDSTR(IPM_CLEARADDRESS),"清空IP地址控件中的内容",
        849     IDSTR(IPM_GETADDRESS),"从IP地址控件的4个域中获取地址值,相关宏:FIRST_IPADDRESS/SECOND_IPADDRESS/THIRD_IPADDRESS/FOURTH_IPADDRESS",
        850     IDSTR(IPM_ISBLANK),"确定IP地址控件的全部域是否为空",
        851     IDSTR(IPM_SETADDRESS),"为IP地址控件的4个域设置地址,宏:MAKEIPADDRESS",
        852     IDSTR(IPM_SETFOCUS),"为IP地址控件指定域设置键盘焦点,同时该域中的文本会被选中",
        853     IDSTR(IPM_SETRANGE),"为IP地址控件指定域设置有效范围,宏:MAKEIPRANGE",
        854 
        855     //IP address control(IP地址控件)通知消息
        856     IDSTR(IPN_FIELDCHANGED),"用户改变了IP地址控件某域或从一个域移动其它域时发送本通知消息,相关结构NMIPADDRESS",
        857 
        858     //progress bar进度条消息
        859     IDSTR(PBM_DELTAPOS),"以指定的增量来增加进度条控件的当前位置",
        860     IDSTR(PBM_GETPOS),"检取进度条的当前位置",
        861     IDSTR(PBM_GETRANGE),"获取当前进度条控件的上下限范围",
        862     IDSTR(PBM_SETBARCOLOR),"设置进度条控件上滑块的颜色(COLORREF值)",
        863     IDSTR(PBM_SETBKCOLOR),"设置进度条控件的背景色",
        864     IDSTR(PBM_SETPOS),"以指定位置来设置进度条的当前位置,并重绘进度条来反映新位置",
        865     IDSTR(PBM_SETRANGE),"设置进度条控件范围的上下限,并重绘进度条来反映新范围",
        866     IDSTR(PBM_SETRANGE32),"为进度条设置32位的上下限范围",
        867     IDSTR(PBM_SETSTEP),"为进度条控件指定步长(缺省为10)",
        868     IDSTR(PBM_STEPIT),"用步进值来增加一个进度条控件的当前位置",
        869 
        870     //Trackbar Control(跟踪器),也叫:Slider Control,滑块控件消息
        871     IDSTR(TBM_CLEARSEL),"清除滑动块控件当前位置",
        872     IDSTR(TBM_CLEARTICS),"删除滑动块控件当前刻度线",
        873     IDSTR(TBM_GETBUDDY),"获取滑动块控件指定位置的伙伴窗口的句柄",
        874     IDSTR(TBM_GETCHANNELRECT),"获取滑动块控件的通道的边界矩形的大小和位置,滑动块在通道上移动并选择一个范围后,它用高亮色显示",
        875     IDSTR(TBM_GETLINESIZE),"获取滑动块控件的行的大小,缺省的行大小是1",
        876     IDSTR(TBM_GETNUMTICS),"获取滑动块控件中的刻度线",
        877     IDSTR(TBM_GETPAGESIZE),"获取滑动块控件一页的大小,页的大小表明在响应TB_PAGEUP和TB_PAGEDOWN通知时滑动块会移动多少",
        878     IDSTR(TBM_GETPOS),"获取滑动块控件中滑动块的当前位置",
        879     IDSTR(TBM_GETPTICS),"获取滑动块控件中的一个刻度线的当前物理位置(用客户坐标表示)",
        880     IDSTR(TBM_GETRANGEMAX),"获取滑动块控件中滑动块的最大位置",
        881     IDSTR(TBM_GETRANGEMIN),"获取滑动块控件中滑动块的最小位置",
        882     IDSTR(TBM_GETSELEND),"获取滑动块控件中当前选择的结束位置",
        883     IDSTR(TBM_GETSELSTART),"获取滑动块控件中当前选择的开始位置",
        884     IDSTR(TBM_GETTHUMBLENGTH),"获取滑动块控件中滑动块(拇指)的长度",
        885     IDSTR(TBM_GETTHUMBRECT),"获取滑动块控件中滑动块(拇指)的边界矩形的大小和位置",
        886     IDSTR(TBM_GETTIC),"获取滑动块控件中刻度线的位置",
        887     IDSTR(TBM_GETTICPOS),"获取滑动块控件中一个刻度线的当前物理位置(用客户坐标表示)",
        888     IDSTR(TBM_GETTOOLTIPS),"获取滑动块控件的工具提示控件的句柄(若有),若TBS_TOOLTIPS风格,则返回NULL",
        889     IDSTR(TBM_GETUNICODEFORMAT),"获取滑动块控件的UNICODE格式标志",
        890     IDSTR(TBM_SETBUDDY),"设置滑动块控件指定位置的伙伴窗口",
        891     IDSTR(TBM_SETLINESIZE),"设置滑动块控件行的大小,行的大小表示在响应TB_LINEUP和TV_LINEDOWN通知时,滑动块移动多少",
        892     IDSTR(TBM_SETPAGESIZE),"设置滑动块控件页的大小,页的大小表示在响应TB_PAGEUP和TB_PAGEDOWN通知时,滑动块移动多少",
        893     IDSTR(TBM_SETPOS),"设置滑动块控件中滑动块的当前位置",
        894     IDSTR(TBM_SETRANGE),"设置滑动块控件滑动块的范围(位置的最小值和最大值)",
        895     IDSTR(TBM_SETRANGEMAX),"设置滑动块控件中滑动块的最大位置",
        896     IDSTR(TBM_SETRANGEMIN),"设置滑动块控件中滑动块的最小位置",
        897     IDSTR(TBM_SETSEL),"设置滑动块控件当前选择的开始和结束位置",
        898     IDSTR(TBM_SETSELEND),"设置滑动块控件中当前选择的结束位置",
        899     IDSTR(TBM_SETSELSTART),"设置滑动块控件中当前选择的开始位置",
        900     IDSTR(TBM_SETTHUMBLENGTH),"设置滑动块控件中滑动块(拇指)的长度",
        901     IDSTR(TBM_SETTIC),"设置滑动块控件中一个刻度线的位置",
        902     IDSTR(TBM_SETTICFREQ),"设置显示在滑动块控件中的刻度线的的频率,例如:若频率设为2,则每两个增量显示一个刻度线,缺省频率是1",
        903     IDSTR(TBM_SETTIPSIDE),"设置滑动块控件中用于显示工具提示控件的位置",
        904     IDSTR(TBM_SETTOOLTIPS),"为滑动块控件设置工具提示控件(用句柄进行设置)",
        905     IDSTR(TBM_SETUNICODEFORMAT),"设置滑动块控件的UNICODE格式标志",
        906 
        907     //Tab Control,标签控件消息
        908     IDSTR(TCM_ADJUSTRECT),"根据给定的窗口矩形计算标签控件的显示区域,或根据一个给定的显示区域计算相应的窗口矩形",
        909     IDSTR(TCM_DELETEALLITEMS),"删除标签控件中所有选项卡",
        910     IDSTR(TCM_DELETEITEM),"从标签控件中删除指定选项卡",
        911     IDSTR(TCM_DESELECTALL),"重新设置标签控件中的项,清除任何被按下的选项卡",
        912     IDSTR(TCM_GETCURFOCUS),"获取标签控件中拥有当前焦点的选项卡索引",
        913     IDSTR(TCM_GETCURSEL),"获取标签控件中当前选择的选项卡",
        914     IDSTR(TCM_GETEXTENDEDSTYLE),"获取标签控件的扩展风格",
        915     IDSTR(TCM_GETIMAGELIST),"获取与标签控件相关联的图像列表",
        916     IDSTR(TCM_GETITEM),"获取标签控件中某选项卡的信息",
        917     IDSTR(TCM_GETITEMCOUNT),"获取标签控件中的项数",
        918     IDSTR(TCM_GETITEMRECT),"获取标签控件中指定选项卡的边界矩形",
        919     IDSTR(TCM_GETROWCOUNT),"获取标签控件中当前行数,注:TCS_MULTILINT风格的标签控件可有多行选项卡",
        920     IDSTR(TCM_GETTOOLTIPS),"获取与标签控件相关联的工具提示控件的句柄",
        921     IDSTR(TCM_GETUNICODEFORMAT),"获取标签控件的UNICODE格式标志",
        922     IDSTR(TCM_HIGHLIGHTITEM),"使标签控件的某选项卡处于高亮状态",
        923     IDSTR(TCM_HITTEST),"确定是哪个选项卡(若有)位于指定的屏幕位置",
        924     IDSTR(TCM_INSERTITEM),"插入一个新选项卡到标签控件",
        925     IDSTR(TCM_REMOVEIMAGE),"从标签控件的图像列表中删除指定图像",
        926     IDSTR(TCM_SETCURFOCUS),"设置焦点到标签控件中指定的选项卡",
        927     IDSTR(TCM_SETCURSEL),"设置标签控件中当前选择的选项卡",
        928     IDSTR(TCM_SETEXTENDEDSTYLE),"设置标签控件的扩展风格",
        929     IDSTR(TCM_SETIMAGELIST),"为标签控件指定一个已创建的图像列表",
        930     IDSTR(TCM_SETITEM),"设置标签控件中选项卡的某些或所有属性",
        931     IDSTR(TCM_SETITEMEXTRA),"标签控件为空时,改变标签控件中各选项卡的额外字节数(默认4字节),注:额外字节可把程序数据与各选项卡关联起来",
        932     IDSTR(TCM_SETITEMSIZE),"设置标签控件中选项卡的宽度和高度",
        933     IDSTR(TCM_SETMINTABWIDTH),"设置标签控件中选项卡的最小宽度",
        934     IDSTR(TCM_SETPADDING),"设置标签控件中的每个选项卡的图标和标签周围的空间大小(填充距)",
        935     IDSTR(TCM_SETTOOLTIPS),"设置与标签控件相关联的工具提示控件(用句柄进行设置)",
        936     IDSTR(TCM_SETUNICODEFORMAT),"设置标签控件的UNICODE格式标志",
        937 
        938     //Tab Control,标签控件通知消息
        939     IDSTR(TCN_GETOBJECT),"将对象拖动到标签控件的选项卡上时,标签控件生成TCN_GETOBJECT通知消息以请求放置目标对象,注:须调用AfxOleInit初始化OLE库",
        940     IDSTR(TCN_KEYDOWN),"通知标签控件的父窗:用户已按下某键",
        941     IDSTR(TCN_SELCHANGE),"通知标签控件的父窗:选项卡的当前选择已被改变",
        942     IDSTR(TCN_SELCHANGING),"通知标签控件的父窗:选项卡的当前选择将要改变",
        943 
        944     //Edit Control,编辑控件(编辑框)消息
        945     IDSTR(EM_GETSEL),"获取编辑控件当前被选中部分(若有)的开始和结束位置;返回双字,低位字为起始位置,高位字为首个未被选中的字符位置",
        946     IDSTR(EM_SETSEL),"在编辑控件中选定文本",
        947     IDSTR(EM_GETRECT),"获取编辑控件的带格式的文本边界矩形(与其窗口大小无关)",
        948     IDSTR(EM_SETRECT),"设置编辑控件的带格式的文本边界矩形(与其窗口大小无关)",
        949     IDSTR(EM_SETRECTNP),"设置多行编辑控件的带格式的文本边界矩形,而不必重绘",
        950     IDSTR(EM_SCROLL),"使多行编辑控件滚动一行(SB_LINEDOWN/SB_LINEUP)或一页(SB_PAGEDOWN/SB_PAGEUP)",
        951     IDSTR(EM_LINESCROLL),"以行为单位使多行编辑控件左右或上下滚动",
        952     IDSTR(EM_SCROLLCARET),"滚动编辑控件中的caret插入光标,使之可视",
        953     IDSTR(EM_GETMODIFY),"测试编辑控件的内容是否被改变(它有个内部标记来表明其内容是否被改变)",
        954     IDSTR(EM_SETMODIFY),"设置或清除编辑控件的改变标志;改变标记表明文本是否被改变(用户改变文本时,会自动设置此标志)",
        955     IDSTR(EM_GETLINECOUNT),"获取多行编辑控件中的总行数",
        956     IDSTR(EM_LINEINDEX),"获得多行编辑控件中某行的字符索引",
        957     IDSTR(EM_SETHANDLE),"设置可被多行编辑控件使用的局部内存的句柄,编辑控件可用此缓冲区存储当前显示的文本,而不必自己分配",
        958     IDSTR(EM_GETHANDLE),"获取多行编辑控件中当前分配的内存句柄,此句柄是个局部内存句柄",
        959     IDSTR(EM_GETTHUMB),"取得多行文本编辑控件的滚动框的当前位置(象素)",
        960     IDSTR(EM_LINELENGTH),"获得编辑控件中的行的长度",
        961     IDSTR(EM_REPLACESEL),"用指定文本覆盖编辑控件中当前被选中的文本",
        962     IDSTR(EM_GETLINE),"在编辑控件中获得一行文本",
        963     IDSTR(EM_LIMITTEXT),"用户在编辑控件中输入文本时的文本长度限制",
        964     IDSTR(EM_CANUNDO),"确定对编辑控件的操作能否撤销",
        965     IDSTR(EM_UNDO),"撤销上一次对编辑控件的操作",
        966     IDSTR(EM_FMTLINES),"设置多行编辑控件中是否包含软回车符",
        967     IDSTR(EM_LINEFROMCHAR),"获取包含指定字符索引的行的行号(字符索引指从开始到指定字符的字符数)",
        968     IDSTR(EM_SETTABSTOPS),"在多行编辑控件中设置跳格键的跳幅(控件中文本的任何制表键间会产生一段空白)",
        969     IDSTR(EM_SETPASSWORDCHAR),"设置或清除编辑控件中密码的替换显示字符",
        970     IDSTR(EM_EMPTYUNDOBUFFER),"清除控件的撤消缓冲区,使其不能撤消上一次编辑操作",
        971     IDSTR(EM_GETFIRSTVISIBLELINE),"确定编辑控件中可视的最顶端行的行号",
        972     IDSTR(EM_SETREADONLY),"设置编辑控件的只读状态",
        973     IDSTR(EM_SETWORDBREAKPROC),"设置编辑控件的新的断字处理回调函数",
        974     IDSTR(EM_GETWORDBREAKPROC),"获取编辑控件的新的断字处理回调函数",
        975     IDSTR(EM_GETPASSWORDCHAR),"获取编辑控件中密码的替换显示字符",
        976     IDSTR(EM_SETMARGINS),"设置编辑控件的左右边空",
        977     IDSTR(EM_GETMARGINS),"获取编辑控件的左右边空",
        978     IDSTR(EM_SETLIMITTEXT),"设置编辑控件中文本的输入长度限制",
        979     IDSTR(EM_GETLIMITTEXT),"获取编辑控件中文本的输入长度限制",
        980     IDSTR(EM_POSFROMCHAR),"获得指定字符索引的左上角的坐标",
        981     IDSTR(EM_CHARFROMPOS),"获得编辑控件中最靠近指定位置的字符的行和字符索引",
        982     IDSTR(EM_SETIMESTATUS),"修改编辑控件的IME输入法的属性",
        983     IDSTR(EM_GETIMESTATUS),"获取编辑控件的IME输入法的属性",
        984 
        985     //Edit Control,编辑控件(编辑框)通知消息
        986     IDSTR(EN_SETFOCUS),"通知编辑控件的父窗(通过WM_COMMAND获知):编辑框获得输入焦点",
        987     IDSTR(EN_KILLFOCUS),"通知编辑控件的父窗(通过WM_COMMAND获知):编辑框失去输入焦点",
        988     IDSTR(EN_CHANGE),"用户的操作可能会改变编辑控件的文本(与EN_UPDATE通知消息不同,该通知是在更新显示之后发送的)",
        989     IDSTR(EN_UPDATE),"编辑控件显示变动的文本时的通知消息",
        990     IDSTR(EN_ERRSPACE),"编辑控件不能为特定请求分配足够的空间的通知消息",
        991     IDSTR(EN_MAXTEXT),"通知父窗,编辑控件当前输入文本已超过指定字符数(并作截尾处理)",
        992     IDSTR(EN_HSCROLL),"用户单击了编辑控件的水平滚动条,父窗在屏幕更新之前被通知",
        993     IDSTR(EN_VSCROLL),"用户单击了编辑控件的垂直滚动条,父窗在屏幕更新之前被通知",
        994 
        995     //Hot Key Control,热键控件消息
        996     IDSTR(HKM_GETHOTKEY),"从热键控件中获取一个虚拟键码和修正符标志",
        997     IDSTR(HKM_SETHOTKEY),"为热键控件设置热键组合",
        998     IDSTR(HKM_SETRULES),"为热键控件定义不可用组合和缺省修正符组合",
        999 
        1000     //Month Calendar Control,月历控件消息
        1001     IDSTR(MCM_GETCOLOR),"获取月历控件中各部分的颜色设置",
        1002     IDSTR(MCM_GETCURSEL),"获取月历控件中当前选定日期指定的系统时间",
        1003     IDSTR(MCM_GETFIRSTDAYOFWEEK),"获取月历控件最左边显示的星期值",
        1004     IDSTR(MCM_GETMAXSELCOUNT),"获取月历控件中能被选择的日期最大值",
        1005     IDSTR(MCM_GETMAXTODAYWIDTH),"获取月历控件中\"今天\"这个字符串的最大宽度",
        1006     IDSTR(MCM_GETMINREQRECT),"获取月历控件显示完整月份所需的最小值",
        1007     IDSTR(MCM_GETMONTHDELTA),"获取月历控件的滚动速率",
        1008     IDSTR(MCM_GETMONTHRANGE),"获取代表月历控件显示的日期上限和下限的有关信息",
        1009     IDSTR(MCM_GETRANGE),"获取月历控件中所设置的最大和最小日期值",
        1010     IDSTR(MCM_GETSELRANGE),"获取代表由用户选定当前日期上限和下限的有关信息",
        1011     IDSTR(MCM_GETTODAY),"获取月历控件中今天的日期",
        1012     IDSTR(MCM_GETUNICODEFORMAT),"获取月历控件的UNICODE格式标志",
        1013     IDSTR(MCM_HITTEST),"确定月历控件是否位于指定位置",
        1014     IDSTR(MCM_SETCOLOR),"改变月历控件中各部分的颜色设置",
        1015     IDSTR(MCM_SETCURSEL),"设定月历控件当前选定的日期",
        1016     IDSTR(MCM_SETDAYSTATE),"在月历控件中设置要显示的日期",
        1017     IDSTR(MCM_SETFIRSTDAYOFWEEK),"在月历控件的最左边设置要显示的星期值",
        1018     IDSTR(MCM_SETMAXSELCOUNT),"将月历控件中能被选择的日期值设置为最大",
        1019     IDSTR(MCM_SETMONTHDELTA),"为月历控件设置滚动速率",
        1020     IDSTR(MCM_SETRANGE),"设置月历控件中所许可的最大和最小日期值",
        1021     IDSTR(MCM_SETSELRANGE),"将被选定的月历控件范围设置为给定的日期范围",
        1022     IDSTR(MCM_SETTODAY),"设置月历控件中今天的日期",
        1023     IDSTR(MCM_SETUNICODEFORMAT),"设置月历控件的UNICODE格式标志",
        1024 
        1025     //Month Calendar Control,日历控件通知消息    
        1026     IDSTR(MCN_GETDAYSTATE),"获取月历控件的日期显示风格(粗体/圈定等),要有MCS_DAYSTATE风格,相关结构:NMDAYSTATE",
        1027     IDSTR(MCN_SELCHANGE),"当前选择项已被改变,相关结构:NMSELCHANGE",
        1028     IDSTR(MCN_SELECT),"在月历控件中选择一个日期,相关结构:NMSELCHANGE",
        1029     IDSTR(NM_RELEASEDCAPTURE),"释放月历控件中鼠标的捕获消息,相关结构:NMHDR",
        1030 
        1031     //date and time picker control,日期时间选择控件(DTP控件)消息
        1032     IDSTR(DTM_GETMCCOLOR),"获取DTP控件中下拉月历指定部分的颜色,宏:DateTime_GetMonthCalColor",
        1033     IDSTR(DTM_GETMCFONT),"获取DTP控件中下拉月历的当前所用字体,宏:DateTime_GetMonthCalFont",
        1034     IDSTR(DTM_GETMONTHCAL),"获取DTP控件中下拉月历的句柄,宏:DateTime_GetMonthCal",
        1035     IDSTR(DTM_GETRANGE),"获取DTP控件中最小和最大允许的系统时间,宏:DateTime_GetRange",
        1036     IDSTR(DTM_GETSYSTEMTIME),"获取DTP控件中的当前选择时间(保存至SYSTEMTIME结构体),宏:DateTime_GetSystemtime",
        1037     IDSTR(DTM_SETFORMAT),"设置DTP控件的显示格式,宏:DateTime_SetFormat",
        1038     IDSTR(DTM_SETMCCOLOR),"设置DTP控件中下拉月历指定部分的颜色,宏:DateTime_SetMonthCalColor",
        1039     IDSTR(DTM_SETMCFONT),"设置DTP控件中下拉月历的当前所用字体,宏:DateTime_SetMonthCalFont",
        1040     IDSTR(DTM_SETRANGE),"设置DTP控件中最小和最大允许的系统时间,宏:DateTime_SetRange,相关结构:SYSTEMTIME",
        1041     IDSTR(DTM_SETSYSTEMTIME),"设置DTP控件中的当前选择时间,宏:DateTime_SetSystemtime,相关结构:SYSTEMTIME",
        1042 

        1043     //date and time picker control,日期时间选择控件(DTP控件)通知消息
        1044     IDSTR(DTN_CLOSEUP),"DTP控件中的月历控件将要关闭,相关结构:NMHDR",
        1045     IDSTR(DTN_DATETIMECHANGE),"DTP控件中的内容已发生改变,相关结构:NMDATETIMECHANGE",
        1046     IDSTR(DTN_DROPDOWN),"DTP控件中的月历控件将要显示,相关结构:NMHDR",
        1047     IDSTR(DTN_FORMAT),"DTP控件中的文本需要显示在回调域中,相关结构:NMDATETIMEFORMAT",
        1048     IDSTR(DTN_FORMATQUERY),"DTP控件中的文本显示所需最大尺寸,相关结构:NMDATETIMEFORMATQUERY",
        1049     IDSTR(DTN_USERSTRING),"用户已完成DTP控件的编辑,相关结构:NMDATETIMESTRING",
        1050     IDSTR(DTN_WMKEYDOWN),"用户单击了DTP控件的回调域,相关结构:NMDATETIMEWMKEYDOWN",
        1051 
        1052     //Animation Control,动画播放控件消息
        1053     IDSTR(ACM_OPEN),"利用动画播放控件打开AVI片段并显示其第一帧,若有ACS_AUTOPLAY风格,则打开后自动开始播放,宏: Animate_Open/Animate_OpenEx",
        1054     IDSTR(ACM_PLAY),"在动画控件中播放AVI片段,若有ACS_TRANSPARENT风格,则第一帧将使用透明背景绘制,而不是使用动画片段中指定的背景色,宏:Animate_Play",
        1055     IDSTR(ACM_STOP),"停止动画控件中的AVI片段的播放,宏:Animate_Stop",
        1056 
        1057     //Animation Control,动画播放控件通知消息
        1058     IDSTR(ACN_START),"通知动画播放控件的父窗:AVI片段已经开始播放",
        1059     IDSTR(ACN_STOP),"通知动画播放控件的父窗:AVI片段已经停止播放",
        1060 
        1061     //Status Bar,状态栏消息
        1062     IDSTR(SB_GETBORDERS),"获取状态栏的边界值",
        1063     IDSTR(SB_GETICON),"获取状态栏的窗格图标",
        1064     IDSTR(SB_GETPARTS),"获取状态栏的窗格数量,也可用来获取指定窗格的右边坐标",
        1065     IDSTR(SB_GETRECT),"获取状态栏某窗格的边界矩形",
        1066     IDSTR(SB_GETTEXT),"从状态栏的指定窗格获取文本",
        1067     IDSTR(SB_GETTEXTLENGTH),"从状态栏的指定窗格获取文本长度(用字符数表示)",
        1068     IDSTR(SB_GETTIPTEXT),"获取状态栏某窗格的工具提示文本",
        1069     IDSTR(SB_GETUNICODEFORMAT),"获取状态栏的UNICODE格式标志",
        1070     IDSTR(SB_ISSIMPLE),"状态栏是否处于简单文本模式",
        1071     IDSTR(SB_SETBKCOLOR),"设置状态栏的背景色",
        1072     IDSTR(SB_SETICON),"设置状态栏的窗格图标",
        1073     IDSTR(SB_SETMINHEIGHT),"设置状态栏的绘图区的最小高度",
        1074     IDSTR(SB_SETPARTS),"设置状态栏的窗格数量",
        1075     IDSTR(SB_SETTEXT),"设置状态栏的窗格文本",
        1076     IDSTR(SB_SETTIPTEXT),"设置状态栏某窗格的工具提示文本",
        1077     IDSTR(SB_SETUNICODEFORMAT),"设置状态栏的UNICODE格式标志",
        1078     IDSTR(SB_SIMPLE),"把状态栏设为简单文本模式",
        1079 
        1080     //Status Bar,状态栏通知消息
        1081     IDSTR(SBN_SIMPLEMODECHANGE),"由于SB_SIMPLE消息导致状态栏简单模式发生改变时发送的通知消息",
        1082 
        1083     //ReBar control,ReBar控件(伸缩条)消息
        1084     IDSTR(RB_BEGINDRAG),"ReBar控件开始拖放",
        1085     IDSTR(RB_DELETEBAND),"删除ReBar控件中某个指定索引的带",
        1086     IDSTR(RB_DRAGMOVE),"更新被拖动的ReBar控件的位置",
        1087     IDSTR(RB_ENDDRAG),"ReBar控件停止拖放",
        1088     IDSTR(RB_GETBANDBORDERS),"获取ReBar控件指定带的区域",
        1089     IDSTR(RB_GETBANDCOUNT),"获取ReBar控件中当前带数",
        1090     IDSTR(RB_GETBANDINFO),"获取ReBar控件中指定带的信息",
        1091     IDSTR(RB_GETBARHEIGHT),"获取ReBar控件高度",
        1092     IDSTR(RB_GETBARINFO),"获取有关ReBar控件的信息获及其使用的图像列表",
        1093     IDSTR(RB_GETBKCOLOR),"获取ReBar控件的背景色",
        1094     IDSTR(RB_GETDROPTARGET),"获取ReBar控件的IDropTarget接口指针(不再使用时,要Release释放之)",
        1095     IDSTR(RB_GETCOLORSCHEME),"获取ReBar控件的颜色方案",
        1096     IDSTR(RB_GETPALETTE),"获取ReBar控件的当前调色板",
        1097     IDSTR(RB_GETRECT),"获取ReBar控件矩形区域",
        1098     IDSTR(RB_GETROWCOUNT),"获取ReBar控件的带所占行数",
        1099     IDSTR(RB_GETROWHEIGHT),"获取ReBar控件指定行的高度",
        1100     IDSTR(RB_GETTEXTCOLOR),"获取ReBar控件的文本前景色",
        1101     IDSTR(RB_GETTOOLTIPS),"获取与ReBar控件相关的工具提示控件的句柄",
        1102     IDSTR(RB_GETUNICODEFORMAT),"获取ReBar控件的UNICODE格式标志",
        1103     IDSTR(RB_HITTEST),"若ReBar带在屏幕上的指定点存在,则确定ReBar带的哪部分位于该点上",
        1104     IDSTR(RB_IDTOINDEX),"将一个带的标识符ID转换成ReBar控件中的带索引",
        1105     IDSTR(RB_INSERTBAND),"ReBar控件中插入一个新带",
        1106     IDSTR(RB_MAXIMIZEBAND),"将ReBar控件中的一个带调整到它的理想或最大尺寸",
        1107     IDSTR(RB_MINIMIZEBAND),"将ReBar控件中的一个带调整到它的理想或最小尺寸",
        1108     IDSTR(RB_MOVEBAND),"将ReBar控件的一个带从一个索引移动到另一个索引",
        1109     IDSTR(RB_SETBANDINFO),"设置ReBar控件中的已存在带的特征",
        1110     IDSTR(RB_SETBARINFO),"设置ReBar控件的信息",
        1111     IDSTR(RB_SETBKCOLOR),"设置ReBar控件的背景色",
        1112     IDSTR(RB_SETCOLORSCHEME),"设置ReBar控件的颜色方案",
        1113     IDSTR(RB_SETPALETTE),"为ReBar控件设置新的调色板",
        1114     IDSTR(RB_SETPARENT),"设置ReBar控件的属主窗口",
        1115     IDSTR(RB_SETTEXTCOLOR),"设置ReBar控件的文本前景色",
        1116     IDSTR(RB_SETTOOLTIPS),"使一个工具提示控件与ReBar控件相关联",
        1117     IDSTR(RB_SETUNICODEFORMAT),"设置ReBar控件的UNICODE格式标志",
        1118     IDSTR(RB_SHOWBAND),"显示或隐藏ReBar控件中的指定带",
        1119     IDSTR(RB_SIZETORECT),"使ReBar控件的尺寸与一个指定矩形最优匹配",
        1120 
        1121     //rebar control.rebar控件通知消息
        1122     IDSTR(RBN_AUTOSIZE),"当Rebar控件自己自动调整大小时由(用RBS_AUTOSIZE风格创建的)Rebar控件发送",
        1123     IDSTR(RBN_BEGINDRAG),"当用户开始拖动带区时由Rebar控件发送",
        1124     IDSTR(RBN_CHILDSIZE),"当调整带区的子窗口大小时由Rebar控件发送",
        1125     IDSTR(RBN_DELETEDBAND),"在带区已被删除后由Rebar控件发送",
        1126     IDSTR(RBN_DELETINGBAND),"当带区即将被删除时由Rebar控件发送",
        1127     IDSTR(RBN_ENDDRAG),"当用户停止拖动带区时由Rebar控件发送",
        1128     IDSTR(RBN_GETOBJECT),"当对象被拖动到此控件中的带区上由(用RBS_REGISTERDROP风格创建的)Rebar控件发送",
        1129     IDSTR(RBN_HEIGHTCHANGE),"当其高度已被更改时由Rebar控件发送",
        1130     IDSTR(RBN_LAYOUTCHANGED),"当用户更改此控件的带区布局时由Rebar控件发送",
        1131 
        1132     //Property Sheet,属性页消息
        1133     IDSTR(PSM_ADDPAGE),"添加新页面到属性表,宏:PropSheet_AddPage",
        1134     IDSTR(PSM_APPLY),"应用属性表的新属性,宏:PropSheet_Apply",
        1135     IDSTR(PSM_CANCELTOCLOSE),"使属性表改变确定按钮上的文本为关闭(标志着应用的改变不可被取消),宏:PropSheet_CancelToClose",
        1136     IDSTR(PSM_CHANGED),"使属性表激活应用按钮(标志着用户已经编辑了一个属性),宏:PropSheet_Changed",
        1137     IDSTR(PSM_GETCURRENTPAGEHWND),"获取属性表当前页的窗口句柄,宏:PropSheet_GetCurrentPageHwnd",
        1138     IDSTR(PSM_GETTABCONTROL),"获取属性表中标签控件的句柄,宏:PropSheet_GetTabControl",
        1139     IDSTR(PSM_ISDIALOGMESSAGE),"发送一个消息至属性表对话框,并指明该对话框是否已处理了该消息,宏:PropSheet_IsDialogMessage",
        1140     IDSTR(PSM_PRESSBUTTON),"在属性表中模拟选择某指定按钮,宏:PropSheet_PressButton",
        1141     IDSTR(PSM_QUERYSIBLINGS),"查询属性表的兄弟页,相互传递参数,宏:PropSheet_QuerySiblings",
        1142     IDSTR(PSM_REBOOTSYSTEM),"指明需重启系统以使改变生效(若某页改变了系统配置),宏:PropSheet_RebootSystem",
        1143     IDSTR(PSM_REMOVEPAGE),"从属性表中移走一页,并销毁与此页相关的窗口,宏:PropSheet_RemovePage",
        1144     IDSTR(PSM_RESTARTWINDOWS),"指明属性表需重启以使改变生效,宏:PropSheet_RestartWindows",
        1145     IDSTR(PSM_SETCURSEL),"选择(激活)属性表中某页,宏:PropSheet_SetCurSel",
        1146     IDSTR(PSM_SETCURSELID),"根据页ID选择(激活)属性表中某页,宏:PropSheet_SetCurSelByID",
        1147     IDSTR(PSM_SETFINISHTEXT),"设置属性表中Finish按钮的文本,宏:PropSheet_SetFinishText",
        1148     IDSTR(PSM_SETTITLE),"指定属性表的标题,宏:PropSheet_SetTitle",
        1149     IDSTR(PSM_SETWIZBUTTONS),"使向导属性表中的Back,Next或Finish按钮有效或无效,宏:PropSheet_SetWizButtons",
        1150     IDSTR(PSM_UNCHANGED),"禁止应用按钮,重新初始化属性表,宏:PropSheet_UnChanged",
        1151 
        1152     //Property Sheet,属性页通知消息
        1153     IDSTR(PSN_APPLY),"属性页的应用按钮被按下,相关结构:PSHNOTIFY",
        1154     IDSTR(PSN_GETOBJECT),"通知允许属性页进行OLE拖放对象,相关结构:NMOBJECTNOTIFY",
        1155     IDSTR(PSN_HELP),"用户点击了属性页的帮助按扭,相关结构:PSHNOTIFY",
        1156     IDSTR(PSN_KILLACTIVE),"属性页失去焦点(其它属性页获得了焦点或用户点击了确定按钮),相关结构:PSHNOTIFY",
        1157     IDSTR(PSN_QUERYCANCEL),"用户点击了属性页的取消按扭,相关结构:PSHNOTIFY",
        1158     IDSTR(PSN_RESET),"用户点击了取消按扭,属性页将被销毁,相关结构:PSHNOTIFY",
        1159     IDSTR(PSN_SETACTIVE),"某属性页被激活获得焦点,相关结构:PSHNOTIFY",
        1160     IDSTR(PSN_WIZBACK),"用户点击了向导属性表的前一页按钮,相关结构:PSHNOTIFY",
        1161     IDSTR(PSN_WIZFINISH),"用户点击了向导属性表的结束按钮,相关结构:PSHNOTIFY",
        1162     IDSTR(PSN_WIZNEXT),"用户点击了向导属性表的下一页按钮,相关结构:PSHNOTIFY",
        1163 
        1164     //ComboBoxEx Control,扩展组合框控件消息
        1165     IDSTR(CBEM_DELETEITEM),"删除CComboBoxEx控件中的某个条目",
        1166     IDSTR(CBEM_GETCOMBOCONTROL),"获取CComboBoxEx控件中组合框控件的句柄",
        1167     IDSTR(CBEM_GETEDITCONTROL),"获取CComboBoxEx控件中编辑框控件的句柄",
        1168     IDSTR(CBEM_GETEXTENDEDSTYLE),"获取CComboBoxEx控件的扩展风格",
        1169     IDSTR(CBEM_GETIMAGELIST),"获取CComboBoxEx控件使用的图像列表的句柄",
        1170     IDSTR(CBEM_GETITEM),"获取CComboBoxEx控件中某条目的信息,相关结构:COMBOBOXEXITEM",
        1171     IDSTR(CBEM_GETUNICODEFORMAT),"获取CComboBoxEx控件的UNICODE格式标志",
        1172     IDSTR(CBEM_HASEDITCHANGED),"确定用户是否在CComboBoxEx控件的编辑框中输入了字符",
        1173     IDSTR(CBEM_INSERTITEM),"向CComboBoxEx控件插入一个条目,相关结构:COMBOBOXEXITEM",
        1174     IDSTR(CBEM_SETEXTENDEDSTYLE),"设置CComboBoxEx控件的扩展风格",
        1175     IDSTR(CBEM_SETIMAGELIST),"设置CComboBoxEx控件使用的图像列表",
        1176     IDSTR(CBEM_SETITEM),"设置CComboBoxEx控件中某条目的属性,相关结构:COMBOBOXEXITEM",
        1177     IDSTR(CBEM_SETUNICODEFORMAT),"设置CComboBoxEx控件的UNICODE格式标志",
        1178 
        1179     //ComboBoxEx Control,扩展组合框控件通知消息
        1180     IDSTR(CBEN_BEGINEDIT),"用户激活下拉列表或点击CComboBoxEx控件的编辑框,相关结构:NMHDR",
        1181     IDSTR(CBEN_DELETEITEM),"CComboBoxEx控件的某条目已被删除,相关结构:NMCOMBOBOXEX",
        1182     IDSTR(CBEN_DRAGBEGIN),"用户开始拖动CComboBoxEx控件的编辑框中的条目图像,相关结构:NMCBEDRAGBEGIN",
        1183     IDSTR(CBEN_ENDEDIT),"用户已结束对CComboBoxEx控件的编辑框的操作或选择了下拉列表,相关结构:NMCBEENDEDIT",
        1184     IDSTR(CBEN_GETDISPINFO),"获取CComboBoxEx控件的回调条目的显示信息,相关结构:NMCOMBOBOXEX",
        1185     IDSTR(CBEN_INSERTITEM),"一个新条目已插入到CComboBoxEx控件,相关结构:NMCOMBOBOXEX", 
        1186 
        1187     //AppBar,应用桌面工具栏消息
        1188     IDSTR(ABM_ACTIVATE),"通知系统AppBar已被激活,相关结构:APPBARDATA",
        1189     IDSTR(ABM_GETAUTOHIDEBAR),"获取在屏幕某边自动隐藏的AppBar的句柄",
        1190     IDSTR(ABM_GETSTATE),"获取自动隐藏且置顶的任务栏的状态",
        1191     IDSTR(ABM_GETTASKBARPOS),"获取任务栏的边界矩形",
        1192     IDSTR(ABM_NEW),"注册一个新的AppBar,并指定一个让系统发送通知消息的消息ID",
        1193     IDSTR(ABM_QUERYPOS),"为AppBar请求大小与屏幕坐标",
        1194     IDSTR(ABM_REMOVE),"反注册一个AppBar(使之从系统内部列表中去除)",
        1195     IDSTR(ABM_SETAUTOHIDEBAR),"注册(或反注册)一个在屏幕某边自动隐藏的AppBar",
        1196     IDSTR(ABM_SETPOS),"为一个AppBar设置大小与屏幕坐标",
        1197     IDSTR(ABM_WINDOWPOSCHANGED),"通知系统一个AppBar的屏幕坐标已被改变",
        1198 
        1199     //appbar,应用桌面工具栏通知消息
        1200     IDSTR(ABN_FULLSCREENAPP),"通知一个AppBar:某全屏应用程序正在打开或关闭",
        1201     IDSTR(ABN_POSCHANGED),"通知一个AppBar:一个可能会被到AppBar的大小与位置的事件已经发生",
        1202     IDSTR(ABN_STATECHANGE),"通知一个AppBar:任务栏自动隐藏或置顶状态已被改变",
        1203     IDSTR(ABN_WINDOWARRANGE),"通知一个AppBar:用户已从任务栏的上下文菜单中选择了层叠或平铺",
        1204 
        1205     //Control Panel,控制面板消息
        1206     IDSTR(CPL_DBLCLK),"用户双击控制面板中某组件图标时向该组件所在CPL库发送本消息,CPlApplet相关",
        1207     IDSTR(CPL_EXIT),"控制面板关闭时会对各组件发送CPL_STOP消息,接着对各CPL库发送本消息,此时CPL库释放在CPL_INIT消息中分配的内存和资源",
        1208     IDSTR(CPL_GETCOUNT),"获取控制面板程序数量",
        1209     IDSTR(CPL_INIT),"发送本消息以指示CPL库作初始化工作",
        1210     IDSTR(CPL_INQUIRE),"Windows3.x适用,获取各组件的图标、名称和提示信息,CPL库可在处理这条消息时依次初始化各组件的对话框",
        1211     IDSTR(CPL_NEWINQUIRE),"获取各组件的图标、名称和提示信息,CPL库可在处理这条消息时依次初始化各组件的对话框",
        1212     IDSTR(CPL_SELECT),"基于WIN32的CPL库已废除本消息",
        1213     IDSTR(CPL_STOP),"控制面板关闭时会对各组件发送CPL_STOP消息,接着对各CPL库发送本消息,此时CPL库释放在CPL_INIT消息中分配的内存和资源",
        1214     IDSTR(WM_CPL_LAUNCH),"请求启动某控制面板程序",
        1215     IDSTR(WM_CPL_LAUNCHED),"某控制面板程序已启动",
        1216 
        1217     //File Manager,文件管理器消息
        1218     IDSTR(FM_GETDRIVEINFO),"从文件管理器窗口获取驱动器信息(总空间大小或空闲空间大小等)",
        1219     IDSTR(FM_GETFILESEL),"获取文件管理器(目录窗口或搜索结果窗口)中已选择文件的信息",
        1220     IDSTR(FM_GETFILESELLFN),"获取文件管理器(目录窗口或搜索结果窗口)中已选择文件的信息(包含长文件名)",
        1221     IDSTR(FM_GETFOCUS),"获取拥有焦点的文件管理器窗口的类型(如:返回FMFOCUS_SEARCH表示搜索结果窗口拥有当前焦点)",
        1222     IDSTR(FM_GETSELCOUNT),"获取文件管理器(目录窗口或搜索结果窗口)中已选择的文件数量",
        1223     IDSTR(FM_GETSELCOUNTLFN),"获取文件管理器(目录窗口或搜索结果窗口)中已选择的文件数量(包含长文件名)",
        1224     IDSTR(FM_REFRESH_WINDOWS),"刷新文件管理器激活窗(或所有窗口)时发送本消息给扩展DLL",
        1225     IDSTR(FM_RELOAD_EXTENSIONS),"使文件管理器重载所有(在Winfile.ini的AddOns节列出的)扩展DLL",
        1226     IDSTR(FMEVENT_HELPMENUITEM),"用户在某菜单或工具栏按钮上按下<F1>时向文件管理器扩展DLL发送本消息",
        1227     IDSTR(FMEVENT_HELPSTRING),"文件管理器需要为某菜单或工具栏按钮设置帮助字符串时向扩展DLL发送本消息",
        1228     IDSTR(FMEVENT_INITMENU),"用户从文件管理器的菜单选择了扩展菜单时向扩展DLL发送本消息",
        1229     IDSTR(FMEVENT_LOAD),"文件管理器加载扩展DLL时发送,如:扩展功能菜单等",
        1230     IDSTR(FMEVENT_SELCHANGE),"用户在文件管理器的目录窗口或搜索结果窗口中选择了文件名时向扩展DLL发送本消息",
        1231     IDSTR(FMEVENT_TOOLBARLOAD),"文件管理器在加载其工具栏时向扩展DLL发送本消息",
        1232     IDSTR(FMEVENT_UNLOAD),"文件管理器卸载扩展DLL时发送",
        1233     IDSTR(FMEVENT_USER_REFRESH),"用户在文件管理器的\"视图\"中选择了刷新菜单项时发送本消息给扩展DLL",
        1234 
        1235     //系统托盘消息
        1236     IDSTR(NIM_ADD),"添加图标到系统托盘,相关结构:NOTIFYICONDATA",
        1237     IDSTR(NIM_DELETE),"从系统托盘删除图标,相关结构:NOTIFYICONDATA",
        1238     IDSTR(NIM_MODIFY),"修改系统托盘中的图标、提示或通知消息的ID,相关结构:NOTIFYICONDATA",
        1239 
        1240     //Common Control,控件的公共通知消息
        1241     IDSTR(NM_CHAR),"字符键被处理后由控件发送,相关结构:NMCHAR",
        1242     IDSTR(NM_CLICK),"通知父窗:用户在控件上点击了鼠标左键,相关结构:NMHDR",
        1243     IDSTR(NM_DBLCLK),"通知父窗:用户在控件上双击了鼠标左键,相关结构:NMHDR",
        1244     IDSTR(NM_HOVER),"用户的鼠标掠过控件,相关结构:NMHDR",
        1245     IDSTR(NM_KEYDOWN),"控件获得键盘焦点并按下某键,相关结构:NMKEY",
        1246     IDSTR(NM_KILLFOCUS),"通知父窗:用户失去输入焦点,相关结构:NMHDR",
        1247     IDSTR(NM_NCHITTEST),"控件收到WM_NCHITTEST消息,相关结构:NMMOUSE",
        1248     IDSTR(NM_OUTOFMEMORY),"通知父窗:内存不足,操作不能完成,相关结构:NMHDR",
        1249     IDSTR(NM_RCLICK),"通知父窗:用户在控件上点击了鼠标右键,相关结构:NMHDR",
        1250     IDSTR(NM_RDBLCLK),"通知父窗:用户在控件上双击了鼠标右键,相关结构:NMHDR",
        1251     IDSTR(NM_RELEASEDCAPTURE),"通知父窗:控件要释放鼠标捕捉,相关结构:NMHDR",
        1252     IDSTR(NM_RETURN),"通知父窗:控件获得键盘焦点并按下回车键,相关结构:NMHDR",
        1253     IDSTR(NM_SETCURSOR),"通知父窗:控件响应WM_SETCURSOR要设置光标,相关结构:NMMOUSE",
        1254     IDSTR(NM_SETFOCUS),"通知父窗:控件收到输入焦点,相关结构:NMHDR",
        1255     IDSTR(NM_TOOLTIPSCREATED),"通知父窗:控件已创建一个工具提示控件,相关结构:NMTOOLTIPSCREATED",
        1256 
        1257     //Up-Down Control(Spin Control),微调按钮消息
        1258     IDSTR(UDM_GETACCEL),"获取旋转按钮的加速信息,相关结构:UDACCEL",
        1259     IDSTR(UDM_GETBASE),"获取旋转按钮的当前基数",
        1260     IDSTR(UDM_GETBUDDY),"获取旋转按钮的当前伙伴窗口的句柄",
        1261     IDSTR(UDM_GETPOS),"获取旋转按钮当前位置(根据伙伴窗口的标题获得返回值)",
        1262     IDSTR(UDM_GETRANGE),"获取旋转按钮的上下限范围",
        1263     IDSTR(UDM_GETRANGE32),"获取旋转按钮的上下限范围(32位DWORD值)",
        1264     IDSTR(UDM_GETUNICODEFORMAT),"获取旋转按钮的UNICODE格式标志",
        1265     IDSTR(UDM_SETACCEL),"设置旋转按钮的加速信息,相关结构:UDACCEL",
        1266     IDSTR(UDM_SETBASE),"设置旋转按钮的基数",
        1267     IDSTR(UDM_SETBUDDY),"为旋转按钮设置伙伴窗口",
        1268     IDSTR(UDM_SETPOS),"设置旋转按钮的当前位置",
        1269     IDSTR(UDM_SETRANGE),"设置旋转按钮的上下限范围",
        1270     IDSTR(UDM_SETRANGE32),"设置旋转按钮的上下限范围(32位DWORD值)",
        1271     IDSTR(UDM_SETUNICODEFORMAT),"设置旋转按钮的UNICODE格式标志" ,
        1272 
        1273     //Up-Down Control(Spin Control),微调按钮(旋转按钮)通知消息
        1274     IDSTR(UDN_DELTAPOS),"微调按钮控件的位置将要改变(向其父窗口发送),相关结构:NMUPDOWN" ,
        1275 
        1276     //Video Capture,视频采集(捕捉)消息
        1277     IDSTR(WM_CAP_ABORT),"终止视频数据采集操作,宏:capCaptureAbort",
        1278     IDSTR(WM_CAP_DLG_VIDEOCOMPRESSION),"显示视频采集压缩器选择对话框,宏:apDlgVideoCompression",
        1279     IDSTR(WM_CAP_DLG_VIDEODISPLAY),"显示视频输出调节对话框(包含控制显示的图像的色调、亮度控件),宏:capDlgVideoDisplay",
        1280     IDSTR(WM_CAP_DLG_VIDEOFORMAT),"显示视频格式选择对话框(选择图像尺寸、位深度和硬压缩选项）,宏:capDlgVideoFormat",
        1281     IDSTR(WM_CAP_DLG_VIDEOSOURCE),"显示一个对话框,在该对话框中可选择视频资源,包括视频输入资源,宏:capDlgVideoSource",
        1282     IDSTR(WM_CAP_DRIVER_CONNECT),"将视频捕获窗口与其驱动相连接,宏:capDriverConnect",
        1283     IDSTR(WM_CAP_DRIVER_DISCONNECT),"将视频捕捉窗口与驱动断开,宏:capDriverDisconnect",
        1284     IDSTR(WM_CAP_DRIVER_GET_CAPS),"获取视频捕获驱动及其硬件性能参数(信息保存在CAPDRIVERCAPS结构中),宏:capDriverGetCaps",
        1285     IDSTR(WM_CAP_DRIVER_GET_NAME),"获取连接到视频捕获窗口的驱动名称,宏:capDriverGetName",
        1286     IDSTR(WM_CAP_DRIVER_GET_VERSION),"获取连接到视频捕获窗口的驱动版本,宏:capDriverGetVersion",
        1287     IDSTR(WM_CAP_EDIT_COPY),"视频采集时,从帧缓存区拷贝一幅图像到剪贴板,宏:capEditCopy",
        1288     IDSTR(WM_CAP_FILE_ALLOCATE),"为视频捕获文件预分配磁盘空间(可减少数据保存时的处理时间),宏:capFileAlloc",
        1289     IDSTR(WM_CAP_FILE_GET_CAPTURE_FILE),"获取当前视频采集文件名,宏:capFileGetCaptureFile",
        1290     IDSTR(WM_CAP_FILE_SAVEAS),"另存视频捕获数据到一个新文件,宏:capFileSaveAs",
        1291     IDSTR(WM_CAP_FILE_SAVEDIB),"将视频捕获数据缓存区的一幅图像拷贝至一张DIB位图中,宏:capFileSaveDIB",
        1292     IDSTR(WM_CAP_FILE_SET_CAPTURE_FILE),"指定视频捕获文件名(本消息并不实际创建文件),宏:capFileSetCaptureFile",
        1293     IDSTR(WM_CAP_FILE_SET_INFOCHUNK),"设置或清除AVI文件中插入的信息块(如文本或自定义数据),宏:capFileSetInfoChunk",
        1294     IDSTR(WM_CAP_GET_AUDIOFORMAT),"获得当前音频数据格式或音频数据结构的大小(默认格式是mono,8 bit,11 kHz PCM),宏:capGetAudioFormat/capGetAudioFormatSize ",
        1295     IDSTR(WM_CAP_GET_MCI_DEVICE),"获得当前使用的视频采集设备MCI驱动名称, 宏:capGetMCIDeviceName",
        1296     IDSTR(WM_CAP_GET_SEQUENCE_SETUP),"获取当前视频捕获的帧频率(每秒捕获几帧),宏:capCaptureGetSetup",
        1297     IDSTR(WM_CAP_GET_STATUS),"获得当前视频捕获窗口的状态,宏:capGetStatus",
        1298     IDSTR(WM_CAP_GET_USER_DATA),"获取关联到一个视频捕获窗口的数据(长整型值),宏:capGetUserData ",
        1299     IDSTR(WM_CAP_GET_VIDEOFORMAT),"获取包含视频格式的结构体或视频格式大小(其实就是BITMAPINFO),宏:capGetVideoForma/capGetVideoFormatSize",
        1300     IDSTR(WM_CAP_GRAB_FRAME),"从视频采集驱动获取并显示一个单独的帧(静态图像),宏:capGrabFrame",
        1301     IDSTR(WM_CAP_GRAB_FRAME_NOSTOP),"视频捕捉,填充未压缩的单帧图像到帧缓存区并显示之(与WM_CAP_GRAB_FRAME不同:覆盖或预览状态不会改变),宏:capGrabFrameNoStop",
        1302     IDSTR(WM_CAP_PAL_AUTOCREATE),"请求视频信号取样帧及自动创建与调色板,宏:capPaletteAuto",
        1303     IDSTR(WM_CAP_PAL_MANUALCREATE),"请求视频信号手工取样帧及创建自定义的调色板(替换默认的调色板),宏:capPaletteAuto",
        1304     IDSTR(WM_CAP_PAL_OPEN),"从调色板文件中加载一个调色板,宏:capPaletteOpen",
        1305     IDSTR(WM_CAP_PAL_PASTE),"从剪切板中拷贝加载一个调色板,宏:capPalettePaste",
        1306     IDSTR(WM_CAP_PAL_SAVE),"保存调色板至调色板文件,宏:capPaletteSave",
        1307     IDSTR(WM_CAP_SEQUENCE),"开始视频与音频的捕获(到文件),宏:capCaptureSequence",
        1308     IDSTR(WM_CAP_SEQUENCE_NOFILE),"开始视频与音频的捕获(不写入文件),宏:capCaptureSequenceNoFile",
        1309     IDSTR(WM_CAP_SET_AUDIOFORMAT),"设置音频数据捕获格式,宏:capSetAudioFormat",
        1310     IDSTR(WM_CAP_SET_CALLBACK_CAPCONTROL),"指定回调函数用于控制捕获的开始和结束,宏:capSetCallbackOnCapControl",
        1311     IDSTR(WM_CAP_SET_CALLBACK_ERROR),"在应用程序中指定回调函数(出错时就调用它),宏:capSetCallbackOnError",
        1312     IDSTR(WM_CAP_SET_CALLBACK_FRAME),"在应用程序中指定回调函数(当预览图像帧被捕获了的时候就调用它),宏:capSetCallbackOnFrame",
        1313     IDSTR(WM_CAP_SET_CALLBACK_STATUS),"在应用程序中指定回调函数(当状态改变时就调用它),宏:capSetCallbackOnStatus",
        1314     IDSTR(WM_CAP_SET_CALLBACK_VIDEOSTREAM),"在应用程序中指定回调函数(在流捕获期间,当一个新的视频缓存区可用时就调用它),宏:capSetCallbackOnVideoStream ",
        1315     IDSTR(WM_CAP_SET_CALLBACK_WAVESTREAM),"在应用程序中指定回调函数(在流捕获期间,当一个新的音频缓存区可用时就调用它),宏:capSetCallbackOnWaveStream",
        1316     IDSTR(WM_CAP_SET_CALLBACK_YIELD),"流捕获期间可使用Yield回调函数(Yield回调函数由消息循环组成),每次捕获视频帧时至少调用一次Yield,具体视帧速率决定,宏:capSetCallbackOnYield",
        1317     IDSTR(WM_CAP_SET_MCI_DEVICE),"指定要选定的MCI设备名称(如:一张影碟或一盘录像带来充当视频源),宏:capSetMCIDeviceName",
        1318     IDSTR(WM_CAP_SET_OVERLAY),"打开覆盖模式(将自动关闭预览模式),覆盖模式:不占用CPU资源,直接在显示器上显示视频(由捕获设备硬件来完成),宏:capOverlay",
        1319     IDSTR(WM_CAP_SET_PREVIEW),"打开或关闭预览模式,宏:capPreview",
        1320     IDSTR(WM_CAP_SET_PREVIEWRATE),"设置预览模式下图像的帧速度,宏:capPreviewRate",
        1321     IDSTR(WM_CAP_SET_SCALE),"打开或关闭预览视频的缩放比例,宏:capPreviewScale",
        1322     IDSTR(WM_CAP_SET_SCROLL),"设置视频帧的滚动条的位置(预览模式或叠加模式),宏:capSetScrollPos",
        1323     IDSTR(WM_CAP_SET_SEQUENCE_SETUP),"设置流捕捉时的配置参数,刷新CAPTUREPARMS结构,宏:capCaptureSetSetup",
        1324     IDSTR(WM_CAP_SET_USER_DATA),"关联数据(长整型值)到一个视频捕获窗口,宏:capSetUserData",
        1325     IDSTR(WM_CAP_SET_VIDEOFORMAT),"对视频格式进行修改设置,宏:capSetVideoFormat",
        1326     IDSTR(WM_CAP_SINGLE_FRAME),"指定捕获视频流中的个别帧,宏:capCaptureSingleFrame",
        1327     IDSTR(WM_CAP_SINGLE_FRAME_CLOSE),"关闭单帧捕获文件,宏:capCaptureSingleFrameClose",
        1328     IDSTR(WM_CAP_SINGLE_FRAME_OPEN),"打开单帧捕获文件,宏:capCaptureSingleFrameOpen",
        1329     IDSTR(WM_CAP_STOP),"停止视频捕获操作,宏:capCaptureStop",
        1330 
        1331     //Common Dialog Box,通用对话框消息
        1332     //Font dialog box,字体通用对话框
        1333     IDSTR(WM_CHOOSEFONT_GETLOGFONT),"获取字体通用对话框中用户当前字体选择信息,相关结构:LOGFONT",
        1334     IDSTR(WM_CHOOSEFONT_SETFLAGS),"设置字体通用对话框的显示选项,相关结构:CHOOSEFONT",
        1335     IDSTR(WM_CHOOSEFONT_SETLOGFONT),"设置字体通用对话框中用户当前字体信息,相关结构:LOGFONT",
        1336 
        1337     //Page Setup dialog,页面设置通用对话框
        1338     IDSTR(WM_PSD_ENVSTAMPRECT),"通知钩子函数:页面设置对话框要在信封样本页上绘制邮票区",
        1339     IDSTR(WM_PSD_FULLPAGERECT),"通知PagePaintHook钩子函数:页面设置对话框上样本页的整个页面区的坐标",
        1340     IDSTR(WM_PSD_GREEKTEXTRECT),"通知钩子函数:页面设置对话框要在样本页上绘制页面内容",
        1341     IDSTR(WM_PSD_MARGINRECT),"通知钩子函数:页面设置对话框将要绘制样本页样本页的的当前边距",
        1342     IDSTR(WM_PSD_MINMARGINRECT),"通知PagePaintHook钩子函数:页面设置对话框上样本页的当前最小边距",
        1343     IDSTR(WM_PSD_PAGESETUPDLG),"页面设置对话框将要绘制样本页,钩子函数利用此消息准备供给样本页里的内容",
        1344     IDSTR(WM_PSD_YAFULLPAGERECT),"页面设置对话框将要绘制信封样本页的返回地址部分,此消息仅发向信封和其它纸张大小",
        1345 
        1346     //Open or Save As dialog box,打开保存为通用对话框
        1347     IDSTR(CDM_GETFILEPATH),"获得打开保存为通用对话框中被选择文件的路径和文件名",
        1348     IDSTR(CDM_GETFOLDERIDLIST),"从打开保存为通用对话框获得当前文件夹的PIDL(外壳对象标志符列表),注:外壳编程中,要使用PIDL路径代替普通路径",
        1349     IDSTR(CDM_GETFOLDERPATH),"获得打开保存为通用对话框中当前打开文件夹的路径",
        1350     IDSTR(CDM_GETSPEC),"获得打开保存为通用对话框中被选择文件的文件名(不含路径)",
        1351     IDSTR(CDM_HIDECONTROL),"隐藏打开保存为通用对话框(OFN_EXPLORER)中的指定控件",
        1352     IDSTR(CDM_SETCONTROLTEXT),"为保存为通用对话框(OFN_EXPLORER)中的指定控件设置文本",
        1353     IDSTR(CDM_SETDEFEXT),"为保存为通用对话框(OFN_EXPLORER)中设置缺省文件扩展名",
        1354 
        1355     //Open or Save As dialog box can send to a hook procedure,打开另存为通用对话框的HOOK相关消息
        1356     IDSTR(CDN_FILEOK),"打开另存为通用对话框向OFNHookProc钩子函数发送确定按钮被按下的消息",
        1357     IDSTR(CDN_FOLDERCHANGE),"打开另存为通用对话框向OFNHookProc钩子函数发送一个新文件夹被打开的消息",
        1358     IDSTR(CDN_HELP),"打开另存为通用对话框中的帮助按钮被按下时发送本消息到OFNHookProc钩子函数",
        1359     IDSTR(CDN_INITDONE),"系统已完成在打开另存为通用对话框中排列控件(为子对话框的控件腾出空间)时发送本消息到OFNHookProc钩子函数",
        1360     IDSTR(CDN_SELCHANGE),"用户在打开另存为对话框中的文件列表里选择了一个新文件或文件夹时发送本消息到OFNHookProc钩子函数",
        1361     IDSTR(CDN_SHAREVIOLATION),"当用户选择的文件名发生网络共享冲突时打开另存为对话框发送本消息(共享违例)到OFNHookProc钩子函数",
        1362     IDSTR(CDN_TYPECHANGE),"打开另存为对话框中从文件类型列表中选择一个新文件类型时发送本消息到OFNHookProc钩子函数",
        1363 
        1364     //Dialog box default push button,对话框缺省按钮消息
        1365     IDSTR(DM_GETDEFID),"获取对话框中缺省按钮的ID号",
        1366     IDSTR(DM_REPOSITION),"使一个(顶层窗口且非chind窗口)对话框回到桌面(屏幕)中,使整个对话框可视",
        1367     IDSTR(DM_SETDEFID),"改变对话框中缺省按钮的ID号",
        1368 
        1369     //TAPI:电话应用程序接口消息
        1370 
        1371     //Remote Access Service Messages,RAS(远程访问服务)消息,主要用于远程拨号(ADSL宽带拨号等)和VPN(虚拟专用网络)
        1372     IDSTR(WM_RASDIALEVENT),"拨号事件通知消息,RAS连接期间状态事件发生改变时,系统发送本消息到相关窗口",
        1373 
        1374     //输入法编辑器消息
        1375     IDSTR(IMC_CLOSESTATUSWINDOW),"发送给IME窗口,隐藏状态窗口",
        1376     IDSTR(IMC_GETCANDIDATEPOS),"发送给IME窗口,获取候选窗口的位置",
        1377     IDSTR(IMC_GETCOMPOSITIONFONT),"发送给IME窗口,获取用来显示按键组合窗口中的文本的逻辑字体",
        1378     IDSTR(IMC_GETCOMPOSITIONWINDOW),"发送给IME窗口,获取按键组合窗口的位置",
        1379     IDSTR(IMR_COMPOSITIONWINDOW),"通知:选定的IME需要应用程序提供有关按键组合窗口的信息",
        1380     IDSTR(IMR_DOCUMENTFEED),"通知:选定的IME需要从应用程序那里取得已转换的字符串",
        1381     IDSTR(IMR_QUERYCHARPOSITION),"通知:选定的IME需要应用程序提供有关组合字符串中某个字符的位置信息",
        1382     IDSTR(IMR_COMPOSITIONFONT),"通知:选定的IME需要应用程序提供有关用在按键组合窗口中的字体信息",
        1383     IDSTR(IMR_CONFIRMRECONVERTSTRING),"通知:选定的IME需要应用程序提供有关组合字符串中某个字符的位置信息",
        1384     IDSTR(IMR_RECONVERTSTRING),"通知:选定的IME需要应用程序提供一个用于自动更正的字符串",
        1385     IDSTR(IMR_CANDIDATEWINDOW),"通知:选定的IME需要应用程序提供有关候选窗口的信息",
        1386 
        1387     //IDSTR(IMC_GETOPENSTATUS),"",
        1388     //IDSTR(IMC_GETSENTENCEMODE),"",
        1389     IDSTR(IMC_GETSTATUSWINDOWPOS),"发送给IME窗口,获取状态窗口的位置",
        1390     IDSTR(IMC_OPENSTATUSWINDOW),"发送给IME窗口,显示状态窗口",
        1391     IDSTR(IMC_SETCANDIDATEPOS),"发送给IME窗口,设置候选窗口的位置",
        1392     IDSTR(IMC_SETCOMPOSITIONFONT),"发送给IME窗口,设置用来显示按键组合窗口中的文本的逻辑字体",
        1393     IDSTR(IMC_SETCOMPOSITIONWINDOW),"发送给IME窗口,设置按键组合窗口的样式",
        1394 
        1395     //IDSTR(IMC_SETCONVERSIONMODE),"",
        1396     //IDSTR(IMC_SETOPENSTATUS),"",
        1397     //IDSTR(IMC_SETSENTENCEMODE),"",
        1398     IDSTR(IMC_SETSTATUSWINDOWPOS),"发送给IME窗口,设置状态窗口的位置",
        1399     IDSTR(IMN_CHANGECANDIDATE),"IME通知应用程序:候选窗口中的内容将改变",
        1400     IDSTR(IMN_CLOSECANDIDATE),"IME通知应用程序:候选窗口将关闭",
        1401     IDSTR(IMN_CLOSESTATUSWINDOW),"IME通知应用程序:状态窗口将关闭",
        1402     IDSTR(IMN_GUIDELINE),"IME通知应用程序:将显示一条出错或其他信息",
        1403     IDSTR(IMN_OPENCANDIDATE),"IME通知应用程序:将打开候选窗口",
        1404     IDSTR(IMN_OPENSTATUSWINDOW),"IME通知应用程序:将创建状态窗口",
        1405     IDSTR(IMN_SETCANDIDATEPOS),"IME通知应用程序:已结束候选处理同时将移动候选窗口",
        1406     IDSTR(IMN_SETCOMPOSITIONFONT),"IME通知应用程序:输入内容的字体已被更改",
        1407     IDSTR(IMN_SETCOMPOSITIONWINDOW),"IME通知应用程序:按键组合窗口的样式或位置已被更改",
        1408     IDSTR(IMN_SETCONVERSIONMODE),"IME通知应用程序:输入内容的转换模式已被更改",
        1409     IDSTR(IMN_SETOPENSTATUS),"IME通知应用程序:输入内容的状态已被更改",
        1410     IDSTR(IMN_SETSENTENCEMODE),"IME通知应用程序:输入内容的语句模式已被更改",
        1411     IDSTR(IMN_SETSTATUSWINDOWPOS),"IME通知应用程序:输入内容中的状态窗口的位置已被更改",
        1412     //IDSTR(IMR_CANDIDATEFORM),"",
        1413 
        1414     //IDSTR(IMR_COMPOSITIONFORM),"",
        1415 
        1416 
        1417     //Pager Control,Pager控件消息,分页控件消息
        1418     IDSTR(PGM_FORWARDMOUSE),"启用或禁用Pager分页控件的鼠标消息转发,若启用则Pager控件转发WM_MOUSEMOVE消息给包含的窗口,宏:Pager_ForwardMouse",
        1419     IDSTR(PGM_GETBKCOLOR),"获取Pager分页控件的当前背景色,宏:Pager_GetBkColor",
        1420     IDSTR(PGM_GETBORDER),"获取Pager分页控件的当前边界尺寸,宏:Pager_GetBorder",
        1421     IDSTR(PGM_GETBUTTONSIZE),"获取Pager分页控件的当前按钮大小,宏:Pager_GetButtonSize",
        1422     IDSTR(PGM_GETBUTTONSTATE),"获取Pager分页控件中指定按钮的状态,宏:Pager_GetButtonState",
        1423     IDSTR(PGM_GETDROPTARGET),"获取Pager分页控件的IDropTarget接口指针,宏:Pager_GetDropTarget",
        1424     IDSTR(PGM_GETPOS),"获取Pager分页控件的滚动条的当前位置,宏:Pager_GetPos",
        1425     IDSTR(PGM_RECALCSIZE),"强制重新计算Pager分页控件包含的窗口的大小,宏:Pager_RecalcSize",
        1426     IDSTR(PGM_SETBKCOLOR),"设置Pager分页控件的当前背景色,宏:Pager_SetBkColor",
        1427     IDSTR(PGM_SETBORDER),"设置Pager分页控件的当前边界尺寸,宏:Pager_SetBorder",
        1428     IDSTR(PGM_SETBUTTONSIZE),"设置Pager分页控件的当前按钮大小,宏:Pager_SetButtonSize",
        1429     IDSTR(PGM_SETCHILD),"设置Pager分页控件中包含的窗口,宏:Pager_SetChild",
        1430     IDSTR(PGM_SETPOS),"获取Pager分页控件的滚动条的当前位置,宏:Pager_SetPos",
        1431 
        1432     //Pager Control,Pager控件通知消息
        1433     IDSTR(PGN_CALCSIZE),"Pager控件发送的通知消息,用以获得所包含窗口的滚动尺寸,相关结构:NMPGCALCSIZE",
        1434     IDSTR(PGN_SCROLL),"在所包含窗口被滚动之前,Pager控件发送的通知消息,相关结构:NMPGSCROLL",
        1435 
        1436     //MIDI消息
        1437     IDSTR(MIM_CLOSE),"当MIDI输入设备被关闭时,把该消息发送给MIDI输入回调函数",
        1438     IDSTR(MIM_DATA),"当MIDI输入设备接收一条MIDI消息后,把该消息发送给MIDI输入回调函数",
        1439     IDSTR(MIM_ERROR),"当收到一条无效的MIDI消息时,把该消息发送给MIDI输入回调函数",
        1440     IDSTR(MIM_LONGDATA),"当输入缓冲区中填写了MIDI系统专用数据且将把该缓冲区交还给应用程序时,发送该消息给MIDI回调函数",
        1441     IDSTR(MIM_LONGERROR),"当收到一条无效的MIDI系统专用消息时,把该消息发送给一个MIDI输入回调函数",
        1442     IDSTR(MIM_MOREDATA),"当MIDI输入设备收到一条MIDI消息,但应用程序处理MIM_DATA消息不够快跟不上输入设备时,发送该消息给MIDI输入回调函数",
        1443     IDSTR(MIM_OPEN),"当MIDI输入设备被打开时,把该消息发送给MIDI输入回调函数",
        1444     IDSTR(MM_MIM_CLOSE),"当关闭某MIDI输入设备时,发送该消息给一个窗口。一旦发送了该消息,设备句柄将不再有效",
        1445     IDSTR(MM_MIM_DATA),"当MIDI输入设备收到一条完整的MIDI消息时,发送该消息给一个窗口",
        1446     IDSTR(MM_MIM_ERROR),"当收到一条无效的MIDI消息时,把该消息发给一个窗口",
        1447     IDSTR(MM_MIM_LONGDATA),"当输入缓冲区中填写了MIDI系统专用数据且将把该缓冲区交还给应用程序时,发送该消息给一个窗口",
        1448     IDSTR(MM_MIM_LONGERROR)," 当收到一条无效的(或不完整的)MIDI系统专用消息时,发送该消息给一个窗口",
        1449     IDSTR(MM_MIM_MOREDATA),"当MIDI输入设备收到一条MIDI消息,但应用程序处理MIM_DATA消息不够快跟不上输入设备时,发送该消息给一个回调窗口",
        1450     IDSTR(MM_MIM_OPEN),"当MIDI输入设备被打开时,发送该消息给一个窗口",
        1451     IDSTR(MM_MOM_CLOSE),"当MIDI输出设备被关闭时,发送该消息给一个窗口;一旦发送了这一消息,设备句柄将不再有效",
        1452     IDSTR(MM_MOM_DONE),"当指定的系统专用缓冲区中的内容被播放完,并且将把该缓冲区交还给应用程序时,发送该消息给一个MIDI回调函数",
        1453     IDSTR(MM_MOM_OPEN),"当MIDI输出设备被打开时,发送该消息给一个窗口",
        1454     IDSTR(MM_MOM_POSITIONCB),"当在MIDI输出流中一个MEVT_F_CALLBACK(标志)事件到达时,发送该消息给一个窗口",
        1455     IDSTR(MOM_CLOSE),"当MIDI输出设备被关闭时,把该消息发送给MIDI输出回调函数",
        1456     IDSTR(MOM_DONE),"当指定的专用系统或流缓冲区已经播放,并且正在返回到应用程序时,发送该信息到MIDI输出回调函数",
        1457     IDSTR(MOM_OPEN),"当MIDI输出设备被打开时,把该消息发送给MIDI输出回调函数",
        1458     IDSTR(MOM_POSITIONCB),"当在MIDI输出流中一个MEVT_F_CALLBACK(标志)事件到达时,发送该消息给一个窗口", 
        1459 
        1460     //驱动程序消息
        1461     IDSTR(DRV_CLOSE),"驱动程序因CloseDriver调用而关闭时,系统向它发出本消息,驱动程序常使用DRV_CLOSE通知来释放特定实例的数据结构",
        1462     IDSTR(DRV_CONFIGURE),"驱动程序完成初始化安装及每当用户要重新配置驱动程序时,驱动安装程序会发送该消息",
        1463     IDSTR(DRV_DISABLE),"驱动程序被释放或由Windows进入DOS时,向驱动程序发DRV_DISABLE消息",
        1464     IDSTR(DRV_ENABLE),"当驱动程序首次加载后,系统向它发DRV_ENABLE消息,利用该消息设置硬件并挂接中断",
        1465     IDSTR(DRV_EXITSESSION),"系统退出前,向所有打开的驱动程序发出该消息",
        1466     IDSTR(DRV_FREE),"驱动程序被丢弃前,系统发送给它的最后一个消息就是DRV_FREE",
        1467     IDSTR(DRV_INSTALL),"驱动程序安装过程中,它将收到该消息",
        1468     IDSTR(DRV_LOAD),"驱动程序首次加载后,系统发送给它的就是DRV_LOAD消息,此时可初始化实例数据",
        1469     IDSTR(DRV_OPEN),"驱动程序被OpenDriver调用打开时,系统向它发该消息",
        1470     IDSTR(DRV_POWER),"在符合APM标准的系统中,当系统将进入或退出挂起模式时,驱动程序将收到DRV_PORWER消息",
        1471     IDSTR(DRV_QUERYCONFIGURE),"驱动程序的安装程序利用该消息来确定驱动程序是否能由用户配置。若该消息返回TURE,安装程序会使能\"configure\"或\"Setup\"按钮",
        1472     IDSTR(DRV_REMOVE),"驱动程序将从安装的驱动程序列表中删除时,将会收到该消息",
        1473     IDSTR(DRV_USER),"用户自定义的驱动程序消息的消息值范围从DRV_RESERVED开始到DRV_USER",
        1474     IDSTR(DRV_EXITAPPLICATION),"应用程序退出时,系统向驱动程序发出该消息",    
        1475     IDSTR(DRV_RESERVED),"用户自定义的驱动程序消息的消息值范围从DRV_RESERVED开始到DRV_USER",
        1476 
        1477     //Power Management,电源管理消息,PBT_:Power BaTtery
        1478     IDSTR(PBT_APMBATTERYLOW),"该消息发送到应用程序,通知BIOS的电池电量不足,窗口通过WM_POWERBROADCAST收到此消息",
        1479     IDSTR(PBT_APMOEMEVENT),"高级电源管理的基本输入/输出系统 (BIOS)发出高级电源管理的OEM事件信号时(APM:高级电源管理),发送本消息,窗口通过WM_POWERBROADCAST收到此消息,注:这不是个统一事件,各OEM厂商会根据自己的判断尝试捕捉各自事件",
        1480     IDSTR(PBT_APMPOWERSTATUSCHANGE),"计算机电源状态改变时,发送本消息,如:检测到电池电源切换A/C或低于一个阈值后的剩余电池电量的下降,窗口通过WM_POWERBROADCAST收到此消息",
        1481     IDSTR(PBT_APMQUERYSUSPEND),"发送该消息以请求允许挂起计算机,授予权限的应用程序应在返回前挂起,窗口通过WM_POWERBROADCAST收到此消息",
        1482     IDSTR(PBT_APMQUERYSUSPENDFAILED),"待机请求被拒绝时,发送该消息,窗口通过WM_POWERBROADCAST收到此消息",
        1483     IDSTR(PBT_APMRESUMEAUTOMATIC),"计算机自动唤醒以处理某事件时,发送该消息,窗口通过WM_POWERBROADCAST收到此消息",
        1484     IDSTR(PBT_APMRESUMECRITICAL),"由于BIOS电池问题使计算机被挂起后恢复操作时,发送该消息,驱动程序通过WM_POWERBROADCAST收到此消息",
        1485     IDSTR(PBT_APMRESUMESUSPEND),"系统待机后恢复运行时,发送该消息,窗口通过WM_POWERBROADCAST收到此消",
        1486     IDSTR(PBT_APMSUSPEND),"系统进入待机后,会立即发送该消息,窗口通过WM_POWERBROADCAST收到此消息",
        1487 
        1488     //setup functions,驱动安装函数消息
        1489     IDSTR(SPFILENOTIFY_COPYERROR),"驱动安装过程中,文件拷贝发生错误时,该通知发送给回调例程",
        1490     IDSTR(SPFILENOTIFY_DELETEERROR),"驱动安装过程中,文件删除操作发生错误时,该通知发送给回调例程",
        1491     IDSTR(SPFILENOTIFY_ENDCOPY),"驱动安装过程中,队列完成复制操作时,该通知传递给回调函数(即使用户取消或有错误发生,该通知也被发送)",
        1492     IDSTR(SPFILENOTIFY_ENDDELETE),"驱动安装过程中,当队列完成删除操作时,该通知被返回给回调例程(即使用户取消或有错误发生,该通知也被发送)",
        1493     IDSTR(SPFILENOTIFY_ENDQUEUE),"驱动安装过程中,队列中的所有作业已完成后,该通知发送给回调例程",
        1494     IDSTR(SPFILENOTIFY_ENDRENAME),"驱动安装过程中,队列完成重命名操作后,该通知发送到回调例程(即使用户取消或有错误发生,该通知也被发送)",
        1495     IDSTR(SPFILENOTIFY_ENDSUBQUEUE),"驱动安装过程中,队列完成子队列中的删除、重命名或拷贝作业后,该通知发送给回调例程",
        1496     IDSTR(SPFILENOTIFY_FILEEXTRACTED),"驱动安装过程中,该通知发送给SetupIterateCabinet函数的回调例程,用以表明已从cab压缩文件中提取出一个文件,或提取失败并且对cab压缩文件的处理已被取消",
        1497     IDSTR(SPFILENOTIFY_FILEINCABINET),"驱动安装过程中,每当cab压缩文件中找到一个文件时,该通知送到SetupIterateCabinet函数的回调例程,回调例程须返回一个值以指示是否提取该文件",
        1498     IDSTR(SPFILENOTIFY_FILEOPDELAYED),"驱动安装过程中,如果文件操作被延时(由于文件在使用中),该通知由SetupInstallFileEx函数或SetupCommitFileQueue函数发送给回调例程,该文件操作将在下次系统重启时被继续处理",
        1499     IDSTR(SPFILENOTIFY_LANGMISMATCH),"驱动安装过程中,若要复制文件的语言不匹配现有目标文件的语言,该通知发送给回调例程,它可被单独或联合发送到回调例程(通过\"或\"操 作:SPFILENOTIFY_TARGETEXISTS 与/或 SPFILENOTIFY_TARGETNEWER)",
        1500     IDSTR(SPFILENOTIFY_NEEDMEDIA),"驱动安装过程中,当需要新的媒介或新的cab压缩文件时,该通知发送给回调例程",
        1501     IDSTR(SPFILENOTIFY_NEEDNEWCABINET),"驱动安装过程中,该通知由SetupIterateCabinet函数发送,用以表明当前文件需有另一个cab压缩文件柜才能继续。您的回调例程可调用SetupPromptForDisk函数,或创建自己的对话框,提示用户去插入下一张磁盘",
        1502     IDSTR(SPFILENOTIFY_QUEUESCAN),"驱动安装过程中,该通知由SetupScanFileQueue函数发送给回调例程,用以检索文件队列的拷贝子队列中的各个节点(只发生在以SPQ_SCAN_USE_CALLBACK标志调用SetupScanFileQueue函数时)",
        1503     IDSTR(SPFILENOTIFY_RENAMEERROR),"驱动安装过程中,若文件重命名操作过程中发生错误时,该通知发送给回调例程",
        1504     IDSTR(SPFILENOTIFY_STARTCOPY),"驱动安装过程中,当队列开始文件拷贝操作时,该通知发送给回调函数",
        1505     IDSTR(SPFILENOTIFY_STARTDELETE),"驱动安装过程中,当队列开始文件删除操作时,该通知发送给回调函数",
        1506     IDSTR(SPFILENOTIFY_STARTQUEUE),"驱动安装过程中,当队列允许进程启动时,该通知发送给回调例程",
        1507     IDSTR(SPFILENOTIFY_STARTRENAME),"驱动安装过程中,当队列开始文件重命名操作时,该通知发送给回调函数",
        1508     IDSTR(SPFILENOTIFY_STARTSUBQUEUE),"驱动安装过程中,当列队开始处理在删除、重命名或拷贝子队列中的作业时,该通知发送给回调函数",
        1509     IDSTR(SPFILENOTIFY_TARGETEXISTS),"驱动安装过程中,如果要拷贝的文件已用SP_COPY_NOOVERWRITE标志进行列队,且该文件在目标目录中已经存在时,该通知发送给回调例程。它可被单独或联合发送到回调例程(通过或操作:SPFILENOTIFY_LANGMISMATCH 与/或 SPFILENOTIFY_TARGETNEWER通知)",
        1510     IDSTR(SPFILENOTIFY_TARGETNEWER),"驱动安装过程中,驱动安装过程中,如果要拷贝的文件已用P_COPY_NEWER或SP_COPY_FORCE_NEWER标志进行列队,且较新版本在文件中已经存在时,该通知发送给回调例程。它可被单独或联合发送到回调例程(通过或操作:SPFILENOTIFY_LANGMISMATCH 与/或 SPFILENOTIFY_TARGETEXISTS通知)",
        1511 
        1512     //TAPI(Telephone Application Programming Interface),电话应用编程接口消息
        1513     // IDSTR(LINE_ADDRESSSTATE),"由应用程序当前已打开的线路的地址状态发生改变时,发送本消息。应用程序可调用lineGetAddressStatus函数以确定该地址的当前状态",
        1514     // IDSTR(LINE_AGENTSPECIFIC),"由应用程序当前已打开的线路的ACD代理的身份发生改变时,发送本消息。应用程序可调用lineGetAgentStatus去确定代理的当前身份",
        1515     // IDSTR(LINE_AGENTSTATUS),"由应用程序当前已打开的线路的ACD代理的身份发生改变时,发送本消息。应用程序可调用lineGetAgentStatus去确定代理的当前身份",
        1516     // IDSTR(LINE_APPNEWCALL),"有呼叫进来(有新来电)",
        1517     // IDSTR(LINE_CALLDEVSPECIFIC),"",
        1518     // IDSTR(LINE_CALLDEVSPECIFICFEATURE),"",
        1519     // IDSTR(LINE_CALLINFO),"呼叫信息,可获取来电去电的很多信息",
        1520     // IDSTR(LINE_CALLSTATE),"呼叫状态(正在拨出/断线/来电/拨通等)",
        */
        #endregion
    }
}
