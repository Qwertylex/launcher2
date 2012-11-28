namespace launcher2
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOptionsItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLaunchMinecraft = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.comboMinecraftVersion = new System.Windows.Forms.ComboBox();
            this.menuOptionsItemForceLWJGLUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuOptions
            // 
            this.menuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptionsItemForceLWJGLUpdate,
            this.menuOptionsItemAbout});
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(183, 70);
            // 
            // menuOptionsItemAbout
            // 
            this.menuOptionsItemAbout.Name = "menuOptionsItemAbout";
            this.menuOptionsItemAbout.Size = new System.Drawing.Size(182, 22);
            this.menuOptionsItemAbout.Text = "About";
            this.menuOptionsItemAbout.Click += new System.EventHandler(this.menuOptionsItemAbout_Click);
            // 
            // btnLaunchMinecraft
            // 
            this.btnLaunchMinecraft.Location = new System.Drawing.Point(12, 39);
            this.btnLaunchMinecraft.Name = "btnLaunchMinecraft";
            this.btnLaunchMinecraft.Size = new System.Drawing.Size(189, 24);
            this.btnLaunchMinecraft.TabIndex = 3;
            this.btnLaunchMinecraft.Text = "Launch";
            this.btnLaunchMinecraft.UseVisualStyleBackColor = true;
            // 
            // btnOptions
            // 
            this.btnOptions.Image = global::launcher2.Properties.Resources.cog;
            this.btnOptions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOptions.Location = new System.Drawing.Point(207, 39);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(24, 24);
            this.btnOptions.TabIndex = 4;
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // comboMinecraftVersion
            // 
            this.comboMinecraftVersion.FormattingEnabled = true;
            this.comboMinecraftVersion.Location = new System.Drawing.Point(12, 12);
            this.comboMinecraftVersion.Name = "comboMinecraftVersion";
            this.comboMinecraftVersion.Size = new System.Drawing.Size(219, 21);
            this.comboMinecraftVersion.TabIndex = 5;
            // 
            // menuOptionsItemForceLWJGLUpdate
            // 
            this.menuOptionsItemForceLWJGLUpdate.Name = "menuOptionsItemForceLWJGLUpdate";
            this.menuOptionsItemForceLWJGLUpdate.Size = new System.Drawing.Size(182, 22);
            this.menuOptionsItemForceLWJGLUpdate.Text = "Force LWJGL Update";
            this.menuOptionsItemForceLWJGLUpdate.Click += new System.EventHandler(this.menuOptionsItemForceLWJGLUpdate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 75);
            this.Controls.Add(this.comboMinecraftVersion);
            this.Controls.Add(this.btnLaunchMinecraft);
            this.Controls.Add(this.btnOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::launcher2.Properties.Resources.l2_ico;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "launcher²";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menuOptions;
        private System.Windows.Forms.Button btnLaunchMinecraft;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsItemAbout;
        private System.Windows.Forms.ComboBox comboMinecraftVersion;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsItemForceLWJGLUpdate;

    }
}

