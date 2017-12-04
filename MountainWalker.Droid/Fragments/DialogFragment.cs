using Android.App;
using Android.OS;
using MountainWalker.Core.ViewModels;
using MountainWalker.Droid.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace MountainWalker.Droid.Fragments
{
    public class DialogFragment : MvxDialogFragment<DialogViewModel>
    {
        private Dialog _dialog;

        public override Dialog OnCreateDialog(Bundle savedState)
        {
            //base.EnsureBindingContextSet(savedState); //tutaj error NIE DZIALA
            var view = this.BindingInflate(Resource.Layout.MainDialog, null);

            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            _dialog = new Dialog(act);

            _dialog.SetCancelable(true);
            _dialog.SetContentView(view);
            _dialog.Show();

            return base.OnCreateDialog(savedState);
        }
    }
}