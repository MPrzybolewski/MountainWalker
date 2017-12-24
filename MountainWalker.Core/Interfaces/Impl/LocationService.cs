using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Models;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace MountainWalker.Core.Interfaces.Impl
{
    public class LocationService : ILocationService
    {
        public async Task<double[]> GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            TimeSpan ts = TimeSpan.FromMilliseconds(1000);
            var position = await locator.GetPositionAsync(ts);
            double[] latLong = {position.Latitude, position.Longitude};

            return latLong;
        }

    }
}