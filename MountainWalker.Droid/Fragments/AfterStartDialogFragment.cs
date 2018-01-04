
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;

namespace MountainWalker.Droid.Fragments
{

    public class AfterStartDialogFragment : MvxDialogFragment<AfterStartDialogViewModel>
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

            var view = this.BindingInflate(Resource.Layout.AfterStartDialogView, null);

            dialog.SetContentView(view);
            dialog.SetCancelable(true);

            return dialog;
        }
    }
}
