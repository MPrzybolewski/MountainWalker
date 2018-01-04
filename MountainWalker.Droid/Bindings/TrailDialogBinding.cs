using System;
using System.Diagnostics;
using System.Reflection;
using Android.Gms.Maps;
using MountainWalker.Core.ViewModels;
using MountainWalker.Droid.Fragments;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace MountainWalker.Droid.Bindings
{
    public class TrailDialogBinding : MvxPropertyInfoTargetBinding<GoogleMap>
    {
        // used to figure out whether a subscription to MyPropertyChanged
        // has been made
        private bool _subscribed;

        private IMvxCommand _command;

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        public TrailDialogBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
        }

        // describes how to set MyProperty on MyView
        protected override void SetValueImpl(object target, object value)
        {
            var view = target as HomeFragment;
            if (view == null) return;

             view.Faken = (string)value;

        }

        // is called when we are ready to listen for change events
        public override void SubscribeToEvents()
        {
            var myView = View;
            if (myView == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - MyView is null in MyViewMyPropertyTargetBinding");
                return;
            }

            _subscribed = true;
            myView.PolylineClick += HandlePolylineClick;
        }

        private void HandlePolylineClick(object sender, GoogleMap.PolylineClickEventArgs poly)
        {
            var myView = View;
            
            if (myView == null) return;

            _command = (IMvxCommand) sender;
            _command.Execute(poly.Polyline.Id);
            //FireValueChanged(myView.MyProperty);
        }

        // clean up
        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);

            if (isDisposing)
            {
                var myView = View;
                if (myView != null && _subscribed)
                {
                    myView.PolylineClick -= HandlePolylineClick;
                    _subscribed = false;
                }
            }
        }
    }
}