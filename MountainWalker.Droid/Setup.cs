using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

using Android.App;
using MountainWalker.Core.Interfaces;
using MountainWalker.Core.ViewModels;

using MountainWalker.Core.Interfaces;
using MountainWalker.Droid.Services;
using MvvmCross.Platform.IoC;

using MountainWalker.Droid.Source;


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

        protected override void InitializeLastChance()
        {
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            base.InitializeLastChance();
            //register a signle instrance of IDialogAlert
            Mvx.RegisterSingleton<IDialogService>(new DroidDialogAlert());
            Mvx.RegisterSingleton<ILocationActivity>(new DroidLocation());

        }
    }
}
