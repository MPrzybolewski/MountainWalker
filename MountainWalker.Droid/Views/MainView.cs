using System.ComponentModel;
using Android.App;
using Android.OS;
using Android.Test;
using MountainWalker.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
        
    }
}
