using System;
namespace MountainWalker.Core.Interfaces
{
    public interface IDialogService
    {
        void ShowAlert(string title, string message, string okButtonText);
    }
}
