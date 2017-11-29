using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Messages
{
    public class LocationMessage : MvxMessage
    {
        public LocationMessage(object sender, double lat, double lng)
            : base(sender)
        {
            Lng = lng;
            Lat = lat;
        }

        public double Lat
        {
            get;
            private set;
        }
        public double Lng
        {
            get;
            private set;
        }
    }
}