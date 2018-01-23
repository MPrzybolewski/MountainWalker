using System;
using System.Diagnostics;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Plugin.SecureStorage;

namespace MountainWalker.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public string UserName { get; set; } = "Patryk Matuszak";

        public MenuViewModel(IMvxNavigationService navigationService, IWebAPIService webAPIService)
        {
            _navigationService = navigationService;
            UserName = CrossSecureStorage.Current.GetValue("Username");
        }
        public IMvxCommand ShowHomeCommand
        {
            get { return new MvxCommand(ShowHomeExecuted); }
        }

        private void ShowHomeExecuted()
        {
            _navigationService.Navigate<HomeViewModel>();
        }

        public IMvxCommand ShowTrailsCommand
        {
            get { return new MvxCommand(ShowTrailsExecuted); }
        }

        private void ShowTrailsExecuted()
        {
            _navigationService.Navigate<TrailsViewModel>();
        }

        public IMvxCommand ShowAchievementsCommand
        {
            get { return new MvxCommand(ShowAchievementsExecuted); }
        }

        private void ShowAchievementsExecuted()
        {
            _navigationService.Navigate<AchievementsViewModel>();
        }

        public IMvxCommand ShowAppDescriptionCommand
        {
            get { return new MvxCommand(ShowAppDescriptionExecuted); }
        }

        private void ShowAppDescriptionExecuted()
        {
            _navigationService.Navigate<AppDescriptionViewModel>();
        }

        public IMvxCommand ShowSettingCommand
        {
            get { return new MvxCommand(ShowSettingsExecuted); }
        }

        private void ShowSettingsExecuted()
        {
            _navigationService.Navigate<SettingsViewModel>();
        }

        public IMvxCommand ShowSignInCommand
        {
            get { return new MvxCommand(ShowSignInExecuted); }
        }

        private void ShowSignInExecuted()
        {
            _navigationService.Navigate<StartViewModel>();
        }

    }
}
