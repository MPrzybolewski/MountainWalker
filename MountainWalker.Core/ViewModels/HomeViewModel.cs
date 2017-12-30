using System;
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
        private MvxSubscriptionToken _token;

        public Point Location { get; set; }
        private PointList _points;
        private ConnectionList _connections;

        public IMvxCommand OpenMainDialogCommand { get; }

        public IMvxCommand LogoutCommand { get; }

        public static Point UserPosition;

        public HomeViewModel(ILocationService locationService, IMainActivityService mainService,
            ISharedPreferencesService sharedPreferencesService, IMvxNavigationService navigationService, IMvxMessenger messenger)
        {
            _locationService = locationService;
            _mainService = mainService;
            _sharedPreferencesService = sharedPreferencesService;
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            _navigationService = navigationService;

            OpenMainDialogCommand = new MvxAsyncCommand(OpenDialog);
            LogoutCommand = new MvxCommand(Logout);

            _locationService.StartFollow();

            _points = new PointList();
            _connections = new ConnectionList();

            _mainService.SetPointsAndTrials(_points, _connections);
        }

        private void OnLocationMessage(LocationMessage message)
        {
            Location = message.Location;
            //_mainService.SetCurrentLocation(Location); this should be enable after started walking
        }

        private async Task OpenDialog()
        {
            await _navigationService.Navigate(typeof(DialogViewModel));
        }

        private void Logout()
        {
            _sharedPreferencesService.CleanSharedPreferences();
            _navigationService.Navigate<SignInViewModel>();
        }
    }
}
