using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using Plugin.SecureStorage;

namespace MountainWalker.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            //CrossSecureStorage.Current.DeleteKey("Session");
        }

        public void ShowMenu()
        {
            _navigationService.Navigate<HomeViewModel>();
            _navigationService.Navigate<MenuViewModel>();
        }

        public void ShowHome()
        {
            _navigationService.Navigate<HomeViewModel>();
        }

        public void Init(object hint)
        {
        }

        public override void Start()
        {
            
        }
    }
}