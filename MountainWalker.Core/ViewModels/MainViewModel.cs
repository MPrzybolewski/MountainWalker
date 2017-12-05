using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MountainWalker.Core.Models;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;

namespace MountainWalker.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        readonly Type[] _menuItemTypes = { typeof(HomeViewModel), typeof(SettingsViewModel) };
        public IEnumerable<string> MenuItems { get; private set; } = new[] { "Home", "Settings" };

        public void NavigateTo(int position)
        {
            ShowViewModel(_menuItemTypes[position]);
        }
    }
}