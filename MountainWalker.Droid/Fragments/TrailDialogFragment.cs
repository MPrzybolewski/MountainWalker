using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
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
        public Dialog _dialog;

        public override Dialog OnCreateDialog(Bundle savedState)
        {
            _dialog = base.OnCreateDialog(savedState);

            if (BindingContext == null)
            {
                BindingContext = new MvxAndroidBindingContext(Activity,
                    new MvxSimpleLayoutInflaterHolder(Activity.LayoutInflater), DataContext);
            }

            var view = this.BindingInflate(Resource.Layout.TrailDialog, null);

            _dialog.SetContentView(view);
            _dialog.SetCancelable(true);
            _dialog.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));

            return _dialog;
        }
    }
}