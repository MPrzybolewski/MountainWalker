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
using MountainWalker.Droid.Services;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views;
using Debug = System.Diagnostics.Debug;
using MountainWalker.Droid.NavigationDrawer;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Droid.Fragments
{
    [DrawerLayoutPresentation(typeof(HomeFragment), typeof(MainViewModel), Resource.Id.content_frame, addToBackStack: false)]
    [Register("MountainWalker.android.HomeFragment")]
    public class HomeFragment : BaseFragment<HomeViewModel>, IOnMapReadyCallback
    {
        public static GoogleMap Map;

        public IMvxCommand Command;
        public string Faken { get; set; }

        public async void OnMapReady(GoogleMap map)
        {
            Map = map;
            await ShowUserLocation();

            Map.MyLocationEnabled = true;
            Map.UiSettings.MyLocationButtonEnabled = true;
            Map.AddMarker(new MarkerOptions().SetPosition(new LatLng(54.394121, 18.569394))
                .SetTitle("Best place to go!"));

            DroidMainActivityService.CreatePointsAndTrails();

            Map.PolylineClick += (sender, args) =>
            {
                int id = int.Parse(args.Polyline.Id.Trim(new Char[] { 'p', 'l' }));
                Debug.WriteLine("Id of this polyline is  => " + id);
                Faken = "dawaj";
                //HomeViewModel.RaiseTrailPopup(args.Polyline.Id);
            };
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

            var view = base.OnCreateView(inflater, container, savedInstanceState);

            var set = this.CreateBindingSet<HomeFragment, HomeViewModel>();
            set.Bind(this).For(v => v.Faken).To(vm => vm.OpenTrailDialogCommand);
            set.Apply();

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

        protected override int FragmentId => Resource.Layout.HomeView;        
    }
}
