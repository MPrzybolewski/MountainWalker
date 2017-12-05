using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

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

        public RegisterViewModel(IDialogService dialogService, IWebAPIService webAPIService)
        {
            _dialogService = dialogService;
            _webAPIService = webAPIService;
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

        public IMvxCommand RegisterButton => new MvxCommand(Walidate);
        private async void Walidate()
        {
            if (_password.Equals(_repPassword))
            {
                string RestUrl = "http://mountainwalkerwebapi.azurewebsites.net";
                string result = await _webAPIService.CheckIfUserCanRegister(RestUrl, _name, _surname, _login, _password, _email);
                if (result.Trim(new char[] { '"' }).Equals("true"))
                {
                    _dialogService.ShowAlert("Powiadomienie!", "Rejestracja przebiegła pomyślnie", "OK");
                    ShowViewModel<SignInViewModel>();
                }
            }         
            else
            {
                _dialogService.ShowAlert("Uwaga!", "Dane są nieprawidłowe!", "OK");
            }
        }
    }
}
