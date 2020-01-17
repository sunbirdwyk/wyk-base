using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    partial class FrmDBConfig
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurrentVersion = new System.Windows.Forms.TextBox();
            this.txtSysConfigTable = new System.Windows.Forms.TextBox();
            this.txtTableNameColumn = new System.Windows.Forms.TextBox();
            this.txtTableValueColumn = new System.Windows.Forms.TextBox();
            this.txtTableDBVersionKey = new System.Windows.Forms.TextBox();
            this.btnOK = new wyk.ui.ExTextButton();
            this.btnCancel = new wyk.ui.ExTextButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前数据库版本:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "系统配置表名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "系统配置表名称列:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "系统配置表值列:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "系统配置表数据库版本值名称:";
            // 
            // txtCurrentVersion
            // 
            this.txtCurrentVersion.Location = new System.Drawing.Point(183, 37);
            this.txtCurrentVersion.Name = "txtCurrentVersion";
            this.txtCurrentVersion.Size = new System.Drawing.Size(200, 23);
            this.txtCurrentVersion.TabIndex = 9;
            // 
            // txtSysConfigTable
            // 
            this.txtSysConfigTable.Location = new System.Drawing.Point(183, 63);
            this.txtSysConfigTable.Name = "txtSysConfigTable";
            this.txtSysConfigTable.Size = new System.Drawing.Size(200, 23);
            this.txtSysConfigTable.TabIndex = 10;
            // 
            // txtTableNameColumn
            // 
            this.txtTableNameColumn.Location = new System.Drawing.Point(183, 95);
            this.txtTableNameColumn.Name = "txtTableNameColumn";
            this.txtTableNameColumn.Size = new System.Drawing.Size(200, 23);
            this.txtTableNameColumn.TabIndex = 11;
            // 
            // txtTableValueColumn
            // 
            this.txtTableValueColumn.Location = new System.Drawing.Point(183, 124);
            this.txtTableValueColumn.Name = "txtTableValueColumn";
            this.txtTableValueColumn.Size = new System.Drawing.Size(200, 23);
            this.txtTableValueColumn.TabIndex = 12;
            // 
            // txtTableDBVersionKey
            // 
            this.txtTableDBVersionKey.Location = new System.Drawing.Point(183, 153);
            this.txtTableDBVersionKey.Name = "txtTableDBVersionKey";
            this.txtTableDBVersionKey.Size = new System.Drawing.Size(200, 23);
            this.txtTableDBVersionKey.TabIndex = 14;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnOK.IsReverse = false;
            this.btnOK.Location = new System.Drawing.Point(210, 186);
            this.btnOK.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.PrimaryColor = System.Drawing.Color.ForestGreen;
            this.btnOK.SecondaryColor = System.Drawing.Color.White;
            this.btnOK.Size = new System.Drawing.Size(80, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.IsReverse = false;
            this.btnCancel.Location = new System.Drawing.Point(303, 186);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PrimaryColor = System.Drawing.Color.DimGray;
            this.btnCancel.SecondaryColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmDBConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTableDBVersionKey);
            this.Controls.Add(this.txtTableValueColumn);
            this.Controls.Add(this.txtTableNameColumn);
            this.Controls.Add(this.txtSysConfigTable);
            this.Controls.Add(this.txtCurrentVersion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmDBConfig";
            this.StatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.StatusBar.Height = 20;
            this.StatusBar.ShouldShow = false;
            this.StatusBar.Text = "";
            this.StatusBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBar.TextColor = System.Drawing.Color.White;
            this.StatusBar.TextFont = new System.Drawing.Font("微软雅黑", 8F);
            this.Text = "数据库信息设置";
            this.TitleBar.ActionButtonPosition = wyk.ui.enums.FormActionButtonPosition.Center;
            this.TitleBar.ActionButtonStyle = wyk.ui.enums.FormActionButtonStyle.Flat;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(226)))));
            this.TitleBar.Height = 25;
            this.TitleBar.ShouldShow = true;
            this.TitleBar.TextColor = System.Drawing.Color.White;
            this.TitleBar.TextFont = new System.Drawing.Font("微软雅黑", 9F);
            this.TitleBar.UIMode = wyk.ui.enums.FormTitleBarUIMode.Separated;
            this.Load += new System.EventHandler(this.FrmDBConfig_Load);
            this.Controls.SetChildIndex(this.btn_minimize, 0);
            this.Controls.SetChildIndex(this.btn_maximize, 0);
            this.Controls.SetChildIndex(this.btn_close, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCurrentVersion, 0);
            this.Controls.SetChildIndex(this.txtSysConfigTable, 0);
            this.Controls.SetChildIndex(this.txtTableNameColumn, 0);
            this.Controls.SetChildIndex(this.txtTableValueColumn, 0);
            this.Controls.SetChildIndex(this.txtTableDBVersionKey, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurrentVersion;
        private System.Windows.Forms.TextBox txtSysConfigTable;
        private System.Windows.Forms.TextBox txtTableNameColumn;
        private System.Windows.Forms.TextBox txtTableValueColumn;
        private System.Windows.Forms.TextBox txtTableDBVersionKey;
        private ExTextButton btnOK;
        private ExTextButton btnCancel;
    }
}