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
    [Register ("HomeView")]
    partial class HomeView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Google.Maps.MapView MyMap { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PointsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StartButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TimeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MyMap != null) {
                MyMap.Dispose ();
                MyMap = null;
            }

            if (PointsLabel != null) {
                PointsLabel.Dispose ();
                PointsLabel = null;
            }

            if (StartButton != null) {
                StartButton.Dispose ();
                StartButton = null;
            }

            if (TimeLabel != null) {
                TimeLabel.Dispose ();
                TimeLabel = null;
            }
        }
    }
}