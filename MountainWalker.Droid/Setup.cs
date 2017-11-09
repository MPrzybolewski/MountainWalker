using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

using Android.App;
using MountainWalker.Core.ViewModels;

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
            base.InitializeLastChance();
            //register a signle instrance of IDialogAlert
            Mvx.RegisterSingleton<IDialogAlert>(new DroidDialogAlert());

        }

        public class DroidDialogAlert : IDialogAlert
        {
            public void Alert(string title, string message, string okButtonText)
            {
                var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
                var act = top.Activity;

                var adb = new AlertDialog.Builder(act);
                adb.SetTitle(title);
                adb.SetMessage(message);
                adb.SetPositiveButton("Ok", (s, ev) => { });
                adb.Create().Show();
            }
        }
    }
}
