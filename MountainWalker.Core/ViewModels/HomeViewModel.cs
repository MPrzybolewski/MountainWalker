using System;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private readonly IMapService _mapService;
        private string _label = "";

        public IMvxCommand GetLocationCommand { get; }
        public IMvxCommand ShowSimpleNoteInDebugLineCommand { get; }
        public IMvxCommand ShowCurrentLocationCommand { get; }


        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                RaisePropertyChanged();
            }
        }


        public HomeViewModel(ILocationService locationService, IMapService mapService)
        {
            _locationService = locationService;
            _mapService = mapService;
            GetLocationCommand = new MvxAsyncCommand(GetLocationAction);
            ShowSimpleNoteInDebugLineCommand = new MvxCommand(OnlySimpleTest);
            ShowCurrentLocationCommand = new MvxAsyncCommand(GetLocationAction);
        }


        private async Task GetLocationAction()
        {
            double[] location = await _locationService.GetLocation(); // 0 is Lat, 1 is Lng
            _mapService.SetCurrentLocation(location[0], location[1]);
        }

        private void OnlySimpleTest()
        {
            _mapService.SetLatLngButton(54.3956171, 18.5724856); //mfi hehe
        }
    }

}
