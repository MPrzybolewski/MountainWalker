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
    public class LoginView : MvxActivity<LoginViewModel>, Core.Services.Intefraces.TestService
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginView);
        }

        public void DoNothing(int x)
        {
            //tylko test
            //fajnie, ze jest interfejs, bo chce te same funkcje w android i iOS, ale potrzebuje danych z viewModel
        }
        //tutaj chcialbym brac zmienne Login i Passowrd zeby tutaj je wrzucic do bazy i tak dalej. Jezeli sie nie da, to po co nam ten mvvmcross?

        //public string testlogin = Login; // tak sie nie da
    }
}