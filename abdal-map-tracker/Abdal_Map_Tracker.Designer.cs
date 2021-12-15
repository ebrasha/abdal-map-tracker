namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.radMap1 = new Telerik.WinControls.UI.RadMap();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.openLatitudeAndLongitudeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAboutUs = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitlabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radMap1)).BeginInit();
            this.radMap1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMap1
            // 
            this.radMap1.Controls.Add(this.menuStrip1);
            this.radMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radMap1.Location = new System.Drawing.Point(0, 0);
            this.radMap1.Name = "radMap1";
            this.radMap1.ShowSearchBar = false;
            this.radMap1.Size = new System.Drawing.Size(800, 510);
            this.radMap1.TabIndex = 0;
            this.radMap1.ThemeName = "VisualStudio2012Dark";
            this.radMap1.DoubleClick += new System.EventHandler(this.radMap1_DoubleClick);
            ((Telerik.WinControls.UI.RadMapElement)(this.radMap1.GetChildAt(0))).BorderDrawMode = Telerik.WinControls.BorderDrawModes.RightOverTop;
            ((Telerik.WinControls.UI.RadMapElement)(this.radMap1.GetChildAt(0))).RightToLeft = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLatitudeAndLongitudeFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.startTrackingToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItemAboutUs,
            this.toolStripMenuItem2,
            this.donateToolStripMenuItem,
            this.toolStripMenuItem4,
            this.sourceCodeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = "|";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem3.Text = "|";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem2.Text = "|";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem4.Text = "|";
            // 
            // openLatitudeAndLongitudeFileToolStripMenuItem
            // 
            this.openLatitudeAndLongitudeFileToolStripMenuItem.Image = global::Abdal_Map_Tracker.Properties.Resources.Earth_Location_5121;
            this.openLatitudeAndLongitudeFileToolStripMenuItem.Name = "openLatitudeAndLongitudeFileToolStripMenuItem";
            this.openLatitudeAndLongitudeFileToolStripMenuItem.Size = new System.Drawing.Size(211, 20);
            this.openLatitudeAndLongitudeFileToolStripMenuItem.Text = "Open Latitude and Longitude File";
            this.openLatitudeAndLongitudeFileToolStripMenuItem.Click += new System.EventHandler(this.openLatitudeAndLongitudeFileToolStripMenuItem_Click);
            // 
            // startTrackingToolStripMenuItem
            // 
            this.startTrackingToolStripMenuItem.Image = global::Abdal_Map_Tracker.Properties.Resources.Position_5121;
            this.startTrackingToolStripMenuItem.Name = "startTrackingToolStripMenuItem";
            this.startTrackingToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.startTrackingToolStripMenuItem.Text = "Start Tracking";
            this.startTrackingToolStripMenuItem.Click += new System.EventHandler(this.startTrackingToolStripMenuItem_Click);
            // 
            // toolStripMenuItemAboutUs
            // 
            this.toolStripMenuItemAboutUs.Image = global::Abdal_Map_Tracker.Properties.Resources.Book_Earth_512;
            this.toolStripMenuItemAboutUs.Name = "toolStripMenuItemAboutUs";
            this.toolStripMenuItemAboutUs.Size = new System.Drawing.Size(84, 20);
            this.toolStripMenuItemAboutUs.Text = "About Us";
            this.toolStripMenuItemAboutUs.Click += new System.EventHandler(this.toolStripMenuItemAboutUs_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Image = global::Abdal_Map_Tracker.Properties.Resources.coin_5_32;
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // sourceCodeToolStripMenuItem
            // 
            this.sourceCodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.githubToolStripMenuItem,
            this.gitlabToolStripMenuItem});
            this.sourceCodeToolStripMenuItem.Image = global::Abdal_Map_Tracker.Properties.Resources.code;
            this.sourceCodeToolStripMenuItem.Name = "sourceCodeToolStripMenuItem";
            this.sourceCodeToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.sourceCodeToolStripMenuItem.Text = "Source Code";
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.Image = global::Abdal_Map_Tracker.Properties.Resources.github;
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.githubToolStripMenuItem.Text = "Github";
            this.githubToolStripMenuItem.Click += new System.EventHandler(this.githubToolStripMenuItem_Click);
            // 
            // gitlabToolStripMenuItem
            // 
            this.gitlabToolStripMenuItem.Image = global::Abdal_Map_Tracker.Properties.Resources.gitlab_icon_rgb;
            this.gitlabToolStripMenuItem.Name = "gitlabToolStripMenuItem";
            this.gitlabToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gitlabToolStripMenuItem.Text = "Gitlab";
            this.gitlabToolStripMenuItem.Click += new System.EventHandler(this.gitlabToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.radMap1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Abdal Map Tracker";
            this.ThemeName = "VisualStudio2012Dark";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radMap1)).EndInit();
            this.radMap1.ResumeLayout(false);
            this.radMap1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadMap radMap1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openLatitudeAndLongitudeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startTrackingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAboutUs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitlabToolStripMenuItem;
    }
}

