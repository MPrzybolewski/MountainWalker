using System.Diagnostics;
using System.Linq.Expressions;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class DialogViewModel : MvxViewModel
    {
        private readonly IMapService _mapService;

        public IMvxCommand DialogTestCommand { get; }

        public IMvxCommand DialogTestDwaCommand { get; }

        private string _label = "";

        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                RaisePropertyChanged();
            }
        }

        public DialogViewModel(IMapService mapService)
        {
            _mapService = mapService;
            Label = "21";
            DialogTestCommand = new MvxCommand(DialogClick);
            DialogTestDwaCommand = new MvxCommand(DialogSecondClick);
        }

        private void DialogClick()
        {
            _mapService.SetLatLngButton(54.3956171, 18.5724856); //mfi
            Label = "MFI";
            _mapService.CloseMainDialog();
        }

        private void DialogSecondClick()
        {
            _mapService.SetLatLngButton(54.394121, 18.569394); //best place to go every monday <3
            Label = "YGREK";
            _mapService.CloseMainDialog();
        }
    }
}