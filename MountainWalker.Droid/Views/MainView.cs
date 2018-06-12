using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MountainWalker.Core.ViewModels;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Content.PM;
using Debug = System.Diagnostics.Debug;
using Android.Support.V4.View;
using Android.Views.InputMethods;
using MvvmCross.Platform;
using Android.Media;
using Acr.UserDialogs;
using MvvmCross.Platform.Droid.Platform;

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "",
              NoHistory = false,
              Theme = "@style/MyTheme",
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait
        )]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
        public DrawerLayout DrawerLayout;
        public View TrailDetailFragment;

        public MediaPlayer _mediaPlayer;
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);

            UserDialogs.Init(() => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
            //_mediaPlayer = MediaPlayer.Create(this, Resource.Raw.background_main);
            //_mediaPlayer.Start();
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
            FragmentManager fm = FragmentManager;
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
            {
                DrawerLayout.CloseDrawers();
            }
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null) return;

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }

        public override void OnSaveInstanceState(Bundle outState, PersistableBundle outPersistentState)
        {
            base.OnSaveInstanceState(outState, outPersistentState);
        }

        public override void OnRestoreInstanceState(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnRestoreInstanceState(savedInstanceState, persistentState);
        }

        protected override void OnDestroy()
        {   
            base.OnDestroy();
            Finish();
        }
    }
}
