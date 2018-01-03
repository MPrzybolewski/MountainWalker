using System;
using System.Diagnostics;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Models;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class AfterStartDialogViewModel : MvxViewModel
    {
        private readonly IMainActivityService _mainService;

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

        public AfterStartDialogViewModel(IMainActivityService mainService) 
        {
            _mainService = mainService;
            TimeInfo = "Twoj czas";
            StopTravel = new MvxCommand(ExecuteStopTravel);
            DontStropTravel = new MvxCommand(ExecuteDontStopTravel);
        }

        private void ExecuteStopTravel()
        {
            _mainService.CloseMainDialog(true);
        }

        private void ExecuteDontStopTravel()
        {
            _mainService.CloseMainDialog(true);
        }
    }
}
