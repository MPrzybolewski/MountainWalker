using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Plugins.Location;

namespace MountainWalker.Core.Interfaces
{
    public interface ILocationService
    {
        Task<Point> GetLocation();
        Point CurrentLocation { get; set; }
        bool IsTrailStarted { get; set; }
        List<Point> ReachedPoints { get; set; }
        int TrailId { get; set; }
        void SetNewList();
        void StartFollow();
    }
}