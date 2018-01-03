﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly IMainActivityService _mainService;
        private readonly ISharedPreferencesService _sharedPreferencesService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private MvxSubscriptionToken _token;

        public Point Location { get; set; }
        private PointList _points;
        private ConnectionList _connections;

        public IMvxCommand OpenMainDialogCommand { get; }

        public IMvxCommand LogoutCommand { get; }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value);}
        }

        public static Point UserPosition;

        public HomeViewModel(ILocationService locationService, IMainActivityService mainService,
            ISharedPreferencesService sharedPreferencesService, IMvxNavigationService navigationService, 
            IMvxMessenger messenger, IDialogService dialogService)
        {
            
            _mainService = mainService;
            _sharedPreferencesService = sharedPreferencesService;
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            _navigationService = navigationService;
            _dialogService = dialogService;
            _locationService = locationService;

            ButtonText = "Start";


            LogoutCommand = new MvxCommand(Logout);

            _locationService.StartFollow();

            _points = new PointList();
            _connections = new ConnectionList();

            _mainService.SetPointsAndTrials(_points, _connections);
            OpenMainDialogCommand = new MvxAsyncCommand(OpenDialog);

        }

        private void OnLocationMessage(LocationMessage message)
        {
            Location = message.Location;
            if (_locationService.GetStateOfJourney())
            {
                _mainService.SetCurrentLocation(Location); //this should be enable after started walking
                foreach (var point in _points.Points)
                {
                    if (_mainService.GetDistanceBetweenTwoPointsOnMapInMeters(Location, point) < 30
                        && _mainService.GetDistanceBetweenTwoPointsOnMapInMeters(
                            _locationService.GetReachedPoints()[_locationService.GetReachedPoints().Count], point) < 30) 
                    {
                        _locationService.AddReachedPoint(point);
                    }
                }
            }
        }

        //private void StopTrail()
        //{
        //    //timer stop
        //    _isTrailStarted = false;
        //    //new view with reached points
        //    _dialogService.ShowAlert("You've reached" + _reachedPoints.Count + " points", "It's nice, it is?", "Fuck yea");
        //}

        private async Task OpenDialog()
        {
            
            await _navigationService.Navigate(typeof(DialogViewModel));

        }

        private void Logout()
        {
            _sharedPreferencesService.CleanSharedPreferences();
            _navigationService.Navigate<SignInViewModel>();
        }
    }
}
