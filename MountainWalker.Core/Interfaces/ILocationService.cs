using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MountainWalker.Core.Services;
using MvvmCross.Plugins.Location;

namespace MountainWalker.Core.Interfaces
{
    public interface ILocationService
    {
        Point CurrentLocation { get; set; }
        event EventHandler<LocationEventArgs> CurrentLocationChanged;
        void OnCurrentLocationChanged(Point loc);
        bool IsTrailStarted { get; set; }
        List<Point> ReachedPoints { get; set; }
        int TrailId { get; set; }
        void SetNewList();
    }
}