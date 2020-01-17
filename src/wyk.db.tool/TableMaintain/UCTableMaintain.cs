using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using wyk.basic;
using wyk.db.tool.Model;
using wyk.db.tool.Util;
using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    public partial class UCTableMaintain : ExUserControl
    {
        public const int COL_PRIMARY = 0;
        public const int COL_IDENTITY = 1;
        public const int COL_NAME = 2;
        public const int COL_TYPE = 3;
        public const int COL_LENGTH = 4;
        public const int COL_LENGTH2 = 5;
        public const int COL_ALLOWNULL = 6;
        public const int COL_DEFAULT = 7;
        public const int COL_JSONIGNORE = 8;
        public const int COL_REPLACENAME = 9;
        public const int COL_DESCRIPTION = 10;

        FrmMain root;
        public List<DBTable> tables = new List<DBTable>();
        public DBInitDataConfig table_config = new DBInitDataConfig();
        string[] data_type_list = null;
        public MaintainProject current_project = null;

        bool loading_detail = false;
        bool show_msg_when_change_project = false;

        public UCTableMaintain(FrmMain Root)
        {
            root = Root;
            InitializeComponent();
        }

        private void UCTableMaintain_Load(object sender, EventArgs e)
        {
            dgvColumns.Visible = false;
            data_type_list = Enum.GetNames(typeof(DBDataType));
            try
            {
                DataGridViewComboBoxColumn col = dgvColumns.Columns[COL_TYPE] as DataGridViewComboBoxColumn;
                col.Items.AddRange(data_type_list);
                foreach (string col_str in data_type_list)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(col_str);
                    tsmi.Name = "tsmiColType_" + col_str;
                    tsmi.Click += onColumnTypeMenuItemClick;
                    cmsTypeCell.Items.Add(tsmi);
                }
            }
            catch { }
            loadProjectList();
            show_msg_when_change_project = true;
        }

        private void onColumnTypeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
                dgvColumns.Rows[dgvColumns.SelectedCells[0].RowIndex].Cells[COL_TYPE].Value = tsmi.Name.Split('_')[1];
            }
            catch { }
        }

        public string rootFolder()
        {
            if (txtRootFolder.Text.Trim() == "")
                return "";
            return txtRootFolder.Text.Trim().Trim('\\').Trim('/') + "\\";
        }

        public void addPresetTables(List<DBTable> preset_tables)
        {
            foreach (DBTable table in preset_tables)
            {
                int idx = -1;
                for (int i = 0; i < tables.Count; i++)
                {
                    if (tables[i].table_name == table.table_name)
                    {
                        idx = i;
                        break;
                    }
                }
                if (idx >= 0)
                {
                    tables[idx] = table;
                }
                else
                {
                    tables.Add(table);
                }
                string path = rootFolder() + table.table_name + ".table";
                table.toXmlFile(path);
            }
            refreshTableList(0);
        }

        public void updateDBStatus()
        {
            lblDBStatus.Text = "数据库版本: " + table_config.CurrentDBVersion;
        }

        public string setNewProject(string name)
        {
            if (name.isNull())
                return "项目名称不能为空";
            name = name.Trim();
            var group = root.config.MaintainGroup;
            var idx = group.getIndex(name);
            if (idx >= 0)
                return "项目已存在!";
            var msg = group.set(name, current_project);
            if (msg.isNull())
            {
                current_project.name = name;
                root.config.current_project = name;
                root.config.MaintainGroup = group;
                root.config.save();
                loadProjectList();
            }
            return "";
        }

        public void loadProjectList()
        {
            show_msg_when_change_project = false;
            var group = root.config.MaintainGroup;
            cbProjectName.Items.Clear();
            foreach (var proj in group.projects)
            {
                cbProjectName.Items.Add(proj.name);
            }
            try
            {
                cbProjectName.SelectedIndex = group.getIndex(root.config.current_project);
                current_project = group.projects[cbProjectName.SelectedIndex].copy();
            }
            catch
            {
                cbProjectName.SelectedIndex = -1;
                current_project = new MaintainProject();
            }
            loadCurrentProject();
            show_msg_when_change_project = true;
        }

        public void loadCurrentProject()
        {
            if (!current_project.name.isNull())
                txtRootFolder.Text = current_project.db_initial_path;
            else
                txtRootFolder.Text = "";
        }

        public void setTable(DBTable table, int index)
        {
            if (index < 0)
            {
                tables.Add(table);
                index = tables.Count - 1;
            }
            else
            {
                tables[index] = table;
            }
            table.toXmlFile(rootFolder());
            refreshTableList(index);
        }

        private void loadTableProfiles()
        {
            root.showNotification("正在读取数据, 请稍候...", 0);
            table_config = new DBInitDataConfig();
            table_config.loadFrom(rootFolder());
            updateDBStatus();
            tables = new List<DBTable>();
            string path = rootFolder();
            if (path != "")
            {
                try
                {
                    string[] table_paths = Directory.GetFiles(path, "*.table");
                    foreach (string table_p in table_paths)
                    {
                        DBTable tb = DBTable.fromXmlFile(table_p);
                        if (tb.table_name != "")
                        {
                            tables.Add(tb);
                        }
                    }
                }
                catch { }
            }
            refreshTableList(0);
            root.hideNotification();
        }

        private void refreshTableList(int current_index)
        {
            lbTables.Items.Clear();
            foreach (DBTable tb in tables)
            {
                lbTables.Items.Add(tb.table_name);
            }
            try
            {
                lbTables.SelectedIndex = current_index;
            }
            catch { }
            lbTables_Click(null, null);
        }

        private void loadCurrentColumns()
        {
            if (lbTables.SelectedIndex < 0)
                return;
            loading_detail = true;
            lblTableDescription.Text = tables[lbTables.SelectedIndex].table_description;
            dgvColumns.Rows.Clear();
            foreach (DBColumn col in tables[lbTables.SelectedIndex].columns)
            {
                int row = dgvColumns.Rows.Add();
                dgvColumns.Rows[row].Cells[COL_PRIMARY].Value = col.is_primary;
                dgvColumns.Rows[row].Cells[COL_IDENTITY].Value = col.is_identity;
                dgvColumns.Rows[row].Cells[COL_NAME].Value = col.name;
                dgvColumns.Rows[row].Cells[COL_TYPE].Value = col.DataType;
                dgvColumns.Rows[row].Cells[COL_LENGTH].Value = col.data_length;
                dgvColumns.Rows[row].Cells[COL_LENGTH2].Value = col.data_length2;
                dgvColumns.Rows[row].Cells[COL_ALLOWNULL].Value = col.allow_null;
                dgvColumns.Rows[row].Cells[COL_DEFAULT].Value = col.default_value;
                dgvColumns.Rows[row].Cells[COL_JSONIGNORE].Value = col.json_ignore;
                dgvColumns.Rows[row].Cells[COL_REPLACENAME].Value = col.replace_name;
                dgvColumns.Rows[row].Cells[COL_DESCRIPTION].Value = col.data_description;
            }
            loading_detail = false;
        }

        private void txtRootFolder_TextChanged(object sender, EventArgs e)
        {
            loadTableProfiles();
            current_project.db_initial_path = rootFolder();
            var group = root.config.MaintainGroup;
            group.set(current_project);
            root.config.MaintainGroup = group;
            root.config.save();
        }

        private void btnSelFolder_Click(object sender, EventArgs e)
        {
            if (selFolder.ShowDialog() == DialogResult.OK)
            {
                txtRootFolder.Text = selFolder.SelectedPath;
            }
        }

        private void lbTables_Click(object sender, EventArgs e)
        {
            if (lbTables.SelectedIndex >= 0)
            {
                dgvColumns.Visible = true;
                loadCurrentColumns();
            }
            else
            {
                dgvColumns.Visible = false;
            }
        }

        private void btnNewTable_Click(object sender, EventArgs e)
        {
            if (rootFolder() == "" || !Directory.Exists(rootFolder()))
                return;
            FrmTableDetail frm = new FrmTableDetail(root, this, new DBTable(), -1);
            frm.ShowDialog();
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (lbTables.SelectedIndex < 0)
                return;
            FrmTableDetail frm = new FrmTableDetail(root, this, tables[lbTables.SelectedIndex], lbTables.SelectedIndex);
            frm.ShowDialog();
        }

        private void lbTables_DoubleClick(object sender, EventArgs e)
        {
            btnEditTable_Click(null, null);
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (lbTables.SelectedIndex < 0)
                return;
            int index = lbTables.SelectedIndex;
            if (ExMessageBox.Show(root, "将要删除当前所选表'" + tables[index].table_name + "', 确认继续吗?", "删除表", ExMessageBoxIcon.Question, ExMessageBoxButton.YesNo) == DialogResult.No)
                return;
            try
            {
                string path = rootFolder() + tables[lbTables.SelectedIndex].table_name + ".table";
                File.Delete(path);
                tables.RemoveAt(index);
            }
            catch (Exception ex) { ExMessageBox.Show(root, ex.Message); }
            refreshTableList(0);
        }

        private void saveCurrentColumns()
        {
            string path = rootFolder() + tables[lbTables.SelectedIndex].table_name + ".table";
            tables[lbTables.SelectedIndex].toXmlFile(path);
        }

        private DBColumn readColumnContent(int row)
        {
            DBColumn col = new DBColumn();
            try
            {
                col.is_primary = Convert.ToBoolean(dgvColumns.Rows[row].Cells[COL_PRIMARY].Value);
            }
            catch { }
            try
            {
                col.is_identity = Convert.ToBoolean(dgvColumns.Rows[row].Cells[COL_IDENTITY].Value);
            }
            catch { }
            try
            {
                col.name = dgvColumns.Rows[row].Cells[COL_NAME].Value.ToString().Trim();
            }
            catch { }
            try
            {
                col.DataType = dgvColumns.Rows[row].Cells[COL_TYPE].Value.ToString().Trim();
            }
            catch { }
            try
            {
                col.data_length = Convert.ToInt32(dgvColumns.Rows[row].Cells[COL_LENGTH].Value);
            }
            catch { }
            try
            {
                col.data_length2 = Convert.ToInt32(dgvColumns.Rows[row].Cells[COL_LENGTH2].Value);
            }
            catch { }
            switch (col.data_type)
            {
                case DBDataType.Varchar:
                    if (col.data_length <= 0)
                        col.data_length = 50;
                    break;
                case DBDataType.Numeric:
                    if (col.data_length < 0)
                        col.data_length = 0;
                    if (col.data_length2 < 0)
                        col.data_length2 = 0;
                    if (col.data_length == 0 && col.data_length2 == 0)
                    {
                        col.data_length = 18;
                        col.data_length2 = 2;
                    }
                    break;
            }
            try
            {
                col.allow_null = Convert.ToBoolean(dgvColumns.Rows[row].Cells[COL_ALLOWNULL].Value);
            }
            catch { }
            try
            {
                col.default_value = dgvColumns.Rows[row].Cells[COL_DEFAULT].Value.ToString();
            }
            catch { }
            try
            {
                col.json_ignore = Convert.ToBoolean(dgvColumns.Rows[row].Cells[COL_JSONIGNORE].Value);
            }
            catch { }
            try
            {
                col.replace_name = dgvColumns.Rows[row].Cells[COL_REPLACENAME].Value.ToString();
            }
            catch { }
            try
            {
                col.data_description = dgvColumns.Rows[row].Cells[COL_DESCRIPTION].Value.ToString();
            }
            catch { }
            return col;
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            loading_detail = true;
            int row = dgvColumns.Rows.Add();
            dgvColumns.Rows[row].Cells[COL_PRIMARY].Value = false;
            dgvColumns.Rows[row].Cells[COL_IDENTITY].Value = false;
            dgvColumns.Rows[row].Cells[COL_NAME].Value = "newcol";
            dgvColumns.Rows[row].Cells[COL_TYPE].Value = "Integer";
            dgvColumns.Rows[row].Cells[COL_LENGTH].Value = 0;
            dgvColumns.Rows[row].Cells[COL_LENGTH2].Value = 0;
            dgvColumns.Rows[row].Cells[COL_ALLOWNULL].Value = true;
            dgvColumns.Rows[row].Cells[COL_DEFAULT].Value = "";
            dgvColumns.Rows[row].Cells[COL_JSONIGNORE].Value = false;
            dgvColumns.Rows[row].Cells[COL_REPLACENAME].Value = "";
            dgvColumns.Rows[row].Cells[COL_DESCRIPTION].Value = "";
            loading_detail = false;
            DBColumn col = readColumnContent(row);
            tables[lbTables.SelectedIndex].columns.Add(col);
            saveCurrentColumns();
        }

        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            if (dgvColumns.SelectedCells.Count <= 0)
                return;
            int index = dgvColumns.SelectedCells[0].RowIndex;
            if (ExMessageBox.Show(root, "将要删除当前所选列'" + dgvColumns.Rows[index].Cells[COL_NAME].Value + "', 确认继续吗?\r\n注意:在未点击保存列设置时, 该操作将不会最终生效.", "删除列", ExMessageBoxIcon.Question, ExMessageBoxButton.YesNo) == DialogResult.No)
                return;
            dgvColumns.Rows.RemoveAt(index);
            tables[lbTables.SelectedIndex].columns.RemoveAt(index);
            saveCurrentColumns();
        }

        private void btnDBInitialData_Click(object sender, EventArgs e)
        {
            if (rootFolder() == "" || !Directory.Exists(rootFolder()))
                return;
            DBTable table;
            if (lbTables.SelectedIndex < 0)
                table = new DBTable();
            else
                table = tables[lbTables.SelectedIndex];
            FrmTableInitialData frm = new FrmTableInitialData(root, this, table);
            frm.ShowDialog();
        }

        private void btnRefreshTables_Click(object sender, EventArgs e)
        {
            loadTableProfiles();
        }

        private void lbTables_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    int index = lbTables.IndexFromPoint(e.Location);
                    if (index >= 0)
                        lbTables.SelectedIndex = index;
                }
                catch { }
                lbTables_Click(null, null);
                cmsTableList.Show(lbTables, e.Location);
            }
        }

        private void dgvColumns_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvColumns.EndEdit();
                try
                {
                    DataGridView.HitTestInfo hitInfo = dgvColumns.HitTest(e.X, e.Y);
                    if (hitInfo.RowIndex < 0)
                        return;
                    foreach (DataGridViewCell cell in dgvColumns.SelectedCells)
                        cell.Selected = false;
                    dgvColumns.Rows[hitInfo.RowIndex].Cells[hitInfo.ColumnIndex].Selected = true;
                    if (hitInfo.ColumnIndex == COL_TYPE)
                    {
                        cmsTypeCell.Show(dgvColumns, e.Location);
                    }
                    else
                    {
                        cmsColumnList.Show(dgvColumns, e.Location);
                    }
                }
                catch { }
            }
        }

        private void dgvColumns_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == COL_LENGTH)
            {
                DBColumn dbc = new DBColumn();
                string type_string = dgvColumns.Rows[e.RowIndex].Cells[COL_TYPE].Value as string;
                dbc.DataType = type_string;
                switch (dbc.data_type)
                {
                    case DBDataType.Varchar:
                    case DBDataType.Numeric:
                        break;
                    default:
                        int value = 0;
                        try
                        {
                            value = Convert.ToInt32(dgvColumns.Rows[e.RowIndex].Cells[COL_LENGTH].Value);
                        }
                        catch { }
                        if (value > 0)
                        {
                            dgvColumns.Rows[e.RowIndex].Cells[COL_LENGTH].Value = 0;
                            if (!loading_detail)
                                ExMessageBox.Show(root, "当前类型'" + type_string + "'不支持长度");
                        }
                        break;
                }
            }
            if (e.ColumnIndex == COL_LENGTH2)
            {
                DBColumn dbc = new DBColumn();
                string type_string = dgvColumns.Rows[e.RowIndex].Cells[COL_TYPE].Value as string;
                dbc.DataType = type_string;
                switch (dbc.data_type)
                {
                    case DBDataType.Numeric:
                        break;
                    default:
                        int value = 0;
                        try
                        {
                            value = Convert.ToInt32(dgvColumns.Rows[e.RowIndex].Cells[COL_LENGTH].Value);
                        }
                        catch { }
                        if (value > 0)
                        {
                            dgvColumns.Rows[e.RowIndex].Cells[COL_LENGTH2].Value = 0;
                            if (!loading_detail)
                                ExMessageBox.Show(root, "当前类型'" + type_string + "'不支持长度2");
                        }
                        break;
                }
            }
            if (e.ColumnIndex == COL_TYPE)
            {
                DBColumn dbc = new DBColumn();
                string type_string = dgvColumns.Rows[e.RowIndex].Cells[COL_TYPE].Value as string;
                dbc.DataType = type_string;
                switch (dbc.data_type)
                {
                    case DBDataType.Varchar:
                        if (!loading_detail)
                        {
                            dgvColumns.Rows[e.RowIndex].Cells[COL_LENGTH].Value = 50;
                            dgvColumns.Rows[e.RowIndex].Cells[COL_LENGTH2].Value = 0;
                        }
                        break;
                    case DBDataType.Numeric:
                        if (!loading_detail)
                        {
                            dgvColumns.Rows[e.RowIndex].Cells[COL_LENGTH].Value = 12;
                            dgvColumns.Rows[e.RowIndex].Cells[COL_LENGTH2].Value = 2;
                        }
                        break;
                    default:
                        dgvColumns.Rows[e.RowIndex].Cells[COL_LENGTH].Value = 0;
                        dgvColumns.Rows[e.RowIndex].Cells[COL_LENGTH2].Value = 0;
                        break;
                }
                dgvColumns.EndEdit();
            }
            if (!loading_detail)
            {
                DBColumn col = readColumnContent(e.RowIndex);
                tables[lbTables.SelectedIndex].columns[e.RowIndex] = col;
                saveCurrentColumns();
            }
        }

        private void tsmiTableClass_Click(object sender, EventArgs e)
        {
            if (lbTables.SelectedIndex < 0)
                return;
            FrmTableClass frm = new FrmTableClass(root, this, tables[lbTables.SelectedIndex]);
            frm.ShowDialog();
        }

        private void dgvColumns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == COL_PRIMARY)
            {
                try
                {
                    DataGridViewCheckBoxCell cell = dgvColumns.Rows[e.RowIndex].Cells[COL_PRIMARY] as DataGridViewCheckBoxCell;
                    bool is_checked = Convert.ToBoolean(cell.EditingCellFormattedValue);
                    if (is_checked)
                        dgvColumns.Rows[e.RowIndex].Cells[COL_ALLOWNULL].Value = false;
                }
                catch { }
            }
        }

        private void tsmiNewColumn_Click(object sender, EventArgs e)
        {
            btnAddColumn_Click(sender, e);
        }

        private void tsmiDeleteColumn_Click(object sender, EventArgs e)
        {
            btnDeleteColumn_Click(sender, e);
        }

        private void btnExportAdapterClasses_Click(object sender, EventArgs e)
        {
            FrmExportTableAdapters frm = new FrmExportTableAdapters(root, this);
            frm.ShowDialog();
        }

        private void btnDBConfig_Click(object sender, EventArgs e)
        {
            FrmDBConfig frm = new FrmDBConfig(root, this);
            frm.ShowDialog();
        }

        private void btnExportSpec_Click(object sender, EventArgs e)
        {
            string path = rootFolder() + "\\db_spec.pdf";
            string msg = DBSpecUtil.exportPDF(path, txtRootFolder.Text);
            if (msg == "")
            {
                ExMessageBox.Show(root, "导出成功!");
            }
            else
            {
                ExMessageBox.Show(root, "导出文档时出现错误, 错误信息:" + msg);
            }
        }

        private void btnPresetTable_Click(object sender, EventArgs e)
        {
            FrmPresetTable frm = new FrmPresetTable(root, this);
            frm.ShowDialog();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            CommonUtil.openFolder(txtRootFolder.Text);
        }

        private void btnOpenWithVSCode_Click(object sender, EventArgs e)
        {
            CommonUtil.runCmdCommand("Code \"" + txtRootFolder.Text + "\" ");
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            try
            {
                string name = cbProjectName.SelectedItem.ToString();
                if (ExMessageBox.Show(root, "将要删除当前项目'" + name + "', 确认继续吗?", "删除项目", ExMessageBoxIcon.Question, ExMessageBoxButton.YesNo) == DialogResult.No)
                    return;
                var group = root.config.MaintainGroup;
                var msg = group.delete(name);
                if (!msg.isNull())
                {
                    ExMessageBox.Show(root, Color.Tomato, msg, "删除失败", ExMessageBoxIcon.Error, ExMessageBoxButton.OK);
                    return;
                }
                if (root.config.current_project == name)
                {
                    if (group.projects.Count > 0)
                        root.config.current_project = group.projects[0].name;
                    else
                        root.config.current_project = "";
                }
                root.config.MaintainGroup = group;
                root.config.save();
                loadProjectList();
            }
            catch { ExMessageBox.Show(root, Color.Tomato, "当前还未选择项目", "删除失败", ExMessageBoxIcon.Error, ExMessageBoxButton.OK); }
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            var frm = new FrmNewProject(root, this);
            frm.ShowDialog();
        }

        private void cbProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var name = cbProjectName.SelectedItem.ToString();
                if (name.isNull())
                {
                    current_project = new MaintainProject(); root.config.current_project = "";
                }
                else
                {
                    if (show_msg_when_change_project)
                    {
                        if (ExMessageBox.Show(root, "将要切换到新的项目'" + name + "', 确认继续吗?", "切换项目", ExMessageBoxIcon.Question, ExMessageBoxButton.YesNo) == DialogResult.No)
                            return;
                    }
                    current_project = root.config.MaintainGroup.get(name);
                    root.config.current_project = current_project.name;
                }
            }
            catch { current_project = new MaintainProject(); root.config.current_project = ""; }
            loadCurrentProject();
        }

        private void BtnSQLCreateTable_Click(object sender, EventArgs e)
        {
            var table = tables[lbTables.SelectedIndex];
            var list = table.getCreateTableSqlList(DBUtil.connection.db_type);
            var sb = new StringBuilder();
            foreach(var sql in list)
            {
                if (sb.Length > 0)
                    sb.Append("\r\n\r\n");
                sb.Append(sql);
            }
            var frm = new FrmTextShow(root, table.table_name, sb.ToString());
            frm.ShowDialog();
        }
    }
}
