using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    public partial class FrmTableDetail : ExForm
    {
        FrmMain root;
        UCTableMaintain parent;
        DBTable table;
        int index;
        public FrmTableDetail(FrmMain Root, UCTableMaintain Parent, DBTable Table, int Index)
        {
            root = Root;
            parent = Parent;
            table = Table;
            index = Index;
            SuperiorForm = root;
            InitializeComponent();
        }

        private void FrmTableDetail_Load(object sender, System.EventArgs e)
        {
            this.setCurrentPositionToCenterParent();
            txtName.Text = table.table_name;
            txtDescription.Text = table.table_description;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            table.table_name = txtName.Text;
            table.table_description = txtDescription.Text;
            parent.setTable(table, index);
            this.Close();
        }
    }
}
