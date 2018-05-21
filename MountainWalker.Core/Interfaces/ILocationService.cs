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
        List<Trail> ReachedTrails { get; set; }
        int TrailId { get; set; }
        void SetNewList();
        bool CheckPointIsNear(Point userLocation, Point pointLocation);
        double GetDistanceBetweenTwoPointsOnMapInMeters(Point firstLocation, Point secondLocation);
        double ConvertDegreeToRadian(double angle);
        Point GetNearestPoint(Point userLocation, List<Point> points);
        string Distance(double dist);
    }
}