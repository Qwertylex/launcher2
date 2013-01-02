using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace launcher2 {
    public partial class AuthDetailForm : Form {
        public AuthDetailForm() {
            InitializeComponent();
        }

        private void AuthDetailForm_Load(object sender, EventArgs e) {
            txtUsername.Text = Properties.Settings.Default.MinecraftUsername;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (txtUsername.Text == "") {
                MessageBox.Show("You must enter a username.");
            } else {
                Properties.Settings.Default.MinecraftUsername = txtUsername.Text;
                Properties.Settings.Default.MinecraftPassword = txtPassword.Text;
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
