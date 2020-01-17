namespace wyk.db.tool
{
    partial class FrmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSchema = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTableMaintain = new System.Windows.Forms.ToolStripButton();
            this.tsbDBConnection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDBStatus = new System.Windows.Forms.ToolStripButton();
            this.tstDBConnection = new System.Windows.Forms.ToolStripTextBox();
            this.tslDBConnection = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.pBody = new System.Windows.Forms.Panel();
            this.pMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(1559, 3);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Location = new System.Drawing.Point(1477, 3);
            // 
            // btn_maximize
            // 
            this.btn_maximize.Location = new System.Drawing.Point(1518, 3);
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pMain.Controls.Add(this.tableLayoutPanel1);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(1, 26);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1598, 833);
            this.pMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tsMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pBody, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1598, 833);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tsMain
            // 
            this.tsMain.BackColor = System.Drawing.Color.White;
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.tsbSchema,
            this.toolStripSeparator3,
            this.tsbQuery,
            this.toolStripSeparator4,
            this.btnTableMaintain,
            this.tsbDBConnection,
            this.toolStripSeparator6,
            this.tsbDBStatus,
            this.tstDBConnection,
            this.tslDBConnection,
            this.toolStripSeparator5,
            this.toolStripSeparator7});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1598, 45);
            this.tsMain.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
            // 
            // tsbSchema
            // 
            this.tsbSchema.Image = global::wyk.db.tool.Properties.Resources.schema;
            this.tsbSchema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSchema.Name = "tsbSchema";
            this.tsbSchema.Size = new System.Drawing.Size(104, 42);
            this.tsbSchema.Text = "数据库结构";
            this.tsbSchema.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
            // 
            // tsbQuery
            // 
            this.tsbQuery.Image = global::wyk.db.tool.Properties.Resources.query;
            this.tsbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuery.Name = "tsbQuery";
            this.tsbQuery.Size = new System.Drawing.Size(104, 42);
            this.tsbQuery.Text = "数据库查询";
            this.tsbQuery.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
            // 
            // btnTableMaintain
            // 
            this.btnTableMaintain.Image = global::wyk.db.tool.Properties.Resources.table;
            this.btnTableMaintain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTableMaintain.Name = "btnTableMaintain";
            this.btnTableMaintain.Size = new System.Drawing.Size(78, 42);
            this.btnTableMaintain.Text = "表维护";
            this.btnTableMaintain.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // tsbDBConnection
            // 
            this.tsbDBConnection.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDBConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDBConnection.Image = global::wyk.db.tool.Properties.Resources.config;
            this.tsbDBConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDBConnection.Name = "tsbDBConnection";
            this.tsbDBConnection.Size = new System.Drawing.Size(32, 42);
            this.tsbDBConnection.Click += new System.EventHandler(this.tsbDBConnection_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 45);
            // 
            // tsbDBStatus
            // 
            this.tsbDBStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDBStatus.AutoSize = false;
            this.tsbDBStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDBStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDBStatus.Name = "tsbDBStatus";
            this.tsbDBStatus.Size = new System.Drawing.Size(32, 42);
            this.tsbDBStatus.Click += new System.EventHandler(this.tsbDBStatus_Click);
            // 
            // tstDBConnection
            // 
            this.tstDBConnection.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstDBConnection.BackColor = System.Drawing.Color.White;
            this.tstDBConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstDBConnection.Name = "tstDBConnection";
            this.tstDBConnection.ReadOnly = true;
            this.tstDBConnection.Size = new System.Drawing.Size(300, 45);
            // 
            // tslDBConnection
            // 
            this.tslDBConnection.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslDBConnection.Name = "tslDBConnection";
            this.tslDBConnection.Size = new System.Drawing.Size(75, 42);
            this.tslDBConnection.Text = "数据库连接:";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 45);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 45);
            // 
            // pBody
            // 
            this.pBody.BackColor = System.Drawing.Color.White;
            this.pBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBody.Location = new System.Drawing.Point(1, 47);
            this.pBody.Margin = new System.Windows.Forms.Padding(1, 2, 1, 0);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(1596, 786);
            this.pBody.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 880);
            this.Controls.Add(this.pMain);
            this.EdgeColor = System.Drawing.Color.SeaGreen;
            this.EdgeWidth = 1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "FrmMain";
            this.StatusBar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.StatusBar.Height = 20;
            this.StatusBar.ShouldShow = true;
            this.StatusBar.Text = "Copyright © Sunbird WYK";
            this.StatusBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBar.TextColor = System.Drawing.Color.White;
            this.StatusBar.TextFont = new System.Drawing.Font("Microsoft YaHei", 8F);
            this.Text = "数据库工具";
            this.TitleBar.ActionButtonPosition = wyk.ui.enums.FormActionButtonPosition.Center;
            this.TitleBar.ActionButtonStyle = wyk.ui.enums.FormActionButtonStyle.Flat;
            this.TitleBar.BackColor = System.Drawing.Color.SeaGreen;
            this.TitleBar.Height = 25;
            this.TitleBar.ShouldShow = true;
            this.TitleBar.TextColor = System.Drawing.Color.White;
            this.TitleBar.TextFont = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.TitleBar.UIMode = wyk.ui.enums.FormTitleBarUIMode.Separated;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Controls.SetChildIndex(this.pMain, 0);
            this.Controls.SetChildIndex(this.btn_minimize, 0);
            this.Controls.SetChildIndex(this.btn_maximize, 0);
            this.Controls.SetChildIndex(this.btn_close, 0);
            this.pMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.ToolStripButton tsbSchema;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel tslDBConnection;
        private System.Windows.Forms.ToolStripTextBox tstDBConnection;
        private System.Windows.Forms.ToolStripButton tsbDBConnection;
        private System.Windows.Forms.ToolStripButton tsbDBStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnTableMaintain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}

