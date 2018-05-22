using System;
using Google.Maps;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MountainWalker.Touch.Bindings
{
    public class TrailDialogBinding : MvxConvertingTargetBinding
    {
        private readonly MapView _googleMap;
        private bool _subscribed;
        private IMvxAsyncCommand<int> _command;

        public TrailDialogBinding(object target)
            : base(target)
        {
            _googleMap = target as MapView;
        }

        public static string BindingName => "TrailDialogBinding";
        public override Type TargetType => typeof(MapView);

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
        public override void SubscribeToEvents()
        {
            if (_googleMap == null)
                return;

            _googleMap.OverlayTapped += HandlePolylineClick;

            _subscribed = true;
        }

        protected override void SetValueImpl(object target, object value)
        {
            _command = value as MvxAsyncCommand<int>;
        }
        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);

            if (isDisposing)
            {
                if (_googleMap == null || _subscribed == false)
                    return;

                _googleMap.OverlayTapped -= HandlePolylineClick;
                _subscribed = false;
            }
        }

        private async void HandlePolylineClick(object sender, GMSOverlayEventEventArgs poly)
        {

            string test = poly.Overlay.Description;
                int id = 1;
            await _command.ExecuteAsync(id);
        }
    }
}
