using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using Newtonsoft.Json.Bson;
using Plugin.Geolocator;

namespace MountainWalker.Core.Interfaces.Impl
{
    public class LocationService : ILocationService
    {
        private readonly IMvxLocationWatcher _watcher;
        private readonly IMvxMessenger _messenger;
        public Point CurrentLocation { get; set; }
        public bool IsTrailStarted { get; set; }
        public List<Point> ReachedPoints { get; set; }
        public int TrailId { get; set; }


        public LocationService(IMvxLocationWatcher watcher, IMvxMessenger messenger)
        {
            _watcher = watcher;
            _messenger = messenger;
        }

        private void OnLocation(MvxGeoLocation location)
        {
            CurrentLocation = new Point(location.Coordinates.Latitude, location.Coordinates.Longitude);

            var message = new LocationMessage(this, CurrentLocation);
            _messenger.Publish(message);
        }
        
        public void StartFollow()
        {
            _watcher.Start(new MvxLocationOptions(), OnLocation, OnError);
        }

        private void OnError(MvxLocationError error)
        {
            Mvx.Error("Seen location error {0}", error.Code);
        }

        public async Task<Point> GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            TimeSpan ts = TimeSpan.FromMilliseconds(1000);
            var position = await locator.GetPositionAsync(ts);
            Point location = new Point(position.Latitude, position.Longitude);

            return location;
        }

        public void SetNewList()
        {
            ReachedPoints = new List<Point>();
        }
    }
}