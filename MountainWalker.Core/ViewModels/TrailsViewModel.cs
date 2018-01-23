using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Models;
using MountainWalker.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class TrailsViewModel : MvxViewModel
    {
        
        private readonly ITrailService _trailService;
        private readonly IMvxNavigationService _navigationService;
        private readonly ILocationService _locationService;

        public TrailsViewModel(ITrailService trailService, IMvxNavigationService navigationService, ILocationService locationService)
        {
            _trailService = trailService;
            _navigationService = navigationService;
            _locationService = locationService;

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
                    _locationService.TrailId = item.Id;
                    Debug.WriteLine("TEST TEST TEST {0}", item.Id);
                    _navigationService.Navigate<TrailDetailsViewModel>();
                });
            }
        }

    }
}
