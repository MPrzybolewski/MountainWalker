using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class StartViewModel : MvxViewModel
    {
        private ISharedPreferencesService _sharedPreferencesService;
        private readonly IMvxNavigationService _navigationService;
        private IWebAPIService _webAPIService;

        public StartViewModel(ISharedPreferencesService sharedPreferencesService, IMvxNavigationService navigationService, IWebAPIService webAPIService)
        {
            _sharedPreferencesService = sharedPreferencesService;
            _navigationService = navigationService;
            _webAPIService = webAPIService;
        }

        public override Task Initialize()
        {
            CheckPreferences();
            return base.Initialize();
        }

        private async void CheckPreferences()
        {
            string userName = string.Empty;
            string password = string.Empty;
            _sharedPreferencesService.CheckSharedPreferences(ref userName, ref password);
            if (userName == String.Empty || password == String.Empty)
            {
                //There is no saved credentials, take user to the login page
                _navigationService.Navigate<MainViewModel>();

            }
            else
            {
                string RestUrl = "http://mountainwalkerwebapi.azurewebsites.net/api/users/" + userName + "?password=" +
                             password;
                string result = await _webAPIService.CheckIfUserCanLogin(RestUrl);

                if (result.Trim(new char[] { '"' }).Equals("true"))
                {
                    //Successful so take the user to application
                    _navigationService.Navigate<MainViewModel>();
                }
                else
                {
                    //Unsuccesful so take user to login screen
                    //Clean SharedPreferences
                    _sharedPreferencesService.CleanSharedPreferences();

                    _navigationService.Navigate<SignInViewModel>();
                }
            }
        }
    }
}
