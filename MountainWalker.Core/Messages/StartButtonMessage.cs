using System;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Messages
{
    public class StartButtonMessage : MvxMessage
    {
        public string StartButtonText
        {
            get;
            private set;
        }

        public StartButtonMessage(object sender, string startButtonText) : base(sender)
        {
            StartButtonText = startButtonText;
        }

    }
}
