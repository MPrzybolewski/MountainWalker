using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.ViewModels
{
    public class TrailDetailsViewModel : MvxViewModel
    {
        private Trail _trail;
        private MvxSubscriptionToken _token;

        private readonly ITrailService _trailService;
        private bool _isOpenedFromMenu;

        private string _trailTitle;
        public string TrailTitle
        {
            get => _trailTitle;
            set { _trailTitle = value; RaisePropertyChanged(); }
        }

        private string _trailDescription;
        public string TrailDescription
        {
            get => _trailDescription; 
            set { _trailDescription = value; RaisePropertyChanged(); }
        }

        private string _timeUp;
        public string TimeUp
        {
            get => _timeUp;
            set { _timeUp = value; RaisePropertyChanged(); }
        }

        private string _timeDown;
        public string TimeDown
        {
            get => _timeDown;
            set { _timeDown = value; RaisePropertyChanged(); }
        }

        private IMvxNavigationService _navigationService;
        public IMvxCommand BackCommand { get; }

        public TrailDetailsViewModel(ILocationService locationService, ITrailService trailService, 
                                     IMvxMessenger messenger, IMvxNavigationService navigationService)
        {
            //SetTrailInfo(trailService.Trails[locationService.TrailId]);
            _token = messenger.Subscribe<TrailMessage>(OnTrailMessage);
            _navigationService = navigationService;
            BackCommand = new MvxCommand(Back);
        }

        private void Back()
        {
            if (_isOpenedFromMenu)
                _navigationService.Navigate<TrailsViewModel>();
            else
                _navigationService.Navigate<HomeViewModel>();
        }

        private void OnTrailMessage(TrailMessage obj)
        {
            _isOpenedFromMenu = obj.IsOpenedFromMenu;
            SetTrailInfo(obj.Trail);
        }

        private void SetTrailInfo(Trail trail)
        {
            _trail = trail;
            TrailTitle = trail.Name;
            TrailDescription = trail.Description;
            TimeUp = "Wejście - " + trail.TimeUp + " minut";
            TimeDown = "Zejście - " + trail.TimeDown + " minut";
        }
    }




}

