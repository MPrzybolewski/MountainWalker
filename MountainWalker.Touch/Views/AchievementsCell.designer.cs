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
    [Register ("AchievementsCell")]
    partial class AchievementsCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DateCellText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleCellText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView TrophyImage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DateCellText != null) {
                DateCellText.Dispose ();
                DateCellText = null;
            }

            if (TitleCellText != null) {
                TitleCellText.Dispose ();
                TitleCellText = null;
            }

            if (TrophyImage != null) {
                TrophyImage.Dispose ();
                TrophyImage = null;
            }
        }
    }
}