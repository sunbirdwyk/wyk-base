using System.Windows.Forms;
using wyk.db.ext.usercontrol;
using wyk.ui;

namespace wyk.db.ext
{
    public partial class FrmDBConnectionEx : ExForm
    {
        ExFormBasic parent;
        bool show_db_type;
        public DBConnection connection;
        DBType default_db_type;

        UCDBConnectionBase ucConnection;

        public FrmDBConnectionEx(Form Parent, bool ShowDBType, DBConnection Connection, DBType DefaultDBType)
        {
            parent = Parent as ExFormBasic;
            SuperiorForm = parent;
            show_db_type = ShowDBType;
            connection = Connection;
            default_db_type = DefaultDBType;
            InitializeComponent();
        }

        public FrmDBConnectionEx(Form Parent, DBConnection Connection)
        {
            parent = Parent as ExFormBasic;
            SuperiorForm = parent;
            show_db_type = false;
            connection = Connection;
            default_db_type = DBType.SqlServer;
            InitializeComponent();
        }

        private void FrmDBConnectionEx_Load(object sender, System.EventArgs e)
        {
            int current_y = 10 + parent.TitleBar.Height;
            pDBType.Visible = show_db_type;
            if (show_db_type)
            {
                current_y += pDBType.Height;
            }
            tlpContent.Top = current_y;
            current_y += tlpContent.Height;
            this.Height = current_y + 10;
            if (connection.db_type == DBType.Unknown)
                connection.db_type = DBType.SqlServer;
            switch (connection.db_type)
            {
                case DBType.Unknown:
                case DBType.SqlServer:
                default:
                    rbnDBSqlServer.Checked = true;
                    break;
                case DBType.Access:
                    rbnDBAccess.Checked = true;
                    break;
                case DBType.Oracle:
                    rbnDBOracle.Checked = true;
                    break;
                case DBType.MySql:
                    rbnMySql.Checked = true;
                    break;
            }
        }

        private void hideCurrentConnectionContent()
        {
            if (ucConnection != null)
            {
                ucConnection.Visible = false;
                ucConnection.Dispose();
                ucConnection = null;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            connection = ucConnection.Connection;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void rbnDBSqlServer_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbnDBSqlServer.Checked)
            {
                hideCurrentConnectionContent();
                connection.db_type = DBType.SqlServer;
                ucConnection = new UCDBConnectionSqlServer();
                ucConnection.Connection = connection;
                pContent.Controls.Add(ucConnection);
                ucConnection.Dock = DockStyle.Fill;
                ucConnection.Show();
            }
        }

        private void rbnDBAccess_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbnDBAccess.Checked)
            {
                hideCurrentConnectionContent();
                connection.db_type = DBType.Access;
                ucConnection = new UCDBConnectionAccess();
                ucConnection.Connection = connection;
                pContent.Controls.Add(ucConnection);
                ucConnection.Dock = DockStyle.Fill;
                ucConnection.Show();
            }
        }

        private void rbnDBOracle_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbnDBOracle.Checked)
            {
                hideCurrentConnectionContent();
                connection.db_type = DBType.Oracle;
                ucConnection = new UCDBConnectionOracle();
                ucConnection.Connection = connection;
                pContent.Controls.Add(ucConnection);
                ucConnection.Dock = DockStyle.Fill;
                ucConnection.Show();
            }
        }

        private void btnTestConnection_Click(object sender, System.EventArgs e)
        {
            DBConnection connection = ucConnection.Connection;
            bool status = DBUtil.testConnection(connection, out string msg);
            if (status)
                ExMessageBox.Show(this, "测试成功!", "测试结果", ExMessageBoxIcon.Successed);
            else
                ExMessageBox.Show(this, msg, "测试结果", ExMessageBoxIcon.Error);
        }

        private void rbnMySql_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbnMySql.Checked)
            {
                hideCurrentConnectionContent();
                connection.db_type = DBType.MySql;
                ucConnection = new UCDBConnectionMySql();
                ucConnection.Connection = connection;
                pContent.Controls.Add(ucConnection);
                ucConnection.Dock = DockStyle.Fill;
                ucConnection.Show();
            }
        }
    }
}
