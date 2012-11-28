using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace launcher2
{
    public partial class MainForm : Form {
        public MainForm() {
            Debug.WriteLine("[MainForm] New MainForm created.");
            InitializeComponent();
        }

        private MinecraftLauncher mcLauncher;

        private void btnOptions_Click(object sender, EventArgs e) {
            Debug.WriteLine("[MainForm] Options button clicked.");
            // Calculate where we should show the options menu
            int xpos = this.Location.X + this.btnOptions.Location.X + 3;
            int ypos = this.Location.Y + this.btnOptions.Location.Y + this.btnOptions.Size.Height * 2 + 3;
            // and show it
            Debug.WriteLine("[MainForm] Displaying menuOptions at (" + xpos + ", " + ypos + ")");
            this.menuOptions.Show(xpos, ypos);
        }

        private void menuOptionsItemAbout_Click(object sender, EventArgs e) {
            Debug.WriteLine("[MainForm] Creating new AboutDialog.");
            AboutDialog aboutDlg = new AboutDialog();
            Debug.WriteLine("[MainForm] Showing AboutDialog.");
            aboutDlg.ShowDialog();
            Debug.WriteLine("[MainForm] Disposing of created AboutDialog.");
            aboutDlg.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            mcLauncher = new MinecraftLauncher();
        }

        private void menuOptionsItemForceLWJGLUpdate_Click(object sender, EventArgs e) {
            mcLauncher.DownloadLWJGL();
        }
    }
}
