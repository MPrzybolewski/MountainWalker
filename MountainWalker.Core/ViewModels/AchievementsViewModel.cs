using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class AchievementsViewModel : MvxViewModel
    {
        private List<Achievement> _items;

        public List<Achievement> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(() => Items); }
        }

        public AchievementsViewModel()
        {
            Items = new List<Achievement>();
            Items.Add(new Achievement("Dotrzyj do SKMki"));
            Items.Add(new Achievement("Obejrzyj budowę Alchemii"));
            Items.Add(new Achievement("Dotrzyj na MFI"));
            Items.Add(new Achievement("Zdobądź Ygrek"));
            Items.Add(new Achievement("Zdobądź KFC"));
        }
    }

    public class Achievement
    {
        public string Name { get; set; }

        public Achievement(string name)
        {
            Name = name;
        }
    }
}
