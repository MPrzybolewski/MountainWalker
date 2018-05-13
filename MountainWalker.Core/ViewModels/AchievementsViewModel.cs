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
            Items.Add(new Achievement("Dotrzyj do SKMki", "Dzisiaj heh", true));
            Items.Add(new Achievement("Obejrzyj budowę Alchemii", "Wczoraj XD", true));
            Items.Add(new Achievement("Dotrzyj na MFI", "Jeszcze nie", false));
            Items.Add(new Achievement("Zdobądź Ygrek", "Z miesiac temu", true));
            Items.Add(new Achievement("Zdobądź KFC", "Jeszcze nie", false));
            Items.Add(new Achievement("Dotrzyj do SKMki", "Dzisiaj heh", true));
            Items.Add(new Achievement("Obejrzyj budowę Alchemii", "Wczoraj XD", true));
            Items.Add(new Achievement("Dotrzyj na MFI", "Jeszcze nie", false));
            Items.Add(new Achievement("Zdobądź Ygrek", "Z miesiac temu", true));
            Items.Add(new Achievement("Zdobądź KFC", "Jeszcze nie", false));
            Items.Add(new Achievement("Dotrzyj do SKMki", "Dzisiaj heh", true));
            Items.Add(new Achievement("Obejrzyj budowę Alchemii", "Wczoraj XD", true));
            Items.Add(new Achievement("Dotrzyj na MFI", "Jeszcze nie", false));
            Items.Add(new Achievement("Zdobądź Ygrek", "Z miesiac temu", true));
            Items.Add(new Achievement("Zdobądź KFC", "Jeszcze nie", false));
            Items.Add(new Achievement("Dotrzyj do SKMki", "Dzisiaj heh", true));
            Items.Add(new Achievement("Obejrzyj budowę Alchemii", "Wczoraj XD", true));
            Items.Add(new Achievement("Dotrzyj na MFI", "Jeszcze nie", false));
            Items.Add(new Achievement("Zdobądź Ygrek", "Z miesiac temu", true));
            Items.Add(new Achievement("Zdobądź KFC", "Jeszcze nie", false));
        }
    }

    public class Achievement
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public bool IsReached { get; set; }
        public string Id { get; set; }
        public string Trophy
        {
            get
            {
                if (IsReached)
                    return "@drawable/trophy";
                else
                    return "@drawable/trophyx";
            }
        }

        public Achievement(string name, string date)
        {
            Name = name;
            Date = date;
            IsReached = false;
        }

        public Achievement(string name, string date, bool reached)
        {
            Name = name;
            Date = date;
            IsReached = reached;
        }
    }
}
