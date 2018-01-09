using System;
using MountainWalker.Core.Models;

namespace MountainWalker.Core.Interfaces
{
    public interface ITravelPanelService
    {
        void OnTimeFromTimer();
        void SetTravelTime(TravelTime travelTime);
        void SetNumberOfReachedPoints(int numberOfReachedPoints);
        void StartTimer();
        void StopTimer();
        void SetTravelTime();
        TravelTime GetTravelTime();
        void SetTravelPanelVisibility(string visibility);
        string GetTravelPanelVisibility();
    }
}
