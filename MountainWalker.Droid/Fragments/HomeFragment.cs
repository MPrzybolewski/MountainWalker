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
using Android.Gms.Maps.Model;
using Android.App;
using MountainWalker.Droid.Services;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views;
using Debug = System.Diagnostics.Debug;

namespace MountainWalker.Droid.Fragments
{
    [MvxFragmentPresentationAttribute(activityHostViewModelType:typeof(MainViewModel), addToBackStack:true,fragmentContentId: Resource.Id.frameLayout)]
    [Register("MountainWalker.android.HomeFragment")]
    public class HomeFragment : MvxFragment<HomeViewModel>, IOnMapReadyCallback
    {
        public static GoogleMap Map;
        //private static View _view;

        public async void OnMapReady(GoogleMap map)
        {
            Map = map;
            await ShowUserLocation();

            Map.MyLocationEnabled = true;
            Map.UiSettings.MyLocationButtonEnabled = true;

            Map.AddMarker(new MarkerOptions().SetPosition(new LatLng(54.394121, 18.569394))
                .SetTitle("Best place to go!"));

            DroidMainActivityService.DawajTePunkty();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            /*
            //            if (_view == null)
            //            {
            //                _view = inflater.Inflate(Resource.Layout.HomeView, container, false);
            //                Debug.WriteLine("JESTEEEEM HIHI");
            //            }

            if (BindingContext == null)
            if (_view == null)
            {
                Debug.WriteLine("JESTEEEEM HIHI");
                if (BindingContext == null)
                {
                    BindingContext = new MvxAndroidBindingContext(Activity,
                        new MvxSimpleLayoutInflaterHolder(Activity.LayoutInflater), DataContext);
                }
                _view = this.BindingInflate(Resource.Layout.HomeView, container, false); // jak nie zadziala to wez wrzuc to w tego ifa co wyzej

            }

//            _view = this.BindingInflate(Resource.Layout.HomeView, null);

            */

            //View view = inflater.Inflate(Resource.Layout.HomeView, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);
            View view = this.BindingInflate(Resource.Layout.HomeView, null);
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
