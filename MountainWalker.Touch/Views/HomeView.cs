using System;
using Foundation;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.XamarinSidebar;
using UIKit;

namespace MountainWalker.Touch.Views
{
    [Register("HomeView")]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public class HomeView : BaseViewController<HomeViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var viewModel = this.ViewModel;

        }

        public override void ViewWillAppear(bool animated)
        {
            Title = "Home View";
            base.ViewWillAppear(animated);
        }
    }
}
