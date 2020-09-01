using AxMapWinGIS;
using MapWinGIS;
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
    public partial class RenderDocAreaCapture : Form
    {
        private static int METRES_IN_DEG = 111000;
        private int camAltitude = 250;
        private List<string> captureCoords = new List<string>();
        public RenderDocAreaCapture()
        {
            InitializeComponent();
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
                                case "Captures":
                                    string[] captures = data[1].Split(';');
                                    foreach(string capture in captures)
                                    {
                                        if(capture != "")
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
            switch(camAltitude)
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
            PrintCaptures();
        }

        private void tbQuality_Scroll(object sender, EventArgs e)
        {
            
            switch(tbQuality.Value)
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
            if(chbCustomQuality.Checked)
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

        private List<string> GetCaptureCoords()
        {
            double[] captureSize = GetCaptureDimensions(camAltitude);
            double[] selDimensions = GetDimensionsFromCoords(txtSelCoordUpper.Text, txtSelCoordLower.Text);

            int numHorizontal = (int)Math.Ceiling(selDimensions[0] / captureSize[0]);
            int numVertical = (int)Math.Ceiling(selDimensions[1] / captureSize[1]);

            List<String> captureCoords = new List<string>();
            double startLat = double.Parse(txtSelCoordUpper.Text.Split(',')[0]);
            double startLng = double.Parse(txtSelCoordUpper.Text.Split(',')[1]);
            double curLat = startLat;
            double curLng = startLng;

            for (int i = 0; i < numVertical; i++)
            {
                for(int j = 0; j < numHorizontal; j++)
                {
                    double captureLowerLat = curLat + DistanceToLat(captureSize[1]);
                    double captureLowerLng = curLng + DistanceToLng(captureLowerLat, captureSize[0]);
                    double captureMidLat = (curLat + captureLowerLat) / 2;
                    double captureMidLng = (curLng + captureLowerLng) / 2;
                    captureCoords.Add(Math.Round(captureMidLat, 6) + "," + Math.Round(captureMidLng, 6));
                    curLng = captureLowerLng;
                }
                curLat -= DistanceToLat(captureSize[1]);
                curLng = startLng;
            }
            return captureCoords;
        }

        private void PrintCaptures()
        {
            rtbResult.Text += "Area requires " + captureCoords.Count + " captures\n\n";

            foreach (string capture in captureCoords)
            {
                rtbResult.Text += "https://www.google.com/maps/@" + capture + "," + camAltitude + "m/data=!3m1!1e3\n";
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            captureCoords = GetCaptureCoords();
            PrintCaptures();
        }
    }
}
