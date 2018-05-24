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
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.Platform.Core;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using UIKit;
namespace MountainWalker.Touch.Views
{
	[MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public partial class HomeView : BaseViewController<HomeViewModel>
    {
		MapView _mapView;
		bool _isMapInitalized;
		CGRect frameForMap;
		bool _isMapCreated;

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


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();  

			var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            set.Bind(StartButton).To(vm => vm.OpenMainDialogCommand);
			set.Bind(StartButton).For("Title").To(vm => vm.ButtonText).TwoWay();
			set.Bind(PointsLabel).To(vm => vm.PointsInfoText);
			set.Bind(TimeLabel).To(vm => vm.TimeInfoText).TwoWay();
			set.Bind(this).For(v => v.Interaction).To(vm => vm.Interaction).TwoWay();


			set.Bind(_mapView).For(TrailDialogBinding.BindingName).To(vm => vm.OpenTrailDialogCommand);         
            set.Apply();




        }

		public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
		{
			base.ViewWillTransitionToSize(toSize, coordinator);
			//frameForMap = MyMap.Frame;
			//_mapView.Frame = new CGRect(0, 0, frameForMap.Width, frameForMap.Height);
		}

		public override void ViewDidLayoutSubviews()
		{
		    base.ViewDidLayoutSubviews();

            if(_mapView == null)
			{
				var viewModel = this.ViewModel;
				frameForMap = MyMap.Frame;
                if (!_isMapInitalized)
                {
                    _isMapInitalized = true;
                    _mapView = new MapView(new CGRect(0, 0, frameForMap.Width, frameForMap.Height));
                    _mapView.MyLocationEnabled = true;
                    _mapView.Settings.MyLocationButton = true;

                    this.MyMap.AddSubview(_mapView);


                    CreatePointsAndTrails(viewModel.Points, viewModel.Trails);
                    Task.Run(async () =>
                    {
                        await GetCurrentLocation();
                    });
                }
                if (_mapView != null)
                {
                    _mapView.Frame = new CGRect(0, 0, frameForMap.Width, frameForMap.Height);
                }

                var set = this.CreateBindingSet<HomeView, HomeViewModel>();
                set.Bind(_mapView).For(TrailDialogBinding.BindingName).To(vm => vm.OpenTrailDialogCommand);
                set.Apply();
			}

           
		}


		private void ChangeLocationCameraHandler(object sender, MvxValueEventArgs<Point> loc)
        {
            SetCurrentLocation(loc.Value);
        }

		private void SetCurrentLocation(Point location)
        {
            
			var camera = CameraPosition.FromCamera(location.Latitude, location.Longitude, 17);
			var cameraUpdate = CameraUpdate.SetCamera(camera);
            _mapView.MoveCamera(cameraUpdate);
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

            int i = 0;
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

