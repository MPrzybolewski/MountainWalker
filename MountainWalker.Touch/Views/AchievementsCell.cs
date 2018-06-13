using System;

using Foundation;
using MountainWalker.Core.Models;
using MountainWalker.Touch.Models;
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
			this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<AchievementsCell, Achievement>();
                
                set.Bind(TitleCellText).To(vm => vm.Name);
                set.Bind(DateCellText).To(vm => vm.Date);
				//set.Bind(imageViewLoader).To(vm => vm.Trophy).WithConversion("TypeToImage");
				//set.Bind(imageViewLoader).To(vm => vm.Trophy);            
				set.Bind(TrophyImage).For(c => c.Image).To(vm => vm.Trophy).WithConversion(new TypeToImageValueConverterPNG()).Apply();
                set.Apply();
            });
        }
    }
}
