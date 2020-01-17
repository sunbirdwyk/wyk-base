using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    partial class FrmTableDetail
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
            this.btnOK = new wyk.ui.ExTextButton();
            this.btnCancel = new wyk.ui.ExTextButton();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(260, 2);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Location = new System.Drawing.Point(180, 2);
            // 
            // btn_maximize
            // 
            this.btn_maximize.Location = new System.Drawing.Point(220, 2);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnOK.IsReverse = false;
            this.btnOK.Location = new System.Drawing.Point(164, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.PrimaryColor = System.Drawing.Color.ForestGreen;
            this.btnOK.SecondaryColor = System.Drawing.Color.White;
            this.btnOK.Size = new System.Drawing.Size(60, 25);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCancel.IsReverse = false;
            this.btnCancel.Location = new System.Drawing.Point(230, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PrimaryColor = System.Drawing.Color.Gray;
            this.btnCancel.SecondaryColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(60, 25);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(50, 60);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(240, 104);
            this.txtDescription.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "说明:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(50, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 23);
            this.txtName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "表名:";
            // 
            // FrmTableDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormResizeable = false;
            this.Name = "FrmTableDetail";
            this.ShowIconInTaskBar = false;
            this.ShowIconOnUI = false;
            this.ShowInTaskbar = false;
            this.StatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.StatusBar.Height = 20;
            this.StatusBar.ShouldShow = false;
            this.StatusBar.Text = "";
            this.StatusBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBar.TextColor = System.Drawing.Color.White;
            this.StatusBar.TextFont = new System.Drawing.Font("微软雅黑", 8F);
            this.Text = "表详细信息";
            this.TitleBar.ActionButtonPosition = wyk.ui.enums.FormActionButtonPosition.Center;
            this.TitleBar.ActionButtonStyle = wyk.ui.enums.FormActionButtonStyle.Flat;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(226)))));
            this.TitleBar.Height = 25;
            this.TitleBar.ShouldShow = true;
            this.TitleBar.TextColor = System.Drawing.Color.White;
            this.TitleBar.TextFont = new System.Drawing.Font("微软雅黑", 9F);
            this.TitleBar.UIMode = wyk.ui.enums.FormTitleBarUIMode.Separated;
            this.Load += new System.EventHandler(this.FrmTableDetail_Load);
            this.Controls.SetChildIndex(this.btn_minimize, 0);
            this.Controls.SetChildIndex(this.btn_maximize, 0);
            this.Controls.SetChildIndex(this.btn_close, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExTextButton btnOK;
        private ExTextButton btnCancel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
    }
}