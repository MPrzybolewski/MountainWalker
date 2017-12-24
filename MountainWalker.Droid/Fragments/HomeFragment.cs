using System;
using System.Threading.Tasks;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MountainWalker.Core.ViewModels;
using Plugin.Geolocator;
using Android.Gms.Maps.Model;
using Android.App;
using MountainWalker.Droid.NavigationDrawer;

namespace MountainWalker.Droid.Fragments
{
    [DrawerLayoutPresentation(typeof(HomeFragment), typeof(MainViewModel), Resource.Id.content_frame, addToBackStack: false)]
    [Register("MountainWalker.android.HomeFragment")]
    public class HomeFragment : BaseFragment<HomeViewModel>, IOnMapReadyCallback
    {
        public static GoogleMap Map;

        public async void OnMapReady(GoogleMap map)
        {
            Map = map;
            await ShowUserLocation();

            Map.MyLocationEnabled = true;
            Map.UiSettings.MyLocationButtonEnabled = true;
            Map.AddMarker(new MarkerOptions().SetPosition(new LatLng(54.394121, 18.569394))
                .SetTitle("Best place to go!"));
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            ShowHamburgerMenu = true;

            FragmentManager fragmentManager = this.Activity.FragmentManager;

            MapFragment _mapFragment = fragmentManager.FindFragmentByTag("map") as MapFragment;

            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeTerrain)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = fragmentManager.BeginTransaction();

                _mapFragment = MapFragment.NewInstance(mapOptions);

                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);

            return base.OnCreateView(inflater, container, savedInstanceState);
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

        protected override int FragmentId => Resource.Layout.HomeView;
    }
}
