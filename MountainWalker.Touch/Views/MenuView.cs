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
      
			var headerView = new UIView();
			headerView.BackgroundColor = UIColor.FromRGB(46, 67, 255);

            
			var avatar = UIImage.FromBundle("Images/" + "mwcircle_small.png");
			var avatarHolder = new UIImageView(avatar);
            
			var userName = new UILabel();
			userName.TextColor = UIColor.White;
			userName.TextAlignment = UITextAlignment.Center;
			userName.Text = "Imie Nazwisko";
			userName.Font = UIFont.BoldSystemFontOfSize(15);

			headerView.AddSubview(avatarHolder);
			headerView.AddSubview(userName);

			var scrollView = new UIScrollView(View.Frame)
			{
				ShowsHorizontalScrollIndicator = false,
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight
            };

            // create a binding set for the appropriate view model
            var set = this.CreateBindingSet<MenuView, MenuViewModel>();

			set.Bind(userName).To(vm => vm.UserName);

            var homeButton = new UIButton(new CGRect(0, 100, 320, 40));
            homeButton.SetTitle("Mapa", UIControlState.Normal);
			homeButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(15);
            homeButton.BackgroundColor = UIColor.White;
            homeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			homeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            set.Bind(homeButton).To(vm => vm.ShowHomeCommand);

            var trailsButton = new UIButton(new CGRect(0, 100, 320, 40));
			trailsButton.SetTitle("Szlaki", UIControlState.Normal);
			trailsButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(15);
			trailsButton.BackgroundColor = UIColor.White;
			trailsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			trailsButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			set.Bind(trailsButton).To(vm => vm.ShowTrailsCommand);

			var achievementsButton = new UIButton(new CGRect(0, 100, 320, 40));
			achievementsButton.SetTitle("Zdobyte szczyty", UIControlState.Normal);
			achievementsButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(15);
			achievementsButton.BackgroundColor = UIColor.White;
			achievementsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			achievementsButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			set.Bind(achievementsButton).To(vm => vm.ShowAchievementsCommand);

			var reachedTrailsButton = new UIButton(new CGRect(0, 100, 320, 40));
			reachedTrailsButton.SetTitle("Przebyte wędrówki", UIControlState.Normal);
			reachedTrailsButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(15);
			reachedTrailsButton.BackgroundColor = UIColor.White;
			reachedTrailsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			reachedTrailsButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			set.Bind(reachedTrailsButton).To(vm => vm.ShowSettingCommand);

			var settingsButton = new UIButton(new CGRect(0, 100, 320, 40));
            settingsButton.SetTitle("Jak to działa?", UIControlState.Normal);
			settingsButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(15);
            settingsButton.BackgroundColor = UIColor.White;
            settingsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			settingsButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            set.Bind(settingsButton).To(vm => vm.ShowTrailsCommand);

            var logoutButton = new UIButton(new CGRect(0, 100, 320, 40));
            logoutButton.SetTitle("Wyloguj", UIControlState.Normal);
			logoutButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(15);
            logoutButton.BackgroundColor = UIColor.White;
            logoutButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			logoutButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            set.Bind(logoutButton).To(vm => vm.ShowSignInCommand);

            set.Apply();         

            Add(headerView);
			Add(scrollView);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();    

			NSLayoutConstraint headerViewTopConstraint = NSLayoutConstraint.Create(headerView, NSLayoutAttribute.Top, NSLayoutRelation.Equal,
																View, NSLayoutAttribute.Top, 1.0f, 0.0f);         
            
			View.AddConstraint(headerViewTopConstraint);
				
			headerView.HeightAnchor.ConstraintEqualTo(180).Active = true;
			headerView.WidthAnchor.ConstraintEqualTo(View.WidthAnchor).Active = true;
			headerView.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;       
            

			headerView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
			avatarHolder.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            
			NSLayoutConstraint avatarTopConstraint = NSLayoutConstraint.Create(avatarHolder, NSLayoutAttribute.Top, NSLayoutRelation.Equal,
                                                                                   headerView, NSLayoutAttribute.Top, 1.0f, 30.0f);

			avatarHolder.WidthAnchor.ConstraintEqualTo(100).Active = true;
			avatarHolder.HeightAnchor.ConstraintEqualTo(100).Active = true;
			avatarHolder.CenterXAnchor.ConstraintEqualTo(headerView.CenterXAnchor).Active = true;
			headerView.AddConstraint(avatarTopConstraint);

			NSLayoutConstraint userNameTopConstraint = NSLayoutConstraint.Create(userName, NSLayoutAttribute.Top, NSLayoutRelation.Equal,
			                                                                     avatarHolder, NSLayoutAttribute.Bottom, 1.0f, 10.0f);

			userName.CenterXAnchor.ConstraintEqualTo(headerView.CenterXAnchor).Active = true;
			userName.WidthAnchor.ConstraintEqualTo(headerView.WidthAnchor).Active = true;
			headerView.AddConstraint(userNameTopConstraint);



            scrollView.Add(homeButton);
			scrollView.Add(trailsButton);
			scrollView.Add(achievementsButton);
			scrollView.Add(reachedTrailsButton);
            scrollView.Add(settingsButton);
            scrollView.Add(logoutButton);

            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			NSLayoutConstraint scrollViewTopConstraint = NSLayoutConstraint.Create(scrollView, NSLayoutAttribute.Top, NSLayoutRelation.Equal,
																				   headerView, NSLayoutAttribute.Bottom, 1.0f, 30.0f);

			NSLayoutConstraint scrollViewBottomConstraint = NSLayoutConstraint.Create(scrollView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal,
			                                                                          View, NSLayoutAttribute.Bottom, 1.0f, 0.0f);

			View.AddConstraint(scrollViewTopConstraint);
			View.AddConstraint(scrollViewBottomConstraint);

			scrollView.WidthAnchor.ConstraintEqualTo(View.WidthAnchor).Active = true;
			scrollView.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;   

            var constraints = scrollView.VerticalStackPanelConstraints(new Margins(20, 10, 20, 10, 5, 20), scrollView.Subviews);
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

