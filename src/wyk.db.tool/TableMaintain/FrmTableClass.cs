using wyk.ui;
using System;
using System.Windows.Forms;

namespace wyk.db.tool.TableMaintain
{
    public partial class FrmTableClass : ExForm
    {
        FrmMain root;
        UCTableMaintain parent;
        DBTable table;
        public FrmTableClass(FrmMain Root, UCTableMaintain Parent, DBTable Table)
        {
            root = Root;
            parent = Parent;
            table = Table;
            SuperiorForm = root;
            InitializeComponent();
        }

        private void FrmTableClass_Load(object sender, System.EventArgs e)
        {
            this.setCurrentPositionToCenterParent();
            btnGenerate_Click(null, null);
        }

        private void btnGenerate_Click(object sender, System.EventArgs e)
        {
            string namespaceStr= "";
            if (txtNameSpace.Text == "" && chbShowDefaultNameSpace.Checked)
                namespaceStr = "MyNameSpace";
            txtClassContent.Text = table.getClassContent(namespaceStr);
        }

        private void chbShowDefaultNameSpace_CheckedChanged(object sender, System.EventArgs e)
        {
            btnGenerate_Click(null, null);
        }

        private void btnCopyAll_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(txtClassContent.Text);
            ExMessageBox.Show(this, "内容已复制到粘帖板");
        }
    }
}
