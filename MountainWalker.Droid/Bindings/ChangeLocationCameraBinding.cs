using System;
using Android.Gms.Maps;
using MountainWalker.Core.Models;
using MountainWalker.Core.Services;
using MvvmCross.Binding;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Droid.Bindings
{
    public class ChangeLocationCameraBinding : MvxAndroidTargetBinding
    {
        private readonly LocationService _location;
        private bool _subscribed;
        private IMvxCommand<Point> _command;
        
        public ChangeLocationCameraBinding(object target)
            : base(target)
        {
            _location = target as LocationService;
        }

        public static string BindingName => "ChangeLocationCameraBinding";
        public override Type TargetType => typeof(LocationService);

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
        public override void SubscribeToEvents()
        {
            if (_location == null)
                return;

            _location.CurrentLocationChanged += HandleCurrentLocationCameraChanged;
            _subscribed = true;
        }

        protected override void SetValueImpl(object target, object value)
        {
            _command = value as MvxCommand<Point>;
        }
        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);

            if (isDisposing)
            {
                if (_location == null || _subscribed == false)
                    return;

                _location.CurrentLocationChanged -= HandleCurrentLocationCameraChanged;
                _subscribed = false;
            }
        }

        private void HandleCurrentLocationCameraChanged(object sender, LocationEventArgs loc)
        {
            _command.Execute(loc.Location);
        }
    }
}