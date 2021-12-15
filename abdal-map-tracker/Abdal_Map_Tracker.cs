using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abdal_Map_Tracker.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Paint;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Map;
using Telerik.WinControls.UI.TaskDialog;

namespace WindowsFormsApp1
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {
        public Form1()
        {
            InitializeComponent();
            //change form title
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = "Abdal Map Tracker" + " " + version.Major + "." + version.Minor;
        }


        private void SetupOpenStreetMapProvider()
        {
            try
            {
                string cacheFolder = @".\ABDAL_MAP_TRACKER_CACHE";
                OpenStreetMapProvider osmProvider = new OpenStreetMapProvider();
                MapTileDownloader tileDownloader = osmProvider.TileDownloader as MapTileDownloader;
                tileDownloader.WebHeaders.Add(HttpRequestHeader.UserAgent, "abdal-map");
                LocalFileCacheProvider cache = new LocalFileCacheProvider(cacheFolder);
                osmProvider.CacheProvider = cache;
                this.radMap1.ShowSearchBar = false;

                this.radMap1.MapElement.Providers.Add(osmProvider);
            }
            catch (Exception)
            {
                // throw;
            }
        }


        #region CustomPin

        public string[] LatitudeLongitudeSpliter(string latitude_longitude)
        {
            string[] latitude_longitude_list = latitude_longitude.Split(',');

            return latitude_longitude_list;
        }


        public void CallMapCustomPin(string[] latitude_longitude_array)
        {
            try
            {
                this.SetupOpenStreetMapProvider();
                MapLayer pointLayer = new MapLayer("PointG");
                this.radMap1.Layers.Add(pointLayer);

                string latitude_longitude_first = latitude_longitude_array.First();
                string[] latitude_longitude_array_fix = latitude_longitude_array.Skip(1).ToArray();

                double latitude = Convert.ToDouble(LatitudeLongitudeSpliter(latitude_longitude_first)[0]);
                double longitude = Convert.ToDouble(LatitudeLongitudeSpliter(latitude_longitude_first)[1]);

                MapPin element = new CustomMapPin(new PointG(latitude, longitude))
                {
                    Image = Resources.man
                };
                element.Text = ("lat " + latitude.ToString() + "-" + "long " + longitude.ToString());
                element.BackColor = Color.Red;
                this.radMap1.Layers["PointG"].Add(element);


                foreach (var latitude_longitude_addr in latitude_longitude_array_fix)
                {
                    latitude = Convert.ToDouble(LatitudeLongitudeSpliter(latitude_longitude_addr)[0]);
                    longitude = Convert.ToDouble(LatitudeLongitudeSpliter(latitude_longitude_addr)[1]);

                    element = new CustomMapPin(new PointG(latitude, longitude))
                    {
                        Image = Resources.man
                    };
                    element.Text = ("lat " + latitude.ToString() + "-" + "long " + longitude.ToString());
                    element.BackColor = Color.Red;
                    this.radMap1.Layers["PointG"].Add(element);
                }
            }
            catch (Exception)
            {
                throw;
            }

            openFileDialog1.Reset();
        }


        public class CustomMapPin : MapPin
        {
            private Image image;
            private PointL pixelLocation;
            private RectangleL drawRect;
            private bool isImageInViewPort;

            public CustomMapPin(PointG location)
                : base(location)
            {
            }

            public Image Image
            {
                get { return image; }
                set { this.image = value; }
            }

            public override bool IsInViewport
            {
                get { return this.Image != null ? this.isImageInViewPort : base.IsInViewport; }
            }

            public override void Paint(IGraphics graphics, IMapViewport viewport)
            {
                object state = graphics.SaveState();
                graphics.ChangeSmoothingMode(SmoothingMode.AntiAlias);
                MapVisualElementInfo info = this.GetVisualElementInfo(viewport);
                GraphicsPath path = info.Path.Clone() as GraphicsPath;
                GraphicsPath dotPath = new GraphicsPath();
                long mapSize = MapTileSystemHelper.MapSize(viewport.ZoomLevel);
                Matrix matrixOffset = new Matrix();
                matrixOffset.Translate(viewport.PanOffset.Width + info.Offset.X,
                    viewport.PanOffset.Height + info.Offset.Y);
                path.Transform(matrixOffset);
                Matrix matrixWraparound = new Matrix();
                matrixWraparound.Translate(mapSize, 0);
                for (int i = 0; i < viewport.NumberOfWraparounds; i++)
                {
                    RectangleF bounds = path.GetBounds();
                    float diameter = bounds.Width / 3F;
                    dotPath.AddEllipse(bounds.X + diameter, bounds.Y + diameter, diameter, diameter);
                    graphics.FillPath(this.BorderColor, dotPath);
                    //draw the image
                    Point imageLocation =
                        new Point((int) bounds.Location.X + (int) bounds.Width / 2 - this.image.Width / 2,
                            (int) bounds.Location.Y);
                    graphics.DrawImage(imageLocation, this.Image, true);
                    path.Transform(matrixWraparound);
                }

                graphics.RestoreState(state);
            }

            public override void ViewportChanged(IMapViewport viewport, ViewportChangeAction action)
            {
                if (this.Image == null)
                {
                    base.ViewportChanged(viewport, action);
                    return;
                }

                long mapSize = MapTileSystemHelper.MapSize(viewport.ZoomLevel);
                if ((action & ViewportChangeAction.Zoom) != 0)
                {
                    this.pixelLocation = MapTileSystemHelper.LatLongToPixelXY(this.Location, viewport.ZoomLevel);
                }

                if ((action & ViewportChangeAction.Pan) != 0)
                {
                    this.drawRect = new RectangleL(pixelLocation.X - this.Image.Size.Width / 2,
                        pixelLocation.Y - this.Image.Size.Height, this.Image.Size.Width, this.Image.Size.Height);
                }

                RectangleL wraparoundDrawRect = this.drawRect;
                for (int i = 0; i <= viewport.NumberOfWraparounds; i++)
                {
                    if (wraparoundDrawRect.IntersectsWith(viewport.ViewportInPixels))
                    {
                        this.isImageInViewPort = true;
                        break;
                    }

                    wraparoundDrawRect.Offset(mapSize, 0L);
                }

                if (!this.IsInViewport)
                {
                    return;
                }
            }

            public override bool HitTest(PointG pointG, PointL pointL, IMapViewport viewport)
            {
                if (this.Image == null)
                {
                    return base.HitTest(pointG, pointL, viewport);
                }

                return this.drawRect.Contains(pointL);
            }
        }

        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.radMap1.MapElement.NavigationBarLocation = MapNavigationBarLocation.BottomLeft;
                this.SetupOpenStreetMapProvider();
            }
            catch (Exception)
            {
                // throw;
            }
        }

        private void radMap1_DoubleClick(object sender, EventArgs e)
        {
        }


        private void openLatitudeAndLongitudeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.AddExtension = false;
                openFileDialog1.Title = "Abdal Map Tracker - Geographic coordinate Info";
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "Lat and Longile |*.txt";
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
                openFileDialog1.FileName = "";
                DialogResult result = openFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void startTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.radMap1.Layers.Clear();
            try
            {
                if (!openFileDialog1.FileName.Contains("txt"))
                {
                    using (var soundPlayer = new SoundPlayer(@"error.wav"))
                    {
                        soundPlayer.PlaySync(); // can also use soundPlayer.Play()
                    }

                    RadTaskDialogPage page = new RadTaskDialogPage();
                    page.Caption = "Abdal Map Tracker";
                    page.Heading = "latitude longitude file error";
                    page.Text =
                        "please first select the Geographic coordinate contain latitude longitude per line like  48.157456,11.503449";
                    page.Icon = RadTaskDialogIcon.ShieldErrorRedBar;
                    page.Icon.SvgImage =
                        RadTaskDialogIcon.GetSvgImage(RadTaskDialogIconImage.FlatShieldError, new Size(32, 32));
                    RadTaskDialog.ShowDialog(page);
                    openFileDialog1.Reset();
                }
                else
                {
                    string[] latitude_longitude_array = File.ReadLines(openFileDialog1.FileName).ToArray();

                    CallMapCustomPin(latitude_longitude_array);
                    using (var soundPlayer = new SoundPlayer(@"start.wav"))
                    {
                        soundPlayer.PlaySync(); // can also use soundPlayer.Play()
                    }
                }
            }
            catch (Exception exception)
            {
                using (var soundPlayer = new SoundPlayer(@"error.wav"))
                {
                    soundPlayer.PlaySync(); // can also use soundPlayer.Play()
                }

                RadTaskDialogPage page = new RadTaskDialogPage();
                page.Caption = "Abdal Map Tracker";
                page.Heading = "latitude longitude file error";
                page.Text =
                    "Your file has a problem, It may have latitude longitude formatting problems. Code 350  ";
                page.Icon = RadTaskDialogIcon.ShieldErrorRedBar;
                page.Icon.SvgImage =
                    RadTaskDialogIcon.GetSvgImage(RadTaskDialogIconImage.FlatShieldError, new Size(32, 32));
                RadTaskDialog.ShowDialog(page);
                openFileDialog1.Reset();
            }
        }

        private void toolStripMenuItemAboutUs_Click(object sender, EventArgs e)
        {
            Abdal_Map_Tracker.about about_form = new Abdal_Map_Tracker.about();
            about_form.Show();
            about_form.TopMost = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://donate.abdalagency.ir/");
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/abdal-security-group/abdal-map-tracker");
        }

        private void gitlabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://gitlab.com/abdal-security-group/abdal-map-tracker");
        }
    }
}