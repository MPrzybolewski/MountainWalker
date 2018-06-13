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
    [Register ("TrailsCell")]
    partial class TrailsCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DescriptionCellText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleCellText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DescriptionCellText != null) {
                DescriptionCellText.Dispose ();
                DescriptionCellText = null;
            }

            if (TitleCellText != null) {
                TitleCellText.Dispose ();
                TitleCellText = null;
            }
        }
    }
}