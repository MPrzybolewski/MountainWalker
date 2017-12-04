using System.Diagnostics;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class DialogViewModel : MvxViewModel
    {
        public IMvxCommand DialogCommand;

        public DialogViewModel()
        {
            DialogCommand = new MvxCommand(DialogClick);
        }

        private void DialogClick()
        {
            Debug.WriteLine("DAWAJ PLSSSSS");
        }


    }
}