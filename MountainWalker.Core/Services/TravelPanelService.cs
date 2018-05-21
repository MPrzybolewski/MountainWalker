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

        public TravelTime TravelTime { get; set; }
        public DateTime StartTime { get; set; }

        public long TravelTimeInMiliseconds { get; set; }

        private int _reachedPoints = 0;
        public int NumberOfReachedPoints
        {
            get => _reachedPoints;
            set
            {
                _reachedPoints = value;
                OnTimeFromTimer();
            }
        }

        private string _travelPanelVisibility = "gone";
        public string TravelPanelVisibility
        {
            get => _travelPanelVisibility;
            set
            {
                _travelPanelVisibility = value;
                OnTimeFromTimer();
            }
        }

        private Stopwatch _timer;

        public TravelPanelService(IMvxMessenger travelPanelMessenger)
        {
            _travelPanelMessenger = travelPanelMessenger;
            TravelTime = new TravelTime(1, 1, 1);
        }

        public void OnTimeFromTimer()
        {
            var message = new TravelPanelMessage(this, TravelTime, NumberOfReachedPoints, TravelPanelVisibility);

            _travelPanelMessenger.Publish(message);
        }

        public void StartTimer()
        {
            StartTime = DateTime.Now;
            _timer = new Stopwatch();
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();
        }

        public void SetTravelTime()
        {
            TravelTimeInMiliseconds = _timer.ElapsedMilliseconds;
            TravelTime = new TravelTime(TravelTimeInMiliseconds / 1000);
        }
    }
}
