using System;
using MountainWalker.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Messages
{
    public class BottomPanelMessage : MvxMessage
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

        public BottomPanelMessage(object sender, TravelTime travelTime, int numberOfReachedPoints) : base(sender)
        {
            TravelTime = travelTime;
            NumberOfReachedPoints = numberOfReachedPoints;
        }


    }
}
