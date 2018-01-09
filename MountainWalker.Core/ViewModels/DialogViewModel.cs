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
        private readonly IMainActivityService _mainService;
        private readonly ILocationService _locationService;
        private readonly ITravelPanelService _travelPanelService;
        private readonly IStartButtonService _startButtonService;

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

        public DialogViewModel(IMainActivityService mainService, ILocationService locationService,
                               ITravelPanelService travelPanelService, IStartButtonService startButtonService) // tutaj ILocationService
        {
            _mainService = mainService;
            _locationService = locationService;
            _travelPanelService = travelPanelService;
            _startButtonService = startButtonService;

            var point = _locationService.CurrentLocation;
            if (point == null)
            {
                point.Latitude = 0.0;
                point.Longitude = 0.0;
            }

            TrailTitle = "Hala Gąsienicowa"; //some function should be here, but idk how i want to do here

            Point test = new Point(54.090426, 18.790808);

            if (_mainService.CheckPointIsNear(point, test)) // user and point location
            {
                CanStart = true;
                TrailStartCommand = new MvxCommand(StartTrail);
                TrailInfo = "Możesz rozpocząć swoją wędrówkę!";
            }
            else
            {
                CanStart = false;
                TrailInfo = "Jesteś zbyt oddalony od najbliższego punktu!";
            }
            NearestPointCommand = new MvxCommand(ShowNearestPoint);
        }

        private void StartTrail()
        {
            _mainService.SetLatLngButton(new Point(54.3956171, 18.5724856)); //mfi
            _locationService.SetNewList();
            _locationService.IsTrailStarted = true;

            _travelPanelService.StartTimer();
            _startButtonService.SetStartButtonText("Stop");
            _travelPanelService.SetTravelPanelVisibility("visible");
            _mainService.CloseMainDialog(false);

        }

        private void ShowNearestPoint()
        {
            _mainService.SetLatLngButton(new Point(54.394121, 18.569394)); //best place to go every monday <3
            _mainService.CloseMainDialog(false);
        }
    }
}