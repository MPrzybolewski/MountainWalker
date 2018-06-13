using System;

using Foundation;
using MountainWalker.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MountainWalker.Touch.Views
{
	public partial class TrailsCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("TrailsCell");
        public static readonly UINib Nib;

        static TrailsCell()
        {
            Nib = UINib.FromName("TrailsCell", NSBundle.MainBundle);
        }
            
		protected TrailsCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<TrailsCell, Trail>();
				set.Bind(TitleCellText).To(vm => vm.Name);
				set.Bind(DescriptionCellText).To(vm => vm.ShortDescription);
                set.Apply();
            });
        }

    }
}
