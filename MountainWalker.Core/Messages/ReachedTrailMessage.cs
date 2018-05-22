using MountainWalker.Core.Models;
using MountainWalker.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Messages
{
    public class ReachedTrailMessage : MvxMessage
    {
        public ReachedTrailMessage(object sender, ReachedTrail trail)
            : base(sender)
        {
            ReachedTrail = trail;
        }

        public ReachedTrail ReachedTrail { get; private set; }
    }
}