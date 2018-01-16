using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using Plugin.Geolocator;
using MountainWalker.Core.Interfaces;
using Plugin.Geolocator.Abstractions;

namespace MountainWalker.Core.Services
{
    public class LocationService : ILocationService
    {
        private readonly IMvxMessenger _messenger;

        public Point CurrentLocation { get; set; }
        public bool IsTrailStarted { get; set; }
        public List<Point> ReachedPoints { get; set; }
        public int TrailId { get; set; }

        //public delegate void EventHandler(object source, LocationEventArgs args);

        public event EventHandler<LocationEventArgs> CurrentLocationChanged;

        public LocationService(IMvxMessenger messenger)
        {
            CurrentLocation = new Point(0.0, 0.0);
            _messenger = messenger;
            StartListening(); // async?
        }

        public void OnCurrentLocationChanged()
        {
            if (CurrentLocationChanged != null)
                CurrentLocationChanged(this, new LocationEventArgs(){ Location = CurrentLocation});
        }
        

        private void OnLocation(object sender, PositionEventArgs e)
        {
            Debug.WriteLine("Zlapalem nowa lokalizacje!");
            var location = e.Position;
            
            CurrentLocation = new Point(location.Latitude, location.Longitude);

            var message = new LocationMessage(this, CurrentLocation);
            _messenger.Publish(message);
        }

        private void OnError(object sender, PositionErrorEventArgs e)
        {
            Debug.WriteLine(e.Error);
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
        
        async Task StartListening()
        {
            if (CrossGeolocator.Current.IsListening)
            {
                return;
            }
	
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 10, true);

            CrossGeolocator.Current.PositionChanged += OnLocation;
            CrossGeolocator.Current.PositionError += OnError;
        }

        public void SetNewList()
        {
            ReachedPoints = new List<Point>();
        }
    }

    public class LocationEventArgs : EventArgs
    {
        public Point Location { get; set; }
    }
}