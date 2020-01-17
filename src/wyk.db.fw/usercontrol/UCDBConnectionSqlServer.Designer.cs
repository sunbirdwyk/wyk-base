namespace wyk.db.ext.usercontrol
{
    partial class UCDBConnectionSqlServer
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
            this.chbWindowsVerification = new System.Windows.Forms.CheckBox();
            this.txtDatabase = new System.Windows.Forms.ComboBox();
            this.txtServer = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefreshDB = new System.Windows.Forms.Button();
            this.btnRefreshServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chbWindowsVerification
            // 
            this.chbWindowsVerification.AutoSize = true;
            this.chbWindowsVerification.Location = new System.Drawing.Point(126, 132);
            this.chbWindowsVerification.Name = "chbWindowsVerification";
            this.chbWindowsVerification.Size = new System.Drawing.Size(128, 21);
            this.chbWindowsVerification.TabIndex = 5;
            this.chbWindowsVerification.Text = "Windows登录验证";
            this.chbWindowsVerification.UseVisualStyleBackColor = true;
            this.chbWindowsVerification.CheckedChanged += new System.EventHandler(this.chbWindowsVerification_CheckedChanged);
            // 
            // txtDatabase
            // 
            this.txtDatabase.FormattingEnabled = true;
            this.txtDatabase.Location = new System.Drawing.Point(56, 43);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(198, 25);
            this.txtDatabase.TabIndex = 2;
            // 
            // txtServer
            // 
            this.txtServer.FormattingEnabled = true;
            this.txtServer.Location = new System.Drawing.Point(56, 8);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(198, 25);
            this.txtServer.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(56, 103);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(198, 23);
            this.txtPassword.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "密码:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(56, 74);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(198, 23);
            this.txtUserName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "数据库:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "服务器:";
            // 
            // btnRefreshDB
            // 
            this.btnRefreshDB.BackgroundImage = global::wyk.db.fw.Properties.Resources.refresh;
            this.btnRefreshDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefreshDB.FlatAppearance.BorderSize = 0;
            this.btnRefreshDB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshDB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDB.Location = new System.Drawing.Point(259, 43);
            this.btnRefreshDB.Name = "btnRefreshDB";
            this.btnRefreshDB.Size = new System.Drawing.Size(23, 23);
            this.btnRefreshDB.TabIndex = 23;
            this.btnRefreshDB.TabStop = false;
            this.btnRefreshDB.UseVisualStyleBackColor = true;
            this.btnRefreshDB.Click += new System.EventHandler(this.btnRefreshDB_Click);
            // 
            // btnRefreshServer
            // 
            this.btnRefreshServer.BackgroundImage = global::wyk.db.fw.Properties.Resources.refresh;
            this.btnRefreshServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefreshServer.FlatAppearance.BorderSize = 0;
            this.btnRefreshServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshServer.Location = new System.Drawing.Point(259, 8);
            this.btnRefreshServer.Name = "btnRefreshServer";
            this.btnRefreshServer.Size = new System.Drawing.Size(23, 23);
            this.btnRefreshServer.TabIndex = 22;
            this.btnRefreshServer.TabStop = false;
            this.btnRefreshServer.UseVisualStyleBackColor = true;
            this.btnRefreshServer.Click += new System.EventHandler(this.btnRefreshServer_Click);
            // 
            // UCDBConnectionSqlServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefreshDB);
            this.Controls.Add(this.btnRefreshServer);
            this.Controls.Add(this.chbWindowsVerification);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCDBConnectionSqlServer";
            this.Size = new System.Drawing.Size(290, 170);
            this.Load += new System.EventHandler(this.UCDBConnectionSqlServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshDB;
        private System.Windows.Forms.Button btnRefreshServer;
        private System.Windows.Forms.CheckBox chbWindowsVerification;
        private System.Windows.Forms.ComboBox txtDatabase;
        private System.Windows.Forms.ComboBox txtServer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
