using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MountainWalker.Core.ViewModels;
using Plugin.Geolocator;
using Android.Gms.Maps.Model;
using Android.App;
using Android.Graphics;
using MountainWalker.Droid.Bindings;
using MountainWalker.Droid.NavigationDrawer;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MountainWalker.Core.Models;
using MvvmCross.Platform.Core;
using Point = MountainWalker.Core.Models.Point;

namespace MountainWalker.Droid.Fragments
{
    [DrawerLayoutPresentation(typeof(HomeFragment), typeof(MainViewModel), Resource.Id.content_frame, addToBackStack: true,
        IsCacheableFragment = true, AddToBackStack = true)]
    [Register("MountainWalker.android.HomeFragment")]
    public class HomeFragment : BaseFragment<HomeViewModel>, IOnMapReadyCallback
    {
        private GoogleMap _map;

        private IMvxInteraction<Point> _interaction;
        public IMvxInteraction<Point> Interaction
        {
            get => _interaction;
            set
            {
                if (_interaction != null)
                    _interaction.Requested -= ChangeLocationCameraHandler;
            
                _interaction = value;
                _interaction.Requested += ChangeLocationCameraHandler;
            }
        }

        public async void OnMapReady(GoogleMap map)
        {
            _map = map;
            _map.MyLocationEnabled = true;
            _map.UiSettings.MyLocationButtonEnabled = true;
            //_map.AddMarker(new MarkerOptions().SetPosition(new LatLng(54.394121, 18.569394))
            //    .SetTitle("Best place to go!"));

            var home = (HomeViewModel) ViewModel;
            
            CreatePointsAndTrails(home.Points, home.Trails);
            
            var set = this.CreateBindingSet<HomeFragment, HomeViewModel>();
            set.Bind(_map).For(TrailDialogBinding.BindingName).To(vm => vm.OpenTrailDialogCommand);
            set.Apply();
            
            await ShowUserLocation();
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
            
            var interact = this.CreateBindingSet<HomeFragment, HomeViewModel>();
            interact.Bind(this).For(v => v.Interaction).To(viewModel => viewModel.Interaction).TwoWay();
            interact.Apply();
            
            return view;
        }

        public async Task ShowUserLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            TimeSpan ts = TimeSpan.FromMilliseconds(1000);
            var pos = await locator.GetPositionAsync(ts);

            SetCurrentLocation(new Point(pos.Latitude, pos.Longitude));
        }

        private void SetCurrentLocation(Point location)
        {
            LatLng coordinate = new LatLng(location.Latitude, location.Longitude);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            _map.AnimateCamera(yourLocation);
        }

        private void ChangeLocationCameraHandler(object sender, MvxValueEventArgs<Point> loc)
        {
            SetCurrentLocation(loc.Value);
        }

        protected override int FragmentId => Resource.Layout.HomeView;        
        
        private void CreatePointsAndTrails(List<Point> points, List<Trail> trails)
        {
            foreach (var point in points)
            {
                //_map.AddMarker(new MarkerOptions()
                    //.SetPosition(new LatLng(point.Latitude, point.Longitude))
                               //.SetTitle(point.Name));
                    //.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.point));
            }

            foreach (var polyline in trails)
            {
                var latlng = new List<LatLng>();
                foreach (var point in polyline.Path)
                {
                    latlng.Add(new LatLng(point.Latitude, point.Longitude));
                }
                
                var poly = _map.AddPolyline(new PolylineOptions().Clickable(true));

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
                    poly.Color = Color.Rgb(32, 178, 0);
                }
                else if (polyline.Color.Equals("yellow"))
                {
                    poly.Color = Color.Yellow;
                }
                poly.Width = 10;

                poly.Points = latlng;
                
            }
        }
    }
}
