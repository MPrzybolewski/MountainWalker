using System;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.XamarinSidebar;
using UIKit;

namespace MountainWalker.Touch.Views
{
	[MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
	public partial class ReachedTrailsView : BaseViewController<ReachedTrailsViewModel>
    {      
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			var source = new MvxSimpleTableViewSource(TrailsList, "ReachedTrailCell", ReachedTrailCell.Key);
            TrailsList.RowHeight = 60;

			var set = this.CreateBindingSet<ReachedTrailsView, ReachedTrailsViewModel>();


            set.Bind(source).To(vm => vm.Items);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowReachedTrail);
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

