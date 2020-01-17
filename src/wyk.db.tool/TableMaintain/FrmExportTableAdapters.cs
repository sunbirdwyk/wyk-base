using System.Collections.Generic;
using wyk.basic;
using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    public partial class FrmExportTableAdapters : ExForm
    {
        UCTableMaintain parent;
        FrmMain root;
        bool loading_detail = true;
        public FrmExportTableAdapters(FrmMain Root, UCTableMaintain Parent)
        {
            parent = Parent;
            root = Root;
            SuperiorForm = root;
            InitializeComponent();
        }

        private void FrmExportTableAdapters_Load(object sender, System.EventArgs e)
        {
            this.setCurrentPositionToCenterParent();
            txtRootFolder.Text = parent.current_project.dbta_path;
            txtNamespace.Text = parent.current_project.model_namespace;
            clbTableList.Items.Clear();
            for (int i = 0; i < parent.tables.Count; i++)
            {
                clbTableList.Items.Add(parent.tables[i].table_name, true);
            }
            loading_detail = false;
        }

        private void btnSelFolder_Click(object sender, System.EventArgs e)
        {
            if (selFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                loading_detail = true;
                txtNamespace.Text = "";
                txtRootFolder.Text = selFolder.SelectedPath;
                parent.current_project.dbta_path = txtRootFolder.Text;
                updateNameSpace();
                parent.current_project.model_namespace = txtNamespace.Text;
                var group = root.config.MaintainGroup;
                group.set(parent.current_project);
                root.config.MaintainGroup = group;
                root.config.save();
                loading_detail = false;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, System.EventArgs e)
        {
            if (chbRemoveAll.Checked)
            {
                if (ExMessageBox.Show(this, "您选择了清空原目录下所有文件, 确认继续吗?", "清空文件确认", ExMessageBoxIcon.Question, ExMessageBoxButton.YesNo) == System.Windows.Forms.DialogResult.No)
                    return;
            }
            this.showNotification("正在导出请稍候...", 0);
            List<DBTable> tables = new List<DBTable>();
            for (int i = 0; i < clbTableList.CheckedIndices.Count; i++)
            {
                tables.Add(parent.tables[clbTableList.CheckedIndices[i]]);
            }
            DBTableManager.generateDBTableAdapters(tables, txtRootFolder.Text, txtNamespace.Text, chbRemoveAll.Checked);
            this.hideNotification();
        }

        private void txtRootFolder_TextChanged(object sender, System.EventArgs e)
        {
            if (!txtNamespace.Text.isNull() || loading_detail)
                return;
            updateNameSpace();
        }

        private void updateNameSpace()
        {
            try
            {
                string[] parts = txtRootFolder.Text.Split('\\');
                txtNamespace.Text = parts[parts.Length - 2];
            }
            catch { }
        }

        private void txtNamespace_TextChanged(object sender, System.EventArgs e)
        {
            if (loading_detail)
                return;
            parent.current_project.model_namespace = txtNamespace.Text;
            var group = root.config.MaintainGroup;
            group.set(parent.current_project);
            root.config.MaintainGroup = group;
            root.config.save();
        }
    }
}
