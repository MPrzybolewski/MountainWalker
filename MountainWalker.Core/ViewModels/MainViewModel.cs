using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using MvvmCross.Core.Navigation;

namespace MountainWalker.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
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