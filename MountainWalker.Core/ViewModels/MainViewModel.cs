using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MountainWalker.Core.Models;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;

namespace MountainWalker.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly IMainActivityService _mainService;
        private ISharedPreferencesService _sharedPreferencesService;

        public IMvxCommand OpenMainDialogCommand { get; }
        public IMvxCommand LogoutCommand { get; }
//        public IMvxCommand ShowCurrentLocationCommand { get; }

        readonly Type[] _menuItemTypes = { typeof(SettingsViewModel) };
        public IEnumerable<string> MenuItems { get; private set; } = new[] { "Settings" };


        public MainViewModel(ILocationService locationService, IMainActivityService mainService, ISharedPreferencesService sharedPreferencesService)
        {
            _locationService = locationService;
            _mainService = mainService;
            _sharedPreferencesService = sharedPreferencesService;

            OpenMainDialogCommand = new MvxCommand(OpenDialog);
            LogoutCommand = new MvxCommand(Logout);
//            ShowCurrentLocationCommand = new MvxAsyncCommand(GetLocationAction);
        }

//        private async Task GetLocationAction()
//        {
//            double[] location = await _locationService.GetLocation(); // 0 is Lat, 1 is Lng
//            _mainService.SetCurrentLocation(location[0], location[1]);
//        }

        private void OpenDialog()
        {
            ShowViewModel(typeof(DialogViewModel));
        }

        private void Logout()
        {
            _sharedPreferencesService.CleanSharedPreferences();
            ShowViewModel<SignInViewModel>();
        }


        public void NavigateTo(int position)
        {
            ShowViewModel(_menuItemTypes[position]);
        }
    }
}