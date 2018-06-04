using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Plugins.Messenger;
using Newtonsoft.Json;
using Plugin.SecureStorage;

namespace MountainWalker.Core.Services
{
    public class TravelPanelService : ITravelPanelService
    {
        private readonly IMvxMessenger _travelPanelMessenger;
        private readonly ILocationService _locationService;

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

        public TravelPanelService(IMvxMessenger travelPanelMessenger, ILocationService locationService)
        {
            _travelPanelMessenger = travelPanelMessenger;
            _locationService = locationService;
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

        public void AddNewTrailToStorage()
        {
            var reachedTrail = new ReachedTrail()
            {
                Date = DateTime.Now.ToString("dd:MM:yy"),
                From = _locationService.ReachedPoints.FirstOrDefault().Name,
                To = _locationService.ReachedPoints.LastOrDefault().Name,
                StartTime = StartTime.ToString("HH:mm:ss"),
                EndTime = DateTime.Now.ToString("HH:mm:ss"),
                Distance = "5km"
            };

            var xx = DateTime.Now.Subtract(StartTime);
            var date = new DateTime(xx.Ticks).ToString("HH:mm:ss");
            reachedTrail.Time = date;
            var trails = new List<int>();
            foreach (var trail in _locationService.ReachedTrails)
            {
                trails.Add(trail.Id);
            }
            reachedTrail.Trails = trails;

            var dataToDb = JsonConvert.SerializeObject(reachedTrail);

            //tutaj wysylam do bazy

            var jsone = CrossSecureStorage.Current.GetValue(CrossSecureStorageKeys.ReachedTrails);
            var jsoneList = JsonConvert.DeserializeObject<List<ReachedTrail>>(jsone);

            jsoneList.Add(reachedTrail);

            jsone = JsonConvert.SerializeObject(jsoneList);

            CrossSecureStorage.Current.SetValue(CrossSecureStorageKeys.ReachedTrails, jsone);
        }
    }
}
