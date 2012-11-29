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
            try {
                Debug.WriteLine("[MainForm] Creating new MinecraftLauncher instance");
                mcLauncher = new MinecraftLauncher();
                Debug.WriteLine("[MainForm] Populating comboMinecraftVersion");
                comboMinecraftVersion.Items.AddRange(mcLauncher.GetMinecraftVersions());
                comboMinecraftVersion.SelectedIndex = 0;
            }
            catch (MinecraftLauncher.JavaNotFoundException) {
                Debug.WriteLine("[MainForm] JavaNotFoundException encountered, closing app.");
                Application.Exit();
            }
            catch (Exception ex) {
                Debug.WriteLine("[MainForm] Exception encountered: " + ex.Message);
                Debug.Indent();
                Debug.WriteLine(ex.StackTrace);
                Debug.Unindent();
                MessageBox.Show("Oops, something went wrong and launcher² has to close.\n\nIf you would like to help us fix what caused this crash, please send the log file located at the path below to me@akiwiguy.net :\n" + launcher2.Program.logPath, "launcher²", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void menuOptionsItemForceLWJGLUpdate_Click(object sender, EventArgs e) {
            Debug.WriteLine("[MainForm] Forcing LWJGL update");
            mcLauncher.DownloadLWJGL();
        }

        private void btnLaunchMinecraft_Click(object sender, EventArgs e) {
            try {
                Debug.WriteLine("[MainForm] Starting launch of '" + (string)comboMinecraftVersion.SelectedItem + "'...");
                mcLauncher.LaunchMinecraft((string)comboMinecraftVersion.SelectedItem);
            }
            catch (Exception ex) {
                Debug.WriteLine("[MainForm] Exception encountered: " + ex.Message);
                Debug.Indent();
                Debug.WriteLine(ex.StackTrace);
                Debug.Unindent();
                MessageBox.Show("Oops, something went wrong and launcher² has to close.\n\nIf you would like to help us fix what caused this crash, please send the log file located at the path below to me@akiwiguy.net :\n" + launcher2.Program.logPath, "launcher²", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void menuOptionsItemOpenLocalVersionsFolder_Click(object sender, EventArgs e) {
            try {
                Debug.WriteLine("[MainForm] Opening local version folder");
                mcLauncher.OpenMinecraftDir(false);
            } catch (Exception) { }
        }

        private void menuOptionsItemOpenAppData_Click(object sender, EventArgs e) {
            try {
                Debug.WriteLine("[MainForm] Opening %appdata%\\.minecraft");
                mcLauncher.OpenMinecraftDir(true);
            } catch (Exception) { }
        }

        private void menuOptionsItemReloadVersionList_Click(object sender, EventArgs e) {
            try {
                Debug.WriteLine("[MainForm] Version list reload requested");
                Debug.WriteLine("[MainForm] Clearing comboMinecraftVersion");
                comboMinecraftVersion.Items.Clear();
                Debug.WriteLine("[MainForm] Repopulating comboMinecraftVersion");
                comboMinecraftVersion.Items.AddRange(mcLauncher.GetMinecraftVersions());
                comboMinecraftVersion.SelectedIndex = 0;
            } catch (Exception ex) {
                Debug.WriteLine("[MainForm] Exception encountered: " + ex.Message);
                Debug.Indent();
                Debug.WriteLine(ex.StackTrace);
                Debug.Unindent();
                MessageBox.Show("Oops, something went wrong and launcher² has to close.\n\nIf you would like to help us fix what caused this crash, please send the log file located at the path below to me@akiwiguy.net :\n" + launcher2.Program.logPath, "launcher²", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
