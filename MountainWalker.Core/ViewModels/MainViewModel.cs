using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MountainWalker.Core.Models;
using Plugin.Geolocator;

namespace MountainWalker.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;
        private string _label = "";
        public MainViewModel(ILocationService locationService)
        {
            _locationService = locationService;
            GetLocationCommand = new MvxAsyncCommand(GetLocationAction);
        }


        private async Task GetLocationAction()
        {
            Label = await _locationService.GetLocation();
            Debug.WriteLine("Done" + _label);
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
    }
}