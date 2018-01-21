using Android.OS;
using Android.Runtime;
using Android.Views;
using MountainWalker.Core.ViewModels;
using MountainWalker.Droid.NavigationDrawer;

namespace MountainWalker.Droid.Fragments
{
    [DrawerLayoutPresentation(typeof(TrailDetailsFragment), typeof(MainViewModel), Resource.Id.content_frame,
        addToBackStack: false)]
    [Register("MountainWalker.android.TrailDetailsFragment")]
    public class TrailDetailsFragment : BaseFragment<TrailDetailsViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.TrailDetailsView;
    }
}
