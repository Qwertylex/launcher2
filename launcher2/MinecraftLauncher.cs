using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.ComponentModel;
using Ionic.Zip;

public class MinecraftLauncher {
	public MinecraftLauncher() {
        Debug.WriteLine("[MinecraftLauncher] New MinecraftLauncher created");
        if(FindLWJGL() == "") {
            // we don't have LWJGL, prompt to download it
            MessageBox.Show("Welcome to launcher²!\nI'm now going to download the files required for Minecraft to run.\nPress OK to continue.", "launcher²", MessageBoxButtons.OK);
            DownloadLWJGL();
        }
	}

    /// <summary>
    /// Looks in the application directory for the LWJGL files.
    /// Returns the full path they are in if found, otherwise an empty string.
    /// </summary>
    public string FindLWJGL() {
        Assembly _assembly = Assembly.GetExecutingAssembly();
        string _assemblydir = Path.GetDirectoryName(_assembly.Location);
        Debug.WriteLine("[FindLWJGL] We are in " + _assemblydir);

        // List of what LWJGL files we want to exist before doing anything
        string[] filearray = new string[] { 
            "\\lwjgl\\lwjgl.jar",
            "\\lwjgl\\lwjgl_util.jar", 
            "\\lwjgl\\jinput.jar"
        };

        foreach (string file in filearray) {
            Debug.WriteLine("[FindLWJGL] Searching for '" + file + "'...");
            if (File.Exists(_assemblydir + file)) {
                Debug.WriteLine("[FindLWJGL] '" + file + "' found in " + _assemblydir);
            } else {
                Debug.WriteLine("[FindLWJGL] '" + file + "' not found, search aborted");
                return "";
            }
        }

        Debug.WriteLine("[FindLWJGL] Searching for lwjgl natives...");
        if (Directory.Exists(_assemblydir + "\\lwjgl/natives\\")) {
            Debug.WriteLine("[FindLWJGL] lwjgl natives found in " + _assemblydir + "\\lwjgl\\natives");
        } else { 
            Debug.WriteLine("[FindLWJGL] lwjgl natives not found, search aborted"); 
            return ""; 
        }

        Debug.WriteLine("[FindLWJGL] Search complete.");
        return _assemblydir + "\\lwjgl\\";
    }

    private Form DownloadLWJGLStatusForm;
    private BackgroundWorker DownloadLWJGLThread;

    public bool DownloadLWJGL() {
        Debug.WriteLine("[DownloadLWJGL] Creating DownloadLWJGLStatusForm form.");
        DownloadLWJGLStatusForm = new Form();
        Label DownloadStatusLabel = new Label();
        DownloadLWJGLStatusForm.SuspendLayout();
        DownloadStatusLabel.Text = "Downloading LWJGL...";
        DownloadStatusLabel.Name = "DownloadStatusLabel";
        DownloadStatusLabel.Location = new System.Drawing.Point(12, 0);
        DownloadStatusLabel.Height = 48;
        DownloadStatusLabel.Width = 192;
        DownloadStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        DownloadStatusLabel.BackColor = System.Drawing.SystemColors.Control;
        DownloadStatusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
        DownloadStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
        DownloadLWJGLStatusForm.Height = 72;
        DownloadLWJGLStatusForm.Width = 216;
        DownloadLWJGLStatusForm.Controls.Add(DownloadStatusLabel);
        DownloadLWJGLStatusForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        DownloadLWJGLStatusForm.ResumeLayout(false);
        DownloadLWJGLStatusForm.Text = "launcher²";
        DownloadLWJGLStatusForm.Icon = global::launcher2.Properties.Resources.l2_ico;
        DownloadLWJGLStatusForm.FormClosing += new FormClosingEventHandler(DownloadLWJGLStatusForm_FormClosing);
        DownloadLWJGLStatusForm.Refresh();
        DownloadLWJGLStatusForm.Show();
        DownloadLWJGLStatusForm.Activate();

        DownloadLWJGLThread = new BackgroundWorker();
        DownloadLWJGLThread.WorkerReportsProgress = true;
        DownloadLWJGLThread.WorkerSupportsCancellation = true;
        DownloadLWJGLThread.DoWork += new DoWorkEventHandler(DownloadLWJGLThread_DoWork);
        DownloadLWJGLThread.ProgressChanged += new ProgressChangedEventHandler(DownloadLWJGLThread_ProgressChanged);
        DownloadLWJGLThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DownloadLWJGLThread_RunWorkerCompleted);
        DownloadLWJGLThread.RunWorkerAsync();
        return true;
    }

    private void DownloadLWJGLThread_DoWork(object sender, DoWorkEventArgs e) {
        BackgroundWorker DownloadLWJGLThread = (BackgroundWorker)sender as BackgroundWorker;
        if (DownloadLWJGLThread != null) {
            Debug.WriteLine("[DownloadLWJGLThread_DoWork] Starting LWJGL download...");
            Assembly _assembly = Assembly.GetExecutingAssembly();
            string _assemblydir = Path.GetDirectoryName(_assembly.Location);
            WebClient webClient = new WebClient();

            // create the LWJGL directories
            Directory.CreateDirectory(_assemblydir + "\\lwjgl\\");
            Directory.CreateDirectory(_assemblydir + "\\lwjgl\\natives\\");

            string[] filearray = new string[] {
                "http://s3.amazonaws.com/MinecraftDownload/lwjgl.jar",
                "http://s3.amazonaws.com/MinecraftDownload/lwjgl_util.jar",
                "http://s3.amazonaws.com/MinecraftDownload/jinput.jar",
                "http://s3.amazonaws.com/MinecraftDownload/windows_natives.jar"
            };

            foreach (string file in filearray) {
                if (DownloadLWJGLThread.CancellationPending == true) {
                    e.Cancel = true;
                    return;
                }
                string filename = file.Substring(file.LastIndexOf('/') + 1);
                string localfile = _assemblydir + "\\lwjgl\\" + filename;
                Debug.WriteLine("[DownloadLWJGLThread_DoWork] Downloading '" + file + "' to '" + localfile + "'...");
                try {
                    DownloadLWJGLThread.ReportProgress(1, "Downloading '" + filename + "'...");
                    webClient.DownloadFile(file, localfile);
                } catch (Exception ex) {
                    Debug.WriteLine("[DownloadLWJGLThread_DoWork] Error downloading " + file + ": " + ex.Message);
                    MessageBox.Show("Error downloading " + file + ":\n" + ex.Message, "launcher²", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Debug.WriteLine("[DownloadLWJGLThread_DoWork] LWJGL file download complete.");

            // assume we've downloaded stuff fine if we hit here, so unpack the natives
            try {
                Debug.WriteLine("[DownloadLWJGLThread_DoWork] Unpacking natives...");
                using (ZipFile nativezip = ZipFile.Read(_assemblydir + "\\lwjgl\\windows_natives.jar")) {
                    foreach (ZipEntry entry in nativezip) {
                        if (DownloadLWJGLThread.CancellationPending == true) {
                            e.Cancel = true;
                            return;
                        }
                        if (!entry.FileName.Contains("META-INF")) {
                            Debug.WriteLine("[DownloadLWJGLThread_DoWork] Unpacking '" + entry.FileName + "'...");
                            DownloadLWJGLThread.ReportProgress(1, "Unpacking '" + entry.FileName + "'...");
                            entry.Extract(_assemblydir + "\\lwjgl\\natives\\", ExtractExistingFileAction.OverwriteSilently);
                        } else {
                            Debug.WriteLine("[DownloadLWJGLThread_DoWork] Skipping unpacking of '" + entry.FileName + "'.");
                        }
                    }
                }
                Debug.WriteLine("[DownloadLWJGLThread_DoWork] Completed unpacking natives.");
            }
            catch (Exception ex) {
                Debug.WriteLine("[DownloadLWJGLThread_DoWork] Error extracting natives: " + ex.Message);
                MessageBox.Show("Error extracting natives:\n" + ex.Message, "launcher²", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }  

    private void DownloadLWJGLThread_ProgressChanged(object sender, ProgressChangedEventArgs e) {
        Debug.WriteLine("[DownloadLWJGLThread_ProgressChanged] " + e.UserState);
        this.DownloadLWJGLStatusForm.Activate();
        this.DownloadLWJGLStatusForm.Controls.Find("DownloadStatusLabel", true)[0].Text = "Downloading LWJGL...\n" + e.UserState;
    }

    private void DownloadLWJGLThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
        if (!e.Cancelled) {
            Debug.WriteLine("[DownloadLWJGLThread] Worker completed normally.");
            this.DownloadLWJGLStatusForm.Close();
            this.DownloadLWJGLStatusForm.Dispose();
        } else {
            Debug.WriteLine("[DownloadLWJGLThread] Worker cancelled.");
        }
    }

    private void DownloadLWJGLStatusForm_FormClosing(object sender, FormClosingEventArgs e) {
        Debug.WriteLine("[DownloadLWJGLStatusForm] Closing reason: " + e.CloseReason);
        if (DownloadLWJGLThread.IsBusy == true) {
            Debug.WriteLine("[DownloadLWJGLStatusForm] Worker is busy, cancelling download.");
            DownloadLWJGLThread.CancelAsync();
            this.DownloadLWJGLStatusForm.Controls.Find("DownloadStatusLabel", true)[0].Text = "Cancelling download...";
            this.DownloadLWJGLStatusForm.Refresh();
            while (DownloadLWJGLThread.IsBusy == true) { };
        }
    }
}
