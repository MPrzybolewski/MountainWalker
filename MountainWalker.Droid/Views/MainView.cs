using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using MountainWalker.Core.Interfaces;
using MvvmCross.Droid.Views;
using Plugin.Geolocator;
using System;
using System.Threading.Tasks;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Support.V7.Widget;
using MountainWalker.Core.ViewModels;
using MountainWalker.Droid.Services;
using Debug = System.Diagnostics.Debug;

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "View for MainViewModel", NoHistory = true)]
    public class MainView : MvxAppCompatActivity<MainViewModel>, IOnMapReadyCallback
    {
        public static GoogleMap _map;

        public async void OnMapReady(GoogleMap map)
        {
            _map = map;
            await ShowUserLocation();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            MapFragment _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeTerrain)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);

            var toolbar = FindViewById<Toolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Mountain Walker";
        }

        public async Task ShowUserLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            TimeSpan ts = TimeSpan.FromMilliseconds(1000);
            var position = await locator.GetPositionAsync(ts);

            UpdateCamera(position.Latitude, position.Longitude);
        }

        public void UpdateCamera(double lat, double lng)
        {
            LatLng coordinate = new LatLng(lat, lng);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            _map.AnimateCamera(yourLocation);
        }
    }
}
