using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Plugin.SecureStorage;

namespace MountainWalker.Core.ViewModels
{
    public class StartViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private IWebAPIService _webAPIService;

        public StartViewModel(IMvxNavigationService navigationService, IWebAPIService webAPIService)
        {
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
            var exists = CrossSecureStorage.Current.HasKey("Session");
            if (!exists)
            {
                await _navigationService.Navigate<SignInViewModel>();
            }
            else
            {
                await _navigationService.Navigate<MainViewModel>();
            }
        }
    }
}
