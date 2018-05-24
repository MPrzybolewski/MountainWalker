using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using MountainWalker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.XamarinSidebar;
using UIKit;

namespace MountainWalker.Touch.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Left, MvxPanelHintType.PushPanel,false)]
	public partial class MenuView : BaseViewController<MenuViewModel>
    {
        public MenuView()
        { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();         

			var scrollView = new UIScrollView(View.Frame)
			{
				ShowsHorizontalScrollIndicator = false,
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight,
				BackgroundColor = UIColor.Blue
            };

            // create a binding set for the appropriate view model
            var set = this.CreateBindingSet<MenuView, MenuViewModel>();
            

            var homeButton = new UIButton(new CGRect(0, 100, 320, 40));
            homeButton.SetTitle("Mapa", UIControlState.Normal);
            homeButton.BackgroundColor = UIColor.White;
            homeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(homeButton).To(vm => vm.ShowHomeCommand);

            var trailsButton = new UIButton(new CGRect(0, 100, 320, 40));
			trailsButton.SetTitle("Szlaki", UIControlState.Normal);
			trailsButton.BackgroundColor = UIColor.White;
			trailsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			set.Bind(trailsButton).To(vm => vm.ShowTrailsCommand);

			var achievementsButton = new UIButton(new CGRect(0, 100, 320, 40));
			achievementsButton.SetTitle("Zdobyte szczyty", UIControlState.Normal);
			achievementsButton.BackgroundColor = UIColor.White;
			achievementsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			set.Bind(achievementsButton).To(vm => vm.ShowAchievementsCommand);

			var reachedTrailsButton = new UIButton(new CGRect(0, 100, 320, 40));
			reachedTrailsButton.SetTitle("Przebyte wędrówki", UIControlState.Normal);
			reachedTrailsButton.BackgroundColor = UIColor.White;
			reachedTrailsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			set.Bind(reachedTrailsButton).To(vm => vm.ShowSettingCommand);

			var settingsButton = new UIButton(new CGRect(0, 100, 320, 40));
            settingsButton.SetTitle("Szlaki", UIControlState.Normal);
            settingsButton.BackgroundColor = UIColor.White;
            settingsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(settingsButton).To(vm => vm.ShowTrailsCommand);

            var logoutButton = new UIButton(new CGRect(0, 100, 320, 40));
            logoutButton.SetTitle("Wyloguj", UIControlState.Normal);
            logoutButton.BackgroundColor = UIColor.White;
            logoutButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(logoutButton).To(vm => vm.ShowSignInCommand);

            set.Apply();

            Add(scrollView);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                scrollView.AtLeftOf(View),
                scrollView.AtTopOf(View),
                scrollView.WithSameWidth(View),
                scrollView.WithSameHeight(View));

            scrollView.Add(homeButton);
			scrollView.Add(trailsButton);
			scrollView.Add(achievementsButton);
			scrollView.Add(reachedTrailsButton);
            scrollView.Add(settingsButton);
            scrollView.Add(logoutButton);

            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var constraints = scrollView.VerticalStackPanelConstraints(new Margins(20, 10, 20, 10, 5, 5), scrollView.Subviews);
            scrollView.AddConstraints(constraints);
        }

        public override void ViewWillAppear(bool animated)
        {
            Title = "Left Menu View";
            base.ViewWillAppear(animated);

            // NavigationController.NavigationBarHidden = true;
        }
    }
}

