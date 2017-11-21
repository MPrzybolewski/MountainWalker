using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MountainWalker.Core.ViewModels
{
    public class SignInViewModel : MvxViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly ISharedPreferencesService _sharedPreferencesService;

        public SignInViewModel(IDialogService dialogService, ISharedPreferencesService sharedPreferencesService)
        {
            _dialogService = dialogService;
            _sharedPreferencesService = sharedPreferencesService;

        }

        public override Task Initialize()
        {
            CheckPreferences();
            return base.Initialize();
        }

        public IMvxCommand SignInButton => new MvxCommand(CheckFields);
        private void CheckFields()
        {
            if(_isChecked == true)
            {
                _sharedPreferencesService.SetSharedPreferences(_login,_password);
            }

            if (_login.Equals("admin") && _password.Equals("admin"))
            {
                ShowViewModel<MainViewModel>();
            }
            else
            {
                _dialogService.ShowAlert("Uwaga!", "Dane są nieprawidłowe", "OK");
            }


        }

        public IMvxCommand RegisterButton => new MvxCommand(JumpRegister);
        private void JumpRegister()
        {
            ShowViewModel<RegisterViewModel>();
        }

        private string _login;
        private string _password;
        private bool _isChecked;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
               // RaisePropertyChanged(() => IsChecked);
            }
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
