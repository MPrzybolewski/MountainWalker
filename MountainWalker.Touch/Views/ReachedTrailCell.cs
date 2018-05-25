using System;

using Foundation;
using MountainWalker.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MountainWalker.Touch.Views
{
	public partial class ReachedTrailCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("ReachedTrailCell");
        public static readonly UINib Nib;

        static ReachedTrailCell()
        {
            Nib = UINib.FromName("ReachedTrailCell", NSBundle.MainBundle);
        }

		protected ReachedTrailCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<ReachedTrailCell, ReachedTrail>();
				set.Bind(DateTextCell).To(vm => vm.Date);
				set.Bind(DescriptionTextCell).To(vm => vm.Desc);
				set.Apply();
			});
		}
    }
}
