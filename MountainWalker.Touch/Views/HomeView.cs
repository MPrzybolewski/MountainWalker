using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CoreGraphics;
using CoreLocation;
using Foundation;
using Google.Maps;
using MountainWalker.Core.Models;
using MountainWalker.Core.ViewModels;
using MountainWalker.Touch.Bindings;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.XamarinSidebar;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using UIKit;

namespace MountainWalker.Touch.Views
{
    [Register("HomeView")]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public class HomeView : BaseViewController<HomeViewModel>
    {

        MapView _mapView;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var viewModel = this.ViewModel;

            var camera = new CameraPosition();
            _mapView = MapView.FromCamera(CGRect.Empty, camera);
            _mapView.MyLocationEnabled = true;
            _mapView.Settings.MyLocationButton = true;

            View = _mapView;

			CreatePointsAndTrails(viewModel.Points, viewModel.Trails);
            GetCurrentLocation();


            var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            set.Bind(_mapView).For(TrailDialogBinding.BindingName).To(vm => vm.OpenTrailDialogCommand);
            set.Apply();

        }


        public override void ViewWillAppear(bool animated)
        {
            Title = "Home View";
            base.ViewWillAppear(animated);
        }

		public override void LoadView()
		{
			base.LoadView();
		}

        public async Task<Position> GetCurrentLocation()
        {
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 1;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                {
                }

                var available = locator.IsGeolocationAvailable;

                var enabled = locator.IsGeolocationEnabled;
                if (!available || !enabled)
                {
                    
                }


                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

            }
            catch (Exception ex)
            {
                return position;
            }

            if (position == null)
            {
                
            }

            var output = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                position.Timestamp, position.Latitude, position.Longitude,
                position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

            Debug.WriteLine(output);

            var camera = CameraPosition.FromCamera(latitude: position.Latitude,
                                                  longitude: position.Longitude,
                                                  zoom: 17);
            var camera1 = CameraUpdate.SetCamera(camera);
            _mapView.MoveCamera(camera1);
            return position;
        }

        private void CreatePointsAndTrails(List<Point> points, List<Trail> trails)
        {
            foreach (var point in points)
            {
                var marker = new Marker()
                {
                    Title = point.Name,
                    Position = new CLLocationCoordinate2D(point.Latitude, point.Longitude),
                    Map = _mapView
                };
            }

            foreach(var polyline in trails)
            {
                var path = new MutablePath();
                foreach(var point in polyline.Path)
                {
                    path.AddCoordinate(new CLLocationCoordinate2D(point.Latitude, point.Longitude));
                }

                var poly = new Polyline();

                poly.Path = path;
                poly.StrokeWidth = 10;

                if (polyline.Color.Equals("blue"))
                {
                    poly.StrokeColor = UIColor.Blue;
                }
                else if (polyline.Color.Equals("red"))
                {
                    poly.StrokeColor = UIColor.Red;
                }
                else if (polyline.Color.Equals("green"))
                {
                    poly.StrokeColor = UIColor.Green;
                }
                poly.Tappable = true;
                poly.Map = _mapView;

            }
        }
	}
}
