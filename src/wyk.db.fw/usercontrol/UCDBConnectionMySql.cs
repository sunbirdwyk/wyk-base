using System;

namespace wyk.db.ext.usercontrol
{
    public partial class UCDBConnectionMySql : UCDBConnectionBase
    {
        public UCDBConnectionMySql()
        {
            InitializeComponent();
        }

        private void UCDBConnectionMySql_Load(object sender, EventArgs e)
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
            txtPort.Text = _connection.port == 0 ? "3306" : _connection.port.ToString();
        }

        protected override void readConnectionConfig()
        {
            _connection.db_type = DBType.MySql;
            _connection.server_name = txtServer.Text;
            _connection.database = txtDatabase.Text;
            _connection.user_name = txtUserName.Text;
            _connection.password = txtPassword.Text;
            try
            {
                _connection.port = Convert.ToInt32(txtPort.Text);
            }
            catch { _connection.port = 0; }
            if (_connection.port == 3306)
                _connection.port = 0;
        }
    }
}