using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    partial class FrmExportTableAdapters
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRootFolder = new System.Windows.Forms.TextBox();
            this.btnSelFolder = new System.Windows.Forms.Button();
            this.chbRemoveAll = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.clbTableList = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new wyk.ui.ExTextButton();
            this.btnExport = new wyk.ui.ExTextButton();
            this.selFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(460, 2);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Location = new System.Drawing.Point(380, 2);
            // 
            // btn_maximize
            // 
            this.btn_maximize.Location = new System.Drawing.Point(420, 2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "根目录:";
            // 
            // txtRootFolder
            // 
            this.txtRootFolder.Location = new System.Drawing.Point(75, 40);
            this.txtRootFolder.Name = "txtRootFolder";
            this.txtRootFolder.Size = new System.Drawing.Size(383, 23);
            this.txtRootFolder.TabIndex = 1;
            this.txtRootFolder.TextChanged += new System.EventHandler(this.txtRootFolder_TextChanged);
            // 
            // btnSelFolder
            // 
            this.btnSelFolder.BackgroundImage = global::wyk.db.tool.Properties.Resources.folder;
            this.btnSelFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelFolder.FlatAppearance.BorderSize = 0;
            this.btnSelFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelFolder.Location = new System.Drawing.Point(464, 40);
            this.btnSelFolder.Name = "btnSelFolder";
            this.btnSelFolder.Size = new System.Drawing.Size(24, 23);
            this.btnSelFolder.TabIndex = 3;
            this.btnSelFolder.UseVisualStyleBackColor = true;
            this.btnSelFolder.Click += new System.EventHandler(this.btnSelFolder_Click);
            // 
            // chbRemoveAll
            // 
            this.chbRemoveAll.AutoSize = true;
            this.chbRemoveAll.Location = new System.Drawing.Point(311, 71);
            this.chbRemoveAll.Name = "chbRemoveAll";
            this.chbRemoveAll.Size = new System.Drawing.Size(147, 21);
            this.chbRemoveAll.TabIndex = 4;
            this.chbRemoveAll.Text = "清空原目录下所有文件";
            this.chbRemoveAll.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "命名空间:";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(75, 69);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(157, 23);
            this.txtNamespace.TabIndex = 6;
            this.txtNamespace.TextChanged += new System.EventHandler(this.txtNamespace_TextChanged);
            // 
            // clbTableList
            // 
            this.clbTableList.FormattingEnabled = true;
            this.clbTableList.Location = new System.Drawing.Point(75, 100);
            this.clbTableList.Name = "clbTableList";
            this.clbTableList.Size = new System.Drawing.Size(413, 112);
            this.clbTableList.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "数据库表:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.IsReverse = false;
            this.btnCancel.Location = new System.Drawing.Point(428, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PrimaryColor = System.Drawing.Color.Gray;
            this.btnCancel.SecondaryColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(60, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnExport.IsReverse = false;
            this.btnExport.Location = new System.Drawing.Point(362, 218);
            this.btnExport.Name = "btnExport";
            this.btnExport.PrimaryColor = System.Drawing.Color.ForestGreen;
            this.btnExport.SecondaryColor = System.Drawing.Color.White;
            this.btnExport.Size = new System.Drawing.Size(60, 25);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmExportTableAdapters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clbTableList);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbRemoveAll);
            this.Controls.Add(this.btnSelFolder);
            this.Controls.Add(this.txtRootFolder);
            this.Controls.Add(this.label1);
            this.Name = "FrmExportTableAdapters";
            this.StatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.StatusBar.Height = 20;
            this.StatusBar.ShouldShow = false;
            this.StatusBar.Text = "";
            this.StatusBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBar.TextColor = System.Drawing.Color.White;
            this.StatusBar.TextFont = new System.Drawing.Font("微软雅黑", 8F);
            this.Text = "导出数据表适配类";
            this.TitleBar.ActionButtonPosition = wyk.ui.enums.FormActionButtonPosition.Center;
            this.TitleBar.ActionButtonStyle = wyk.ui.enums.FormActionButtonStyle.Flat;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(226)))));
            this.TitleBar.Height = 25;
            this.TitleBar.ShouldShow = true;
            this.TitleBar.TextColor = System.Drawing.Color.White;
            this.TitleBar.TextFont = new System.Drawing.Font("微软雅黑", 9F);
            this.TitleBar.UIMode = wyk.ui.enums.FormTitleBarUIMode.Separated;
            this.Load += new System.EventHandler(this.FrmExportTableAdapters_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtRootFolder, 0);
            this.Controls.SetChildIndex(this.btnSelFolder, 0);
            this.Controls.SetChildIndex(this.chbRemoveAll, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNamespace, 0);
            this.Controls.SetChildIndex(this.clbTableList, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btn_minimize, 0);
            this.Controls.SetChildIndex(this.btn_maximize, 0);
            this.Controls.SetChildIndex(this.btn_close, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRootFolder;
        private System.Windows.Forms.Button btnSelFolder;
        private System.Windows.Forms.CheckBox chbRemoveAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.CheckedListBox clbTableList;
        private System.Windows.Forms.Label label3;
        private ExTextButton btnCancel;
        private ExTextButton btnExport;
        private System.Windows.Forms.FolderBrowserDialog selFolder;
    }
}