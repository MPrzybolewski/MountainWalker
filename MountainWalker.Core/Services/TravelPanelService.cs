using System;
using System.Diagnostics;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Services
{
    public class TravelPanelService : ITravelPanelService
    {
        private readonly IMvxMessenger _travelPanelMessenger;

        private TravelTime _travelTime = new TravelTime(1,1,1);
        private int _numberOfReachedPoints = 0;
        private string _travelPanelVisibility = "gone";

        Stopwatch timer;
        long _travelTimeInMiliseconds;

        public TravelPanelService(IMvxMessenger travelPanelMessenger)
        {
            _travelPanelMessenger = travelPanelMessenger;
        }

        public void OnTimeFromTimer()
        {
            var message = new TravelPanelMessage(this, _travelTime, _numberOfReachedPoints, _travelPanelVisibility);

            _travelPanelMessenger.Publish(message);
        }


        public void SetTravelTime(TravelTime travelTime)
        {
            _travelTime = travelTime;
        }

        public void SetNumberOfReachedPoints(int numberOfReachedPoints)
        {
            _numberOfReachedPoints = numberOfReachedPoints;
        }

        public void StartTimer()
        {
            timer = new Stopwatch();
            timer.Start();
        }

        public void StopTimer()
        {
            timer.Stop();
        }

        public void SetTravelTime()
        {
            _travelTimeInMiliseconds = timer.ElapsedMilliseconds;
            _travelTime = new TravelTime(_travelTimeInMiliseconds / 1000);
        }

        public TravelTime GetTravelTime()
        {
            return _travelTime;
        }

        public void SetTravelPanelVisibility(string visibility)
        {
            _travelPanelVisibility = visibility;
            OnTimeFromTimer();
        }

        public string GetTravelPanelVisibility()
        {
            return _travelPanelVisibility;
        }

      
    }
}
