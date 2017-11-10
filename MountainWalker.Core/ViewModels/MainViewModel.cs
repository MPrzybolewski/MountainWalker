using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MountainWalker.Core.Models;

namespace MountainWalker.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MainViewModel()
        {
        }

        public override Task Initialize()
        {
            //TODO: Add starting logic here

            return base.Initialize();
        }

        public IMvxCommand GetLocation => new MvxCommand(async () => await CheckLocation());
        private Task CheckLocation()
        {
            var foo = Mvx.Resolve<ILocationService>();
            Marker mark = await foo.GetLocation().Result;
            _label = mark.City + " " + mark.Latitude + " " + mark.Latitude;
            return null;
        }

        private string _label = "";

        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }
    }
}