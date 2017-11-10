
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
            Latitude = latitude;
            Longitude = longitude;
            City = city;
            Date = date;
        }

        public Marker(Marker mark)
        {
            Latitude = mark.Latitude;
            Longitude = mark.Longitude;
            City = mark.City;
            Date = mark.Date;
        }
    }

}
