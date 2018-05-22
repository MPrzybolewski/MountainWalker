using System;
using System.Diagnostics;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class AfterStartDialogViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly ITravelPanelService _travelPanelService;
        private readonly IStartButtonService _startButtonService;
        
        private readonly MvxInteraction<bool> _visible = new MvxInteraction<bool>();
        public IMvxInteraction<bool> Interaction => _visible;

        public IMvxCommand StopTravel { get; }
        public IMvxCommand DontStopTravel { get; }

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

        public AfterStartDialogViewModel(ILocationService locationService, ITravelPanelService travelPanelService, 
            IStartButtonService startButtonService) 
        {
            _visible.Raise(true);
            _locationService = locationService;
            _travelPanelService = travelPanelService;
            _startButtonService = startButtonService;

            _travelPanelService.SetTravelTime();
            TimeInfo = "Twoj czas: " +  _travelPanelService.TravelTime;
            StopTravel = new MvxCommand(ExecuteStopTravel);
            DontStopTravel = new MvxCommand(ExecuteDontStopTravel);
        }

        private void ExecuteStopTravel()
        {
            Stopwatch timer = new Stopwatch();
            _locationService.IsTrailStarted = false;
            _startButtonService.SetStartButtonText("Start");
            _travelPanelService.StopTimer();
            _travelPanelService.TravelPanelVisibility = "gone";
            _travelPanelService.NumberOfReachedPoints = 0;
            _visible.Raise(false);
        }

        private void ExecuteDontStopTravel()
        {
            _visible.Raise(false);
        }

		public void Close()
        {
            Close(this);
        }
    }
}
