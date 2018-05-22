using System;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform.Core;
using UIKit;

namespace MountainWalker.Touch.Views
{
	[MvxModalPresentation(
        ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext,
        ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal,
        WrapInNavigationController = false
    )]
    public partial class TrailDialogView : BaseViewController<TrailDialogViewModel>
    {

		private IMvxInteraction<bool> _visible;
        public IMvxInteraction<bool> Interaction
        {
            get => _visible;
            set
            {
                if (_visible != null)
                    _visible.Requested -= CloseDialogHandler;

                _visible = value;
                _visible.Requested += CloseDialogHandler;
            }
        }

        private void CloseDialogHandler(object sender, MvxValueEventArgs<bool> visible)
        {
            if (!visible.Value)
            {
                ViewModel.Close();
            }
                
            
        }

              
        public override void ViewDidLoad()
        {
            
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.Black.ColorWithAlpha((nfloat)0.5);
            View.ExclusiveTouch = true;
            View.ReloadInputViews();

			var interact = this.CreateBindingSet<TrailDialogView, TrailDialogViewModel>();
            interact.Bind(this).For(v => v.Interaction).To(vm => vm.Interaction);
			interact.Bind(DialogTitle).To(vm => vm.TrailName);
			interact.Bind(DialogText).To(vm => vm.TrailDescription);
			interact.Bind(ReadMoreButton).To(vm => vm.ReadMoreCommand);
            interact.Apply();
            
        }      
    
    }
}

