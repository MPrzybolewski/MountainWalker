using System;

using Foundation;
using UIKit;

namespace MountainWalker.Touch.Views
{
    public partial class TrailsCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("TrailsCell");
        public static readonly UINib Nib;

        static TrailsCell()
        {
            Nib = UINib.FromName("TrailsCell", NSBundle.MainBundle);
        }

        protected TrailsCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
