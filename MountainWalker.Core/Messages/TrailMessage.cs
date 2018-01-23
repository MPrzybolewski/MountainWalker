using MountainWalker.Core.Models;
using MountainWalker.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Messages
{
    public class TrailMessage : MvxMessage
    {
        public TrailMessage(object sender, Trail trail)
            : base(sender)
        {
            Trail = trail;
        }

        public Trail Trail { get; private set; }
    }
}