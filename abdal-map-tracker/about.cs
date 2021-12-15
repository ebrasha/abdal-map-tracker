using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Abdal_Map_Tracker
{
    public partial class about : Telerik.WinControls.UI.RadForm
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public about()
        {
            InitializeComponent();
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            version_info.Text = "Version:" + " " + version.Major + "." + version.Minor;
        }

        private void about_Load(object sender, EventArgs e)
        {
            player.SoundLocation = "ab-us.wav";
            player.Play();
        }

        private void about_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Stop();
        }
    }
}