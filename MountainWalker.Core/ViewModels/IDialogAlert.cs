using System;
namespace MountainWalker.Core.ViewModels
{
    public interface IDialogAlert
    {
        void Alert(string title, string message, string okButtonText);
    }
}
