using System;
using MountainWalker.Core.Interfaces;
using MvvmCross.Platform;
using UIKit;

namespace MountainWalker.Touch.Services
{
    public class IOSDialogService : IDialogService
    {
        

        public void ShowAlert(string title, string message, string okButtonText)
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;

            var okAlertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            //Add Action
            okAlertController.AddAction(UIAlertAction.Create(okButtonText, UIAlertActionStyle.Default, null));

            // Present Alert
            vc.PresentViewController(okAlertController, true, null);
        }

        public void ShowWaitingAlert(string message)
        {
            throw new NotImplementedException();
        }

        public void WaitingAlertDismiss()
        {
            throw new NotImplementedException();
        }
    }
}
