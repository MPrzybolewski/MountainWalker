using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Droid.Views;
using MvvmCross.Plugins.Messenger;
using Debug = System.Diagnostics.Debug;

namespace MountainWalker.Droid.Services
{
    public class DroidLatLngMapService : ILatLngSetService
    {
        public void SetLatLngButton(double latitude, double longitude)
        {
            Debug.WriteLine("wyslac to do MainView w androidzie");
            LatLng coordinate = new LatLng(latitude, longitude);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            MainView._map.AnimateCamera(yourLocation);
        }
    }
}