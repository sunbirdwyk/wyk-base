using System.Windows.Forms;

namespace wyk.db.ext.usercontrol
{
    public partial class UCDBConnectionBase : UserControl
    {
        protected DBConnection _connection;
        public UCDBConnectionBase()
        {
            InitializeComponent();
        }

        public string ConnectionString
        {
            get
            {
                readConnectionConfig();
                _connection.refreshConnectionString();
                return _connection.connection_string;
            }
            set
            {
                _connection = new DBConnection(value);
                loadConnectionConfig();
            }
        }

        public DBConnection Connection
        {
            get
            {
                readConnectionConfig();
                _connection.refreshConnectionString();
                return _connection;
            }
            set
            {
                _connection = value;
                loadConnectionConfig();
            }
        }

        protected virtual void loadConnectionConfig()
        {

        }

        protected virtual void readConnectionConfig()
        {

        }
    }
}
