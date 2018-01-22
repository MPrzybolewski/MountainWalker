using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using MountainWalker.Droid.NavigationDrawer;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "View for StartViewModel",
        ConfigurationChanges = ConfigChanges.Orientation, 
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class StartView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.StartView);
            //var intent = new Intent(this, typeof(MainView));
            //intent.SetFlags(ActivityFlags.NewTask);
            //StartActivity(intent);
            Finish();

            // var presenter = (NavigationDrawerPresenter)Mvx.Resolve<IMvxAndroidViewPresenter>();
            // presenter.RegisterAttributeTypes();
        }

    }
}
