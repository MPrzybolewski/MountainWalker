using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Java.IO;
using MountainWalker.Core.Models;
using MountainWalker.Core.ViewModels;
using Plugin.Geolocator;
using Console = System.Console;


namespace MountainWalker.Droid.Source
{
    class DroidLocation : ILocationActivity
    {
        public DroidLocation()
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