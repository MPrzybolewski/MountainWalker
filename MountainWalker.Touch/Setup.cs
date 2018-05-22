using Google.Maps;
using MountainWalker.Core;
using MountainWalker.Core.Interfaces;
using MountainWalker.Touch.Services;
using MountainWalker.Touch.Bindings;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using UIKit;

namespace MountainWalker.Touch
{
    public class Setup : MvxIosSetup
    {
        /// <summary>Initializes a new instance of the <see cref="Setup"/> class.</summary>
        /// <param name="applicationDelegate">The application delegate.</param>
        /// <param name="window">The window.</param>
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected Setup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter) : base(applicationDelegate, presenter)
        {
        }

        /// <summary>Creates the application.</summary>
        /// <returns>The IMvxApplication <see langword="object"/></returns>
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        /// <summary>Creates the debug trace.</summary>
        /// <returns>The IMvxTrace <see langword="object"/></returns>
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            return new MvxSidebarPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.RegisterSingleton<IDialogService>(() => new IOSDialogService());
        }

		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
            registry.RegisterCustomBindingFactory<MapView>(TrailDialogBinding.BindingName, v => new TrailDialogBinding(v));
            base.FillTargetFactories(registry);
		}
	}
}
