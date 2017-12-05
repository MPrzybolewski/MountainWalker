using System;
using System.Threading.Tasks;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MountainWalker.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views.Attributes;
using Plugin.Geolocator;
using MountainWalker.Droid.Views;
using Android.Gms.Maps.Model;
using Android.App;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views;
using System.Diagnostics;

namespace MountainWalker.Droid.Fragments
{
    [MvxFragmentPresentationAttribute(typeof(MainViewModel), Resource.Id.frameLayout)]
    [Register("MountainWalker.android.HomeFragment")]
    public class HomeFragment : MvxFragment<HomeViewModel>, IOnMapReadyCallback
    {
        public static GoogleMap Map;

        public async void OnMapReady(GoogleMap map)
        {
            Map = map;
            await ShowUserLocation();

            Map.MyLocationEnabled = true;
            Map.UiSettings.MyLocationButtonEnabled = true;

        }


        private static View view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (view == null)
            {
                view = inflater.Inflate(Resource.Layout.HomeView, container, false);
            }



            FragmentManager fragmentManager = this.Activity.FragmentManager;

            MapFragment _mapFragment = fragmentManager.FindFragmentByTag("map") as MapFragment;

            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeTerrain)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = fragmentManager.BeginTransaction();
                _mapFragment =MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);


            return view;
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
            Map.MoveCamera(yourLocation);
        }


    }
}
