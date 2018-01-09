﻿using Android.App;
using Android.OS;
using Android.Runtime;
using MountainWalker.Core.ViewModels;
using MountainWalker.Droid.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace MountainWalker.Droid.Fragments
{
    public class TrailDialogFragment : MvxDialogFragment<TrailDialogViewModel>
    {
        public static Dialog dialog;

        public override Dialog OnCreateDialog(Bundle savedState)
        {
            dialog = base.OnCreateDialog(savedState);

            if (BindingContext == null)
            {
                BindingContext = new MvxAndroidBindingContext(Activity,
                    new MvxSimpleLayoutInflaterHolder(Activity.LayoutInflater), DataContext);
            }

            var view = this.BindingInflate(Resource.Layout.TrailDialog, null);

            dialog.SetContentView(view);
            dialog.SetCancelable(true);

            return dialog;
        }
    }
}