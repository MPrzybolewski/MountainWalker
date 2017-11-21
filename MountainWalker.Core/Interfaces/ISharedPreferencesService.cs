using System;
namespace MountainWalker.Core.Interfaces
{
    public interface ISharedPreferencesService
    {
        void SetSharedPreferences(string userName, string password);
        void CheckSharedPreferences(ref string userName, ref string password);
        void CleanSharedPreferences();
    }
}
