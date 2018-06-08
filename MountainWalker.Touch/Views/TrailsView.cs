using System;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
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

			var source = new MvxSimpleTableViewSource(TrailsList, "TrailsCell", TrailsCell.Key);
			TrailsList.RowHeight = 100;

            var set = this.CreateBindingSet<TrailsView, TrailsViewModel>();
            
            
            set.Bind(source).To(vm => vm.Items);
			set.Bind(source).For("ItemClick").To(vm => vm.ShowDetailTrail);
            set.Apply();

			TrailsList.Source = source;
			TrailsList.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

