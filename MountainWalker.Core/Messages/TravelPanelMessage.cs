using System;
using MountainWalker.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Messages
{
    public class TravelPanelMessage : MvxMessage
    {
        public TravelTime TravelTime 
        {
            get;
            private set;
        }

        public int NumberOfReachedPoints
        {
            get;
            private set;
        }

        public string TravelPanelVisibility
        {
            get;
            private set;
        }

        public TravelPanelMessage(object sender, TravelTime travelTime, int numberOfReachedPoints, string travelPanelVisibility) : base(sender)
        {
            TravelTime = travelTime;
            NumberOfReachedPoints = numberOfReachedPoints;
            TravelPanelVisibility = travelPanelVisibility;
        }


    }
}
