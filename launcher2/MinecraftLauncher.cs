using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.ComponentModel;
using Ionic.Zip;
using System.Runtime.Serialization;

public class MinecraftLauncher {

    private Form DownloadLWJGLStatusForm;
    private BackgroundWorker DownloadLWJGLThread;
    private string JavaLocation;
    private string LWJGLLocation;

	public MinecraftLauncher() {
        Debug.WriteLine("[MinecraftLauncher] New MinecraftLauncher created");

        JavaLocation = FindJava();
        Debug.WriteLine("[MinecraftLauncher] Reported Java location is \"" + JavaLocation + "\"");
        if (JavaLocation == "") {
            MessageBox.Show("I can't find Java installed on your system. Please install Java and try again.", "launcher²", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw new JavaNotFoundException();
        }
        
        LWJGLLocation = FindLWJGL();
        Debug.WriteLine("[MinecraftLauncher] Reported LWJGL location is \"" + LWJGLLocation + "\"");
        if (LWJGLLocation == "") {
            MessageBox.Show("Welcome to launcher²!\nI'm now going to download the files required for Minecraft to run.\nPress OK to continue.", "launcher²", MessageBoxButtons.OK);
            DownloadLWJGL();
        }
	}

    public string[] GetMinecraftVersions() {
        try {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            string _assemblydir = Path.GetDirectoryName(_assembly.Location);
            Debug.WriteLine("[GetMinecraftVersions] Assembly location: \"" + _assemblydir + "\"");

            if (!Directory.Exists(_assemblydir + "\\versions")) {
                Debug.WriteLine("[GetMinecraftVersions] Versions directory does not exist, creating");
                Directory.CreateDirectory(_assemblydir + "\\versions");
            }

            string[] versionDirContents = Directory.GetDirectories(_assemblydir + "\\versions");
            string[] _collection = new string[versionDirContents.Length + 1];
            _collection[0] = "Minecraft in %appdata%";

            if (versionDirContents != null) {
                int i = 1;
                foreach (string dir in versionDirContents) {
                    Debug.WriteLine("[GetMinecraftVersions] Adding \"" + dir + "\" to collection at index " + _collection.Length);
                    _collection[i] = Path.GetFileName(dir);
                    i++;
                }
                Debug.WriteLine("[GetMinecraftVersions] versionDirContents is null, not adding to collection");
            }
            return _collection;
        }
        catch (Exception ex) {
            Debug.WriteLine("[GetMinecraftVersions] Exception encountered: " + ex.Message);
            Debug.Indent();
            Debug.WriteLine(ex.StackTrace);
            Debug.Unindent();
            throw;
        }
    }

    public bool LaunchMinecraft(string MinecraftVersion, MinecraftAuthentication MinecraftAuthData) {
        Assembly _assembly = Assembly.GetExecutingAssembly();
        string _assemblydir = Path.GetDirectoryName(_assembly.Location);
        string MinecraftJar;
        
        if(MinecraftVersion == "Minecraft in %appdata%")
            MinecraftJar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft\\bin\\minecraft.jar");
        else MinecraftJar = _assemblydir + "\\versions\\" + MinecraftVersion + "\\minecraft.jar";
        if (!File.Exists(MinecraftJar))
            return false;

        Debug.WriteLine("[MinecraftLauncher] Reloading configuration");
        System.Configuration.ConfigurationManager.RefreshSection("userSettings");

        Process launchProcess = new Process();
        launchProcess.StartInfo.FileName = this.JavaLocation;
        launchProcess.StartInfo.Arguments = "-Xms" + launcher2.Properties.Settings.Default.JavaMinHeap + " -Xmx" + launcher2.Properties.Settings.Default.JavaMaxHeap + " -Xincgc ";
        launchProcess.StartInfo.Arguments += "-cp \"" + MinecraftJar + ";";
        launchProcess.StartInfo.Arguments += LWJGLLocation + "jinput.jar" + ";";
        launchProcess.StartInfo.Arguments += LWJGLLocation + "lwjgl.jar" + ";";
        launchProcess.StartInfo.Arguments += LWJGLLocation + "lwjgl_util.jar" + "\" ";
        launchProcess.StartInfo.Arguments += "-Dorg.lwjgl.librarypath=\"" + LWJGLLocation + "natives" + "\" ";
        launchProcess.StartInfo.Arguments += "-Dnet.java.games.input.librarypath=\"" + LWJGLLocation + "natives" + "\" ";
        launchProcess.StartInfo.Arguments += "net.minecraft.client.Minecraft ";
        launchProcess.StartInfo.Arguments += MinecraftAuthData.MinecraftAuthToken;

        Debug.WriteLine("[LaunchMinecraft] Launching java with arguments: " + launchProcess.StartInfo.Arguments);

        launchProcess.Start();
        return true;
    }

    public void OpenMinecraftDir(bool AppData) {
        Assembly _assembly = Assembly.GetExecutingAssembly();
        string _assemblydir = Path.GetDirectoryName(_assembly.Location);
        string dir;
        
        if (AppData) dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft\\");
        else dir = Path.Combine(_assemblydir, "versions\\");

        Debug.WriteLine("[OpenMinecraftDir] Opening \"" + dir + "\"");
        Process.Start(@dir);
    }

    public string FindJava() {
        string[] knownLocations = new string[] {
            Environment.GetEnvironmentVariable("SystemDrive") + "\\Program Files\\Java\\jre7\\bin\\javaw.exe",
            Environment.GetEnvironmentVariable("SystemDrive") + "\\Program Files (x86)\\Java\\jre7\\bin\\javaw.exe",
            // Prefer javaw.exe over java.exe if it's present, since this doesn't show the console window
            // It should _theoretically_ always be there, but have java.exe as a fallback anyway
            Environment.GetEnvironmentVariable("SystemDrive") + "\\Program Files\\Java\\jre7\\bin\\java.exe",
            Environment.GetEnvironmentVariable("SystemDrive") + "\\Program Files (x86)\\Java\\jre7\\bin\\java.exe"
        };

        foreach(string path in knownLocations) {
            Debug.WriteLine("[FindJava] Checking if Java exists at '" + path + "'...");
            if (File.Exists(path)) {
                Debug.WriteLine("[FindJava] Found Java, returning");
                return path;
            }
        }

        // if we found java already we wouldn't be here, so return failure
        return "";
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

    [Serializable] public class JavaNotFoundException : System.Exception {
        public JavaNotFoundException() {
        }

        public JavaNotFoundException(string message) : base(message) {
        }

        public JavaNotFoundException(string message, Exception innerException) : base(message, innerException) {
        }

        protected JavaNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
