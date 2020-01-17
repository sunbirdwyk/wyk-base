using System.Windows.Forms;

namespace wyk.ui
{
    public static class ControlReferedExtention
    {
        /// <summary>
        /// 获取控件所在的窗体(ExForm)
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static ExFormBasic parentExForm(this Control control)
        {
            Control parent = control;
            while (true)
            {
                parent = parent.Parent;
                if (parent == null)
                    break;
                try
                {
                    return parent as ExFormBasic;
                }
                catch { }
            }
            return null;
        }
    }
}
