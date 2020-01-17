namespace wyk.db.tool.TableMaintain
{
    partial class FrmTableClass
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
            this.txtClassContent = new System.Windows.Forms.TextBox();
            this.tlp0 = new System.Windows.Forms.TableLayoutPanel();
            this.flp0 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.chbShowDefaultNameSpace = new System.Windows.Forms.CheckBox();
            this.tlp0.SuspendLayout();
            this.flp0.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(560, 2);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Location = new System.Drawing.Point(480, 2);
            // 
            // btn_maximize
            // 
            this.btn_maximize.Location = new System.Drawing.Point(520, 2);
            // 
            // txtClassContent
            // 
            this.txtClassContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClassContent.Location = new System.Drawing.Point(3, 33);
            this.txtClassContent.Multiline = true;
            this.txtClassContent.Name = "txtClassContent";
            this.txtClassContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtClassContent.Size = new System.Drawing.Size(594, 339);
            this.txtClassContent.TabIndex = 0;
            this.txtClassContent.TabStop = false;
            // 
            // tlp0
            // 
            this.tlp0.ColumnCount = 1;
            this.tlp0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp0.Controls.Add(this.txtClassContent, 0, 1);
            this.tlp0.Controls.Add(this.flp0, 0, 0);
            this.tlp0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp0.Location = new System.Drawing.Point(0, 25);
            this.tlp0.Name = "tlp0";
            this.tlp0.RowCount = 2;
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp0.Size = new System.Drawing.Size(600, 375);
            this.tlp0.TabIndex = 1;
            // 
            // flp0
            // 
            this.flp0.Controls.Add(this.label1);
            this.flp0.Controls.Add(this.txtNameSpace);
            this.flp0.Controls.Add(this.chbShowDefaultNameSpace);
            this.flp0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp0.Location = new System.Drawing.Point(0, 0);
            this.flp0.Margin = new System.Windows.Forms.Padding(0);
            this.flp0.Name = "flp0";
            this.flp0.Size = new System.Drawing.Size(600, 30);
            this.flp0.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "namespace:";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(86, 4);
            this.txtNameSpace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(120, 23);
            this.txtNameSpace.TabIndex = 1;
            this.txtNameSpace.TabStop = false;
            // 
            // chbShowDefaultNameSpace
            // 
            this.chbShowDefaultNameSpace.AutoSize = true;
            this.chbShowDefaultNameSpace.Checked = true;
            this.chbShowDefaultNameSpace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowDefaultNameSpace.Location = new System.Drawing.Point(212, 5);
            this.chbShowDefaultNameSpace.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.chbShowDefaultNameSpace.Name = "chbShowDefaultNameSpace";
            this.chbShowDefaultNameSpace.Size = new System.Drawing.Size(141, 21);
            this.chbShowDefaultNameSpace.TabIndex = 3;
            this.chbShowDefaultNameSpace.TabStop = false;
            this.chbShowDefaultNameSpace.Text = "显示默认namespace";
            this.chbShowDefaultNameSpace.UseVisualStyleBackColor = true;
            this.chbShowDefaultNameSpace.CheckedChanged += new System.EventHandler(this.chbShowDefaultNameSpace_CheckedChanged);
            // 
            // FrmTableClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.tlp0);
            this.Name = "FrmTableClass";
            this.ShowIconOnUI = false;
            this.ShowInTaskbar = false;
            this.StatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.StatusBar.Height = 20;
            this.StatusBar.ShouldShow = false;
            this.StatusBar.Text = "";
            this.StatusBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBar.TextColor = System.Drawing.Color.White;
            this.StatusBar.TextFont = new System.Drawing.Font("微软雅黑", 8F);
            this.Text = "数据表类";
            this.TitleBar.ActionButtonPosition = wyk.ui.enums.FormActionButtonPosition.Center;
            this.TitleBar.ActionButtonStyle = wyk.ui.enums.FormActionButtonStyle.Flat;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(226)))));
            this.TitleBar.Height = 25;
            this.TitleBar.ShouldShow = true;
            this.TitleBar.TextColor = System.Drawing.Color.White;
            this.TitleBar.TextFont = new System.Drawing.Font("微软雅黑", 9F);
            this.TitleBar.UIMode = wyk.ui.enums.FormTitleBarUIMode.Separated;
            this.Load += new System.EventHandler(this.FrmTableClass_Load);
            this.Controls.SetChildIndex(this.tlp0, 0);
            this.Controls.SetChildIndex(this.btn_minimize, 0);
            this.Controls.SetChildIndex(this.btn_maximize, 0);
            this.Controls.SetChildIndex(this.btn_close, 0);
            this.tlp0.ResumeLayout(false);
            this.tlp0.PerformLayout();
            this.flp0.ResumeLayout(false);
            this.flp0.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtClassContent;
        private System.Windows.Forms.TableLayoutPanel tlp0;
        private System.Windows.Forms.FlowLayoutPanel flp0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.CheckBox chbShowDefaultNameSpace;
    }
}