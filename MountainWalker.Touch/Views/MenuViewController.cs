using System;
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
            //set.Bind(homeButton).To(vm => vm.ShowHomeCommand);
            //set.Bind(settingsButton).To(vm => vm.ShowSettingCommand);
            //set.Bind(logoutButton).To(vm => vm.ShowSignInCommand);

            set.Apply();
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

