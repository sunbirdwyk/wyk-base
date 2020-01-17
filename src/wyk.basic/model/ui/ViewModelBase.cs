using System;

namespace wyk.basic
{
    public class ViewModelBase
    {
        public string error_message = "";
        public FollowAction action = FollowAction.None;
        public string ActionName
        {
            get => Enum.GetName(typeof(FollowAction), action);
            set => action = (FollowAction)Enum.Parse(typeof(FollowAction), value);
        }

        public void setActionForAlert(string msg)
        {
            action = FollowAction.Alert;
            error_message = msg.Replace("\r\n", "    ").Replace("'", "\"").Replace("\\", "/");
        }

        public void setActionForAlertNoPrivilege()
        {
            setActionForAlert("您没有此项操作的权限, 请与管理员联系");
        }
    }
}
