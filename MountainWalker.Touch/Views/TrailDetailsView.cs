using System;
using MountainWalker.Core.ViewModels;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace MountainWalker.Touch.Views
{
	[MvxModalPresentation(
        ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext,
        ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal,
        WrapInNavigationController = false
    )]
	public partial class TrailDetailsView : BaseViewController<TrailDetailsViewModel>
    {      
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

