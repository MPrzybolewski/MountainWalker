using System;
using System.Diagnostics;
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
        private readonly ITrailService _trailService;
        private readonly ITravelPanelService _travelPanelService;
        private readonly IStartButtonService _startButtonService;

        private MvxSubscriptionToken _token;
        private MvxSubscriptionToken _travelPanelToken;
        private MvxSubscriptionToken _startButtonToken;

        public Point Location { get; set; }

        public IMvxCommand OpenMainDialogCommand { get; }
        public IMvxCommand<int> OpenTrailDialogCommand { get; set; }
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
            IMvxMessenger messenger, IDialogService dialogService, ITrailService trailService, 
            ITravelPanelService travelPanelService, IStartButtonService startButtonService)
        {
            _mainService = mainService;
            _sharedPreferencesService = sharedPreferencesService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _trailService = trailService;

            OpenMainDialogCommand = new MvxAsyncCommand(OpenDialog);
            OpenTrailDialogCommand = new MvxAsyncCommand<int>(OpenTrailDialog);
            _locationService = locationService;
            _travelPanelService = travelPanelService;
            _startButtonService = startButtonService;

            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            _travelPanelToken = messenger.Subscribe<TravelPanelMessage>(OnTimerMessage);
            _startButtonToken = messenger.Subscribe<StartButtonMessage>(OnStartButtonMessage);

            LogoutCommand = new MvxCommand(Logout);

            _locationService.StartFollow();

            _mainService.SetPointsAndTrials(_trailService.Points, _trailService.Trails);

            _mainService.SetPointsAndTrials(_trailService.Points, _trailService.Trails);

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
            if (_locationService.IsTrailStarted)
            {
                _mainService.SetCurrentLocation(Location); //this should be enable after starting walking
                foreach (var point in _trailService.Points)
                {
                    if (_mainService.GetDistanceBetweenTwoPointsOnMapInMeters(Location, point) < 20
                        && _mainService.GetDistanceBetweenTwoPointsOnMapInMeters(
                            _locationService.ReachedPoints[_locationService.ReachedPoints.Count], point) < 20) 
                    {
                        _locationService.ReachedPoints.Add(point);
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
            while(_locationService.IsTrailStarted)
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
            if(_locationService.IsTrailStarted)
            {
                await _navigationService.Navigate<AfterStartDialogViewModel>();
            } else 
            {
                await _navigationService.Navigate<DialogViewModel>();
            }
        }

        private async Task OpenTrailDialog(int args)
        {
            int id = args;
            Debug.WriteLine("dostalem w homeviewmodel args = " + args);
            _locationService.TrailId = id;
            Debug.WriteLine("HomeViewModel");
            await _navigationService.Navigate(typeof(TrailDialogViewModel));
        }

        private void Logout()
        {
            _sharedPreferencesService.CleanSharedPreferences();
            _navigationService.Navigate<SignInViewModel>();
        }

        public void RaiseTrailPopup(string polylineId)
        {
            Debug.WriteLine("nie wolno tak");
        }
    }
}
