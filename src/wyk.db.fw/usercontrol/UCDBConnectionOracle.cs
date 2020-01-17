namespace wyk.db.ext.usercontrol
{
    public partial class UCDBConnectionOracle : UCDBConnectionBase
    {
        public UCDBConnectionOracle()
        {
            InitializeComponent();
        }

        protected override void loadConnectionConfig()
        {
            txtServer.Text = _connection.server_name;
            txtUserName.Text = _connection.user_name;
            txtPassword.Text = _connection.password;
        }

        protected override void readConnectionConfig()
        {
            _connection.db_type = DBType.Access;
            _connection.server_name = txtServer.Text;
            _connection.user_name = txtUserName.Text;
            _connection.password = txtPassword.Text;
        }
    }
}
