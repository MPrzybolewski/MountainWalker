using System;

using Foundation;
using MountainWalker.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MountainWalker.Touch.Views
{
	public partial class AchievementsCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("AchievementsCell");
        public static readonly UINib Nib;

        static AchievementsCell()
        {
			Nib = UINib.FromName("AchievementsCell", NSBundle.MainBundle);
        }

        protected AchievementsCell(IntPtr handle) : base(handle)
        {
			var imageViewLoader = new MvxImageViewLoader(() => TrophyImage);
            
			this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<AchievementsCell, Achievement>();
				set.Bind(imageViewLoader).To(vm => vm.Trophy);
                set.Bind(TitleCellText).To(vm => vm.Name);
                set.Bind(DateCellText).To(vm => vm.Date);
				//set.Bind(TrophyImage).For("image").To(vm => vm.Trophy);
                set.Apply();
            });
        }
    }
}
