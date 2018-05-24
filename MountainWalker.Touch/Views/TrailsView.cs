using System;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.XamarinSidebar;
using UIKit;

namespace MountainWalker.Touch.Views
{
	[MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public partial class TrailsView : BaseViewController<TrailsViewModel>
    {      
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<TrailsView, TrailsViewModel>();
            
            
            set.Bind(TrailsList).For("ItemsSource").To(vm => vm.Items);
			set.Bind(TrailsList).For("ItemClick").To(vm => vm.ShowDetailTrail);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

