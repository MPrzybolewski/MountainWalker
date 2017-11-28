﻿using Android.App;
using Android.OS;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace MountainWalker.Droid.Fragments
{
    public class MySettingsFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.MySettingsView, container, false);
        }
    }

}