using Android.Content;
using Android.Support.V4.App;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using MvvmCross.Droid.Views.Attributes;

namespace MountainWalker.Droid.NavigationDrawer
{
    public class NavigationDrawerPresenter
       : MvxAppCompatViewPresenter
    {
        private Fragment _currentFragment;

        public NavigationDrawerPresenter(IEnumerable<Assembly> androidViewAssemblies)
            : base(androidViewAssemblies)
        {
        }

        private ConditionalWeakTable<Type, FragmentInfo> Fragments { get; set; }
                            = new ConditionalWeakTable<Type, FragmentInfo>();

        public override void Show(MvxViewModelRequest request)
        {
            if (request?.PresentationValues != null)
            {
                if (request.PresentationValues.ContainsKey("clearBackStack"))
                {
                    ClearFragments();

                    var intent = CreateIntentForRequest(request);
                    intent.SetFlags(ActivityFlags.ClearTask | ActivityFlags.NewTask);
                    ShowIntent(intent);
                    return;
                }
            }

            base.Show(request);
        }

        public override void RegisterAttributeTypes()
        {
            AttributeTypesToActionsDictionary.Add(
                typeof(DrawerLayoutPresentationAttribute),
                new MvxPresentationAttributeAction
                {
                    ShowAction = (view, attribute, request) => ShowDrawerLayoutRelatedFragment(
                        (DrawerLayoutPresentationAttribute)attribute,
                        request)
                });

            base.RegisterAttributeTypes();
        }

        private void ClearFragments()
        {
            Fragments = new ConditionalWeakTable<Type, FragmentInfo>();
            _currentFragment = null;
        }

        private void ShowDrawerLayoutRelatedFragment(DrawerLayoutPresentationAttribute attribute, MvxViewModelRequest request)
        {
            if (Fragments.TryGetValue(attribute.FragmentType, out var _) == false)
            {
                var javaFragmentName = FragmentJavaName(attribute.ViewType);
                var fragment = CreateFragment(attribute, FragmentJavaName(attribute.ViewType));

                    Fragments.Add(attribute.FragmentType, new FragmentInfo
                {
                    FragmentInstance = fragment,
                    ViewModelInstance = (MvxViewModel)((MvxViewModelInstanceRequest)request).ViewModelInstance,
                    JavaFragmentName = javaFragmentName,
                    FragmentContentId = attribute.FragmentContentId
                });
            }

            TryGetAndInvokeFragment(attribute.FragmentType);
        }

        private void TryGetAndInvokeFragment(Type fragmentType)
        {
            if (Fragments.TryGetValue(fragmentType, out var fragmentInfo))
            {
                InvokeFragmentTransaction(fragmentInfo);
            }
        }

        private void InvokeFragmentTransaction(FragmentInfo fragmentInfo)
        {
            if (fragmentInfo.FragmentInstance == _currentFragment)
                return;

            var fragmentTransaction = CurrentFragmentManager.BeginTransaction();
            var fragment = fragmentInfo.FragmentInstance;
            fragment.ViewModel = fragmentInfo.ViewModelInstance;

            if (CurrentFragmentManager.FindFragmentByTag(fragmentInfo.JavaFragmentName) != null)
            {
                fragmentTransaction.Show(CurrentFragmentManager.FindFragmentByTag(
                    fragmentInfo.JavaFragmentName));
            }
            else
            {
                fragmentTransaction.Add(fragmentInfo.FragmentContentId,
                    (Fragment)fragment, fragmentInfo.JavaFragmentName);
            }

            fragmentTransaction.Commit();
            fragmentTransaction = CurrentFragmentManager.BeginTransaction();

            if (_currentFragment != null)
            {
                fragmentTransaction.Hide(_currentFragment);
            }
            fragmentTransaction.Commit();

            _currentFragment = (Fragment)fragment;
            fragmentInfo.ViewModelInstance.ViewAppearing();
        }

        internal class FragmentInfo
        {
            public IMvxFragmentView FragmentInstance { get; set; }
            public MvxViewModel ViewModelInstance { get; set; }
            public string JavaFragmentName { get; set; }
            public int FragmentContentId { get; set; }
        }
    }


}
