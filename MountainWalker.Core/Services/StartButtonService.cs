using System;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.Messages;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.Services
{
    public class StartButtonService : IStartButtonService
    {
        private readonly IMvxMessenger _startButtonMessenger;

        private string _startButtonText;

        public StartButtonService(IMvxMessenger startButtonMessenger)
        {
            _startButtonMessenger = startButtonMessenger;
        }

        public string GetStartButtonText()
        {
            return _startButtonText;
        }

        public void OnStartButton()
        {
            var message = new StartButtonMessage(this, _startButtonText);

            _startButtonMessenger.Publish(message);
        }

        public void SetStartButtonText(string buttonText)
        {
            _startButtonText = buttonText;
            OnStartButton();
        }
    }
}
