﻿using Android.OS;
using Android.Runtime;
using Android.Views;
using MountainWalker.Core.ViewModels;
using MvvmCross.Droid.Views.Attributes;

namespace MountainWalker.Droid.Fragments
{
    [MvxFragmentPresentationAttribute(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("MountainWalker.android.SettingsFragment")]
    public class SettingsFragment : BaseFragment<SettingsViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.SettingsView;
    }

}
