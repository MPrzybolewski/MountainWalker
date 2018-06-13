// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MountainWalker.Touch.Views
{
    [Register ("TrailDetailsView")]
    partial class TrailDetailsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DescriptionText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DistanceText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ShortDescriptionText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TimeDownText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TimeUpText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView TrailImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TrailTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DescriptionText != null) {
                DescriptionText.Dispose ();
                DescriptionText = null;
            }

            if (DistanceText != null) {
                DistanceText.Dispose ();
                DistanceText = null;
            }

            if (ShortDescriptionText != null) {
                ShortDescriptionText.Dispose ();
                ShortDescriptionText = null;
            }

            if (TimeDownText != null) {
                TimeDownText.Dispose ();
                TimeDownText = null;
            }

            if (TimeUpText != null) {
                TimeUpText.Dispose ();
                TimeUpText = null;
            }

            if (TrailImage != null) {
                TrailImage.Dispose ();
                TrailImage = null;
            }

            if (TrailTitle != null) {
                TrailTitle.Dispose ();
                TrailTitle = null;
            }
        }
    }
}