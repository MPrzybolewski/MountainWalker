using System;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MountainWalker.Core;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Models;
using MountainWalker.Droid.Fragments;
using MountainWalker.Droid.Views;
using Debug = System.Diagnostics.Debug;
using DialogFragment = MountainWalker.Droid.Fragments.DialogFragment;

namespace MountainWalker.Droid.Services
{
    public class DroidMainActivityService : IMainActivityService
    {
        public static PointList pointList;

        public void SetLatLngButton(Point location)
        {
            LatLng coordinate = new LatLng(location.Latitude, location.Longitude);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            HomeFragment.Map.AnimateCamera(yourLocation);
        }

        public void SetCurrentLocation(Point location)
        {
            LatLng coordinate = new LatLng(location.Latitude, location.Longitude);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            HomeFragment.Map.AnimateCamera(yourLocation);
        }

        public void CloseMainDialog()
        {
            DialogFragment.dialog.Dismiss();
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

        public static void DawajTePunkty()
        {
            foreach (var point in pointList.Points)
            {
                HomeFragment.Map.AddMarker(new MarkerOptions()
                    .SetPosition(new LatLng(point.Latitude, point.Longitude))
                    .SetTitle(point.Description));
            }
        }

        public void SetPoints(PointList points)
        {
            pointList = points;
        }
    }
}