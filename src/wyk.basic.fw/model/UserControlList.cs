using System.Collections.Generic;
using System.Windows.Forms;

namespace wyk.basic
{
    /// <summary>
    /// 用于在同一个界面切换不同UserControl的列表管理器
    /// </summary>
    public class UserControlList
    {
        public int current_index = -1;
        public List<UserControl> user_controls = new List<UserControl>();
        public List<object> buttons = new List<object>();

        public virtual UserControl userControlByName(string name, Control parentForm)
        {
            UserControl uc = null;
            switch (name)
            {
                default:
                    break;
            }
            return uc;
        }


        public virtual void show(object sender, Control parentForm, Panel parentPanel)
        {
            int index = -1;
            for (int i = 0; i < buttons.Count; i++)
            {
                if (sender == buttons[i])
                {
                    index = i;
                    break;
                }
            }
            if (index < 0)
            {
                UserControl uc = userControlByName(nameForButton(sender), parentForm);
                if (uc != null)
                {
                    user_controls.Add(uc);
                    buttons.Add(sender);
                    uc.Parent = parentPanel;
                    uc.Dock = DockStyle.Fill;
                    index = user_controls.Count - 1;
                }
            }
            if (index >= 0)
            {
                hideCurrent();
                user_controls[index].Show();
                user_controls[index].Focus();
                setStateForButton(buttons[index], CheckState.Checked);
                current_index = index;
            }
        }

        protected virtual void setStateForButton(object button, CheckState state)
        {
            var type = button.GetType();
            if(type== typeof(ToolStripButton))
            {
                var btn = button as ToolStripButton;
                btn.CheckState = state;
            }
            else if(type == typeof(ToolStripMenuItem))
            {
                var btn = button as ToolStripMenuItem;
                btn.CheckState = state;
            }
        }

        protected virtual string nameForButton(object button)
        {
            var type = button.GetType();
            if (type == typeof(ToolStripButton)|| type == typeof(ToolStripMenuItem))
            {
                var btn = button as ToolStripItem;
                return btn.Name;
            }
            else
            {
                try
                {
                    var btn = button as Control;
                    return btn.Name;
                }
                catch { }
            }
            return "";
        }

        public void hideCurrent()
        {
            if (current_index >= 0)
            {
                user_controls[current_index].Hide();
                setStateForButton(buttons[current_index], CheckState.Unchecked);
                current_index = -1;
            }
        }
    }
}