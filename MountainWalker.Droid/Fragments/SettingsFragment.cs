using Android.OS;
using Android.Runtime;
using Android.Views;
using MountainWalker.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views.Attributes;

namespace MountainWalker.Droid.Fragments
{
    [MvxFragmentPresentationAttribute(typeof(MainViewModel), Resource.Id.frameLayout)]
    [Register("MountainWalker.android.SettingsFragment")]
    public class SettingsFragment : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.SettingsView, container, false);
        }
    }

}
