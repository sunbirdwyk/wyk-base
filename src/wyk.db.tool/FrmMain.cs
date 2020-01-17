using System;
using System.Windows.Forms;
using wyk.db.tool.UCL;
using wyk.db.tool.Util;
using wyk.db.ext;
using wyk.ui;

namespace wyk.db.tool
{
    public partial class FrmMain : ExFormMain
    {
        UCLMain ucl = new UCLMain();
        public DBConnection connection = new DBConnection();
        public int connection_status = -1;
        public DBToolConfig config = new DBToolConfig();
        string connection_message = "";

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            setCurrentPositionTo(System.Drawing.ContentAlignment.MiddleCenter, 1600, 880);
            config = new DBToolConfig();
            config.load();
            checkCurrentConnection();
            ucl.show(tsbSchema, this, pBody);
        }

        public void checkCurrentConnection()
        {
            if(connection.db_type == DBType.Unknown)
            {
                connection_status = -1;
            }
            else
            {
                bool status = DBUtil.testConnection(connection, out string msg);
                if (status)
                {
                    connection_status = 1;
                }
                else
                {
                    connection_status = 0;
                    connection_message = msg;
                }
            }
            refreshConnectionStatus();
        }

        public void refreshConnectionStatus()
        {
            if (connection_status < 0)
            {
                tsbDBStatus.Image = wyk.db.tool.Properties.Resources.warning;
                connection_message = "数据库连接未设置, 请设置数据库连接!";
            }
            else if (connection_status == 0)
            {
                tsbDBStatus.Image = wyk.db.tool.Properties.Resources.error;
            }
            else
            {
                tsbDBStatus.Image = wyk.db.tool.Properties.Resources.ok;
                connection_message = "数据库连接正常";
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            ucl.show(sender, this, pBody);
        }

        private void tsbDBStatus_Click(object sender, EventArgs e)
        {
            ExMessageBox.Show(this, connection_message, "连接状态");
        }

        private void tsbDBConnection_Click(object sender, EventArgs e)
        {
            var frm = new FrmDBConnectionEx(this, true, connection, DBType.SqlServer);
            frm.ShowDialog();
            if(frm.DialogResult== DialogResult.OK)
            {
                connection = frm.connection;
                connection.refreshConnectionString();
                tstDBConnection.Text = connection.connection_string;
                checkCurrentConnection();
                if (connection_status > 0)
                {
                    ucl.show(ucl.buttons[ucl.current_index], this, pBody);
                }
            }
        }
    }
}
