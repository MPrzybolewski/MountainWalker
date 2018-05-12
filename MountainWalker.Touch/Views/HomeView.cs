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
using MountainWalker.Touch.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.XamarinSidebar;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using UIKit;
namespace MountainWalker.Touch.Views
{
	[MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public partial class HomeView : BaseViewController<HomeViewModel>
    {
		MapView _mapView;
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


        }

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			this.View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            MyMap.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            var viewModel = this.ViewModel;
            var frameForMap = MyMap.Frame;

            var camera = new CameraPosition();
            ////_mapView = MapView.FromCamera(MyMap.Bounds, camera);
            //_mapView = new MapView(MyMap.Bounds);
            _mapView = new MapView(new CGRect(0, 0, frameForMap.Width, frameForMap.Height));
            _mapView.MyLocationEnabled = true;
            _mapView.Settings.MyLocationButton = true;


            //_mapView.Center = this.MyMap.Center;
            //_mapView.Frame = this.MyMap.Frame;
            //_mapView.Bounds = this.MyMap.Bounds;
            this.MyMap.AddSubview(_mapView);


            CreatePointsAndTrails(viewModel.Points, viewModel.Trails);
            Task.Run(async () =>
            {
                await GetCurrentLocation();
            });
            //var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            //set.Bind(_mapView).For(TrailDialogBinding.BindingName).To(vm => vm.OpenTrailDialogCommand);
            //set.Apply();
		}


		public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
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

            int i = 1;
            foreach (var polyline in trails)
            {
                var path = new MutablePath();
                foreach (var point in polyline.Path)
                {
                    path.AddCoordinate(new CLLocationCoordinate2D(point.Latitude, point.Longitude));
                }

                var poly = new PolylineWithId();

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
                poly.Id = i;
                i++;
                poly.Map = _mapView;

            }
        }
       
    }
}

