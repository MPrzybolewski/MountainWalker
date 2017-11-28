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
            
        }

        public IMvxCommand GetLocationCommand { get; }
        public IMvxCommand ShowSimpleNoteInDebugLineCommand { get; }



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