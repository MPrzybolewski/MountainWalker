
namespace MountainWalker.Core.Interfaces
{
    public interface IMainActivityService
    {
        void SetLatLngButton(double latitude, double longitude);
        void SetCurrentLocation(double latitude, double longitude);
        void CloseMainDialog();
        bool CheckPointIsNear();
    }
}
