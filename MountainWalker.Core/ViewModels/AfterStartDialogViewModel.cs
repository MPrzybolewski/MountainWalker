using System;
using System.Diagnostics;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class AfterStartDialogViewModel : MvxViewModel
    {
        private readonly IMainActivityService _mainService;
        private readonly ILocationService _locationService;
        private readonly IBottomPanelService _bottomPanelService;

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

        public AfterStartDialogViewModel(IMainActivityService mainService, ILocationService locationService, IBottomPanelService bottomPanelService) 
        {
            _mainService = mainService;
            _locationService = locationService;
            _bottomPanelService = bottomPanelService;

            //_locationService.SetTravelTime();
            //TimeInfo = "Twoj czas: " +  _locationService.GetTravelTime();
            StopTravel = new MvxCommand(ExecuteStopTravel);
            DontStropTravel = new MvxCommand(ExecuteDontStopTravel);
        }

        private void ExecuteStopTravel()
        {
            Stopwatch timer = new Stopwatch();
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
