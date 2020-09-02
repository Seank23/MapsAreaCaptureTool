using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenderDoc_Area_Capture
{
    public partial class MapsAreaCaptureTool : Form
    {
        private static int METRES_IN_DEG = 111000;
        private int camAltitude = 250;
        private List<string> captureCoords = new List<string>();
        private GMapOverlay selectOverlay = new GMapOverlay();
        private GMapOverlay captureOverlay = new GMapOverlay();
        private PointLatLng selStartCoord;

        public MapsAreaCaptureTool()
        {
            InitializeComponent();
        }

        private void MapsAreaCaptureTool_Load(object sender, EventArgs e)
        {
            gMapControl.ShowCenter = false;
            gMapControl.DragButton = MouseButtons.Right;
            gMapControl.MapProvider = GMapProviders.GoogleSatelliteMap;
            gMapControl.Position = new PointLatLng(51.507222, -0.1275);
            gMapControl.MinZoom = 5;
            gMapControl.MaxZoom = 18;
            gMapControl.Zoom = 14;
            gMapControl.Overlays.Add(selectOverlay);
            gMapControl.Overlays.Add(captureOverlay);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text file|*.txt";
            saveDialog.ShowDialog();

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveDialog.FileName != "")
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        writer.WriteLine("CamAlt=" + camAltitude);
                        writer.WriteLine("AlignCaptures=" + chbAlignCaptures.Checked);
                        writer.Write("Captures=");

                        foreach (string capture in captureCoords)
                        {
                            writer.Write(capture + ";");
                        }
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Text file|*.txt";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                if (openDialog.FileName != "")
                {
                    using (StreamReader reader = new StreamReader(openDialog.FileName))
                    {
                        while (!reader.EndOfStream)
                        {
                            string[] data = reader.ReadLine().Split('=');
                            switch (data[0])
                            {
                                case "CamAlt":
                                    camAltitude = int.Parse(data[1]);
                                    break;
                                case "AlignCaptures":
                                    chbAlignCaptures.Checked = bool.Parse(data[1]);
                                    break;
                                case "Captures":
                                    string[] captures = data[1].Split(';');
                                    foreach (string capture in captures)
                                    {
                                        if (capture != "")
                                            captureCoords.Add(capture);
                                    }
                                    break;
                            }
                        }
                    }
                    OnOpen();
                }
            }
        }

        private void OnOpen()
        {
            switch (camAltitude)
            {
                case 1000:
                    tbQuality.Value = 0;
                    LblQuality.Text = "Low";
                    break;
                case 500:
                    tbQuality.Value = 1;
                    LblQuality.Text = "Medium";
                    break;
                case 250:
                    tbQuality.Value = 2;
                    LblQuality.Text = "High";
                    break;
                case 100:
                    tbQuality.Value = 3;
                    LblQuality.Text = "Ultra";
                    break;
                default:
                    chbCustomQuality.Checked = true;
                    txtCamAlt.Text = camAltitude.ToString();
                    chbCustomQuality_CheckedChanged(null, null);
                    break;
            }

            rtbResult.Text = "File opened successfully!\n\n";
            DisplayCaptures(captureCoords);
        }

        private void tbQuality_Scroll(object sender, EventArgs e)
        {

            switch (tbQuality.Value)
            {
                case 0:
                    camAltitude = 1000;
                    LblQuality.Text = "Low";
                    break;
                case 1:
                    camAltitude = 500;
                    LblQuality.Text = "Medium";
                    break;
                case 2:
                    camAltitude = 250;
                    LblQuality.Text = "High";
                    break;
                case 3:
                    camAltitude = 100;
                    LblQuality.Text = "Ultra";
                    break;
            }
        }

        private void chbCustomQuality_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCustomQuality.Checked)
            {
                tbQuality.Visible = false;
                txtCamAlt.Visible = true;
                LblQuality.Text = "Set Camera Altitude";
            }
            else
            {
                tbQuality.Visible = true;
                txtCamAlt.Visible = false;
                tbQuality_Scroll(null, null);
            }
        }

        private void txtCamAlt_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtCamAlt.Text, out int n))
                camAltitude = n;
            else
                txtCamAlt.Text = "";
        }

        private double GetZoomLevel(int camAlt)
        {
            return Math.Log(40000000 / (camAlt / 2), 2);
        }

        private double[] GetCaptureDimensions(int camAlt)
        {
            double length = (2 * Math.PI * 6378137) / (256 * Math.Pow(2, GetZoomLevel(camAlt))) * 1000;
            return new double[] { Math.Round(length, 2), Math.Round(length / GetAspectRatio() - (length / GetAspectRatio()) / 5, 2) };
        }

        private double GetAspectRatio()
        {
            int width = int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
            int height = int.Parse(Screen.PrimaryScreen.Bounds.Height.ToString());
            return (double)width / (double)height;
        }

        private double[] GetDimensionsFromCoords(string a, string b)
        {
            string[] coordA = a.Split(',');
            string[] coordB = b.Split(',');
            double avgLat = (double.Parse(coordA[0]) + double.Parse(coordB[0])) / 2;
            double latDistance = Math.Abs(double.Parse(coordA[0]) - double.Parse(coordB[0])) * METRES_IN_DEG;
            double lngDistance = Math.Abs(double.Parse(coordA[1]) - double.Parse(coordB[1])) * Math.Cos(avgLat * (Math.PI / 180)) * METRES_IN_DEG;
            return new double[] { Math.Round(lngDistance, 2), Math.Round(latDistance, 2) };
        }

        private double DistanceToLat(double distance)
        {
            return distance / METRES_IN_DEG;
        }

        private double DistanceToLng(double lat, double distance)
        {
            return distance / (Math.Cos(lat * (Math.PI / 180)) * METRES_IN_DEG);
        }

        private double[] CalculateOffset(double deltaHorizontal, double deltaVertical, double[] captureSize, double lat)
        {
            double offsetDistanceV = DistanceToLat(deltaVertical / 2 * captureSize[1]);
            double offsetDistanceH = DistanceToLng(lat, deltaHorizontal / 2 * captureSize[0]);
            return new double[] { -offsetDistanceH, -offsetDistanceV };
        }

        private double[] AlignCoords(double lat, double lng, double[] captureSize)
        {
            double deltaLat = Math.Abs(double.Parse(captureCoords[0].Split(',')[0]) + DistanceToLat(captureSize[1] / 2) - lat);
            double deltaLng = Math.Abs(double.Parse(captureCoords[0].Split(',')[1]) - DistanceToLng(double.Parse(captureCoords[0].Split(',')[0]), captureSize[0] / 2) - lng);
            string a = lat + "," + lng;
            string b = (lat + deltaLat).ToString() + "," + (lng + deltaLng).ToString();
            double[] distance = GetDimensionsFromCoords(a, b);
            double alignedLat = distance[1] % captureSize[1];
            double alignedLng = distance[0] % captureSize[0];
            if (alignedLat > captureSize[1] / 2)
                alignedLat -= captureSize[1];
            if (alignedLng > captureSize[0] / 2)
                alignedLng -= captureSize[0];
            alignedLat = DistanceToLat(alignedLat);
            alignedLng = DistanceToLng(lat, alignedLng);
            return new double[] { lat + alignedLat, lng - alignedLng };
        }

        private List<string> GetCaptureCoords()
        {
            List<string> myCaptures = new List<string>();
            double[] captureSize = GetCaptureDimensions(camAltitude);
            double[] selDimensions = GetDimensionsFromCoords(txtSelCoordUpper.Text, txtSelCoordLower.Text);

            int numHorizontal = (int)Math.Ceiling(selDimensions[0] / captureSize[0]);
            int numVertical = (int)Math.Ceiling(selDimensions[1] / captureSize[1]);
            double[] offset = CalculateOffset(numHorizontal - (selDimensions[0] / captureSize[0]), numVertical - (selDimensions[1] / captureSize[1]), captureSize, double.Parse(txtSelCoordUpper.Text.Split(',')[0]));

            double startLat = double.Parse(txtSelCoordUpper.Text.Split(',')[0]) - offset[1];
            double startLng = double.Parse(txtSelCoordUpper.Text.Split(',')[1]) + offset[0];

            if (chbAlignCaptures.Checked && captureCoords.Count > 0)
            {
                double[] alignedCoords = AlignCoords(startLat, startLng, captureSize);
                startLat = alignedCoords[0];
                startLng = alignedCoords[1];
            }

            double curLat = startLat;
            double curLng = startLng;

            for (int i = 0; i < numVertical; i++)
            {
                for (int j = 0; j < numHorizontal; j++)
                {
                    double captureLowerLat = curLat - DistanceToLat(captureSize[1]);
                    double captureLowerLng = curLng + DistanceToLng(captureLowerLat, captureSize[0]);
                    double captureMidLat = (curLat + captureLowerLat) / 2;
                    double captureMidLng = (curLng + captureLowerLng) / 2;
                    myCaptures.Add(Math.Round(captureMidLat, 6) + "," + Math.Round(captureMidLng, 6));
                    curLng = captureLowerLng;
                }
                curLat -= DistanceToLat(captureSize[1]);
                curLng = startLng;
            }
            return myCaptures;
        }

        private void DisplayCaptures(List<string> captures)
        {
            rtbResult.Text += "Area requires " + captures.Count + " captures\n\n";
            double[] captureSize = GetCaptureDimensions(camAltitude);

            foreach (string capture in captures)
            {
                GMapMarker captureMarker = new GMarkerGoogle(new PointLatLng(double.Parse(capture.Split(',')[0]), double.Parse(capture.Split(',')[1])), GMarkerGoogleType.blue_small);
                captureOverlay.Markers.Add(captureMarker);

                double topLat = double.Parse(capture.Split(',')[0]) + DistanceToLat(captureSize[1] / 2);
                double topLng = double.Parse(capture.Split(',')[1]) - DistanceToLng(topLat, captureSize[0] / 2);
                double bottomLat = double.Parse(capture.Split(',')[0]) - DistanceToLat(captureSize[1] / 2);
                double bottomLng = double.Parse(capture.Split(',')[1]) + DistanceToLng(bottomLat, captureSize[0] / 2);

                GMapPolygon capturePoly = new GMapPolygon(new List<PointLatLng>() { new PointLatLng(topLat, topLng), new PointLatLng(topLat, bottomLng),
                        new PointLatLng(bottomLat, bottomLng), new PointLatLng(bottomLat, topLng) }, "");
                capturePoly.Stroke = new Pen(Color.Blue, 2);
                capturePoly.Fill = new SolidBrush(Color.Empty);
                captureOverlay.Polygons.Add(capturePoly);

                rtbResult.Text += "https://www.google.com/maps/@" + capture + "," + camAltitude + "m/data=!3m1!1e3\n";
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var returnedCoords = GetCaptureCoords();
            captureCoords.AddRange(returnedCoords);
            DisplayCaptures(returnedCoords);
        }

        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                selectOverlay.Polygons.Clear();
                var coord = gMapControl.FromLocalToLatLng(e.X, e.Y);
                txtSelCoordUpper.Text = Math.Round(coord.Lat, 6) + ", " + Math.Round(coord.Lng, 6);
                selStartCoord = coord;
            }
        }

        private void gMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var coord = gMapControl.FromLocalToLatLng(e.X, e.Y);
                txtSelCoordLower.Text = Math.Round(coord.Lat, 6) + ", " + Math.Round(coord.Lng, 6);

                GMapPolygon selPoly = new GMapPolygon(new List<PointLatLng>() { selStartCoord, new PointLatLng(selStartCoord.Lat, coord.Lng), coord, new PointLatLng(coord.Lat, selStartCoord.Lng) }, "");
                selPoly.Stroke = new Pen(Color.Red, 2);
                selPoly.Fill = new SolidBrush(Color.Empty);
                selectOverlay.Polygons.Add(selPoly);
            }
        }
    }
}
