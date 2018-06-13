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
    [Register ("SettingsView")]
    partial class SettingsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Google.Maps.MapView MyMap { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MyMap != null) {
                MyMap.Dispose ();
                MyMap = null;
            }
        }
    }
}