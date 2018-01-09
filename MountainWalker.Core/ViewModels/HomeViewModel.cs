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
        private readonly ITravelPanelService _travelPanelService;
        private readonly IStartButtonService _startButtonService;

        private MvxSubscriptionToken _token;
        private MvxSubscriptionToken _travelPanelToken;
        private MvxSubscriptionToken _startButtonToken;

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

        private string _travelPanelVisibility = "gone";
        public  string TravelPanelVisibility
        {
            get => _travelPanelVisibility;
            set => SetProperty(ref _travelPanelVisibility, value);
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
            IMvxMessenger messenger, IDialogService dialogService, ITravelPanelService travelPanelService,
                            IStartButtonService startButtonService)
        {
            _mainService = mainService;
            _sharedPreferencesService = sharedPreferencesService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _locationService = locationService;
            _travelPanelService = travelPanelService;
            _startButtonService = startButtonService;

            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            _travelPanelToken = messenger.Subscribe<TravelPanelMessage>(OnTimerMessage);
            _startButtonToken = messenger.Subscribe<StartButtonMessage>(OnStartButtonMessage);

            LogoutCommand = new MvxCommand(Logout);

            _locationService.StartFollow();

            _points = new PointList();
            _connections = new ConnectionList();

            _mainService.SetPointsAndTrials(_points, _connections);

            OpenMainDialogCommand = new MvxAsyncCommand(OpenDialog);

            SetLayoutProperties();

        }

        void SetLayoutProperties()
        {
            ButtonText = _startButtonService.GetStartButtonText();
            TravelPanelVisibility = _travelPanelService.GetTravelPanelVisibility();
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

        private void OnTimerMessage(TravelPanelMessage message)
        {
            TravelPanelVisibility = message.TravelPanelVisibility;
            RunTravelPanelTimer();
            PointsInfoText = message.NumberOfReachedPoints.ToString();
        }

        private void OnStartButtonMessage(StartButtonMessage message)
        {
            ButtonText = message.StartButtonText;
        }

        private async void RunTravelPanelTimer()
        {
            while(_locationService.GetStateOfJourney())
            {
                await Task.Delay(1000);
                _travelPanelService.SetTravelTime();
                TimeInfoText = "Czas podróży: " +  _travelPanelService.GetTravelTime().ToString();
            }
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
