using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MountainWalker.Core.Models;

namespace MountainWalker.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private string _label = "ZMIEN TO EHHHH";
        private readonly ILocationService _locationService;

        public MainViewModel(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public IMvxCommand GetLocation => new MvxCommand(async () =>
        {
            Debug.WriteLine("cmon");

            var result = Task.Run(() => _locationService.GetLocation()).Result;
            Marker mark = new Marker(result);
            Label = mark.City + " " + mark.Latitude + " " + mark.Latitude;
            //_label = "A se zmienilem XD";
            Debug.WriteLine("I WANT LABEL = " + _label);
        });


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