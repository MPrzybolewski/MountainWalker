using System;
using System.Drawing;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace MountainWalker.Touch.Views
{
    [Register ("SignInView")]
    public class SignInView : MvxViewController<SignInViewModel>
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.Cyan;

            var scrollView = new UIScrollView(View.Frame)
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight
            };

            // create a binding set for the appropriate view model
            var set = this.CreateBindingSet<SignInView, SignInViewModel>();

            var loginLabel = new UILabel();
            loginLabel.Text = "Podaj login";
            loginLabel.Font.WithSize(36);

            var loginEntry = new UITextField();
            loginEntry.Placeholder = "Login";
            loginEntry.AutocapitalizationType = UITextAutocapitalizationType.None;
            loginEntry.BorderStyle = UITextBorderStyle.RoundedRect;
            set.Bind(loginEntry).To(vm => vm.Login);

            var passwordLabel = new UILabel();
            passwordLabel.Text = "Podaj hasło";
            passwordLabel.Font.WithSize(36);

            var passwordEntry = new UITextField();
            passwordEntry.Placeholder = "Hasło";
            passwordEntry.BorderStyle = UITextBorderStyle.RoundedRect;
            passwordEntry.SecureTextEntry = true;
            set.Bind(passwordEntry).To(vm => vm.Password);

            var loginButton = new UIButton();
            loginButton.BackgroundColor = UIColor.Green;
            loginButton.ShowsTouchWhenHighlighted = true;
            loginButton.SetTitle("Click Me", forState: UIControlState.Normal);
            loginButton.BackgroundImageForState(UIControlState.Selected);
            set.Bind(loginButton).To(vm => vm.SignInButton);

            set.Apply();

            Add(scrollView);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                scrollView.AtLeftOf(View),
                scrollView.AtTopOf(View),
                scrollView.WithSameWidth(View),
                scrollView.WithSameHeight(View));

            scrollView.Add(loginLabel);
            scrollView.Add(loginEntry);
            scrollView.Add(passwordLabel);
            scrollView.Add(passwordEntry);
            scrollView.Add(loginButton);

            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var constraints = scrollView.VerticalStackPanelConstraints(new Margins(20, 10, 20, 10, 5, 5), scrollView.Subviews);
            scrollView.AddConstraints(constraints);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

