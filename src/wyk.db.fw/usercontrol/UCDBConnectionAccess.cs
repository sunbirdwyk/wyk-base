namespace wyk.db.ext.usercontrol
{
    public partial class UCDBConnectionAccess : UCDBConnectionBase
    {
        public UCDBConnectionAccess()
        {
            InitializeComponent();
        }

        protected override void loadConnectionConfig()
        {
            txtServer.Text = _connection.server_name;
            txtPassword1.Text = _connection.password;
        }

        protected override void readConnectionConfig()
        {
            _connection.db_type = DBType.Access;
            _connection.server_name = txtServer.Text;
            _connection.password = txtPassword1.Text;
        }
    }
}
