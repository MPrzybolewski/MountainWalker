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
    [Register ("ReachedTrailMapView")]
    partial class ReachedTrailMapView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel BeginText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FinishedText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel KmText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Google.Maps.MapView MyMap { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StartText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StopText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TimeText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BeginText != null) {
                BeginText.Dispose ();
                BeginText = null;
            }

            if (FinishedText != null) {
                FinishedText.Dispose ();
                FinishedText = null;
            }

            if (KmText != null) {
                KmText.Dispose ();
                KmText = null;
            }

            if (MyMap != null) {
                MyMap.Dispose ();
                MyMap = null;
            }

            if (StartText != null) {
                StartText.Dispose ();
                StartText = null;
            }

            if (StopText != null) {
                StopText.Dispose ();
                StopText = null;
            }

            if (TimeText != null) {
                TimeText.Dispose ();
                TimeText = null;
            }
        }
    }
}