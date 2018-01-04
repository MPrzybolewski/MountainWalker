using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Plugin.Geolocator;
using System;
using System.Threading.Tasks;
using MvvmCross.Droid.Support.V7.AppCompat;
using MountainWalker.Core.ViewModels;
using Android.Support.V7.App;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using System.Linq;
using Android.Content.PM;
using Debug = System.Diagnostics.Debug;
using Android.Support.V4.View;
using Android.Views.InputMethods;
using MountainWalker.Droid.NavigationDrawer;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MountainWalker.Droid.Fragments;

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "View for MainViewModel",
              NoHistory = true,
              Theme = "@style/MyTheme",
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
         public DrawerLayout DrawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

            if(bundle == null)
            {
                ViewModel.ShowMenu();
            }

        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }


        private void ShowBackButton()
        {
            DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);
        }

        private void ShowHamburguerMenu()
        {
            DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeUnlocked);
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
                DrawerLayout.CloseDrawers();
            else
                base.OnBackPressed();
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null) return;

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }


    }
}
