using System;
using MountainWalker.Core.Messages;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Services
{
    public class BottomPanelService
    {
        private readonly IMvxMessenger _bottomPanelMessenger;
        public BottomPanelService(IMvxMessenger bottomPanelMessenger)
        {
            _bottomPanelMessenger = bottomPanelMessenger;
        }

        public void GetTimeFromTimer()
        {
            var message = new BottomPanelMessage(this);

            _bottomPanelMessenger.Publish(message);
        }

    }
}
