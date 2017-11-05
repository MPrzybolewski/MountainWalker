using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MountainWalker.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "Login Page")]
    public class LoginView : MvxActivity, Core.Services.Intefraces.TestService
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginView);
        }

        public void DoNothing(int x)
        {
            
        }
    }
}