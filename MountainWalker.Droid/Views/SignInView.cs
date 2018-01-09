using System;
using Android.App;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using MvvmCross.Droid.Views;
using Acr.UserDialogs;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "View for SignInViewModel",
        ConfigurationChanges = ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignInView : MvxActivity
    {
        //public MediaPlayer _mediaPlayer;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            UserDialogs.Init(() => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);

            //_mediaPlayer = MediaPlayer.Create(this, Resource.Raw.background);
            //_mediaPlayer.Start(); panowie, ile mozna? XD
            SetContentView(Resource.Layout.SignInView);

        }
    }
}
