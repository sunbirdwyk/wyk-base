using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    public partial class FrmPresetTable : ExForm
    {
        FrmMain root;
        UCTableMaintain parent;
        public FrmPresetTable(FrmMain Root, UCTableMaintain Parent)
        {
            root = Root;
            parent = Parent;
            SuperiorForm = root;
            InitializeComponent();
        }

        private void FrmPresetTable_Load(object sender, EventArgs e)
        {
            foreach (DBTable table in DBPresetUtil.preset_tables)
            {
                chlPreset.Items.Add(table.table_name, true);
            }
            if (chlPreset.Items.Count > 0)
                chlPreset.SelectedIndex = 0;
            chlPreset_Click(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<DBTable> selected = new List<DBTable>();
            for(int i = 0; i < chlPreset.Items.Count; i++)
            {
                if(chlPreset.GetItemChecked(i))
                {
                    selected.Add(DBPresetUtil.preset_tables[i]);
                }
            }
            if (selected.Count <= 0)
            {
                ExMessageBox.Show(this, "您当前没有选择任何表");
                return;
            }
            parent.addPresetTables(selected);
            this.Close();
        }

        private void chlPreset_Click(object sender, EventArgs e)
        {
            if (chlPreset.SelectedIndex >= 0)
            {
                dgvColumns.Visible = true;
                loadCurrentColumns();
            }
            else
            {
                dgvColumns.Visible = false;
            }
        }

        private void loadCurrentColumns()
        {
            if (chlPreset.SelectedIndex < 0)
                return;
            dgvColumns.Rows.Clear();
            foreach (DBColumn col in DBPresetUtil.preset_tables[chlPreset.SelectedIndex].columns)
            {
                int row = dgvColumns.Rows.Add();
                dgvColumns.Rows[row].Cells[UCTableMaintain.COL_PRIMARY].Value = col.is_primary;
                dgvColumns.Rows[row].Cells[UCTableMaintain.COL_IDENTITY].Value = col.is_identity;
                dgvColumns.Rows[row].Cells[UCTableMaintain.COL_NAME].Value = col.name;
                dgvColumns.Rows[row].Cells[UCTableMaintain.COL_TYPE].Value = col.DataType;
                dgvColumns.Rows[row].Cells[UCTableMaintain.COL_LENGTH].Value = col.data_length;
                dgvColumns.Rows[row].Cells[UCTableMaintain.COL_LENGTH2].Value = col.data_length2;
                dgvColumns.Rows[row].Cells[UCTableMaintain.COL_ALLOWNULL].Value = col.allow_null;
                dgvColumns.Rows[row].Cells[UCTableMaintain.COL_DEFAULT].Value = col.default_value;
                dgvColumns.Rows[row].Cells[UCTableMaintain.COL_DESCRIPTION].Value = col.data_description;
            }
        }
    }
}
