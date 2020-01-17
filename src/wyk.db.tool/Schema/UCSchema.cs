using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using wyk.basic;
using wyk.ui;

namespace wyk.db.tool.Schema
{
    public partial class UCSchema : ExUserControl
    {
        FrmMain root;
        ValuePairList typeList = new ValuePairList();
        public UCSchema(FrmMain Root)
        {
            root = Root;
            InitializeComponent();
        }

        private void UCSchema_Load(object sender, EventArgs e)
        {
            DBSchemaName dBSchemaName = new DBSchemaName(); 
            FieldInfo[] fields = typeof(DBSchemaName).GetFields();
            foreach(FieldInfo info in fields)
            {
                try
                {
                    string value = info.GetValue(dBSchemaName).ToString();
                    typeList.set(info.Name, info.GetValue(dBSchemaName).ToString());
                    lb.Items.Add(info.Name);
                }
                catch { }
            }
            if (lb.Items.Count > 0)
            {
                lb.SelectedIndex = 0;
            }
            lb_Click(null, null);
        }

        private void lb_Click(object sender, EventArgs e)
        {
            if (root.connection.db_type == DBType.Unknown)
                return;
            string schema = "";
            if (lb.SelectedIndex >= 0)
            {
                try
                {
                    schema = typeList.get(lb.SelectedItem.ToString()).value;
                }
                catch { }
            }
            DataTable data = DBQuery.schema(root.connection.connection_string, schema, out string msg);
            if (msg != "")
            {
                ExMessageBox.Show(root, msg, "提示", ExMessageBoxIcon.Error);
                return;
            }
            dgv.DataSource = data;
        }

        private void UCSchema_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lb_Click(null, null);
            }
        }

        private void dgv_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            //由于Columns列含有貌似图片的信息, 但是转换出错, 需要实现此方法跳过错误, 不然该表无法显示
            e.Cancel = true;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string[] parts = txtColFilter.Text.Split(',');
            List<int> cols = new List<int>();
            foreach(string part in parts)
            {
                try
                {
                    int col = Convert.ToInt32(part);
                    if (col >= 0 && col < dgv.ColumnCount)
                        cols.Add(col);
                }
                catch { }
            }
            for(int i = 0; i < dgv.Columns.Count; i++)
            {
                if (cols.Contains(i))
                    dgv.Columns[i].Visible = true;
                else
                    dgv.Columns[i].Visible = false;
            }
        }
    }
}
