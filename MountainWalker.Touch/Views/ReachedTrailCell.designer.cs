// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MountainWalker.Touch.Views
{
    [Register ("ReachedTrailCell")]
    partial class ReachedTrailCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DateTextCell { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DescriptionTextCell { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DateTextCell != null) {
                DateTextCell.Dispose ();
                DateTextCell = null;
            }

            if (DescriptionTextCell != null) {
                DescriptionTextCell.Dispose ();
                DescriptionTextCell = null;
            }
        }
    }
}