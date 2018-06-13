using System;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using MountainWalker.Core.ViewModels;
using MountainWalker.Touch.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace MountainWalker.Touch.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
	public partial class TrailDetailsView : BaseViewController<TrailDetailsViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

                var set = this.CreateBindingSet<TrailDetailsView, TrailDetailsViewModel>();
                set.Bind(TrailTitle).To(vm => vm.TrailTitle);
                set.Bind(TimeUpText).To(vm => vm.TimeUp);
                set.Bind(TimeDownText).To(vm => vm.TimeDown);
                set.Bind(DescriptionText).To(vm => vm.TrailDescription);
                set.Bind(ShortDescriptionText).To(vm => vm.TrailShortDescription);
                set.Bind(TrailImage).For(c => c.Image).To(vm => vm.Image).WithConversion(new TypeToImageValueConverterJPG()).Apply();
                set.Apply();
        }
    }
}

