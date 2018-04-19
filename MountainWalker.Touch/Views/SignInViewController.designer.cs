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
    [Register ("SignInViewController")]
    partial class SignInViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton buttonSignIn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField loginEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton registerButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch rememberCheck { get; set; }

        [Action ("Clicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Clicked (UIKit.UITapGestureRecognizer sender);

        void ReleaseDesignerOutlets ()
        {
            if (buttonSignIn != null) {
                buttonSignIn.Dispose ();
                buttonSignIn = null;
            }

            if (loginEntry != null) {
                loginEntry.Dispose ();
                loginEntry = null;
            }

            if (passwordEntry != null) {
                passwordEntry.Dispose ();
                passwordEntry = null;
            }

            if (registerButton != null) {
                registerButton.Dispose ();
                registerButton = null;
            }

            if (rememberCheck != null) {
                rememberCheck.Dispose ();
                rememberCheck = null;
            }
        }
    }
}