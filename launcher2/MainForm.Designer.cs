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
            this.menuOptionsItemReloadVersionList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuOptionsItemOpenLocalVersionsFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsItemOpenAppData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuOptionsItemAuthDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsItemChangeAuthDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuOptionsItemForceLWJGLUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionsItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLaunchMinecraft = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.menuAdvancedOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.advancedOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.editUserConfigurationFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboMinecraftVersion = new System.Windows.Forms.ComboBox();
            this.menuOptions.SuspendLayout();
            this.menuAdvancedOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuOptions
            // 
            this.menuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptionsItemReloadVersionList,
            this.toolStripSeparator1,
            this.menuOptionsItemOpenLocalVersionsFolder,
            this.menuOptionsItemOpenAppData,
            this.toolStripSeparator3,
            this.menuOptionsItemAuthDetails,
            this.menuOptionsItemChangeAuthDetails,
            this.toolStripSeparator2,
            this.menuOptionsItemForceLWJGLUpdate,
            this.menuOptionsItemAbout});
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(258, 176);
            // 
            // menuOptionsItemReloadVersionList
            // 
            this.menuOptionsItemReloadVersionList.Name = "menuOptionsItemReloadVersionList";
            this.menuOptionsItemReloadVersionList.Size = new System.Drawing.Size(257, 22);
            this.menuOptionsItemReloadVersionList.Text = "Reload versions list";
            this.menuOptionsItemReloadVersionList.Click += new System.EventHandler(this.menuOptionsItemReloadVersionList_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(254, 6);
            // 
            // menuOptionsItemOpenLocalVersionsFolder
            // 
            this.menuOptionsItemOpenLocalVersionsFolder.Name = "menuOptionsItemOpenLocalVersionsFolder";
            this.menuOptionsItemOpenLocalVersionsFolder.Size = new System.Drawing.Size(257, 22);
            this.menuOptionsItemOpenLocalVersionsFolder.Text = "Open local versions folder";
            this.menuOptionsItemOpenLocalVersionsFolder.Click += new System.EventHandler(this.menuOptionsItemOpenLocalVersionsFolder_Click);
            // 
            // menuOptionsItemOpenAppData
            // 
            this.menuOptionsItemOpenAppData.Name = "menuOptionsItemOpenAppData";
            this.menuOptionsItemOpenAppData.Size = new System.Drawing.Size(257, 22);
            this.menuOptionsItemOpenAppData.Text = "Open Minecraft %appdata% folder";
            this.menuOptionsItemOpenAppData.Click += new System.EventHandler(this.menuOptionsItemOpenAppData_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(254, 6);
            // 
            // menuOptionsItemAuthDetails
            // 
            this.menuOptionsItemAuthDetails.Enabled = false;
            this.menuOptionsItemAuthDetails.Name = "menuOptionsItemAuthDetails";
            this.menuOptionsItemAuthDetails.Size = new System.Drawing.Size(257, 22);
            this.menuOptionsItemAuthDetails.Text = "Authenticated as <username>";
            // 
            // menuOptionsItemChangeAuthDetails
            // 
            this.menuOptionsItemChangeAuthDetails.Name = "menuOptionsItemChangeAuthDetails";
            this.menuOptionsItemChangeAuthDetails.Size = new System.Drawing.Size(257, 22);
            this.menuOptionsItemChangeAuthDetails.Text = "Change authentication details";
            this.menuOptionsItemChangeAuthDetails.Click += new System.EventHandler(this.menuOptionsItemChangeAuthDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(254, 6);
            // 
            // menuOptionsItemForceLWJGLUpdate
            // 
            this.menuOptionsItemForceLWJGLUpdate.Name = "menuOptionsItemForceLWJGLUpdate";
            this.menuOptionsItemForceLWJGLUpdate.Size = new System.Drawing.Size(257, 22);
            this.menuOptionsItemForceLWJGLUpdate.Text = "Force LWJGL Update";
            this.menuOptionsItemForceLWJGLUpdate.Click += new System.EventHandler(this.menuOptionsItemForceLWJGLUpdate_Click);
            // 
            // menuOptionsItemAbout
            // 
            this.menuOptionsItemAbout.Name = "menuOptionsItemAbout";
            this.menuOptionsItemAbout.Size = new System.Drawing.Size(257, 22);
            this.menuOptionsItemAbout.Text = "About launcher²";
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
            this.btnLaunchMinecraft.Click += new System.EventHandler(this.btnLaunchMinecraft_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.ContextMenuStrip = this.menuAdvancedOptions;
            this.btnOptions.Image = global::launcher2.Properties.Resources.cog;
            this.btnOptions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOptions.Location = new System.Drawing.Point(207, 39);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(24, 24);
            this.btnOptions.TabIndex = 4;
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // menuAdvancedOptions
            // 
            this.menuAdvancedOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedOptionsToolStripMenuItem,
            this.toolStripSeparator4,
            this.editUserConfigurationFileToolStripMenuItem});
            this.menuAdvancedOptions.Name = "menuAdvancedOptions";
            this.menuAdvancedOptions.Size = new System.Drawing.Size(214, 76);
            // 
            // advancedOptionsToolStripMenuItem
            // 
            this.advancedOptionsToolStripMenuItem.Enabled = false;
            this.advancedOptionsToolStripMenuItem.Name = "advancedOptionsToolStripMenuItem";
            this.advancedOptionsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.advancedOptionsToolStripMenuItem.Text = "Advanced Options";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(210, 6);
            // 
            // editUserConfigurationFileToolStripMenuItem
            // 
            this.editUserConfigurationFileToolStripMenuItem.Name = "editUserConfigurationFileToolStripMenuItem";
            this.editUserConfigurationFileToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.editUserConfigurationFileToolStripMenuItem.Text = "Edit user configuration file";
            this.editUserConfigurationFileToolStripMenuItem.Click += new System.EventHandler(this.editUserConfigurationFileToolStripMenuItem_Click);
            // 
            // comboMinecraftVersion
            // 
            this.comboMinecraftVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMinecraftVersion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboMinecraftVersion.FormattingEnabled = true;
            this.comboMinecraftVersion.Location = new System.Drawing.Point(12, 12);
            this.comboMinecraftVersion.Name = "comboMinecraftVersion";
            this.comboMinecraftVersion.Size = new System.Drawing.Size(219, 21);
            this.comboMinecraftVersion.TabIndex = 5;
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
            this.menuAdvancedOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menuOptions;
        private System.Windows.Forms.Button btnLaunchMinecraft;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsItemAbout;
        private System.Windows.Forms.ComboBox comboMinecraftVersion;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsItemForceLWJGLUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsItemOpenLocalVersionsFolder;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsItemOpenAppData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsItemReloadVersionList;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsItemChangeAuthDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuOptionsItemAuthDetails;
        private System.Windows.Forms.ContextMenuStrip menuAdvancedOptions;
        private System.Windows.Forms.ToolStripMenuItem advancedOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem editUserConfigurationFileToolStripMenuItem;

    }
}

