using System;
using Cirrious.FluentLayouts.Touch;
using MountainWalker.Core.ViewModels;
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

            AdjustUITextViewHeight(DescriptionText);

            var set = this.CreateBindingSet<TrailDetailsView, TrailDetailsViewModel>();
            set.Bind(TrailTitle).To(vm => vm.TrailTitle);
            set.Bind(TimeUpText).To(vm => vm.TimeUp);
            set.Bind(TimeDownText).To(vm => vm.TimeDown);
            set.Apply();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void AdjustUITextViewHeight(UILabel textView)
        {
            textView.TranslatesAutoresizingMaskIntoConstraints = true;
            textView.SizeToFit();
        }
    }
}

