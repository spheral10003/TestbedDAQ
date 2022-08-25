namespace TestbedDAQ.Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlView = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblManager = new System.Windows.Forms.Label();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlView
            // 
            this.pnlView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(45)))));
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlView.Location = new System.Drawing.Point(0, 152);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(1920, 928);
            this.pnlView.TabIndex = 2;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(45)))));
            this.pnlTitle.BackgroundImage = global::TestbedDAQ.Properties.Resources.body_top;
            this.pnlTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlTitle.Controls.Add(this.label2);
            this.pnlTitle.Controls.Add(this.lblManager);
            this.pnlTitle.Controls.Add(this.lblMonitor);
            this.pnlTitle.Location = new System.Drawing.Point(0, 93);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1920, 60);
            this.pnlTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Image = global::TestbedDAQ.Properties.Resources.ssss;
            this.label2.Location = new System.Drawing.Point(1626, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 44);
            this.label2.TabIndex = 2;
            // 
            // lblManager
            // 
            this.lblManager.Image = global::TestbedDAQ.Properties.Resources.tab02_off;
            this.lblManager.Location = new System.Drawing.Point(195, 7);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(170, 44);
            this.lblManager.TabIndex = 1;
            this.lblManager.Click += new System.EventHandler(this.Menu_Click);
            // 
            // lblMonitor
            // 
            this.lblMonitor.Image = global::TestbedDAQ.Properties.Resources.tab01_on;
            this.lblMonitor.Location = new System.Drawing.Point(25, 7);
            this.lblMonitor.Name = "lblMonitor";
            this.lblMonitor.Size = new System.Drawing.Size(170, 44);
            this.lblMonitor.TabIndex = 0;
            this.lblMonitor.Click += new System.EventHandler(this.Menu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(45)))));
            this.panel1.BackgroundImage = global::TestbedDAQ.Properties.Resources.title_bar;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.lblClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 93);
            this.panel1.TabIndex = 4;
            // 
            // lblClose
            // 
            this.lblClose.Image = global::TestbedDAQ.Properties.Resources.button_close;
            this.lblClose.Location = new System.Drawing.Point(1860, 17);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(48, 48);
            this.lblClose.TabIndex = 0;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(2)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.Label lblMonitor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblClose;
    }
}