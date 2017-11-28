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
using Android.Support.V7.App;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using MountainWalker.Droid.Fragments;
using Fragment = Android.Support.V4.App.Fragment;

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "View for MainViewModel", NoHistory = true)]
    public class MainView : MvxAppCompatActivity<MainViewModel>, IOnMapReadyCallback
    {
        private GoogleMap _map;
        Fragment[] _fragments = { new MyListFragment(), new MySettingsFragment() };
        string[] _titles = { "My list", "My settings" };
        ActionBarDrawerToggle _drawerToggle;
        ListView _drawerListView;
        DrawerLayout _drawerLayout;

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


            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Mountain Walker";

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            _drawerListView = FindViewById<ListView>(Resource.Id.drawerListView);
            _drawerListView.ItemClick += (sender, e) => ShowFragmentAt(e.Position);
            _drawerListView.Adapter = new ArrayAdapter<string>(this, global::Android.Resource.Layout.SimpleListItem1,_titles);

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

            _drawerToggle = new ActionBarDrawerToggle(this, _drawerLayout, Resource.String.OpenDrawerString, Resource.String.CloseDrawerString);

            _drawerLayout.SetDrawerListener(_drawerToggle);

            ShowFragmentAt(0);

        }

        void ShowFragmentAt(int position)
        {
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _fragments[position]).Commit();
 
            Title = _titles [position];
 
            _drawerLayout.CloseDrawer (_drawerListView);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            _drawerToggle.SyncState();

            base.OnPostCreate(savedInstanceState);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (_drawerToggle.OnOptionsItemSelected(item))
                return true;

            return base.OnOptionsItemSelected(item);
        }

        public async Task ShowUserLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            TimeSpan ts = TimeSpan.FromMilliseconds(1000);
            var position = await locator.GetPositionAsync(ts);

            LatLng coordinate = new LatLng(position.Latitude, position.Longitude);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            _map.AnimateCamera(yourLocation);
        }
    }
}
