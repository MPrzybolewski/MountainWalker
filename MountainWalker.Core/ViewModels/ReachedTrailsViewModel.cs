using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Newtonsoft.Json;
using Plugin.SecureStorage;

namespace MountainWalker.Core.ViewModels
{
    public class ReachedTrailsViewModel : MvxViewModel
    {
        private List<ReachedTrail> _items;
        public List<ReachedTrail> Items
        {
            get => _items;
            set { _items = value; RaisePropertyChanged(() => Items); }
        }

        private readonly IMvxMessenger _messenger;
        private readonly IMvxNavigationService _navigationService;


        public ReachedTrailsViewModel(IWebAPIService webAPIService, IMvxMessenger messenger,
                                      IMvxNavigationService navigationService )
        {
            SetItems();
            _messenger = messenger;
            _navigationService = navigationService;
        }

        private void SetItems()
        {
            var jsone = CrossSecureStorage.Current.GetValue(CrossSecureStorageKeys.ReachedTrails);
            var items = JsonConvert.DeserializeObject<List<ReachedTrail>>(jsone);
            Items = TranslateAndCalculateTime(items);
        }

        public ICommand ShowReachedTrail
        {
            get
            {
                return new MvxCommand<ReachedTrail>(item =>
                {
                    var message = new ReachedTrailMessage(this, item);
                    _navigationService.Navigate<ReachedTrailMapViewModel>();
                    _messenger.Publish(message);
                });
            }
        }

        private List<ReachedTrail> TranslateAndCalculateTime(List<ReachedTrail> reachedTrails)
        {
            foreach (var reachedTrail in reachedTrails)
            {
                var startTime = DateTime.Parse(reachedTrail.StartTime);
                var endTime = DateTime.Parse(reachedTrail.EndTime);

                reachedTrail.Date = DateTime.Parse(reachedTrail.Date).ToString("dd-MM-yyyy");
                reachedTrail.StartTime = "Start: " + startTime.ToString("HH:mm:ss");
                reachedTrail.EndTime = "Stop: " + endTime.ToString("HH:mm:ss");
                reachedTrail.Distance += "km";

                var xx = endTime.Subtract(startTime);
                reachedTrail.Time = new DateTime(xx.Ticks).ToString("HH:mm:ss");
            }

            return reachedTrails;
        }
    }
}
