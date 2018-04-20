using Android.OS;
using Android.Runtime;
using Android.Views;
using MountainWalker.Core.ViewModels;
using MountainWalker.Droid.NavigationDrawer;

namespace MountainWalker.Droid.Fragments
{
    [DrawerLayoutPresentation(typeof(AchievementsFragment), typeof(MainViewModel), Resource.Id.content_frame, addToBackStack: true)]
    [Register("MountainWalker.android.ReachedTrailMapFragment")]
    public class ReachedTrailMapFragment : BaseFragment<ReachedTrailMapViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.AchievementsView;
    }
}