using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
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
		public IMvxCommand DismissDialogCommand { get; }

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
            TrailDescription = _trailService.Trails[_trailId].ShortDescription;
            ReadMoreCommand = new MvxCommand(ReadMore);
			DismissDialogCommand = new MvxCommand(DismissDialog);
        }

        private void ReadMore()
        {
            var message = new TrailMessage(this, _trailService.Trails[_trailId], false);
            if(Achievement.Os == "Android")
            {
                _navigationService.Navigate<TrailDetailsViewModel>();
                _visible.Raise(false);
                _messenger.Publish(message);
            }
            else
            {
                _navigationService.Navigate<TrailDetailsViewModel>();
                Close();
                _messenger.Publish(message);
            }


        }

		private void DismissDialog()
        {
            _visible.Raise(false);
        }

		public void Close()
        {
            Close(this);
        }
    }
}