using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Locations;
using MountainWalker.Core.Models;
using Plugin.Geolocator;
using Console = System.Console;
using Java.IO;

namespace MountainWalker.Droid.Services
{
    class DroidLocationService : ILocationActivity
    {
        public DroidLocationService()
        {
        }

        public async Task<Marker> GetLocation()
        {
            string city = "";
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            TimeSpan ts = TimeSpan.FromMilliseconds(100);
            var position = await locator.GetPositionAsync(ts);

            Console.WriteLine("Position Status: {0}", position.Timestamp);
            Console.WriteLine("Position Latitude: {0}", position.Latitude);
            Console.WriteLine("Position Longitude: {0}", position.Longitude);

            Geocoder gcd = new Geocoder(Application.Context);
            List<Address> addresses;
            try
            {
                addresses = new List<Address>(gcd.GetFromLocation(position.Latitude, position.Longitude, 1));
                if (addresses.Count > 0)
                {
                    Console.WriteLine(addresses[0].Locality);
                    Console.WriteLine(addresses[0].FeatureName);
                }
                city = addresses[0].Locality;
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }
            return new Marker(position.Latitude, position.Longitude, city, "tera");
        }
        

    }
}
