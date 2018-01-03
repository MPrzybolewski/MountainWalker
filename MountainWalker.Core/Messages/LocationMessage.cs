using MountainWalker.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Messages
{
    public class LocationMessage : MvxMessage
    {
        public LocationMessage(object sender, Point location)
            : base(sender)
        {
            Location = location;
        }

        public Point Location
        {
            get;
            private set;
        }
    }
}