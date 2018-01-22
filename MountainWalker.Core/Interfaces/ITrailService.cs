using System.Collections.Generic;
using MountainWalker.Core.Models;

namespace MountainWalker.Core.Interfaces
{
    public interface ITrailService
    {
        List<Trail> Trails { get; set; }
        List<Point> Points { get; set; }

    }
}