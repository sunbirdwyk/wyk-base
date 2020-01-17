namespace wyk.db.tool.TableMaintain
{
    partial class FrmPresetTable
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
            this.tlp0 = new System.Windows.Forms.TableLayoutPanel();
            this.pList = new System.Windows.Forms.Panel();
            this.chlPreset = new System.Windows.Forms.CheckedListBox();
            this.dgvColumns = new wyk.ui.ExDataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new wyk.ui.ExTextButton();
            this.btnOK = new wyk.ui.ExTextButton();
            this.col0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlp0.SuspendLayout();
            this.pList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(660, 2);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Location = new System.Drawing.Point(580, 2);
            // 
            // btn_maximize
            // 
            this.btn_maximize.Location = new System.Drawing.Point(620, 2);
            // 
            // tlp0
            // 
            this.tlp0.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlp0.ColumnCount = 2;
            this.tlp0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tlp0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp0.Controls.Add(this.pList, 0, 0);
            this.tlp0.Controls.Add(this.dgvColumns, 1, 0);
            this.tlp0.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tlp0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp0.Location = new System.Drawing.Point(0, 25);
            this.tlp0.Name = "tlp0";
            this.tlp0.RowCount = 2;
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp0.Size = new System.Drawing.Size(700, 425);
            this.tlp0.TabIndex = 3;
            // 
            // pList
            // 
            this.pList.BackColor = System.Drawing.Color.White;
            this.pList.Controls.Add(this.chlPreset);
            this.pList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pList.Location = new System.Drawing.Point(0, 0);
            this.pList.Margin = new System.Windows.Forms.Padding(0);
            this.pList.Name = "pList";
            this.pList.Size = new System.Drawing.Size(220, 385);
            this.pList.TabIndex = 0;
            // 
            // chlPreset
            // 
            this.chlPreset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chlPreset.FormattingEnabled = true;
            this.chlPreset.Location = new System.Drawing.Point(0, 0);
            this.chlPreset.Name = "chlPreset";
            this.chlPreset.Size = new System.Drawing.Size(220, 385);
            this.chlPreset.TabIndex = 0;
            this.chlPreset.Click += new System.EventHandler(this.chlPreset_Click);
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            this.dgvColumns.AllowUserToResizeColumns = false;
            this.dgvColumns.AllowUserToResizeRows = false;
            this.dgvColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvColumns.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvColumns.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvColumns.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col0,
            this.col8,
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col9,
            this.col10,
            this.col7});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColumns.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(220, 0);
            this.dgvColumns.Margin = new System.Windows.Forms.Padding(0);
            this.dgvColumns.MultiSelect = false;
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.ReadOnly = true;
            this.dgvColumns.RowHeadersVisible = false;
            this.dgvColumns.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvColumns.RowTemplate.Height = 23;
            this.dgvColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvColumns.Size = new System.Drawing.Size(480, 385);
            this.dgvColumns.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.tlp0.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 385);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(700, 40);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.IsReverse = false;
            this.btnCancel.Location = new System.Drawing.Point(635, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PrimaryColor = System.Drawing.Color.Gray;
            this.btnCancel.SecondaryColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(60, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnOK.IsReverse = false;
            this.btnOK.Location = new System.Drawing.Point(525, 5);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnOK.Name = "btnOK";
            this.btnOK.PrimaryColor = System.Drawing.Color.ForestGreen;
            this.btnOK.SecondaryColor = System.Drawing.Color.White;
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "创建所选表";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // col0
            // 
            this.col0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col0.HeaderText = "主键";
            this.col0.MinimumWidth = 40;
            this.col0.Name = "col0";
            this.col0.ReadOnly = true;
            this.col0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col0.Width = 40;
            // 
            // col8
            // 
            this.col8.HeaderText = "自增长";
            this.col8.MinimumWidth = 50;
            this.col8.Name = "col8";
            this.col8.ReadOnly = true;
            this.col8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col8.Width = 50;
            // 
            // col1
            // 
            this.col1.HeaderText = "列名";
            this.col1.MinimumWidth = 100;
            this.col1.Name = "col1";
            this.col1.ReadOnly = true;
            this.col1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col2
            // 
            this.col2.HeaderText = "类型";
            this.col2.MinimumWidth = 80;
            this.col2.Name = "col2";
            this.col2.ReadOnly = true;
            this.col2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col2.Width = 80;
            // 
            // col3
            // 
            this.col3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col3.HeaderText = "长度";
            this.col3.MinimumWidth = 40;
            this.col3.Name = "col3";
            this.col3.ReadOnly = true;
            this.col3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col3.Width = 40;
            // 
            // col4
            // 
            this.col4.HeaderText = "长度2";
            this.col4.MinimumWidth = 50;
            this.col4.Name = "col4";
            this.col4.ReadOnly = true;
            this.col4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col4.Width = 50;
            // 
            // col5
            // 
            this.col5.HeaderText = "允许空";
            this.col5.MinimumWidth = 50;
            this.col5.Name = "col5";
            this.col5.ReadOnly = true;
            this.col5.Width = 50;
            // 
            // col6
            // 
            this.col6.HeaderText = "默认值";
            this.col6.MinimumWidth = 50;
            this.col6.Name = "col6";
            this.col6.ReadOnly = true;
            this.col6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col6.Width = 50;
            // 
            // col9
            // 
            this.col9.HeaderText = "Json忽略";
            this.col9.Name = "col9";
            this.col9.ReadOnly = true;
            this.col9.Width = 64;
            // 
            // col10
            // 
            this.col10.HeaderText = "替换名";
            this.col10.Name = "col10";
            this.col10.ReadOnly = true;
            this.col10.Width = 69;
            // 
            // col7
            // 
            this.col7.HeaderText = "说明";
            this.col7.MinimumWidth = 40;
            this.col7.Name = "col7";
            this.col7.ReadOnly = true;
            this.col7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col7.Width = 40;
            // 
            // FrmPresetTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.tlp0);
            this.Name = "FrmPresetTable";
            this.StatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.StatusBar.Height = 20;
            this.StatusBar.ShouldShow = false;
            this.StatusBar.Text = "";
            this.StatusBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBar.TextColor = System.Drawing.Color.White;
            this.StatusBar.TextFont = new System.Drawing.Font("微软雅黑", 8F);
            this.Text = "预创建表";
            this.TitleBar.ActionButtonPosition = wyk.ui.enums.FormActionButtonPosition.Center;
            this.TitleBar.ActionButtonStyle = wyk.ui.enums.FormActionButtonStyle.Flat;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(226)))));
            this.TitleBar.Height = 25;
            this.TitleBar.ShouldShow = true;
            this.TitleBar.TextColor = System.Drawing.Color.White;
            this.TitleBar.TextFont = new System.Drawing.Font("微软雅黑", 9F);
            this.TitleBar.UIMode = wyk.ui.enums.FormTitleBarUIMode.Separated;
            this.Load += new System.EventHandler(this.FrmPresetTable_Load);
            this.Controls.SetChildIndex(this.btn_minimize, 0);
            this.Controls.SetChildIndex(this.btn_maximize, 0);
            this.Controls.SetChildIndex(this.btn_close, 0);
            this.Controls.SetChildIndex(this.tlp0, 0);
            this.tlp0.ResumeLayout(false);
            this.pList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp0;
        private System.Windows.Forms.Panel pList;
        private ui.ExDataGridView dgvColumns;
        private System.Windows.Forms.CheckedListBox chlPreset;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ui.ExTextButton btnCancel;
        private ui.ExTextButton btnOK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col0;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col8;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col9;
        private System.Windows.Forms.DataGridViewTextBoxColumn col10;
        private System.Windows.Forms.DataGridViewTextBoxColumn col7;
    }
}