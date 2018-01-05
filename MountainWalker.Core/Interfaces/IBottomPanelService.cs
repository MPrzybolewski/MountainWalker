using System;
using MountainWalker.Core.Models;

namespace MountainWalker.Core.Interfaces
{
    public interface IBottomPanelService
    {
        void GetTimeFromTimer();
        void SetTravelTime(TravelTime travelTime);
        void SetNumberOfReachedPoints(int numberOfReachedPoints);
        void StartTimer();
        void StopTimer();
        void SetTravelTime();
        TravelTime GetTravelTime();
    }
}
