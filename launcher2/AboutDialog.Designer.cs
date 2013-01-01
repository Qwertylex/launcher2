namespace launcher2
{
    partial class AboutDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblSilkIcons = new System.Windows.Forms.Label();
            this.lblMSPL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::launcher2.Properties.Resources.l2_128;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "launcher²";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 52);
            this.label2.TabIndex = 2;
            this.label2.Text = "Originally crafted by akiwiguy, though there may be more\r\n\r\nAvailable under the Simplified BSD Licence, see \r\n http://github.com/aki--aki/launcher2 for details.";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(350, 201);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(151, 47);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(124, 13);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "launcher² version 0.0.0.0";
            // 
            // lblSilkIcons
            // 
            this.lblSilkIcons.AutoSize = true;
            this.lblSilkIcons.Location = new System.Drawing.Point(151, 144);
            this.lblSilkIcons.Name = "lblSilkIcons";
            this.lblSilkIcons.Size = new System.Drawing.Size(257, 26);
            this.lblSilkIcons.TabIndex = 5;
            this.lblSilkIcons.Text = "Uses icons from Silk by famfamfam, available at \r\n famfamfam.com under the CC Att" +
                "ribution 2.5 licence.";
            this.lblSilkIcons.Click += new System.EventHandler(this.lblSilkIcons_Click);
            // 
            // lblMSPL
            // 
            this.lblMSPL.AutoSize = true;
            this.lblMSPL.Location = new System.Drawing.Point(151, 172);
            this.lblMSPL.Name = "lblMSPL";
            this.lblMSPL.Size = new System.Drawing.Size(271, 26);
            this.lblMSPL.TabIndex = 6;
            this.lblMSPL.Text = "Uses the DotNetZip library, licenced under the Microsoft\r\n Public Licence (Ms-PL)" +
                ". Click to view.";
            this.lblMSPL.Click += new System.EventHandler(this.lblMSPL_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Other licence terms:";
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 236);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMSPL);
            this.Controls.Add(this.lblSilkIcons);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::launcher2.Properties.Resources.l2_ico;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About launcher²";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblSilkIcons;
        private System.Windows.Forms.Label lblMSPL;
        private System.Windows.Forms.Label label3;
    }
}