
namespace MountainWalker.Core.Interfaces
{
    public interface IMapService
    {
        void SetLatLngButton(double latitude, double longitude);
        void SetCurrentLocation(double latitude, double longitude);
        void CloseMainDialog();
    }
}
