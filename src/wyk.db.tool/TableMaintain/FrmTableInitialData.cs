using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using wyk.basic;
using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    public partial class FrmTableInitialData : ExForm
    {
        FrmMain root;
        UCTableMaintain parent;
        DBTable table;
        string root_path = "";
        const string file_ext = ".data";
        string data_file_path = "";
        DBInitDataProfile data_profile = null;
        bool loading_detail = false;
        public FrmTableInitialData(FrmMain Root, UCTableMaintain Parent, DBTable Table)
        {
            root = Root;
            parent = Parent;
            table = Table;
            SuperiorForm = root;
            root_path = parent.current_project.db_initial_path.Trim('\\').Trim('/') + "\\";
            InitializeComponent();
        }

        private void FrmTableInitialData_Load(object sender, System.EventArgs e)
        {
            this.setCurrentPositionToCenterParent();
            cbTables.Items.Clear();
            int index = -1;
            for (int i = 0; i < parent.tables.Count; i++)
            {
                cbTables.Items.Add(parent.tables[i].table_name);
                if (index < 0)
                    index = 0;
                if (parent.tables[i].table_name == table.table_name)
                    index = i;
            }
            cbTables.SelectedIndex = index;
        }

        private void cbTables_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            data_profile = null;
            if (cbTables.SelectedIndex >= 0)
                table = parent.tables[cbTables.SelectedIndex];
            else
                table = null;
            data_file_path = "";
            if (table != null)
                data_file_path = root_path + table.table_name + file_ext;
            loadCurrentInitialData();
        }

        private void loadCurrentInitialData()
        {
            dgvData.Columns.Clear();
            if (table == null)
                return;
            foreach (DBColumn column in table.columns)
            {
                DataGridViewColumn dc;
                switch (column.data_type)
                {
                    case DBDataType.Binary:
                        dc = new DataGridViewTextBoxColumn();
                        dc.ReadOnly = true;
                        dc.DefaultCellStyle.BackColor = Color.LightGray;
                        dc.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                        break;
                    case DBDataType.Bit:
                        dc = new DataGridViewCheckBoxColumn();
                        dc.ReadOnly = false;
                        break;
                    case DBDataType.Byte:
                    case DBDataType.DateTime:
                    case DBDataType.Integer:
                    case DBDataType.Long:
                    case DBDataType.Numeric:
                    case DBDataType.Short:
                    case DBDataType.Text:
                    case DBDataType.Varchar:
                    default:
                        dc = new DataGridViewTextBoxColumn();
                        dc.ReadOnly = false;
                        break;
                }
                dc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dc.Name = column.name;
                dc.HeaderText = column.name;
                dgvData.Columns.Add(dc);
            }
            refreshTableInitData();
        }

        private void refreshTableInitData()
        {
            if (!File.Exists(data_file_path))
                return;
            data_profile = DBInitDataProfile.fromXMLFile(data_file_path);
            foreach (DBInitData data in data_profile.data_list)
            {
                int row = dgvData.Rows.Add();
                loadDataForRow(row, data);
            }
        }

        private void loadDataForRow(int row, DBInitData data)
        {
            loading_detail = true;
            for (int i = 0; i < dgvData.Columns.Count; i++)
            {
                if (table.columns[i].data_type == DBDataType.Bit)
                {
                    object value = data.valueWithName(dgvData.Columns[i].Name);
                    if (value == null)
                        dgvData.Rows[row].Cells[i].Value = false;
                    else
                        dgvData.Rows[row].Cells[i].Value = value;
                }
                else
                    dgvData.Rows[row].Cells[i].Value = data.valueWithName(dgvData.Columns[i].Name);
            }
            loading_detail = false;
        }

        private DBInitData readDataFromRow(int row)
        {
            DBInitData data = new DBInitData();
            for (int i = 0; i < dgvData.Columns.Count; i++)
            {
                if (table.columns[i].data_type == DBDataType.Binary)
                    continue;
                string value = "";
                if (dgvData.Rows[row].Cells[i].Value != null)
                    value = dgvData.Rows[row].Cells[i].Value.ToString();
                DBInitDataItem di = new DBInitDataItem();
                di.column_name = dgvData.Columns[i].Name;
                di.data_type = table.columns[i].data_type;
                di.StringValue = value;
                data.item_list.Add(di);
            }
            return data;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (table == null)
            {
                ExMessageBox.Show(this, "请选择一个数据表再进行操作!");
                return;
            }
            if (data_profile == null)
            {
                data_profile = DBInitDataProfile.fromXMLFile(data_file_path);
                data_profile.table_name = table.table_name;
            }
            DBInitData data = new DBInitData(table);
            data_profile.data_list.Add(data);
            data_profile.toXmlFile(root_path);
            int row = dgvData.Rows.Add();
            loadDataForRow(row, data);
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (table == null)
            {
                ExMessageBox.Show(this, "请选择一个数据表再进行操作!");
                return;
            }
            if (data_profile == null)
                return;
            if (dgvData.SelectedCells.Count == 0)
                return;
            int row = dgvData.SelectedCells[0].RowIndex;
            if (row < 0)
                return;
            if (ExMessageBox.Show(this, "删除当前所选数据项, 确认继续吗?", "删除数据项", ExMessageBoxIcon.Question, ExMessageBoxButton.YesNo) == DialogResult.No)
                return;
            data_profile.data_list.RemoveAt(row);
            dgvData.Rows.RemoveAt(row);
            data_profile.toXmlFile(root_path);
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            if (table == null)
            {
                ExMessageBox.Show(this, "请选择一个数据表再进行操作!");
                return;
            }
            if (data_profile == null)
                return;
            if (ExMessageBox.Show(this, "将要清空当前数据表所有初始数据, 确认继续吗?清空后, 数据描述文件也将被删除.", "清空数据项", ExMessageBoxIcon.Warning, ExMessageBoxButton.YesNo) == DialogResult.No)
                return;
            try
            {
                File.Delete(data_file_path);
            }
            catch (Exception ex) { ExMessageBox.Show(this, "删除文件失败, 错误信息:" + ex.Message, "删除失败", ExMessageBoxIcon.Error); }
            data_profile = null;
            dgvData.Rows.Clear();
        }

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loading_detail)
                return;
            if (e.RowIndex < 0)
                return;
            data_profile.data_list[e.RowIndex] = readDataFromRow(e.RowIndex);
            data_profile.toXmlFile(root_path);
        }
    }
}
