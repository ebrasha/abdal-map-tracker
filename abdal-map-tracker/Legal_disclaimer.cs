using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Abdal_Map_Tracker
{
    public partial class Legal_disclaimer : Telerik.WinControls.UI.RadForm
    {
        public Legal_disclaimer()
        {
            InitializeComponent();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WindowsFormsApp1.Form1 main_form = new WindowsFormsApp1.Form1();
            main_form.Show();
        }

        private void Legal_disclaimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
        }
    }
}
