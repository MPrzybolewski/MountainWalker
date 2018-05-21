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
    [Register ("DialogView")]
    partial class DialogView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NearestPointButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StartButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NearestPointButton != null) {
                NearestPointButton.Dispose ();
                NearestPointButton = null;
            }

            if (StartButton != null) {
                StartButton.Dispose ();
                StartButton = null;
            }
        }
    }
}