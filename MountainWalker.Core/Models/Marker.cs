
namespace MountainWalker.Core.Models
{
    public class Marker
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        public string Date { get; set; }

        public Marker(double latitude, double longitude, string city, string date)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.City = city;
            this.Date = date;
        }
    }

}
