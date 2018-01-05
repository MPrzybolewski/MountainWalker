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
        private readonly IBottomPanelService _bottomPanelService;

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

        public DialogViewModel(IMainActivityService mainService, ILocationService locationService, IBottomPanelService bottomPanelService) // tutaj ILocationService
        {
            _mainService = mainService;
            _locationService = locationService;
            _bottomPanelService = bottomPanelService;

            var point = _locationService.GetCurrentLocation();
            Debug.WriteLine(point.Latitude + " " + point.Longitude + " - ja jestem tutaj");

            TrailTitle = "Hala Gąsienicowa"; //some function should be here, but idk how i want to do here

            Point test = new Point(54.034424, 19.033050);
            Debug.WriteLine(test.Latitude + " " + test.Longitude + " - a test tutaj");

            //Point Point = new Point(54.090506, 18.790464);

            if (_mainService.CheckPointIsNear(point, test)) // user and point location
            {
                CanStart = true;
                TrailStartCommand = new MvxCommand(StartTrail);
                TrailInfo = "You can start right now!";
            }
            else
            {
                CanStart = false;
                TrailInfo = "You are to far away from any start point";
            }
            NearestPointCommand = new MvxCommand(ShowNearestPoint);
        }

        private void StartTrail()
        {
            _mainService.SetLatLngButton(new Point(54.3956171, 18.5724856)); //mfi
            _locationService.SetNewList();
            _locationService.SetStateOfJourney(true);
            _bottomPanelService.StartTimer();
            _locationService.SetDialogButtonText("Stop");
            _bottomPanelService.SetBottomPanelVisibility("visible");
            _mainService.CloseMainDialog(false);

        }

        private void ShowNearestPoint()
        {
            _mainService.SetLatLngButton(new Point(54.394121, 18.569394)); //best place to go every monday <3
            _mainService.CloseMainDialog(false);
        }
    }
}