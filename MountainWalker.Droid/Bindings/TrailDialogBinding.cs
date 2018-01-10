using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.ViewModels;
using MountainWalker.Droid.Fragments;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace MountainWalker.Droid.Bindings
{
    public class TrailDialogBinding : MvxAndroidTargetBinding
    {
        private readonly GoogleMap _googleMap;
        private bool _subscribed;
        private IMvxAsyncCommand<int> _command;
        
        public TrailDialogBinding(object target)
            : base(target)
        {
            _googleMap = target as GoogleMap;
        }

        public static string BindingName => "TrailDialogBinding";
        public override Type TargetType => typeof(GoogleMap);

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
        public override void SubscribeToEvents()
        {
            if (_googleMap == null)
                return;

            _googleMap.PolylineClick += HandlePolylineClick;
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

                _googleMap.PolylineClick -= HandlePolylineClick;
                _subscribed = false;
            }
        }

        private async void HandlePolylineClick(object sender, GoogleMap.PolylineClickEventArgs poly)
        {
            int id = int.Parse(poly.Polyline.Id.Trim(new Char[] { 'p', 'l' }));
            await _command.ExecuteAsync(id);
        }
    }
}