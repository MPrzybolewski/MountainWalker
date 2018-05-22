using MountainWalker.Core.Models;
using MountainWalker.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Messages
{
    public class TrailMessage : MvxMessage
    {
        public TrailMessage(object sender, Trail trail, bool fromMenu)
            : base(sender)
        {
            Trail = trail;
            IsOpenedFromMenu = fromMenu;
        }

        public Trail Trail { get; }
        public bool IsOpenedFromMenu { get; }
    }
}