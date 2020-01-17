using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    public partial class FrmDBConfig : ExForm
    {
        FrmMain root;
        UCTableMaintain parent;
        public FrmDBConfig(FrmMain Root, UCTableMaintain Parent)
        {
            root = Root;
            parent = Parent;
            SuperiorForm = root;
            InitializeComponent();
        }

        private void FrmDBConfig_Load(object sender, System.EventArgs e)
        {
            txtCurrentVersion.Text = parent.table_config.current_db_version;
            txtSysConfigTable.Text = parent.table_config.configuration_table_name;
            txtTableNameColumn.Text = parent.table_config.configuration_key_column;
            txtTableValueColumn.Text = parent.table_config.configuration_value_column;
            txtTableDBVersionKey.Text = parent.table_config.configuration_db_version_key;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            DBInitDataConfig config = new DBInitDataConfig();
            config.can_save = true;
            config.CurrentDBVersion = txtCurrentVersion.Text.Trim();
            if (txtSysConfigTable.Text.Trim() != "")
                config.configuration_table_name = txtSysConfigTable.Text.Trim();
            if (txtTableNameColumn.Text.Trim() != "")
                config.configuration_key_column = txtTableNameColumn.Text.Trim();
            if (txtTableValueColumn.Text.Trim() != "")
                config.configuration_value_column = txtTableValueColumn.Text.Trim();
            if (txtTableDBVersionKey.Text.Trim() != "")
                config.configuration_db_version_key = txtTableDBVersionKey.Text.Trim();
            string msg = config.saveTo(parent.rootFolder());
            if (msg != "")
                ExMessageBox.Show(root, msg, "错误", ExMessageBoxIcon.Error);
            else
            {
                parent.table_config = config;
                parent.updateDBStatus();
                this.Close();
            }
        }
    }
}
