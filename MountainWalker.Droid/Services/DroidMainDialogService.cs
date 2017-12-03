using System;
using System.Diagnostics;
using Android.App;
using Android.Views;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace MountainWalker.Droid.Services
{
    public class DroidMainDialogService : IMainDialogService
    {
        private Dialog _dialog;

        public void Show(string pointName, bool canStart)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            _dialog = new Dialog(act);

            _dialog.SetCancelable(true);
            _dialog.SetContentView(Resource.Layout.MainDialog);

            _dialog.Show();
        }

        public void Close()
        {
            Debug.WriteLine("In droid service");
            _dialog.Dismiss();
        }
    }
}