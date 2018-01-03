namespace MountainWalker.Core.Models
{
    public class Point
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }

        public Point(double lat, double lng)
        {
            Latitude = lat;
            Longitude = lng;
            Description = "";
        }

        public Point(double lat, double lng, string desc)
        {
            Latitude = lat;
            Longitude = lng;
            Description = desc;
        }
    }
}