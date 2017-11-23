using System;
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "View for StartViewModel")]
    public class StartView : MvxActivity
    {
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.StartView);

        }
    }
}
