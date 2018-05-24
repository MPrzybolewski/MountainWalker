using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.ViewModels
{
    public class TrailsViewModel : MvxViewModel
    {
        
        private readonly ITrailService _trailService;
        private readonly IMvxNavigationService _navigationService;
        private readonly ILocationService _locationService;
        private readonly IMvxMessenger _messenger;

        public TrailsViewModel(ITrailService trailService, IMvxNavigationService navigationService, 
            ILocationService locationService, IMvxMessenger messenger)
        {
            _trailService = trailService;
            _navigationService = navigationService;
            _locationService = locationService;
            _messenger = messenger;

            Items = _trailService.Trails;
        }

        private List<Trail> _items;
        public List<Trail> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(() => Items); }
        }

        public ICommand ShowDetailTrail
        {
            get
            {
                return new MvxCommand<Trail>(item =>
                {
                    var message = new TrailMessage(this, _trailService.Trails.Where(trail => trail.Id == item.Id).FirstOrDefault(), true);
                    _navigationService.Navigate<TrailDetailsViewModel>();
                    _messenger.Publish(message);
                });
            }
        }

    }
}
