﻿namespace wyk.ui
{
    partial class ExFormMain
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
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.ImageSize = new System.Drawing.Size(12, 12);
            this.btn_close.Location = new System.Drawing.Point(760, 2);
            this.btn_close.Size = new System.Drawing.Size(40, 20);
            // 
            // btn_minimize
            // 
            this.btn_minimize.ImageSize = new System.Drawing.Size(12, 12);
            this.btn_minimize.Location = new System.Drawing.Point(680, 2);
            this.btn_minimize.Size = new System.Drawing.Size(40, 20);
            // 
            // btn_maximize
            // 
            this.btn_maximize.ImageSize = new System.Drawing.Size(12, 12);
            this.btn_maximize.Location = new System.Drawing.Point(720, 2);
            this.btn_maximize.Size = new System.Drawing.Size(40, 20);
            // 
            // ExFormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ExFormMain";
            this.StatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.StatusBar.Height = 20;
            this.StatusBar.ShouldShow = true;
            this.StatusBar.Text = "Copyright © Sunbird WYK";
            this.StatusBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBar.TextColor = System.Drawing.Color.White;
            this.StatusBar.TextFont = new System.Drawing.Font("微软雅黑", 8F);
            this.Text = "ExFormMain";
            this.TitleBar.ActionButtonPosition = wyk.ui.enums.FormActionButtonPosition.Center;
            this.TitleBar.ActionButtonStyle = wyk.ui.enums.FormActionButtonStyle.Flat;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(226)))));
            this.TitleBar.Height = 25;
            this.TitleBar.ShouldShow = true;
            this.TitleBar.TextColor = System.Drawing.Color.White;
            this.TitleBar.TextFont = new System.Drawing.Font("微软雅黑", 9F);
            this.TitleBar.UIMode = wyk.ui.enums.FormTitleBarUIMode.Separated;
            this.ResumeLayout(false);

        }

        #endregion
    }
}