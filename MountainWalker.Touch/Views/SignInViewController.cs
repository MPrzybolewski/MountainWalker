using System;
using System.Diagnostics;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace MountainWalker.Touch.Views
{
    public partial class SignInViewController : MvxViewController<SignInViewModel>
    {
        partial void Clicked(UITapGestureRecognizer sender)
        {
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
        }

        public SignInViewController() : base("SignInViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIGraphics.BeginImageContext(View.Frame.Size);
            UIImage bgImage = UIImage.FromBundle("Images/loginbg.jpg");
            bgImage = bgImage.Scale(View.Frame.Size);
            View.BackgroundColor = UIColor.FromPatternImage(bgImage);

            var set = this.CreateBindingSet<SignInViewController, SignInViewModel>();
            set.Bind(loginEntry).To(vm => vm.Login);
            set.Bind(passwordEntry).To(vm => vm.Password);
            set.Bind(buttonSignIn).To(vm => vm.SignInButton);
            set.Bind(rememberCheck).To(vm => vm.IsChecked);
            set.Bind(registerButton).To(vm => vm.RegisterButton);

            set.Apply();

            // Perform any additional setup after loading the view, typically from a nib.
        }

		public override void ViewWillAppear(bool animated)
		{
            NavigationController.NavigationBarHidden = true;
			base.ViewWillAppear(animated);
		}

		public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

