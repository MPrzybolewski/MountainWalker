﻿using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
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
