using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    partial class UCTableMaintain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlp0 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSQLCreateTable = new wyk.ui.ExTextButton();
            this.flpAction2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddTable = new wyk.ui.ExTextButton();
            this.btnDeleteColumn = new wyk.ui.ExTextButton();
            this.btnAddColumn = new wyk.ui.ExTextButton();
            this.btnDeleteTable = new wyk.ui.ExTextButton();
            this.btnEditTable = new wyk.ui.ExTextButton();
            this.btnExportAdapter = new wyk.ui.ExTextButton();
            this.btnExportSpec = new wyk.ui.ExTextButton();
            this.pList = new System.Windows.Forms.Panel();
            this.lbTables = new System.Windows.Forms.ListBox();
            this.flpAction = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPresetTable = new wyk.ui.ExTextButton();
            this.btnTableData = new wyk.ui.ExTextButton();
            this.btnDBConfig = new wyk.ui.ExTextButton();
            this.lblDBStatus = new System.Windows.Forms.Label();
            this.tlpFolder = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnOpenWithVSCode = new System.Windows.Forms.Button();
            this.btnRefreshTables = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRootFolder = new System.Windows.Forms.TextBox();
            this.btnSelFolder = new System.Windows.Forms.Button();
            this.dgvColumns = new wyk.ui.ExDataGridView();
            this.col0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flp0 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProjectName = new System.Windows.Forms.ComboBox();
            this.btnNewProject = new wyk.ui.ExTextButton();
            this.btnDeleteProject = new wyk.ui.ExTextButton();
            this.lblTableDescription = new System.Windows.Forms.Label();
            this.cmsTableList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCreateTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteTable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTableData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableClass = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsColumnList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNewColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.selFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.cmsTypeCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlp0.SuspendLayout();
            this.flpAction2.SuspendLayout();
            this.pList.SuspendLayout();
            this.flpAction.SuspendLayout();
            this.tlpFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.flp0.SuspendLayout();
            this.cmsTableList.SuspendLayout();
            this.cmsColumnList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp0
            // 
            this.tlp0.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlp0.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp0.ColumnCount = 3;
            this.tlp0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlp0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tlp0.Controls.Add(this.btnSQLCreateTable, 2, 4);
            this.tlp0.Controls.Add(this.flpAction2, 0, 3);
            this.tlp0.Controls.Add(this.pList, 0, 4);
            this.tlp0.Controls.Add(this.flpAction, 0, 2);
            this.tlp0.Controls.Add(this.tlpFolder, 0, 1);
            this.tlp0.Controls.Add(this.dgvColumns, 1, 5);
            this.tlp0.Controls.Add(this.flp0, 0, 0);
            this.tlp0.Controls.Add(this.lblTableDescription, 1, 4);
            this.tlp0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp0.Location = new System.Drawing.Point(0, 0);
            this.tlp0.Name = "tlp0";
            this.tlp0.RowCount = 6;
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp0.Size = new System.Drawing.Size(800, 600);
            this.tlp0.TabIndex = 0;
            // 
            // btnSQLCreateTable
            // 
            this.btnSQLCreateTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSQLCreateTable.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSQLCreateTable.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnSQLCreateTable.IsReverse = false;
            this.btnSQLCreateTable.Location = new System.Drawing.Point(718, 125);
            this.btnSQLCreateTable.Margin = new System.Windows.Forms.Padding(0);
            this.btnSQLCreateTable.Name = "btnSQLCreateTable";
            this.btnSQLCreateTable.PrimaryColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSQLCreateTable.SecondaryColor = System.Drawing.Color.White;
            this.btnSQLCreateTable.Size = new System.Drawing.Size(81, 20);
            this.btnSQLCreateTable.TabIndex = 5;
            this.btnSQLCreateTable.Text = "建表SQL";
            this.btnSQLCreateTable.Click += new System.EventHandler(this.BtnSQLCreateTable_Click);
            // 
            // flpAction2
            // 
            this.flpAction2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlp0.SetColumnSpan(this.flpAction2, 3);
            this.flpAction2.Controls.Add(this.btnAddTable);
            this.flpAction2.Controls.Add(this.btnDeleteColumn);
            this.flpAction2.Controls.Add(this.btnAddColumn);
            this.flpAction2.Controls.Add(this.btnDeleteTable);
            this.flpAction2.Controls.Add(this.btnEditTable);
            this.flpAction2.Controls.Add(this.btnExportAdapter);
            this.flpAction2.Controls.Add(this.btnExportSpec);
            this.flpAction2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAction2.Location = new System.Drawing.Point(1, 94);
            this.flpAction2.Margin = new System.Windows.Forms.Padding(0);
            this.flpAction2.Name = "flpAction2";
            this.flpAction2.Size = new System.Drawing.Size(798, 30);
            this.flpAction2.TabIndex = 2;
            // 
            // btnAddTable
            // 
            this.btnAddTable.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAddTable.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnAddTable.IsReverse = false;
            this.btnAddTable.Location = new System.Drawing.Point(10, 3);
            this.btnAddTable.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.PrimaryColor = System.Drawing.Color.ForestGreen;
            this.btnAddTable.SecondaryColor = System.Drawing.Color.White;
            this.btnAddTable.Size = new System.Drawing.Size(60, 23);
            this.btnAddTable.TabIndex = 0;
            this.btnAddTable.Text = "新建表";
            this.btnAddTable.Click += new System.EventHandler(this.btnNewTable_Click);
            // 
            // btnDeleteColumn
            // 
            this.btnDeleteColumn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDeleteColumn.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnDeleteColumn.IsReverse = false;
            this.btnDeleteColumn.Location = new System.Drawing.Point(76, 3);
            this.btnDeleteColumn.Name = "btnDeleteColumn";
            this.btnDeleteColumn.PrimaryColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteColumn.SecondaryColor = System.Drawing.Color.White;
            this.btnDeleteColumn.Size = new System.Drawing.Size(60, 23);
            this.btnDeleteColumn.TabIndex = 5;
            this.btnDeleteColumn.Text = "删除列";
            this.btnDeleteColumn.Click += new System.EventHandler(this.btnDeleteColumn_Click);
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAddColumn.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnAddColumn.IsReverse = false;
            this.btnAddColumn.Location = new System.Drawing.Point(142, 3);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.PrimaryColor = System.Drawing.Color.RoyalBlue;
            this.btnAddColumn.SecondaryColor = System.Drawing.Color.White;
            this.btnAddColumn.Size = new System.Drawing.Size(60, 23);
            this.btnAddColumn.TabIndex = 4;
            this.btnAddColumn.Text = "新增列";
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDeleteTable.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnDeleteTable.IsReverse = false;
            this.btnDeleteTable.Location = new System.Drawing.Point(208, 3);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.PrimaryColor = System.Drawing.Color.MediumSeaGreen;
            this.btnDeleteTable.SecondaryColor = System.Drawing.Color.White;
            this.btnDeleteTable.Size = new System.Drawing.Size(60, 23);
            this.btnDeleteTable.TabIndex = 2;
            this.btnDeleteTable.Text = "删除表";
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // btnEditTable
            // 
            this.btnEditTable.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnEditTable.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnEditTable.IsReverse = false;
            this.btnEditTable.Location = new System.Drawing.Point(274, 3);
            this.btnEditTable.Name = "btnEditTable";
            this.btnEditTable.PrimaryColor = System.Drawing.Color.ForestGreen;
            this.btnEditTable.SecondaryColor = System.Drawing.Color.White;
            this.btnEditTable.Size = new System.Drawing.Size(60, 23);
            this.btnEditTable.TabIndex = 1;
            this.btnEditTable.Text = "编辑表";
            this.btnEditTable.Click += new System.EventHandler(this.btnEditTable_Click);
            // 
            // btnExportAdapter
            // 
            this.btnExportAdapter.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnExportAdapter.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnExportAdapter.IsReverse = false;
            this.btnExportAdapter.Location = new System.Drawing.Point(340, 3);
            this.btnExportAdapter.Name = "btnExportAdapter";
            this.btnExportAdapter.PrimaryColor = System.Drawing.Color.OliveDrab;
            this.btnExportAdapter.SecondaryColor = System.Drawing.Color.White;
            this.btnExportAdapter.Size = new System.Drawing.Size(108, 23);
            this.btnExportAdapter.TabIndex = 7;
            this.btnExportAdapter.Text = "导出表适配类";
            this.btnExportAdapter.Click += new System.EventHandler(this.btnExportAdapterClasses_Click);
            // 
            // btnExportSpec
            // 
            this.btnExportSpec.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnExportSpec.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnExportSpec.IsReverse = false;
            this.btnExportSpec.Location = new System.Drawing.Point(454, 3);
            this.btnExportSpec.Name = "btnExportSpec";
            this.btnExportSpec.PrimaryColor = System.Drawing.Color.DarkBlue;
            this.btnExportSpec.SecondaryColor = System.Drawing.Color.White;
            this.btnExportSpec.Size = new System.Drawing.Size(119, 23);
            this.btnExportSpec.TabIndex = 10;
            this.btnExportSpec.Text = "导出数据库说明";
            this.btnExportSpec.Click += new System.EventHandler(this.btnExportSpec_Click);
            // 
            // pList
            // 
            this.pList.BackColor = System.Drawing.Color.White;
            this.pList.Controls.Add(this.lbTables);
            this.pList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pList.Location = new System.Drawing.Point(1, 125);
            this.pList.Margin = new System.Windows.Forms.Padding(0);
            this.pList.Name = "pList";
            this.tlp0.SetRowSpan(this.pList, 2);
            this.pList.Size = new System.Drawing.Size(250, 474);
            this.pList.TabIndex = 0;
            // 
            // lbTables
            // 
            this.lbTables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTables.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTables.FormattingEnabled = true;
            this.lbTables.ItemHeight = 21;
            this.lbTables.Location = new System.Drawing.Point(0, 0);
            this.lbTables.Margin = new System.Windows.Forms.Padding(0);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(250, 474);
            this.lbTables.TabIndex = 1;
            this.lbTables.Click += new System.EventHandler(this.lbTables_Click);
            this.lbTables.DoubleClick += new System.EventHandler(this.lbTables_DoubleClick);
            this.lbTables.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbTables_MouseUp);
            // 
            // flpAction
            // 
            this.flpAction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlp0.SetColumnSpan(this.flpAction, 3);
            this.flpAction.Controls.Add(this.btnPresetTable);
            this.flpAction.Controls.Add(this.btnTableData);
            this.flpAction.Controls.Add(this.btnDBConfig);
            this.flpAction.Controls.Add(this.lblDBStatus);
            this.flpAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAction.Location = new System.Drawing.Point(1, 63);
            this.flpAction.Margin = new System.Windows.Forms.Padding(0);
            this.flpAction.Name = "flpAction";
            this.flpAction.Size = new System.Drawing.Size(798, 30);
            this.flpAction.TabIndex = 0;
            // 
            // btnPresetTable
            // 
            this.btnPresetTable.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnPresetTable.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnPresetTable.IsReverse = false;
            this.btnPresetTable.Location = new System.Drawing.Point(10, 3);
            this.btnPresetTable.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnPresetTable.Name = "btnPresetTable";
            this.btnPresetTable.PrimaryColor = System.Drawing.Color.Fuchsia;
            this.btnPresetTable.SecondaryColor = System.Drawing.Color.White;
            this.btnPresetTable.Size = new System.Drawing.Size(82, 23);
            this.btnPresetTable.TabIndex = 10;
            this.btnPresetTable.Text = "预创建表";
            this.btnPresetTable.Click += new System.EventHandler(this.btnPresetTable_Click);
            // 
            // btnTableData
            // 
            this.btnTableData.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnTableData.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnTableData.IsReverse = false;
            this.btnTableData.Location = new System.Drawing.Point(98, 3);
            this.btnTableData.Name = "btnTableData";
            this.btnTableData.PrimaryColor = System.Drawing.Color.Indigo;
            this.btnTableData.SecondaryColor = System.Drawing.Color.White;
            this.btnTableData.Size = new System.Drawing.Size(110, 23);
            this.btnTableData.TabIndex = 6;
            this.btnTableData.Text = "原始表数据设置";
            this.btnTableData.Click += new System.EventHandler(this.btnDBInitialData_Click);
            // 
            // btnDBConfig
            // 
            this.btnDBConfig.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDBConfig.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnDBConfig.IsReverse = false;
            this.btnDBConfig.Location = new System.Drawing.Point(214, 3);
            this.btnDBConfig.Name = "btnDBConfig";
            this.btnDBConfig.PrimaryColor = System.Drawing.Color.DarkSlateGray;
            this.btnDBConfig.SecondaryColor = System.Drawing.Color.White;
            this.btnDBConfig.Size = new System.Drawing.Size(80, 23);
            this.btnDBConfig.TabIndex = 8;
            this.btnDBConfig.Text = "数据库配置";
            this.btnDBConfig.Click += new System.EventHandler(this.btnDBConfig_Click);
            // 
            // lblDBStatus
            // 
            this.lblDBStatus.AutoSize = true;
            this.lblDBStatus.Location = new System.Drawing.Point(307, 6);
            this.lblDBStatus.Margin = new System.Windows.Forms.Padding(10, 6, 3, 0);
            this.lblDBStatus.Name = "lblDBStatus";
            this.lblDBStatus.Size = new System.Drawing.Size(71, 17);
            this.lblDBStatus.TabIndex = 9;
            this.lblDBStatus.Text = "数据库版本:";
            // 
            // tlpFolder
            // 
            this.tlpFolder.ColumnCount = 6;
            this.tlp0.SetColumnSpan(this.tlpFolder, 3);
            this.tlpFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFolder.Controls.Add(this.btnOpenFolder, 4, 0);
            this.tlpFolder.Controls.Add(this.btnOpenWithVSCode, 5, 0);
            this.tlpFolder.Controls.Add(this.btnRefreshTables, 3, 0);
            this.tlpFolder.Controls.Add(this.label1, 0, 0);
            this.tlpFolder.Controls.Add(this.txtRootFolder, 1, 0);
            this.tlpFolder.Controls.Add(this.btnSelFolder, 2, 0);
            this.tlpFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFolder.Location = new System.Drawing.Point(1, 32);
            this.tlpFolder.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFolder.Name = "tlpFolder";
            this.tlpFolder.RowCount = 1;
            this.tlpFolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFolder.Size = new System.Drawing.Size(798, 30);
            this.tlpFolder.TabIndex = 0;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.BackgroundImage = global::wyk.db.tool.Properties.Resources.folder_open;
            this.btnOpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenFolder.FlatAppearance.BorderSize = 0;
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolder.Location = new System.Drawing.Point(741, 3);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(24, 23);
            this.btnOpenFolder.TabIndex = 5;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnOpenWithVSCode
            // 
            this.btnOpenWithVSCode.BackgroundImage = global::wyk.db.tool.Properties.Resources.vscode_open;
            this.btnOpenWithVSCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenWithVSCode.FlatAppearance.BorderSize = 0;
            this.btnOpenWithVSCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenWithVSCode.Location = new System.Drawing.Point(771, 3);
            this.btnOpenWithVSCode.Name = "btnOpenWithVSCode";
            this.btnOpenWithVSCode.Size = new System.Drawing.Size(24, 23);
            this.btnOpenWithVSCode.TabIndex = 4;
            this.btnOpenWithVSCode.UseVisualStyleBackColor = true;
            this.btnOpenWithVSCode.Click += new System.EventHandler(this.btnOpenWithVSCode_Click);
            // 
            // btnRefreshTables
            // 
            this.btnRefreshTables.BackgroundImage = global::wyk.db.tool.Properties.Resources.refresh;
            this.btnRefreshTables.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefreshTables.FlatAppearance.BorderSize = 0;
            this.btnRefreshTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTables.Location = new System.Drawing.Point(711, 3);
            this.btnRefreshTables.Name = "btnRefreshTables";
            this.btnRefreshTables.Size = new System.Drawing.Size(24, 23);
            this.btnRefreshTables.TabIndex = 3;
            this.btnRefreshTables.UseVisualStyleBackColor = true;
            this.btnRefreshTables.Click += new System.EventHandler(this.btnRefreshTables_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "表文件目录:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRootFolder
            // 
            this.txtRootFolder.BackColor = System.Drawing.Color.White;
            this.txtRootFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRootFolder.Location = new System.Drawing.Point(83, 4);
            this.txtRootFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtRootFolder.Name = "txtRootFolder";
            this.txtRootFolder.ReadOnly = true;
            this.txtRootFolder.Size = new System.Drawing.Size(592, 23);
            this.txtRootFolder.TabIndex = 1;
            this.txtRootFolder.TabStop = false;
            this.txtRootFolder.TextChanged += new System.EventHandler(this.txtRootFolder_TextChanged);
            // 
            // btnSelFolder
            // 
            this.btnSelFolder.BackgroundImage = global::wyk.db.tool.Properties.Resources.folder;
            this.btnSelFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelFolder.FlatAppearance.BorderSize = 0;
            this.btnSelFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelFolder.Location = new System.Drawing.Point(681, 3);
            this.btnSelFolder.Name = "btnSelFolder";
            this.btnSelFolder.Size = new System.Drawing.Size(24, 23);
            this.btnSelFolder.TabIndex = 2;
            this.btnSelFolder.UseVisualStyleBackColor = true;
            this.btnSelFolder.Click += new System.EventHandler(this.btnSelFolder_Click);
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
            this.tlp0.SetColumnSpan(this.dgvColumns, 2);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColumns.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(252, 146);
            this.dgvColumns.Margin = new System.Windows.Forms.Padding(0);
            this.dgvColumns.MultiSelect = false;
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.RowHeadersVisible = false;
            this.dgvColumns.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvColumns.RowTemplate.Height = 23;
            this.dgvColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvColumns.Size = new System.Drawing.Size(547, 453);
            this.dgvColumns.TabIndex = 1;
            this.dgvColumns.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColumns_CellContentClick);
            this.dgvColumns.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColumns_CellValueChanged);
            this.dgvColumns.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvColumns_MouseUp);
            // 
            // col0
            // 
            this.col0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col0.HeaderText = "主键";
            this.col0.MinimumWidth = 40;
            this.col0.Name = "col0";
            this.col0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col0.Width = 40;
            // 
            // col8
            // 
            this.col8.HeaderText = "自增长";
            this.col8.MinimumWidth = 50;
            this.col8.Name = "col8";
            this.col8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col8.Width = 50;
            // 
            // col1
            // 
            this.col1.HeaderText = "列名";
            this.col1.MinimumWidth = 100;
            this.col1.Name = "col1";
            this.col1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col2
            // 
            this.col2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.col2.HeaderText = "类型";
            this.col2.MinimumWidth = 80;
            this.col2.Name = "col2";
            this.col2.Width = 80;
            // 
            // col3
            // 
            this.col3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col3.HeaderText = "长度";
            this.col3.MinimumWidth = 40;
            this.col3.Name = "col3";
            this.col3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col3.Width = 40;
            // 
            // col4
            // 
            this.col4.HeaderText = "长度2";
            this.col4.MinimumWidth = 50;
            this.col4.Name = "col4";
            this.col4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col4.Width = 50;
            // 
            // col5
            // 
            this.col5.HeaderText = "允许空";
            this.col5.MinimumWidth = 50;
            this.col5.Name = "col5";
            this.col5.Width = 50;
            // 
            // col6
            // 
            this.col6.HeaderText = "默认值";
            this.col6.MinimumWidth = 50;
            this.col6.Name = "col6";
            this.col6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col6.Width = 50;
            // 
            // col9
            // 
            this.col9.HeaderText = "Json忽略";
            this.col9.Name = "col9";
            this.col9.Width = 64;
            // 
            // col10
            // 
            this.col10.HeaderText = "替换名";
            this.col10.Name = "col10";
            this.col10.Width = 69;
            // 
            // col7
            // 
            this.col7.HeaderText = "说明";
            this.col7.MinimumWidth = 40;
            this.col7.Name = "col7";
            this.col7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col7.Width = 40;
            // 
            // flp0
            // 
            this.flp0.BackColor = System.Drawing.Color.Linen;
            this.tlp0.SetColumnSpan(this.flp0, 3);
            this.flp0.Controls.Add(this.label2);
            this.flp0.Controls.Add(this.cbProjectName);
            this.flp0.Controls.Add(this.btnNewProject);
            this.flp0.Controls.Add(this.btnDeleteProject);
            this.flp0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp0.Location = new System.Drawing.Point(1, 1);
            this.flp0.Margin = new System.Windows.Forms.Padding(0);
            this.flp0.Name = "flp0";
            this.flp0.Size = new System.Drawing.Size(798, 30);
            this.flp0.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "项目名称:";
            // 
            // cbProjectName
            // 
            this.cbProjectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjectName.FormattingEnabled = true;
            this.cbProjectName.Location = new System.Drawing.Point(68, 3);
            this.cbProjectName.Name = "cbProjectName";
            this.cbProjectName.Size = new System.Drawing.Size(238, 25);
            this.cbProjectName.TabIndex = 1;
            this.cbProjectName.SelectedIndexChanged += new System.EventHandler(this.cbProjectName_SelectedIndexChanged);
            // 
            // btnNewProject
            // 
            this.btnNewProject.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnNewProject.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnNewProject.IsReverse = false;
            this.btnNewProject.Location = new System.Drawing.Point(312, 4);
            this.btnNewProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.PrimaryColor = System.Drawing.Color.DarkSlateGray;
            this.btnNewProject.SecondaryColor = System.Drawing.Color.White;
            this.btnNewProject.Size = new System.Drawing.Size(64, 23);
            this.btnNewProject.TabIndex = 8;
            this.btnNewProject.Text = "新项目";
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDeleteProject.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnDeleteProject.IsReverse = false;
            this.btnDeleteProject.Location = new System.Drawing.Point(382, 4);
            this.btnDeleteProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.PrimaryColor = System.Drawing.Color.DarkSlateGray;
            this.btnDeleteProject.SecondaryColor = System.Drawing.Color.White;
            this.btnDeleteProject.Size = new System.Drawing.Size(64, 23);
            this.btnDeleteProject.TabIndex = 9;
            this.btnDeleteProject.Text = "删除";
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // lblTableDescription
            // 
            this.lblTableDescription.AutoSize = true;
            this.lblTableDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTableDescription.Location = new System.Drawing.Point(255, 125);
            this.lblTableDescription.Name = "lblTableDescription";
            this.lblTableDescription.Size = new System.Drawing.Size(459, 20);
            this.lblTableDescription.TabIndex = 4;
            this.lblTableDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmsTableList
            // 
            this.cmsTableList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateTable,
            this.tsmiEditTable,
            this.tsmiDeleteTable,
            this.toolStripSeparator1,
            this.tsmiTableData,
            this.tsmiTableClass});
            this.cmsTableList.Name = "cmsTableList";
            this.cmsTableList.Size = new System.Drawing.Size(125, 120);
            // 
            // tsmiCreateTable
            // 
            this.tsmiCreateTable.Name = "tsmiCreateTable";
            this.tsmiCreateTable.Size = new System.Drawing.Size(124, 22);
            this.tsmiCreateTable.Text = "新建表";
            this.tsmiCreateTable.Click += new System.EventHandler(this.btnNewTable_Click);
            // 
            // tsmiEditTable
            // 
            this.tsmiEditTable.Name = "tsmiEditTable";
            this.tsmiEditTable.Size = new System.Drawing.Size(124, 22);
            this.tsmiEditTable.Text = "编辑表";
            this.tsmiEditTable.Click += new System.EventHandler(this.btnEditTable_Click);
            // 
            // tsmiDeleteTable
            // 
            this.tsmiDeleteTable.Name = "tsmiDeleteTable";
            this.tsmiDeleteTable.Size = new System.Drawing.Size(124, 22);
            this.tsmiDeleteTable.Text = "删除表";
            this.tsmiDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmiTableData
            // 
            this.tsmiTableData.Name = "tsmiTableData";
            this.tsmiTableData.Size = new System.Drawing.Size(124, 22);
            this.tsmiTableData.Text = "表数据";
            this.tsmiTableData.Click += new System.EventHandler(this.btnDBInitialData_Click);
            // 
            // tsmiTableClass
            // 
            this.tsmiTableClass.Name = "tsmiTableClass";
            this.tsmiTableClass.Size = new System.Drawing.Size(124, 22);
            this.tsmiTableClass.Text = "表代码类";
            this.tsmiTableClass.Click += new System.EventHandler(this.tsmiTableClass_Click);
            // 
            // cmsColumnList
            // 
            this.cmsColumnList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewColumn,
            this.tsmiDeleteColumn});
            this.cmsColumnList.Name = "cmsColumnList";
            this.cmsColumnList.Size = new System.Drawing.Size(113, 48);
            // 
            // tsmiNewColumn
            // 
            this.tsmiNewColumn.Name = "tsmiNewColumn";
            this.tsmiNewColumn.Size = new System.Drawing.Size(112, 22);
            this.tsmiNewColumn.Text = "新增列";
            this.tsmiNewColumn.Click += new System.EventHandler(this.tsmiNewColumn_Click);
            // 
            // tsmiDeleteColumn
            // 
            this.tsmiDeleteColumn.Name = "tsmiDeleteColumn";
            this.tsmiDeleteColumn.Size = new System.Drawing.Size(112, 22);
            this.tsmiDeleteColumn.Text = "删除列";
            this.tsmiDeleteColumn.Click += new System.EventHandler(this.tsmiDeleteColumn_Click);
            // 
            // cmsTypeCell
            // 
            this.cmsTypeCell.Name = "cmsColumnList";
            this.cmsTypeCell.Size = new System.Drawing.Size(61, 4);
            // 
            // UCTableMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp0);
            this.Name = "UCTableMaintain";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.UCTableMaintain_Load);
            this.tlp0.ResumeLayout(false);
            this.tlp0.PerformLayout();
            this.flpAction2.ResumeLayout(false);
            this.pList.ResumeLayout(false);
            this.flpAction.ResumeLayout(false);
            this.flpAction.PerformLayout();
            this.tlpFolder.ResumeLayout(false);
            this.tlpFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.flp0.ResumeLayout(false);
            this.flp0.PerformLayout();
            this.cmsTableList.ResumeLayout(false);
            this.cmsColumnList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp0;
        private System.Windows.Forms.TableLayoutPanel tlpFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRootFolder;
        private System.Windows.Forms.Button btnSelFolder;
        private System.Windows.Forms.ListBox lbTables;
        private System.Windows.Forms.FlowLayoutPanel flpAction;
        private ExDataGridView dgvColumns;
        private System.Windows.Forms.FolderBrowserDialog selFolder;
        private System.Windows.Forms.Button btnRefreshTables;
        private System.Windows.Forms.ContextMenuStrip cmsTableList;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableData;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableClass;
        private System.Windows.Forms.ContextMenuStrip cmsColumnList;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewColumn;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteColumn;
        private System.Windows.Forms.ContextMenuStrip cmsTypeCell;
        private ExTextButton btnAddTable;
        private ExTextButton btnEditTable;
        private ExTextButton btnDeleteTable;
        private ExTextButton btnAddColumn;
        private ExTextButton btnDeleteColumn;
        private ExTextButton btnTableData;
        private ExTextButton btnExportAdapter;
        private ExTextButton btnDBConfig;
        private System.Windows.Forms.FlowLayoutPanel flpAction2;
        private System.Windows.Forms.Label lblDBStatus;
        private ExTextButton btnExportSpec;
        private ExTextButton btnPresetTable;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnOpenWithVSCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col0;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col8;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewComboBoxColumn col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col9;
        private System.Windows.Forms.DataGridViewTextBoxColumn col10;
        private System.Windows.Forms.DataGridViewTextBoxColumn col7;
        private System.Windows.Forms.FlowLayoutPanel flp0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProjectName;
        private ExTextButton btnNewProject;
        private ExTextButton btnDeleteProject;
        private System.Windows.Forms.Panel pList;
        private System.Windows.Forms.Label lblTableDescription;
        private ExTextButton btnSQLCreateTable;
    }
}
