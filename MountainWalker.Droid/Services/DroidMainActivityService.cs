﻿using System;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MountainWalker.Core.Interfaces;
using MountainWalker.Droid.Fragments;
using MountainWalker.Droid.Views;
using Debug = System.Diagnostics.Debug;
using DialogFragment = MountainWalker.Droid.Fragments.DialogFragment;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Android.Content;

namespace MountainWalker.Droid.Services
{
    public class DroidMainActivityService : IMainActivityService
    {
        public void SetLatLngButton(double latitude, double longitude)
        {
            LatLng coordinate = new LatLng(latitude, longitude);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            HomeFragment.Map.AnimateCamera(yourLocation);
        }

        public void SetCurrentLocation(double latitude, double longitude)
        {
            LatLng coordinate = new LatLng(latitude, longitude);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            HomeFragment.Map.AnimateCamera(yourLocation);
        }

        public void SendNotification()
        {

            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            Notification.Builder builder = new Notification.Builder(act)
                .SetContentTitle("Congrats user!")
                .SetContentText("You started a trail!")
                .SetDefaults(NotificationDefaults.All)
                .SetSmallIcon(Resource.Drawable.SignInViewBackground);

            Notification notification = builder.Build();

            NotificationManager notificationManager =
                act.GetSystemService(Context.NotificationService) as NotificationManager;

            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }

        public void CloseMainDialog()
        {
            DialogFragment.dialog.Dismiss();
        }

        public bool CheckPointIsNear(double userLatitude, double userLongitude, double pointLatitude, double pointLongitude )
        {
            double distanceBetweenNearestPointAndUserCurrentLocation = GetDistanceBetweenTwoPointsOnMapInMeters(userLatitude, userLongitude, pointLatitude, pointLongitude);
            Debug.WriteLine("Odelglosc: {0}",distanceBetweenNearestPointAndUserCurrentLocation);
            if(distanceBetweenNearestPointAndUserCurrentLocation < 50)
            {
                return true;
            }
            return false;
        }

        public double GetDistanceBetweenTwoPointsOnMapInMeters(double firstPointLatitude, double firstPointLongitude, double secondPointLatitude, double secondPointLongitude)
        {
            Debug.WriteLine("Uzytkownik: {0} , {1}");
            Debug.WriteLine("Punkt: {0} , {1}");
            int R = 6378137; //Earth's mean radius in meter
            double dLat = ConvertDegreeToRadian(secondPointLatitude - firstPointLatitude);
            double dLong = ConvertDegreeToRadian(secondPointLongitude - firstPointLongitude);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) 
                           + Math.Cos(ConvertDegreeToRadian(firstPointLatitude)) * Math.Cos(ConvertDegreeToRadian(secondPointLatitude))
                           * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c;
            return d;
        }

        public double ConvertDegreeToRadian(double angle)
        {
            return (Math.PI * angle) / 180.0;
        }
    }
}