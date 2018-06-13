using System;
using Foundation;
using MountainWalker.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace MountainWalker.Touch.Views
{
    /// <summary>
    /// A base view controller 
    /// </summary>
    public class BaseViewController<TViewModel> : MvxViewController<TViewModel> where TViewModel : class, IMvxViewModel
    {
        #region Fields

        protected bool NavigationBarEnabled = false;

        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        #endregion
        
        #region Public Methods
        
        public override void ViewDidLoad()
        {
            EdgesForExtendedLayout = UIRectEdge.None;
            View.BackgroundColor = UIColor.White;
            base.ViewDidLoad(); 

			var phoneImage = UIImage.FromBundle("phone");
			NavigationItem.RightBarButtonItem = new UIBarButtonItem(phoneImage, UIBarButtonItemStyle.Bordered, PhoneButtonClick);         
        }

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);         
		}

		void PhoneButtonClick(object sender, EventArgs e)
		{
			var url = new NSUrl("tel:123346678");
            UIApplication.SharedApplication.OpenUrl(url);
		}

		#endregion
	}
}
