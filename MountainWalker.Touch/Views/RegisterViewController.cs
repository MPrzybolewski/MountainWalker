using System;
using System.Diagnostics;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace MountainWalker.Touch.Views
{
    public partial class RegisterViewController : MvxViewController<RegisterViewModel>
    {
        //partial void Clicked(UITapGestureRecognizer sender)
        //{
        //    Debug.WriteLine("Test: kaalal");
        //    UIApplication.SharedApplication.KeyWindow.EndEditing(true);
        //}

        public RegisterViewController() : base("RegisterViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            UIGraphics.BeginImageContext(View.Frame.Size);
            UIImage bgImage = UIImage.FromBundle("Images/gradientbg.png");
            bgImage = bgImage.Scale(View.Frame.Size);
            View.BackgroundColor = UIColor.FromPatternImage(bgImage);
            scrollView.KeyboardDismissMode = UIScrollViewKeyboardDismissMode.Interactive;

            var set = this.CreateBindingSet<RegisterViewController, RegisterViewModel>();
            set.Bind(firstnameEntry).For(s => s.Text).To(vm => vm.Name);
            set.Bind(firstnameEntry).For(s => s.Placeholder).To(vm => vm.NamePlaceholder);
            set.Bind(surnameEntry).To(vm => vm.Surname);
            set.Bind(surnameEntry).For(s => s.Placeholder).To(vm => vm.SurnamePlaceholder);
            set.Bind(loginEntry).To(vm => vm.Login);
            set.Bind(loginEntry).For(s => s.Placeholder).To(vm => vm.LoginPlaceholder);
            set.Bind(passwordEntry).To(vm => vm.Password);
            set.Bind(passwordEntry).For(s => s.Placeholder).To(vm => vm.PasswordPlaceholder);
            set.Bind(rePasswordEntry).To(vm => vm.RepPassword);
            set.Bind(rePasswordEntry).For(s => s.Placeholder).To(vm => vm.PasswordPlaceholder);
            set.Bind(emailEntry).To(vm => vm.Email);
            set.Bind(emailEntry).For(s => s.Placeholder).To(vm => vm.EmailPlaceholder);
            set.Bind(signUpButton).To(vm => vm.RegisterButton);

            set.Apply();
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

