using wyk.ui;

namespace wyk.db.tool.Schema
{
    partial class UCSchema
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.lb = new System.Windows.Forms.ListBox();
            this.sc1 = new System.Windows.Forms.SplitContainer();
            this.txtColFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnFilter = new ExTextButton();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).BeginInit();
            this.sc1.Panel1.SuspendLayout();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.BackColor = System.Drawing.Color.MintCream;
            this.scMain.Panel1.Controls.Add(this.lb);
            this.scMain.Panel1MinSize = 150;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.BackColor = System.Drawing.Color.Ivory;
            this.scMain.Panel2.Controls.Add(this.sc1);
            this.scMain.Size = new System.Drawing.Size(784, 477);
            this.scMain.SplitterDistance = 150;
            this.scMain.SplitterWidth = 2;
            this.scMain.TabIndex = 0;
            // 
            // lb
            // 
            this.lb.BackColor = System.Drawing.Color.MintCream;
            this.lb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb.FormattingEnabled = true;
            this.lb.ItemHeight = 20;
            this.lb.Location = new System.Drawing.Point(0, 0);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(146, 473);
            this.lb.TabIndex = 0;
            this.lb.Click += new System.EventHandler(this.lb_Click);
            // 
            // sc1
            // 
            this.sc1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc1.IsSplitterFixed = true;
            this.sc1.Location = new System.Drawing.Point(0, 0);
            this.sc1.Name = "sc1";
            this.sc1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc1.Panel1
            // 
            this.sc1.Panel1.Controls.Add(this.btnFilter);
            this.sc1.Panel1.Controls.Add(this.txtColFilter);
            this.sc1.Panel1.Controls.Add(this.label1);
            // 
            // sc1.Panel2
            // 
            this.sc1.Panel2.Controls.Add(this.dgv);
            this.sc1.Size = new System.Drawing.Size(632, 477);
            this.sc1.SplitterDistance = 33;
            this.sc1.SplitterWidth = 2;
            this.sc1.TabIndex = 1;
            // 
            // txtColFilter
            // 
            this.txtColFilter.Location = new System.Drawing.Point(191, 3);
            this.txtColFilter.Name = "txtColFilter";
            this.txtColFilter.Size = new System.Drawing.Size(334, 23);
            this.txtColFilter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "列过滤(当前显示的列, 逗号隔开):";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.Ivory;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(628, 438);
            this.dgv.TabIndex = 0;
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnFilter.IsReverse = false;
            this.btnFilter.Location = new System.Drawing.Point(531, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.PrimaryColor = System.Drawing.Color.OliveDrab;
            this.btnFilter.SecondaryColor = System.Drawing.Color.White;
            this.btnFilter.Size = new System.Drawing.Size(66, 23);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "过滤";
            this.btnFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // UCSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Name = "UCSchema";
            this.Size = new System.Drawing.Size(784, 477);
            this.Load += new System.EventHandler(this.UCSchema_Load);
            this.VisibleChanged += new System.EventHandler(this.UCSchema_VisibleChanged);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.sc1.Panel1.ResumeLayout(false);
            this.sc1.Panel1.PerformLayout();
            this.sc1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).EndInit();
            this.sc1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ListBox lb;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.SplitContainer sc1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColFilter;
        private ExTextButton btnFilter;
    }
}
