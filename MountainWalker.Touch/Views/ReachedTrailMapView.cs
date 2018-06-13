using System;
using System.Collections.Generic;
using CoreGraphics;
using CoreLocation;
using Google.Maps;
using MountainWalker.Core.Models;
using MountainWalker.Core.ViewModels;
using MountainWalker.Touch.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.Platform.Core;
using UIKit;

namespace MountainWalker.Touch.Views
{
	[MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public partial class ReachedTrailMapView : BaseViewController<ReachedTrailMapViewModel>
    {
		MapView _mapView;
        bool _isMapInitalized;
        CGRect frameForMap;
		private PolylineWithId _trail;

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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
			var interact = this.CreateBindingSet<ReachedTrailMapView, ReachedTrailMapViewModel>();
            interact.Bind(this).For(v => v.Interaction).To(viewModel => viewModel.Interaction).TwoWay();

			interact.Bind(TimeText).To(vm => vm.ReachedTrail.Time);
			interact.Bind(StartText).To(vm => vm.ReachedTrail.StartTime);
			interact.Bind(KmText).To(vm => vm.ReachedTrail.Distance);
            interact.Bind(StopText).To(vm => vm.ReachedTrail.EndTime);
			interact.Bind(BeginText).To(vm => vm.ReachedTrail.From);
			interact.Bind(FinishedText).To(vm => vm.ReachedTrail.To);
                                     

            interact.Apply();
        }

		public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (_mapView == null)
            {
				
                var viewModel = this.ViewModel;
                frameForMap = MyMap.Frame;
                if (!_isMapInitalized)
                {
                    _isMapInitalized = true;
                    _mapView = new MapView(new CGRect(0, 0, frameForMap.Width, frameForMap.Height));
                    _mapView.MyLocationEnabled = true;
                    _mapView.Settings.MyLocationButton = true;
					_mapView.MapType = MapViewType.Terrain;

                    this.MyMap.AddSubview(_mapView);
                }
                if (_mapView != null)
                {
                    _mapView.Frame = new CGRect(0, 0, frameForMap.Width, frameForMap.Height);
                }
            }
        }

		private void ShowReachedTrail(object sender, MvxValueEventArgs<List<Point>> trail)
        {   
			var points = new List<Point>();

				_trail = new PolylineWithId();


			_trail.Map = _mapView;
			_trail.Tappable = false;

			_trail.StrokeColor = UIColor.Blue;

			var path = new MutablePath();
            foreach (var point in trail.Value)
            {
				path.AddCoordinate(new CLLocationCoordinate2D(point.Latitude, point.Longitude));
				points.Add(new Point(point.Latitude, point.Longitude));
            }

			_trail.Path = path;
			SetCurrentLocation(points[points.Count / 2]);
        }

        private void SetCurrentLocation(Point location)
        {
			var camera = CameraPosition.FromCamera(latitude: location.Latitude,
			                                       longitude: location.Longitude,
                                                 zoom: 15);
            var camera1 = CameraUpdate.SetCamera(camera);
            _mapView.MoveCamera(camera1);
        }
    }
}

