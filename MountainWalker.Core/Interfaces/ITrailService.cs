using System.Collections.Generic;
using MountainWalker.Core.Models;

namespace MountainWalker.Core.Interfaces
{
    public interface ITrailService
    {
        List<Connection> Trails { get; set; }
        List<Point> Points { get; set; }

    }
}