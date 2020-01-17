using System;
using System.Reflection;
using System.Windows.Forms;

namespace wyk.basic
{
    public static class ControlReferedExtention
    {
        public static void click(this Control control)
        {
            control.raiseEvent("OnClick");
        }

        public static void click(this Control control, EventArgs event_args)
        {
            control.raiseEvent("OnClick", event_args);
        }

        public static void raiseEvent(this Control control, string event_name)
        {
            control.raiseEvent(event_name, EventArgs.Empty);
        }

        public static void raiseEvent(this Control control, string event_name, EventArgs event_args)
        {
            try
            {
                Type t = control.GetType();
                object[] p = new object[1];
                MethodInfo m = t.GetMethod(event_name, BindingFlags.NonPublic | BindingFlags.Instance);
                p[0] = event_args;
                m.Invoke(control, p);
            }
            catch { }
        }

        public static void raiseEvent(this Control control, string event_name, MouseEventArgs mouse_event_args)
        {
            try
            {
                Type t = control.GetType();
                object[] p = new object[1];
                MethodInfo m = t.GetMethod(event_name, BindingFlags.NonPublic | BindingFlags.Instance);
                p[0] = mouse_event_args;
                m.Invoke(control, p);
            }
            catch { }
        }

        public static Form parentForm(this Control control)
        {
            Control parent = control;
            while (true)
            {
                parent = parent.Parent;
                if (parent == null)
                    break;
                try
                {
                    return parent as Form;
                }
                catch { }
            }
            return null;
        }
    }
}
