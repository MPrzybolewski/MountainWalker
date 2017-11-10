using System;
namespace MountainWalker.Core.Interfaces
{
    public interface IDialogAlert
    {
        void Alert(string title, string message, string okButtonText);
    }
}
