
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MountainWalker.Core.Models;
using MountainWalker.Core.ViewModels;
using MountainWalker.Droid.NavigationDrawer;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Core;

namespace MountainWalker.Droid.Fragments
{
    [DrawerLayoutPresentation(typeof(ReachedTrailMapFragment), typeof(MainViewModel), Resource.Id.content_frame, addToBackStack: true,
        IsCacheableFragment = false, AddToBackStack = true)]
    [Register("MountainWalker.android.ReachedTraiMapFragment")]
    public class ReachedTrailMapFragment : BaseFragment<ReachedTrailMapViewModel>, IOnMapReadyCallback
    {
        private GoogleMap _map;
        private Polyline _trail;

        private IMvxInteraction<List<Point>> _interaction;
        public IMvxInteraction<List<Point>> Interaction
        {
            get => _interaction;
            set
            {
                if (_interaction != null)
                    _interaction.Requested -= ShowReachedTrail;

                _interaction = value;
                _interaction.Requested += ShowReachedTrail;
            }
        }

        protected override int FragmentId => Resource.Layout.ReachedTrailMapView;

        public void OnMapReady(GoogleMap map)
        {
            _map = map;
            _map.MyLocationEnabled = false;
            _map.UiSettings.MyLocationButtonEnabled = false;
            _map.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(49.269507, 19.980543), 14));
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            FragmentManager fragmentManager = this.Activity.FragmentManager;

            MapFragment _mapFragment = fragmentManager.FindFragmentByTag("reached") as MapFragment;

            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeTerrain)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = fragmentManager.BeginTransaction();

                _mapFragment = MapFragment.NewInstance(mapOptions);

                fragTx.Add(Resource.Id.reached, _mapFragment, "reached");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);

            var view = base.OnCreateView(inflater, container, savedInstanceState);

            var interact = this.CreateBindingSet<ReachedTrailMapFragment, ReachedTrailMapViewModel>();
            interact.Bind(this).For(v => v.Interaction).To(viewModel => viewModel.Interaction).TwoWay();
            interact.Apply();

            return view;
        }

        private void ShowReachedTrail(object sender, MvxValueEventArgs<List<Point>> trail)
        {
            var points = new List<LatLng>();

            if(_trail != null)
                _trail.Remove();

            _trail = _map.AddPolyline(new PolylineOptions().Clickable(false));
            _trail.Color = Android.Graphics.Color.Blue;

            foreach(var point in trail.Value)
            {
                points.Add(new LatLng(point.Latitude, point.Longitude));
            }

            _trail.Points = points;
            SetCurrentLocation(points[points.Count / 2]);
        }

        private void SetCurrentLocation(LatLng location)
        {
            CameraUpdate trail = CameraUpdateFactory.NewLatLngZoom(location, 14);
            _map.MoveCamera(trail);
        }
    }
}
