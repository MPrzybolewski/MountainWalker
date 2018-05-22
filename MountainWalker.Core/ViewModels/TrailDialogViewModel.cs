using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.ViewModels
{
    public class TrailDialogViewModel : MvxViewModel
    {
        private int _trailId;

        private readonly ILocationService _locationService;
        private readonly ITrailService _trailService;
        private readonly IMvxNavigationService _navigationService;

        private readonly MvxInteraction<bool> _visible = new MvxInteraction<bool>();
        public IMvxInteraction<bool> Interaction => _visible;
        private IMvxMessenger _messenger;

        public IMvxCommand ReadMoreCommand { get; }

        private string _trailName = "";
        public string TrailName
        {
            get => _trailName;
            set { _trailName = value; RaisePropertyChanged(); }
        }

        private string _trailDescription = "";
        public string TrailDescription
        {
            get => _trailDescription;
            set { _trailDescription = value; RaisePropertyChanged(); }
        }

        public TrailDialogViewModel(ILocationService locationService, ITrailService trailService, 
            IMvxNavigationService navigationService, IMvxMessenger messenger)
        {
            _locationService = locationService;
            _trailService = trailService;
            _navigationService = navigationService;
            _trailId = _locationService.TrailId;
            _messenger = messenger;

            TrailName = _trailService.Trails[_trailId].Name;
            TrailDescription = _trailService.Trails[_trailId].Description;
            ReadMoreCommand = new MvxCommand(ReadMore);
        }

        private void ReadMore()
        {
            var message = new TrailMessage(this, _trailService.Trails[_trailId], false);
            _navigationService.Navigate<TrailDetailsViewModel>();
            _visible.Raise(false);
            _messenger.Publish(message);
        }

		public void Close()
        {
            Close(this);
        }
    }
}