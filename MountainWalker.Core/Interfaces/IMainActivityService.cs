
namespace MountainWalker.Core.Interfaces
{
    public interface IMainActivityService
    {
        void SetLatLngButton(double latitude, double longitude);
        void SetCurrentLocation(double latitude, double longitude);
        void CloseMainDialog();
        void SendNotification();
        bool CheckPointIsNear(double userLatitude, double userLongitude, double pointLatitude, double pointLongitude);
        double GetDistanceBetweenTwoPointsOnMapInMeters(double firstPointLatitude, double firstPointLongitude, double secondPointLatitude, double secondPointLongitude);
        double ConvertDegreeToRadian(double angle);
    }
}
