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
        Point GetCurrentLocation();
        void StartFollow();
    }
}