namespace MountainWalker.Core.Models
{
    public class Point
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public Point(double lat, double lng)
        {
            Latitude = lat;
            Longitude = lng;
            Description = "";
        }

        public Point(double lat, double lng, string name)
        {
            Latitude = lat;
            Longitude = lng;
            Name = name;
        }

        //public Point(double lat, double lng, string desc, string name)
        //{
        //    Latitude = lat;
        //    Longitude = lng;
        //    Description = desc;
        //    Name = name;
        //}
    }
}