using System;
using Foundation;
using MountainWalker.Core.ViewModels;
using MvvmCross.iOS.Support.XamarinSidebar;

namespace MountainWalker.Touch.Views
{
    [Register("SettingsView")]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.PopToRoot, true)]
    public class SettingsView : BaseViewController<SettingsViewModel>
    {
        public override void ViewWillAppear(bool animated)
        {
            Title = "Settings View";
            base.ViewWillAppear(animated);
        }
    }
}
