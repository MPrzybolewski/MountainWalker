using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Interfaces.Impl;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class DialogViewModel : MvxViewModel
    {
        private readonly IMainActivityService _mainService;
        private readonly ILocationService _locationService;

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

        public DialogViewModel(IMainActivityService mainService, ILocationService locationService )
        {
            _mainService = mainService;
            _locationService = locationService;



            TrailTitle = "Hala Gąsienicowa"; //some function should be here, but idk how i want to do this
            double[] userPosition = HomeViewModel.UserPosition;


            if (_mainService.CheckPointIsNear(userPosition[0],userPosition[1],54.034448, 19.033126)) // user and point location
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
            _mainService.SendNotification();
            _mainService.SetLatLngButton(54.3956171, 18.5724856); //mfi
            _mainService.CloseMainDialog();
        }

        private void ShowNearestPoint()
        {
            _mainService.SetLatLngButton(54.394121, 18.569394); //best place to go every monday <3
            _mainService.CloseMainDialog();
        }
    }
}