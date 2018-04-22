
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views.Attributes;

namespace MountainWalker.Droid.NavigationDrawer
{
    public class DrawerLayoutPresentationAttribute
    : MvxFragmentPresentationAttribute
    {
        public DrawerLayoutPresentationAttribute(Type fragmentType, Type activityHostViewModelType, int fragmentContentId, bool addToBackStack)
            : base(activityHostViewModelType, fragmentContentId, true)
        {
            FragmentType = fragmentType;
            this.AddToBackStack = addToBackStack;
        }

        public Type FragmentType { get; }
    }
}
