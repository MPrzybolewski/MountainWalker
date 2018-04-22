using Android.Content.Res;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MountainWalker.Droid.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Content;

namespace MountainWalker.Droid.Fragments
{
    public abstract class BaseFragment : MvxFragment
    {
        protected Toolbar Toolbar { get; private set; }
        protected MvxActionBarDrawerToggle DrawerToggle { get; private set; }

        protected bool ShowHamburgerMenu { get; set; } = false;

        protected abstract int FragmentId { get; }

        protected BaseFragment()
        {
            RetainInstance = true;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentId, null);

            Toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
            if(Toolbar != null)
            {
                var mainActivity = Activity as MainView;
                if (mainActivity == null) return view;


                Android.Widget.Button button = view.FindViewById<Android.Widget.Button>(Resource.Id.phoneButton);

                button.Click += delegate {
                    var uri = Android.Net.Uri.Parse("tel:123346678");
                    var intent = new Intent(Intent.ActionDial, uri);
                    StartActivity(intent);
                };

                mainActivity.SetSupportActionBar(Toolbar);

                if(ShowHamburgerMenu)
                {
                    mainActivity.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);

                    DrawerToggle = new MvxActionBarDrawerToggle(Activity, mainActivity.DrawerLayout, Toolbar, Resource.String.drawer_open, Resource.String.drawer_close);

                    DrawerToggle.DrawerOpened += (sender, e) => mainActivity?.HideSoftKeyboard();
                    mainActivity.DrawerLayout.AddDrawerListener(DrawerToggle);
                }
            }
            return view;
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (Toolbar != null)
            {
                DrawerToggle?.OnConfigurationChanged(newConfig);
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            if (Toolbar != null)
            {
                DrawerToggle?.SyncState();
            }
        }

    }


    public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }




}
