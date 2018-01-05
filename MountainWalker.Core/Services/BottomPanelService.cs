using System;
using System.Diagnostics;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Services
{
    public class BottomPanelService : IBottomPanelService
    {
        private readonly IMvxMessenger _bottomPanelMessenger;

        private TravelTime _travelTime;
        private int _numberOfReachedPoints;
        private string _bottomPanelVisibility;

        Stopwatch timer;
        long _travelTimeInMiliseconds;

        public BottomPanelService(IMvxMessenger bottomPanelMessenger)
        {
            _bottomPanelMessenger = bottomPanelMessenger;
        }

        public void OnTimeFromTimer()
        {
            var message = new BottomPanelMessage(this, _travelTime, _numberOfReachedPoints, _bottomPanelVisibility);

            _bottomPanelMessenger.Publish(message);
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

        public void SetBottomPanelVisibility(string visibility)
        {
            _bottomPanelVisibility = visibility;
        }

        public string GetBottomPanelVisibility()
        {
            return _bottomPanelVisibility;
        }

      
    }
}
