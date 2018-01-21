
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;
using MvvmCross.Platform.Core;

namespace MountainWalker.Droid.Fragments
{

    public class AfterStartDialogFragment : MvxDialogFragment<AfterStartDialogViewModel>
    {
        private Dialog _dialog;
        
        private IMvxInteraction<bool> _visible;
        public IMvxInteraction<bool> Interaction
        {
            get => _visible;
            set
            {
                if (_visible != null)
                    _visible.Requested -= CloseDialogHandler;
            
                _visible = value;
                _visible.Requested += CloseDialogHandler;
            }
        }

        private void CloseDialogHandler(object sender, MvxValueEventArgs<bool> visible)
        {
            if (!visible.Value)
                _dialog.Dismiss();
        }

        public override Dialog OnCreateDialog(Bundle savedState)
        {
            _dialog = base.OnCreateDialog(savedState);

            if (BindingContext == null)
            {
                BindingContext = new MvxAndroidBindingContext(Activity,
                    new MvxSimpleLayoutInflaterHolder(Activity.LayoutInflater), DataContext);
            }

            var view = this.BindingInflate(Resource.Layout.AfterStartDialogView, null);

            _dialog.SetContentView(view);
            _dialog.SetCancelable(true);
            _dialog.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
            
            var interact = this.CreateBindingSet<AfterStartDialogFragment, AfterStartDialogViewModel>();
            interact.Bind(this).For(v => v.Interaction).To(viewModel => viewModel.Interaction);
            interact.Apply();

            return _dialog;
        }
    }
}
