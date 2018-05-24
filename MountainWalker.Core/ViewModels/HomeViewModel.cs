using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MountainWalker.Core.Services;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using System;
using Plugin.SecureStorage;
using Newtonsoft.Json;

namespace MountainWalker.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly IMvxNavigationService _navigationService;
        private readonly ITrailService _trailService;
        private readonly ITravelPanelService _travelPanelService;
        private readonly IStartButtonService _startButtonService;
        
        private MvxInteraction<Point> _interaction = new MvxInteraction<Point>();
        public IMvxInteraction<Point> Interaction => _interaction;

        private MvxSubscriptionToken _token;
        private MvxSubscriptionToken _travelPanelToken;
        private MvxSubscriptionToken _startButtonToken;

        public Point Location { get; set; }
        public List<Point> Points { get; private set;  }
        public List<Trail> Trails { get; private set;  }

        public IMvxCommand OpenMainDialogCommand { get; }
        public IMvxCommand<int> OpenTrailDialogCommand { get; }

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

        private string _timeInfoText = "0h:0m:0s";
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

        private bool _followUser = true;
        public bool FollowUser
        {
            get => _followUser;
            set { _followUser = value; RaisePropertyChanged(); } 
        }

        public HomeViewModel(ILocationService locationService, IMvxNavigationService navigationService, IMvxMessenger messenger, 
            ITrailService trailService, ITravelPanelService travelPanelService, IStartButtonService startButtonService)
        {
            _navigationService = navigationService;
            _trailService = trailService;

            OpenMainDialogCommand = new MvxAsyncCommand(OpenDialog);
            OpenTrailDialogCommand = new MvxAsyncCommand<int>(OpenTrailDialog);
            _locationService = locationService;
            _travelPanelService = travelPanelService;
            _startButtonService = startButtonService;

            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            _travelPanelToken = messenger.Subscribe<TravelPanelMessage>(OnTimerMessage);
            _startButtonToken = messenger.Subscribe<StartButtonMessage>(OnStartButtonMessage);

            _locationService.CurrentLocationChanged += HandleCurrentLocationCameraChanged;
            Points = _trailService.Points;
            Trails = _trailService.Trails;

            OpenMainDialogCommand = new MvxAsyncCommand(OpenDialog);

            SetLayoutProperties();

        }

        void SetLayoutProperties()
        {
            ButtonText = _startButtonService.GetStartButtonText();
            TravelPanelVisibility = _travelPanelService.TravelPanelVisibility;
        }

        private void OnLocationMessage(LocationMessage message)
        {
            Location = message.Location;
            
            if (_locationService.IsTrailStarted)
            {
                if(FollowUser)
                    _locationService.OnCurrentLocationChanged(Location);
                
                foreach (var point in _trailService.Points)
                {
                    if (_locationService.GetDistanceBetweenTwoPointsOnMapInMeters(Location, point) < 50
                        &&  !_locationService.ReachedPoints.Contains(point)) 
                    {
                        _locationService.ReachedPoints.Add(point);
                        _travelPanelService.NumberOfReachedPoints = _locationService.ReachedPoints.Count;
                    }
                }

                if (_locationService.ReachedPoints.Count > 0
                       && _locationService.ReachedTrails.Count < _locationService.ReachedPoints.Count)
                {
                    var currentPoint = _locationService.ReachedPoints.Last();
                    var nearestTrails = new List<Trail>();
                    foreach (var trail in _trailService.Trails)
                    {

                        if (_locationService.GetDistanceBetweenTwoPointsOnMapInMeters(trail.Path.First(), currentPoint) < 5
                           || _locationService.GetDistanceBetweenTwoPointsOnMapInMeters(trail.Path.Last(), currentPoint) < 5)
                        {
                            nearestTrails.Add(trail);
                        }
                    }

                    Trail nearestTrail = null;
                    var currentDistance = 5d;
                    foreach (var trail in nearestTrails)
                    {
                        foreach (var pt in trail.Path)
                        {
                            var x = _locationService.GetDistanceBetweenTwoPointsOnMapInMeters(pt, currentPoint);
                            if (x < currentDistance)
                            {
                                x = currentDistance;
                                nearestTrail = trail;
                            }
                        }
                    }
                    if (nearestTrail != null)
                        _locationService.ReachedTrails.Add(nearestTrail);
                }
            }
        }

        private void OnTimerMessage(TravelPanelMessage message)
        {
            TravelPanelVisibility = message.TravelPanelVisibility;
            RunTravelPanelTimer();
            PointsInfoText = "" + message.NumberOfReachedPoints;
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
                TimeInfoText = "" +  _travelPanelService.TravelTime;
            }
            //AddNewTrailToStorage(_travelPanelService.TravelTime);
            TimeInfoText = "0:0:0";
        }

        private void AddNewTrailToStorage(TravelTime time)
        {
            var date = DateTime.Now.ToString("HH/MM/SS");
            var reachedTrail = new ReachedTrail()
            {
                Date = DateTime.Now.ToString("dd:MM:yy"),
                From = _locationService.ReachedPoints.First().Name,
                To = _locationService.ReachedPoints.Last().Name,
                StartTime = _travelPanelService.StartTime.ToString("HH:mm:ss"),
                EndTime = DateTime.Now.ToString("HH:mm:ss"),
                Time = time.ToString(""),
                Distance = "5km"
            };

            var trails = new List<int>();
            foreach(var trail in _locationService.ReachedTrails)
            {
                trails.Add(trail.Id);
            }
            reachedTrail.Trails = trails;

            var jsone = CrossSecureStorage.Current.GetValue(CrossSecureStorageKeys.ReachedTrails);
            var jsoneList = JsonConvert.DeserializeObject<List<ReachedTrail>>(jsone);

            jsoneList.Add(reachedTrail);

            jsone = JsonConvert.SerializeObject(jsoneList);

            CrossSecureStorage.Current.SetValue(CrossSecureStorageKeys.ReachedTrails, jsone);

            //deserialize, add and serialize
            //add to securestorage
        }

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
            _locationService.TrailId = id;
            await _navigationService.Navigate(typeof(TrailDialogViewModel));
        }
        
        private void HandleCurrentLocationCameraChanged(object sender, LocationEventArgs loc)
        {
            _interaction.Raise(loc.Location);
        }
    }
}
