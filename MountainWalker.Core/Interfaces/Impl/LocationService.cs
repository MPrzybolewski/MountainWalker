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
    public class DroidLocationService : ILocationService
    {
        private string _position = "";

        private void OnPositionChanged(object sender, PositionEventArgs e)
        {
            _position = e.Position.Latitude + " " + e.Position.Longitude;
        }

        public async Task<string> GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            TimeSpan ts = TimeSpan.FromMilliseconds(1000);
            var position = await locator.GetPositionAsync(ts);

            return position.Latitude + " " + position.Longitude;
        }

    }
}