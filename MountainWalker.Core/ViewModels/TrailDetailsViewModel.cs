using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class TrailDetailsViewModel : MvxViewModel
    {
        private string _trailTitle;
        public string TrailTitle
        {
            get { return _trailTitle; }
            set
            {
                _trailTitle = value;
                RaisePropertyChanged();
            }
        }

        public TrailDetailsViewModel()
        {
            _trailTitle = "Porządny teścik here";
        }
    }
}

