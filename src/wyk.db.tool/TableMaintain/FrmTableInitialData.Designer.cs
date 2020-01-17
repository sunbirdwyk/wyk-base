using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    partial class FrmTableInitialData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tlp0 = new System.Windows.Forms.TableLayoutPanel();
            this.flpAction = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new wyk.ui.ExTextButton();
            this.btnDelete = new wyk.ui.ExTextButton();
            this.btnClear = new wyk.ui.ExTextButton();
            this.dgvData = new wyk.ui.ExDataGridView();
            this.tlp0.SuspendLayout();
            this.flpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(560, 2);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Location = new System.Drawing.Point(480, 2);
            // 
            // btn_maximize
            // 
            this.btn_maximize.Location = new System.Drawing.Point(520, 2);
            // 
            // cbTables
            // 
            this.cbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Location = new System.Drawing.Point(55, 2);
            this.cbTables.Margin = new System.Windows.Forms.Padding(2);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(220, 25);
            this.cbTables.TabIndex = 3;
            this.cbTables.SelectedIndexChanged += new System.EventHandler(this.cbTables_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "数据表:";
            // 
            // tlp0
            // 
            this.tlp0.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp0.ColumnCount = 1;
            this.tlp0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp0.Controls.Add(this.flpAction, 0, 0);
            this.tlp0.Controls.Add(this.dgvData, 0, 1);
            this.tlp0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp0.Location = new System.Drawing.Point(0, 25);
            this.tlp0.Name = "tlp0";
            this.tlp0.RowCount = 2;
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp0.Size = new System.Drawing.Size(600, 475);
            this.tlp0.TabIndex = 6;
            // 
            // flpAction
            // 
            this.flpAction.Controls.Add(this.label1);
            this.flpAction.Controls.Add(this.cbTables);
            this.flpAction.Controls.Add(this.btnAdd);
            this.flpAction.Controls.Add(this.btnDelete);
            this.flpAction.Controls.Add(this.btnClear);
            this.flpAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAction.Location = new System.Drawing.Point(1, 1);
            this.flpAction.Margin = new System.Windows.Forms.Padding(0);
            this.flpAction.Name = "flpAction";
            this.flpAction.Size = new System.Drawing.Size(598, 30);
            this.flpAction.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAdd.IsReverse = false;
            this.btnAdd.Location = new System.Drawing.Point(282, 3);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PrimaryColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.SecondaryColor = System.Drawing.Color.White;
            this.btnAdd.Size = new System.Drawing.Size(60, 24);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDelete.IsReverse = false;
            this.btnDelete.Location = new System.Drawing.Point(348, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PrimaryColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.SecondaryColor = System.Drawing.Color.White;
            this.btnDelete.Size = new System.Drawing.Size(60, 24);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnClear.IsReverse = false;
            this.btnClear.Location = new System.Drawing.Point(414, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.PrimaryColor = System.Drawing.Color.Peru;
            this.btnClear.SecondaryColor = System.Drawing.Color.White;
            this.btnClear.Size = new System.Drawing.Size(60, 24);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(1, 32);
            this.dgvData.Margin = new System.Windows.Forms.Padding(0);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(598, 442);
            this.dgvData.TabIndex = 7;
            this.dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
            // 
            // FrmTableInitialData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.tlp0);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "FrmTableInitialData";
            this.ShowIconOnUI = false;
            this.ShowInTaskbar = false;
            this.StatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.StatusBar.Height = 20;
            this.StatusBar.ShouldShow = false;
            this.StatusBar.Text = "";
            this.StatusBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBar.TextColor = System.Drawing.Color.White;
            this.StatusBar.TextFont = new System.Drawing.Font("微软雅黑", 8F);
            this.Text = "数据库基础数据";
            this.TitleBar.ActionButtonPosition = wyk.ui.enums.FormActionButtonPosition.Center;
            this.TitleBar.ActionButtonStyle = wyk.ui.enums.FormActionButtonStyle.Flat;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(226)))));
            this.TitleBar.Height = 25;
            this.TitleBar.ShouldShow = true;
            this.TitleBar.TextColor = System.Drawing.Color.White;
            this.TitleBar.TextFont = new System.Drawing.Font("微软雅黑", 9F);
            this.TitleBar.UIMode = wyk.ui.enums.FormTitleBarUIMode.Separated;
            this.Load += new System.EventHandler(this.FrmTableInitialData_Load);
            this.Controls.SetChildIndex(this.btn_minimize, 0);
            this.Controls.SetChildIndex(this.btn_maximize, 0);
            this.Controls.SetChildIndex(this.btn_close, 0);
            this.Controls.SetChildIndex(this.tlp0, 0);
            this.tlp0.ResumeLayout(false);
            this.flpAction.ResumeLayout(false);
            this.flpAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tlp0;
        private System.Windows.Forms.FlowLayoutPanel flpAction;
        private ExDataGridView dgvData;
        private ExTextButton btnAdd;
        private ExTextButton btnDelete;
        private ExTextButton btnClear;
    }
}