using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly IMainActivityService _mainService;
        private readonly ISharedPreferencesService _sharedPreferencesService;

        public IMvxCommand OpenMainDialogCommand { get; }

        public IMvxCommand LogoutCommand { get; }
        //        public IMvxCommand ShowCurrentLocationCommand { get; }

        public HomeViewModel(ILocationService locationService, IMainActivityService mainService,
            ISharedPreferencesService sharedPreferencesService)
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
            Debug.WriteLine("OPEN DIALOG");
        }

        private void Logout()
        {
            _sharedPreferencesService.CleanSharedPreferences();
            ShowViewModel<SignInViewModel>();
            Debug.WriteLine("OPEN LOGOUT");
        }

    }
}
