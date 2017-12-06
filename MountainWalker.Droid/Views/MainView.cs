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

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "View for MainViewModel", NoHistory = true,
        ConfigurationChanges = ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
        ActionBarDrawerToggle _drawerToggle;
        ListView _drawerListView;
        DrawerLayout _drawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Mountain Walker";

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            _drawerListView = FindViewById<ListView>(Resource.Id.drawerListView);
            _drawerListView.ItemClick += (sender, e) => ShowFragmentAt(e.Position);
            _drawerListView.Adapter = new ArrayAdapter<string>(this, global::Android.Resource.Layout.SimpleListItem1, ViewModel.MenuItems.ToArray());

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

            _drawerToggle = new ActionBarDrawerToggle(this, _drawerLayout, Resource.String.OpenDrawerString, Resource.String.CloseDrawerString);

            _drawerLayout.SetDrawerListener(_drawerToggle);

            ShowFragmentAt(0);
        }

        void ShowFragmentAt(int position)
        {
            ViewModel.NavigateTo(position);

            Title = ViewModel.MenuItems.ElementAt(position);
 
            _drawerLayout.CloseDrawer (_drawerListView);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            _drawerToggle.SyncState();

            base.OnPostCreate(savedInstanceState);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (_drawerToggle.OnOptionsItemSelected(item))
                return true;

            return base.OnOptionsItemSelected(item);
        }
    }
}
