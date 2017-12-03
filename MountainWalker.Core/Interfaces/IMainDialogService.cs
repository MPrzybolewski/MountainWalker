namespace MountainWalker.Core.Interfaces
{
    public interface IMainDialogService
    {
        void Show(string pointName, bool canStart);
        void Close();
    }
}