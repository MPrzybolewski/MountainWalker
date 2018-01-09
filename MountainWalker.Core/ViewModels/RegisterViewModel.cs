using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Acr.UserDialogs;

namespace MountainWalker.Core.ViewModels
{
    class RegisterViewModel : MvxViewModel
    {
        private string _name = "";
        private string _surname = "";
        private string _login = "";
        private string _password = "";
        private string _repPassword = "";
        private string _email = "";
        private readonly IDialogService _dialogService;
        private readonly IWebAPIService _webAPIService;
        private readonly IMvxNavigationService _navigationService;

        public RegisterViewModel(IDialogService dialogService, IWebAPIService webAPIService, IMvxNavigationService navigationService)
        {
            _dialogService = dialogService;
            _webAPIService = webAPIService;
            _navigationService = navigationService;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
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
        public string RepPassword
        {
            get { return _repPassword; }
            set { _repPassword = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public IMvxCommand RegisterButton => new MvxCommand(Validate);
        private async void Validate()
        {
            if (_password.Equals(_repPassword))
            {
                bool result = await CheckIfRegistered();
                if (result)
                {
                    _navigationService.Navigate<SignInViewModel>();
                }
                else
                {
                    _dialogService.ShowAlert("Uwaga!", "Błędne dane. Nie można zarejestrować!", "OK");
                    _navigationService.Navigate<RegisterViewModel>();
                }
            }
            else
            {
                _dialogService.ShowAlert("Uwaga!", "Podane hasła są nieprawidłowe!", "OK");
            }
        }

        public async Task<bool> CheckIfRegistered()
        {

            UserDialogs.Instance.ShowLoading("Rejestrowanie...");
            string RestUrl = "http://mountainwalkerwebapi.azurewebsites.net/api/users/" + _login + "?password=" +
                             _password;
            string result = await _webAPIService.CheckIfUserCanLogin(RestUrl);
            if (result.Trim(new char[] { '"' }).Equals("true"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
