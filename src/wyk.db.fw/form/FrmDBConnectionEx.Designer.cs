using wyk.ui;

namespace wyk.db.ext
{
    partial class FrmDBConnectionEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDBConnectionEx));
            this.pDBType = new System.Windows.Forms.Panel();
            this.rbnDBOracle = new System.Windows.Forms.RadioButton();
            this.rbnDBAccess = new System.Windows.Forms.RadioButton();
            this.rbnDBSqlServer = new System.Windows.Forms.RadioButton();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new wyk.ui.ExTextButton();
            this.btnOK = new wyk.ui.ExTextButton();
            this.pContent = new System.Windows.Forms.Panel();
            this.btnTestConnection = new wyk.ui.ExTextButton();
            this.rbnMySql = new System.Windows.Forms.RadioButton();
            this.pDBType.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Location = new System.Drawing.Point(270, 2);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Location = new System.Drawing.Point(190, 2);
            // 
            // btn_maximize
            // 
            this.btn_maximize.Location = new System.Drawing.Point(230, 2);
            // 
            // pDBType
            // 
            this.pDBType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pDBType.Controls.Add(this.rbnMySql);
            this.pDBType.Controls.Add(this.rbnDBOracle);
            this.pDBType.Controls.Add(this.rbnDBAccess);
            this.pDBType.Controls.Add(this.rbnDBSqlServer);
            this.pDBType.Location = new System.Drawing.Point(10, 29);
            this.pDBType.Name = "pDBType";
            this.pDBType.Size = new System.Drawing.Size(290, 26);
            this.pDBType.TabIndex = 3;
            // 
            // rbnDBOracle
            // 
            this.rbnDBOracle.AutoSize = true;
            this.rbnDBOracle.Location = new System.Drawing.Point(222, 2);
            this.rbnDBOracle.Name = "rbnDBOracle";
            this.rbnDBOracle.Size = new System.Drawing.Size(64, 21);
            this.rbnDBOracle.TabIndex = 2;
            this.rbnDBOracle.Text = "Oracle";
            this.rbnDBOracle.UseVisualStyleBackColor = true;
            this.rbnDBOracle.CheckedChanged += new System.EventHandler(this.rbnDBOracle_CheckedChanged);
            // 
            // rbnDBAccess
            // 
            this.rbnDBAccess.AutoSize = true;
            this.rbnDBAccess.Location = new System.Drawing.Point(85, 2);
            this.rbnDBAccess.Name = "rbnDBAccess";
            this.rbnDBAccess.Size = new System.Drawing.Size(65, 21);
            this.rbnDBAccess.TabIndex = 1;
            this.rbnDBAccess.Text = "Access";
            this.rbnDBAccess.UseVisualStyleBackColor = true;
            this.rbnDBAccess.CheckedChanged += new System.EventHandler(this.rbnDBAccess_CheckedChanged);
            // 
            // rbnDBSqlServer
            // 
            this.rbnDBSqlServer.AutoSize = true;
            this.rbnDBSqlServer.Location = new System.Drawing.Point(3, 2);
            this.rbnDBSqlServer.Name = "rbnDBSqlServer";
            this.rbnDBSqlServer.Size = new System.Drawing.Size(81, 21);
            this.rbnDBSqlServer.TabIndex = 0;
            this.rbnDBSqlServer.Text = "SqlServer";
            this.rbnDBSqlServer.UseVisualStyleBackColor = true;
            this.rbnDBSqlServer.CheckedChanged += new System.EventHandler(this.rbnDBSqlServer_CheckedChanged);
            // 
            // tlpContent
            // 
            this.tlpContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpContent.ColumnCount = 3;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpContent.Controls.Add(this.btnCancel, 2, 1);
            this.tlpContent.Controls.Add(this.btnOK, 1, 1);
            this.tlpContent.Controls.Add(this.pContent, 0, 0);
            this.tlpContent.Controls.Add(this.btnTestConnection, 0, 1);
            this.tlpContent.Location = new System.Drawing.Point(10, 55);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 2;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContent.Size = new System.Drawing.Size(290, 210);
            this.tlpContent.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnCancel.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnCancel.IsReverse = false;
            this.btnCancel.Location = new System.Drawing.Point(233, 178);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 8, 0, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PrimaryColor = System.Drawing.Color.Gray;
            this.btnCancel.SecondaryColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(57, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnOK.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnOK.IsReverse = false;
            this.btnOK.Location = new System.Drawing.Point(173, 178);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 8, 0, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(226)))));
            this.btnOK.SecondaryColor = System.Drawing.Color.White;
            this.btnOK.Size = new System.Drawing.Size(57, 30);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pContent
            // 
            this.pContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpContent.SetColumnSpan(this.pContent, 3);
            this.pContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pContent.Location = new System.Drawing.Point(0, 0);
            this.pContent.Margin = new System.Windows.Forms.Padding(0);
            this.pContent.Name = "pContent";
            this.pContent.Size = new System.Drawing.Size(290, 170);
            this.pContent.TabIndex = 4;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTestConnection.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnTestConnection.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnTestConnection.IsReverse = false;
            this.btnTestConnection.Location = new System.Drawing.Point(3, 178);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(3, 8, 0, 2);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.PrimaryColor = System.Drawing.Color.DarkCyan;
            this.btnTestConnection.SecondaryColor = System.Drawing.Color.White;
            this.btnTestConnection.Size = new System.Drawing.Size(80, 30);
            this.btnTestConnection.TabIndex = 5;
            this.btnTestConnection.Text = "测试连接";
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // rbnMySql
            // 
            this.rbnMySql.AutoSize = true;
            this.rbnMySql.Location = new System.Drawing.Point(153, 3);
            this.rbnMySql.Name = "rbnMySql";
            this.rbnMySql.Size = new System.Drawing.Size(62, 21);
            this.rbnMySql.TabIndex = 3;
            this.rbnMySql.Text = "MySql";
            this.rbnMySql.UseVisualStyleBackColor = true;
            this.rbnMySql.CheckedChanged += new System.EventHandler(this.rbnMySql_CheckedChanged);
            // 
            // FrmDBConnectionEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 270);
            this.Controls.Add(this.pDBType);
            this.Controls.Add(this.tlpContent);
            this.FormResizeable = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 270);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 270);
            this.Name = "FrmDBConnectionEx";
            this.StatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.StatusBar.Height = 20;
            this.StatusBar.ShouldShow = false;
            this.StatusBar.Text = "";
            this.StatusBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBar.TextColor = System.Drawing.Color.White;
            this.StatusBar.TextFont = new System.Drawing.Font("Microsoft YaHei", 8F);
            this.Text = "数据库连接";
            this.TitleBar.ActionButtonPosition = wyk.ui.enums.FormActionButtonPosition.Center;
            this.TitleBar.ActionButtonStyle = wyk.ui.enums.FormActionButtonStyle.Flat;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(226)))));
            this.TitleBar.Height = 25;
            this.TitleBar.ShouldShow = true;
            this.TitleBar.TextColor = System.Drawing.Color.White;
            this.TitleBar.TextFont = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.TitleBar.UIMode = wyk.ui.enums.FormTitleBarUIMode.Separated;
            this.Load += new System.EventHandler(this.FrmDBConnectionEx_Load);
            this.Controls.SetChildIndex(this.tlpContent, 0);
            this.Controls.SetChildIndex(this.pDBType, 0);
            this.Controls.SetChildIndex(this.btn_minimize, 0);
            this.Controls.SetChildIndex(this.btn_maximize, 0);
            this.Controls.SetChildIndex(this.btn_close, 0);
            this.pDBType.ResumeLayout(false);
            this.pDBType.PerformLayout();
            this.tlpContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pDBType;
        private System.Windows.Forms.RadioButton rbnDBOracle;
        private System.Windows.Forms.RadioButton rbnDBAccess;
        private System.Windows.Forms.RadioButton rbnDBSqlServer;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.Panel pContent;
        private ExTextButton btnCancel;
        private ExTextButton btnOK;
        private ExTextButton btnTestConnection;
        private System.Windows.Forms.RadioButton rbnMySql;
    }
}