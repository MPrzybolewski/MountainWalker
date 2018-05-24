using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MountainWalker.Core.Interfaces;

namespace MountainWalker.Core.ViewModels
{
    public class ReachedTrailMapViewModel : MvxViewModel
    {
        private MvxInteraction<List<Point>> _interaction = new MvxInteraction<List<Point>>();
        public IMvxInteraction<List<Point>> Interaction => _interaction;
        private readonly ITrailService _trailService;
        private readonly ILocationService _locationService;

        private ReachedTrail _reached;
        public ReachedTrail ReachedTrail
        {
            get => _reached;
            set => SetProperty(ref _reached, value);
        }

        private MvxSubscriptionToken _token;

        private IMvxNavigationService _navigationService;
        public IMvxCommand BackCommand { get; }

        public ReachedTrailMapViewModel(IMvxMessenger messenger, IMvxNavigationService navigationService, 
                                        ITrailService trailService, ILocationService locationService)
        {
            _trailService = trailService;
            _locationService = locationService;
            _token = messenger.Subscribe<ReachedTrailMessage>(OnMessage);
            _navigationService = navigationService;
            BackCommand = new MvxCommand(Back);
        }

        private void Back()
        {
            _navigationService.Navigate<ReachedTrailsViewModel>();
        }

        private async void OnMessage(ReachedTrailMessage message)
        {
            ReachedTrail = message.ReachedTrail;
            await Task.Delay(500);
            var trail = TranslateTrailsFromIndexesToPoints(message.ReachedTrail);
            _interaction.Raise(trail);
        }

        private List<Point> TranslateTrailsFromIndexesToPoints(ReachedTrail trail)
        {
            var resList = new List<Point>();
            foreach (var id in trail.Trails)
            {
                var select = _trailService.Trails.FirstOrDefault(t => t.Id == id);

                if (resList.Count > 0 && select.Path.Count > 0
                  && _locationService.GetDistanceBetweenTwoPointsOnMapInMeters(resList.Last(), select.Path.First()) > 50)
                    select.Path.Reverse();
                
                resList.AddRange(select.Path);
            }

            return resList;
        }
    }
}
