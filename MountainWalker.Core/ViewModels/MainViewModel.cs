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
        private readonly ILatLngSetService _latLng;
        private string _label = "";

        public IMvxCommand GetLocationCommand { get; }
        public IMvxCommand ShowSimpleNoteInDebugLineCommand { get; }

        readonly Type[] _menuItemTypes = { typeof(SettingsViewModel) };
        public IEnumerable<string> MenuItems { get; private set; } = new[] { "Settings" };

        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel(ILocationService locationService, ILatLngSetService latLng)
        {
            _locationService = locationService;
            _latLng = latLng;
            GetLocationCommand = new MvxAsyncCommand(GetLocationAction);
            ShowSimpleNoteInDebugLineCommand = new MvxCommand(OnlySimpleTest);
        }

        private async Task GetLocationAction()
        {
            Label = await _locationService.GetLocation(); 
            Debug.WriteLine("Done" + _label);
        }

        private void OnlySimpleTest()
        {
            Debug.WriteLine("Hellooooo! I'm here!");
            Debug.WriteLine("xvoxin did this XD");
            Debug.WriteLine("Mariando krul");
         
            _latLng.SetLatLngButton(49.2314702, 19.9769924);
        }


        public void NavigateTo(int position)
        {
            ShowViewModel(_menuItemTypes[position]);
        }
    }
}