using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Models;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class TrailDetailsViewModel : MvxViewModel
    {
        private Trail _trail;
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

        public TrailDetailsViewModel(ILocationService locationService, ITrailService trailService)
        {
            
            _trail = trailService.Trails[locationService.TrailId];
            _trailTitle = _trail.Name;
            _trailDescription = _trail.Description;
            _timeUp = "Wejście - " + _trail.TimeUp + " minut";
            _timeDown = "Zejście - " + _trail.TimeDown + " minut";


            _trailService = trailService;
        }

    }




}

