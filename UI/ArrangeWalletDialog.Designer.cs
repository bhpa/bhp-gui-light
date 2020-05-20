﻿namespace Bhp.UI
{
    partial class ArrangeWalletDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArrangeWalletDialog));
            this.lbl_progress = new System.Windows.Forms.Label();
            this.btn_arrange = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbl_txs = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.combo_asset = new System.Windows.Forms.ComboBox();
            this.lbl_asset = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_progress
            // 
            resources.ApplyResources(this.lbl_progress, "lbl_progress");
            this.lbl_progress.Name = "lbl_progress";
            // 
            // btn_arrange
            // 
            resources.ApplyResources(this.btn_arrange, "btn_arrange");
            this.btn_arrange.Name = "btn_arrange";
            this.btn_arrange.UseVisualStyleBackColor = true;
            this.btn_arrange.Click += new System.EventHandler(this.btn_arrange_Click);
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btn_close, "btn_close");
            this.btn_close.Name = "btn_close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.Name = "listBox1";
            // 
            // lbl_txs
            // 
            resources.ApplyResources(this.lbl_txs, "lbl_txs");
            this.lbl_txs.Name = "lbl_txs";
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // combo_asset
            // 
            this.combo_asset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_asset.FormattingEnabled = true;
            resources.ApplyResources(this.combo_asset, "combo_asset");
            this.combo_asset.Name = "combo_asset";
            this.combo_asset.SelectedIndexChanged += new System.EventHandler(this.combo_asset_SelectedIndexChanged);
            // 
            // lbl_asset
            // 
            resources.ApplyResources(this.lbl_asset, "lbl_asset");
            this.lbl_asset.Name = "lbl_asset";
            // 
            // ArrangeWalletDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combo_asset);
            this.Controls.Add(this.lbl_asset);
            this.Controls.Add(this.lbl_txs);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_arrange);
            this.Controls.Add(this.lbl_progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArrangeWalletDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_progress;
        private System.Windows.Forms.Button btn_arrange;
        private System.Windows.Forms.Button btn_close;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbl_txs;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox combo_asset;
        private System.Windows.Forms.Label lbl_asset;
    }
}