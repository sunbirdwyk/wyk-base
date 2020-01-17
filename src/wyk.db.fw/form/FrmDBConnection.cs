using wyk.db;
using System;
using System.Windows.Forms;
using wyk.db.ext.usercontrol;

namespace wyk.db.ext
{
    public partial class FrmDBConnection : Form
    {
        Form parent;
        bool show_db_type;
        DBConnection connection;
        DBType default_db_type;

        UCDBConnectionBase ucConnection;

        public FrmDBConnection(Form parent, bool show_db_type, DBConnection connection, DBType default_db_type)
        {
            this.parent = parent;
            this.show_db_type = show_db_type;
            this.connection = connection;
            this.default_db_type = default_db_type;
            InitializeComponent();
        }

        public FrmDBConnection(Form parent, DBConnection connection)
        {
            this.parent = parent;
            show_db_type = false;
            this.connection = connection;
            default_db_type = DBType.SqlServer;
            InitializeComponent();
        }

        private void FrmDBConnection_Load(object sender, EventArgs e)
        {
            int current_y = 10;
            pDBType.Visible = show_db_type;
            if (show_db_type)
            {
                current_y += pDBType.Height;
            }
            tlpContent.Top = current_y;
            current_y += tlpContent.Height;
            this.Height = current_y + 35;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            connection = ucConnection.Connection;
            this.Close();
        }

        private void rbnDBSqlServer_CheckedChanged(object sender, EventArgs e)
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

        private void rbnDBAccess_CheckedChanged(object sender, EventArgs e)
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

        private void rbnDBOracle_CheckedChanged(object sender, EventArgs e)
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

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            DBConnection connection = ucConnection.Connection;
            bool status = DBUtil.testConnection(connection, out string msg);
            if (status)
                MessageBox.Show("测试成功!", "测试结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(msg, "测试结果", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rbnMySql_CheckedChanged(object sender, EventArgs e)
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
