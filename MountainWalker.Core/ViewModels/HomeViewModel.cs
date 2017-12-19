using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly IMainActivityService _mainService;
        private readonly ISharedPreferencesService _sharedPreferencesService;
        private readonly IMvxMessenger _messenger;
        private MvxSubscriptionToken _token;

        public static Point Location { get; set; }
        private PointList _points;

        public IMvxCommand OpenMainDialogCommand { get; }

        public IMvxCommand LogoutCommand { get; }

        readonly Type[] _menuItemTypes = {typeof(SettingsViewModel)};


        public HomeViewModel(ILocationService locationService, IMainActivityService mainService,
            ISharedPreferencesService sharedPreferencesService, IMvxMessenger messenger)
        {
            _locationService = locationService;
            _mainService = mainService;
            _sharedPreferencesService = sharedPreferencesService;
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);

            OpenMainDialogCommand = new MvxAsyncCommand(OpenDialog);
            LogoutCommand = new MvxCommand(Logout);

            _points = new PointList();
            _mainService.SetPoints(_points);
        }

        private void OnLocationMessage(LocationMessage message)
        {
            Location = message.Location;
            _mainService.SetCurrentLocation(Location);
        }

        private async Task OpenDialog()
        {
            Location = await _locationService.GetLocation();
            ShowViewModel(typeof(DialogViewModel));
            Debug.WriteLine("OPEN DIALOG");
        }

        private void Logout()
        {
            _sharedPreferencesService.CleanSharedPreferences();
            ShowViewModel<SignInViewModel>();
            Debug.WriteLine("OPEN LOGOUT");
        }

        public void NavigateTo(int position)
        {
            ShowViewModel(_menuItemTypes[position]);
        }
    }
}