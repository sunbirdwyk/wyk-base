namespace wyk.db.ext
{
    partial class FrmDBConnection
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
            this.pDBType = new System.Windows.Forms.Panel();
            this.rbnDBOracle = new System.Windows.Forms.RadioButton();
            this.rbnDBAccess = new System.Windows.Forms.RadioButton();
            this.rbnDBSqlServer = new System.Windows.Forms.RadioButton();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pContent = new System.Windows.Forms.Panel();
            this.rbnMySql = new System.Windows.Forms.RadioButton();
            this.pDBType.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDBType
            // 
            this.pDBType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pDBType.Controls.Add(this.rbnMySql);
            this.pDBType.Controls.Add(this.rbnDBOracle);
            this.pDBType.Controls.Add(this.rbnDBAccess);
            this.pDBType.Controls.Add(this.rbnDBSqlServer);
            this.pDBType.Location = new System.Drawing.Point(10, 6);
            this.pDBType.Name = "pDBType";
            this.pDBType.Size = new System.Drawing.Size(290, 26);
            this.pDBType.TabIndex = 0;
            // 
            // rbnDBOracle
            // 
            this.rbnDBOracle.AutoSize = true;
            this.rbnDBOracle.Location = new System.Drawing.Point(221, 2);
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
            this.rbnDBAccess.Location = new System.Drawing.Point(86, 2);
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
            // btnTestConnection
            // 
            this.btnTestConnection.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTestConnection.Location = new System.Drawing.Point(0, 178);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(0, 8, 3, 2);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(80, 30);
            this.btnTestConnection.TabIndex = 1;
            this.btnTestConnection.TabStop = false;
            this.btnTestConnection.Text = "测试连接";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
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
            this.tlpContent.Controls.Add(this.btnTestConnection, 0, 1);
            this.tlpContent.Controls.Add(this.btnOK, 1, 1);
            this.tlpContent.Controls.Add(this.btnCancel, 2, 1);
            this.tlpContent.Controls.Add(this.pContent, 0, 0);
            this.tlpContent.Location = new System.Drawing.Point(10, 39);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 2;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpContent.Size = new System.Drawing.Size(290, 210);
            this.tlpContent.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(173, 178);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 8, 0, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(57, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(233, 178);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 8, 0, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pContent
            // 
            this.pContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpContent.SetColumnSpan(this.pContent, 3);
            this.pContent.Location = new System.Drawing.Point(0, 0);
            this.pContent.Margin = new System.Windows.Forms.Padding(0);
            this.pContent.Name = "pContent";
            this.pContent.Size = new System.Drawing.Size(290, 170);
            this.pContent.TabIndex = 4;
            // 
            // rbnMySql
            // 
            this.rbnMySql.AutoSize = true;
            this.rbnMySql.Location = new System.Drawing.Point(154, 2);
            this.rbnMySql.Name = "rbnMySql";
            this.rbnMySql.Size = new System.Drawing.Size(62, 21);
            this.rbnMySql.TabIndex = 3;
            this.rbnMySql.Text = "MySql";
            this.rbnMySql.UseVisualStyleBackColor = true;
            this.rbnMySql.CheckedChanged += new System.EventHandler(this.rbnMySql_CheckedChanged);
            // 
            // FrmDBConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 255);
            this.Controls.Add(this.tlpContent);
            this.Controls.Add(this.pDBType);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(325, 294);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(325, 294);
            this.Name = "FrmDBConnection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据库连接";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmDBConnection_Load);
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
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pContent;
        private System.Windows.Forms.RadioButton rbnMySql;
    }
}