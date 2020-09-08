using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapsAreaCaptureTool
{
    public partial class MapsAreaCaptureTool : Form
    {
        private static int METRES_IN_DEG = 111000;

        private int camAltitude = 250;
        private List<Capture> capturesList = new List<Capture>();
        private GMapOverlay selectOverlay = new GMapOverlay();
        private GMapOverlay captureOverlay = new GMapOverlay();
        private PointLatLng selStartCoord;
        private string grid = "";

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

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveDialog.FileName != "")
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        writer.WriteLine("CamAlt=" + camAltitude);
                        writer.WriteLine("Overlap=" + numOverlap.Value);
                        writer.WriteLine("AlignCaptures=" + chbAlignCaptures.Checked);
                        writer.WriteLine("Grid=" + grid);
                        writer.Write("Captures=");

                        foreach (Capture capture in capturesList)
                            writer.Write(capture.Coordinate[0] + "," + capture.Coordinate[1] + "," + capture.Altitude + "," + capture.Overlap + "," + capture.Completed + ";");
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
                            if(data.Length <= 1)
                            {
                                MessageBox.Show("Error: Format is incorrect, file could not be read.");
                                return;
                            }

                            switch (data[0])
                            {
                                case "CamAlt":
                                    camAltitude = int.Parse(data[1]);
                                    break;
                                case "Overlap":
                                    numOverlap.Value = int.Parse(data[1]);
                                    break;
                                case "AlignCaptures":
                                    chbAlignCaptures.Checked = bool.Parse(data[1]);
                                    break;
                                case "Grid":
                                    grid = data[1];
                                    break;
                                case "Captures":
                                    string[] captures = data[1].Split(';');
                                    foreach (string capture in captures)
                                    {
                                        if (capture != "")
                                        {
                                            string[] captureData = capture.Split(',');
                                            if(captureData.Length > 4)
                                                capturesList.Add(new Capture(new double[] { double.Parse(captureData[0]), double.Parse(captureData[1]) }, int.Parse(captureData[2]), int.Parse(captureData[3]),
                                                    bool.Parse(captureData[4])));
                                            else
                                                capturesList.Add(new Capture(new double[] { double.Parse(captureData[0]), double.Parse(captureData[1]) }, int.Parse(captureData[2]), int.Parse(captureData[3]), false));
                                        }
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
            if (grid != "")
            {
                gMapControl.Position = new PointLatLng(double.Parse(grid.Split(',')[0]), double.Parse(grid.Split(',')[1]));
                gMapControl.Zoom = 14;
            }

            rtbResult.Text = "File opened successfully!\n\n";
            DisplayCaptures(capturesList);
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

        private double[] GetCaptureDimensions(int camAlt, int percentOverlap)
        {
            double length = (2 * Math.PI * 6378137) / (256 * Math.Pow(2, GetZoomLevel(camAlt))) * 1000;
            double overlapX = length * ((double)percentOverlap / 100);
            double overlapY = length / GetAspectRatio() * ((double)percentOverlap / 100);
            return new double[] { Math.Round(length - overlapX, 2), Math.Round(length / GetAspectRatio() - overlapY, 2) };
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
            double deltaLat = Math.Abs(capturesList[0].Coordinate[0] + DistanceToLat(captureSize[1] / 2) - lat);
            double deltaLng = Math.Abs(capturesList[0].Coordinate[1] - DistanceToLng(capturesList[0].Coordinate[0], captureSize[0] / 2) - lng);
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

        private List<Capture> GetCaptures(string startCoord, string endCoord)
        {
            List<Capture> myCaptures = new List<Capture>();
            double[] captureSize = GetCaptureDimensions(camAltitude, Convert.ToInt32(numOverlap.Value));
            double[] selDimensions = GetDimensionsFromCoords(startCoord, endCoord);

            int numHorizontal = (int)Math.Ceiling(selDimensions[0] / captureSize[0]);
            int numVertical = (int)Math.Ceiling(selDimensions[1] / captureSize[1]);

            double startLat = Math.Max(double.Parse(startCoord.Split(',')[0]), double.Parse(endCoord.Split(',')[0]));
            double startLng = Math.Min(double.Parse(startCoord.Split(',')[1]), double.Parse(endCoord.Split(',')[1]));
            
            if(chbCentre.Checked)
            {
                double[] offset = CalculateOffset(numHorizontal - (selDimensions[0] / captureSize[0]), numVertical - (selDimensions[1] / captureSize[1]), captureSize, startLat);
                startLat -= offset[1];
                startLng += offset[0];
            }

            if (chbAlignCaptures.Checked && capturesList.Count > 0)
            {
                double[] alignedCoords;
                if (grid.Split(',').Length > 2)
                    alignedCoords = AlignCoords(startLat, startLng, GetCaptureDimensions(int.Parse(grid.Split(',')[2]), int.Parse(grid.Split(',')[3])));
                else
                    alignedCoords = AlignCoords(startLat, startLng, captureSize);
                startLat = alignedCoords[0];
                startLng = alignedCoords[1];
            }

            if (capturesList.Count == 0)
                grid = startLat + "," + startLng + "," + camAltitude + "," + numOverlap.Value;

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
                    myCaptures.Add(new Capture(new double[] { Math.Round(captureMidLat, 6), Math.Round(captureMidLng, 6) }, camAltitude, Convert.ToInt32(numOverlap.Value), false));
                    curLng = captureLowerLng;
                }
                curLat -= DistanceToLat(captureSize[1]);
                curLng = startLng;
            }
            return myCaptures;
        }

        private void DisplayCaptures(List<Capture> captures)
        {
            rtbResult.Text += "Area requires " + captures.Count + " captures\n\n";

            foreach (Capture capture in captures)
            {
                GMapMarker captureMarker = new GMarkerGoogle(new PointLatLng(capture.Coordinate[0], capture.Coordinate[1]), GMarkerGoogleType.blue);
                captureMarker.ToolTipText = capture.URL + "\nDouble-click to copy to clipboard";
                captureOverlay.Markers.Add(captureMarker);

                double[] captureSize = GetCaptureDimensions(capture.Altitude, capture.Overlap);
                double topLat = capture.Coordinate[0] + DistanceToLat(captureSize[1] / 2);
                double topLng = capture.Coordinate[1] - DistanceToLng(topLat, captureSize[0] / 2);
                double bottomLat = capture.Coordinate[0] - DistanceToLat(captureSize[1] / 2);
                double bottomLng = capture.Coordinate[1] + DistanceToLng(bottomLat, captureSize[0] / 2);

                GMapPolygon capturePoly = new GMapPolygon(new List<PointLatLng>() { new PointLatLng(topLat, topLng), new PointLatLng(topLat, bottomLng),
                        new PointLatLng(bottomLat, bottomLng), new PointLatLng(bottomLat, topLng) }, "");

                if(capture.Completed)
                    capturePoly.Stroke = new Pen(Color.Red, 2);
                else
                    capturePoly.Stroke = new Pen(Color.Blue, 2);

                capturePoly.Fill = new SolidBrush(Color.Empty);
                captureOverlay.Polygons.Add(capturePoly);

                rtbResult.Text += capture.URL + "\n";
            }
            rtbResult.Text += "\n";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string startCoord = txtSelCoordUpper.Text;
                string endCoord = txtSelCoordLower.Text;
                if (startCoord.Split(',').Length > 2 || endCoord.Split(',').Length > 2)
                {
                    string[] startSplit = startCoord.Split(',');
                    string[] endSplit = endCoord.Split(',');
                    startCoord = startSplit[0] + "." + startSplit[1] + "," + startSplit[2] + "." + startSplit[3];
                    endCoord = endSplit[0] + "." + endSplit[1] + "," + endSplit[2] + "." + endSplit[3];
                }
                var returnedCaptures = GetCaptures(startCoord, endCoord);
                capturesList.AddRange(returnedCaptures);
                DisplayCaptures(returnedCaptures);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid selection, please try again...");
            }
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

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            capturesList.Clear();
            captureOverlay.Clear();
            rtbResult.Clear();
        }

        private void gMapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                for(int i = 0; i < captureOverlay.Polygons.Count; i++)
                {
                    PointLatLng clickPoint = gMapControl.FromLocalToLatLng(e.X, e.Y);
                    if(captureOverlay.Polygons[i].IsInside(clickPoint))
                    {
                        string url = captureOverlay.Markers[i].ToolTipText;
                        captureOverlay.Markers[i].ToolTipText = "Copied!";
                        Clipboard.SetText(capturesList[i].URL);
                        Task.Factory.StartNew(() => ResetToolTip(url, i));
                        capturesList[i].Completed = true;
                        captureOverlay.Polygons[i].Stroke = new Pen(Color.Red, 2);
                        return;
                    }
                }
            }
        }

        private void ResetToolTip(string url, int index)
        {
            Thread.Sleep(1000);
            captureOverlay.Markers[index].ToolTipText = url;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> removeIndex = new List<int>();
                for (int i = 0; i < capturesList.Count; i++)
                {
                    if (capturesList[i].Coordinate[0] <= double.Parse(txtSelCoordUpper.Text.Split(',')[0]) && capturesList[i].Coordinate[0] >= double.Parse(txtSelCoordLower.Text.Split(',')[0])
                        && capturesList[i].Coordinate[1] >= double.Parse(txtSelCoordUpper.Text.Split(',')[1]) && capturesList[i].Coordinate[1] <= double.Parse(txtSelCoordLower.Text.Split(',')[1]))
                    {
                        removeIndex.Add(i);
                    }
                }
                for (int i = removeIndex.Count - 1; i >= 0; i--)
                    capturesList.RemoveAt(removeIndex[i]);

                captureOverlay.Clear();
                rtbResult.Clear();
                DisplayCaptures(capturesList);
            }
            catch(Exception)
            {
                MessageBox.Show("Error: Captures could not be removed");
            }
        }
    }
}
