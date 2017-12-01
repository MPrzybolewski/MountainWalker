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
        private readonly ILocationService _locationService;
        private string _label = "";

        readonly Type[] _menuItemTypes = { typeof(SettingsViewModel) };
        public IEnumerable<string> MenuItems { get; private set; } = new[] { "Settings" };

        public MainViewModel(ILocationService locationService)
        {
            _locationService = locationService;
            GetLocationCommand = new MvxAsyncCommand(GetLocationAction);
        }

        public IMvxCommand GetLocationCommand { get; }

        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                RaisePropertyChanged();
            }
        }

        private async Task GetLocationAction()
        {
            Label = await _locationService.GetLocation(); 
            Debug.WriteLine("Done" + _label);
        }


        public void NavigateTo(int position)
        {
            ShowViewModel(_menuItemTypes[position]);
        }
    }
}