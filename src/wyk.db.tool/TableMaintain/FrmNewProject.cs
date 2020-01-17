using System;
using wyk.basic;
using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    public partial class FrmNewProject : ExForm
    {
        FrmMain root;
        UCTableMaintain parent;
        public FrmNewProject(FrmMain Root, UCTableMaintain Parent)
        {
            root = Root;
            parent = Parent;
            SuperiorForm = root;
            InitializeComponent();
        }

        private void FrmNewProject_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var msg = parent.setNewProject(txtProjectName.Text.Trim());
            if(!msg.isNull())
            {
                ExMessageBox.Show(root, msg);
                return;
            }
            this.Close();
        }
    }
}
