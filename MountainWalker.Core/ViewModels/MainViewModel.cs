using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace MountainWalker.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {

        public void ShowMenu()
        {
            ShowViewModel<HomeViewModel>();
            ShowViewModel<MenuViewModel>();
        }

        public void ShowHome()
        {
            ShowViewModel<HomeViewModel>();
        }

        public void Init(object hint)
        {
        }

        public override void Start()
        {
            
        }
    }
}