using Microsoft.Win32;

namespace wyk.basic
{
    /// <summary>
    /// 注册表操作单元
    /// </summary>
    public class RegistryUtil
    {
        /// <summary>
        /// 检测程序是否已设置开机启动
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="path">程序路径</param>
        /// <returns></returns>
        public static bool isAppAutoStart(string name, string path)
        {
            RegistryKey runItem = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (runItem != null)
            {
                try
                {
                    if (runItem.GetValue(name).ToString() == path)
                        return true;
                }
                catch { }
            }
            return false;
        }

        /// <summary>
        /// 设置程序开机启动
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="path">路径</param>
        /// <param name="autostart">是否开机启动</param>
        /// <returns></returns>
        public static bool setAppAutoStart(string name, string path, bool autostart)
        {
            RegistryKey runItem = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (autostart)
            {
                try
                {
                    runItem.SetValue(name, path);
                    return true;
                }
                catch { return false; }
            }
            else
            {
                try
                {
                    runItem.DeleteValue(name);
                    return true;
                }
                catch { return false; }
            }
        }
    }
}