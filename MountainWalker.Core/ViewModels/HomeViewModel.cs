using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly IMainActivityService _mainService;
        private readonly ISharedPreferencesService _sharedPreferencesService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private MvxSubscriptionToken _token;
        private MvxSubscriptionToken _bottomPanelToken;

        public Point Location { get; set; }
        private PointList _points;
        private ConnectionList _connections;
        public IMvxCommand OpenMainDialogCommand { get; }

        public IMvxCommand LogoutCommand { get; }

        private  string _buttonText = "Start";
        public string ButtonText
        {
            get { return _buttonText; }
            set 
            {
                _buttonText = value; 
                RaisePropertyChanged();
            }
        }

        private string _bottomPanelVisibility = "gone";
        public  string BottomPanelVisibility
        {
            get => _bottomPanelVisibility;
            set => SetProperty(ref _bottomPanelVisibility, value);
        }

        private string _timeInfoText = "0";
        public string TimeInfoText
        {
            get { return _timeInfoText; }
            set 
            {
                _timeInfoText = value;
                RaisePropertyChanged();
            }
        }

        private string _pointsInfoText = "0";
        public string PointsInfoText
        {
            get { return _pointsInfoText; }
            set
            {
                _pointsInfoText = value;
                RaisePropertyChanged();
            }
        }

        public static Point UserPosition;



        public HomeViewModel(ILocationService locationService, IMainActivityService mainService,
            ISharedPreferencesService sharedPreferencesService, IMvxNavigationService navigationService, 
            IMvxMessenger messenger, IDialogService dialogService)
        {
            _mainService = mainService;
            _sharedPreferencesService = sharedPreferencesService;
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            _bottomPanelToken = messenger.Subscribe<BottomPanelMessage>(OnTimerMessage);
            _navigationService = navigationService;
            _dialogService = dialogService;
            _locationService = locationService;

            LogoutCommand = new MvxCommand(Logout);

            _locationService.StartFollow();

            _points = new PointList();
            _connections = new ConnectionList();

            _mainService.SetPointsAndTrials(_points, _connections);

            ButtonText = _locationService.GetDialogButtonText();
            OpenMainDialogCommand = new MvxAsyncCommand(OpenDialog);

        }

        private void OnLocationMessage(LocationMessage message)
        {
            Location = message.Location;
            if (_locationService.GetStateOfJourney())
            {
                _mainService.SetCurrentLocation(Location); //this should be enable after started walking
                foreach (var point in _points.Points)
                {
                    if (_mainService.GetDistanceBetweenTwoPointsOnMapInMeters(Location, point) < 150
                        && _mainService.GetDistanceBetweenTwoPointsOnMapInMeters(
                            _locationService.GetReachedPoints()[_locationService.GetReachedPoints().Count], point) < 150) 
                    {
                        _locationService.AddReachedPoint(point);
                    }
                }
            }
        }

        private void OnTimerMessage(BottomPanelMessage message)
        {
            TimeInfoText = message.TravelTime.ToString();
            PointsInfoText = message.NumberOfReachedPoints.ToString();
            BottomPanelVisibility = message.BottomPanelVisibility;
        }

        //private void StopTrail()
        //{
        //    //timer stop
        //    _isTrailStarted = false;
        //    //new view with reached points
        //    _dialogService.ShowAlert("You've reached" + _reachedPoints.Count + " points", "It's nice, it is?", "Fuck yea");
        //}

        private async Task OpenDialog()
        {
            if(_locationService.GetStateOfJourney())
            {
                await _navigationService.Navigate<AfterStartDialogViewModel>();
            } else 
            {
                await _navigationService.Navigate<DialogViewModel>();
            }
        }

        private void Logout()
        {
            _sharedPreferencesService.CleanSharedPreferences();
            _navigationService.Navigate<SignInViewModel>();
        }
    }
}
