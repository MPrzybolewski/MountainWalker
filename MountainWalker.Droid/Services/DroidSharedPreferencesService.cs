using System;
using Android.App;
using Android.Content;
using MountainWalker.Core.Interfaces;

namespace MountainWalker.Droid.Services
{
    public class DroidSharedPreferencesService : ISharedPreferencesService
    {
        public void CheckSharedPreferences(ref string userName, ref string password)
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            userName = pref.GetString("UserName", String.Empty);
            password = pref.GetString("Password", String.Empty);
        }

        public void CleanSharedPreferences()
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.Clear();
            edit.Apply();
        }

        public void SetSharedPreferences(string userName, string password)
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.PutString("UserName", userName);
            edit.PutString("Password", password);
            edit.Apply();
        }
    }
}
