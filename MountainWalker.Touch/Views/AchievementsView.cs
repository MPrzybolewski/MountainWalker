using System;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.XamarinSidebar;
using UIKit;

namespace MountainWalker.Touch.Views
{
	[MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
	public partial class AchievementsView : BaseViewController<AchievementsViewModel>
    {      
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

			var source = new MvxSimpleTableViewSource(AchievementsList, "AchievementsCell", AchievementsCell.Key);
			AchievementsList.RowHeight = 80;

			var set = this.CreateBindingSet<AchievementsView, AchievementsViewModel>();         

            set.Bind(source).To(vm => vm.Items);
            set.Apply();

			AchievementsList.Source = source;
			AchievementsList.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

