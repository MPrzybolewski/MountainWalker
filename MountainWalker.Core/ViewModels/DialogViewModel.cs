using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Interfaces.Impl;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.ViewModels
{
    public class DialogViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly ITravelPanelService _travelPanelService;
        private readonly IStartButtonService _startButtonService;
        private readonly ITrailService _trailService;
        
        private readonly MvxInteraction<bool> _visible = new MvxInteraction<bool>();
        public IMvxInteraction<bool> Interaction => _visible;

        public IMvxCommand TrailStartCommand { get; }
        public IMvxCommand NearestPointCommand { get; }

        private string _trialTitle = "";
        public string TrailTitle
        {
            get { return _trialTitle; }
            set
            {
                _trialTitle = value;
                RaisePropertyChanged();
            }
        }

        private string _trialInfo = "";
        public string TrailInfo
        {
            get { return _trialInfo; }
            set
            {
                _trialInfo = value;
                RaisePropertyChanged();
            }
        }

        private bool _canStart;

        public bool CanStart
        {
            get { return _canStart; }
            set
            {
                _canStart = value;
                RaisePropertyChanged();
            }
        }

        public DialogViewModel(ILocationService locationService, ITravelPanelService travelPanelService, 
            IStartButtonService startButtonService, ITrailService trailService)
        {
            _visible.Raise(true);
            _locationService = locationService;
            _travelPanelService = travelPanelService;
            _startButtonService = startButtonService;
            _trailService = trailService;

            var currentLocation = _locationService.CurrentLocation;


            var nearestPoint = _locationService.GetNearestPoint(currentLocation, _trailService.Points);

            if (_locationService.CheckPointIsNear(currentLocation, nearestPoint)) // user and point location
            {
                CanStart = true;
                TrailStartCommand = new MvxCommand(StartTrail);
                TrailTitle = "MOŻNA"; // here name of point
                TrailInfo = "Możesz rozpocząć swoją wędrówkę!";
            }
            else
            {
                var distance = _locationService.GetDistanceBetweenTwoPointsOnMapInMeters(currentLocation, nearestPoint);
                CanStart = false;
                TrailTitle = "NIE MOŻNA"; //some function should be here, but idk how i want to do here
                TrailInfo = "Najbliższy punkt to " + nearestPoint.Name + " oddalony o " + _locationService.Distance(distance); // name of nearest point
            }
            NearestPointCommand = new MvxCommand(ShowNearestPoint);
        }

        private void StartTrail()
        {
            _locationService.OnCurrentLocationChanged(_locationService.GetNearestPoint(
                _locationService.CurrentLocation, _trailService.Points));
            _locationService.SetNewList();
            _locationService.IsTrailStarted = true;

            _travelPanelService.StartTimer();
            _startButtonService.SetStartButtonText("Stop");
            _travelPanelService.TravelPanelVisibility = "visible";
            _visible.Raise(false);
        }

        private void ShowNearestPoint()
        {
            _locationService.OnCurrentLocationChanged(_locationService.GetNearestPoint(
            _locationService.CurrentLocation, _trailService.Points));
            _visible.Raise(false);
        }
    }
}