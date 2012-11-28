﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace launcher2
{
    public partial class AboutDialog : Form
    {
        public AboutDialog() {
            Debug.WriteLine("[AboutDialog] New AboutDialog created.");
            InitializeComponent();
            Debug.WriteLine("[AboutDialog] Updating label text.");
            lblVersion.Text = "launcher² version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Debug.WriteLine("[AboutDialog] Closing.");
            this.Close();
        }

        private void lblSilkIcons_Click(object sender, EventArgs e) {
            Debug.WriteLine("[AboutDialog] Launching default browser to Silk icon set page.");
            Process silkIcons = new Process();
            silkIcons.StartInfo.FileName = "http://www.famfamfam.com/lab/icons/silk/";
            silkIcons.StartInfo.UseShellExecute = true;
            silkIcons.Start();
            silkIcons.Dispose();
        }

        private void lblMSPL_Click(object sender, EventArgs e) {
            MessageBox.Show("Microsoft Public License (Ms-PL)\nThis license governs use of the accompanying software, the DotNetZip library (\"the software\"). If you use the software, you accept this license. If you do not accept the license, do not use the software.\n\n1. Definitions\nThe terms \"reproduce,\" \"reproduction,\" \"derivative works,\" and \"distribution\" have the same meaning here as under U.S. copyright law.\nA \"contribution\" is the original software, or any additions or changes to the software.\nA \"contributor\" is any person that distributes its contribution under this license.\n\"Licensed patents\" are a contributor's patent claims that read directly on its contribution.\n\n2. Grant of Rights\n(A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.\n(B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.\n\n3. Conditions and Limitations\n(A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.\n(B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.\n(C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.\n(D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.\n(E) The software is licensed \"as-is.\" You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.", "Microsoft Public Licence (Ms-PL)");
        }
    }
}
