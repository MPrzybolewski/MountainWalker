﻿using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MountainWalker.Core.ViewModels;
using MountainWalker.Droid.NavigationDrawer;

namespace MountainWalker.Droid.Fragments
{
    [DrawerLayoutPresentation(typeof(TrailsFragment), typeof(MainViewModel), Resource.Id.content_frame, addToBackStack: false)]
    [Register("MountainWalker.android.TrialsFragment")]
    public class TrailsFragment : BaseFragment<TrailsViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.TrailsView;
    }
}
