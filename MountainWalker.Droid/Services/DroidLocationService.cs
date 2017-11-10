using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.App;
using Android.Locations;
using MountainWalker.Core.Models;
using Plugin.Geolocator;
using Java.IO;
using MountainWalker.Core.Interfaces;

namespace MountainWalker.Droid.Services
{
    public class DroidLocationService : ILocationService
    {
        public async Task<Marker> GetLocation()
        {
            string city = "";
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            TimeSpan ts = TimeSpan.FromMilliseconds(1000);
            var position = await locator.GetPositionAsync(ts);


            Geocoder gcd = new Geocoder(Application.Context);
            List<Address> addresses;
            try
            {
                addresses = new List<Address>(gcd.GetFromLocation(position.Latitude, position.Longitude, 1));
                if (addresses.Count > 0)
                {
                    Debug.WriteLine("Position Latitude: {0}", position.Latitude);
                    Debug.WriteLine("Position Longitude: {0}", position.Longitude);
                    Debug.WriteLine("Position Status: {0}", position.Timestamp);
                    Debug.WriteLine(addresses[0].Locality);
                    Debug.WriteLine(addresses[0].FeatureName);
                    city = addresses[0].Locality;
                }
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }
            return new Marker(position.Latitude, position.Longitude, city, "tera");
            //return null;
        }

        public void Test()
        {
            Debug.WriteLine("a to dziala?");
        }
        

    }
}
