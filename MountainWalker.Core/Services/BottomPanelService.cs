using System;
using System.Diagnostics;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Services
{
    public class BottomPanelService
    {
        private readonly IMvxMessenger _bottomPanelMessenger;

        private TravelTime _travelTime;
        private int _numberOfReachedPoints;

        Stopwatch timer;
        long _travelTimeInMiliseconds;

        public BottomPanelService(IMvxMessenger bottomPanelMessenger)
        {
            _bottomPanelMessenger = bottomPanelMessenger;
        }

        public void GetTimeFromTimer()
        {
            var message = new BottomPanelMessage(this, _travelTime, _numberOfReachedPoints);

            _bottomPanelMessenger.Publish(message);
        }


        private void SetTravelTime(TravelTime travelTime)
        {
            _travelTime = travelTime;
        }

        private void SetNumberOfReachedPoints(int numberOfReachedPoints)
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
    }
}
