using System;

namespace wyk.db.ext.usercontrol
{
    public partial class UCDBConnectionSqlServer : UCDBConnectionBase
    {
        public UCDBConnectionSqlServer()
        {
            InitializeComponent();
        }

        private void UCDBConnectionSqlServer_Load(object sender, EventArgs e)
        {
        }

        private void btnRefreshServer_Click(object sender, EventArgs e)
        {
            string current_server = txtServer.Text;
            string[] servers = SqlServerUtil.getServers();
            txtServer.Items.Clear();
            try
            {
                txtServer.Items.AddRange(servers);
            }
            catch { }
            txtServer.Text = current_server;
        }

        private void btnRefreshDB_Click(object sender, EventArgs e)
        {
            string current_database = txtDatabase.Text;
            DBConnection conn = new DBConnection();
            conn.db_type = DBType.SqlServer;
            conn.server_name = txtServer.Text;
            conn.user_name = txtUserName.Text;
            conn.password = txtPassword.Text;
            conn.windows_verification = chbWindowsVerification.Checked;
            conn.refreshConnectionString();
            txtDatabase.Items.Clear();
            string[] databases = SqlServerUtil.getDatabases(conn);
            try
            {
                txtDatabase.Items.AddRange(databases);
            }
            catch { }
            txtDatabase.Text = current_database;
        }

        protected override void loadConnectionConfig()
        {
            txtServer.Text = _connection.server_name;
            txtDatabase.Text = _connection.database;
            txtUserName.Text = _connection.user_name;
            txtPassword.Text = _connection.password;
            chbWindowsVerification.Checked = _connection.windows_verification;
        }

        protected override void readConnectionConfig()
        {
            _connection.db_type = DBType.SqlServer;
            _connection.server_name = txtServer.Text;
            _connection.database = txtDatabase.Text;
            _connection.user_name = txtUserName.Text;
            _connection.password = txtPassword.Text;
            _connection.windows_verification = chbWindowsVerification.Checked;
        }

        private void chbWindowsVerification_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = !chbWindowsVerification.Checked;
            txtUserName.Enabled = !chbWindowsVerification.Checked;
        }
    }
}
