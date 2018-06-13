using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using Plugin.Geolocator;
using MountainWalker.Core.Interfaces;
using Plugin.Geolocator.Abstractions;
using Plugin.SecureStorage;
using Newtonsoft.Json;

namespace MountainWalker.Core.Services
{
    public class LocationService : ILocationService
    {
        private readonly IMvxMessenger _messenger;

        public Point CurrentLocation { get; set; }
        public bool IsTrailStarted { get; set; }
        public List<Point> ReachedPoints { get; set; }
        public List<Trail> ReachedTrails { get; set; }
        public int TrailId { get; set; }

        public event EventHandler<LocationEventArgs> CurrentLocationChanged;

        public LocationService(IMvxMessenger messenger)
        {
            CurrentLocation = new Point(0.0, 0.0);
            _messenger = messenger;
            Task.Run(async () => { await StartListening(); }); // async?
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
            ReachedTrails = new List<Trail>();
        }
        
        public bool CheckPointIsNear(Point userLocation, Point pointLocation)
        {
            double distanceBetweenNearestPointAndUserCurrentLocation = GetDistanceBetweenTwoPointsOnMapInMeters(userLocation, pointLocation);
            if(distanceBetweenNearestPointAndUserCurrentLocation < 100)
            {
                return true;
            }
            return false;
        }
        
        public double GetDistanceBetweenTwoPointsOnMapInMeters(Point firstLocation, Point secondLocation)
        {
            int R = 6378137; //Earth's mean radius in meter
            double dLat = ConvertDegreeToRadian(secondLocation.Latitude - firstLocation.Latitude);
            double dLong = ConvertDegreeToRadian(secondLocation.Longitude - firstLocation.Longitude);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) 
                       + Math.Cos(ConvertDegreeToRadian(firstLocation.Latitude)) * Math.Cos(ConvertDegreeToRadian(secondLocation.Latitude))
                                                                                 * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c;
            return d;
        }

        public double ConvertDegreeToRadian(double angle)
        {
            return (Math.PI * angle) / 180.0;
        }
        
        public Point GetNearestPoint(Point userLocation, List<Point> points)
        {
            var minDistanceBettwenPoints = Double.MaxValue;
            var nearestPoint = new Point(0,0);
            foreach(var point in points)
            {
                double distanceBettwenPoints = GetDistanceBetweenTwoPointsOnMapInMeters(userLocation, point);
                Debug.WriteLine("Distance between I and point is - " + distanceBettwenPoints);
                if(minDistanceBettwenPoints > distanceBettwenPoints)
                {
                    minDistanceBettwenPoints = distanceBettwenPoints;
                    nearestPoint = point;
                }
            }
            return nearestPoint;
        }

        public void AddTopsToStorage(int id)
        {
            var tops = CrossSecureStorage.Current.GetValue(CrossSecureStorageKeys.Achievements);
            var achievements = JsonConvert.DeserializeObject<List<Achievement>>(tops);

            achievements[id].IsReached = true;

            var json = JsonConvert.SerializeObject(achievements);
            CrossSecureStorage.Current.SetValue(json, CrossSecureStorageKeys.Achievements);
        }

        public string Distance(double dist)
        {
            var distance = (int) dist;

            if (distance < 1000)
                return distance + " metrów";
            else
            {
                var distKilometers = (double)distance / 1000;
                return distKilometers + " kilometrów";
            }
        }
    }

    public class LocationEventArgs : EventArgs
    {
        public Point Location { get; set; }
    }
}