namespace wyk.db.ext.usercontrol
{
    partial class UCDBConnectionAccess
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
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelFile = new System.Windows.Forms.Button();
            this.selFile = new System.Windows.Forms.OpenFileDialog();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(56, 8);
            this.txtServer.Multiline = true;
            this.txtServer.Name = "txtServer";
            this.txtServer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServer.Size = new System.Drawing.Size(192, 85);
            this.txtServer.TabIndex = 1;
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(56, 99);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(192, 23);
            this.txtPassword1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "密码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "服务器:";
            // 
            // btnSelFile
            // 
            this.btnSelFile.BackgroundImage = global::wyk.db.fw.Properties.Resources.folder;
            this.btnSelFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelFile.FlatAppearance.BorderSize = 0;
            this.btnSelFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSelFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSelFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelFile.Location = new System.Drawing.Point(254, 8);
            this.btnSelFile.Name = "btnSelFile";
            this.btnSelFile.Size = new System.Drawing.Size(23, 23);
            this.btnSelFile.TabIndex = 25;
            this.btnSelFile.TabStop = false;
            this.btnSelFile.UseVisualStyleBackColor = true;
            // 
            // selFile
            // 
            this.selFile.Filter = "*.mdb|*.mdb";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(56, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(162, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // UCDBConnectionAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.btnSelFile);
            this.Controls.Add(this.txtPassword1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "UCDBConnectionAccess";
            this.Size = new System.Drawing.Size(290, 170);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnSelFile;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog selFile;
        private System.Windows.Forms.TextBox txtPassword;
    }
}
