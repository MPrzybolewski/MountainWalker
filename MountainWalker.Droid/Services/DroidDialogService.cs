using System;
using Android.App;
using MountainWalker.Core.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace MountainWalker.Droid.Services
{
    public class DroidDialogService : IDialogService
    {
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


    }
}
