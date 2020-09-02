namespace MapsAreaCaptureTool
{
    class Capture
    {
        public double[] Coordinate { get; set; }
        public int Altitude { get; set; }
        public string URL { get; set; }

        public Capture(double[] coordinate, int altitude)
        {
            Coordinate = coordinate;
            Altitude = altitude;
            URL = "https://www.google.com/maps/@" + Coordinate[0] + "," + Coordinate[1] + "," + Altitude + "m/data=!3m1!1e3";
        }
    }
}
