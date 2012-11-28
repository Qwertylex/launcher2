using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace launcher2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            // Enable debugging output to a logfile with the date and time of launch in the current directory
            Assembly _assembly = typeof(MainForm).Assembly;
            DateTime _now = DateTime.Now;
            string logPath = Path.GetDirectoryName(_assembly.Location) + "\\" + 
                _now.Year + "-" + _now.Month + "-" + _now.Day + "_" + 
                _now.Hour + "-" + _now.Minute + "-" + _now.Second + ".log";

            Debug.WriteLine("[LogListener] Setting up Listener for log file " + logPath);
            TextWriterTraceListener logListener = new TextWriterTraceListener(logPath);
            Debug.Listeners.Add(logListener);
            Debug.WriteLine("[LogListener] Log file " + logPath + " created");
            
            // and start evetything
            Debug.WriteLine("[Program] Starting new MainForm");
            Application.Run(new MainForm());

            Debug.WriteLine("[Program] Returned from MainForm, cleaning up");
            logListener.Flush();
            logListener.Dispose();
        }
    }
}
