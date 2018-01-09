using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class TrailDialogViewModel : MvxViewModel
    {
        private int _trailId;

        private readonly ILocationService _locationService;
        private readonly ITrailService _trailService;
        private readonly IMainActivityService _mainService;

        public IMvxCommand CloseDialogCommand { get; }
        public IMvxCommand ReadMoreCommand { get; }




        private string _trailName = "";
        public string TrailName
        {
            get { return _trailName; }
            set
            {
                _trailName = value;
                RaisePropertyChanged();
            }
        }

        private string _trailDescription = "";
        public string TrailDescription
        {
            get { return _trailDescription; }
            set
            {
                _trailDescription = value;
                RaisePropertyChanged();
            }
        }


        public TrailDialogViewModel(ILocationService locationService, ITrailService trailService, IMainActivityService mainService)
        {
            _locationService = locationService;
            _trailService = trailService;
            _mainService = mainService;
            _trailId = _locationService.TrailId;

            TrailName = _trailService.Trails[_trailId].Name;
            TrailDescription = _trailService.Trails[_trailId].Description;
            CloseDialogCommand = new MvxCommand(CloseDialog);
            ReadMoreCommand = new MvxCommand(ReadMore);
        }

        private void CloseDialog()
        {
            _mainService.CloseTrailDialog();
        }

        private void ReadMore()
        {
            
        }
    }
}