﻿using System;
using CoreGraphics;
using Foundation;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Support.XamarinSidebar;
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
    public partial class DialogView : BaseViewController<DialogViewModel>
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

			var interact = this.CreateBindingSet<DialogView, DialogViewModel>();
            interact.Bind(this).For(v => v.Interaction).To(vm => vm.Interaction);
			interact.Bind(StartButton).To(vm => vm.TrailStartCommand);
			interact.Bind(NearestPointButton).To(vm => vm.NearestPointCommand);
			interact.Bind(DialogTitle).To(vm => vm.TrailTitle);
			interact.Bind(DialogText).To(vm => vm.TrailInfo);         
            interact.Apply();
            
        }      
	
    }
}

