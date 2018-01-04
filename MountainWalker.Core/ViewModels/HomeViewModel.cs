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
        private MvxSubscriptionToken _token;

        public Point Location { get; set; }

        public IMvxCommand OpenMainDialogCommand { get; }
        public IMvxCommand OpenTrailDialogCommand { get; set; }
        public IMvxCommand LogoutCommand { get; }

        public static Point UserPosition;

        public HomeViewModel(ILocationService locationService, IMainActivityService mainService,
            ISharedPreferencesService sharedPreferencesService, IMvxNavigationService navigationService, 
            IMvxMessenger messenger, IDialogService dialogService, ITrailService trailService)
        {
            _locationService = locationService;
            _mainService = mainService;
            _sharedPreferencesService = sharedPreferencesService;
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            _navigationService = navigationService;
            _dialogService = dialogService;
            _trailService = trailService;

            OpenMainDialogCommand = new MvxAsyncCommand(OpenDialog);
            OpenTrailDialogCommand = new MvxAsyncCommand(OpenTrailDialog);
            LogoutCommand = new MvxCommand(Logout);

            _locationService.StartFollow();

            _mainService.SetPointsAndTrials(_trailService.Points, _trailService.Trails);
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

        //private void StopTrail()
        //{
        //    //timer stop
        //    _isTrailStarted = false;
        //    //new view with reached points
        //    _dialogService.ShowAlert("You've reached" + _reachedPoints.Count + " points", "It's nice, it is?", "Fuck yea");
        //}

        private async Task OpenDialog()
        {
            await _navigationService.Navigate(typeof(DialogViewModel));
        }

        private async Task OpenTrailDialog()
        {
            int id = 1;
            _locationService.TrailId = id;
            Debug.WriteLine("HomeViewModel kurłaaaaaaaaaaaa");
            //await _navigationService.Navigate(typeof(TrailDialogViewModel));
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
