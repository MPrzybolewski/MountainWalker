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
        private readonly IMapService _mapService;
        private string _label = "";

        public IMvxCommand GetLocationCommand { get; }
        public IMvxCommand ShowSimpleNoteInDebugLineCommand { get; }
        public IMvxCommand ShowCurrentLocationCommand { get; }
        public IMvxCommand OkDialogCommand { get; }

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

        public MainViewModel(ILocationService locationService, IMapService mapService)
        {
            _locationService = locationService;
            _mapService = mapService;

            GetLocationCommand = new MvxAsyncCommand(GetLocationAction);
            ShowSimpleNoteInDebugLineCommand = new MvxCommand(OnlySimpleTest);
            ShowCurrentLocationCommand = new MvxAsyncCommand(GetLocationAction);
            OkDialogCommand = new MvxCommand(OkDialog);
        }

        private async Task GetLocationAction()
        {
            double[] location = await _locationService.GetLocation(); // 0 is Lat, 1 is Lng
            _mapService.SetCurrentLocation(location[0], location[1]);
        }

        private void OnlySimpleTest()
        {
            ShowViewModel(typeof(DialogViewModel));
            //_mapService.SetLatLngButton(54.3956171, 18.5724856); //mfi hehe
        }


        public void NavigateTo(int position)
        {
            ShowViewModel(_menuItemTypes[position]);
        }

        private void OkDialog()
        {
            Debug.WriteLine("In mainviewmodel");
        }
    }
}