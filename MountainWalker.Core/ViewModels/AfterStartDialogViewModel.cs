﻿using System;
using System.Diagnostics;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Models;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class AfterStartDialogViewModel : MvxViewModel
    {
        private readonly IMainActivityService _mainService;
        private readonly ILocationService _locationService;

        public IMvxCommand StopTravel { get; }
        public IMvxCommand DontStropTravel { get; }

        private string _trialTitle = "Czy chcesz zakończyć swoją podróż?";
        public string TrailTitle
        {
            get { return _trialTitle; }
            set
            {
                _trialTitle = value;
                RaisePropertyChanged();
            }
        }

        private string _timeInfo = "";
        public string TimeInfo
        {
            get { return _timeInfo; }
            set
            {
                _timeInfo = value;
                RaisePropertyChanged();
            }
        }

        public AfterStartDialogViewModel(IMainActivityService mainService, ILocationService locationService) 
        {
            _mainService = mainService;
            _locationService = locationService;
            TimeInfo = "Twoj czas";
            StopTravel = new MvxCommand(ExecuteStopTravel);
            DontStropTravel = new MvxCommand(ExecuteDontStopTravel);
        }

        private void ExecuteStopTravel()
        {
            _mainService.CloseMainDialog(true);
            _locationService.SetStateOfJourney(false);
            _locationService.SetDialogButtonText("Start");

        }

        private void ExecuteDontStopTravel()
        {
            _mainService.CloseMainDialog(true);
        }
    }
}
