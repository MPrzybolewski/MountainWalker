
using MountainWalker.Core.Models;

namespace MountainWalker.Core.Interfaces
{
    public interface IMainActivityService
    {
        void SetLatLngButton(Point location);
        void SetCurrentLocation(Point location);
        void CloseMainDialog(bool isStopButton);
        bool CheckPointIsNear(Point userLocation, Point pointLocation);
        double GetDistanceBetweenTwoPointsOnMapInMeters(Point firstLocation, Point secondLocation);
        double ConvertDegreeToRadian(double angle);
        void SetPointsAndTrials(PointList points, ConnectionList connections);
    }
}
