﻿using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Interfaces.Impl;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.ViewModels
{
    public class DialogViewModel : MvxViewModel
    {
        private readonly IMainActivityService _mainService;
        private readonly ILocationService _locationService;
        private readonly ITravelPanelService _travelPanelService;
        private readonly IStartButtonService _startButtonService;
        private readonly ITrailService _trailService;

        public IMvxCommand TrailStartCommand { get; }
        public IMvxCommand NearestPointCommand { get; }

        private string _trialTitle = "";
        public string TrailTitle
        {
            get { return _trialTitle; }
            set
            {
                _trialTitle = value;
                RaisePropertyChanged();
            }
        }

        private string _trialInfo = "";
        public string TrailInfo
        {
            get { return _trialInfo; }
            set
            {
                _trialInfo = value;
                RaisePropertyChanged();
            }
        }

        private bool _canStart;

        public bool CanStart
        {
            get { return _canStart; }
            set
            {
                _canStart = value;
                RaisePropertyChanged();
            }
        }

        public DialogViewModel(IMainActivityService mainService, ILocationService locationService,
                               ITravelPanelService travelPanelService, IStartButtonService startButtonService,
                              ITrailService trailService) // tutaj ILocationService
        {
            _mainService = mainService;
            _locationService = locationService;
            _travelPanelService = travelPanelService;
            _startButtonService = startButtonService;
            _trailService = trailService;

            var currentLocation = _locationService.CurrentLocation;
            if (currentLocation == null)
            {
                currentLocation.Latitude = 0.0;
                currentLocation.Longitude = 0.0;
            }

            Debug.WriteLine(currentLocation.Latitude + " " + currentLocation.Longitude + " - ja jestem tutaj");

            TrailTitle = "Hala Gąsienicowa"; //some function should be here, but idk how i want to do here

            Point nearestPoint = GetNearestPoint(currentLocation);
            Debug.WriteLine(currentLocation.Latitude + " " + currentLocation.Longitude + " - a test tutaj");

            //Point Point = new Point(54.090506, 18.790464);

            if (_mainService.CheckPointIsNear(currentLocation, nearestPoint)) // user and point location
            {
                CanStart = true;
                TrailStartCommand = new MvxCommand(StartTrail);
                TrailInfo = "You can start right now!";
            }
            else
            {
                CanStart = false;
                TrailInfo = "You are to far away from any start point";
            }
            NearestPointCommand = new MvxCommand(ShowNearestPoint);
        }

        private void StartTrail()
        {
            _mainService.SetLatLngButton(new Point(54.3956171, 18.5724856)); //mfi
            _locationService.SetNewList();
            _locationService.IsTrailStarted = true;

            _travelPanelService.StartTimer();
            _startButtonService.SetStartButtonText("Stop");
            _travelPanelService.SetTravelPanelVisibility("visible");
            _mainService.CloseMainDialog(false);

        }

        private void ShowNearestPoint()
        {
            _mainService.SetLatLngButton(new Point(54.394121, 18.569394)); //best place to go every monday <3
            _mainService.CloseMainDialog(false);
        }

        private Point GetNearestPoint(Point userLocation)
        {
            double minDistanceBettwenPoints = Double.MaxValue;
            Point nearestPoint = new Point(0,0);
            foreach(Point point in _trailService.Points)
            {
                double distanceBettwenPoints = _mainService.GetDistanceBetweenTwoPointsOnMapInMeters(userLocation, point);
                if(minDistanceBettwenPoints > distanceBettwenPoints)
                {
                    minDistanceBettwenPoints = distanceBettwenPoints;
                    nearestPoint = point;
                }
            }

            return nearestPoint;
        }
    }
}