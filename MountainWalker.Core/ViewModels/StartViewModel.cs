using System;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;

namespace MountainWalker.Core.ViewModels
{
    public class StartViewModel : MvxViewModel
    {
        private ISharedPreferencesService _sharedPreferencesService;
        public StartViewModel(ISharedPreferencesService sharedPreferencesService)
        {
            _sharedPreferencesService = sharedPreferencesService;
        }

        public override Task Initialize()
        {
            CheckPreferences();
            return base.Initialize();
        }

        private void CheckPreferences()
        {
            string userName = string.Empty;
            string password = string.Empty;
            _sharedPreferencesService.CheckSharedPreferences(ref userName, ref password);

            if (userName == String.Empty || password == String.Empty)
            {
                //There is no saved credentials, take user to the login page
                ShowViewModel<SignInViewModel>();
            }
            else
            {
                //There are saved credentials

                /*This is where you would query the database
                 * 
                 * 
                 * 
                 Done querying*/

                if (userName == "admin" && password == "admin")
                {
                    //Successful so take the user to application
                    ShowViewModel<MainViewModel>();
                }
                else
                {
                    //Unsuccesful so take user to login screen

                    //Clean SharedPreferences
                    _sharedPreferencesService.CleanSharedPreferences();

                    ShowViewModel<SignInViewModel>();
                }
            }
        }
    }
}
