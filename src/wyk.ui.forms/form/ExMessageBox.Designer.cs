namespace wyk.ui
{
    partial class ExMessageBox
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.tlpAction = new System.Windows.Forms.TableLayoutPanel();
            this.btnAction2 = new wyk.ui.ExTextButton();
            this.btnAction1 = new wyk.ui.ExTextButton();
            this.btnCopy = new wyk.ui.ExTextButton();
            this.pText = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.tlpAction.SuspendLayout();
            this.pText.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.ImageSize = new System.Drawing.Size(12, 12);
            this.btn_close.Location = new System.Drawing.Point(260, 2);
            this.btn_close.Size = new System.Drawing.Size(40, 20);
            // 
            // btn_minimize
            // 
            this.btn_minimize.ImageSize = new System.Drawing.Size(12, 12);
            this.btn_minimize.Location = new System.Drawing.Point(180, 2);
            this.btn_minimize.Size = new System.Drawing.Size(40, 20);
            // 
            // btn_maximize
            // 
            this.btn_maximize.ImageSize = new System.Drawing.Size(12, 12);
            this.btn_maximize.Location = new System.Drawing.Point(220, 2);
            this.btn_maximize.Size = new System.Drawing.Size(40, 20);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pbIcon, 0, 0);
            this.tlpMain.Controls.Add(this.tlpAction, 0, 1);
            this.tlpMain.Controls.Add(this.pText, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 25);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.Size = new System.Drawing.Size(300, 100);
            this.tlpMain.TabIndex = 3;
            // 
            // pbIcon
            // 
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIcon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon.Margin = new System.Windows.Forms.Padding(0);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(60, 65);
            this.pbIcon.TabIndex = 1;
            this.pbIcon.TabStop = false;
            // 
            // tlpAction
            // 
            this.tlpAction.ColumnCount = 4;
            this.tlpMain.SetColumnSpan(this.tlpAction, 2);
            this.tlpAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpAction.Controls.Add(this.btnAction2, 3, 0);
            this.tlpAction.Controls.Add(this.btnAction1, 2, 0);
            this.tlpAction.Controls.Add(this.btnCopy, 0, 0);
            this.tlpAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAction.Location = new System.Drawing.Point(0, 65);
            this.tlpAction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAction.Name = "tlpAction";
            this.tlpAction.RowCount = 1;
            this.tlpAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAction.Size = new System.Drawing.Size(300, 35);
            this.tlpAction.TabIndex = 2;
            // 
            // btnAction2
            // 
            this.btnAction2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAction2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAction2.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnAction2.IsReverse = false;
            this.btnAction2.Location = new System.Drawing.Point(235, 5);
            this.btnAction2.Margin = new System.Windows.Forms.Padding(5);
            this.btnAction2.Name = "btnAction2";
            this.btnAction2.PrimaryColor = System.Drawing.Color.RoyalBlue;
            this.btnAction2.SecondaryColor = System.Drawing.Color.White;
            this.btnAction2.Size = new System.Drawing.Size(60, 25);
            this.btnAction2.TabIndex = 2;
            this.btnAction2.Click += new System.EventHandler(this.btnAction2_Click);
            // 
            // btnAction1
            // 
            this.btnAction1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAction1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAction1.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnAction1.IsReverse = false;
            this.btnAction1.Location = new System.Drawing.Point(165, 5);
            this.btnAction1.Margin = new System.Windows.Forms.Padding(5);
            this.btnAction1.Name = "btnAction1";
            this.btnAction1.PrimaryColor = System.Drawing.Color.RoyalBlue;
            this.btnAction1.SecondaryColor = System.Drawing.Color.White;
            this.btnAction1.Size = new System.Drawing.Size(60, 25);
            this.btnAction1.TabIndex = 1;
            this.btnAction1.Click += new System.EventHandler(this.btnAction1_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopy.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCopy.FunctionType = wyk.ui.ButtonFuctionType.Normal;
            this.btnCopy.IsReverse = true;
            this.btnCopy.Location = new System.Drawing.Point(5, 5);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(5);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.PrimaryColor = System.Drawing.Color.RoyalBlue;
            this.btnCopy.SecondaryColor = System.Drawing.Color.White;
            this.btnCopy.Size = new System.Drawing.Size(60, 25);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "复制";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // pText
            // 
            this.pText.AutoScroll = true;
            this.pText.Controls.Add(this.lblText);
            this.pText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pText.Location = new System.Drawing.Point(60, 0);
            this.pText.Margin = new System.Windows.Forms.Padding(0);
            this.pText.Name = "pText";
            this.pText.Size = new System.Drawing.Size(240, 65);
            this.pText.TabIndex = 3;
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(10, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(214, 65);
            this.lblText.TabIndex = 0;
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExMessageBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(300, 125);
            this.Controls.Add(this.tlpMain);
            this.FormResizeable = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 125);
            this.Name = "ExMessageBox";
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
            this.Text = "ExMessageBox";
            this.TitleBar.ActionButtonPosition = wyk.ui.enums.FormActionButtonPosition.Center;
            this.TitleBar.ActionButtonStyle = wyk.ui.enums.FormActionButtonStyle.Flat;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(226)))));
            this.TitleBar.Height = 25;
            this.TitleBar.ShouldShow = true;
            this.TitleBar.TextColor = System.Drawing.Color.White;
            this.TitleBar.TextFont = new System.Drawing.Font("微软雅黑", 9F);
            this.TitleBar.UIMode = wyk.ui.enums.FormTitleBarUIMode.Separated;
            this.TopMost = true;
            this.Controls.SetChildIndex(this.btn_minimize, 0);
            this.Controls.SetChildIndex(this.btn_maximize, 0);
            this.Controls.SetChildIndex(this.btn_close, 0);
            this.Controls.SetChildIndex(this.tlpMain, 0);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.tlpAction.ResumeLayout(false);
            this.pText.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.TableLayoutPanel tlpAction;
        private ExTextButton btnAction2;
        private ExTextButton btnAction1;
        private System.Windows.Forms.Panel pText;
        private System.Windows.Forms.Label lblText;
        private ExTextButton btnCopy;
    }
}