using System;
using CoreGraphics;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.XamarinSidebar;
using UIKit;

namespace MountainWalker.Touch.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Left, MvxPanelHintType.PushPanel, false)]
    public partial class MenuViewController : BaseViewController<MenuViewModel>
    {
        //public MenuViewController() : base("MenuViewController", null)
        //{
        //}

        public MenuViewController()
        {
        }

        public override void ViewDidLoad()
        {
            var set = this.CreateBindingSet<MenuViewController, MenuViewModel>();
            var homeButton = new UIButton(new CGRect(0, 100, 320, 40));
            homeButton.SetTitle("Home", UIControlState.Normal);
            homeButton.BackgroundColor = UIColor.White;
            homeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(homeButton).To(vm => vm.ShowHomeCommand);

            var settingsButton = new UIButton(new CGRect(0, 100, 320, 40));
            settingsButton.SetTitle("Settings", UIControlState.Normal);
            settingsButton.BackgroundColor = UIColor.White;
            settingsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(settingsButton).To(vm => vm.ShowSettingCommand);

            var logoutButton = new UIButton(new CGRect(0, 100, 320, 40));
            logoutButton.SetTitle("Wyloguj", UIControlState.Normal);
            logoutButton.BackgroundColor = UIColor.White;
            logoutButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(logoutButton).To(vm => vm.ShowSignInCommand);

            set.Apply();

            View.Add(homeButton);
            View.Add(settingsButton);
            View.Add(logoutButton);

            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillAppear(bool animated)
        {
            Title = "Left Menu View";
            base.ViewWillAppear(animated);

            // NavigationController.NavigationBarHidden = true;
        }
    }
}

