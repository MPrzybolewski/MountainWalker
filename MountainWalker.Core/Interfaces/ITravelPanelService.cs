
using MountainWalker.Core.Models;

namespace MountainWalker.Core.Interfaces
{
    public interface ITravelPanelService
    {
        void OnTimeFromTimer();
        void StartTimer();
        void StopTimer();
        int NumberOfReachedPoints { get; set; }
        string TravelPanelVisibility { get; set; }
        long TravelTimeInMiliseconds { get; set; }
        TravelTime TravelTime { get; set; }
        void SetTravelTime();
    }
}
