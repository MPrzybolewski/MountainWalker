using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

using Android.App;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.ViewModels;

using MountainWalker.Droid.Services;
using MvvmCross.Platform.IoC;


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
            Mvx.RegisterSingleton<IRegisterService>(new DroidRegisterService());
            Mvx.RegisterSingleton<ISharedPreferencesService>(new DroidSharedPreferencesService());
        }
    }
}
