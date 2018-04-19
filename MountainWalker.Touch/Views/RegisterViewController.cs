using System;
using MountainWalker.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace MountainWalker.Touch.Views
{
    public partial class RegisterViewController : MvxViewController<RegisterViewModel>
    {
        public RegisterViewController() : base("RegisterViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            UIGraphics.BeginImageContext(View.Frame.Size);
            UIImage bgImage = UIImage.FromBundle("Images/gradientbg.png");
            bgImage = bgImage.Scale(View.Frame.Size);
            View.BackgroundColor = UIColor.FromPatternImage(bgImage);
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

		public override void ViewWillAppear(bool animated)
		{
            base.ViewDidAppear(animated);
            NavigationController.NavigationBarHidden = false;
		}

		public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

