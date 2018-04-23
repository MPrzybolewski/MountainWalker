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
    [Register ("RegisterViewController")]
    partial class RegisterViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField emailEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField firstnameEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField loginEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField rePasswordEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrollView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel shortLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton signUpButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField surnameEntry { get; set; }

        [Action("Clicked:")]
        [GeneratedCode("iOS Designer", "1.0")]
        partial void Clicked(UIKit.UITapGestureRecognizer sender);

        void ReleaseDesignerOutlets ()
        {
            if (emailEntry != null) {
                emailEntry.Dispose ();
                emailEntry = null;
            }

            if (firstnameEntry != null) {
                firstnameEntry.Dispose ();
                firstnameEntry = null;
            }

            if (loginEntry != null) {
                loginEntry.Dispose ();
                loginEntry = null;
            }

            if (passwordEntry != null) {
                passwordEntry.Dispose ();
                passwordEntry = null;
            }

            if (rePasswordEntry != null) {
                rePasswordEntry.Dispose ();
                rePasswordEntry = null;
            }

            if (scrollView != null) {
                scrollView.Dispose ();
                scrollView = null;
            }

            if (shortLabel != null) {
                shortLabel.Dispose ();
                shortLabel = null;
            }

            if (signUpButton != null) {
                signUpButton.Dispose ();
                signUpButton = null;
            }

            if (surnameEntry != null) {
                surnameEntry.Dispose ();
                surnameEntry = null;
            }
        }
    }
}