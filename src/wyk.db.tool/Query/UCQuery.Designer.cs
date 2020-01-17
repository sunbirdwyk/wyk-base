using wyk.ui;

namespace wyk.db.tool.Query
{
    partial class UCQuery
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sc0 = new System.Windows.Forms.SplitContainer();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tlpDBInfo = new System.Windows.Forms.TableLayoutPanel();
            this.cbTableList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.cbShowContent = new System.Windows.Forms.ComboBox();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.sc1 = new System.Windows.Forms.SplitContainer();
            this.tlpQuery = new System.Windows.Forms.TableLayoutPanel();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnQuery = new ExTextButton();
            this.btnClear = new ExTextButton();
            this.btnExport = new ExTextButton();
            ((System.ComponentModel.ISupportInitialize)(this.sc0)).BeginInit();
            this.sc0.Panel1.SuspendLayout();
            this.sc0.Panel2.SuspendLayout();
            this.sc0.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.tlpDBInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).BeginInit();
            this.sc1.Panel1.SuspendLayout();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            this.tlpQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // sc0
            // 
            this.sc0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sc0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc0.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc0.Location = new System.Drawing.Point(0, 0);
            this.sc0.Name = "sc0";
            // 
            // sc0.Panel1
            // 
            this.sc0.Panel1.Controls.Add(this.tlpLeft);
            this.sc0.Panel1MinSize = 200;
            // 
            // sc0.Panel2
            // 
            this.sc0.Panel2.Controls.Add(this.sc1);
            this.sc0.Size = new System.Drawing.Size(772, 492);
            this.sc0.SplitterDistance = 200;
            this.sc0.SplitterWidth = 2;
            this.sc0.TabIndex = 0;
            // 
            // tlpLeft
            // 
            this.tlpLeft.BackColor = System.Drawing.Color.FloralWhite;
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.label1, 0, 0);
            this.tlpLeft.Controls.Add(this.tlpDBInfo, 0, 1);
            this.tlpLeft.Controls.Add(this.dgvInfo, 0, 2);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(0, 0);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 3;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Size = new System.Drawing.Size(196, 488);
            this.tlpLeft.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "相关信息";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpDBInfo
            // 
            this.tlpDBInfo.ColumnCount = 2;
            this.tlpDBInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpDBInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDBInfo.Controls.Add(this.cbTableList, 1, 2);
            this.tlpDBInfo.Controls.Add(this.label4, 0, 2);
            this.tlpDBInfo.Controls.Add(this.label3, 0, 1);
            this.tlpDBInfo.Controls.Add(this.label2, 0, 0);
            this.tlpDBInfo.Controls.Add(this.txtDatabaseName, 1, 0);
            this.tlpDBInfo.Controls.Add(this.cbShowContent, 1, 1);
            this.tlpDBInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDBInfo.Location = new System.Drawing.Point(0, 20);
            this.tlpDBInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDBInfo.Name = "tlpDBInfo";
            this.tlpDBInfo.RowCount = 4;
            this.tlpDBInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDBInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDBInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDBInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDBInfo.Size = new System.Drawing.Size(196, 90);
            this.tlpDBInfo.TabIndex = 1;
            // 
            // cbTableList
            // 
            this.cbTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTableList.Enabled = false;
            this.cbTableList.FormattingEnabled = true;
            this.cbTableList.Items.AddRange(new object[] {
            "数据表列表",
            "数据列列表",
            "视图列表"});
            this.cbTableList.Location = new System.Drawing.Point(83, 63);
            this.cbTableList.Name = "cbTableList";
            this.cbTableList.Size = new System.Drawing.Size(110, 25);
            this.cbTableList.TabIndex = 5;
            this.cbTableList.TabStop = false;
            this.cbTableList.SelectedIndexChanged += new System.EventHandler(this.cbTableList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "数据表:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "显示内容:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据库名:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.BackColor = System.Drawing.Color.White;
            this.txtDatabaseName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDatabaseName.Location = new System.Drawing.Point(83, 3);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.ReadOnly = true;
            this.txtDatabaseName.Size = new System.Drawing.Size(110, 23);
            this.txtDatabaseName.TabIndex = 1;
            this.txtDatabaseName.TabStop = false;
            // 
            // cbShowContent
            // 
            this.cbShowContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShowContent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShowContent.FormattingEnabled = true;
            this.cbShowContent.Items.AddRange(new object[] {
            "数据表列表",
            "数据列列表",
            "视图列表"});
            this.cbShowContent.Location = new System.Drawing.Point(83, 33);
            this.cbShowContent.Name = "cbShowContent";
            this.cbShowContent.Size = new System.Drawing.Size(110, 25);
            this.cbShowContent.TabIndex = 3;
            this.cbShowContent.TabStop = false;
            this.cbShowContent.SelectedIndexChanged += new System.EventHandler(this.cbShowContent_SelectedIndexChanged);
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.AllowUserToResizeColumns = false;
            this.dgvInfo.AllowUserToResizeRows = false;
            this.dgvInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInfo.BackgroundColor = System.Drawing.Color.Ivory;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.Location = new System.Drawing.Point(0, 110);
            this.dgvInfo.Margin = new System.Windows.Forms.Padding(0);
            this.dgvInfo.MultiSelect = false;
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.ReadOnly = true;
            this.dgvInfo.RowHeadersVisible = false;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(196, 378);
            this.dgvInfo.TabIndex = 2;
            this.dgvInfo.TabStop = false;
            // 
            // sc1
            // 
            this.sc1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc1.Location = new System.Drawing.Point(0, 0);
            this.sc1.Name = "sc1";
            this.sc1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc1.Panel1
            // 
            this.sc1.Panel1.Controls.Add(this.tlpQuery);
            this.sc1.Panel1MinSize = 200;
            // 
            // sc1.Panel2
            // 
            this.sc1.Panel2.Controls.Add(this.dgvResult);
            this.sc1.Panel2MinSize = 200;
            this.sc1.Size = new System.Drawing.Size(570, 492);
            this.sc1.SplitterDistance = 279;
            this.sc1.SplitterWidth = 2;
            this.sc1.TabIndex = 0;
            // 
            // tlpQuery
            // 
            this.tlpQuery.ColumnCount = 4;
            this.tlpQuery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpQuery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpQuery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpQuery.Controls.Add(this.btnClear, 1, 1);
            this.tlpQuery.Controls.Add(this.txtQuery, 0, 0);
            this.tlpQuery.Controls.Add(this.btnQuery, 0, 1);
            this.tlpQuery.Controls.Add(this.btnExport, 3, 1);
            this.tlpQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQuery.Location = new System.Drawing.Point(0, 0);
            this.tlpQuery.Name = "tlpQuery";
            this.tlpQuery.RowCount = 2;
            this.tlpQuery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpQuery.Size = new System.Drawing.Size(566, 275);
            this.tlpQuery.TabIndex = 0;
            // 
            // txtQuery
            // 
            this.tlpQuery.SetColumnSpan(this.txtQuery, 4);
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Location = new System.Drawing.Point(3, 3);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuery.Size = new System.Drawing.Size(560, 239);
            this.txtQuery.TabIndex = 0;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeColumns = false;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvResult.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OldLace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(0);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(566, 207);
            this.dgvResult.TabIndex = 3;
            this.dgvResult.TabStop = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnQuery.IsReverse = false;
            this.btnQuery.Location = new System.Drawing.Point(3, 248);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.PrimaryColor = System.Drawing.Color.RoyalBlue;
            this.btnQuery.SecondaryColor = System.Drawing.Color.White;
            this.btnQuery.Size = new System.Drawing.Size(74, 24);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "执行";
            this.btnQuery.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnClear.IsReverse = false;
            this.btnClear.Location = new System.Drawing.Point(83, 248);
            this.btnClear.Name = "btnClear";
            this.btnClear.PrimaryColor = System.Drawing.Color.Gray;
            this.btnClear.SecondaryColor = System.Drawing.Color.White;
            this.btnClear.Size = new System.Drawing.Size(74, 24);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnExport.IsReverse = false;
            this.btnExport.Location = new System.Drawing.Point(489, 248);
            this.btnExport.Name = "btnExport";
            this.btnExport.PrimaryColor = System.Drawing.Color.ForestGreen;
            this.btnExport.SecondaryColor = System.Drawing.Color.White;
            this.btnExport.Size = new System.Drawing.Size(74, 24);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // UCQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.sc0);
            this.Name = "UCQuery";
            this.Size = new System.Drawing.Size(772, 492);
            this.Load += new System.EventHandler(this.UCQuery_Load);
            this.VisibleChanged += new System.EventHandler(this.UCQuery_VisibleChanged);
            this.sc0.Panel1.ResumeLayout(false);
            this.sc0.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc0)).EndInit();
            this.sc0.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlpLeft.PerformLayout();
            this.tlpDBInfo.ResumeLayout(false);
            this.tlpDBInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.sc1.Panel1.ResumeLayout(false);
            this.sc1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).EndInit();
            this.sc1.ResumeLayout(false);
            this.tlpQuery.ResumeLayout(false);
            this.tlpQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sc0;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.SplitContainer sc1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tlpDBInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbShowContent;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.TableLayoutPanel tlpQuery;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTableList;
        private ExTextButton btnClear;
        private ExTextButton btnQuery;
        private ExTextButton btnExport;
    }
}
