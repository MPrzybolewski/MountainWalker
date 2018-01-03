using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using MountainWalker.Core.Interfaces;
using MountainWalker.Droid.Services;
using MountainWalker.Droid.Views;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MountainWalker.Droid.NavigationDrawer;

namespace MountainWalker.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }

        protected override void InitializeLastChance()
        {
            //CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            base.InitializeLastChance();
            //Mvx.LazyConstructAndRegisterSingleton<IDialogService>(new DroidDialogService());
            Mvx.RegisterSingleton<IDialogService>(new DroidDialogService());
            Mvx.RegisterSingleton<ISharedPreferencesService>(new DroidSharedPreferencesService());
            Mvx.RegisterSingleton<IMainActivityService>(new DroidMainActivityService());
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new NavigationDrawerPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);
            return mvxFragmentsPresenter;
        }
    }
}
