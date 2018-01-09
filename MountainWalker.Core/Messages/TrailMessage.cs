using MountainWalker.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Messages
{
    public class TrailMessage : MvxMessage
    {
        public TrailMessage(object sender, int id)
            : base(sender)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}