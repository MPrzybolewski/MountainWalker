using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Models;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using Plugin.SecureStorage;

namespace MountainWalker.Core.ViewModels
{
    public class AchievementsViewModel : MvxViewModel
    {
        private readonly IWebAPIService _webService;

        private MvxObservableCollection<Achievement> _items;
        public MvxObservableCollection<Achievement> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(() => Items); }
        }

        public AchievementsViewModel(IWebAPIService webService)
        {
            _webService = webService;
            var id = 1;
            Items = new MvxObservableCollection<Achievement>
            {
                new Achievement(id++, "Giewont"),
                new Achievement(id++, "Kasprowy wierch"),
                new Achievement(id++, "Rysy"),
                new Achievement(id++, "Mały Giewont"),
                new Achievement(id++, "Kopa Kondracka"),
                new Achievement(id++, "Świnica"),
                new Achievement(id++, "Kościelec"),
                new Achievement(id++, "Mnich"),
                new Achievement(id++, "Kozi Wierch"),
                new Achievement(id++, "Sarnia Skała"),
                new Achievement(id++, "Gęsia Szyja")
            };
            SetAchievements();
        }

        private void SetAchievements()
        {
            var tops = CrossSecureStorage.Current.GetValue(CrossSecureStorageKeys.Achievements);
            var achievements = JsonConvert.DeserializeObject<List<Achievement>>(tops);

            if (achievements.Count == 0)
                Items = new MvxObservableCollection<Achievement>();

            else
                foreach(var ach in achievements)
                {
                    foreach(var item in Items)
                    {
                        if (item.Id == ach.Id)
                        {
                            item.IsReached = true;
                            item.Date = ach.Date;
                        }
                    }
                }
        }
    }
}
