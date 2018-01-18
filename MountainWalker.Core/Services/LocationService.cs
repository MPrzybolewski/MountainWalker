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

        public event EventHandler<LocationEventArgs> CurrentLocationChanged;

        public LocationService(IMvxMessenger messenger)
        {
            CurrentLocation = new Point(0.0, 0.0);
            _messenger = messenger;
            StartListening(); // async?
        }
        
        async Task StartListening()
        {
            if (CrossGeolocator.Current.IsListening)
                return;
	
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(3), 5, true);

            CrossGeolocator.Current.PositionChanged += OnLocation;
            CrossGeolocator.Current.PositionError += OnError;
        }

        public void OnCurrentLocationChanged(Point loc)
        {
            if (CurrentLocationChanged != null)
                CurrentLocationChanged(this, new LocationEventArgs(){ Location = loc});
        }

        private void OnLocation(object sender, PositionEventArgs e)
        {
            var location = e.Position;
            
            CurrentLocation = new Point(location.Latitude, location.Longitude);

            var message = new LocationMessage(this, CurrentLocation);
            _messenger.Publish(message);
        }

        private void OnError(object sender, PositionErrorEventArgs e)
        {
            Debug.WriteLine(e.Error);
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