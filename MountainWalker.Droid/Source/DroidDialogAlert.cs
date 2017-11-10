using Android.App;

using MountainWalker.Core.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace MountainWalker.Droid.Source
{
    public class DroidDialogAlert : IDialogService
    {
        public void Alert(string title, string message, string okButtonText)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(title);
            adb.SetMessage(message);
            adb.SetPositiveButton("Ok", (s, ev) => { });
            adb.Create().Show();
        }
    }
}