using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MountainWalker.Core.Messages;
using MountainWalker.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MountainWalker.Core.ViewModels
{
    public class ReachedTrailMapViewModel : MvxViewModel
    {
        private MvxInteraction<List<Point>> _interaction = new MvxInteraction<List<Point>>();
        public IMvxInteraction<List<Point>> Interaction => _interaction;

        private ReachedTrail _reached;
        public ReachedTrail ReachedTrail 
        {
            get => _reached;
            set => SetProperty(ref _reached, value);    
        }

        private MvxSubscriptionToken _token;

        public ReachedTrailMapViewModel(IMvxMessenger messenger)
        {
            _token = messenger.Subscribe<ReachedTrailMessage>(OnMessage);
        }

        private async void OnMessage(ReachedTrailMessage message)
        {
			ReachedTrail = message.ReachedTrail;
            await Task.Delay(500);
            _interaction.Raise(message.ReachedTrail.Trail);
        }
    }
}