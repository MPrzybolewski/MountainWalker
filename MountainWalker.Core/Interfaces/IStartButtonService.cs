using System;
namespace MountainWalker.Core.Interfaces
{
    public interface IStartButtonService
    {
        void OnStartButton();
        void SetStartButtonText(string buttonText);
        string GetStartButtonText();
    }
}
