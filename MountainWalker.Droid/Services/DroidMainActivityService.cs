﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using MountainWalker.Core;
using MountainWalker.Core.Interfaces;
using MountainWalker.Droid.Fragments;
using Debug = System.Diagnostics.Debug;
using DialogFragment = MountainWalker.Droid.Fragments.DialogFragment;
using Point = MountainWalker.Core.Models.Point;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Android.Content;

namespace MountainWalker.Droid.Services
{
    public class DroidMainActivityService : IMainActivityService
    {
        private static PointList _pointList;
        private static ConnectionList _trails;

        public void SetLatLngButton(Point location)
        {
            LatLng coordinate = new LatLng(location.Latitude, location.Longitude);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            HomeFragment.Map.AnimateCamera(yourLocation);
        }

        public void SetCurrentLocation(Point location)
        {
            if (HomeFragment.Map != null)
            {
                LatLng coordinate = new LatLng(location.Latitude, location.Longitude);
                CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
                HomeFragment.Map.AnimateCamera(yourLocation);
            }
        }

        public void CloseMainDialog()
        {
            DialogFragment.dialog.Dismiss();
        }

        public void SendNotification(string title, string content)
        {

            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            Notification.Builder builder = new Notification.Builder(act)
                .SetContentTitle(title)
                .SetContentText(content)
                .SetDefaults(NotificationDefaults.All)
                .SetSmallIcon(Resource.Drawable.SignInViewBackground);

            Notification notification = builder.Build();

            NotificationManager notificationManager =
                act.GetSystemService(Context.NotificationService) as NotificationManager;

            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }

        public bool CheckPointIsNear(Point userLocation, Point pointLocation)
        {
            double distanceBetweenNearestPointAndUserCurrentLocation = GetDistanceBetweenTwoPointsOnMapInMeters(userLocation, pointLocation);
            Debug.WriteLine("Odelglosc: {0}",distanceBetweenNearestPointAndUserCurrentLocation);
            if(distanceBetweenNearestPointAndUserCurrentLocation < 50)
            {
                return true;
            }
            return false;
        }

        public double GetDistanceBetweenTwoPointsOnMapInMeters(Point firstLocation, Point secondLocation)
        {
            if (secondLocation==null)
            {
                return 1000000;
            }
            Debug.WriteLine("Uzytkownik: {0} , {1}", firstLocation.Latitude, firstLocation.Longitude);
            Debug.WriteLine("Punkt: {0} , {1}", secondLocation.Latitude, secondLocation.Longitude);
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

        public static void CreatePointsAndTrails()
        {
            foreach (var point in _pointList.Points)
            {
                HomeFragment.Map.AddMarker(new MarkerOptions()
                    .SetPosition(new LatLng(point.Latitude, point.Longitude))
                    .SetTitle(point.Description));
            }

            foreach (var polyline in _trails.Connections)
            {
                var latlng = new List<LatLng>();
                foreach (var point in polyline.Path)
                {
                    latlng.Add(new LatLng(point.Latitude, point.Longitude));
                }

                var poly = HomeFragment.Map.AddPolyline(new PolylineOptions().Clickable(true));

                if (polyline.Color.Equals("blue"))
                {
                    poly.Color = Color.Blue;
                }
                else if (polyline.Color.Equals("red"))
                {
                    poly.Color = Color.Red;
                }
                else if (polyline.Color.Equals("green"))
                {
                    poly.Color = Color.Green;
                }
                poly.Width = 10;
                poly.Points = latlng;
            }
        }

        public void SetPointsAndTrials(PointList points, ConnectionList connections)
        {
            _pointList = points;
            _trails = connections;
        }
    }
}