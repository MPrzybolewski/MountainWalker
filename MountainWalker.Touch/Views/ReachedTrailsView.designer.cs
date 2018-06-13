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
    [Register ("ReachedTrailsView")]
    partial class ReachedTrailsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TrailsList { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TrailsList != null) {
                TrailsList.Dispose ();
                TrailsList = null;
            }
        }
    }
}