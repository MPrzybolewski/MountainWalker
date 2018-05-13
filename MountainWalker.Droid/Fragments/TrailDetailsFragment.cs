using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MountainWalker.Core.ViewModels;
using MountainWalker.Droid.NavigationDrawer;
using MvvmCross.Droid.Views.Fragments;
using Debug = System.Diagnostics.Debug;

namespace MountainWalker.Droid.Fragments
{
    [DrawerLayoutPresentation(typeof(TrailDetailsFragment), typeof(MainViewModel), Resource.Id.content_frame,
        addToBackStack: true, IsCacheableFragment = true, AddToBackStack = true)]
    [Register("MountainWalker.android.TrailDetailsFragment")]
    public class TrailDetailsFragment : BaseFragment<TrailDetailsViewModel>
    {
        public string LOG = "[SPRAWDZAM CO SIE DZIEJE Z FRAGMENTEM] : ";
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = false;

            //FragmentTransaction ft = this.Activity.FragmentManager.BeginTransaction();
            //ft.AddToBackStack(null);
            //ft.Commit();

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
        
        public override void OnPause()
        {
            base.OnPause();
            Debug.WriteLine(LOG + "onPause");
        }

        public override void OnStop()
        {
            base.OnStop();
            Debug.WriteLine(LOG + "onStop");
        }

        public override void OnResume()
        {
            base.OnResume();
            Debug.WriteLine(LOG + "onResume");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Debug.WriteLine(LOG + "onDestroy");
            
        }

        protected override int FragmentId => Resource.Layout.TrailDetailsView;
    }
}
