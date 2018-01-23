using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.ViewModels
{
    public class TrailDetailsViewModel : MvxViewModel
    {
        private Trail _trail;
        private MvxSubscriptionToken _token;

        private readonly ITrailService _trailService;


        private string _trailTitle;
        public string TrailTitle
        {
            get { return _trailTitle; }
            set
            {
                _trailTitle = value;
                RaisePropertyChanged();
            }
        }

        private string _trailDescription;
        public string TrailDescription
        {
            get { return _trailDescription; }
            set
            {
                _trailDescription = value;
                RaisePropertyChanged();
            }
        }

        private string _timeUp;
        public string TimeUp
        {
            get { return _timeUp; }
            set
            {
                _timeUp = value;
                RaisePropertyChanged();
            }
        }

        private string _timeDown;
        public string TimeDown
        {
            get { return _timeDown; }
            set
            {
                _timeDown = value;
                RaisePropertyChanged();
            }
        }

        public TrailDetailsViewModel(ILocationService locationService, ITrailService trailService, IMvxMessenger messenger)
        {
            //SetTrailInfo(trailService.Trails[locationService.TrailId]);
            _token = messenger.Subscribe<TrailMessage>(OnTrailMessage);
        }

        private void OnTrailMessage(TrailMessage obj)
        {
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

