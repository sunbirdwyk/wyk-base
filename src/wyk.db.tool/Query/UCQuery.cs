using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using wyk.ui;

namespace wyk.db.tool.Query
{
    public partial class UCQuery : ExUserControl
    {
        FrmMain root;
        string[] table_list = null;
        string[] view_list = null;
        DataTable dtColumns = new DataTable();
        DataTable dtDataTypes = new DataTable();
        public UCQuery(FrmMain Root)
        {
            root = Root;
            InitializeComponent();
        }

        private void UCQuery_Load(object sender, EventArgs e)
        {
            loadDBInfo();
        }

        private void loadDBInfo()
        {
            table_list = null;
            view_list = null;
            dtDataTypes = new DataTable();
            dtColumns = new DataTable();
            if (root.connection_status <= 0)
            {
                txtDatabaseName.Text = "";
                cbShowContent.SelectedIndex = -1;
            }
            else
            {
                refreshTableList();
                txtDatabaseName.Text = root.connection.database;
                cbShowContent.SelectedIndex = 0;
            }
        }

        private void UCQuery_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                loadDBInfo();
        }

        private void cbShowContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshTableList();
            dgvInfo.Columns.Clear();
            cbTableList.Items.Clear();
            cbTableList.Enabled = false;
            int row;
            switch (cbShowContent.SelectedIndex)
            {
                case 0://表
                    dgvInfo.Columns.Add("colTableList", "表名");
                    foreach(string table in table_list)
                    {
                        row = dgvInfo.Rows.Add();
                        dgvInfo.Rows[row].Cells[0].Value = table;
                    }                  
                    break;
                case 1://列
                    refreshColumnList();
                    cbTableList.Enabled = true;
                    try
                    {
                        cbTableList.Items.AddRange(table_list);
                        cbTableList.SelectedIndex = 0;
                    }
                    catch { }
                    break;
                case 2://视图
                    dgvInfo.Columns.Add("colViewList", "视图名");
                    foreach (string view in view_list)
                    {
                        row = dgvInfo.Rows.Add();
                        dgvInfo.Rows[row].Cells[0].Value = view;
                    }
                    break;
                default://空
                    break;
            }
        }

        private void refreshTableList()
        {
            if (table_list==null || view_list==null)
            {
                DataTable data = DBQuery.schema(root.connection, DBSchemaName.Tables, out string msg);
                if (msg == "")
                {
                    ArrayList tables = new ArrayList();
                    ArrayList views = new ArrayList();
                    for(int i = 0; i < data.Rows.Count; i++)
                    {
                        string name = data.Rows[i]["TABLE_NAME"].ToString();
                        string type = data.Rows[i]["TABLE_TYPE"].ToString();
                        if (type.ToLower() == "table")
                            tables.Add(name);
                        else if (type.ToLower() == "view")
                            views.Add(name);
                    }
                    table_list = tables.ToArray(typeof(string)) as string[];
                    view_list = views.ToArray(typeof(string)) as string[];
                }
            }
        }

        private void refreshColumnList()
        {
            if (dtDataTypes.Columns.Count <= 0)
            {
                dtDataTypes.Columns.Add("TypeId");
                dtDataTypes.Columns.Add("TypeName");
                DataTable data = DBQuery.schema(root.connection, DBSchemaName.DataTypes, out string msg);
                if (msg == "")
                {
                    foreach(DataRow dr in data.Rows)
                    {
                        string id = dr["NativeDataType"].ToString();
                        int idx = -1;
                        for(int i = 0; i < dtDataTypes.Rows.Count; i++)
                        {
                            if (dtDataTypes.Rows[i][0].ToString() == id)
                            {
                                idx = i;
                                break;
                            }
                        }
                        if (idx < 0)
                        {
                            DataRow row = dtDataTypes.NewRow();
                            row[0] = id;
                            row[1] = dr["TypeName"];
                            dtDataTypes.Rows.Add(row);
                        }
                        else
                        {
                            dtDataTypes.Rows[idx][1] = dtDataTypes.Rows[idx][1].ToString() + "|" + dr["TypeName"].ToString();
                        }                      
                    }
                }
            }
            if (dtColumns.Columns.Count <= 0)
            {
                dtColumns.Columns.Add("table");
                dtColumns.Columns.Add("column");
                dtColumns.Columns.Add("type");
                dtColumns.Columns.Add("nullable");
                dtColumns.Columns.Add("length");
                DataTable data = DBQuery.schema(root.connection, DBSchemaName.Columns, out string msg);
                if (msg == "")
                {
                    foreach(DataRow dr in data.Rows)
                    {
                        if (dr["TABLE_SCHEMA"].ToString() == "dbo")
                        {
                            DataRow row = dtColumns.NewRow();
                            row[0] = dr["TABLE_NAME"];
                            row[1] = dr["COLUMN_NAME"];
                            string data_type = dr["DATA_TYPE"].ToString();
                            foreach(DataRow dtr in dtDataTypes.Rows)
                            {
                                if (dtr[0].ToString() == data_type)
                                {
                                    data_type = dtr[1].ToString();
                                    break;
                                }
                            }
                            row[2] = data_type;
                            row[3] = dr["IS_NULLABLE"];
                            string length = dr["CHARACTER_MAXIMUM_LENGTH"].ToString();
                            if (length.Trim() == "")
                            {
                                length = dr["NUMERIC_PRECISION"].ToString();
                                string test_post = dr["NUMERIC_SCALE"].ToString();
                                if (test_post.Trim() != "")
                                    length = length + "," + test_post;
                            }
                            row[4] = length;
                            dtColumns.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void cbTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvInfo.Columns.Clear();
            dgvInfo.Columns.Add("colColName", "列名");
            dgvInfo.Columns.Add("colColType", "类型");
            dgvInfo.Columns.Add("colAllowNull", "允许空");
            dgvInfo.Columns.Add("colColType", "长度");
            string table = "";
            if (cbTableList.SelectedIndex >= 0)
                table = cbTableList.SelectedItem.ToString();
            if (table.Trim() == "")
                return;
            foreach (DataRow dr in dtColumns.Rows)
            {
                if (dr["table"].ToString() == table)
                {
                    int row = dgvInfo.Rows.Add();
                    dgvInfo.Rows[row].Cells[0].Value = dr["column"];
                    dgvInfo.Rows[row].Cells[1].Value = dr["type"];
                    dgvInfo.Rows[row].Cells[2].Value = dr["nullable"];
                    dgvInfo.Rows[row].Cells[3].Value = dr["length"];
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (ExMessageBox.Show(root, "清空当前sql语句内容吗?", "清空Sql", ExMessageBoxIcon.Question, ExMessageBoxButton.YesNo) == DialogResult.No)
                return;
            txtQuery.Text = "";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExMessageBox.Show(root, "当前功能暂未支持!");
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            DataTable data = DBQuery.query(txtQuery.Text, root.connection, null, out string msg);
            dgvResult.DataSource = data;
            if (msg != "")
                ExMessageBox.Show(root, msg, "错误信息", ExMessageBoxIcon.Error);
        }
    }
}
