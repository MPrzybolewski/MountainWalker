using System;
using System.Diagnostics;
using Android.App;
using Android.Media;
using MountainWalker.Core.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace MountainWalker.Droid.Services
{
    public class DroidDialogService : IDialogService
    {
        private static AlertDialog.Builder _dialog;
        private string tescik = "nic";

        public void ShowAlert(string title, string message, string okButtonText)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(title);
            adb.SetMessage(message);
            adb.SetPositiveButton(okButtonText, (sender, args) => { /* some logic */ });
            adb.Create().Show();
        }

        public void ShowWaitingAlert(string message)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            _dialog = new AlertDialog.Builder(act);
            _dialog.SetMessage(message);
            _dialog.Create().Show();
            tescik = "wariat";
        }

        public void WaitingAlertDismiss()
        {
            _dialog.Dispose();
            Debug.WriteLine("a se wylaczam, a string to " + tescik);
        }
    }
}
